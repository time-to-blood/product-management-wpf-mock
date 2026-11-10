using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Linq;
using System.Security.Policy;
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

namespace BAI03
{
    /// <summary>
    /// Interaction logic for QuanLySanPhamWindow.xaml
    /// </summary>
    public partial class QuanLySanPhamWindow : Window
    {
        Product_Management qlsp = new Product_Management();
        ObservableCollection<Product> lstSanPham = new ObservableCollection<Product>();
        public QuanLySanPhamWindow()
        {
            InitializeComponent();
        }

        private void QuanLySanPham_Loaded(object sender, RoutedEventArgs e)
        {
            List<string> lstDonViTinh = new List<string> { "Pieces", "Item", "Box", "Kg", "Liter","Bag", "Carton" };
            cbDonViTinh.ItemsSource = lstDonViTinh;
            cbDonViTinh.SelectedIndex = 0;

            qlsp.LoadTatCaSanPham(ref lstSanPham);
            dgSanPham.ItemsSource = lstSanPham;

            tbMaSP.Text = qlsp.SinhMaTuDong(lstSanPham);
        }

        private void btnThem_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                Product sp = new Product();
                sp.MaSanPham = tbMaSP.Text;
                sp.TenSanPham = tbTenSP.Text;
                sp.SoLuong = Convert.ToInt32(tbSoLuong.Text);
                sp.DonGia = Convert.ToDouble(tbDonGia.Text);
                sp.DonViTinh = cbDonViTinh.Text;
                qlsp.ThemSanPham(ref lstSanPham, sp);
                MessageBox.Show("Product added successfully!", "Information", MessageBoxButton.OK, MessageBoxImage.Information);

                tbTenSP.Text = "";
                tbSoLuong.Text = "";
                tbDonGia.Text = "";
                cbDonViTinh.SelectedIndex = 0;

                tbMaSP.Text = qlsp.SinhMaTuDong(lstSanPham);
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex);
            }
        }

        private void btnXoa_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                Product spDuocChon = dgSanPham.SelectedItem as Product;
                if (spDuocChon != null)
                {
                    MessageBoxResult kq = MessageBox.Show("Are you sure you want to delete this product?", "Confirm Delete", MessageBoxButton.YesNo, MessageBoxImage.Question);
                    if (kq == MessageBoxResult.Yes)
                    {
                        qlsp.XoaSanPham(ref lstSanPham, spDuocChon);
                        MessageBox.Show("Product deleted successfully!", "Information", MessageBoxButton.OK, MessageBoxImage.Information);

                        tbMaSP.Text = qlsp.SinhMaTuDong(lstSanPham);
                    }
                }
                else
                {
                    MessageBox.Show("Please select a product from the table to delete!", "Warning", MessageBoxButton.OK, MessageBoxImage.Warning);
                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex);
            }
        }

        private void dgSanPham_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

            Product spDuocChon = dgSanPham.SelectedItem as Product;

            if (spDuocChon != null)
            {

                tbMaSP.Text = spDuocChon.MaSanPham;
                tbTenSP.Text = spDuocChon.TenSanPham;
                tbSoLuong.Text = spDuocChon.SoLuong.ToString();
                tbDonGia.Text = spDuocChon.DonGia.ToString();
                cbDonViTinh.Text = spDuocChon.DonViTinh;

            }
        }

        private void btnSua_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                Product spDuocChon = dgSanPham.SelectedItem as Product;

                if (spDuocChon != null)
                {

                    spDuocChon.TenSanPham = tbTenSP.Text.Trim();
                    spDuocChon.SoLuong = Convert.ToInt32(tbSoLuong.Text);
                    spDuocChon.DonGia = Convert.ToDouble(tbDonGia.Text);
                    spDuocChon.DonViTinh = cbDonViTinh.Text;


                    dgSanPham.Items.Refresh();

                    MessageBox.Show("Product updated successfully!", "Information", MessageBoxButton.OK, MessageBoxImage.Information);
                }
                else
                {
                    MessageBox.Show("Please select a product from the table to edit!", "Warning", MessageBoxButton.OK, MessageBoxImage.Warning);
                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex);
            }
        }

        private void btnTimKiem_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                string tuKhoa = tbTimKiem.Text.Trim().ToLower();

                if (string.IsNullOrEmpty(tuKhoa))
                {

                    dgSanPham.ItemsSource = lstSanPham;
                }
                else
                {

                    var ketQua = lstSanPham
                        .Where(sp => (sp.TenSanPham != null && sp.TenSanPham.ToLower().Contains(tuKhoa)) ||
                                     (sp.MaSanPham != null && sp.MaSanPham.ToLower().Contains(tuKhoa)))
                        .ToList();

                    dgSanPham.ItemsSource = ketQua;
                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex);
            }

        }

    }
}
