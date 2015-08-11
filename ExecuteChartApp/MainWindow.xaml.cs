using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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
using MahApps.Metro.Controls;


namespace PieChartResources
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    /// 

    public partial class MainWindow : MetroWindow
    {
        ObservableCollection<MyCollection> dataCollection = new ObservableCollection<MyCollection>();
        public ObservableCollection<MyCollection> DataCollection { get { return dataCollection; } }

        public MainWindow()
        {
            
            InitializeComponent();
            
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            ErrorMessage.Content = "";
            try
            {
                if (Parameter.Text == "")
                {
                    ErrorMessage.Content = PieChartResources.Resources.English.param_err_msg;
                }
                else
                {
                    dataCollection.Add(new MyCollection(Parameter.Text, Double.Parse(Value.Text)));
                    this.DataContext = dataCollection;
                    this.InitializeComponent();
                    Parameter.Clear();
                    Value.Clear();
                }
               
            }
            catch (Exception)
            {

                ErrorMessage.Content = ErrorMessage.Content + PieChartResources.Resources.English.val_err;
                    Value.Clear();
                
                
            }

        }

        private void TextBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            var parameter = sender as TextBox;
        }

        private void TextBox_TextChanged_1(object sender, TextChangedEventArgs e)
        {
            var value = sender as TextBox;
        }

        private void Datagrid_Loaded(object sender, RoutedEventArgs e)
        {
            
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

       
       

    }

    public class MyCollection
    {
       
        public string Parameter { get; set; }
        public double Value { get; set; }
       
        public MyCollection(string name, double val)
        {
            this.Parameter = name;
            this.Value = val;
        }
    }
}
