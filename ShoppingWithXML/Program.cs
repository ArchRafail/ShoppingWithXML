using System;
using System.Globalization;

namespace ShoppingWithXML
{
    class Program
    {
        static CultureInfo provider = CultureInfo.InvariantCulture;

        static Receipt AddReceipt()
        {
            int number;
            DateTime dateTime;
            Console.Write("Input number of the receipt here -> ");
            number = Convert.ToInt32(Console.ReadLine());
            Console.Write("Input the date of receipt in format dd.mm.yyyy. -> ");
            dateTime = DateTime.ParseExact(Console.ReadLine(), "dd.MM.yyyy", provider);
            return new Receipt(number, dateTime);
        }

        static int MainInfo()
        {
            Console.WriteLine("Program will allow you send receipts from shops into XML file.");
            Console.WriteLine("And than you will be able read an info about receipts from XML file.");
            Console.WriteLine("So, let's start. You should collect info about goods into receipts.\n");
            Console.WriteLine("How many receipt would you like to fill?");
            int quantity = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine();
            return quantity > 0 ? quantity : 1;
        }

        static void showReceipts(Receipt[] receipts)
        {
            Console.WriteLine("\n--------------------------------------------------");
            for (int i = 0; i < receipts.Length; i++)
            {
                receipts[i].show();
                Console.WriteLine("--------------------------------------------------\n");
            }
        }

        static void Main(string[] args)
        {
            Receipt[] receipts = new Receipt[MainInfo()];
            for (int i = 0; i < receipts.Length; i++)
            {
                receipts[i] = AddReceipt();
                Console.WriteLine();
            }
            Console.WriteLine();
            Console.Clear();
            showReceipts(receipts);
            XMLWork.WriterXML(receipts);
            XMLWork.ReaderXMLDoc();
            Console.WriteLine();
            XMLWork.ReaderXMLTxt();
            Console.WriteLine();
        }
    }
}
