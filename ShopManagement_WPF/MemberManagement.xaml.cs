using BusinessObject.Models;
using Service;
using Service.Interface;
using System.Windows;
using System.Windows.Controls;

namespace ShopManagement_WPF
{
    public partial class MemberManagement : Window
    {
        private readonly IMemberService _memberService;
        public MemberManagement()
        {
            InitializeComponent();
            _memberService = new MemberService();
        }

        private void btnCreate_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                Member member = new Member
                {
                    Name = txtName.Text,
                    Description = txtDescription.Text,
                    UserName = txtUserName.Text,
                    Role = txtRole.Text,
                    Password = "1"
                };
                _memberService.Add(member);
                MessageBox.Show("Created member successful");
                this.LoadData();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btnUpdate_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                int id = int.Parse(txtMemberId.Text);
                Member member = _memberService.GetById(id);
                member.Description = txtDescription.Text;
                member.Name = txtName.Text;
                member.UserName = txtUserName.Text;
                member.Role = txtRole.Text;
                _memberService.Update(id, member);
                MessageBox.Show("Updated member successful");
                this.LoadData();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        private void LoadData()
        {
            dgData.ItemsSource = _memberService.GetAll();
        }

        private void btnDelete_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                int id = int.Parse(txtMemberId.Text);
                _memberService.Delete(id);
                MessageBox.Show("Deleted member successful");
                this.LoadData();
            }
            catch (Exception ex) 
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btnClose_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void LoadMember()
        {
            var memberList = _memberService.GetAll();
            dgData.ItemsSource = memberList;
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            LoadMember();
        }

        private void dgData_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            DataGrid dataGrid = sender as DataGrid;
            DataGridRow row =
                (DataGridRow)dataGrid.ItemContainerGenerator.ContainerFromIndex(dataGrid.SelectedIndex);
            DataGridCell RowColumn = dataGrid.Columns[0].GetCellContent(row).Parent as DataGridCell;
            int id = int.Parse(((TextBlock)RowColumn.Content).Text);
            Member member = _memberService.GetById(id);
            txtName.Text = member.Name.ToString();
            txtMemberId.Text = member.Id.ToString();
            txtDescription.Text = member.Description.ToString();
            txtRole.Text = member.Role.ToString();
            txtUserName.Text = member.UserName.ToString();
        }
    }
}
