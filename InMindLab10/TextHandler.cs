using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace InMindLab10
{
    
    public static class TextFormatter
    {
       
        public static string ToSnakeCase(string input)
        {
            if (string.IsNullOrEmpty(input))
                return input;

            StringBuilder sb = new StringBuilder();
            for (int i = 0; i < input.Length; i++)
            {
                char c = input[i];

                if (char.IsWhiteSpace(c))
                {
                    // Only add underscore if the previous character is not already an underscore
                    if (sb.Length == 0 || sb[sb.Length - 1] != '_')
                        sb.Append('_');
                }
                else if (char.IsUpper(c))
                {
                    // If not the first character and the previous character is not an underscore, add an underscore
                    if (i > 0 && sb[sb.Length - 1] != '_' && !char.IsWhiteSpace(input[i - 1]))
                        sb.Append('_');
                    sb.Append(char.ToLower(c));
                }
                else
                {
                    sb.Append(c);
                }
            }
            return sb.ToString();
        }

        
        public static string ToPascalCase(string input)
        {
            if (string.IsNullOrEmpty(input))
                return input;

            // Split by common delimiters: whitespace, dash, underscore.
            string[] words = input.Split(new[] { ' ', '-', '_' }, StringSplitOptions.RemoveEmptyEntries);
            StringBuilder sb = new StringBuilder();
            foreach (string word in words)
            {
                if (word.Length > 0)
                {
                    sb.Append(char.ToUpper(word[0]));
                    if (word.Length > 1)
                        sb.Append(word.Substring(1).ToLower());
                }
            }
            return sb.ToString();
        }

        
        public static string ToKebabCase(string input)
        {
            if (string.IsNullOrEmpty(input))
                return input;

            StringBuilder sb = new StringBuilder();
            for (int i = 0; i < input.Length; i++)
            {
                char c = input[i];

                if (char.IsWhiteSpace(c))
                {
                    if (sb.Length == 0 || sb[sb.Length - 1] != '-')
                        sb.Append('-');
                }
                else if (char.IsUpper(c))
                {
                    if (i > 0 && sb[sb.Length - 1] != '-' && !char.IsWhiteSpace(input[i - 1]))
                        sb.Append('-');
                    sb.Append(char.ToLower(c));
                }
                else
                {
                    sb.Append(c);
                }
            }
            return sb.ToString();
        }

        
        public static string ToCamelCase(string input)
        {
            string pascal = ToPascalCase(input);
            if (string.IsNullOrEmpty(pascal))
                return pascal;
            return char.ToLower(pascal[0]) + pascal.Substring(1);
        }
    }

    
    public static class TextStatistics
    {
        
        public static int WordCount(string input)
        {
            if (string.IsNullOrWhiteSpace(input))
                return 0;

            // Splitting by whitespace characters.
            string[] words = input.Split(new[] { ' ', '\t', '\n' }, StringSplitOptions.RemoveEmptyEntries);
            return words.Length;
        }

        
        public static int CharacterCount(string input)
        {
            if (input == null)
                return 0;
            return input.Length;
        }

        
        public static string MostCommonWord(string input)
        {
            if (string.IsNullOrWhiteSpace(input))
                return string.Empty;

            string[] words = input.Split(new[] { ' ', '\t', '\n' }, StringSplitOptions.RemoveEmptyEntries);
            Dictionary<string, int> frequency = new Dictionary<string, int>(StringComparer.OrdinalIgnoreCase);

            foreach (string word in words)
            {
                string trimmed = word.Trim();
                if (trimmed == string.Empty)
                    continue;

                if (frequency.ContainsKey(trimmed))
                    frequency[trimmed]++;
                else
                    frequency[trimmed] = 1;
            }

           
            return frequency.OrderByDescending(kv => kv.Value).First().Key;
        }

        
        public static string LeastCommonWord(string input)
        {
            if (string.IsNullOrWhiteSpace(input))
                return string.Empty;

            string[] words = input.Split(new[] { ' ', '\t', '\n' }, StringSplitOptions.RemoveEmptyEntries);
            Dictionary<string, int> frequency = new Dictionary<string, int>(StringComparer.OrdinalIgnoreCase);

            foreach (string word in words)
            {
                string trimmed = word.Trim();
                if (trimmed == string.Empty)
                    continue;

                if (frequency.ContainsKey(trimmed))
                    frequency[trimmed]++;
                else
                    frequency[trimmed] = 1;
            }

           
            return frequency.OrderBy(kv => kv.Value).First().Key;
        }
    }
}
