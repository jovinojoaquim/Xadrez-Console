using System;
using tabuleiro;

namespace xadrez {
    class Peao : Peca{

        public Peao(Tabuleiro tab, Cor cor) : base(cor, tab) {

        }

        //private bool PodeMover(Posicao pos) {
        //    Peca p = Tab.Peca(pos);
        //    return p == null || p.Cor != this.Cor;
        //}

        public override string ToString() {
            return "P ";
        }

        private bool ExisteInimigo(Posicao pos) {
            Peca p = Tab.Peca(pos);
            return p == null && p.Cor != this.Cor;
        }

        private bool Livre(Posicao pos) {
            return Tab.Peca(pos) == null;
        }

        public override bool[,] MovimentosPossiveis() {
            bool[,] mat = new bool[Tab.Linhas, Tab.Colunas];
            Posicao pos = new Posicao(0, 0);

            if(Cor == Cor.Branca) {
                pos.definirValores(posicao.linha - 1, posicao.coluna);
                if(Tab.PosicaoValida(pos) && Livre(pos)) {
                    mat[pos.linha, pos.coluna] = true;
                }
                pos.definirValores(posicao.linha - 2, posicao.coluna);
                if (Tab.PosicaoValida(pos) && Livre(pos) && QtdMovimentos==0) {
                    mat[pos.linha, pos.coluna] = true;
                }
                pos.definirValores(posicao.linha - 1, posicao.coluna-1);
                if (Tab.PosicaoValida(pos) && ExisteInimigo(pos)) {
                    mat[pos.linha, pos.coluna] = true;
                }
                pos.definirValores(posicao.linha - 1, posicao.coluna+1);
                if (Tab.PosicaoValida(pos)&& ExisteInimigo(pos)) {
                    mat[pos.linha, pos.coluna] = true;
                }
            }
            else {
                pos.definirValores(posicao.linha + 1, posicao.coluna);
                if (Tab.PosicaoValida(pos) && Livre(pos)) {
                    mat[pos.linha, pos.coluna] = true;
                }
                pos.definirValores(posicao.linha + 2, posicao.coluna);
                if (Tab.PosicaoValida(pos) && Livre(pos) && QtdMovimentos == 0) {
                    mat[pos.linha, pos.coluna] = true;
                }
                pos.definirValores(posicao.linha + 1, posicao.coluna - 1);
                if (Tab.PosicaoValida(pos) && ExisteInimigo(pos)) {
                    mat[pos.linha, pos.coluna] = true;
                }
                pos.definirValores(posicao.linha + 1, posicao.coluna + 1);
                if (Tab.PosicaoValida(pos) && ExisteInimigo(pos)) {
                    mat[pos.linha, pos.coluna] = true;
                }
            }

            return mat;
        }
    }
}
