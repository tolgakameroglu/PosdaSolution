using POSDA.GlobalVar;
using POSDA.Methods;
using POSDA.Views;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Xamarin.Forms;


namespace POSDA
{
    public class App : Application
    {
        public App()
        {
            var mth = new Methodlar();

            MainPage = new MasterDetail();
            //mth.newMasterDetail();//               
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
