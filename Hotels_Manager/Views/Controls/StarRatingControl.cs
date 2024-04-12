using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using System.Windows.Shapes;

namespace Hotels_Manager.Views.Controls
{
    public class StarRatingControl : Control
    {
        private int _starWidth = 13;
        private int _starHeight = 13;
        private string _starPath = "m 97.876782,159.28151\r\nc -0.06986,-0.18204 0.228726,-1.93821 0.663515,-3.9026\r\nl 0.790525,-3.57162 -1.250524,-1.19068\r\nc -0.687788,-0.65487 -1.935133,-1.80696 -2.771878,-2.5602 -0.894386,-0.80513 -1.521354,-1.58895 -1.521354,-1.90197 0,-0.58902 0.0421,-0.5982 5.009151,-1.09228 1.518103,-0.15101 2.776883,-0.30248 2.797283,-0.33659 0.0204,-0.0341 0.73223,-1.63961 1.58184,-3.56776 1.09797,-2.4918 1.67318,-3.50573 1.98881,-3.50573 0.31563,0 0.89084,1.01393 1.98881,3.50573 0.84961,1.92815 1.56143,3.53364 1.58183,3.56776 0.0204,0.0341 1.27919,0.18558 2.79729,0.33659 5.11516,0.50881 5.05058,0.49381 4.95879,1.15232 -0.0486,0.3487 -1.18806,1.5918 -2.80151,3.05634 -1.84945,1.67877 -2.67922,2.60644 -2.59342,2.89941 0.44043,1.50388 1.45672,6.99571 1.33195,7.19759 -0.2928,0.47376 -0.9242,0.22747 -4.07904,-1.59112\r\nl -3.1847,-1.8358 -3.1847,1.8358\r\nc -3.230874,1.86242 -3.874809,2.09861 -4.102668,1.50481\r\nz";

        static StarRatingControl()
        {
            DefaultStyleKeyProperty.OverrideMetadata(typeof(StarRatingControl), new FrameworkPropertyMetadata(typeof(StarRatingControl)));
        }

        public static readonly DependencyProperty StarsCountProperty = DependencyProperty.Register(
            "StarsCount", typeof(int), typeof(StarRatingControl), new FrameworkPropertyMetadata(0, FrameworkPropertyMetadataOptions.AffectsRender));

        public int StarsCount
        {
            get { return (int)GetValue(StarsCountProperty); }
            set { SetValue(StarsCountProperty, value); }
        }

        public static readonly DependencyProperty StarColorProperty = DependencyProperty.Register(
            "StarColor", typeof(Brush), typeof(StarRatingControl), new FrameworkPropertyMetadata(Brushes.Yellow, FrameworkPropertyMetadataOptions.AffectsRender));

        public Brush StarColor
        {
            get { return (Brush)GetValue(StarColorProperty); }
            set { SetValue(StarColorProperty, value); }
        }

        public override void OnApplyTemplate()
        {
            base.OnApplyTemplate();
            UpdateStars();
        }

        protected override void OnPropertyChanged(DependencyPropertyChangedEventArgs e)
        {
            base.OnPropertyChanged(e);
            if (e.Property == StarsCountProperty || e.Property == StarColorProperty)
            {
                UpdateStars();
            }
        }

        private void UpdateStars()
        {
            if (GetTemplateChild("PART_StarPanel") is Panel starPanel)
            {
                starPanel.Children.Clear();
                for (int i = 0; i < StarsCount; i++)
                {
                    var star = new Path
                    {
                        Data = Geometry.Parse(_starPath),
                        Fill = StarColor,
                        Stretch = Stretch.Uniform,
                        Width = _starWidth, 
                        Height = _starHeight,
                        Margin = new Thickness(0, 0, 2, 0)
                    };
                    starPanel.Children.Add(star);
                }

                for (int i = StarsCount; i < 5; i++)
                {
                    var star = new Path
                    {
                        Data = Geometry.Parse(_starPath),
                        Fill = Brushes.Gray,
                        Stretch = Stretch.Uniform,
                        Width = _starWidth,
                        Height = _starHeight,
                        Margin = new Thickness(0, 0, 2, 0)
                    };
                    starPanel.Children.Add(star);
                }
            }
        }
    }
}
