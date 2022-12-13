using System;

namespace ConsoleApp1
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Are you going to encrypt or decrypt using Vigenere Cipher?\nPlease, reply with 'E' or 'D'.");

            string userChoice = Console.ReadLine();
            while (!userChoice.Equals("E") && !userChoice.Equals("D"))
            {
                Console.WriteLine("You have not inputted a correct letter.\nPlease, try again!");

                userChoice = Console.ReadLine();
            }

            if (userChoice.Equals("E"))
            {
                EncryptFunction();
            }
            else if (userChoice.Equals("D"))
            {
                DecryptFunction();
            }
        }

        public static void EncryptFunction()
        {
            Console.WriteLine("What sentence would you want to be encrypted?");
            string toEncrypt = Console.ReadLine();

            string[,] vigenereMatrix = GenerateMatrix();

            string encryptedMessage = "";

            for (int i = 0; i < toEncrypt.Length; i++)
            {
                int copyIndexer = i % 26;
                char letter = toEncrypt[i];
                int getLetterLocation = GetLetterLocation(letter);

                if (getLetterLocation >= 0)
                {
                    encryptedMessage = encryptedMessage + vigenereMatrix[getLetterLocation, copyIndexer];
                } else
                {
                    encryptedMessage = encryptedMessage + " ";
                }
            }

            Console.WriteLine(encryptedMessage);
        }

        public static void DecryptFunction()
        {
            Console.WriteLine("What sentence would you want to be encrypted?");
            string toDecrypt = Console.ReadLine();

            string decryptedMessage = "";

            for (int i = 0; i < toDecrypt.Length; i++)
            {
                int copyIndexer = i % 26;
                char letter = toDecrypt[i];
                int getLetterLocation = GetLetterLocation(letter);

                if (getLetterLocation >= 0)
                {
                    int index = getLetterLocation - copyIndexer;
                    if (index < 0)
                    {
                        index = index + 26;
                    }

                    decryptedMessage = decryptedMessage + GetLetterAtIndex(index);
                }
                else
                {
                    decryptedMessage = decryptedMessage + " ";
                }
            }

            Console.WriteLine(decryptedMessage);
        }

        public static string[,] GenerateMatrix()
        {
            string[,] matrix = new string[26, 26];
            string[] lines = System.IO.File.ReadAllLines(@"D:\Zadacha\matrix.txt");

            for (int i = 0; i < lines.Length - 1; i++)
            {
                string[] lineAsArray = lines[i].Split(", ");
                for (int j = 0; j < lineAsArray.Length; j++)
                {
                    matrix[i, j] = lineAsArray[j];
                }
            }

            return matrix;
        }

        public static void PrintMatrix(string[,] vigenereMatrix)
        {
            for (int i = 0; i < vigenereMatrix.GetLength(0); i++)
            {
                for (int j = 0; j < vigenereMatrix.GetLength(1); j++)
                {
                    Console.Write(vigenereMatrix[i, j] + " ");
                }
                Console.WriteLine();
            }
        }

        public static int GetLetterLocation(char letter)
        {
            string[] lines = System.IO.File.ReadAllLines(@"D:\Zadacha\alphabet.txt");

            string[] lineAsArray = null;
            for (int i = 0; i < lines.Length; i++)
            {
                lineAsArray = lines[i].Split(", ");
            }
            

            for (int i = 0; i < lineAsArray.Length; i++)
            {
                if (lineAsArray[i].Equals(letter.ToString()))
                {
                    return i;
                }
            }

            return -1;
        }

        public static string GetLetterAtIndex(int index)
        {
            string[] lines = System.IO.File.ReadAllLines(@"D:\Zadacha\alphabet.txt");

            string[] lineAsArray = null;
            for (int i = 0; i < lines.Length; i++)
            {
                lineAsArray = lines[i].Split(", ");
            }

            return lineAsArray[index];
        }
    }
}
