using System;
using System.Collections.Generic;
using System.Text;

namespace ProductCategory.Model
{
    public class Product
    {
        public int ProductId { get; set; }
        public string ProductName { get; set; }
        public DateTime CreatedDate { get; set; }
        public Category Pcategory { get; set; } = new Category();
    }
}
