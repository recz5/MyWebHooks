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
using mPowerBitBucketAPI;

namespace mPowerBitBucketWCFApp
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        bool validUser = false;

        public MainWindow()
        {
            InitializeComponent();

            while (!validUser)
            { 
                BitbucketUsername.Visibility = System.Windows.Visibility.Visible;
            
                UserControls.Visibility = System.Windows.Visibility.Hidden;
            
                APIResults.Visibility = System.Windows.Visibility.Hidden;

                TestLogin();
            }

        }

        private void Execute_Button(object sender, RoutedEventArgs e)
        {
            this.Title = ReposirotyComboBox.Text + SourceTypesComboBox.Text;
        }

        private void Cancel_Click(object sender, RoutedEventArgs e)
        {
            this.Title = ReposirotyComboBox.Text + SourceTypesComboBox.Text;
        }

        private void Enter_Click(object sender, RoutedEventArgs e)
        {
            this.Title = ReposirotyComboBox.Text + SourceTypesComboBox.Text;
        }

        private void TestLogin()
        { 
            
        }
    }
}
