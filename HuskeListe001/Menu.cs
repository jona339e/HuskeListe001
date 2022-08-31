using System.Diagnostics;
using System.IO;
using System.Xml.Linq;

namespace HuskeListe001
{
    internal class Menu
    {
        Data data = new Data();
        SaveLoad sl = new(@"C:\MyDir\HuskeListeData.json");
        public Menu()
        {

            if (sl.PathExists())
            {
                data = sl.LoadData(data);
            }
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
                    // TODO ShowNames, select name, modify list on selected name
                    ShowLists();
                    Console.ReadKey();
                    break;
                case ConsoleKey.NumPad2:
                case ConsoleKey.D2:
                    ListMenu();
                    break;

                default:
                    break;
            }
        }

        private void ShowNames()
        {
            foreach (Appointment titleAppointment in data.AppointmentList)
            {
                Console.WriteLine(titleAppointment.ListName);
            }
            foreach (Meeting titleMeeting in data.MeetingList)
            {
                Console.WriteLine(titleMeeting.ListName);
            }
            foreach (GroceryList titleGrocery in data.GroceryList)
            {
                Console.WriteLine(titleGrocery.ListName);
            }
        }
        private void ShowLists()
        {
            foreach (Appointment a in data.AppointmentList)
            {
                ShowAppointment(a);
            }
            foreach (GroceryList b in data.GroceryList)
            {
                ShowGroceryList(b);
            }
            foreach (Meeting c in data.MeetingList)
            {
                ShowMeeting(c);
            }
        }

        private void ShowAppointment(Appointment a)
        {
            Console.WriteLine($"Listname: {a.ListName} Location: {a.Where} Start Time: {a.Start} End Time: {a.End} Appointment Type{a.TypeOfAppointment} Cost of Appointment: {a.Cost}\nParticipants:");
            foreach (string? s in a.WithWho)
            {
                Console.WriteLine(s);
            }
        }
        private void ShowGroceryList(GroceryList b)
        {
            // TODO: Make properties into a list. Display list here. add a loop so you can add more elements to the list.
            Console.WriteLine($"Listname: {b.ListName} Location: {b.Where} Start Time: {b.Start} End Time: {b.End} Grocery name: {b.Name}\nWho I'm going shopping with:");
            foreach (string? s in b.WithWho)
            {
                Console.WriteLine(s);
            }
        }
        private void ShowMeeting(Meeting c)
        {
            Console.WriteLine($"Listname: {c.ListName} Location: {c.Where} Start Time: {c.Start} End Time: {c.End}" +
                $"\nSubject:\n{c.Subject}\nI need to bring: {c.ToBring}\nMy role in the meeting: {c.Role}\nMeeting Participants:");
            foreach (string? s in c.WithWho)
            {
                Console.WriteLine(s);
            }
        }

        private void ListMenu()
        {
            Console.Clear();
            Console.WriteLine("Choose Type of List to Create:\n1. Appointment\n2. Meeting\n3. GroceryList");

            switch (Console.ReadKey(true).Key)
            {
                case ConsoleKey.NumPad1:
                case ConsoleKey.D1:
                    AddAppointment();
                    break;
                case ConsoleKey.NumPad2:
                case ConsoleKey.D2:
                    AddMeeting();
                    break;
                case ConsoleKey.NumPad3:
                case ConsoleKey.D3:
                    AddGroceryList();
                    break;
                case ConsoleKey.NumPad4:
                case ConsoleKey.D4:
                    
                    break;
                default:
                    break;
            }
        }
        private void AddAppointment()
        {
            Appointment appoint = new();

            //appoint.ListName = "a";
            //appoint.Where = "b";
            //appoint.Start = DateTime.Now;
            //appoint.End = DateTime.Now;
            AddGeneric<Appointment>(appoint);
            appoint.TypeOfAppointment = "c";
            appoint.Cost = 1;
            AddMoreWithWho<Appointment>(appoint, "Who is your appointment with?", "Do you want to add more participants? (y/n)");

            data.AppointmentList.Add(appoint);
            sl.SaveData(data);
            Console.WriteLine("Data Succesfully added!\nPress any key to continue");
            Console.ReadKey();
        }
        private void AddMeeting()
        {
            Meeting meet = new();

            //meet.ListName = "a";
            //meet.Where = "b";
            //meet.Start = DateTime.Now;
            //meet.End = DateTime.Now;
            AddGeneric<Meeting>(meet);
            meet.Subject = "";
            meet.ToBring = ""; // TODO: list of elements to bring, iterate through them in ShowMeeting()
            meet.Role = "";

            AddMoreWithWho<Meeting>(meet, "Who is your meeting with?", "Do you want to add more participants? (y/n)");

            data.MeetingList.Add(meet);
            Console.WriteLine("Data Succesfully added!\nPress any key to continue");
            sl.SaveData(data);
            Console.ReadKey();
        }
        private void AddGroceryList()
        {
            GroceryList grocery = new();

            //grocery.ListName = "a";
            //grocery.Where = "b";
            //grocery.Start = DateTime.Now;
            //grocery.End = DateTime.Now;
            AddGeneric<GroceryList>(grocery);
            grocery.Name = "";
            grocery.Category = "";
            grocery.Price = 1;
            grocery.Amount = 2;
            AddMoreWithWho<GroceryList>(grocery, "Who is your shopping trip with?", "Do you want to add more participants? (y/n)");

            data.GroceryList.Add(grocery);
            sl.SaveData(data);
            Console.WriteLine("Data Succesfully added!\nPress any key to continue");
            Console.ReadKey();
        }
        private void AddGeneric<T>(T toDoList) where T : TodoList
        {
            toDoList.ListName = "a";
            toDoList.Where = "b";
            toDoList.Start = DateTime.Now;
            toDoList.End = DateTime.Now;

        }
        private void AddMoreWithWho<T>(T toDoList, string s1, string s2) where T : TodoList
        {
            string? input;
            do
            {
                Console.WriteLine(s1);
                input = Console.ReadLine();
                if (!string.IsNullOrEmpty(input))
                {
                    toDoList.WithWho.Add(input);
                    Console.WriteLine(s2);
                }
                else Console.WriteLine("Input not valid try again!") ;

            } while (Console.ReadKey(true).Key == ConsoleKey.Y || string.IsNullOrEmpty(input));
        }
    }
}
