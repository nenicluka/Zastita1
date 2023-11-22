using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FSW
{
    public class FoursquareCipher
    {
        private readonly char[,] upperLeftTable;
        private readonly char[,] upperRightTable;
        private readonly char[,] lowerLeftTable;
        private readonly char[,] lowerRightTable;

        public FoursquareCipher(string keyword1, string keyword2)
        {
            upperLeftTable = GenerateTable();
            upperRightTable = GenerateTableWithKeywords(keyword1, keyword2);
            lowerLeftTable = GenerateTableWithKeywords(keyword2, keyword1);
            lowerRightTable = GenerateTable();
        }

        public string Encrypt(string plaintext)
        {
            plaintext = PreparePlaintext(plaintext);

            StringBuilder ciphertext = new StringBuilder();

            for (int i = 0; i < plaintext.Length; i += 2)
            {
                char char1 = plaintext[i];
                char char2 = (i + 1 < plaintext.Length) ? plaintext[i + 1] : 'X';

                int[] position1 = FindPosition(char1, upperLeftTable);
                int[] position2 = FindPosition(char2, lowerRightTable);

                char encryptedChar1 = upperRightTable[position1[0], position2[1]];
                char encryptedChar2 = lowerLeftTable[position2[0], position1[1]];

                ciphertext.Append(encryptedChar1);
                ciphertext.Append(encryptedChar2);
            }

            return ciphertext.ToString();
        }

        public string Decrypt(string ciphertext)
        {
            StringBuilder plaintext = new StringBuilder();

            for (int i = 0; i < ciphertext.Length; i += 2)
            {
                char char1 = ciphertext[i];
                char char2 = (i + 1 < ciphertext.Length) ? ciphertext[i + 1] : 'X';

                int[] position1 = FindPosition(char1, upperRightTable);
                int[] position2 = FindPosition(char2, lowerLeftTable);


                char decryptedChar1 = upperLeftTable[position2[0], position1[1]];
                char decryptedChar2 = lowerRightTable[position1[0], position2[1]];

                plaintext.Append(decryptedChar2);
                plaintext.Append(decryptedChar1);
            }

            return plaintext.ToString();
        }


        private char[,] GenerateTable()
        {
            char[,] table = new char[5, 5];
            string alphabet = "ABCDEFGHIKLMNOPQRSTUVWXYZ"; // Preskoči 'J'

            int index = 0;
            for (int i = 0; i < 5; i++)
            {
                for (int j = 0; j < 5; j++)
                {
                    table[i, j] = alphabet[index];
                    index++;
                }
            }

            return table;
        }

        private char[,] GenerateTableWithKeywords(string keyword1, string keyword2)
        {
            char[,] table = new char[5, 5];
            HashSet<char> uniqueChars = new HashSet<char>();

            // Dodaj jedinstvene karaktere iz oba ključa
            foreach (char c in keyword1.ToUpper())
            {
                if (c != 'J' && !uniqueChars.Contains(c))
                {
                    uniqueChars.Add(c);
                }
            }

            foreach (char c in keyword2.ToUpper())
            {
                if (c != 'J' && !uniqueChars.Contains(c))
                {
                    uniqueChars.Add(c);
                }
            }

            // Dodaj preostale karaktere iz abecede
            foreach (char c in "ABCDEFGHIKLMNOPQRSTUVWXYZ")
            {
                if (c != 'J' && !uniqueChars.Contains(c))
                {
                    uniqueChars.Add(c);
                }
            }

            // Popuni tabelu
            int index = 0;
            for (int i = 0; i < 5; i++)
            {
                for (int j = 0; j < 5; j++)
                {
                    table[i, j] = uniqueChars.ElementAt(index);
                    index++;
                }
            }

            return table;
        }

        private string PreparePlaintext(string plaintext)
        {
            // Pretvori u velika slova i zameni 'J' sa 'I'
            return plaintext.ToUpper().Replace("J", "I");
        }

        private int[] FindPosition(char target, char[,] table)
        {
            int[] position = new int[2];

            for (int i = 0; i < 5; i++)
            {
                for (int j = 0; j < 5; j++)
                {
                    if (table[i, j] == target)
                    {
                        position[0] = i;
                        position[1] = j;
                        return position;
                    }
                }
            }

            throw new ArgumentException($"Karakter '{target}' nije pronađen u tabeli.");
        }
    }
}
