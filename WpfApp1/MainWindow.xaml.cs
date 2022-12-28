using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
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

namespace WpfApp1
{
    /// <summary>
    /// MainWindow.xaml 的交互逻辑
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void btn_Click(object sender, RoutedEventArgs e)
        {
            if (btn.Content.ToString() == "true")
            {
                btn.Content = "false";
            }
            else
            {
                btn.Content = "true";
            }
        }
        private int _num { set; get; } = 1;
        public int Num
        {
            set 
            {
                _num = value;
                this.RaisePropertyChanged();
            }
            get { return _num; }
        }


        private void ort_Click(object sender, RoutedEventArgs e)
        {
            
            if (Num == 2)
            {
                Num = 1;
                PP.Direction = 1;
            }
            else
            {
                Num = 2;
                PP.Direction = 2;
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;

        public void RaisePropertyChanged([CallerMemberName] string propName = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propName));
        }

        public void Set<T>(ref T field, T value, [CallerMemberName] string propName = "")
        {
            if (EqualityComparer<T>.Default.Equals(field, value))
                return;

            field = value;
            RaisePropertyChanged(propName);
        }
    }

 
}
