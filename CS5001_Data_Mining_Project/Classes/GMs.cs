using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CS5001_Data_Mining_Project.Classes
{
    public static class GMs
    {
        /// <summary>
        /// parse the first matching element between headerKeyword keyword and enderKeyword keyword in source
        /// </summary>
        public static string ParseElement(string source, string headerKeyword, string enderKeyword, bool withHeader, bool withEnder)
        {
            string str = "";
            int startIndex;
            int endIndex;
            int length;
            startIndex = source.IndexOf(headerKeyword);

            if (startIndex == -1) { throw new Exception("Error: Cannot find headerKeyword to parse the element"); }

            startIndex += headerKeyword.Length;
            endIndex = source.Substring(startIndex).IndexOf(enderKeyword);

            if (endIndex == -1) { throw new Exception("Error: Cannot find enderKeyword to parse the element"); }

            length = endIndex;
            endIndex += startIndex;
            str = source.Substring(startIndex, length);
            if (withHeader) { str = headerKeyword + str; }
            if (withEnder) { str = str + enderKeyword; }
            return str;
        }

        /// <summary>
        /// parse all the matching elements between headerKeyword keyword and enderKeyword keyword in source
        /// </summary>
        public static List<string> ParseElements(string source, string headerKeyword, string enderKeyword, bool withHeader, bool withEnder)
        {
            List<string> list = new List<string>();
            int startIndex = 0;
            int endIndex = 0;
            int length;
            while (startIndex != -1 && endIndex != -1)
            {
                startIndex = source.IndexOf(headerKeyword);

                if (startIndex == -1) { break; }

                startIndex += headerKeyword.Length;
                endIndex = source.Substring(startIndex).IndexOf(enderKeyword);

                if (endIndex == -1) { break; }

                length = endIndex;
                endIndex += startIndex + enderKeyword.Length;

                string str = source.Substring(startIndex, length);
                if (withHeader) { str = headerKeyword + str; }
                if (withEnder) { str = str + enderKeyword; }
                list.Add(str);

                source = source.Substring(endIndex);
            }
            return list;
        }
    }
}
