using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;

namespace Hotels_Manager.Views.Controls
{
    class ModernButton : Button
    {
        static ModernButton()
        {
            DefaultStyleKeyProperty.OverrideMetadata(typeof(ModernButton), new FrameworkPropertyMetadata(typeof(ModernButton)));
        }

        public static readonly DependencyProperty CornerRadiusProperty =
           DependencyProperty.Register("CornerRadius", typeof(CornerRadius), typeof(ModernButton));
        public CornerRadius CornerRadius
        {
            get { return (CornerRadius)GetValue(CornerRadiusProperty); }
            set { SetValue(CornerRadiusProperty, value); }
        }

        public static readonly DependencyProperty MouseOverColorProperty =
            DependencyProperty.Register("MouseOverColor", typeof(Brush), typeof(ModernButton));
        public Brush MouseOverColor
        {
            get { return (Brush)GetValue(MouseOverColorProperty); }
            set { SetValue(MouseOverColorProperty, value); }
        }

        public static readonly DependencyProperty MouseOverTextColorProperty =
            DependencyProperty.Register("MouseOverTextColor", typeof(Brush), typeof(ModernButton));
        public Brush MouseOverTextColor
        {
            get { return (Brush)GetValue(MouseOverTextColorProperty); }
            set { SetValue(MouseOverTextColorProperty, value); }
        }
    }
}
