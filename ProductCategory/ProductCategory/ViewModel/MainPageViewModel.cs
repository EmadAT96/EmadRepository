using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;
using ProductCategory.Model;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;

namespace ProductCategory.ViewModel
{
    public class MainPageViewModel : INotifyPropertyChanged
    {
        public MainPageViewModel()
        {
            CreatedDate = DateTime.Now;
            CCreatedDate = DateTime.Now;
            Categories.Add(new Category
            {
                CategoryName = "Test1",
                CategoryId = 100,
                CreatedDate = DateTime.Now
            });
            AvailableCategories = Categories.Select(X => X.CategoryName).ToList();
            Test = "Test";
            SubmitProduct = new Command(execute: () => {
                if (Products.Count == 0)
                {
                    ProductId = 1;
                }
                else
                {
                    ProductId = Products.Select(x => x.ProductId).Last() + 1;
                }
                Products.Add(new Product
                {
                    ProductId = ProductId,
                    ProductName = ProductName,
                    CreatedDate = CreatedDate,
                    Pcategory = Categories.Where(x => x.CategoryName == SelectedCategoryForProduct).First()
                });
                Categories.Where(x => x.CategoryName == SelectedCategoryForProduct).First().Products.Add(Products.Last());
                ProductName = "";
            });

            SubmitCategory = new Command(execute: () =>
            {
                if(Categories.Count == 0)
                {
                    CategoryId = 100;
                }
                else
                {
                    CategoryId = Categories.Select(x => x.CategoryId).Last() + 1;
                }
                Categories.Add(new Category
                {
                    CategoryId = CategoryId,
                    CategoryName = CategoryName,
                    CreatedDate = CCreatedDate
                });
                AvailableCategories = Categories.Select(X => X.CategoryName).ToList();
                CategoryName = "";
                
            },canExecute: () => CategoryName != "");
            ShowSelectedCategoryProducts = new Command(execute: () =>
            {
                SelectedCategoryForProdutcs = Categories.Where(x => x.CategoryName == SelectedCategory.CategoryName).First().Products;
            });
            

        }

        public string ProductName { get; set; }
        public Product SelectedProduct { get; set; } = new Product();
        public Category SelectedCategory { get; set; } = new Category();
        public string Test { get; set; }
        public DateTime CreatedDate { get; set; }
        public int CategoryId { get; set; }
        public DateTime CCreatedDate { get; set; }
        public string CategoryName { get; set; }
        public Command SubmitProduct { get; set; }
        public Command SubmitCategory { get; set; }
        public Command ShowSelectedCategoryProducts { get; set; }
        public int ProductId { get; set; }
        public ObservableCollection<Product> Products { get; set; } = new ObservableCollection<Product>();
        public ObservableCollection<Category> Categories { get; set; } = new ObservableCollection<Category>();
        public List<string> AvailableCategories { get; set; } = new List<string>();
        public ObservableCollection<Product> SelectedCategoryForProdutcs { get; set; } = new ObservableCollection<Product>();
        public string SelectedCategoryForProduct { get; set; }
        public Category SelectedCategoryForShow { get; set; }

        public event PropertyChangedEventHandler PropertyChanged;
    }
}
