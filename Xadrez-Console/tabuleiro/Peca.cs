using System;
using System.Collections.Generic;
using System.Text;

namespace tabuleiro {
    class Peca {

        public Posicao Posicao { get; set; }
        public Cor Cor { get; protected set; }
        public int QtdMovimentos { get; set; }
        public Tabuleiro Tabuleiro { get; set; }

        public Peca(Cor cor, Tabuleiro tabuleiro) {
            this.Posicao = null;
            this.Cor = cor;
            this.Tabuleiro = tabuleiro;
            this.QtdMovimentos = 0;
        }

        public void IncrementarQuantidadeDeMovimentos() {
            QtdMovimentos++;
        }
    }
}
