using Hotels_Manager.ViewModels;
using System.Windows;

namespace Hotels_Manager.Views.Dialogs
{
    public partial class CreateNewRoomDialog : Window
    {
        public CreateNewRoomDialog()
        {
            InitializeComponent();
        }

        public CreateNewRoomDialog(MainViewModel dataContext, Window owner)
        {
            InitializeComponent();
            DataContext = dataContext;
            Owner = owner;
        }

        private void ConfirmBtn_Click(object sender, RoutedEventArgs e)
        {
            DialogResult = true;
            Close();
        }

        private void CancelBtn_Click(object sender, RoutedEventArgs e)
        {
            DialogResult = false;
            Close();
        }
    }
}
