using POSDA.GlobalVar;
using POSDA.Methods;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace POSDA.Views
{
    class WelcomePage:ContentPage
    {
        GlobalDegisken g;
        public WelcomePage(GlobalDegisken glb)
        {
            Padding = new Thickness(0, Device.OS == TargetPlatform.iOS ? 20 : 0, 0, 0);
            g = glb;

            
            
            


            if (g.signIn)
            {
                startInPage();

            }
            else
            {
                if (g.checkDbUser)
                {


                }else
                {


                }

                startOutPage();
            }


            



        }


        void OnButtonClicked(object sender, EventArgs e)
        {
            var mth = new Methodlar();


            if (g.signIn)
            {

            }
            else
            {
                if (g.checkDbUser)
                {
                    g.usernameEntry.Text = g.user.user;
                    g.passwordEntry.Text = g.user.pass;
                    g.custEntry.Text = g.user.cust;
                    g.cpssEntry.Text = g.user.cpss;
                    g.rememberSwt.On = g.user.remember;
                    g.savepassSwt.On = g.user.save;



                }
                

                LoginPage loginp = new LoginPage(g);
                g.mdp.Detail.Navigation.PushAsync(loginp);
            }



        }

        public  async void startOutPage()
        {

            StackLayout layout = new StackLayout();

            g.mainButton.Text = "Start To tyr!";
            g.mainButton.Clicked += OnButtonClicked;

            layout.Children.Add(g.mainButton);

            this.Content = layout;

        }
        public async void startInPage()
        {
            StackLayout layout = new StackLayout();
            var mth = new Methodlar();


            ContentPage p = new ContentPage();
            p = mth.showProgress("Get Report Data...", this);


            Grid grid = new Grid
            {
                VerticalOptions = LayoutOptions.FillAndExpand,
                HorizontalOptions = LayoutOptions.FillAndExpand,
                ColumnSpacing = 10,
                RowSpacing = 10,
                RowDefinitions =
                {
                    new RowDefinition { Height = 75 },//GridLength.Auto
                    new RowDefinition { Height = 200 },
                    new RowDefinition { Height = 20 },
                    //new RowDefinition { Height = new GridLength(1, GridUnitType.Star) },
                    //new RowDefinition { Height = new GridLength(100, GridUnitType.Absolute) }
                },
                ColumnDefinitions =
                {
                    new ColumnDefinition { Width = GridLength.Star },
                    new ColumnDefinition { Width = GridLength.Star },
                    //new ColumnDefinition { Width = new GridLength(1, GridUnitType.Star) },
                    //new ColumnDefinition { Width = new GridLength(100, GridUnitType.Absolute) }
                }
            };

            List<MyData> myData = new List<MyData>();

            
            try
            {
                ServiceManager sm = new ServiceManager();
                myData = await sm.GetReport(g.user.sesid, "101", "", "2");
            }
            catch (Exception)
            {
                mth.hideProgress(p);
                throw;
            }
            finally
            {
                grid.Children.Add(await mth.dsh_Label(myData[myData.Count() - 1].Val1, myData[myData.Count() - 1].Val1, myData[myData.Count() - 1].Val2, ""), 0, 2, 0, 1);

                grid.Children.Add(await mth.dsh_Line("Haftalık Satışlar", "WEEKLY QUANTITY"), 0, 2, 1, 3);

                grid.Children.Add(await mth.dsh_Text("http://www.peraport.net"), 0, 2, 3, 4);

                

            }







            layout.Children.Add(new ScrollView { Content = grid });
            layout.Children.Add(g.mainButton);


            this.Content = layout;


            //Navigation.InsertPageBefore(this, Navigation.NavigationStack.First());
            //await Navigation.PopToRootAsync(true);

            mth.hideProgress(p);


        }
    }
}
