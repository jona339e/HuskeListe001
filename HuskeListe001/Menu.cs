using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HuskeListe001
{
    internal class Menu
    {
        public Menu()
        {
            while (true)
            {
                MainMenu();
            }
        }

        private void MainMenu()
        {
            Console.Clear();
            Console.WriteLine("Menu\n1. To Show ToDoLists\n2. For Create New ToDoList");
            switch (Console.ReadKey(true).Key)
            {
                case ConsoleKey.NumPad1:
                case ConsoleKey.D1:
                    ShowLists();
                    break;
                case ConsoleKey.NumPad2:
                case ConsoleKey.D2:
                    CreateList();
                    break;

                default:
                    break;
            }
        }

        private static void ShowLists()
        {

        }        
        private static void CreateList()
        {
            Console.Clear();
            Console.WriteLine("Choose type of list\n1. Appointment\n2. Meeting\n3. GroceryList");

            switch (Console.ReadKey(true).Key)
            {
                case ConsoleKey.NumPad1:
                case ConsoleKey.D1:
                    
                    break;
                case ConsoleKey.NumPad2:
                case ConsoleKey.D2:
                    
                    break;
                case ConsoleKey.NumPad3:
                case ConsoleKey.D3:
                    
                    break;
                case ConsoleKey.NumPad4:
                case ConsoleKey.D4:
                    
                    break;
                default:
                    break;
            }
        }
    }
    
}
