using WindowsFeatureDemo.DataModel;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;

namespace WindowsFeatureDemo
{
    public sealed partial class MainPage : Page
    {
        private static IMainPageViewModel ViewModel;

        public MainPage()
        {
            this.InitializeComponent();

            if (ViewModel == null)
            {
                ViewModel = new MainPageViewModel();
            }

            DataContext = ViewModel;
        }

        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
        }
    }
}
