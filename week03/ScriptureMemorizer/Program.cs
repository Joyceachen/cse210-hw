using System;

namespace ScriptureMemorizer
{
    class Program
    {
        static void Main(string[] args)
        {
             Scripture[] scriptureLibrary = {
                new Scripture(new Reference("John", 3, 16), "For God so loved the world, that he gave his only begotten Son, that whosoever believeth in him should not perish, but have everlasting life."),
                new Scripture(new Reference("Proverbs", 3, 5, 6), "Trust in the Lord with all thine heart; and lean not unto thine own understanding. In all thy ways acknowledge him, and he shall direct thy paths."),
                new Scripture(new Reference("1 Nephi", 3, 7), "And it came to pass that I, Nephi, said unto my father: I will go and do the things which the Lord hath commanded, for I know that the Lord giveth no commandments unto the children of men, save he shall prepare a way for them that they may accomplish the thing which he commandeth them."),
                new Scripture(new Reference("Philippians", 4, 13), "I can do all things through Christ which strengtheneth me.")
            };

            Random random = new Random();
            Scripture currentScripture = scriptureLibrary[random.Next(scriptureLibrary.Length)];
            
            string userInput = "";
            
            while (userInput != "quit" && !currentScripture.IsCompletelyHidden())
            {
                Console.Clear();
                Console.WriteLine(currentScripture.GetDisplayText());
                Console.WriteLine();
                Console.Write("Press enter to continue or type 'quit' to finish: ");
                
                userInput = Console.ReadLine();
                
                if (userInput != "quit")
                {
                    currentScripture.HideRandomWords(3);
                }
            }
            
            if (currentScripture.IsCompletelyHidden())
            {
                Console.Clear();
                Console.WriteLine(currentScripture.GetDisplayText());
                Console.WriteLine();
                Console.WriteLine("Congratulations! You've completed the scripture.");
            }
        }
    }
}