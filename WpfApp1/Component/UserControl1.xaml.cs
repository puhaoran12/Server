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
    /// UserControl1.xaml 的交互逻辑
    /// </summary>
    public partial class UserControl1 : UserControl
    {
        public UserControl1()
        {
            InitializeComponent();
        }

        public bool IsRunning4
        {
            get { return (bool)GetValue(IsRunningProperty4); }
            set { SetValue(IsRunningProperty4, value); }
        }
        public static readonly DependencyProperty IsRunningProperty4 =
            DependencyProperty.Register("IsRunning4", typeof(bool), typeof(UserControl1), new PropertyMetadata(default(bool), new PropertyChangedCallback(OnRunningStateChanged4)));

        private static void OnRunningStateChanged4(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            bool state = (bool)e.NewValue;
            VisualStateManager.GoToState(d as UserControl1, state ? "RunFlowState" : "StopFlowState", false);
        }

        public int Direction4
        {
            get { return (int)GetValue(DirectionProperty4); }
            set { SetValue(DirectionProperty4, value); }
        }
        public static readonly DependencyProperty DirectionProperty4 =
            DependencyProperty.Register("Direction4", typeof(int), typeof(UserControl1), new PropertyMetadata(default(int), new PropertyChangedCallback(OnDirectionChanged4)));

        private static void OnDirectionChanged4(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            int value = int.Parse(e.NewValue.ToString());
            VisualStateManager.GoToState(d as UserControl1, "RunFlowState", false);
        }

        public Brush LiquidColor4
        {
            get { return (Brush)GetValue(LiguidColorProperty4); }
            set { SetValue(LiguidColorProperty4, value); }
        }
        public static readonly DependencyProperty LiguidColorProperty4 =
            DependencyProperty.Register("LiquidColor4", typeof(Brush), typeof(UserControl1), new PropertyMetadata(Brushes.Orange));

        public int CapRadius4
        {
            get { return (int)GetValue(CapRadiusProperty4); }
            set { SetValue(CapRadiusProperty4, value); }
        }
        public static readonly DependencyProperty CapRadiusProperty4 =
            DependencyProperty.Register("CapRadius4", typeof(int), typeof(UserControl1), new PropertyMetadata(default(int)));
    }
}
