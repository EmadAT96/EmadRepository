using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;

namespace ProductCategory.Model
{
    public class Category
    {
        public int CategoryId { get; set; }
        public string CategoryName { get; set; }
        public DateTime CreatedDate { get; set; }
        public ObservableCollection<Product> Products { get; set; } = new ObservableCollection<Product>();
    }
}
