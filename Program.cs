namespace ToDoApplication;
class Program
{
    static void Main(string[] args)
    {
        List<Placeman> placemans = Placeman.GetPlacemans();
        List<Card> _cards = Card.Get3Cards();

        int chosen;
        bool result;
        do
        {
            MenuOperations.GetMenu();            
            MenuOperations.ControlChosen(out chosen, out result,6);            

            switch (chosen)
            {
                case 1:
                    MenuOperations.AddNewCard(placemans, _cards, out chosen, out result);
                    break;
                case 2:
                    MenuOperations.UpdateCard(placemans, _cards, out chosen, out result);
                    break;
                case 3:
                    MenuOperations.DeleteCard(placemans, _cards, out chosen, out result);
                    break;
                case 4:
                    MenuOperations.MoveCardLine(placemans, _cards, out chosen, out result);
                    break;
                case 5:
                    MenuOperations.GetAllLine(_cards);
                    break;
                default:
                    break;
            
            }
        } while (chosen != 6);       
        
    }
}


                