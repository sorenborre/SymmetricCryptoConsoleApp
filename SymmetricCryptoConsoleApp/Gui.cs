using System;
using System.Diagnostics;
using System;
using System.Collections.Generic;
using System.Text;
using System.Security.Cryptography;
using System.IO;


namespace SymmetricCryptoConsoleApp
{
    partial class Program
    {
        public class Gui
        {
            readonly MySymmetricAlgorithms msa;
            readonly EncryptDecrypt encryptDecrypt;
            Stopwatch stopwatch = new Stopwatch();
            public Gui(MySymmetricAlgorithms m, EncryptDecrypt e)
            {
                msa = m;
                encryptDecrypt = e;
            }

            public void run()
            {
                string text;
                bool isRunning = true;


                while (isRunning)
                {
                    Console.WriteLine("Write a text you want to encrypt");
                    text = Console.ReadLine();

                    Console.WriteLine("Choose encrypter:\n1: AES\n2: DES\n3: RC2\n4: Rijndael\n5: TripleDES\n\n6: Exit\n--------------------------------------------\n\n\n");
                    switch (Console.ReadLine())
                    {
                        case "1":
                            SymmetricAlgorithmWithTimer(text, msa.MyAes);

                            break;
                        case "2":
                            SymmetricAlgorithmWithTimer(text, msa.MyDES);
                           
                            break;
                        case "3":
                            SymmetricAlgorithmWithTimer(text, msa.MyRC2);

                            break;
                        case "4":
                            SymmetricAlgorithmWithTimer(text, msa.MyRijndael);

                            break;
                        case "5":
                            SymmetricAlgorithmWithTimer(text, msa.MyTripleDES);

                            break;
                        case "6":
                            isRunning = false;

                            break;
                        case "7":
                            break;
                        default:
                            Console.WriteLine("Invalid number, try again");
                            Console.Clear();
                            break;
                    }
                    Console.WriteLine("push any key to try again!");
                    Console.ReadKey();
                    Console.Clear();
                }
            }
            private void printToConsole(string encrypted, string decrypted, string text, long time)
            {
                Console.WriteLine("Original text:" + text + "\n");

                Console.WriteLine("Encrypted text: " + encrypted + "\n");
                Console.WriteLine("Time it took to encrypt, ms:" + time + "\n");

                Console.WriteLine("Push any key to decrypt it" + "\n");
                Console.ReadKey();

                Console.WriteLine("Decrypted text:" + decrypted);
            }


            public void SymmetricAlgorithmWithTimer(string text, SymmetricAlgorithm symmetricAlgorithm)
            {

                byte[] key = symmetricAlgorithm.Key;
                byte[] iV = symmetricAlgorithm.IV;

                stopwatch.Start();
                byte[] encrypted = encryptDecrypt.EncryptStringToBytes(text, key, iV, symmetricAlgorithm);
                stopwatch.Stop();

                string decrypted = encryptDecrypt.DecryptStringFromBytes(encrypted, key, iV, symmetricAlgorithm);


                printToConsole(Convert.ToBase64String(encrypted), decrypted, text, stopwatch.ElapsedMilliseconds);

            }
        }
    }
}
