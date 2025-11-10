namespace ProjectBrightBuy
{
    public partial class App : Application
    {
        public App(string dbPath)
        {
            InitializeComponent();

            Database = new Database(dbPath);

            MainPage = new NavigationPage(new SignInPage());
        }
    }
}
