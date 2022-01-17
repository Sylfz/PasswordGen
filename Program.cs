using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp2
{
    class KeyGen//container for each character
    {
        public char Key { get; set; }
        class Program
        {
            static void Main(string[] args)
            {
                //secure password generator (v2)
                //define lists for generation
                char[] alpha = "abcdefghijklmnopqrstuvwxyz".ToCharArray();//alphabet
                char[] number = "1234567890".ToCharArray();//numbers
                char[] symbol = "!£$%^&*()_+-=".ToCharArray();//symbols
                List <KeyGen> passwordgeneration = new List<KeyGen>();//where the password will be stored

                //define variables
                int passwordlength, counter = 0, temp2;
                string temp;
                bool loop = false;
                Random pass = new Random();
                //introduction to the program
                Console.WriteLine("Welcome to Kieran's Password Generator\n" +
                    "Version 2 (2022)\n" +
                    "---");
                //what length does the user want the password to be?
                Console.WriteLine("Please choose a password length\n" +
                    "Please choose a number over 8 and below 32.");
                do//data validation
                {
                    temp = Console.ReadLine();
                    if (Int32.TryParse(temp, out passwordlength) && passwordlength > 7 && passwordlength < 33)//is a number? is greater than 8? is less than 32?
                    {
                        break;
                    }
                    Console.WriteLine("Please input a number between 8 and 32");//tell the user to reinput
                } while (!loop);
                while (counter < passwordlength)//populate the list.
                {
                    passwordgeneration.Add(new KeyGen());
                    counter++;
                }
                Console.WriteLine("Your Password is: ");
                temp2 = 0; //always start with a letter
                foreach (KeyGen a in passwordgeneration)//generate the password
                {
                    switch (temp2)
                    {
                        case 0://character
                            {
                                temp2 = pass.Next(0, 26);
                                a.Key = alpha[temp2];
                                temp2 = pass.Next(0, 2);
                                if (temp2 == 1)//should it be a lower case or an upper case?
                                {
                                    temp = Convert.ToString(a.Key);
                                    temp = temp.ToUpper();
                                    a.Key = Convert.ToChar(temp);
                                }
                                break;
                            }
                        case 1://number
                            {
                                temp2 = pass.Next(0, 10);
                                a.Key = number[temp2];
                                break;
                            }
                        case 2://symbol
                            {
                                temp2 = pass.Next(0, 13);
                                a.Key = symbol[temp2];
                                break;
                            }
                    }
                    temp2 = pass.Next(0, 3);//is the nth digit a letter, number or symbol?
                    Console.Write(a.Key);
                }
                Console.ReadKey();
            }
        }
    }
}
