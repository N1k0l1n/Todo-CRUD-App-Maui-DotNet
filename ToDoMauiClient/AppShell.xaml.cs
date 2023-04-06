using ToDoMauiClient.Pages;

namespace ToDoMauiClient
{
    public partial class AppShell : Shell
    {
        public AppShell()
        {
            InitializeComponent();

            //Create Route For Manage Todos
            Routing.RegisterRoute(nameof(ManageToDoPage), typeof(ManageToDoPage));
        }
    }
}