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
    class LoginPage : ContentPage
    {
        GlobalDegisken g;
        public LoginPage(GlobalDegisken glb)
        {
            g = glb;
            Padding = new Thickness(0, Device.OS == TargetPlatform.iOS ? 20 : 0, 0, 0);
            Content = loginView();
            
       }

        public StackLayout loginView()
        {

            StackLayout lyt = new StackLayout();
            lyt.Padding = new Thickness(5, Device.OS == TargetPlatform.iOS ? 20 : 5, 5, 5);
            lyt.BackgroundColor = Color.White;

            TableView tableView = new TableView();
            tableView.Intent = TableIntent.Menu;
            tableView.BackgroundColor = Color.White;
            tableView.RowHeight = 30;
            tableView.HasUnevenRows = true;
            tableView.HorizontalOptions = LayoutOptions.Center;
            tableView.VerticalOptions = LayoutOptions.Start;


            TableRoot root = new TableRoot();
            TableSection section = new TableSection();

            section.Title = "";

            //section.Add(g.usernameEntry);
            //section.Add(g.passwordEntry);
            section.Add(g.rememberSwt);
            section.Add(g.savepassSwt);

            root.Add(section);
            tableView.Root = root;


            Image Img = new Image
            {
                WidthRequest = 100,
                HeightRequest = 100,
                HorizontalOptions = LayoutOptions.Center,
                VerticalOptions = LayoutOptions.Center,
                Source = ImageSource.FromFile("login1.png")

            };


            Label lbl = new Label();
            lbl.Text = "Please enter your POSDA account";
            lbl.TextColor = Color.Gray;
            lbl.HorizontalOptions = LayoutOptions.Center;
            lbl.VerticalOptions = LayoutOptions.Center;
            lbl.FontSize = 10;


            Button btn = new Button();
            btn.Text = "Sign In";
            btn.BackgroundColor = Color.Orange;
            btn.Clicked += OnLoginClicked;
            btn.HorizontalOptions = LayoutOptions.FillAndExpand;
            btn.VerticalOptions = LayoutOptions.Start;

            Button btnChangePass = new Button();
            btnChangePass.Text = "Change Password";
            btnChangePass.TextColor = Color.Silver;
            btnChangePass.BackgroundColor = Color.Transparent;
            btnChangePass.Clicked += OnbtnChangePassClicked;
            btnChangePass.HorizontalOptions = LayoutOptions.Center;
            btnChangePass.VerticalOptions = LayoutOptions.Start;


            lyt.Children.Add(Img);
            //lyt.Children.Add(g.lblUdid);
            lyt.Children.Add(lbl);
            lyt.Children.Add(g.usernameEntry);
            lyt.Children.Add(g.passwordEntry);
            lyt.Children.Add(g.custEntry);
            lyt.Children.Add(g.cpssEntry);
            lyt.Children.Add(tableView);
            lyt.Children.Add(btnChangePass);
            lyt.Children.Add(btn);

            return lyt;
        }

        void OnbtnChangePassClicked(object sender, EventArgs e)
        {
            ServiceManager sm = new ServiceManager();
            var m = new UserMethods();


            if (g.usernameEntry.Text == "" || g.passwordEntry.Text == "")
            {
                this.DisplayAlert("User Name Error", "Please Enter your POSDA account name", "OK");
            }
            else
            {
                g = m.dbCheckUser(g).Result;

                //var signResult = m.SignInOut(g, 0).Result;

                if (g.signIn)
                {
                    ChangePassPage cp = new ChangePassPage(g);

                    g.mdp.Detail.Navigation.PushAsync(cp);

                }
                //else
                //{
                //    await parentpage.DisplayAlert("Error", "Failed Sign In", "OK");

                //}


            }


        }

        async void OnLoginClicked(object sender, EventArgs e)
        {

            var m = new UserMethods();
            var mth = new Methodlar();
            SQLiteManager sqlm = new SQLiteManager();
            ContentPage p = new ContentPage();


            if (g.usernameEntry.Text == "" || g.usernameEntry.Text == null || g.passwordEntry.Text == "" || g.passwordEntry.Text == null)
            {
                await this.DisplayAlert("Info Error", "Please enter POSDA account or Password", "OK");

            }
            else
            {

                try
                {
                    p = mth.showProgress("Sign In POSDA...", this);

                    g.user.user = g.usernameEntry.Text;
                    g.user.pass = g.passwordEntry.Text;
                    g.user.cust = g.custEntry.Text;
                    g.user.cpss = g.cpssEntry.Text;
                    g.user.remember = g.rememberSwt.On;
                    g.user.save = g.savepassSwt.On;
                    if (g.user.udid == null) g.user.udid = "-1";

                    g = await m.SignIn(g);

                    //if (g.signIn)
                    //{
                    if (g.rememberSwt.On)
                    {
                        g.user.remember = true;

                        if (g.savepassSwt.On)
                        {
                            g.user.save = true;
                        }
                        else
                        {
                            g.user.save = false;
                            g.user.pass = null;
                            g.user.cpss = null;
                        }

                        sqlm.DeleteAll();
                        sqlm.Insert(g.user);
                    }
                    else
                    {
                        g.user.remember = false;
                        //g.user.user = null;
                        g.user.pass = null;
                        g.user.cust = null;
                        g.user.cpss = null;
                        g.user.remember = false;

                        if (g.savepassSwt.On)
                        {
                            g.user.save = true;
                        }
                        else g.user.save = false;

                        sqlm.DeleteAll();
                        sqlm.Insert(g.user);
                    };

                    //}
                    if (!g.signIn)
                    {
                        mth.hideProgress(p);
                        await this.DisplayAlert("Info Error", "SignIn Fail", "OK");
                    }
                    else
                    {

                        mth.hideProgress(p);



                        WelcomePage welcomep = new WelcomePage(g);


                        NavigationPage np = new NavigationPage(welcomep);

                        g.mdp.Detail = np;

                        //await g.mdp.Detail.Navigation.PushModalAsync(welcomep);

                        await Navigation.PopToRootAsync();

                        //mth.callPage(g, welcomep);
                    }

                }
                catch (Exception)
                {
                    mth.hideProgress(p);

                    throw;
                }
            }


        }




    }
}
