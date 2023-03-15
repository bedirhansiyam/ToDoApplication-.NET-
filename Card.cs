namespace ToDoApplication;

public class Card
{
    private string title;
    private string content;
    private Placeman placeman;
    private Size size;
    private Line line;
    

    public string Title { get => title; set => title = value; }
    public string Content { get => content; set => content = value; }
    internal Size Size { get => size; set => size = value; }
    public Placeman Placeman { get => placeman; set => placeman = value; }
    internal Line Line { get => line; set => line = value; }

    public Card()
    {
        Size = Size.XS;
        Placeman = new Placeman(){Id = 1, FullName = "Altay Bayindir"};
        Line = Line.TODO;
    }

    public static List<Card> Get3Cards()
    {
        List<Card> cards = new List<Card>()
        {
            new Card(){Title ="Create an order", Content = "New shirts must be ordered.", Size = Size.M}, 
            new Card(){Title ="Shipping products", Content = "150 pieces of trousers must be shipped.", Size = Size.XL},
            new Card(){Title ="Purchasing", Content = "Fabric must be purchased", Size = Size.S,}

        };
        return cards;
    }

}
