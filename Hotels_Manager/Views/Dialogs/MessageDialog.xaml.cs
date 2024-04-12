using System.Windows;

namespace Hotels_Manager.Views.Dialogs
{
    public partial class MessageDialog : Window
    {
        public MessageDialog(string description, Window windowOwner)
        {
            InitializeComponent();
            this.Description = description;
            this.Owner = windowOwner;
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
            DependencyProperty.Register("Description", typeof(string), typeof(MessageDialog), new PropertyMetadata(string.Empty));
    }
}
