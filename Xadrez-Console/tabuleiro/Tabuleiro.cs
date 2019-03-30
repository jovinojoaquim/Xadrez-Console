using System;
using System.Collections.Generic;
using System.Text;

namespace tabuleiro {
    class Tabuleiro {
        public int Linhas { get; set; }
        public int Colunas { get; set; }
        private Peca[,] Pecas;

        public Tabuleiro(int linhas, int colunas) {
            this.Linhas = linhas;
            this.Colunas = colunas;
            Pecas = new Peca[linhas, colunas];
        }

        public Peca Peca(int linha, int coluna) {
            return Pecas[linha, coluna];
        }

        public Peca Peca(Posicao pos) {
            return Pecas[pos.linha, pos.coluna];
        }

        public void ColocarPeca(Peca peca, Posicao posicao) {
            if (ExistePeca(posicao)) {
                throw new TabuleiroException("Já existe uma peça nessa posicao");
            }
            Pecas[posicao.linha, posicao.coluna] = peca;
            peca.Posicao = posicao;
        }

        public bool ExistePeca(Posicao pos) {
            ValidarPosicao(pos);
            return Peca(pos) != null;
        }

        public void ValidarPosicao(Posicao pos) {
            if (!PosicaoValida(pos)) {
                throw new TabuleiroException("Posicao Inválida");
            }
        }

        public bool PosicaoValida(Posicao pos) {
            if (pos.linha < 0 || pos.linha >= Linhas || pos.coluna < 0 || pos.coluna >= Colunas) {
                return false;
            }
            else {
                return true;
            }
        }

        public Peca retirarPeca(Posicao posicao) {
            if (Peca(posicao) == null) {
                return null;
            }
            Peca aux = Peca(posicao);
            aux.Posicao = null;
            Pecas[posicao.linha, posicao.coluna] = null;
            return aux;
        }

    }
}
