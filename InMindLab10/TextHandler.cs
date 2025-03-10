using System;
using System.Collections.Generic;
using System.Linq;

namespace SmartTextLibrary
{
    public static class TextHandler
    {
        public static string ToSnakeCase(string input)
        {
            var result = new List<char>();
            foreach (var c in input)
            {
                if (char.IsUpper(c) && result.Count > 0)
                    result.Add('_');
                result.Add(char.ToLower(c));
            }
            return new string(result.ToArray());
        }

        public static string ToPascalCase(string input)
        {
            var words = input.Split(new[] { ' ', '_', '-' }, StringSplitOptions.RemoveEmptyEntries);
            for (int i = 0; i < words.Length; i++)
                words[i] = char.ToUpper(words[i][0]) + words[i].Substring(1).ToLower();
            return string.Join("", words);
        }

        public static string ToKebabCase(string input)
        {
            var result = new List<char>();
            foreach (var c in input)
            {
                if (char.IsUpper(c) && result.Count > 0)
                    result.Add('-');
                result.Add(char.ToLower(c));
            }
            return new string(result.ToArray());
        }

        public static string ToCamelCase(string input)
        {
            string pascal = ToPascalCase(input);
            return char.ToLower(pascal[0]) + pascal.Substring(1);
        }

        public static int WordCount(string input)
        {
            var words = input.Split(new[] { ' ', '\t', '\n' }, StringSplitOptions.RemoveEmptyEntries);
            return words.Length;
        }

        public static int CharacterCount(string input)
        {
            int count = 0;
            foreach (var c in input)
                if (char.IsLetterOrDigit(c))
                    count++;
            return count;
        }

        public static string MostCommonWord(string input)
        {
            var words = input.ToLower().Split(new[] { ' ', '\t', '\n' }, StringSplitOptions.RemoveEmptyEntries);
            var wordCounts = new Dictionary<string, int>();
            foreach (var word in words)
            {
                if (!wordCounts.ContainsKey(word))
                    wordCounts[word] = 0;
                wordCounts[word]++;
            }
            return wordCounts.OrderByDescending(w => w.Value).FirstOrDefault().Key ?? "";
        }

        public static string LeastCommonWord(string input)
        {
            var words = input.ToLower().Split(new[] { ' ', '\t', '\n' }, StringSplitOptions.RemoveEmptyEntries);
            var wordCounts = new Dictionary<string, int>();
            foreach (var word in words)
            {
                if (!wordCounts.ContainsKey(word))
                    wordCounts[word] = 0;
                wordCounts[word]++;
            }
            return wordCounts.OrderBy(w => w.Value).FirstOrDefault().Key ?? "";
        }
    }
}
