using tabuleiro;

namespace xadrez {
    class Rei : Peca{
    
        public Rei(Tabuleiro Tab, Cor Cor) : base(Cor, Tab) {
   
        }

        public override bool[,] MovimentosPossiveis() {
            bool[,] mat = new bool[Tab.Linhas, Tab.Colunas];

            Posicao pos = new Posicao(0, 0);

            //verificando posicao acima;
            pos.definirValores(pos.linha - 1, pos.coluna);
            if(Tab.PosicaoValida(pos) && PodeMover(pos)) {
                mat[pos.linha, pos.coluna] = true;
            }

            //verificando posicao ne;
            pos.definirValores(base.posicao.linha - 1, base.posicao.coluna +1 );
            if (Tab.PosicaoValida(pos) && PodeMover(pos)) {
                mat[pos.linha, pos.coluna] = true;
            }

            //verificando posicao direita;
            pos.definirValores(pos.linha, pos.coluna +1);
            if (Tab.PosicaoValida(pos) && PodeMover(pos)) {
                mat[pos.linha, pos.coluna] = true;
            }

            //verificando posicao se;
            pos.definirValores(pos.linha + 1, pos.coluna+1);
            if (Tab.PosicaoValida(pos) && PodeMover(pos)) {
                mat[pos.linha, pos.coluna] = true;
            }

            //verificando posicao abaixo;
            pos.definirValores(pos.linha + 1, pos.coluna);
            if (Tab.PosicaoValida(pos) && PodeMover(pos)) {
                mat[pos.linha, pos.coluna] = true;
            }

            //verificando posicao so;
            pos.definirValores(pos.linha + 1, pos.coluna-1);
            if (Tab.PosicaoValida(pos) && PodeMover(pos)) {
                mat[pos.linha, pos.coluna] = true;
            }

            //verificando posicao esquerda;
            pos.definirValores(pos.linha, pos.coluna-1);
            if (Tab.PosicaoValida(pos) && PodeMover(pos)) {
                mat[pos.linha, pos.coluna] = true;
            }

            //verificando posicao no;
            pos.definirValores(pos.linha - 1, pos.coluna-1);
            if (Tab.PosicaoValida(pos) && PodeMover(pos)) {
                mat[pos.linha, pos.coluna] = true;
            }
            return mat;
        }

        private bool PodeMover(Posicao pos) {
            Peca p = Tab.Peca(pos);
            return p == null || p.Cor != this.Cor;
        }

        public override string ToString() {
            return "R";
        }

    }
}
