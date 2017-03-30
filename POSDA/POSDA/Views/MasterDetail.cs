using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using POSDA.GlobalVar;
using POSDA.Methods;

namespace POSDA.Views
{
    public class MasterDetail : MasterDetailPage 
    {
        public  MasterDetail()
        {

            var glb = new POSDA.GlobalVar.GlobalDegisken();
            var mth = new Methodlar();
            var um = new UserMethods();
            glb.mdp = this;
            glb.datePeriod = 2;
            glb.signIn = false;
            glb.checkDbUser = false;


            try
            {
                glb = um.dbCheckUser(glb).Result;

                if (glb.checkDbUser)
                {
                    if (glb.user.save)
                    {
                        glb = um.SignIn(glb).Result;

                        if (glb.signIn)
                        {


                        }
                        else
                        {
                            int i = um.SignOut(glb).Result;

                        }

                    }


                }
                else
                {

                }
            }
            catch (Exception)
            {

                throw;
            }
            finally
            {

                Master = new MenuPage(glb)
                {
                    Title = " ",
                    Padding = new Thickness(0, Device.OS == TargetPlatform.iOS ? 20 : 0, 0, 0),
                    BackgroundColor = Color.Aqua
                };
                WelcomePage wp = new WelcomePage(glb);
                glb.activep = wp;
                glb.prevp = null;
                Detail = new NavigationPage(wp)
                {
                    BarBackgroundColor = Color.Aqua,
                    BarTextColor = Color.Black,
                    Padding = new Thickness(5, Device.OS == TargetPlatform.iOS ? 20 : 0, 5, 5),
                };
                

            }


        }





    }
}
