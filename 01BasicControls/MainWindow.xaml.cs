using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
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

namespace _01BasicControls
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private delegate void updateProgressBarDelegate(DependencyProperty depProperty, object value);

        public MainWindow()
        {
            InitializeComponent();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            this.Language = System.Windows.Markup.XmlLanguage.GetLanguage(Thread.CurrentThread.CurrentCulture.Name);
        }

        private void handleProgressBar()
        {
            //valore di partenza
            double value = pBar.Value;
            //istanza delegate per puntare almetodo richiesto.
            updateProgressBarDelegate updateProgressBar = new updateProgressBarDelegate(pBar.SetValue);
            //finchè non raggiunge il valore massimo incrementa
            while (!(pBar.Value == pBar.Maximum))
            {
                value += 1;
                //invova il delegate con thread a priorità bassa.
                Dispatcher.Invoke(updateProgressBar, 
                    System.Windows.Threading.DispatcherPriority.Background,
                    new object[] { ProgressBar.ValueProperty,value });
            }

        }

        private void btnGoPbar_Click(object sender, RoutedEventArgs e)
        {
            handleProgressBar();
            pBar.Value = 0;
        }
    }
}
