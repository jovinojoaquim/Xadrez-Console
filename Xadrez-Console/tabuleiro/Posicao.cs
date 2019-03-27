using System;
using System.Collections.Generic;
using System.Text;

namespace tabuleiro {
    class Posicao {
        public int Linha { get; set; }
        public int Coluna { get; set; }

        public Posicao(int linha, int coluna) {
            this.linha = linha;
            this.coluna = coluna;
        }
    }
}
