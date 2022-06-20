using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodeChecker
{
    public static class LPISCodeChecker
    {
       
        public static void Main()
        {
            
           if( CodeChecker("(()}}"))
            {
                Console.WriteLine("Expression is Valid");
            }
           else
            {
                Console.WriteLine("Expression is NOT Valid");
            }
            Console.ReadLine();
        }
        public static bool CodeChecker(string input)
        {
             Dictionary<char, char> paranthesisPairs = new Dictionary<char, char>() {
                 { '(', ')' },
                 { '{', '}' },
                 { '[', ']' },
                 { '<', '>' }
             };

            Stack<char> stackParanthesis = new Stack<char>();

            try
            {
                // Iterate through each character in the input string
                foreach (char c in input)
                {
                    // check if the character is one of the 'opening' Paranthesis
                    if (paranthesisPairs.Keys.Contains(c))
                  
                    {
                        // if yes, push to stack
                        stackParanthesis.Push(c);
                    }
                    else
                       // check if the character is one of the 'closing' Paranthesis
                        if (paranthesisPairs.Values.Contains(c))
                      
                    {
                        // check if the closing bracket matches the 'latest' 'opening' bracket
                       // char stackFirst = stackParanthesis.FirstOrDefault();
                        //in case a closing bracket is found,  before any opening bracket it will return null
                        if (stackParanthesis.FirstOrDefault() != '\0')
                        {
                           
                            if (c == paranthesisPairs[stackParanthesis.FirstOrDefault()])
                           
                            {
                                stackParanthesis.Pop();
                            }
                            else
                            // if not, its an unbalanced string
                            
                             return false;
                        }
                        else  return false; // closing bracket occured before opening bracket 
                      
                    }
                    else
                        // continue iterating
                        continue;
                }
            }
            catch
            {
               
                return false ;
            }

            // Ensure all paranthesis are closed
             return stackParanthesis.Count == 0 ? true : false;
        }
    }
}


    

