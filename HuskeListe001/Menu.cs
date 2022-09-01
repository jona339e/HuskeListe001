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
                case ConsoleKey.NumPad3:
                case ConsoleKey.D3:
                    ShowNames();
                    Console.ReadKey();
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
                ShowData(a);
            }
            foreach (GroceryList b in data.GroceryList)
            {
                ShowData(b);
            }
            foreach (Meeting c in data.MeetingList)
            {
                ShowData(c);
            }
        }


        private void ShowData(Appointment a)
        {
            Console.WriteLine($"Listname: {a.ListName} Location: {a.Where} Start Time: {a.Start} End Time: {a.End} Appointment Type{a.TypeOfAppointment} Cost of Appointment: {a.Cost}\nParticipants:");
            foreach (string? s in a.WithWho)
            {
                Console.WriteLine(s);
            }
        }        
        private void ShowData(GroceryList b)
        {
            // TODO: Make properties into a list. Display list here. add a loop so you can add more elements to the list.
            Console.WriteLine($"Listname: {b.ListName} Location: {b.Where} Start Time: {b.Start} End Time: {b.End} \nWho I'm going shopping with:");
            foreach (string? s in b.WithWho)
            {
                Console.WriteLine(s);
            }
            Console.WriteLine("\nGroceries:");
            foreach (Groceries item in b.groceries)
            {
                Console.WriteLine($"{item.Name} Price: {item.Price} Amount: {item.Amount} Category: {item.Category} ");
            }
        }        
        private void ShowData(Meeting c)
        {
            Console.WriteLine($"Listname: {c.ListName} Location: {c.Where} Start Time: {c.Start} End Time: {c.End}" +
                            $"\nSubject:\n{c.Subject}\nI need to bring: {c.ToBring}\nMy role in the meeting: {c.Role}\nMeeting Participants:");
            foreach (string? s in c.WithWho)
            {
                Console.WriteLine(s);
            }
        }
        
        //private void ShowAppointment(Appointment a)
        //{
        //    Console.WriteLine($"Listname: {a.ListName} Location: {a.Where} Start Time: {a.Start} End Time: {a.End} Appointment Type{a.TypeOfAppointment} Cost of Appointment: {a.Cost}\nParticipants:");
        //    foreach (string? s in a.WithWho)
        //    {
        //        Console.WriteLine(s);
        //    }
        //}

        //private void ShowGroceryList(GroceryList b)
        //{
        //    // TODO: Make properties into a list. Display list here. add a loop so you can add more elements to the list.
        //    Console.WriteLine($"Listname: {b.ListName} Location: {b.Where} Start Time: {b.Start} End Time: {b.End} \nWho I'm going shopping with:");
        //    foreach (string? s in b.WithWho)
        //    {
        //        Console.WriteLine(s);
        //    }
        //    Console.WriteLine("\nGroceries:");
        //    foreach (Groceries item in b.groceries)
        //    {
        //        Console.WriteLine($"{item.Name} Price: {item.Price} Amount: {item.Amount} Category: {item.Category} ");
        //    }
        //}

        //private void ShowMeeting(Meeting c)
        //{
        //    Console.WriteLine($"Listname: {c.ListName} Location: {c.Where} Start Time: {c.Start} End Time: {c.End}" +
        //        $"\nSubject:\n{c.Subject}\nI need to bring: {c.ToBring}\nMy role in the meeting: {c.Role}\nMeeting Participants:");
        //    foreach (string? s in c.WithWho)
        //    {
        //        Console.WriteLine(s);
        //    }
        //}

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

                default:
                    break;
            }
        }
        private void AddAppointment()
        {
            Appointment appoint = new();

            AddGeneric<Appointment>(appoint);

            Console.Write("Type of appointment: ");
            appoint.TypeOfAppointment = Console.ReadLine();

            Console.WriteLine("Cost of appointment: ");
            if (int.TryParse(Console.ReadLine(), out int cost))
            {
                appoint.Cost = cost;
            }
            else
            {
                Console.WriteLine("Invalid input, defaulted to 0");
            }
            
            AddMoreWithWho<Appointment>(appoint, "Who is your appointment with?", "Do you want to add more participants? (y/n)");

            data.AppointmentList.Add(appoint);
            sl.SaveData(data);

            Console.WriteLine("Data Succesfully added!\nPress any key to continue");
            Console.ReadKey();
        }
        private void AddMeeting()
        {
            Meeting meet = new();

            AddGeneric<Meeting>(meet);

            Console.Write("Meeting subject/description: ");
            meet.Subject = Console.ReadLine();

            Console.WriteLine("What to bring to the meeting: ");
            meet.ToBring = ""; // TODO: list of elements to bring, iterate through them in ShowMeeting()

            Console.WriteLine("Your role in the meeting: ");
            meet.Role = Console.ReadLine();

            AddMoreWithWho<Meeting>(meet, "Who is your meeting with?", "Do you want to add more participants? (y/n)");

            data.MeetingList.Add(meet);
            Console.WriteLine("Data Succesfully added!\nPress any key to continue");

            sl.SaveData(data);
            Console.ReadKey();
        }
        private void AddGroceryList()
        {
            GroceryList grocery = new();

            AddGeneric<GroceryList>(grocery);

            do
            {
                Console.Clear();

                grocery.groceries.Add(AddGroceries());
                Console.WriteLine("Do you want to add more groceries? (y/n)");

            } while (Console.ReadKey().Key == ConsoleKey.Y);

            AddMoreWithWho<GroceryList>(grocery, "Who is your shopping trip with?", "Do you want to add more participants? (y/n)");

            data.GroceryList.Add(grocery);
            sl.SaveData(data);

            Console.WriteLine("Data Succesfully added!\nPress any key to continue");
            Console.ReadKey();
        }

        private Groceries AddGroceries()
        {
            Groceries gr = new();

            Console.Write("Grocery Name: ");
            gr.Name = Console.ReadLine();

            Console.WriteLine("Grocery Category: ");
            gr.Category = Console.ReadLine();

            Console.WriteLine("Grocery Price: ");
            if (int.TryParse(Console.ReadLine(), out int price))
            {
                gr.Price = price;
            }
            else
            {
                Console.WriteLine("Invalid input, Defaulted to 0");
            }

            Console.WriteLine("Amount of groceries: ");
            if (int.TryParse(Console.ReadLine(), out int amount))
            {
                gr.Amount = amount;
            }
            else
            {
                Console.WriteLine("Invalid input, Defaulted to 0");
            }
            
            return gr;
        }
        private void AddGeneric<T>(T toDoList) where T : TodoList
        {
            Console.Write("Enter the name of the list: ");
            toDoList.ListName = Console.ReadLine();

            Console.Write("Enter the name of the Location: ");
            toDoList.Where = Console.ReadLine();

            Console.WriteLine("Enter the name of the startdate (dd:mm:yyyy): ");
            if (DateTime.TryParse(Console.ReadLine(), out DateTime dateStart))
            {
                toDoList.Start = dateStart;
            }
            else
            {
                Console.WriteLine("Invalid input, defaulting to 00:00:00");
            }

            Console.WriteLine("Enter the name of the enddate (dd:mm:yyyy): ");
            if (DateTime.TryParse(Console.ReadLine(), out DateTime dateEnd))
            {
                toDoList.End = dateEnd;
            }
            else
            {
                Console.WriteLine("Invalid input, defaulting to 00:00:00");
            }
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

        private void ShowListFromName<T>(T myList, string name) where T : TodoList
        {
            if (myList.ListName == name)
            {
                //ShowData(myList.GetType());
            }
        }
    }
}
