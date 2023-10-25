using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Threading.Channels;

namespace Models
{
    public class Game
    {
        private String[,] _plate;

        //private String[,] _plate;

        public Game()
        {
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


            Display();

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


        public void MyTurn(string input, bool player)
        {
            int i;
            if (int.TryParse(input, out i))
            {
                for (int j = 6; j > 0; j--)
                {
                    if (_plate[j, i - 1].Equals("|_|"))
                    {
                        if (player)
                            _plate[j, i - 1] = "|X|";
                        else
                            _plate[j, i - 1] = "|O|";


                        Console.WriteLine(Win(j, i, player));

                        break;
                    }
                }
            }
        }

        public void Play()
        {
            bool keepGoing = true;
            bool player = true;
            while (keepGoing)
            {
                if (player)
                {
                    Console.WriteLine("C'est au tour du joueur 1 de jouer");
                }
                else
                {
                    Console.WriteLine("C'est au tour du joueur 2 de jouer");
                }
                Console.WriteLine("Veuillez rentrer le numéro d'une colonne");
                MyTurn(Console.ReadLine(), player);

                player = player ? false : true;



                Display();
            }

        }

        public bool Win(int j, int i, bool player)
        {
            return (HorizontalLeft(j, i, player) || HorizontalRight(j, i, player) ||
                Vertical(j, i, player));
            
            


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

                Console.WriteLine($"{player} a gagné");
                return true;
            }
            return false;
        }

        private bool HorizontalLeft(int j, int i, bool player)
        {
            if (i>2)
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

                Console.WriteLine($"{player} a gagné");
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
