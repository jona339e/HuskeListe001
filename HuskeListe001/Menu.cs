namespace HuskeListe001
{
    internal class Menu
    {
        Data data = new Data();
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
            foreach (object title in data.MyData)
            {

            }
        }
        private void ShowLists()
        {
            foreach (Appointment a in data.MyData)
            {
                ShowAppointment(a);
            }
            foreach (GroceryList b in data.MyData)
            {
                ShowGroceryList(b);
            }
            foreach (Meeting c in data.MyData)
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
            Console.WriteLine($"Listname: {b.ListName} Location: {b.Where} Start Time: {b.Start} End Time: {b.End} Appointment Type{b.Name} \nParticipants:");

        }
        private void ShowMeeting(Meeting c)
        {
            Console.WriteLine($"Listname: {c.ListName} Location: {c.Where} Start Time: {c.Start} End Time: {c.End} \nParticipants:");

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
        private void AddAppointment()
        {
            Appointment appoint = new();

            appoint.ListName = "a";
            appoint.Where = "b";
            appoint.Start = DateTime.Now;
            appoint.End = DateTime.Now;
            appoint.TypeOfAppointment = "c";
            appoint.Cost = 1;
            AddMoreWithWho<Appointment>(appoint, "Who is your appointment with?", "Do you want to add more participants? (y/n)");

            data.MyData.Add(appoint);
            Console.WriteLine("Data Succesfully added!\nPress any key to continue");
            Console.ReadKey();
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
