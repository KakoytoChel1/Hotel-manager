using System.Windows;
using System.Windows.Controls;

namespace Hotels_Manager.Views.Controls
{
    public class RatingStarCounter : Control
    {
        static RatingStarCounter()
        {
            DefaultStyleKeyProperty.OverrideMetadata(typeof(RatingStarCounter), new FrameworkPropertyMetadata(typeof(RatingStarCounter)));
        }

        public static readonly DependencyProperty StarsCountProperty =
            DependencyProperty.Register("StarsCount", typeof(int), typeof(RatingStarCounter), new PropertyMetadata(0, StarsCountPropertyChanged));

        public int StarsCount
        {
            get { return (int)GetValue(StarsCountProperty); }
            set { SetValue(StarsCountProperty, value); }
        }

        private static void StarsCountPropertyChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            // Ensure StarsCount stays within the range of 1 to 5
            var ratingControl = (RatingStarCounter)d;
            ratingControl.StarsCount = (int)e.NewValue < 1 ? 1 : ((int)e.NewValue > 5 ? 5 : (int)e.NewValue);
        }

        public override void OnApplyTemplate()
        {
            base.OnApplyTemplate();

            var decreaseButton = GetTemplateChild("PART_decreaseBtn") as Button;
            if (decreaseButton != null)
                decreaseButton.Click += DecreaseButton_Click;

            var increaseButton = GetTemplateChild("PART_increaseBtn") as Button;
            if (increaseButton != null)
                increaseButton.Click += IncreaseButton_Click;
        }

        private void DecreaseButton_Click(object sender, RoutedEventArgs e)
        {
            StarsCount--;
        }

        private void IncreaseButton_Click(object sender, RoutedEventArgs e)
        {
            StarsCount++;
        }
    }
}
