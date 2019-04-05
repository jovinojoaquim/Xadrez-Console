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

        public PartidaDeXadrez() {
            Tab = new Tabuleiro(8, 8);
            Turno = 1;
            JogadorAtual = Cor.Branca;
            ColocarPecas();
        }

        public void ExecutaMovimento(Posicao origem, Posicao destino) {
            Peca p = Tab.retirarPeca(origem);
            p.IncrementarQuantidadeDeMovimentos();
            Peca pecaCapturada = Tab.retirarPeca(destino);
            Tab.ColocarPeca(p, destino);
        }

        private void ColocarPecas() {
            Tab.ColocarPeca(new Torre(Tab, Cor.Preta), new PosicaoXadrez('c', 1).toPosicao());
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
