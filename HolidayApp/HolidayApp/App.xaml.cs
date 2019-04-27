using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using HolidayApp.Services;
using HolidayApp.Views;

namespace HolidayApp
{
    public partial class App : Application
    {
        private SlowService services;

        public App()
        {
            InitializeComponent();

            DependencyService.Register<MockDataStore>();
            MainPage = new AppShell();
            services = new SlowService();
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
