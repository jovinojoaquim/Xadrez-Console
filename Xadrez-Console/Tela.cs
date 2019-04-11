using System;
using System.Collections.Generic;
using System.Text;
using tabuleiro;
using xadrez;

namespace Xadrez_Console {
    class Tela {
        public static void ImprimirTabuleiro(Tabuleiro tab) {

            for (int i = 0; i < tab.Linhas; i++) {
                Console.Write(8 - i + " ");
                for (int j = 0; j < tab.Colunas; j++) {
                    ImprimirPeca(tab.Peca(i, j));
                }
                Console.WriteLine();
            }
            Console.WriteLine("  a b c d e f g h");
        }

        public static PosicaoXadrez LerPosicaoXadrez() {
            string s = Console.ReadLine();
            char coluna = s[0];
            int linha = int.Parse(s[1] + "");
            return new PosicaoXadrez(coluna, linha);
        }

        public static void ImprimirTabuleiro(Tabuleiro tab, bool[,] posicoesPossiveis) {

            ConsoleColor fundoOriginal = Console.BackgroundColor;
            ConsoleColor fundoAlterado = ConsoleColor.DarkGray; 
            for (int i = 0; i < tab.Linhas; i++) {
                Console.Write(8 - i + " ");
                for (int j = 0; j < tab.Colunas; j++) {
                    if (posicoesPossiveis[i, j]) {
                        Console.BackgroundColor = fundoAlterado;
                    }
                    else {
                        Console.BackgroundColor = fundoOriginal;
                    }
                    ImprimirPeca(tab.Peca(i, j));
                    Console.BackgroundColor = fundoOriginal;
                }
                Console.WriteLine();
            }
            Console.WriteLine("  a b c d e f g h");
        }

        public static void ImprimirPeca(Peca peca) {

            if (peca == null) {
                Console.Write("- ");
            }

            else {

                if (peca.Cor == Cor.Branca) {
                    Console.Write(peca);
                }
                else {
                    ConsoleColor aux = Console.ForegroundColor;
                    Console.ForegroundColor = ConsoleColor.Yellow;
                    Console.Write(peca);
                    Console.ForegroundColor = aux;

                }

            }

        }

        public static void ImprimirPartida(PartidaDeXadrez partida) {
            Tela.ImprimirTabuleiro(partida.Tab);
            Console.WriteLine();
            ImprimirPecasCapturadas(partida);

            Console.WriteLine("Turno " + partida.Turno);
            Console.WriteLine("Aguardando Jogada: " + partida.JogadorAtual);
        }

        public static void ImprimirPecasCapturadas(PartidaDeXadrez partida) {
            Console.WriteLine("Peças Capturadas: ");
            Console.Write("Brancas: ");
            ImprimirConjunto(partida.PecasCapturadas(Cor.Branca));
            Console.WriteLine();
            Console.Write("Pretas: ");
            ImprimirConjunto(partida.PecasCapturadas(Cor.Preta));
            Console.WriteLine();
            Console.WriteLine();
        }

        private static void ImprimirConjunto(HashSet<Peca> Conjunto) {
            Console.Write("[");
            foreach(Peca x in Conjunto) {
                Console.Write(x+" ");
            }
            Console.Write("]");
        }
    }
}
