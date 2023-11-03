using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Threading.Channels;

namespace Models
{
    public class Game
    {
        private String[,] _plate;
        private bool _keepGoing;    

        //private String[,] _plate;

        public Game()
        {
            _keepGoing = true;
            _plate = new string[,]
            {
                    { " 1 "," 2 "," 3 "," 4 "," 5 "," 6 "," 7 "},
                    { "|_|","|_|","|_|","|_|","|_|","|_|","|_|" },
                    { "|_|","|_|","|_|","|_|","|_|","|_|","|_|" },
                    { "|_|","|_|","|_|","|_|","|_|","|_|","|_|" },
                    { "|_|","|_|","|_|","|_|","|_|","|_|","|_|" },
                    { "|_|","|_|","|_|","|_|","|_|","|_|","|_|" },
                    { "|_|","|_|","|_|","|_|","|_|","|_|","|_|" },
            };


           // Display();

            Play();
        }

        public void Display()
        {
            for (int j = 0; j < 7; j++)
            {
                Console.WriteLine();
                for (int i = 0; i < 7; i++)
                {

                    Console.Write(_plate[j, i]);
                }
            }
            Console.WriteLine();
        }


        public bool MyTurn(string input, bool player)
        {
            int i = -1;
            int k =i;
            if (int.TryParse(input, out i))
            {
                if((i<1)||(i>7))
                {
                    return false;
                }
                for (int j = 6; j > 0; j--)
                {
                    if (_plate[j, i - 1].Equals("|_|"))
                    {
                        if (player)
                            _plate[j, i - 1] = "|X|";
                        else
                            _plate[j, i - 1] = "|O|";


                        k = j;

                        break;
                    }
                }

            }
            else
            {
                return false;
            }
            if (i > 0 && k > 0)
            {
                if(IfWin(k, i, player))
                {
                    Win(player);
                }
            }
            return true;
        }

        private void Win(bool player)
        {
            Display();
            if (player)
            {
                Console.WriteLine("Le joueur 1 a gagné");
            }
            else
            {
                Console.WriteLine("Le joueur 2 a gagné");
            }

            _keepGoing = false;
        }

        public void Play()
        {
            
            bool player = true;
            while (_keepGoing)
            {
                Display();
                if (player)
                {
                    Console.WriteLine("C'est au tour du joueur 1 de jouer");
                }
                else
                {
                    Console.WriteLine("C'est au tour du joueur 2 de jouer");
                }
                Console.WriteLine("Veuillez rentrer le numéro d'une colonne");
                if (MyTurn(Console.ReadLine(), player))
                {
                    player = player ? false : true;
                }


                //Display();
            }

        }

        public bool IfWin(int j, int i, bool player)
        {
            return (HorizontalLeft(j, i, player) || HorizontalRight(j, i, player) ||
                Vertical(j, i, player)||HorizontalTwoLeftOne(j,i,player)
                || HorizontalTwoRightOne(j, i, player) || Diagonal(j,i));            
        }

        public bool Diagonal(int j, int i)
        {
            return (DiagonalOne(j, i) || DiagonalTwo(j, i)|| DiagonalThree(j,i) || DiagonalFour(j,i)
                    || DiagonalOneBis(j,i) || DiagonalTwoBis(j,i) || DiagonalThreeBis(j,i) || DiagonalFourBis(j,i));
        }


        /// <summary>
        /// diagonal /
        /// </summary>
        /// <param name="j"></param>
        /// <param name="i"></param>
        /// <returns></returns>
        private bool DiagonalOne(int j, int i)
        {
            if ((i < 5)&&(j > 3))
            {
                for(int k = 1;k<4;k++) 
                {
                    if (_plate[j - k, i + (k - 1)] != _plate[j,i-1])
                        {
                        return false;
                        }
                }
                Console.WriteLine("!!!!!!!!!!diagonal one");
                return true;

            }
            else return false;
        }

     

        private bool DiagonalTwo(int j, int i)
        {
            if ((i < 6) && (i>1)&& (j > 2) && (j<6))
            {
                for (int k = 1; k < 3; k++)
                {
                    if ((_plate[j - k, i + (k - 1)] != _plate[j, i - 1])
                        || (_plate[j+1,i-2] != _plate[j, i - 1]))
                    {
                        return false;
                    }
                }
                Console.WriteLine("!!!!!!!diagonale two");
                return true;

            }
            else return false;
        }


 
        private bool DiagonalThree(int j, int i)
        {
            if ((i < 7) && (i > 2) && (j > 1) && (j < 5))
            {
                for (int k = 1; k < 3; k++)
                {
                    if ((_plate[j + k, (i -1)-k] != _plate[j, i - 1])
                        || (_plate[j - 1, i] != _plate[j, i - 1]))
                    {
                        return false;
                    }
                }
                Console.WriteLine("!!!!!!!diagonale three");
                return true;

            }
            else return false;
        }


        private bool DiagonalFour(int j, int i)
        {
            if ((i > 3) && (j < 4) )
            {
                for (int k = 1; k < 4; k++)
                {
                    if (_plate[j + k, (i - 1) - k] != _plate[j, i - 1])
                    {
                        return false;
                    }
                }
                Console.WriteLine("!!!!!!!diagonale four");
                return true;

            }
            else return false;
        }

        /// <summary>
        /// diagonal \
        /// </summary>
        /// <param name="j"></param>
        /// <param name="i"></param>
        /// <returns></returns>
        private bool DiagonalOneBis(int j, int i)
        {
            if ((i < 5) && (j < 4))
            {
                for (int k = 1; k < 4; k++)
                {
                    if (_plate[j + k, i + (k - 1)] != _plate[j, i - 1])
                    {
                        return false;
                    }
                }
                Console.WriteLine("!!!!!!!!!!diagonal one bis");
                return true;

            }
            else return false;
        }

        private bool DiagonalTwoBis(int j, int i)
        {
            if ((i < 6) && (i > 1) && (j > 1) && (j < 5))
            {
                for (int k = 1; k < 3; k++)
                {
                    if ((_plate[j + k, i + (k - 1)] != _plate[j, i - 1])
                        || (_plate[j - 1, i - 2] != _plate[j, i - 1]))
                    {
                        return false;
                    }
                }
                Console.WriteLine("!!!!!!!diagonale two bis");
                return true;

            }
            else return false;
        }

        private bool DiagonalThreeBis(int j, int i)
        {
            if ((i < 7) && (i > 2) && (j > 2) && (j < 6))
            {
                for (int k = 1; k < 3; k++)
                {
                    if ((_plate[j - k, (i -1) - k ] != _plate[j, i - 1])
                        || (_plate[j + 1, i] != _plate[j, i - 1]))
                    {
                        return false;
                    }
                }

                Console.WriteLine("!!!!!!!diagonale three bis");
                return true;

            }
            else return false;
        }

        private bool DiagonalFourBis(int j, int i)
        {
            if ((i > 3) && (j > 3))
            {
                for (int k = 1; k < 4; k++)
                {
                    if (_plate[j - k, (i - 1) - k] != _plate[j, i - 1])
                    {
                        return false;
                    }
                }
                Console.WriteLine("!!!!!!!diagonale four bis");
                return true;

            }
            else return false;
        }




        private bool HorizontalTwoLeftOne(int j, int i, bool player)
        {
            if ((i > 2) && (i < 6))
            {
                if (player)
                {
                    if (_plate[j, i - 2] != "|X|")
                    {
                        return false;
                    }
                    if (_plate[j, i - 3] != "|X|")
                    {
                        return false;
                    }
                    if (_plate[j, i] != "|X|")
                    {
                        return false;
                    }

                }
                if (!player)
                {
                    if (_plate[j, i - 2] != "|O|")
                    {
                        return false;
                    }
                    if (_plate[j, i - 3] != "|O|")
                    {
                        return false;
                    }
                    if (_plate[j, i] != "|O|")
                    {
                        return false;
                    }
                }

                return true;

            }
            else
            {
                return false;
            }
        }

        private bool HorizontalTwoRightOne(int j, int i, bool player)
        {
            if ((i > 0) && (i < 5))
            {
                if (player)
                {
                    if (_plate[j, i] != "|X|")
                    {
                        return false;
                    }
                    if (_plate[j, i +1] != "|X|")
                    {
                        return false;
                    }
                    if (_plate[j, i-2] != "|X|")
                    {
                        return false;
                    }

                }
                if (!player)
                {
                    if (_plate[j, i] != "|O|")
                    {
                        return false;
                    }
                    if (_plate[j, i + 1] != "|O|")
                    {
                        return false;
                    }
                    if (_plate[j, i-2] != "|O|")
                    {
                        return false;
                    }
                }

                return true;

            }

            else
            {
                return false;
            }
        }

        private bool HorizontalRight(int j, int i, bool player)
        {
            if (i < 4)
            {

                for (int k = 0; k < 3; k++)
                {
                    if (player)
                    {
                        if (_plate[j, i + k] != "|X|")
                        {
                            return false;
                        }
                    }
                    else
                    {
                        if (_plate[j, i + k] != "|O|")
                        {
                            return false;
                        }
                    }
                }

                return true;
            }
            return false;
        }

        private bool HorizontalLeft(int j, int i, bool player)
        {
            if (i>3)
            {

                for(int k = 2;k<5;k++)
                {
                    if (player)
                    {
                        if (_plate[j,i-k]!="|X|")
                        {
                            return false;
                        }
                    }
                    else
                    {
                        if (_plate[j, i - k] != "|O|")
                        {
                            return false;
                        }
                    }
                }

             
                return true;
            }
            return false;

        }

        private bool Vertical(int j, int i, bool player)
        {
            if (j < 4)
            {


                for (int k = 1; k < 4; k++)
                {
                    if (player)
                        if (_plate[j + k, i - 1] != "|X|")
                        {
                            return false;
                        }

                    if (!player)
                        if (_plate[j + k, i - 1] != "|O|")
                        {
                            return false;
                        }

                }

                return true;

            }
            else
            { return false; }



            //for(int k=j;k<)
        }
    }


}
