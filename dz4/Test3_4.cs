using dz4.MorseTranslator;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace dz4
{
    namespace MorseTranslator
    {
        public class Morse
        {

            static Dictionary<char, string> morseAlphabet = new Dictionary<char, string>()
        {
            {'a', ".-"},
            {'b', "-..."},
            {'c', "-.-."},
            {'d', "-.."},
            {'e', "."},
            {'f', "..-."},
            {'g', "--."},
            {'h', "...."},
            {'i', ".."},
            {'j', ".---"},
            {'k', "-.-"},
            {'l', ".-.."},
            {'m', "--"},
            {'n', "-."},
            {'o', "---"},
            {'p', ".--."},
            {'q', "--.-"},
            {'r', ".-."},
            {'s', "..."},
            {'t', "-"},
            {'u', "..-"},
            {'v', "...-"},
            {'w', ".--"},
            {'x', "-..-"},
            {'y', "-.--"},
            {'z', "--.."},
            {'0', "-----"},
            {'1', ".----"},
            {'2', "..---"},
            {'3', "...--"},
            {'4', "....-"},
            {'5', "....."},
            {'6', "-...."},
            {'7', "--..."},
            {'8', "---.."},
            {'9', "----."},
            {' ', "/"}
        };


            static Dictionary<string, char> reverseMorseAlphabet = new Dictionary<string, char>();

            static Morse()
            {

                foreach (var entry in morseAlphabet)
                {
                    reverseMorseAlphabet.Add(entry.Value, entry.Key);
                }
            }


            public static string ToMorse(string text)
            {
                string morseText = "";


                foreach (char c in text)
                {

                    if (morseAlphabet.ContainsKey(c))
                    {

                        morseText += morseAlphabet[c] + " ";
                    }
                }

                return morseText.TrimEnd();
            }


            public static string FromMorse(string morseText)
            {
                string text = "";


                string[] codes = morseText.Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);


                foreach (string code in codes)
                {

                    if (reverseMorseAlphabet.ContainsKey(code))
                    {

                        text += reverseMorseAlphabet[code];
                    }
                }

                return text;
            }
        }


    }

    public class Test3_4
    {
        public static void num3_4()
        {
            Console.WriteLine("Введіть текст для перетворення в азбуку Морзе:");
            string text = Console.ReadLine().ToLower();


            string morseText = Morse.ToMorse(text);

            Console.WriteLine("Азбука Морзе: " + morseText);


            string newText = Morse.FromMorse(morseText);

            Console.WriteLine("Звичайний текст: " + newText);

            Console.ReadKey();
        }
    }
}