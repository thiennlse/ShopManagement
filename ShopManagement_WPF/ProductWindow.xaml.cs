using BusinessObject.Models;
using Repository;
using Service;
using Service.Interface;
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

namespace ShopManagement_WPF
{
    /// <summary>
    /// Interaction logic for ProductWindow.xaml
    /// </summary>
    public partial class ProductWindow : Window
    {
        private readonly IProductService _productService;
        private readonly IOrderService _orderService;
        public ProductWindow()
        {
            InitializeComponent();
            _productService = new ProductService();
            _orderService = new OderService();
        }

        private void dgProducts_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            DataGrid dataGrid = sender as DataGrid;
            DataGridRow row =
                (DataGridRow)dataGrid.ItemContainerGenerator.ContainerFromIndex(dataGrid.SelectedIndex);
            DataGridCell RowColumn = dataGrid.Columns[0].GetCellContent(row).Parent as DataGridCell;
            int id = int.Parse(((TextBlock)RowColumn.Content).Text);
            Product prod = _productService.GetById(id);
        }

        private void LoadProduct()
        {
            var products = _productService.GetAll();
            dgProducts.ItemsSource = products;
        }

        private void btnAddOrder_Click(object sender, RoutedEventArgs e)
        {
            if (dgProducts.SelectedItem is var selectedProduct && selectedProduct != null)
            {
                Product product = selectedProduct as Product;

                if (int.TryParse(txtQuantity.Text, out int quantity) && quantity > 0)
                {
                    Order order = new Order
                    {
                        Description = product.Name,
                        Quantity = int.Parse(txtQuantity.Text),
                        TotalPrice = int.Parse(txtQuantity.Text) * product.Price,

                    };
                    _orderService.AddOder(order);
                    MessageBox.Show($"Order placed for {quantity} of {((dynamic)selectedProduct).Name}.");
                    txtQuantity.Clear();
                }
                else
                {
                    MessageBox.Show("Please enter a valid quantity greater than 0.", "Invalid Quantity", MessageBoxButton.OK, MessageBoxImage.Warning);
                    txtQuantity.Clear();
                    txtQuantity.Focus();
                }
            }
            else
            {
                MessageBox.Show("Please select a product to order.", "No Product Selected", MessageBoxButton.OK, MessageBoxImage.Warning);
            }
        }

        private void btnSwitchToOrder_Click(object sender, RoutedEventArgs e)
        {

        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            LoadProduct();
        }

        private void btnSwitchToOrderWindow_Click(object sender, RoutedEventArgs e)
        {
            LoadProduct();
        }
    }
}
