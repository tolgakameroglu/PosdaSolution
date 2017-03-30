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
    class ChangePassPage : ContentPage
    {
        public ChangePassPage(GlobalDegisken glb)
        {
            var mth = new Methodlar();

            Content = mth.changePassView(glb, this);
        }
    }
}
