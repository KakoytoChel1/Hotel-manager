using Hotels_Manager.ViewModels;
using System.Windows;

namespace Hotels_Manager.Views.Dialogs
{
    public partial class CreateNewFloorDialog : Window
    {
        public CreateNewFloorDialog()
        {
            InitializeComponent();
        }

        public CreateNewFloorDialog(MainViewModel dataContext, Window owner)
        {
            InitializeComponent();
            Owner = owner;
            DataContext = dataContext;
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
