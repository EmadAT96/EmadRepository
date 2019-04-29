using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using ProductCategory.ViewModel;

namespace ProductCategory
{
    // Learn more about making custom code visible in the Xamarin.Forms previewer
    // by visiting https://aka.ms/xamarinforms-previewer
    [DesignTimeVisible(true)]
    public partial class MainPage : ContentPage
    {
        MainPageViewModel MainPageViewModel;
        public MainPage()
        {
            InitializeComponent();

            BindingContext = MainPageViewModel = new MainPageViewModel();
        }
    }
}
