using System;
using System.Collections.Generic;
using System.Text;
using System.Security.Cryptography;
using System.IO;

namespace SymmetricCryptoConsoleApp
{
    class EncryptDecrypt
    {
        public string DecryptStringFromBytes(byte[] cipherText, byte[] key, byte[] iV, SymmetricAlgorithm symmetricAlgorithm)
        {
            if (cipherText == null || cipherText.Length <= 0)
                throw new ArgumentNullException("cipherText");
            if (key == null || key.Length <= 0)
                throw new ArgumentNullException("Key");
            if (iV == null || iV.Length <= 0)
                throw new ArgumentNullException("IV");

            string plaintext = null;

            using (symmetricAlgorithm)
            {
                symmetricAlgorithm.Key = key;
                symmetricAlgorithm.IV = iV;

                ICryptoTransform decryptor = symmetricAlgorithm.CreateDecryptor(symmetricAlgorithm.Key, symmetricAlgorithm.IV);

                using (MemoryStream msDecrypt = new MemoryStream(cipherText))
                {
                    using (CryptoStream csDecrypt = new CryptoStream(msDecrypt, decryptor, CryptoStreamMode.Read))
                    {
                        using (StreamReader srDecrypt = new StreamReader(csDecrypt))
                        {
                            plaintext = srDecrypt.ReadToEnd();
                        }
                    }
                }
            }
            return plaintext;
        }

        public byte[] EncryptStringToBytes(string originalText, byte[] key, byte[] iV, SymmetricAlgorithm symmetricAlgorithm)
        {
            if (originalText == null || originalText.Length <= 0)
                throw new ArgumentNullException("cipherText");
            if (key == null || key.Length <= 0)
                throw new ArgumentNullException("Key");
            if (iV == null || iV.Length <= 0)
                throw new ArgumentNullException("IV");

            byte[] encrypted;

            using (symmetricAlgorithm)
            {
                symmetricAlgorithm.Key = key;
                symmetricAlgorithm.IV = iV;

                ICryptoTransform encryptor = symmetricAlgorithm.CreateEncryptor(symmetricAlgorithm.Key, symmetricAlgorithm.IV);

                using (MemoryStream msEncrypt = new MemoryStream())
                {
                    using (CryptoStream csEncrypt = new CryptoStream(msEncrypt, encryptor, CryptoStreamMode.Write))
                    {
                        using (StreamWriter swEncrypt = new StreamWriter(csEncrypt))
                        {
                            swEncrypt.Write(originalText);
                        }
                        encrypted = msEncrypt.ToArray();
                    }
                }
            }
            return encrypted;
        }
    }
}
