using System.Security.Cryptography;

namespace SymmetricCryptoConsoleApp
{
    public class MySymmetricAlgorithms
    {
        public DES MyDES { get { return DES.Create(); } }
        public Aes MyAes { get { return Aes.Create(); } }
        public RC2 MyRC2 { get { return RC2.Create(); } }
        public Rijndael MyRijndael { get { return Rijndael.Create(); } }
        public TripleDES MyTripleDES { get { return TripleDES.Create(); } }
    }
}