using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace BAI03
{
    
    public class Product_Management
    {
        public void LoadTatCaSanPham(ref ObservableCollection<Product> lstSanPham)
        {
            lstSanPham = new ObservableCollection<Product>
            {
                new Product("P001", "Detergent Powder", 1000, 50, "Bag"),
                new Product("P002", "Toothpaste", 800, 30, "Box"),
                new Product("P003", "Pepsi Soft Drink", 500, 100, "Carton")
            };
        }

        public int ThemSanPham( ref ObservableCollection<Product> lstSanPham, Product sp )
        {
            try
            {
                lstSanPham.Add(sp);
                return 1;
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        public int XoaSanPham ( ref ObservableCollection<Product> lstSanPham, Product sp )
        {
            try
            {
                lstSanPham.Remove(sp);
                return 1;
            }
            catch (Exception ex)
            {
                throw;
            }
        }
        
        public string SinhMaTuDong(ObservableCollection<Product> lstSanPham)
        {
            
            if (lstSanPham == null || lstSanPham.Count == 0)
            {
                return "SP001";
            }

            try
            {
                int maxId = lstSanPham
                    .Where(sp => sp.MaSanPham != null && sp.MaSanPham.StartsWith("SP") && sp.MaSanPham.Length > 2)
                    .Select(sp => int.Parse(sp.MaSanPham.Substring(2)))
                    .DefaultIfEmpty(0)
                    .Max();

                int nextId = maxId + 1;

                return "SP" + nextId.ToString("D3");
            }
            catch
            {
                return "SP" + (lstSanPham.Count + 1).ToString("D3");
            }
        }

    }
}
