using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task_18
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string strng = GetCorrectString(); // генерирует корректную расстановку скобок
            CheckBreckets(strng);

            strng = GetInCorrectString(); // генерирует некорректную расстановку скобок
            Console.WriteLine();
            CheckBreckets(strng);

            strng = "f()56({gf}68([]gfd)96)"; // строка с корректной расстановкой скобок
            Console.WriteLine();
            CheckBreckets(strng);

            Console.ReadKey();
        }

        static string GetCorrectString() // возвращает "правильную" строку
        {
            string returnedString = "";
            string symbols = "+-!@#$%&*_=0123456789abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ";
            string stringOfBrackets = "";

            Random random = new Random();

            int countOfBracket1 = random.Next(1, 2);
            int countOfBracket2 = random.Next(1, 2);
            int countOfBracket3 = random.Next(1, 2);

            do
            {
                switch (random.Next(5))
                {
                    case (0):
                        {
                            returnedString += symbols[random.Next(symbols.Length)];
                            break;
                        }
                    case 1:
                        {
                            if (countOfBracket1 != 0)
                            {
                                returnedString += "(";
                                countOfBracket1--;
                                stringOfBrackets = ")" + stringOfBrackets;
                                break;
                            }
                            else
                            {
                                break;
                            }
                        }
                    case 2:
                        {
                            if (countOfBracket2 != 0)
                            {
                                returnedString += "{";
                                countOfBracket2--;
                                stringOfBrackets = "}" + stringOfBrackets;
                                break;
                            }
                            else
                            {
                                break;
                            }
                        }
                    case 3:
                        {
                            if (countOfBracket3 != 0)
                            {
                                returnedString += "[";
                                countOfBracket3--;
                                stringOfBrackets = "]" + stringOfBrackets;
                                break;
                            }
                            else
                            {
                                break;
                            }
                        }
                    case 4:
                        {
                            if (stringOfBrackets.Length > 0)
                            {
                                returnedString += stringOfBrackets[0];
                                stringOfBrackets = stringOfBrackets.Remove(0, 1);
                                break;
                            }
                            else
                            {
                                break;
                            }
                        }
                }
            }
            while (countOfBracket1 + countOfBracket2 + countOfBracket3 != 0);

            if (stringOfBrackets != null)
            {
                returnedString += stringOfBrackets;
            }
            return returnedString;
        }

        static string GetInCorrectString() // возвращает "неправильную" строку
        {
            string returnedString = "";
            string symbols = "+-!@#$%&*_=0123456789abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ";
            string stringOfBrackets = "";

            Random random = new Random();

            int countOfBracket1 = random.Next(1, 2);
            int countOfBracket2 = random.Next(1, 2);
            int countOfBracket3 = random.Next(1, 2);

            do
            {
                switch (random.Next(5))
                {
                    case (0):
                        {
                            returnedString += symbols[random.Next(symbols.Length)];
                            break;
                        }
                    case 1:
                        {
                            if (countOfBracket1 != 0)
                            {
                                returnedString += "(";
                                countOfBracket1--;
                                stringOfBrackets = "}" + stringOfBrackets;
                                break;
                            }
                            else
                            {
                                break;
                            }
                        }
                    case 2:
                        {
                            if (countOfBracket2 != 0)
                            {
                                returnedString += "{";
                                countOfBracket2--;
                                stringOfBrackets = "]" + stringOfBrackets;
                                break;
                            }
                            else
                            {
                                break;
                            }
                        }
                    case 3:
                        {
                            if (countOfBracket3 != 0)
                            {
                                returnedString += "[";
                                countOfBracket3--;
                                stringOfBrackets = ")" + stringOfBrackets;
                                break;
                            }
                            else
                            {
                                break;
                            }
                        }
                    case 4:
                        {
                            if (stringOfBrackets.Length > 0)
                            {
                                returnedString += stringOfBrackets[0];
                                stringOfBrackets = stringOfBrackets.Remove(0, 1);
                                break;
                            }
                            else
                            {
                                break;
                            }
                        }
                }
            }
            while (countOfBracket1 + countOfBracket2 + countOfBracket3 != 0);

            if (stringOfBrackets != null)
            {
                returnedString += stringOfBrackets;
            }
            return returnedString;
        }

        static void CheckBreckets(string strng) // проверяет строку
        {
            Stack<string> stack = new Stack<string>();

            foreach (char s in strng)
            {
                if (Equals(s, '('))
                {
                    stack.Push(")");
                    continue;
                }
                else if (Equals(s, '{'))
                {
                    stack.Push("}");
                    continue;
                }
                else if (Equals(s, '['))
                {
                    stack.Push("]");
                    continue;
                }
                else if (Equals(s, ')') && Equals(stack.Peek(), ")"))
                {
                    stack.Pop();
                    continue;
                }
                else if (Equals(s, '}') && Equals(stack.Peek(), "}"))
                {
                    stack.Pop();
                    continue;
                }
                else if (Equals(s, ']') && Equals(stack.Peek(), "]"))
                {
                    stack.Pop();
                    continue;
                }
            }

            if (stack.Count == 0)
            {
                Console.WriteLine("В строке {0} скобки расставлены корректно", strng);
            }
            else
            {
                Console.WriteLine("В строке {0} скобки расставлены некорректно", strng);
            }
        }
    }



}
