using System;
using tabuleiro;
using xadrez;
namespace Xadrez_Console {
    class Program {
        static void Main(string[] args) {
            try {
                PartidaDeXadrez partida = new PartidaDeXadrez();
                //Tela.ImprimirTabuleiro(partida.Tab);

                while (!partida.Terminada) {
                    try {
                        Console.Clear();
                        Tela.ImprimirPartida(partida);

                        Console.WriteLine();
                        Console.Write("Digite a posição de origem: ");
                        Posicao origem = Tela.LerPosicaoXadrez().toPosicao();
                        bool[,] posicoesPossiveis = partida.Tab.Peca(origem).MovimentosPossiveis();
                        partida.ValidarPosicaoDeOrigem(origem);
                        Console.Clear();
                        Tela.ImprimirTabuleiro(partida.Tab, posicoesPossiveis);
                        Console.Write("Digite a posição de destino: ");
                        Posicao destino = Tela.LerPosicaoXadrez().toPosicao();
                        partida.ValidarPosicaoDeDestino(origem, destino);

                        partida.RealizaJogada(origem, destino);
                    }catch(TabuleiroException e) {
                        Console.WriteLine(e.Message);
                        Console.ReadLine();
                    }
                }
            }catch(TabuleiroException e) {
                Console.WriteLine(e.Message);
            }

            Console.ReadLine();
        }
    }
}
