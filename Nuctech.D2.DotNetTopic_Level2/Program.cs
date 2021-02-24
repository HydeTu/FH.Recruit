using System;
using System.Linq;

namespace Nuctech.D2.DotNetTopic
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            Console.Title = "Shopping List";

            Console.WriteLine("".PadRight(60, '*'));
            Console.WriteLine("Shopping List Program Start.");

            Console.WriteLine("Create shooping manager.");
            IShoppingManager shoppingManager = new ShoppingManager();

            while (true)
            {
                Console.WriteLine("Create shooping list.");
                IShoppingList newShowList = shoppingManager.CreateRandomShoppingList();
                IShoppingList checkList = new DotNetTopic.Level2.Tudh.ShoppingList(DateTime.Now);
                Console.WriteLine("".PadRight(60, '-'));

                Console.WriteLine("Shopping List Detail");
                Console.WriteLine("Date:\t{0}", newShowList.Time);
                Console.WriteLine("{0,-20}{1,12}{2,12}{3,12}", "Name", "Count", "Price(￥)", "Rate(%)");
                foreach (var each in newShowList)
                {
                    checkList.Add(each, newShowList.GetItemCount(each));
                    Console.WriteLine("{0,-20}{1,12}{2,12:f2}{3,12:f1}", each.Name, newShowList.GetItemCount(each), each.Price, shoppingManager.CurrentTaxRateTable.GetTaxRate(each.Type) * 100);
                }

                Console.WriteLine("                    \t{0,-10}{1,10}", "计算值", "参考值");

                var oldColor = Console.ForegroundColor;
                if (!Equals(newShowList, checkList, shoppingManager.CurrentTaxRateTable))
                    Console.ForegroundColor = ConsoleColor.Red;

                Console.WriteLine("Total Count:        \t{0,-10}{1,16}", newShowList.GetAllItemCount(), checkList.GetAllItemCount());
                Console.WriteLine("Total Price(Origin):\t{0,-10:f1}{1,16:f1}", newShowList.Sum(e => e.Price * newShowList.GetItemCount(e)), checkList.Sum(e => e.Price * newShowList.GetItemCount(e)));
                Console.WriteLine("Total Price(No Tax):\t{0,-10:f1}{1,16:f1}", newShowList.Sum(null), checkList.Sum(null));
                Console.WriteLine("Total Price:        \t{0,-10:f1}{1,16:f1}", newShowList.Sum(shoppingManager.CurrentTaxRateTable), checkList.Sum(shoppingManager.CurrentTaxRateTable));

                Console.ForegroundColor = oldColor;

                Console.WriteLine("".PadRight(60, '-'));
                Console.WriteLine();

                Console.WriteLine("Press any key to continue, press q to quit.");
                if (Console.ReadLine() == "q")
                    break;
            }

            Console.WriteLine("Shopping List Program End.");
            Console.WriteLine("".PadRight(60, '*'));

            Console.ReadLine();
        }

        private static bool Equals(IShoppingList srcList, IShoppingList dstList, ITaxRateTable taxTable)
        {
            return srcList != null && dstList != null
                && srcList.IsEmpty() == dstList.IsEmpty()
                && srcList.GetAllItemCount() == dstList.GetAllItemCount()
                && srcList.Sum(null) == dstList.Sum(null)
                && srcList.Sum(taxTable) == dstList.Sum(taxTable);
        }
    }
}