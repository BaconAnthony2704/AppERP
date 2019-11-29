using ConsolidaApp.Pages;
using System;
using Xamarin.Essentials;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace ConsolidaApp
{
    public partial class App : Application
    {
        public static string BaseImageUrl { get; } = "https://cdn.syncfusion.com/essential-ui-kit-for-xamarin.forms/common/uikitimages/";
        
        public App()
        {
            InitializeComponent();
            if (!string.IsNullOrEmpty(Preferences.Get("accesstoken", "")))
            {
                MainPage = new MainPage();
            }
            else if(string.IsNullOrEmpty(Preferences.Get("useremail","")) && string.IsNullOrEmpty(Preferences.Get("password","")))
            {
                MainPage = new NavigationPage(new LoginPage());
            }
            //MainPage = new NavigationPage(new LoginPage());

           

        }

        protected override void OnStart()
        {
            // Handle when your app starts
        }

        protected override void OnSleep()
        {
            // Handle when your app sleeps
        }

        protected override void OnResume()
        {
            // Handle when your app resumes
        }
    }
}
