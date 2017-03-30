using Newtonsoft.Json;
using POSDA.GlobalVar;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;


namespace POSDA.Methods
{

    public class ServiceManager
    {

        private string Url = "http://posda.peraport.net:55778/Service1.svc/";
        private async Task<HttpClient> GetClient()
        {

            HttpClient client = new HttpClient();
            client.DefaultRequestHeaders.Add("Accept", "application/json");

            return client;

        }

        public async Task<List<MyData>> AuthControl(string user, string pass, string id, string cust , string cpss)
        {
            List<MyData> sonuc;

            //try
            //{
                HttpClient client = await GetClient();

                var response = await client.GetStringAsync(Url + "AuthControl/" +
                     (cust == "" ? "-1" : cust) + "/" +
                     (cpss == "" ? "-1" : cpss) + "/" +
                     (user == "" ? "-1" : user) + "/" +
                     (pass == "" ? "-1" : pass) + "/" +
                     (id == "" ? "-1" : id));

                sonuc = JsonConvert.DeserializeObject<List<MyData>>(response.ToString());
            //}
            //catch (Exception)
            //{

            //    throw;
            //}
            //finally
            //{

                
            //}

            return sonuc;

        }
        public async Task<GlobalDegisken> signIn (GlobalDegisken g)
        {

            List<MyData> sonuc = await AuthControl(g.user.user, g.user.pass, g.user.udid,g.user.cust,g.user.cpss);

            if (sonuc[0].Val1.ToString() == "0")
            {
                g.signIn = true;
                g.user.sesid = sonuc[0].Val3.ToString();
            }
            else
            {
                if (sonuc[0].Val4 == null && g.user.udid != null)
                {
                    g.user.udid = null;

                }
                else
                {
                    g.user.udid = sonuc[0].Val4.ToString();

                }
                g.signIn = false;
            }

            return g;
        }

        public async Task<List<MyData>> MenuList(string sesid, string reportType)
        {
            HttpClient client = await GetClient();

            var response = await client.GetStringAsync(Url + "MenuList/" +
                 (sesid == "" ? "-1" : sesid) + "/" +
                 (reportType == "" ? "-1" : reportType) );

            List<MyData> sonuc = JsonConvert.DeserializeObject<List<MyData>>(response.ToString());

            return sonuc;
        }

        public async Task<List<MyData>> GetReport(string SesID, string MenuID, string RepPrm, string qType)
        {
            HttpClient client = await GetClient();
            List<MyData> sonuc = new List<MyData>();

            MyData bosdata = new MyData();
            bosdata.Val1 = "0"; bosdata.Val2 = "0"; bosdata.Val3 = "0"; bosdata.Val4 = "0"; bosdata.Val5 = "0"; bosdata.Val6 = "0"; bosdata.Val7 = "0"; bosdata.Val8 = "0";
            bosdata.Val9 = "0"; bosdata.Val10 = "0"; bosdata.Val11 = "0"; bosdata.Val12 = "0"; bosdata.Val13 = "0"; bosdata.Val14 = "0"; bosdata.Val15 = "0"; bosdata.Val16 = "0";
            bosdata.Val17 = "0"; bosdata.Val18 = "0"; bosdata.Val19 = "0"; bosdata.Val20 = "0";




            try
            {
                var response = await client.GetStringAsync(Url + "GetReport/" +
                (SesID == "" ? "-1" : SesID) + "/" +
                (MenuID == "" ? "-1" : MenuID) + "/" +
                (RepPrm == "" ? "-1" : RepPrm) + "/" +
                (qType == "" ? "-1" : qType)
                );

                sonuc = JsonConvert.DeserializeObject<List<MyData>>(response.ToString());
            }
            catch (Exception)
            {

                sonuc.Add(bosdata);

                //throw;
            }
            finally
            {


            }


            return sonuc;


        }
        public bool changePass(string user, string oldpass, string newpass)
        {
            bool result;

            if ( (user == "tolga") && (oldpass!=newpass) )   result = true;
            else result = false;

            return result;
        }
    }
}
