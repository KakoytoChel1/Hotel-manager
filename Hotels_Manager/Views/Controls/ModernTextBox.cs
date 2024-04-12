using System.Windows;
using System.Windows.Controls;

namespace Hotels_Manager.Views.Controls
{
    public class ModernTextBox : TextBox
    {
        static ModernTextBox()
        {
            DefaultStyleKeyProperty.OverrideMetadata(typeof(ModernTextBox), new FrameworkPropertyMetadata(typeof(ModernTextBox)));
        }

        public string PlaceHolder
        {
            get { return (string)GetValue(PlaceHolderProperty); }
            set { SetValue(PlaceHolderProperty, value); }
        }

        public static readonly DependencyProperty PlaceHolderProperty =
            DependencyProperty.Register("PlaceHolder", typeof(string), typeof(ModernTextBox), new PropertyMetadata(string.Empty));

        public CornerRadius CornerRadius
        {
            get { return (CornerRadius)GetValue(CornerRadiusProperty); }
            set { SetValue(CornerRadiusProperty, value); }
        }

        public static readonly DependencyProperty CornerRadiusProperty =
            DependencyProperty.Register("CornerRadius", typeof(CornerRadius), typeof(ModernTextBox));
    }
}
