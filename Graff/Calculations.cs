using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Graff
{
    public static class Calculations
    {
        public static void FormatStringX(float number, ref string input)
        {
            for(int i = 0; i < input.Length; i++)
            {
                if(input[i] == 'x')
                {
                    string suf = input.Substring(0, i);
                    string mid = number.ToString("F3");
                    string pref = (i + 1 < input.Length) ? input.Substring(i + 1) : "";
                    input = suf + mid + pref;
                    i += mid.Length - 1;
                }
            }
        }

        //function return factorial of a number
        public static int Factorial(int number)
        {
            int result = 1;

            //loop doesn't run if number is <= 1
            for (int i = 2; i <= number; i++)
            {
                result *= i;
            }
            //end loop doesn't run if number is <= 1

            return result;
        }
        //end function return factorial of a number

        //function to calculate nCr
        public static int C(int n, int r)
        {
            int result = 1;

            //multiply from n upto before (n-r)
            for (int i = n; i > n - r; i--)
            {
                result *= i;
            }
            //end multiply from n upto before (n-r)

            //loop doesn't run if number is <= 1
            for (int i = 1; i <= r; i++)
            {
                result /= i;
            }
            //end loop doesn't run if number is <= 1

            return result;
        }
        //end function to calculate nCr

        //function to calculate nPr
        public static int P(int n, int r)
        {
            int result = 1;

            //multiply from n upto before (n-r)
            for (int i = n; i > n - r; i--)
            {
                result *= i;
            }
            //end multiply from n upto before (n-r)

            return result;
        }
        //end function to calculate nPr

        //provide parent function name in 'Calculate"
        //function as parameter as a member of enum here
        public enum Functions { NONE, SIN, COS, TAN, ASIN, ACOS, ATAN, LOG, LN, DEG, RAD };

        //main solving function
        //it solves the children brackets first
        //solves recursively
        //'functionName' argument takes name of function (within the enum)
        //on left of pair of parent brackets
        public static string Calculate(string input, Functions functionName = Functions.NONE)
        {
            List<char> operators = new List<char>();
            List<float> numbers = new List<float>();

            bool bracketFound = false;
            int bracketVal = 0;
            int bracketStart = -1, bracketEnd = -1;


            //detect pair of brackets and calculate what is inside recursively
            for (int i = 0; i < input.Length; i++)
            {
                if (input[i] == '(')
                {
                    if (!bracketFound)
                    {
                        bracketFound = true;
                        bracketStart = i;
                    }

                    bracketVal++;
                }
                else if (input[i] == ')')
                {
                    bracketVal--;

                    if (bracketVal == 0)
                    {
                        bracketFound = false;
                        bracketEnd = i;
                    }
                }

                //put everything inside pair of brackets found in 'Calculate' function
                if (bracketStart != -1 && bracketEnd != -1)
                {
                    string mid = "";
                    bool funcFound = false;

                    //first look for mathematical functions with 4 characters
                    //on the left of pair of brackets found
                    //then those with 3 characters

                    if (!funcFound && bracketStart - 4 >= 0)
                    {
                        if (input.Substring(bracketStart - 4, 4) == "asin")
                        {
                            mid = Calculate(input.Substring(bracketStart + 1, bracketEnd - bracketStart - 1), Functions.ASIN);
                            bracketStart -= 4;
                            funcFound = true;
                        }
                        else if (input.Substring(bracketStart - 4, 4) == "acos")
                        {
                            mid = Calculate(input.Substring(bracketStart + 1, bracketEnd - bracketStart - 1), Functions.ACOS);
                            bracketStart -= 4;
                            funcFound = true;
                        }
                        else if (input.Substring(bracketStart - 4, 4) == "atan")
                        {
                            mid = Calculate(input.Substring(bracketStart + 1, bracketEnd - bracketStart - 1), Functions.ATAN);
                            bracketStart -= 4;
                            funcFound = true;
                        }
                    }

                    if (!funcFound && bracketStart - 3 >= 0)
                    {
                        if (input.Substring(bracketStart - 3, 3) == "sin")
                        {
                            mid = Calculate(input.Substring(bracketStart + 1, bracketEnd - bracketStart - 1), Functions.SIN);
                            bracketStart -= 3;
                            funcFound = true;
                        }
                        else if (input.Substring(bracketStart - 3, 3) == "cos")
                        {
                            mid = Calculate(input.Substring(bracketStart + 1, bracketEnd - bracketStart - 1), Functions.COS);
                            bracketStart -= 3;
                            funcFound = true;
                        }
                        else if (input.Substring(bracketStart - 3, 3) == "tan")
                        {
                            mid = Calculate(input.Substring(bracketStart + 1, bracketEnd - bracketStart - 1), Functions.TAN);
                            bracketStart -= 3;
                            funcFound = true;
                        }
                        else if (input.Substring(bracketStart - 3, 3) == "log")
                        {
                            mid = Calculate(input.Substring(bracketStart + 1, bracketEnd - bracketStart - 1), Functions.LOG);
                            bracketStart -= 3;
                            funcFound = true;
                        }
                        else if (input.Substring(bracketStart - 3, 3) == "deg")
                        {
                            mid = Calculate(input.Substring(bracketStart + 1, bracketEnd - bracketStart - 1), Functions.DEG);
                            bracketStart -= 3;
                            funcFound = true;
                        }
                        else if (input.Substring(bracketStart - 3, 3) == "rad")
                        {
                            mid = Calculate(input.Substring(bracketStart + 1, bracketEnd - bracketStart - 1), Functions.RAD);
                            bracketStart -= 3;
                            funcFound = true;
                        }
                    }

                    if (!funcFound && bracketStart - 2 >= 0)
                    {
                        if (input.Substring(bracketStart - 2, 2) == "ln")
                        {
                            mid = Calculate(input.Substring(bracketStart + 1, bracketEnd - bracketStart - 1), Functions.LN);
                            bracketStart -= 2;
                            funcFound = true;
                        }
                    }

                    if (!funcFound)
                    {
                        mid = Calculate(input.Substring(bracketStart + 1, bracketEnd - bracketStart - 1));
                    }

                    input = ((bracketStart > 0) ? input.Substring(0, bracketStart) : "") + mid + ((bracketEnd + 1 < input.Length) ? input.Substring(bracketEnd + 1) : "");
                    i = bracketStart - 1 + mid.Length;
                    bracketStart = bracketEnd = -1;
                }
                //end put everything inside pair of brackets found in 'Calculate' function
            }
            //end detect pair of brackets and calculate what is inside recursively

            //consider a '0' before if first character is '+' or '-'
            if (input[0] == '+' || input[0] == '-')
            {
                input = "0" + input;
            }
            //end consider a '0' before if first character is '+' or '-'

            //seperating operators from digits
            for (int i = 0; i < input.Length; i++)
            {
                if (input[i] == '+' || input[i] == '-' || input[i] == '*' ||
                    input[i] == '/' || input[i] == '^' || input[i] == 'C' ||
                    input[i] == 'P' || input[i] == '!')
                {
                    operators.Add(input[i]);

                    input = input.Substring(0, i) + " " + input.Substring(i + 1);

                    //ignore next '-', consider as negative number
                    if (i + 1 < input.Length && input[i + 1] == '-')
                    {
                        i++;
                    }
                    //end ignore next '-', consider as negative number
                }
            }
            //end seperating operators from digits

            List<string> numbersString = new List<string>(input.Split()); //keeping digits seperated by ' ' in a List<string>

            //making another List<float> parsing float from List<string> 'numbersString'
            foreach (string numStr in numbersString)
            {
                if (!numStr.Equals(string.Empty))
                {
                    numbers.Add(float.Parse(numStr));
                }
            }
            //end making another List<float> parsing float from List<string> 'numbersString'

            /*
             * handle operators chronologically:
             * * '^'
             * * 'C' or 'P'
             * * '*'or '/'
             * * '+' or '-'
             */

            //handling '!' operator
            for (int i = 0; i < operators.Count;)
            {
                if (operators[i] == '!')
                {
                    numbers[i] = Factorial((int)numbers[i]);

                    operators.RemoveAt(i);
                }
                else
                {
                    i++;
                }
            }
            //end handling '!' operator

            //handling '^' operator
            for (int i = 0; i < operators.Count;)
            {
                if (operators[i] == '^')
                {
                    numbers[i] = (float)Math.Pow(numbers[i], numbers[i + 1]);

                    numbers.RemoveAt(i + 1);
                    operators.RemoveAt(i);
                }
                else
                {
                    i++;
                }
            }
            //end handling '^' operator

            //handling 'C' or 'P' operator
            for (int i = 0; i < operators.Count;)
            {
                if (operators[i] == 'C')
                {
                    if (numbers[i + 1] > numbers[i] || numbers[i].GetType() != typeof(int) ||
                        numbers[i + 1].GetType() != typeof(int))
                    {
                        numbers[i] = float.NaN;
                    }
                    else
                    {
                        numbers[i] = C((int)numbers[i], (int)numbers[i + 1]);
                    }

                    numbers.RemoveAt(i + 1);
                    operators.RemoveAt(i);
                }
                else if (operators[i] == 'P')
                {
                    if (numbers[i + 1] > numbers[i] || numbers[i].GetType() != typeof(int) ||
                        numbers[i + 1].GetType() != typeof(int))
                    {
                        numbers[i] = float.NaN;
                    }
                    else
                    {
                        numbers[i] = P((int)numbers[i], (int)numbers[i + 1]);
                    }

                    numbers.RemoveAt(i + 1);
                    operators.RemoveAt(i);
                }
                else
                {
                    i++;
                }
            }
            //end handling 'C' or 'P' operator

            //handling '*' or '/' operator
            for (int i = 0; i < operators.Count;)
            {
                if (operators[i] == '*')
                {
                    numbers[i] *= numbers[i + 1];

                    numbers.RemoveAt(i + 1);
                    operators.RemoveAt(i);
                }
                else if (operators[i] == '/')
                {
                    if (numbers[i + 1] == 0)
                    {
                        numbers[i] = float.NaN;
                    }
                    else
                    {
                        numbers[i] /= numbers[i + 1];
                    }

                    numbers.RemoveAt(i + 1);
                    operators.RemoveAt(i);
                }
                else
                {
                    i++;
                }
            }
            //end handling '*' or '/' operator

            //handling '+' or '-' operator
            for (int i = 0; i < operators.Count;)
            {
                if (operators[i] == '+')
                {
                    numbers[i] += numbers[i + 1];

                    numbers.RemoveAt(i + 1);
                    operators.RemoveAt(i);
                }
                else if (operators[i] == '-')
                {
                    numbers[i] -= numbers[i + 1];

                    numbers.RemoveAt(i + 1);
                    operators.RemoveAt(i);
                }
                else
                {
                    i++;
                }
            }
            //end handling '+' or '-' operator

            //check function by most outward pair of brackets
            if (functionName == Functions.SIN)
            {
                return Math.Sin(numbers[0] * (Math.PI / 180f)).ToString("F3");
            }
            else if (functionName == Functions.COS)
            {
                return Math.Cos(numbers[0] * (Math.PI / 180f)).ToString("F3");
            }
            else if (functionName == Functions.TAN)
            {
                if (numbers[0] % 90 == 0)
                {
                    return float.NaN.ToString("F3");
                }
                else
                {
                    return Math.Tan(numbers[0] * (Math.PI / 180f)).ToString("F3");
                }
            }
            else if (functionName == Functions.ASIN)
            {
                return (Math.Asin(numbers[0]) * (180f / Math.PI)).ToString("F3");
            }
            else if (functionName == Functions.ACOS)
            {
                return (Math.Acos(numbers[0]) * (180f / Math.PI)).ToString("F3");
            }
            else if (functionName == Functions.ATAN)
            {
                return (Math.Atan(numbers[0]) * (180f / Math.PI)).ToString("F3");
            }
            else if (functionName == Functions.LOG)
            {
                return Math.Log10(numbers[0]).ToString("F3");
            }
            else if (functionName == Functions.LN)
            {
                return Math.Log(numbers[0]).ToString("F3");
            }
            else if (functionName == Functions.DEG)
            {
                return (numbers[0] * (180.0 / Math.PI)).ToString("F3");
            }
            else if (functionName == Functions.RAD)
            {
                return (numbers[0] * (Math.PI / 180.0)).ToString("F3");
            }
            //end check function by most outward pair of brackets

            return numbers[0].ToString("F3");
            //return as it is if there is no function
            //clamping to show INFINITY and -INFINITY values as per my intention in some case(s) :3
        }
        //end main solving function

    }
}
