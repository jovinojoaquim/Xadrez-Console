using System;
using System.Collections.Generic;
using System.Text;

namespace tabuleiro {
    abstract class Peca {

        public Posicao posicao { get; set; }
        public Cor Cor { get; protected set; }
        public int QtdMovimentos { get; set; }
        public Tabuleiro Tab { get; set; }

        public Peca(Cor cor, Tabuleiro tabuleiro) {
            this.posicao = null;
            this.Cor = cor;
            this.Tab = tabuleiro;
            this.QtdMovimentos = 0;
        }

        public void IncrementarQuantidadeDeMovimentos() {
            QtdMovimentos++;
        }

        public bool ExisteMovimentosPossiveis() {
            bool[,] math = MovimentosPossiveis();
            for (int i = 0; i< Tab.Linhas; i++) {
                for(int j = 0; i<Tab.Colunas; j++) {
                    if (math[i, j]) {
                        return true;
                    }
                }
            }
            return false;
        }

        public bool PodeMoverPara(Posicao pos) {
            return MovimentosPossiveis()[pos.linha, pos.coluna];
        }

        public abstract bool[,] MovimentosPossiveis();
    }
}
