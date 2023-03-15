namespace ToDoApplication;

public class MenuOperations
{
    public static void ReturnMenu()
    {
        Console.WriteLine();
        Console.WriteLine("Please press any key to return to the main menu!");
        Console.ReadKey();
    }
    public static void GetMenu()
    {
        Console.Clear();
        Console.WriteLine("Please make a selection");
        Console.WriteLine("***********************");
        Console.WriteLine("(1) Add new card");
        Console.WriteLine("(2) Update a card");
        Console.WriteLine("(3) Delete a card");
        Console.WriteLine("(4) Move the line of a card");
        Console.WriteLine("(5) List all cards");
        Console.WriteLine("(6) Exit");
    }
    public static void ControlChosen(out int chosen, out bool result, int limit)
    {
        do
        {
            result = int.TryParse(Console.ReadLine(), out chosen);
            if (chosen >= 1 && chosen <= limit && result == true)
                result = true;
            else
                result = false;
            if (result == false)
                Console.Write("Please make a valid selection : ");  
        } while (result == false);      
    }
    public static void UpdateCard(List<Placeman> placemans, List<Card> _cards, out int chosen, out bool result)
    {
        bool check = false;
        bool control = false;
        chosen = 1;
        result = true;
        do
        {
            Console.Clear();
            Console.WriteLine("Please select a card to update.");
            Console.Write("Enter the card title : ");
            string title = Console.ReadLine();
            foreach (var card in _cards)
            {
                if (title == card.Title)
                {
                    check = true;
                    Console.WriteLine("");
                    Console.WriteLine("Old card title : " + card.Title);
                    Console.Write("Please enter the new title : ");
                    string newTitle = Console.ReadLine();

                    Console.WriteLine("");
                    Console.WriteLine("Old card content : " + card.Content);
                    Console.Write("Please enter the new content : ");
                    string newContent = Console.ReadLine();

                    Console.WriteLine("");
                    Console.WriteLine("Old card size : " + card.Size);
                    Console.Write("Please enter the new size -> XS(1),S(2),M(3),L(4),XL(5) : ");
                    ControlChosen(out chosen, out result, 5);
                    int newSize = chosen;

                    Console.WriteLine("");
                    Console.WriteLine("Old placeman : " + card.Placeman.FullName);
                    Console.Write("Please enter the new placeman (ID) : ");
                    ControlChosen(out chosen, out result, 10);
                    int NewId = chosen;

                    card.Title = newTitle;
                    card.Content = newContent;
                    card.Size = (Size)newSize;
                    card.Placeman = placemans[NewId-1];

                    Console.WriteLine("");
                    Console.WriteLine("Card updated.");
                    control = false;
                    ReturnMenu();
                    break;
                }
            }
            if (check == false)
            {
                Console.WriteLine("");
                Console.WriteLine($"Card title '{title}' was not found in the board. Please make a selection.");
                Console.WriteLine("*To end the update   : (1)");
                Console.WriteLine("*To search again     : (2)");
                ControlChosen(out chosen, out result, 2);

                if (chosen == 2)
                {
                    control = true;
                }
                else
                {
                    GetMenu();
                    break;
                }
            }
        } while (control == true);
    }

    public static void AddNewCard(List<Placeman> placemans, List<Card> _cards, out int chosen, out bool result)
    {
        Console.Clear();
        Console.WriteLine("Add new card");
        Console.WriteLine("------------");
        Console.Write("Please enter the title : ");
        string title = Console.ReadLine();
        Console.Write("Please enter the content : ");
        string content = Console.ReadLine();
        Console.Write("Please choose size -> XS(1),S(2),M(3),L(4),XL(5) : ");
        ControlChosen(out chosen, out result, 5);
        int size = chosen;
        Console.Write("Please choose a placeman [ID (1-10)]) : ");
        ControlChosen(out chosen, out result, 10);
        int id = chosen;

        Card card = new Card();
        card.Title = title;
        card.Content = content;
        card.Size = (Size)size;
        card.Placeman = placemans[id-1];

        _cards.Add(card);
        Console.WriteLine("");
        Console.WriteLine("New card added.");
        ReturnMenu();
    }

    public static void DeleteCard(List<Placeman> placemans, List<Card> _cards, out int chosen, out bool result)
    {
        bool check = false;
        bool control = false;
        chosen = 1;
        result = true;
        do
        {
            Console.Clear();
            Console.WriteLine("Please select a card to delete.");
            Console.Write("Enter the card title : ");
            string title = Console.ReadLine();
            foreach (var card in _cards)
            {
                if (title == card.Title)
                {
                    check = true;
                    _cards.Remove(card);

                    Console.WriteLine("");
                    Console.WriteLine("Card deleted.");

                    control = false;
                    ReturnMenu();
                    break;
                }
            }
            if (check == false)
            {
                Console.WriteLine("");
                Console.WriteLine($"Card title '{title}' was not found in the board. Please make a selection.");
                Console.WriteLine("*To end the delete   : (1)");
                Console.WriteLine("*To search again     : (2)");
                ControlChosen(out chosen, out result, 2);

                if (chosen == 2)
                {
                    control = true;
                }
                else
                {
                    GetMenu();
                    break;
                }
            }
        } while (control == true);
    }

public static void MoveCardLine(List<Placeman> placemans, List<Card> _cards, out int chosen, out bool result)
    {
        bool check = false;
        bool control = false;
        chosen = 1;
        result = true;
        do
        {
            Console.Clear();
            Console.WriteLine("Please select a card to move line.");
            Console.Write("Enter the card title : ");
            string title = Console.ReadLine();
            foreach (var card in _cards)
            {
                if (title == card.Title)
                {
                    check = true;
                    
                    Console.WriteLine("");
                    Console.WriteLine("Card Informations");
                    Console.WriteLine("-----------------");
                    Console.WriteLine("Title : " + card.Title);
                    Console.WriteLine("Content : " + card.Content);
                    Console.WriteLine("Placeman : " + card.Placeman.FullName);
                    Console.WriteLine("Size : " + card.Size);
                    Console.WriteLine("Line : " + card.Line);

                    Console.WriteLine("");
                    Console.WriteLine("Please select the line you want to move:");
                    Console.WriteLine("(1) TODO");
                    Console.WriteLine("(2) IN PROGRESS");
                    Console.WriteLine("(3) DONE");
                    ControlChosen(out chosen, out result, 3);
                    int newLine = chosen;

                    card.Line = (Line)newLine;

                    Console.WriteLine("");
                    Console.WriteLine("Card line changed.");

                    control = false;
                    ReturnMenu();
                    break;
                }
            }
            if (check == false)
            {
                Console.WriteLine("");
                Console.WriteLine($"Card title '{title}' was not found in the board. Please make a selection.");
                Console.WriteLine("*To end the moving line   : (1)");
                Console.WriteLine("*To search again     : (2)");
                ControlChosen(out chosen, out result, 2);

                if (chosen == 2)
                {
                    control = true;
                }
                else
                {
                    GetMenu();
                    break;
                }
            }
        } while (control == true);
    }

    public static void GetAllLine(List<Card> _cards)
    {
        List<Card> toDo = new List<Card>();
        List<Card> inProgress = new List<Card>();
        List<Card> done = new List<Card>();

        foreach (var card in _cards)
        {
            if (card.Line == Line.TODO)
                toDo.Add(card);
            else if (card.Line == Line.INPROGRESS)
                inProgress.Add(card);
            else
                done.Add(card);
        }
        Console.Clear();
        GetLines(toDo, "TODO Line");

        Console.WriteLine("");
        Console.WriteLine("");
        GetLines(inProgress, "IN PROGRESS Line");

        Console.WriteLine("");
        Console.WriteLine("");
        GetLines(done, "DONE Line");

        ReturnMenu();
    }

    private static void GetLines(List<Card> cards, string head)
    {
        Console.WriteLine(head);
        Console.WriteLine("************************");
        foreach (var card in cards)
        {
            Console.WriteLine("Title    : " + card.Title);
            Console.WriteLine("Content  : " + card.Content);
            Console.WriteLine("Placeman : " + card.Placeman.FullName);
            Console.WriteLine("Size     : " + card.Size);
            Console.WriteLine("-");
        }
    }
}
