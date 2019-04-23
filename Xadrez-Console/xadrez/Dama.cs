using System;
using tabuleiro;

namespace xadrez {
    class Dama : Peca{
        public Dama(Tabuleiro Tab, Cor Cor) : base(Cor, Tab) {

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
            pos.definirValores(posicao.linha, posicao.coluna + 1);
            while (Tab.PosicaoValida(pos) && PodeMover(pos)) {
                mat[pos.linha, pos.coluna] = true;
                if (Tab.Peca(pos) != null && Tab.Peca(pos).Cor != Cor) {
                    break;
                }
                pos.coluna = pos.coluna + 1;
            }

            //verificando posicao esquerda;
            pos.definirValores(base.posicao.linha, base.posicao.coluna - 1);
            while (Tab.PosicaoValida(pos) && PodeMover(pos)) {
                mat[pos.linha, pos.coluna] = true;
                if (Tab.Peca(pos) != null && Tab.Peca(pos).Cor != Cor) {
                    break;
                }
                pos.coluna = pos.coluna - 1;
            }
            //verificando posicao Noroeste;
            pos.definirValores(posicao.linha - 1, posicao.coluna - 1);
            while (Tab.PosicaoValida(pos) && PodeMover(pos)) {
                mat[pos.linha, pos.coluna] = true;
                if (Tab.Peca(pos) != null && Tab.Peca(pos).Cor != Cor) {
                    break;
                }
                pos.definirValores(pos.linha - 1, pos.coluna - 1);
            }
            //verificando posicao nordeste;
            pos.definirValores(posicao.linha + 1, base.posicao.coluna);
            while (Tab.PosicaoValida(pos) && PodeMover(pos)) {
                mat[pos.linha, pos.coluna] = true;
                if (Tab.Peca(pos) != null && Tab.Peca(pos).Cor != Cor) {
                    break;
                }
                pos.definirValores(pos.linha - 1, pos.coluna + 1);
            }

            //verificando posicao sudeste;
            pos.definirValores(posicao.linha + 1, posicao.coluna + 1);
            while (Tab.PosicaoValida(pos) && PodeMover(pos)) {
                mat[pos.linha, pos.coluna] = true;
                if (Tab.Peca(pos) != null && Tab.Peca(pos).Cor != Cor) {
                    break;
                }
                pos.definirValores(pos.linha + 1, pos.coluna + 1);
            }

            //verificando posicao sudoeste;
            pos.definirValores(base.posicao.linha + 1, base.posicao.coluna - 1);
            while (Tab.PosicaoValida(pos) && PodeMover(pos)) {
                mat[pos.linha, pos.coluna] = true;
                if (Tab.Peca(pos) != null && Tab.Peca(pos).Cor != Cor) {
                    break;
                }
                pos.definirValores(pos.linha + 1, pos.coluna + 1);
            }

            return mat;
        }

        private bool PodeMover(Posicao pos) {
            Peca p = Tab.Peca(pos);
            return p == null || p.Cor != this.Cor;
        }

        public override string ToString() {
            return "D ";
        }

    }
}
