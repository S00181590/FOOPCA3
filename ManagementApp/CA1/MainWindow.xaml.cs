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

namespace CA1
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        StorageEntities db = new StorageEntities();

        public User StatusUser;

        public MainWindow()
        {
            InitializeComponent();

            
        }

        private void RegBtn_Click(object sender, RoutedEventArgs e)
        {
            User U = new User("", "", "");

            if(RegNameBx != null)
            {
                if(RegPasBx != null)
                {
                    if(TrRadio != null || CRadio != null)
                    {
                        if(TrRadio != null)
                        {
                            U = new User(RegNameBx.Text, RegPasBx.Text, "Trustee");
                        }
                        else if(CRadio != null)
                        {
                            U = new User(RegNameBx.Text, RegPasBx.Text, "Protectorite");
                        }

                        db.Users.Add(U);

                    }
                }
            }
            db.SaveChanges();
        }

        private void SignBtn_Click(object sender, RoutedEventArgs e)
        {
            string name = SignNameBx.Text;

            

            var NamCon = from C in db.Users
                         where C.Username == name
                         select C;

            string pass = SignPassBx.Text;

            List<User> possible = NamCon.ToList<User>();

            foreach (User U in possible)
            {

                if (U.Password == pass)
                {
                    StatusUser = U;

                    TrusteeWindow trustee = new TrusteeWindow(U);
                    trustee.Owner = this;
                    
                    trustee.ShowDialog();
                }

            }

        }
    }

    public partial class User
    {

        public User()
        {

        }

        public User(string name, string pw, string type)
        {

        }

    }

}
