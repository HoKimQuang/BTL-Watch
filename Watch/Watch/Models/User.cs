using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Watch.Models
{
    /// <summary>
    /// Bang Tai khoan
    /// </summary>
    public class User
    {

        /// <summary>
        /// Khoa chinh
        /// </summary>
        public int ID { get; set; }

        /// <summary>
        /// Ten Tai Khoan
        /// </summary>
        public string TaiKhoan { get; set; }

        /// <summary>
        /// Mat Khau
        /// </summary>
        public string MatKhau { get; set; }

        /// <summary>
        /// Ho Ten
        /// </summary>
        public string HoTen { get; set; }

        /// <summary>
        /// Dia Chi
        /// </summary>
        public string DiaChi { get; set; }

        /// <summary>
        /// So Dien Thoai
        /// </summary>
        public string SDT { get; set; }

        /// <summary>
        /// Email
        /// </summary>
        public string Email { get; set; }

        /// <summary>
        /// Quyen
        /// </summary>
        public int Quyen { get; set; }
    }
}