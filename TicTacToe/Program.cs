using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TicTacToe
{
    class Program
    {
        static void Main(string[] args)
        {
            int player = 2;
            int entry = 0;
            bool correctEntry = true;

            do
            {
                if (player == 2)
                {
                    player = 1;
                    PutXorY(player, entry);
                }
                else if (player == 1)
                {
                    player = 2;
                    PutXorY(player, entry);
                }

                CreateBoard();


                #region  verificar si hay un ganador
                char[] allSign = { 'X', 'O' };

                foreach (char sign in allSign)
                {
                    if ((gameBoard[0, 0] == sign) && (gameBoard[0, 1] == sign) && (gameBoard[0, 2] == sign)
                        || (gameBoard[1, 0] == sign) && (gameBoard[1, 1] == sign) && (gameBoard[1, 2] == sign)
                        || (gameBoard[2, 0] == sign) && (gameBoard[2, 1] == sign) && (gameBoard[2, 2] == sign)
                        || (gameBoard[0, 0] == sign) && (gameBoard[1, 0] == sign) && (gameBoard[2, 0] == sign)
                        || (gameBoard[0, 1] == sign) && (gameBoard[1, 1] == sign) && (gameBoard[2, 1] == sign)
                        || (gameBoard[0, 2] == sign) && (gameBoard[1, 2] == sign) && (gameBoard[2, 2] == sign)
                        || (gameBoard[0, 0] == sign) && (gameBoard[1, 1] == sign) && (gameBoard[2, 2] == sign)
                        || (gameBoard[0, 2] == sign) && (gameBoard[1, 1] == sign) && (gameBoard[2, 0] == sign))
                    {
                        if (sign == 'X')
                        {
                            Console.WriteLine("Felicitaciones, ha ganado el jugador 2");
                        }
                        else
                        {
                            Console.WriteLine("Felicitaciones, ha ganado el jugador 1");
                        }

                        Console.WriteLine("Presione cualquier tecla para reiniciar el juego");
                        Console.Read();
                        entry = 0;
                        Reset();

                        break;
                    }
                    /* NO FUNCIONA
                    //empate
                    else if (turns == 10)
                    {
                        Console.WriteLine("\nEmpate");
                        Console.WriteLine("Presione cualquier tecla para reiniciar el juego");
                        Console.Read();
                        entry = 0;
                        Reset();
                        break;
                    }
                    */
                }

                #endregion

                #region verificar si el valor ingresado es valido
                do
                {
                    Console.WriteLine("\nJugador {0}: Elija un casillero...", player);
                    try
                    {
                        entry = Convert.ToInt32(Console.ReadLine());
                    }
                    catch
                    {
                        Console.WriteLine("Ingrese un numero");
                    }

                    if ((entry == 1) && (gameBoard[0, 0] == '1'))
                    {
                        correctEntry = true;
                    }
                    else if ((entry == 2) && (gameBoard[0, 1] == '2'))
                    {
                        correctEntry = true;
                    }
                    else if ((entry == 3) && (gameBoard[0, 2] == '3'))
                    {
                        correctEntry = true;
                    }
                    else if ((entry == 4) && (gameBoard[1, 0] == '4'))
                    {
                        correctEntry = true;
                    }
                    else if ((entry == 5) && (gameBoard[1, 1] == '5'))
                    {
                        correctEntry = true;
                    }
                    else if ((entry == 6) && (gameBoard[1, 2] == '6'))
                    {
                        correctEntry = true;
                    }
                    else if ((entry == 7) && (gameBoard[2, 0] == '7'))
                    {
                        correctEntry = true;
                    }
                    else if ((entry == 8) && (gameBoard[2, 1] == '8'))
                    {
                        correctEntry = true;
                    }
                    else if ((entry == 9) && (gameBoard[2, 2] == '9'))
                    {
                        correctEntry = true;
                    }
                    else
                    {
                        Console.WriteLine("\nIngrese Otro numero");
                        correctEntry = false;
                    }

                }
                while (!correctEntry);
                #endregion
            }
            while (true);
        }

        #region metodos
        //metodo identificar jugador
        public static void PutXorY(int player, int entry)
        {
            char sign = ' ';
            if(player == 1)
            {
                sign = 'X';
            }
            else if(player == 2)
            {
                sign = 'O';
            }

            switch (entry)
            {
                case 1:
                    gameBoard[0, 0] = sign;
                    break;

                case 2:
                    gameBoard[0, 1] = sign;
                    break;

                case 3:
                    gameBoard[0, 2] = sign;
                    break;

                case 4:
                    gameBoard[1, 0] = sign;
                    break;

                case 5:
                    gameBoard[1, 1] = sign;
                    break;

                case 6:
                    gameBoard[1, 2] = sign;
                    break;

                case 7:
                    gameBoard[2, 0] = sign;
                    break;

                case 8:
                    gameBoard[2, 1] = sign;
                    break;

                case 9:
                    gameBoard[2, 2] = sign;
                    break;
            }
        }

        //array que contiene variables del juego
        static char[,] gameBoard =
        {
            {'1','2','3'},
            {'4','5','6'},
            {'7','8','9'}
        };

        //array que contiene variables del juego inicial
        static char[,] initialGameBoard =
        {
            {'1','2','3'},
            {'4','5','6'},
            {'7','8','9'}
        };

        static int turns = 0;

        //metodo que crea el tablero
        public static void CreateBoard()
        {
            Console.Clear();
            Console.WriteLine("     |     |");
            Console.WriteLine("  {0}  |  {1}  |  {2}", gameBoard[0,0], gameBoard[0, 1], gameBoard[0, 2]);
            Console.WriteLine("_____|_____|_____");
            Console.WriteLine("     |     |");
            Console.WriteLine("  {0}  |  {1}  |  {2}", gameBoard[1, 0], gameBoard[1, 1], gameBoard[1, 2]);
            Console.WriteLine("_____|_____|_____");
            Console.WriteLine("     |     |");
            Console.WriteLine("  {0}  |  {1}  |  {2}", gameBoard[2, 0], gameBoard[2, 1], gameBoard[2, 2]);
            Console.WriteLine("     |     |");
            turns++;
        }                  

        //metodo reinicia todo el juego
        public static void Reset()
        {
            gameBoard = initialGameBoard;
            CreateBoard();
            turns = 0;
        }
        #endregion
    }
}
