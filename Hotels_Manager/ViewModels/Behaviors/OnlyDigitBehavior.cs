using Microsoft.Xaml.Behaviors;
using System.Windows.Controls;
using System.Windows.Input;

namespace Hotels_Manager.ViewModels.Behaviors
{
    class OnlyDigitBehavior : Behavior<TextBox>
    {
        protected override void OnAttached()
        {
            base.OnAttached();

            AssociatedObject.PreviewTextInput += AssociatedObject_PreviewTextInput;
            AssociatedObject.PreviewKeyDown += AssociatedObject_PreviewKeyDown;
        }

        private void AssociatedObject_PreviewKeyDown(object sender, KeyEventArgs e)
        {
            TextBox? textBox = sender as TextBox;

            if (textBox != null)
            {
                if (e.Key == Key.Space)
                {
                    e.Handled = true;
                }
            }
        }

        private void AssociatedObject_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            bool isNumber = int.TryParse(e.Text, out int result);

            if (!isNumber)
            {
                e.Handled = true;
                return;
            }

        }

        protected override void OnDetaching()
        {
            base.OnDetaching();
            AssociatedObject.PreviewTextInput -= AssociatedObject_PreviewTextInput;
            AssociatedObject.PreviewKeyDown -= AssociatedObject_PreviewKeyDown;
        }
    }
}
