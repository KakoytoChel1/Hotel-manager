using System.Windows;

namespace Hotels_Manager.Views.Dialogs
{
    public partial class ConfirmDialog : Window
    {
        public ConfirmDialog(string description, Window windowOwner)
        {
            InitializeComponent();
            this.Description = description;
            this.Owner = windowOwner;
        }

        private void cancel_Click(object sender, RoutedEventArgs e)
        {
            DialogResult = false;
            Close();
        }

        private void Ok_Click(object sender, RoutedEventArgs e)
        {
            DialogResult = true;
            Close();
        }

        public string Description
        {
            get { return (string)GetValue(DescriptionProperty); }
            set { SetValue(DescriptionProperty, value); }
        }

        public static readonly DependencyProperty DescriptionProperty =
            DependencyProperty.Register("Description", typeof(string), typeof(ConfirmDialog), new PropertyMetadata(string.Empty));
    }
}
