using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BT_de1
{
    internal class Program
    {

        private int n;
        private int[] storeItems = new int[5];
        public static List<Option> options;
        static void Main(string[] args)
        {
            int n;
            int[] a = new int[5];
            Console.Write("Moi nhap vao tong so phan tu: ");
            n = Convert.ToInt32(Console.ReadLine());
            Console.Clear();

            array_input(n, a);
           

        }
        static void array_input(int n, int[] a )
        {

            int i;
           
            // array
            for (i = 0; i < n; i++)
            {

                var result = Console.ReadLine();
                int ketquatemp;
                if (!int.TryParse(result, out ketquatemp))

                {
                    Console.Write("please input array: ");
                    Console.WriteLine("element {0}: {1} ", i, a[i]);
                    a[i] = Convert.ToInt32(Console.ReadLine());
                    continue;
                }
                if (ketquatemp < 5 || ketquatemp > 10)
                {
                    Console.Write("the element in array does not meet required condition");
                    i--;
                    continue;
                }
                a[i] = ketquatemp;

            }
            Console.Write("\nthe current array atm is : \n");
            for (i = 0; i < n; i++)
            {
                Console.Write("{0} | ", a[i]);
            }

            Console.WriteLine("please wait for two 2s: ");
            Thread.Sleep(2000);
            menu(n, a);

        }

        static void ouput(int []a , int n)
        {
            int i;
            Console.Write("\nthe current array atm is : \n");
            for (i = 0; i < n; i++)
            {
                Console.Write("{0} | ", a[i]);
            }

            Console.WriteLine("the current array atm is : ");
            Thread.Sleep(2000);
        }
        /*static void menu()
        {
            Console.WriteLine("Menu");
            int optionsCount = 5;


            int selected = 0;

            bool chon = false;

            while (chon)
            {
                for (int i = 0; i < optionsCount; i++)
                {

                    if (selected == i)
                    {
                        Console.ForegroundColor = ConsoleColor.Cyan;
                        Console.Write("> ");
                    }
                    else
                    {
                        Console.Write("  ");
                    }


                    Console.WriteLine(i);


                    Console.ResetColor();
                }

                switch (Console.ReadKey(true).Key)
                {
                    case ConsoleKey.UpArrow:
                        selected = Math.Max(0, selected - 1);
                        break;
                    case ConsoleKey.DownArrow:
                        selected = Math.Min(optionsCount - 1, selected + 1);
                        break;
                    case ConsoleKey.Enter:
                        chon = true;
                        break;
                }

                if (!chon)
                    Console.CursorTop = Console.CursorTop - optionsCount;
            }

            Console.WriteLine($"Selected {selected}.");
        }*/
        
        static void sorting()
        {
            /*Console.Write("array sau khi sap xep la :\n");
            for (i = n - 1; i >= 0; i--)
            {
                Console.Write("{0} ", a[i]);
            }*/
        }
        static void menu(int n, int []a)
        {
            // Create options that you want your menu to have
            options = new List<Option>
            {
                new Option("Re-input the array", () => array_input(n,a)),
                new Option("Sorting array asc order", () =>  sorting_asc(a,n)),
                new Option("Sorting array desc order", () => sorting_desc(a,n)),
                new Option("Print previous array", () =>  ouput(a,n)),
                new Option("Demo sorting asc", () => Demo_sorting(a,n)),
                new Option("Exit", () => Environment.Exit(0)),
            };

            // Set the default index of the selected item to be the first
            int index = 0;

            // Write the menu out
            WriteMenu(options, options[index]);

            // Store key info in here
            ConsoleKeyInfo keyinfo;
            do
            {
                keyinfo = Console.ReadKey();

                // Handle each key input (down arrow will write the menu again with a different selected item)
                if (keyinfo.Key == ConsoleKey.DownArrow)
                {
                    if (index + 1 < options.Count)
                    {
                        index++;
                        WriteMenu(options, options[index]);
                    }
                }
                if (keyinfo.Key == ConsoleKey.UpArrow)
                {
                    if (index - 1 >= 0)
                    {
                        index--;
                        WriteMenu(options, options[index]);
                    }
                }
                // Handle different action for the option
                if (keyinfo.Key == ConsoleKey.Enter)
                {
                    options[index].Selected.Invoke();
                    index = 0;
                }
            }
            while (keyinfo.Key != ConsoleKey.X);

            Console.ReadKey();

        }
        // Default action of all the options
        static void WriteTemporaryMessage(string message)
        {
            Console.Clear();
            Console.WriteLine(message);
            Thread.Sleep(3000);
            WriteMenu(options, options.First());
        }

       

        static void WriteMenu(List<Option> options, Option selectedOption)
        {
            Console.Clear();

            foreach (Option option in options)
            {
                if (option == selectedOption)
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.Write("> ");
                }
                else
                {
                    Console.Write(" ");
                }

                Console.WriteLine(option.Name);
                Console.ResetColor();
            }
        }
        static void Demo_sorting(int[] a, int n)
        {
            int min = a[0];
            for(int i = 1; i < n; i++)
            {
                if(a[i] < min)
                {
                    a[i] = min; 
                }
                Console.Write("{0}", a[i]);
                Thread.Sleep(1000);
            }


            
           
        }
        static void sorting_asc(int []a, int n)
        {
            Array.Sort(a);
            Console.WriteLine("\n array sau khi sap xep la");
            Console.WriteLine("- - - - - - - - -");
            foreach (int x in a)
            {

                Console.Write(x + "| ");
            }
            Console.WriteLine("\n- - - - - - - - -");
        }
        static void sorting_desc(int[] a, int n)
        {

     
          
            Array.Reverse(a);
            Console.WriteLine("\n array sau khi sap xep la");
            Console.WriteLine("- - - - - - - - -");
            foreach (int x in a)
            {

                Console.Write(x + "| ");
            }
            Console.WriteLine("\n- - - - - - - - -");

        }
    }
    public class Option
    {
        public string Name { get; }
        public Action Selected { get; }

        public Option(string name, Action selected)
        {
            Name = name;
            Selected = selected;
        }
    }
}
