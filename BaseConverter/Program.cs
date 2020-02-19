using System;
using static System.Console;
using static System.Math;

namespace BaseConverter
{
    class Program
    {
        static void Main(string[] args)
        {
            Menu();
        }

        static void DecToBin()
        {
            uint value;

            Write("Insira um número decimal (somente valores inteiros positivos até 4294967296): ");
            value = uint.Parse(ReadLine());

            uint[] binArray = new uint[GetBitLength(value)];
            binArray = ConvertToBinary(binArray, value);

            Write("{0} em binário: ", value);
            foreach (var b in binArray)
            {
                Write(b);
            }
            WriteLine();
        }

        static uint GetBitLength(uint number)
        {
            uint binDigitsNeeded = (uint)Floor(Log(number, 2)) + 1;
            return binDigitsNeeded;
        }

        static uint[] ConvertToBinary(uint[] binaryArray, uint decimalValue)
        {
            for (int i = binaryArray.Length - 1; decimalValue > 0; i--)
            {
                binaryArray[i] = decimalValue % 2;
                decimalValue /= 2;
            }
            return binaryArray;
        }

        static void BinToDec()
        {
            uint dec;
            string input;
            char[] binary = new char[10];

            Write("Insira um número binário (somente valores positivos até 1111111111): ");
            input = ReadLine();
            binary = input.ToCharArray();
            if (CheckDigits(binary))
            {
                WriteLine("Valor ({0}) inválido.", input);
                return;
            }

            dec = ConvertToDecimal(binary);
            WriteLine("{0} em decimal: {1}", input, dec);
        }

        static bool CheckDigits(char[] binaryArray)
        {
            for (int i = 0; i < binaryArray.Length; i++)
            {
                if (binaryArray[i] > 49 || binaryArray[i] < 48)
                {
                    return true;
                }
            }

            return false;
        }

        static uint ConvertToDecimal(char[] binaryChrArray)
        {
            uint decimalValue = 0;
            uint[] binaryIntArray = new uint[binaryChrArray.Length];

            for (int i = 0; i < binaryIntArray.Length; i++)
            {
                binaryIntArray[i] = (uint)char.GetNumericValue(binaryChrArray[i]);
                binaryIntArray[i] *= (uint)Pow(2, ((binaryIntArray.Length - 1) - i));
                decimalValue += binaryIntArray[i];
            }

            return decimalValue;
        }

        static void Menu()
        {
            int choice;

            while (true)
            {
                Write("1- Bin2Dec   2- Dec2Bin\nEscolha uma conversão (0 para sair): ");
                choice = int.Parse(ReadLine());
                if (choice == 1)
                {
                    BinToDec();
                }
                else if (choice == 2)
                {
                    DecToBin();
                }
                else if (choice == 0)
                {
                    Write("Programa encerrado.");
                    break;
                }
                else
                {
                    WriteLine("Escolha inválida.");
                }
            }

            ReadKey();
        }
    }
}
