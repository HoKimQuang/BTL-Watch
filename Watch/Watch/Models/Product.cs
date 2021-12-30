using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Watch.Models
{

    /// <summary>
    /// Bang San Pham
    /// </summary>
    public class Product
    {

        /// <summary>
        /// Ma San Pham (Khoa chinh)
        /// </summary>
        public int ID { get; set; }

        /// <summary>
        /// Ten San Pham
        /// </summary>
        public string TenSP { get; set; }

        /// <summary>
        /// Hinh Anh
        /// </summary>
        public string HinhAnh { get; set; }

        /// <summary>
        /// So Luong
        /// </summary>
        public int SoLuong { get; set; }

        /// <summary>
        /// Don Gia
        /// </summary>
        public decimal DonGia { get; set; }

        /// <summary>
        /// Mo ta
        /// </summary>
        public string MoTa { get; set; }

        /// <summary>
        /// Khoa Ngoai LK Bang Danh Muc
        /// </summary>
        public int CategoryID { get; set; }
        public virtual Category Category { get; set; }

    }
}