using System;
using tabuleiro;
namespace Xadrez_Console {
    class Program {
        static void Main(string[] args) {
            try {
                Tabuleiro tab = new Tabuleiro(8, 8);
                Tela.ImprimirTabuleiro(tab);

            }catch(TabuleiroException e) {
                Console.WriteLine(e.Message);
            }

            Console.ReadLine();
        }
    }
}
