using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using POSDA.GlobalVar;
using Xamarin.Forms;
using POSDA.Views;

namespace POSDA.Methods
{
    public class UserMethods
    {
        GlobalDegisken g;
        public async Task<GlobalDegisken> dbCheckUser(GlobalDegisken glb)
        {
            g = glb;

            SQLiteManager sqlm = new SQLiteManager();

            g.user = sqlm.GetFirst();

            if (g.user != null)
            {
                if (g.user.remember)
                {
                    g.usernameEntry.Text = g.user.user;
                    g.custEntry.Text = g.user.cust;
                    g.rememberSwt.On = g.user.remember;
                    g.savepassSwt.On = g.user.save;

                    if (g.user.save)
                    {
                        g.passwordEntry.Text = g.user.pass;
                        g.cpssEntry.Text = g.user.cpss;
                    }
                    else
                    {
                        g.passwordEntry.Text = "";
                        g.cpssEntry.Text = "";

                    }

                    g.checkDbUser = true;

                }
                else
                {
                    g.usernameEntry.Text = "";
                    g.custEntry.Text = "";
                    g.rememberSwt.On = true;
                    g.savepassSwt.On = false;
                    g.passwordEntry.Text = "";
                    g.cpssEntry.Text = "";
                    g.checkDbUser = false;
                }

            }else
            {
                if (g.user == null)
                {
                    g.user = new posdaUser();
                }
            }

            return g;
        }


        public async Task<int> SignOut(GlobalDegisken glb)
        {

            g.user = null;
            g.usernameEntry.Text = "";
            g.passwordEntry.Text = "";
            g.custEntry.Text = "";
            g.cpssEntry.Text = "";
            g.rememberSwt.On = true;
            g.savepassSwt.On = false;
            g.signIn = false;
            g.mainButton.Text = "Start To Try!";
            g.btnLogin.Text = "SIGN IN";
            g.btnLogin.BackgroundColor = Color.Orange;
            g.loginImg.Source = ImageSource.FromFile("login2.jpg");
            g.user = null;

            //await Task.Delay(3000);
            return 1;

        }

        public async Task<GlobalDegisken> SignIn(GlobalDegisken glb)
        {
            g = glb;

            ServiceManager sm = new ServiceManager();
            var m = new Methodlar();

            g = await sm.signIn(g);


            if (g.signIn)
            {
                g = glb;
                //g.usernameEntry.Text = g.user.user;
                //g.passwordEntry.Text = g.user.pass;
                //g.custEntry.Text = g.user.cust;
                //g.cpssEntry.Text = g.user.cpss;
                //g.rememberSwt.On = g.user.remember;
                //g.savepassSwt.On = g.user.save;
                //g.signIn = true;
                g.mainButton.Text = "";
                g.btnLogin.Text = "SIGN OUT ( " + g.user.user + " )"; ;
                g.btnLogin.BackgroundColor = Color.Red;



            } else
            {

                g.mainButton.Text = "Start To tyr!";
                g.btnLogin.Text = "SIGN IN" ;
                g.btnLogin.BackgroundColor = Color.Orange;
            }


            return g;
        }


    }
}
