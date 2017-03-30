using OxyPlot;
using OxyPlot.Series;
using OxyPlot.Xamarin.Forms;
using POSDA.GlobalVar;
using POSDA.Views;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Forms;
using Xamarin.Forms.Internals;


namespace POSDA.Methods
{
    class Methodlar
    {
        ContentPage parentpage;
        GlobalDegisken g;




        public async Task<StackLayout> dsh_Text(string text)
        {


            Label lbl = new Label();
            lbl.Text = text;
            lbl.FontSize = Device.GetNamedSize(NamedSize.Small, typeof(Label));
            lbl.FontAttributes = FontAttributes.Bold;
            lbl.BackgroundColor = Color.White;
            lbl.TextColor = Color.Black;
            lbl.VerticalOptions = LayoutOptions.Center;
            lbl.HorizontalOptions = LayoutOptions.Center;
            //lbl.HeightRequest = 20;

            StackLayout lyt = new StackLayout();
            lyt.Spacing = 0;
            //lyt.HeightRequest = yukseklik ;
            lyt.BackgroundColor = Color.White;
            lyt.Children.Add(lbl);

            var tapGestureRecognizer = new TapGestureRecognizer();
            tapGestureRecognizer.Tapped += (s, e) => {
                Device.OpenUri(new Uri(lbl.Text));
            };
            lbl.GestureRecognizers.Add(tapGestureRecognizer);

            return lyt;
        }
        public async Task<StackLayout> dsh_Label(string baslik, string altbaslik, string icerik, string id)
        {
            Label lbl_id = new Label();
            lbl_id.Text = id;
            lbl_id.IsVisible = false;
            
            Label lbl = new Label();
            lbl.Text = baslik;
            lbl.FontSize = Device.GetNamedSize(NamedSize.Small, typeof(Label));
            lbl.FontAttributes = FontAttributes.Bold;
            lbl.BackgroundColor = Color.White;
            lbl.TextColor = Color.Black;
            //lbl.HeightRequest = 20;

            Label lbl2 = new Label();
            lbl2.Text = altbaslik;
            lbl2.FontSize = Device.GetNamedSize(NamedSize.Micro, typeof(Label));
            lbl2.FontAttributes = FontAttributes.Italic;
            lbl2.BackgroundColor = Color.White;
            lbl2.TextColor = Color.Gray;
            //lbl2.HeightRequest = 15;

            Label lbl1 = new Label();
            lbl1.Text = icerik;
            lbl1.HorizontalTextAlignment = TextAlignment.Center;
            lbl1.VerticalTextAlignment = TextAlignment.Center;
            lbl1.FontSize = Device.GetNamedSize(NamedSize.Large, typeof(Label));
            lbl1.FontAttributes = FontAttributes.Bold;
            lbl1.BackgroundColor = Color.White;
            lbl1.TextColor = Color.Black;
            //lbl1.HeightRequest = yukseklik;
            lbl1.VerticalOptions = LayoutOptions.Center;
            lbl1.HorizontalOptions = LayoutOptions.Center;

            StackLayout lyt = new StackLayout();
            lyt.Spacing = 0;
            //lyt.HeightRequest = yukseklik+40;
            lyt.BackgroundColor = Color.White;
            lyt.Children.Add(lbl_id);
            lyt.Children.Add(lbl);
            lyt.Children.Add(lbl2);
            lyt.Children.Add(lbl1);
            //lyt.HorizontalOptions = LayoutOptions.Center;
            //lyt.VerticalOptions = LayoutOptions.Center;





            return lyt;
        }
        public async Task<StackLayout> dsh_Line(string baslik, string altbaslik )
        {

            PlotView opv = new PlotView();

            opv = createOpv();

            Label lbl = new Label();
            lbl.Text = baslik;
            lbl.FontSize = Device.GetNamedSize(NamedSize.Small, typeof(Label));
            lbl.FontAttributes = FontAttributes.Bold;
            lbl.BackgroundColor = Color.White;
            lbl.TextColor = Color.Black;
            //lbl.HeightRequest = 20;

            Label lbl2 = new Label();
            lbl2.Text = altbaslik;
            lbl2.FontSize = Device.GetNamedSize(NamedSize.Micro, typeof(Label));
            lbl2.FontAttributes = FontAttributes.Italic;
            lbl2.BackgroundColor = Color.White;
            lbl2.TextColor = Color.Gray;
            //lbl2.HeightRequest = 15;

            StackLayout lyt = new StackLayout();
            lyt.Spacing = 0;
            //lyt.HeightRequest = yukseklik +40;

            lyt.Children.Add(lbl);
            lyt.Children.Add(lbl2);
            lyt.Children.Add(opv);

            return lyt;
        }

        public PlotView createOpv()
        {
            var Points1 = new List<DataPoint>
            {
            new DataPoint(0, 4),
            new DataPoint(10, 13),
            new DataPoint(20, 15),
            new DataPoint(30, 16),
            new DataPoint(40, 12),
            new DataPoint(50, 12),
            new DataPoint(60, 4),
            new DataPoint(70, 13),
            new DataPoint(80, 15),
            new DataPoint(90, 16),
            new DataPoint(100, 12),
            new DataPoint(110, 12)
            };
            var Points2 = new List<DataPoint>
            {
            new DataPoint(0, 3),
            new DataPoint(10, 20),
            new DataPoint(20, 18),
            new DataPoint(30, 16),
            new DataPoint(40, 10),
            new DataPoint(50, 8)
            };

            var m = new PlotModel { Title = "" };
            m.PlotType = PlotType.XY;

            var s = new LineSeries();
            s.ItemsSource = Points1;
            var s1 = new LineSeries();
            s1.ItemsSource = Points2;

            s.Color = OxyColors.Blue;
            s1.Color = OxyColors.Red;


            m.Series.Add(s);
            m.Series.Add(s1);

            //m.TouchStarted += OnButtonClicked;

            var opv = new PlotView
            {
                HorizontalOptions = LayoutOptions.FillAndExpand,
                VerticalOptions = LayoutOptions.FillAndExpand,
                //WidthRequest = 100,
                //HeightRequest = 500,
                BackgroundColor = Color.White
            };
            opv.Model = m;

            return opv;

        }
        public StackLayout changePassView(GlobalDegisken glb, ContentPage p)
        {
            g = glb;
            parentpage = p;


            StackLayout lyt = new StackLayout();
            lyt.Padding = new Thickness(5, 30, 5, 5);
            lyt.Spacing = 3;
            lyt.BackgroundColor = Color.White;

            Label lbl = new Label();
            lbl.Text = g.usernameEntry.Text;
            lbl.HorizontalOptions = LayoutOptions.Center;
            lbl.VerticalOptions = LayoutOptions.Center;

            Button btn = new Button();
            btn.Text = "Change Password";
            btn.BackgroundColor = Color.Orange;
            btn.Clicked += OnChangePasswordClicked;
            btn.HorizontalOptions = LayoutOptions.FillAndExpand;
            btn.VerticalOptions = LayoutOptions.End;


            Image loginImg = new Image();
            loginImg.WidthRequest = 100;
            loginImg.HeightRequest = 100;
            loginImg.HorizontalOptions = LayoutOptions.Center;
            loginImg.VerticalOptions = LayoutOptions.Center;
            loginImg.Source = ImageSource.FromFile("lock.png");

            lyt.Children.Add(loginImg);
            lyt.Children.Add(lbl);
            lyt.Children.Add(g.oldpassEntry);
            lyt.Children.Add(g.newpassEntry);
            lyt.Children.Add(g.renewpassEntry);
            lyt.Children.Add(btn);
            return lyt;
        }

        void OnChangePasswordClicked(object sender, EventArgs e)
        {
            if (g.newpassEntry.Text != g.renewpassEntry.Text)
            {
                parentpage.DisplayAlert("Password Error", "Different new pass and re- pass", "OK");

            }
            else
            {
                if (g.newpassEntry.Text == g.oldpassEntry.Text)
                {
                    parentpage.DisplayAlert("Password Error", "New pass cannot be same as old pass ", "OK");

                }
                else
                {
                    ServiceManager sm = new ServiceManager();

                    try
                    {
                        if (sm.changePass(g.usernameEntry.Text, g.oldpassEntry.Text, g.newpassEntry.Text))
                        {
                            callPage(g, g.activep);
                            g.activep.DisplayAlert("Success", "Change Password ", "OK");
                            

                        }
                        else
                        {
                            parentpage.DisplayAlert("Fail", "Change Password failed", "OK");

                        }
                    }
                    catch (Exception)
                    {

                        throw;
                    }



                }

            }
        }



        public TableView mainList(ContentPage p, GlobalDegisken glb)
        {
            parentpage = p;
            g = glb;

            TableView tableView = new TableView();
            tableView.Intent = TableIntent.Menu;
            tableView.BackgroundColor = Color.White;
            tableView.RowHeight = 1;
            tableView.HasUnevenRows = true;


            TableRoot root = new TableRoot();
            TableSection section = new TableSection();


            section.Title = "";

            ImageCell cell1 = new ImageCell();
            cell1.Text = "ONLINE REPORTING";
            cell1.Detail = "Classic Posda";
            cell1.ImageSource = ImageSource.FromFile("linearrow.png");
            cell1.TextColor = Color.Black;
            cell1.DetailColor = Color.Default;
            cell1.Height = 80;
            ImageCell cell2 = new ImageCell();
            cell2.Text = "LOCATION ANALYSIS";
            cell2.Detail = "Store, Mall Analysis";
            cell2.ImageSource = ImageSource.FromFile("gauge2.png");
            cell2.TextColor = Color.Black;
            cell2.DetailColor = Color.Default;
            cell2.Height = 80;
            ImageCell cell3 = new ImageCell();
            cell3.Text = "PRODUCT REPORTS";
            cell3.Detail = "Segment and MainGroup Reports";
            cell3.ImageSource = ImageSource.FromFile("bar.png");
            cell3.TextColor = Color.Black;
            cell3.DetailColor = Color.Default;
            cell3.Height = 80;
            ImageCell cell4 = new ImageCell();
            cell4.Text = "COMPARISON";
            cell4.Detail = "You and Others";
            cell4.ImageSource = ImageSource.FromFile("list.png");
            cell4.TextColor = Color.Black;
            cell4.DetailColor = Color.Default;
            cell4.Height = 80;

            //cell1.Tapped += mainCell_Tapped;
            //cell2.Tapped += mainCell_Tapped;
            //cell3.Tapped += mainCell_Tapped;
            //cell4.Tapped += mainCell_Tapped;

            TextCell text1 = new TextCell();
            text1.Text = "Online Reporting";
            text1.TextColor = Color.Gray;
            text1.Height = 25;
            TextCell text2 = new TextCell();
            text2.Text = "Analysis";
            text2.TextColor = Color.Gray;
            text2.Height = 25;


            section.Add(text1);
            section.Add(cell1);
            section.Add(text2);
            section.Add(cell2);
            section.Add(cell3);
            section.Add(cell4);


            root.Add(section);

            tableView.Root = root;

            return tableView;
        }



        public async Task<StackLayout> orMenuList(List<MyData> myData)
        {
            StackLayout lyt = new StackLayout();
            TableView tableView = new TableView();
            tableView.Intent = TableIntent.Menu;
            tableView.BackgroundColor = Color.White;
            tableView.RowHeight = 1;
            tableView.HasUnevenRows = true;
            TableRoot root = new TableRoot();
            TableSection section = new TableSection();
            section.Title = "";

            foreach (MyData my in myData)
            {
                
                ImageCell cell = new ImageCell();
                cell.Text = my.Val2;
                cell.Detail = my.Val1;
                cell.ImageSource = ImageSource.FromFile("x"+my.Val1+"x.png");
                cell.TextColor = Color.Black;
                cell.DetailColor = Color.White; //rapor numarası görünmesin ekranda.
                cell.Height = 80;
                cell.Tapped += orMenuList_Tapped;

                section.Add(cell);
            }



            root.Add(section);

            tableView.Root = root;

            lyt.Children.Add(tableView);
            return lyt;
        }

        private async void orMenuList_Tapped(object sender, EventArgs e)
        {
            ImageCell img = new ImageCell();
            img = (ImageCell)sender;
            //03101201631012016
            getReport(g.user.sesid, img.Detail,"0", g.datePeriod.ToString(),img.Text);



        }

        public async Task<StackLayout> orReportData(List<MyData> myData)
        {
            StackLayout lyt = new StackLayout();
            //TableView tableView = new TableView();
            //tableView.Intent = TableIntent.Data;
            //tableView.BackgroundColor = Color.White;
            //tableView.RowHeight = 1;
            //tableView.HasUnevenRows = true;
            //TableRoot root = new TableRoot();
            //TableSection section = new TableSection();
            //section.Title = "";

            //foreach (MyData my in myData)
            //{

            //    ImageCell cell = new ImageCell();
            //    cell.Text = my.Val2;
            //    cell.Detail = my.Val1;
            //    //cell.ImageSource = ImageSource.FromFile("linearrow.png");
            //    cell.TextColor = Color.Black;
            //    cell.DetailColor = Color.Default;
            //    cell.Height = 80;
            //    cell.Tapped += orReportData_Tapped;

            //    section.Add(cell);
            //}



            //root.Add(section);

            //tableView.Root = root;

            //lyt.Children.Add(tableView);
            return lyt;
        }

        public async Task<StackLayout> orReportDataGrid(List<MyData> myData, string MenuId)
        {
            StackLayout lyt = new StackLayout();

            var tapGestureRecognizer = new TapGestureRecognizer();
            tapGestureRecognizer.Tapped += (s, e) => {

                StackLayout gc = (StackLayout)s;
                Label lbl_id = (Label)gc.Children[0];
                Label lbl = (Label)gc.Children[1];
                if (lbl.Text == "" )
                {


                }else
                {
                    if (MenuId.Length == 3)
                    {
                        getReport(g.user.sesid, lbl_id.Text + "9", lbl.Text, g.datePeriod.ToString(), lbl.Text);
                    }
                    else
                    {
                        
                    }

                    

                }
            };

            Grid grid = new Grid
            {
                VerticalOptions = LayoutOptions.FillAndExpand,
                HorizontalOptions = LayoutOptions.FillAndExpand,
                ColumnSpacing = 10,
                RowSpacing = 10,
                RowDefinitions =
                {
                    new RowDefinition { Height = 75 }
                },
                ColumnDefinitions =
                {
                    new ColumnDefinition { Width = GridLength.Star },
                    new ColumnDefinition { Width = GridLength.Star },
                }
            };

            StackLayout lyt_lb = new StackLayout();

            if (MenuId.Length== 3)
            {
                lyt_lb.GestureRecognizers.Add(tapGestureRecognizer);
            }
            else
            {
                lyt_lb.GestureRecognizers.Clear();
            }
            
            lyt_lb = await dsh_Label(myData[myData.Count() - 1].Val1, myData[myData.Count() - 1].Val1, myData[myData.Count() - 1].Val2, "");
        
            grid.Children.Add(lyt_lb, 0, 2, 0, 1);

            var grid_rc = (int)Math.Round( ((double)myData.Count()+0.0001) / 2 , 0);
             

            for (int i = 1; i <= grid_rc; i++)
            {
                grid.RowDefinitions.Add(new RowDefinition { Height = 75 });
            }

            for (int i = 1; i < myData.Count()-1; i++)
            {
                int j = (int)Math.Round((i + 0.0001) / 2, 0);

                lyt_lb = await dsh_Label(myData[i].Val1, myData[i].Val1, myData[i].Val2, MenuId);
                //lyt_lb.GestureRecognizers.Add(tapGestureRecognizer);

                if ( (i % 2) !=0)
                {
                    grid.Children.Add(lyt_lb, 0, 1, j , j + 1);
                } else
                {
                    grid.Children.Add(lyt_lb, 1, 2, j, j + 1);
                }

                
            }
            for (int i = 0; i < grid.Children.Count(); i++)
            {
                grid.Children[i].GestureRecognizers.Add(tapGestureRecognizer);
            }

            lyt.Children.Add(grid);

            
            
            

            return lyt;

        }

        private async void orReportData_Tapped(object sender, EventArgs e)
        {
            //ImageCell img = new ImageCell();
            //img = (ImageCell)sender;

            //getReport(g.user.sesid,"1069", img.Detail, "03101201631012016",img.Text);



        }
        public async void getReport(string SesID, string MenuID, string RepPrm, string qType, string MenuName)
        {
            ServiceManager sm = new ServiceManager();
            StackLayout lyt = new StackLayout();
            lyt.BackgroundColor = Color.White;
            ContentPage p = new ContentPage();

            p = showProgress("Get Report Data...",g.activep);
            try
            {
                List<MyData> sonuc = await sm.GetReport(SesID, MenuID, RepPrm, qType);

                lyt = await orReportDataGrid(sonuc,MenuID);
            }
            catch (Exception)
            {

                throw;
            }
            finally
            {
                DashPage dsh = new DashPage(g, lyt, MenuName);

                callPage(g, dsh);

                hideProgress(p);

            }

        }

        public void callPage(GlobalDegisken glb, ContentPage page)
        {
            g = glb;
            g.prevp = g.activep;

            if (g.mdp.IsPresented) glb.mdp.IsPresented = false;

            g.activep.Navigation.PushAsync(page);

            g.activep = page;

        }
        public ListView mainListT()
        {
            List<ViewCell> reportList = new List<ViewCell>();

            ListView listView = new ListView();
            DataTemplate dataTemplate = new DataTemplate(typeof(ImageCell));
            listView.ItemTemplate = dataTemplate;

            ImageCell cell1 = new ImageCell();
            cell1.Text = "ONLINE REPORTING";
            cell1.Detail = "Classic Posda";
            cell1.ImageSource = ImageSource.FromFile("linearrow.png");
            cell1.TextColor = Color.Black;
            cell1.DetailColor = Color.Default;
            cell1.Height = 100;
            ImageCell cell2 = new ImageCell();
            cell2.Text = "LOCATION ANALYSIS";
            cell2.Detail = "Store, Mall Analysis";
            cell2.ImageSource = ImageSource.FromFile("gauge2.png");
            cell2.TextColor = Color.Black;
            cell2.DetailColor = Color.Default;
            cell2.Height = 100;

            //reportList.Add();



            listView.ItemsSource = reportList;

            return listView;
        }

        public ContentPage showProgress(string msg,ContentPage act )
        {
            Progress p = new Progress(msg)
            {
                IsBusy = true,
                BackgroundColor = Color.Transparent,
                Opacity = 0.5
            };
            act.Navigation.PushModalAsync(p);

            return p;
        }

        public void hideProgress(ContentPage p)
        {
            if (p != null)
                p.Navigation.PopModalAsync();
            p.IsBusy = false;
        }




    }
}
