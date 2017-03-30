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
    
    class DashPage : ContentPage
    {
        GlobalDegisken g;
        public DashPage(GlobalDegisken glb, StackLayout layout, string title)
        {
            Title = title;



            g = glb;

            ScrollView scroll = new ScrollView();
            //scroll.BackgroundColor = Color.White;
            scroll.Content = layout;

            if (title == "ONLINE REPORTING")
            {
                this.ToolbarItems.Add(new ToolbarItem { Text = "Dun" , Order = ToolbarItemOrder.Secondary  });
                this.ToolbarItems.Add(new ToolbarItem { Text = "Guncel", Order = ToolbarItemOrder.Secondary });
                this.ToolbarItems.Add(new ToolbarItem { Text = "Gecen Hafta", Order = ToolbarItemOrder.Secondary });
                this.ToolbarItems.Add(new ToolbarItem { Text = "Hafta", Order = ToolbarItemOrder.Secondary });
                this.ToolbarItems.Add(new ToolbarItem { Text = "Gecen Ay", Order = ToolbarItemOrder.Secondary });
                this.ToolbarItems.Add(new ToolbarItem { Text = "Ay", Order = ToolbarItemOrder.Secondary });


                foreach (ToolbarItem my in this.ToolbarItems)
                {

                    my.Activated += onActivateTb ;

                }

            }
                
            else this.ToolbarItems.Clear();


            Content = scroll;
        }

        private void onActivateTb(object sender, EventArgs e)
        {
            ToolbarItem tb = (ToolbarItem)sender;

            if (tb.Text == "Dun") g.datePeriod = 1;
            else if (tb.Text == "Guncel") g.datePeriod = 2;
            else if (tb.Text == "Gecen Hafta") g.datePeriod = 3;
            else if (tb.Text == "Hafta") g.datePeriod = 4;
            else if (tb.Text == "Gecen Ay") g.datePeriod = 5;
            else if (tb.Text == "Ay") g.datePeriod = 6;

        }




    }
}
