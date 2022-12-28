using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace WpfApp1.Component
{
    /// <summary>
    /// UserControl2.xaml 的交互逻辑
    /// </summary>
    public partial class UserControl2 : UserControl
    {
        public UserControl2()
        {
            InitializeComponent();
        }

        public bool IsRunning5
        {
            get { return (bool)GetValue(IsRunningProperty5); }
            set { SetValue(IsRunningProperty5, value); }
        }
        public static readonly DependencyProperty IsRunningProperty5 =
            DependencyProperty.Register("IsRunning5", typeof(bool), typeof(UserControl1), new PropertyMetadata(default(bool), new PropertyChangedCallback(OnRunningStateChanged5)));

        private static void OnRunningStateChanged5(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            bool state = (bool)e.NewValue;
            VisualStateManager.GoToState(d as UserControl1, state ? "RunFlowState" : "StopFlowState", false);
        }

        public int Direction5
        {
            get { return (int)GetValue(DirectionProperty5); }
            set { SetValue(DirectionProperty5, value); }
        }
        public static readonly DependencyProperty DirectionProperty5 =
            DependencyProperty.Register("Direction5", typeof(int), typeof(UserControl1), new PropertyMetadata(default(int), new PropertyChangedCallback(OnDirectionChanged5)));

        private static void OnDirectionChanged5(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            int value = int.Parse(e.NewValue.ToString());
            VisualStateManager.GoToState(d as UserControl1, "RunFlowState", false);
        }

        public Brush LiquidColor5
        {
            get { return (Brush)GetValue(LiguidColorProperty5); }
            set { SetValue(LiguidColorProperty5, value); }
        }
        public static readonly DependencyProperty LiguidColorProperty5 =
            DependencyProperty.Register("LiquidColor5", typeof(Brush), typeof(UserControl1), new PropertyMetadata(Brushes.Orange));

        public int CapRadius5
        {
            get { return (int)GetValue(CapRadiusProperty5); }
            set { SetValue(CapRadiusProperty5, value); }
        }
        public static readonly DependencyProperty CapRadiusProperty5 =
            DependencyProperty.Register("CapRadius5", typeof(int), typeof(UserControl1), new PropertyMetadata(default(int)));
    }
}
