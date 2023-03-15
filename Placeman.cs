namespace ToDoApplication;

public class Placeman
{
    private int id;
    private string? fullName;

    public int Id { get => id; set => id = value; }
    public string FullName { get => fullName; set => fullName = value; }

    public static List<Placeman> GetPlacemans()
    {
        List<Placeman> placemans = new List<Placeman>()
        {
            new Placeman(){Id = 1, FullName = "Altay Bayindir"}, 
            new Placeman(){Id = 2, FullName = "Gustavo Henrique"},
            new Placeman(){Id = 3, FullName = "Samet Akaydin"},
            new Placeman(){Id = 4, FullName = "Serdar Aziz"},
            new Placeman(){Id = 5, FullName = "Willian Arao"},
            new Placeman(){Id = 6, FullName = "Ezgjan Alioski"},
            new Placeman(){Id = 7, FullName = "Ferdi Kadioglu"},
            new Placeman(){Id = 8, FullName = "Mert Hakan Yandas"},
            new Placeman(){Id = 9, FullName = "Diego Rossi"},
            new Placeman(){Id = 10, FullName = "Arda Güler"}
        };
        return placemans;
    }

}