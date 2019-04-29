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
using System.Windows.Shapes;

namespace CA1
{
    /// <summary>
    /// Interaction logic for TrusteeWindow.xaml
    /// </summary>
    public partial class TrusteeWindow : Window
    {
        public TrusteeWindow()
        {
            InitializeComponent();

            Signed_btn.Content = "Signed in as " + LoggedUser.Username;
        }

        User LoggedUser;

        public TrusteeWindow(User user):this()
        {
            LoggedUser = user;

        }

        
    }
}
