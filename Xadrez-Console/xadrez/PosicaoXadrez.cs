﻿using tabuleiro;

namespace xadrez {
    class PosicaoXadrez {
        public char Coluna { get; set; }
        public int Linha { get; set; }

        public PosicaoXadrez(char Coluna, int Linha) {
            this.Coluna = Coluna;
            this.Linha = Linha;
        }

        public Posicao toPosicao() {
            return new Posicao(8 - Linha, Coluna - 'a');
        }

        public override string ToString() {
            return "" + Coluna + Linha;
        }
    }
}
