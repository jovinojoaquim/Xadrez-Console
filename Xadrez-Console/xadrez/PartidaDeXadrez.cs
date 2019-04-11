using System;
using System.Collections.Generic;
using System.Text;
using tabuleiro;

namespace xadrez {
    class PartidaDeXadrez {
        public Tabuleiro Tab { get; private set;  }
        public int Turno { get; set; }
        public Cor JogadorAtual { get; set; }
        public bool Terminada { get; private set; }
        private HashSet<Peca> Pecas;
        private HashSet<Peca> Capturadas;

        public PartidaDeXadrez() {
            Tab = new Tabuleiro(8, 8);
            Turno = 1;
            JogadorAtual = Cor.Branca;
            Pecas = new HashSet<Peca>();
            Capturadas = new HashSet<Peca>();
            ColocarPecas();
        }

        public void ExecutaMovimento(Posicao origem, Posicao destino) {
            Peca p = Tab.retirarPeca(origem);
            p.IncrementarQuantidadeDeMovimentos();
            Peca pecaCapturada = Tab.retirarPeca(destino);
            Tab.ColocarPeca(p, destino);
            if(pecaCapturada != null) {
                Capturadas.Add(pecaCapturada);
            }
        }

        public  HashSet<Peca> PecasCapturadas(Cor cor) {
            HashSet<Peca> aux = new HashSet<Peca>();
            foreach(Peca x in Capturadas) {
                if(x.Cor == cor) {
                    aux.Add(x);
                }
            }
            return aux;
        }

        public HashSet<Peca> PecasEmJogo(Cor cor) {
            HashSet<Peca> aux = new HashSet<Peca>();
            foreach(Peca x in aux) {
                if (x.Cor == cor) {
                    aux.Add(x);
                }
            }
            aux.ExceptWith(PecasCapturadas(cor));
            return aux;
        }


        public void ColocarNovaPeca(char col, int linha, Peca peca) {
            Tab.ColocarPeca(peca, new PosicaoXadrez(col, linha).toPosicao());
            Pecas.Add(peca);
        }

        private void ColocarPecas() {
            ColocarNovaPeca('a', 1, new Torre(Tab, Cor.Preta));
            ColocarNovaPeca('h', 1, new Torre(Tab, Cor.Preta));
            ColocarNovaPeca('a', 8, new Torre(Tab, Cor.Branca));
            ColocarNovaPeca('h', 8, new Torre(Tab, Cor.Branca));
            //Tab.ColocarPeca(new Torre(Tab, Cor.Preta), new PosicaoXadrez('c', 1).toPosicao());
        }

        public void RealizaJogada(Posicao origem, Posicao destino) {
            ExecutaMovimento(origem, destino);
            Turno++;
            MudaJogador();
        }

        private void MudaJogador() {
            if(JogadorAtual == Cor.Branca) {
                JogadorAtual = Cor.Preta;
            }
            else {
                JogadorAtual = Cor.Branca;
            }
        }

        public void ValidarPosicaoDeOrigem(Posicao pos) {
            if(Tab.Peca(pos) == null) {
                throw new TabuleiroException("Não existe peça na posicao escolhida");
            }
            if(JogadorAtual != Tab.Peca(pos).Cor) {
                throw new TabuleiroException("A peça de origem escolhida não é sua");
            }
            if (!Tab.Peca(pos).ExisteMovimentosPossiveis()) {
                throw new TabuleiroException("Não há movimentos possiveis para a peça de origem escolhida");
            }
        }

        public void ValidarPosicaoDeDestino(Posicao origem, Posicao destino) {
            if (!Tab.Peca(origem).PodeMoverPara(destino)) {
                throw new TabuleiroException("Posicao de destino inválida");
            }
        }
    }
}
