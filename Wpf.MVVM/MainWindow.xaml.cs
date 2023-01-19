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
using Wpf.MVVM.ViewModel;
namespace Wpf.MVVM
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        CategoryViewModel categoryViewModel;
        public MainWindow()
        {
            InitializeComponent();
            categoryViewModel=new CategoryViewModel();
            this.DataContext = categoryViewModel;
        }
    }
}
