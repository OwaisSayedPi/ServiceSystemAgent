namespace ConsoleApp2
{
    public class MainMenu : Page
    {
        public MainMenu()
        {
            pages.Add(new CustomerInfo());
            pages.Add(new ChangeStatus());
        }
    }
}