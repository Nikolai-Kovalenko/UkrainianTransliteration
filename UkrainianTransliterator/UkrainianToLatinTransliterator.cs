using System.Text;

namespace UkrainianTransliterator;

public class UkrainianToLatinTransliterator
{
    public string GetTransliteration(string input)
    {
        if (string.IsNullOrEmpty(input))
        {
            throw new ArgumentException("Input cannot be null or empty", nameof(input));
        }

        var output = new StringBuilder();
        int i = 0;

        while (i < input.Length)
        {
            var currentChar = input[i].ToString();

            // Обработка специальных букв
            if ("ЯяЄєЮюЇїЙй".Contains(currentChar))
            {
                var isStartOfWord = i == 0 || !char.IsLetter(input[i - 1]);
                var transliteration = ProcessSpecialChar(currentChar, isStartOfWord);
                output.Append(transliteration);
                i += currentChar.Length;
            }
            else
            {
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
        }

        return output.ToString();

    }

    private string ProcessSpecialChar(string currentChar, bool isStartOfWord)
    {
        switch (currentChar)
        {
            case "Я":
                return isStartOfWord ? "Ya" : "Ia";
            case "я":
                return isStartOfWord ? "ya" : "ia";
            case "Є":
                return isStartOfWord ? "Ye" : "ie";
            case "є":
                return isStartOfWord ? "ye" : "ie";
            case "Ю":
                return isStartOfWord ? "Yu" : "iu";
            case "ю":
                return isStartOfWord ? "yu" : "iu";
            case "Ї":
                return isStartOfWord ? "Yi" : "I";
            case "ї":
                return isStartOfWord ? "yi" : "i";
            case "Й":
                return isStartOfWord ? "Y" : "I";
            case "й":
                return isStartOfWord ? "y" : "i";
            default:
                return currentChar; // Не должны сюда попась
        }
    }
}
