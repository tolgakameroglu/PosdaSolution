using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace POSDA.Views
{
    class Progress :ContentPage
    {
        public Progress(string msg)
        {

            StackLayout lyt1 = new StackLayout() {
                BackgroundColor = Color.Transparent, Opacity = 0.5 ,
                BindingContext = this, HorizontalOptions = LayoutOptions.Center, VerticalOptions = LayoutOptions.Center };
            lyt1.SetBinding(StackLayout.IsVisibleProperty, "IsBusy");
            ActivityIndicator ac = new ActivityIndicator() { BindingContext = this, Color = Color.Black };
            ac.SetBinding(ActivityIndicator.IsRunningProperty, "IsBusy");

            Label lbl = new Label();
            lbl.Text = msg;
            lbl.TextColor = Color.Black;
            lbl.HorizontalOptions = LayoutOptions.Center;
            lbl.VerticalOptions = LayoutOptions.Center;

            lyt1.Children.Add(lbl);

            lyt1.Children.Add(ac);

            Content = lyt1;
        }
    }
}
