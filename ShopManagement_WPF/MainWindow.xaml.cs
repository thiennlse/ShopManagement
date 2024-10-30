using Service;
using Service.Interface;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace ShopManagement_WPF
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {   
        private readonly IMemberService _memberService;
        public MainWindow()
        {
            InitializeComponent();
            _memberService = new MemberService();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                var member = _memberService.ExistUsername(txtUserName.Text);
                if (member.Password != txtPassword.Password || member == null)
                {
                    MessageBox.Show("Wrong Username or Password");
                }
                if (member.Role.Equals("Admin"))
                {
                    MemberManagement memberpage = new MemberManagement();
                    memberpage.Show();
                    this.Close();
                }
                ProductWindow productWindow = new ProductWindow();
                productWindow.Show();
                this.Close();
            }
            catch (Exception ex) 
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}