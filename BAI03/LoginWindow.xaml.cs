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

namespace BAI03
{
    /// <summary>
    /// Interaction logic for DangNhapWindow.xaml
    /// </summary>
    public partial class DangNhapWindow : Window
    {
        public DangNhapWindow()
        {
            InitializeComponent();
        }

        private void btnOK_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if ((tbTen.Text == "admin" || tbTen.Text == "Admin") && pbMatKhau.Password == "123456")
                {
                    MessageBox.Show("Login successful!", "Information", MessageBoxButton.OK, MessageBoxImage.Information);
                    QuanLySanPhamWindow qlsp = new QuanLySanPhamWindow();
                    qlsp.Show();
                    this.Close();
                }
                else
                {
                    MessageBox.Show("Login failed!", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message);
            }
        }

        private void btnCancel_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                MessageBoxResult kq = MessageBox.Show("Are you sure you want to exit the application?", "Confirmation", MessageBoxButton.YesNo, MessageBoxImage.Question);
                if (kq == MessageBoxResult.Yes)
                {
                    this.Close();
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}