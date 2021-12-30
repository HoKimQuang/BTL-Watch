using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Watch.Models
{

    /// <summary>
    /// Bang Danh Muc
    /// </summary>
    public class Category
    {
        /// <summary>
        /// Ma Danh Muc (Khoa Chinh)
        /// </summary>
        public int ID { get; set; }

        /// <summary>
        /// Ten Danh Muc
        /// </summary>
        public string TenDM { get; set; }

        /// <summary>
        /// LK Bang San Pham
        /// </summary>
        public virtual ICollection<Product> Products { get; set; }
    }
}