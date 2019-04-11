using tabuleiro;
using System;

namespace xadrez {
    class Torre : Peca {

        public Torre(Tabuleiro tab, Cor cor) : base(cor, tab) {

        }

        public override bool[,] MovimentosPossiveis() {
            bool[,] mat = new bool[Tab.Linhas, Tab.Colunas];
            
            Posicao pos = new Posicao(0, 0);

            //verificando posicao acima;
           pos.definirValores(posicao.linha - 1, posicao.coluna);
            while (Tab.PosicaoValida(pos) && PodeMover(pos)) {
                mat[pos.linha, pos.coluna] = true;
                if (Tab.Peca(pos) != null && Tab.Peca(pos).Cor != Cor) {
                    break;
                }
                pos.linha = pos.linha - 1;
            }
            //verificando posicao abaixo;
            pos.definirValores(posicao.linha + 1, base.posicao.coluna);
            while (Tab.PosicaoValida(pos) && PodeMover(pos)) {
                mat[pos.linha, pos.coluna] = true;
                if (Tab.Peca(pos) != null && Tab.Peca(pos).Cor != Cor) {
                    break;
                }
                pos.linha = pos.linha + 1;
            }

            //verificando posicao direita;
            pos.definirValores(posicao.linha, posicao.coluna+1);
            while (Tab.PosicaoValida(pos) && PodeMover(pos)) {
                mat[pos.linha, pos.coluna] = true;
                if (Tab.Peca(pos) != null && Tab.Peca(pos).Cor != Cor) {
                    break;
                }
                pos.coluna = pos.coluna +1;
            }

            //verificando posicao esquerda;
            pos.definirValores(base.posicao.linha, base.posicao.coluna-1);
            while (Tab.PosicaoValida(pos) && PodeMover(pos)) {
                mat[pos.linha, pos.coluna] = true;
                if (Tab.Peca(pos) != null && Tab.Peca(pos).Cor != Cor) {
                    break;
                }
                pos.coluna = pos.coluna -1;
            }

            return mat;
        }

        private bool PodeMover(Posicao pos) {
            Peca p = Tab.Peca(pos);
            return p == null || p.Cor != this.Cor;
        }
        public override string ToString() {
            return "T ";
        }
    }
}
