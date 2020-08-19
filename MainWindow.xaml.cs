using MC_Packer.Views;
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

namespace MC_Packer
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            DataContext = new StartupView();
            Hide_Nav();
        }

        private void NewPack_Click(object sender, RoutedEventArgs e)
        {
            DataContext = new NewPackView();
        }

        private void Main_Click(object sender, RoutedEventArgs e)
        {
            DataContext = new MainView();
        }

        private void Start_Click(object sender, RoutedEventArgs e)
        {
            DataContext = new StartupView();
        }

        private void Hide_Nav()
        {
            menubar.Visibility = Visibility.Hidden;
            menubar.Height = 0;
        }

        private void Show_Nav()
        {
            menubar.Visibility = Visibility.Visible;
            menubar.Height = Double.NaN;
        }

        private void ViewChanged(object sender, DependencyPropertyChangedEventArgs e)
        {
            if (DataContext.GetType() == new StartupView().GetType())
            {
                Hide_Nav();
            }
            if (DataContext.GetType() == new MainView().GetType())
            {
                Show_Nav();
            }
            if (DataContext.GetType() == new NewPackView().GetType())
            {
                Hide_Nav();
            }
        }

        private void Craft_Click(object sender, RoutedEventArgs e)
        {
            
        }
    }
}
