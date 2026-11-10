using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BAI03
{
    public class Product
    {
        string _maSanPham;
        string _tenSanPham;
        int _soLuong;
        double _donGia;
        string _donViTinh;

        public string MaSanPham { get => _maSanPham; set => _maSanPham = value; }
        public string TenSanPham { get => _tenSanPham; set => _tenSanPham = value; }
        public int SoLuong { get => _soLuong; set => _soLuong = value; }
        public double DonGia { get => _donGia; set => _donGia = value; }
        public string DonViTinh { get => _donViTinh; set => _donViTinh = value; }

        public Product() { }

        public Product (string MaSP, string TenSP, int SL, double DG, string DVT)
        {
            MaSanPham = MaSP;
            TenSanPham = TenSP;
            SoLuong = SL;
            DonGia = DG;
            DonViTinh = DVT;
        }
    }
}
