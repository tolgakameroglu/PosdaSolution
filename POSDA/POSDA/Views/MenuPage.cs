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
    public class MenuPage : ContentPage
    {
        GlobalDegisken g;

        public MenuPage(GlobalDegisken glb)
        {
            g = glb;
            g.menup = this;

            Content = menuLayout().Result;
        }

        public async Task<StackLayout> menuLayout()
        {
            var mth = new Methodlar();

            StackLayout layout = new StackLayout();
            layout.Padding = new Thickness(5, Device.OS == TargetPlatform.iOS ? 20 : 5, 5, 5);
            layout.BackgroundColor = Color.Black;
            layout.Spacing = 3;
            layout.VerticalOptions = LayoutOptions.Fill;
            layout.HorizontalOptions = LayoutOptions.Fill;

            g.btnLogin.Text = "SIGN IN";
            g.btnLogin.BackgroundColor = Color.Orange;
            g.loginImg.Source = ImageSource.FromFile("login2.jpg");

            g.btnLogin.Clicked += OnbtnLoginClicked;

            Button btnExit = new Button();
            btnExit.Text = "CLOSE";
            btnExit.Clicked += OnbtnExitClicked;
            btnExit.BackgroundColor = Color.Red;
            btnExit.HorizontalOptions = LayoutOptions.FillAndExpand;
            btnExit.VerticalOptions = LayoutOptions.End;

            StackLayout layoutMiddle = new StackLayout();
            layoutMiddle.HorizontalOptions = LayoutOptions.FillAndExpand;
            layoutMiddle.VerticalOptions = LayoutOptions.FillAndExpand;
            layoutMiddle.Children.Add(menuList());

            layout.Children.Add(g.loginImg);
            layout.Children.Add(g.btnLogin);
            layout.Children.Add(layoutMiddle);
            layout.Children.Add(btnExit);

            return layout;
        }
        void OnbtnExitClicked(object sender, EventArgs e)
        {
            //
        }

        async void OnbtnLoginClicked(object sender, EventArgs e)
        {
            var m = new UserMethods();
            
            if (g.signIn)
            {


                var s = await m.SignOut(g);

            }
            else
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
                    
                    await g.mdp.Detail.Navigation.PushAsync(loginp);
                }



            }
        }

        public TableView menuList()
        {

            TableView tableView = new TableView();
            tableView.Intent = TableIntent.Menu;
            tableView.BackgroundColor = Color.Black;
            tableView.RowHeight = 1;
            tableView.HasUnevenRows = true;


            TableRoot root = new TableRoot();
            TableSection section = new TableSection();


            section.Title = "";

            ImageCell cell1 = new ImageCell();
            cell1.Text = "ONLINE REPORTING";
            cell1.Detail = "Classic Posda";
            //cell1.ImageSource = ImageSource.FromFile("linearrow.png");
            cell1.TextColor = Color.White;
            cell1.DetailColor = Color.Gray;
            cell1.Height = 50;
            ImageCell cell2 = new ImageCell();
            cell2.Text = "LOCATION ANALYSIS";
            cell2.Detail = "Store, Mall Analysis";
            //cell2.ImageSource = ImageSource.FromFile("gauge2.png");
            cell2.TextColor = Color.White;
            cell2.DetailColor = Color.Gray;
            cell2.Height = 50;
            ImageCell cell3 = new ImageCell();
            cell3.Text = "PRODUCT REPORTS";
            cell3.Detail = "Segment and MainGroup Reports";
            //cell3.ImageSource = ImageSource.FromFile("bar.png");
            cell3.TextColor = Color.White;
            cell3.DetailColor = Color.Gray;
            cell3.Height = 50;
            ImageCell cell4 = new ImageCell();
            cell4.Text = "COMPARISON";
            cell4.Detail = "You and Others";
            //cell4.ImageSource = ImageSource.FromFile("list.png");
            cell4.TextColor = Color.White;
            cell4.DetailColor = Color.Gray;
            cell4.Height = 50;

            cell1.Tapped += Cell_Tapped;
            cell2.Tapped += Cell_Tapped;
            cell3.Tapped += Cell_Tapped;
            cell4.Tapped += Cell_Tapped;

            section.Add(cell1);
            section.Add(cell2);
            section.Add(cell3);
            section.Add(cell4);


            root.Add(section);

            tableView.Root = root;

            return tableView;
        }

        private async void Cell_Tapped(object sender, EventArgs e)
        {
            var mth = new Methodlar();
            ContentPage p = new ContentPage();

            if (g.signIn)
            {
                ImageCell cell = new ImageCell();
                cell = (ImageCell)sender;

                if (cell.Text == "ONLINE REPORTING")
                {
                    ServiceManager sm = new ServiceManager();
                    StackLayout lyt = new StackLayout();
                    lyt.BackgroundColor = Color.White;


                    p = mth.showProgress("Get Report List...", this);
                    try
                    {
                        List<MyData> sonuc = await sm.MenuList(g.user.sesid, "menu");

                        lyt = await mth.orMenuList(sonuc);
                    }
                    catch (Exception)
                    {
                        mth.hideProgress(p);

                        throw;
                    }
                    finally
                    {
                        mth.hideProgress(p);

                        DashPage dsh = new DashPage(g, lyt, cell.Text);

                        await this.Navigation.PushModalAsync(dsh);

                        

                    }

                }

            }
            else
            {
                await this.DisplayAlert("Fail", "Sign in failed", "OK");

            }


        }



    }
}
