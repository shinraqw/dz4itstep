using dz4.TicTacToeMultiplayer;
using dz4.TicTacToeSingle;

namespace dz4
{
    internal class Program
    {
        static void Main()
        {
            //1-2
            TicTacToeS ticTacToeS = new TicTacToeS();
            ticTacToeS.Play();
            TicTacToeM ticTacToeM = new TicTacToeM();
            ticTacToeM.Play();
            //3-4
            Test3_4.num3_4();

        }
    }
}