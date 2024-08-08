using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UkrainianTransliterator
{
    internal static class TransliterationMap
    {
        public static readonly Dictionary<string, string> Map = new Dictionary<string, string>
        {
            {"А", "A"}, {"а", "a"},
            {"Б", "B"}, {"б", "b"},
            {"В", "V"}, {"в", "v"},
            {"Г", "H"}, {"г", "h"},
            {"Ґ", "G"}, {"ґ", "g"},
            {"Д", "D"}, {"д", "d"},
            {"Е", "E"}, {"е", "e"},
            {"Є", "Ye"}, {"є", "ie"}, 
            {"Ж", "Zh"}, {"ж", "zh"},
            {"З", "Z"}, {"з", "z"},
            {"И", "Y"}, {"и", "y"},
            {"І", "I"}, {"і", "i"},
            {"Ї", "Yi"}, {"ї", "i"}, 
            {"Й", "Y"}, {"й", "i"}, 
            {"К", "K"}, {"к", "k"},
            {"Л", "L"}, {"л", "l"},
            {"М", "M"}, {"м", "m"},
            {"Н", "N"}, {"н", "n"},
            {"О", "O"}, {"о", "o"},
            {"П", "P"}, {"п", "p"},
            {"Р", "R"}, {"р", "r"},
            {"С", "S"}, {"с", "s"},
            {"Т", "T"}, {"т", "t"},
            {"У", "U"}, {"у", "u"},
            {"Ф", "F"}, {"ф", "f"},
            {"Х", "Kh"}, {"х", "kh"},
            {"Ц", "Ts"}, {"ц", "ts"},
            {"Ч", "Ch"}, {"ч", "ch"},
            {"Ш", "Sh"}, {"ш", "sh"},
            {"Щ", "Shch"}, {"щ", "shch"},
            {"Ю", "Yu"}, {"ю", "iu"}, 
            {"Я", "Ya"}, {"я", "ia"}, 

            {"Зг", "Zgh"}, {"зг", "zgh"}, 
            
            {"ь", ""}, {"'", ""}
        };

    }
}
