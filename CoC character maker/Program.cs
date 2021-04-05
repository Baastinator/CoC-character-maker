using System;

namespace CoC_character_maker
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] stats = new int[9]; 
            bool exit = false;
            Char character;
            while (true)
            {
                //initial stat generation
                while (true) 
                {
                    Console.Clear();
                    stats = Char.GenerateStats();
                    Display(stats);
                    Console.WriteLine();

                    Console.Write("R to Reroll, C to Cancel, S to Shift values: ");
                    string Input = Console.ReadLine();

                    if (Input == "C")
                    {
                        exit = true;
                        break;
                    } else if (Input == "R")
                    {

                    } else if (Input == "S")
                    {
                        break;
                    }
                }
                if (exit)
                {
                    break;
                }
                bool matching = true;
                //switch stat position
                while (true) 
                {
                    Console.Clear();
                    if (!matching)
                    {
                        Console.WriteLine("Invalid Input: dice types must be matching");
                        Console.WriteLine();
                        matching = true;
                    }
                    int num1, num2;
                    Display(stats);
                    Console.Write("Select the index to move (C to cancel, F to finish): ");
                    string Input = Console.ReadLine();
                    if (Input == "C")
                    {
                        exit = true;
                        break;
                    } else if (Input == "F") 
                    {
                        break;
                    } else
                    {
                        num1 = Convert.ToInt32(Input) - 1;
                    }
                    Console.Write("Select the index to replace with: ");
                    Input = Console.ReadLine();
                    if (Input == "C")
                    {
                        exit = true;
                        break;
                    } else
                    {
                        num2 = Convert.ToInt32(Input) - 1;
                        if (IsTwoD(num1) && IsTwoD(num2))
                        {
                            int carry = stats[num2];
                            stats[num2] = stats[num1];
                            stats[num1] = carry;
                        } else if (!IsTwoD(num1) && !IsTwoD(num2))
                        {
                            int carry = stats[num2];
                            stats[num2] = stats[num1];
                            stats[num1] = carry;
                        } else
                        {
                            matching = false;
                        }
                    }
                }
                if (exit)
                {
                    break;
                }
                //set initial stats
                character = new Char(stats);
                int[] intData = new int[2];
                string[] stringData = new string[4];
                //get misc data
                while (true)
                {
                    Console.Clear();
                    for (int i = 0; i <= 5; i++)
                    {
                        string key = ""; //string name, string job, int age, string sex, string residence, int CR
                        switch (i)
                        {
                            case 0:
                                key = "Name";
                                break;
                            case 1:
                                key = "Job";
                                break;
                            case 2:
                                key = "Age";
                                break;
                            case 3:
                                key = "Sex";
                                break;
                            case 4:
                                key = "Residence";
                                break;
                            case 5:
                                key = "CR";
                                break;
                        }
                        Console.Write(key + " (C to cancel): ");
                        string Input = Console.ReadLine();


                        if (Input == "C")
                        {
                            exit = true;
                            break;
                        }
                        switch (i)
                        {
                            case 0:
                                stringData[0] = Input;
                                break;
                            case 1:
                                stringData[1] = Input;
                                break;
                            case 2:
                                intData[0] = Convert.ToInt32(Input);
                                break;
                            case 3:
                                stringData[2] = Input;
                                break;
                            case 4:
                                stringData[3] = Input;
                                break;
                            case 5:
                                intData[1] = Convert.ToInt32(Input);
                                break;
                        }
                    }
                    break;
                }
                if (exit)
                {
                    break;
                }
                //set misc data
                character.ExtraData(stringData, intData);
                //display all data
                while (true)
                {
                    Console.Clear();

                    DisplayAll(character);

                    Console.WriteLine();

                    Console.Write("enter \"Exit\" to exit program: ");
                    string Input = Console.ReadLine();
                    
                    if (Input == "Exit")
                    {
                        exit = true;
                        break;
                    }
                }
                if (exit)
                {
                    break;
                }
            }
        }
        static void Display(int[] stats)  //display stats
        {
            int i = 0;
            foreach (int numbers in stats)
            {
                switch (i)
                {
                    case 0:
                        Console.Write("1) STR  | ");
                        break;
                    case 1:
                        Console.Write("2) CON  | ");
                        break;
                    case 2:
                        Console.Write("3) SIZ  | ");
                        break;
                    case 3:
                        Console.Write("4) DEX  | ");
                        break;
                    case 4:
                        Console.Write("5) APP  | ");
                        break;
                    case 5:
                        Console.Write("6) EDU  | ");
                        break;
                    case 6:
                        Console.Write("7) INT  | ");
                        break;
                    case 7:
                        Console.Write("8) POW  | ");
                        break;
                    case 8:
                        Console.Write("9) Luck | ");
                        break;
                }
                Console.Write(numbers);
                if (i == 2 || i == 5 || i == 6)
                {
                    Console.WriteLine(" | 2d6+6 * 5");
                }
                else
                {
                    Console.WriteLine(" | 3d6   * 5");
                }
                i++;
            }
        } 
        static bool IsTwoD(int i)  //checks if index is part of 2d6+6 group
        {
            bool output = false;
            if (i == 2 || i == 5 || i == 6)
            {
                output = true;
            }            
            return output;
        }
        static void DisplayAll(Char character) //display all stats
        {
            Console.WriteLine("Name       " + character.name);
            Console.WriteLine("Age        " + character.age);
            Console.WriteLine("Sex        " + character.sex);
            Console.WriteLine("Residence  " + character.residence);
            Console.WriteLine("Job        " + character.job);
            Console.WriteLine();
            Console.WriteLine("STR        " + character.STR);
            Console.WriteLine("CON        " + character.CON);
            Console.WriteLine("SIZ        " + character.SIZ);
            Console.WriteLine("DEX        " + character.DEX);
            Console.WriteLine("APP        " + character.APP);
            Console.WriteLine("EDU        " + character.EDU);
            Console.WriteLine("INT        " + character.INT);
            Console.WriteLine("POW        " + character.POW);
            Console.WriteLine();
            Console.WriteLine("CR         " + character.CR);
            Console.WriteLine("Cash       " + character.cash);
            Console.WriteLine("Assets     " + character.assets);
            Console.WriteLine("S. Level   " + character.S_LVL);
            Console.WriteLine();
            Console.WriteLine("Luck       " + character.luck);
            Console.WriteLine("HP         " + character.HP);
            Console.WriteLine("Sanity     " + character.sanity);
            Console.WriteLine("MOV        " + character.MOV);
            Console.WriteLine("Build      " + character.build);
            Console.WriteLine("DB         " + character.DB);
        }
    }
}
