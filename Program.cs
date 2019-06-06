using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;

namespace CodeNames
{
    class Program
    {
        const string NOUNS = "CodeNames.nouns.txt";
        const string ADJECTIVES = "CodeNames.adjectives.txt";

        static void Main(string[] args)
        {
            var nouns = ReadResourceFile(NOUNS).ToArray();
            var adjs = ReadResourceFile(ADJECTIVES).ToArray();
            var rand = new Random();

            var noun = nouns[rand.Next(0, nouns.Length)];
            var adj = adjs[rand.Next(0, adjs.Length)];

            Console.WriteLine($"{adj.ToFirstUpper()} {noun.ToFirstUpper()}");
        }

        static IEnumerable<string> ReadResourceFile(string resource)
        {
            var asm = Assembly.GetExecutingAssembly();
            using (Stream stream = asm.GetManifestResourceStream(resource))
            using (StreamReader reader = new StreamReader(stream))
            {
                string line = reader.ReadLine();
                while (!string.IsNullOrWhiteSpace(line))
                {
                    yield return line;
                    line = reader.ReadLine();
                }
            }
        }
    }
}
