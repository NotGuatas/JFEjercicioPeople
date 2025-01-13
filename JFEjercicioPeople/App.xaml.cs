namespace JFEjercicioPeople
{
    public partial class App : Application
    {
        public static JFPersonRepository PersonRepo { get; private set; }

        public App(JFPersonRepository repo)
        {
            InitializeComponent();
            PersonRepo = repo;
            // MainPage = new AppShell();
        }
        protected override Window CreateWindow(IActivationState activationState)
        {
            return new Window(new AppShell());
        }
    }
}
