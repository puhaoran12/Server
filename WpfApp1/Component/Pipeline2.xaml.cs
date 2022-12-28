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
    /// Pipeline2.xaml 的交互逻辑
    /// </summary>
    public partial class Pipeline2 : UserControl
    {
        public Pipeline2()
        {
            InitializeComponent();
        }
        public bool IsRunning3
        {
            get { return (bool)GetValue(IsRunningProperty); }
            set { SetValue(IsRunningProperty, value); }
        }
        public static readonly DependencyProperty IsRunningProperty =
            DependencyProperty.Register("IsRunning3", typeof(bool), typeof(Pipeline2), new PropertyMetadata(default(bool), new PropertyChangedCallback(OnRunningStateChanged3)));

        private static void OnRunningStateChanged3(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            bool state = (bool)e.NewValue;
            VisualStateManager.GoToState(d as Pipeline2, state ? "RunFlowState" : "StopFlowState", false);
        }

        /// <summary>
        /// 液体流向，接受1和2两个值
        /// </summary>
        public int Direction3
        {
            get { return (int)GetValue(DirectionProperty3); }
            set { SetValue(DirectionProperty3, value); }
        }
        public static readonly DependencyProperty DirectionProperty3 =
            DependencyProperty.Register("Direction3", typeof(int), typeof(Pipeline2), new PropertyMetadata(default(int), new PropertyChangedCallback(OnDirectionChanged3)));

        private static void OnDirectionChanged3(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            int value = int.Parse(e.NewValue.ToString());
            VisualStateManager.GoToState(d as Pipeline2, "RunFlowState", false);
        }

        public Brush LiquidColor3
        {
            get { return (Brush)GetValue(LiguidColorProperty3); }
            set { SetValue(LiguidColorProperty3, value); }
        }
        public static readonly DependencyProperty LiguidColorProperty3 =
            DependencyProperty.Register("LiquidColor3", typeof(Brush), typeof(Pipeline2), new PropertyMetadata(Brushes.Orange));

        public int CapRadius3
        {
            get { return (int)GetValue(CapRadiusProperty3); }
            set { SetValue(CapRadiusProperty3, value); }
        }
        public static readonly DependencyProperty CapRadiusProperty3 =
            DependencyProperty.Register("CapRadius3", typeof(int), typeof(Pipeline2), new PropertyMetadata(default(int)));

    }
}
