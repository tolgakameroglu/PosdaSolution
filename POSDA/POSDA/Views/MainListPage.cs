using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using POSDA.Methods;
using POSDA.GlobalVar;

namespace POSDA.Views
{
    public class MainListPage : ContentPage
    {
        GlobalDegisken g;
        public MainListPage(GlobalDegisken glb)
        {
            g = glb;
            var mth = new Methodlar();

           
            Title = "";
            StackLayout layout = new StackLayout();

            

            if (g.signIn)
            {

            }else
            {
                g.mainButton.Text = "Start To tyr!";
                g.mainButton.Clicked += OnButtonClicked;
            }

            layout.Children.Add(mth.mainList(this,g));
            layout.Children.Add(g.mainButton);

            
            Content = layout;

        }

        async void OnButtonClicked(object sender, EventArgs e)
        {
            if (g.signIn)
            {

            }
            else
            {
                

                var mth = new Methodlar();
                var um = new UserMethods();

                await um.dbCheckUser(g);

                LoginPage loginp = new LoginPage(g);

                mth.callPage(g, loginp);
            }



        }
    }
}
