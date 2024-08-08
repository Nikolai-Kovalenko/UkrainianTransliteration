using System.Text;

namespace UkrainianTransliterator;

public class UkrainianToLatinTransliterator
{
    public string GetTransliteration(string input)
    {
        if (string.IsNullOrEmpty(input))
        {
            throw new ArgumentException("Input cannot be null or empty", nameof(input));
            //return string.Empty;
        }

        var output = new StringBuilder();

        int i = 0;
        while (i < input.Length)
        {
            var currentChar = input[i].ToString();
            if (char.IsLetter(currentChar[0]))
            {
                var nextChar = i < input.Length - 1 ? input.Substring(i, 2) : null;

                var match = TransliterationMap.Map
                    .Where(pair => pair.Key.Length > 1 && input.Substring(i).StartsWith(pair.Key))
                    .Select(pair => new { pair.Key, pair.Value })
                    .FirstOrDefault();

                if (match != null)
                {
                    output.Append(match.Value);
                    i += match.Key.Length; 
                }
                else
                {
                    if (TransliterationMap.Map.ContainsKey(currentChar))
                    {
                        output.Append(TransliterationMap.Map[currentChar]);
                    }
                    else
                    {
                        output.Append(currentChar);
                    }
                    i++;
                }
            }
            else
            {
                output.Append(currentChar);
                i++;
            }
        }

        return output.ToString();
    }
}
