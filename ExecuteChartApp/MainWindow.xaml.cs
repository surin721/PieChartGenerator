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
using PieChartResources.Resources;


namespace PieChartResources
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    /// 

    public partial class MainWindow : MetroWindow
    {
        ObservableCollection<PieChartDataCollection> dataCollection = new ObservableCollection<PieChartDataCollection>();
        public ObservableCollection<PieChartDataCollection> DataCollection { get { return dataCollection; } }

        public MainWindow()
        {
            
            InitializeComponent();
            
        }

        private void add_clicked(object sender, RoutedEventArgs e)
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
                    dataCollection.Add(new PieChartDataCollection(Parameter.Text, Double.Parse(Value.Text)));
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

        private void parameter_changed(object sender, TextChangedEventArgs e)
        {
            var parameter = sender as TextBox;
        }

        private void value_changed(object sender, TextChangedEventArgs e)
        {
            var value = sender as TextBox;
        }

       

        private void cancel_clicked(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

       
       

    }

    public class PieChartDataCollection
    {
       
        public string Parameter { get; set; }
        public double Value { get; set; }
       
        public PieChartDataCollection(string name, double val)
        {
            this.Parameter = name;
            this.Value = val;
        }
    }
}
