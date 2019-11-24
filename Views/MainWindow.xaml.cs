using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace LazyManWPF.Views
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow() : this(null) { }

        public MainWindow(object dataContext)
        {
            InitializeComponent();
            DataContext = dataContext;
            Loaded += MainWindow_Loaded;
        }

        private void MainWindow_Loaded(object sender, RoutedEventArgs e)
        {
            NHLDatePicker.SelectedDate = DateTime.Now;
            MLBDatePicker.SelectedDate = DateTime.Now;
            /*if(DataContext is IClosable)
            {
                (DataContext as IClosable).RequestClose += (_, __,) => this.Close();
            }*/
        }
    }
}
