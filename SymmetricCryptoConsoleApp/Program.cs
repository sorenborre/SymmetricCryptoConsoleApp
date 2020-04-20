namespace SymmetricCryptoConsoleApp
{
    partial class Program
    {
        static void Main(string[] args)
        {
            Gui gui = new Gui(new MySymmetricAlgorithms(), new EncryptDecrypt());
            gui.run();
        }
    }
}
