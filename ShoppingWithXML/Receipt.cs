using System;
using System.Collections.Generic;

namespace ShoppingWithXML
{
    class Receipt
    {
        public int ReceiptNumber { get; private set; }
        DateTime dateTime;
        List<Good> goods;
        double total_cost;

        public Receipt(int receipt, DateTime dateTime)
        {
            ReceiptNumber = receipt;
            this.dateTime = dateTime;
            goods = null;
            total_cost = 0;
            bool check = true;
            do
            {
                if (AddItem())
                    if (goods == null)
                        goods = new List<Good>() { AddGood() };
                    else
                        goods.Add(AddGood());
                else
                    check = false;
            } while (check);
            foreach (Good good in goods)
                total_cost += good.Cost;
        }

        bool AddItem()
        {
            int answer;
            Console.WriteLine($"\nDear user, do you want to add an item to the receipt N{ReceiptNumber}?");
            Console.WriteLine("1 - Yes, 2 or any other input - No.");
            answer = Menu(2);
            return answer == 1;
        }

        static bool CheckLength(char[] answer) => answer.Length == 1;

        static bool CheckChar(char[] answer, int qty_props) => (answer[0] > 48 && answer[0] < (48 + qty_props + 1));

        public static int Menu(int qty_props)
        {
            Console.Write("Input the answer here -> ");
            char[] answer_char = Console.ReadLine().ToCharArray();
            int answer = 0;
            if (CheckLength(answer_char) && CheckChar(answer_char, qty_props))
            {
                answer = Convert.ToInt32(answer_char[0] - 48);
            }
            else
                Console.WriteLine("Incorrect input. Will be considered default value \"No\"");
            return answer;
        }

        Good AddGood()
        {
            int article;
            Console.WriteLine("\nDear user, you have to input the requested below information.\n");
            Console.Write("Input article of the good here -> ");
            article = Convert.ToInt32(Console.ReadLine());
            string name;
            Console.Write("Input name of the good here -> ");
            name = Console.ReadLine();
            int units;
            Console.WriteLine("Pick the unit of measurements: 1 - pcs., 2 - kg., 3 - pck.");
            units = Menu(3);
            double price;
            Console.Write("Input price of the good here -> ");
            price = Convert.ToDouble(Console.ReadLine());
            double qty;
            Console.Write("Input quantity of the good that you want to buy here -> ");
            qty = Convert.ToDouble(Console.ReadLine());
            return new Good(article, name, units, price, qty);
        }

        public void show()
        {
            Console.WriteLine($"Receipt number: {ReceiptNumber}\tDate: {dateTime.ToShortDateString()}\n");
            foreach (Good good in goods)
                Console.WriteLine(good);
            Console.WriteLine($"Total cost by receipt: {total_cost}\n");
        }

        public DateTime GetTime() => dateTime;
        public List<Good> GetGoods() => goods;
        public double GetCost() => total_cost;
    }
}
