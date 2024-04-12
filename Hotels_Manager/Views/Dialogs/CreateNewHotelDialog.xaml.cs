using Hotels_Manager.ViewModels;
using System.Windows;

namespace Hotels_Manager.Views.Dialogs
{
    public partial class CreateNewHotelDialog : Window
    {
        public CreateNewHotelDialog()
        {
            InitializeComponent();
        }
        public CreateNewHotelDialog(MainViewModel dataContext, Window owner)
        {
            InitializeComponent();
            this.DataContext = dataContext;
            this.Owner = owner;
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
