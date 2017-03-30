using SQLite.Net.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using Xamarin.Forms.Internals;

namespace POSDA.GlobalVar
{
    
    public class posdaUser
    {
        [PrimaryKey]
        public string user { get; set; }
        public string pass { get; set; }
        public string cust { get; set; }
        public string cpss { get; set; }
        public bool remember { get; set; }
        public bool save { get; set; }
        public string udid { get; set; }
        public string sesid { get; set; }
    }

    public class MyData
    {
        public string Val1 { get; set; }
        public string Val2 { get; set; }
        public string Val3 { get; set; }
        public string Val4 { get; set; }
        public string Val5 { get; set; }
        public string Val6 { get; set; }
        public string Val7 { get; set; }
        public string Val8 { get; set; }
        public string Val9 { get; set; }
        public string Val10 { get; set; }
        public string Val11 { get; set; }
        public string Val12 { get; set; }
        public string Val13 { get; set; }
        public string Val14 { get; set; }
        public string Val15 { get; set; }
        public string Val16 { get; set; }
        public string Val17 { get; set; }
        public string Val18 { get; set; }
        public string Val19 { get; set; }
        public string Val20 { get; set; }


    }
    public class GlobalDegisken
    {
        public static string localDbName { get; set; } = "posdaDb.db3";

        public Entry usernameEntry = new Entry { Placeholder = "user" , VerticalOptions=LayoutOptions.Center, HeightRequest = 30, FontSize = 14};

        public Entry passwordEntry = new Entry { Placeholder = "pass", VerticalOptions = LayoutOptions.Center, IsPassword=true, HeightRequest = 30, FontSize = 14 };

        public Entry custEntry = new Entry { Placeholder = "company code", VerticalOptions = LayoutOptions.Center, HeightRequest = 30, FontSize = 14 };

        public Entry cpssEntry = new Entry { Placeholder = "company pass", VerticalOptions = LayoutOptions.Center, IsPassword = true, HeightRequest = 30, FontSize = 14 };

        public Entry oldpassEntry = new Entry
        {
            Placeholder = "Old Pass",
            IsPassword = true,
            HorizontalOptions = LayoutOptions.FillAndExpand,
            VerticalOptions = LayoutOptions.Center
        };

        public Entry newpassEntry = new Entry
        {
            Placeholder = "New Pass",
            IsPassword = true,
            HorizontalOptions = LayoutOptions.FillAndExpand,
            VerticalOptions = LayoutOptions.Center
        };

        public Entry renewpassEntry = new Entry
        {
            Placeholder = "Re- Pass",
            IsPassword = true,
            HorizontalOptions = LayoutOptions.FillAndExpand,
            VerticalOptions = LayoutOptions.Center
        };

        public Button btnLogin = new Button
        {
            Text = "",
            HorizontalOptions = LayoutOptions.FillAndExpand,
            VerticalOptions = LayoutOptions.Start
        };

        public Image loginImg = new Image
        {
            WidthRequest = 50,
            HeightRequest = 50,
            HorizontalOptions = LayoutOptions.Start,
            VerticalOptions = LayoutOptions.Start

        };

        public SwitchCell rememberSwt = new SwitchCell {Text="Remember me", On = true     };
        public SwitchCell savepassSwt = new SwitchCell {Text="Save Password",On = false     };
        public Label lblUdid = new Label { Text = "udid" , HorizontalOptions = LayoutOptions.Center, VerticalOptions = LayoutOptions.Center};

        public Button mainButton = new Button
        {
            Text = "",
            BackgroundColor = Color.Orange,
        };



        public int datePeriod { get; set; }
        public bool signIn { get; set; }
        public bool checkDbUser { get; set; }
        public posdaUser user { get; set; }
        public ContentPage activep { get; set; }
        public ContentPage menup { get; set; }
        public ContentPage prevp { get; set; }
        public MasterDetailPage mdp { get; set; }

        public Color backColor { get { return Color.White; } set { } }

        public Color backColorMenu { get { return Color.Black; }  set { } }

 
    }

}
