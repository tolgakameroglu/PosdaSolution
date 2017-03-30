using POSDA.GlobalVar;
using SQLite.Net;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace POSDA.Methods
{
    public class SQLiteManager
    {
        SQLiteConnection _sqlconneciton;

        public SQLiteManager()
        {
            _sqlconneciton = DependencyService.Get<ISQLiteConnection>().GetConnection();
            _sqlconneciton.CreateTable<posdaUser>();
        }

        #region CRUD

        public int Insert(posdaUser s)
        {

            return _sqlconneciton.Insert(s);
        }

        public int Update(posdaUser s)
        {

            return _sqlconneciton.Update(s);
        }

        public int Delete(string user)
        {

            return _sqlconneciton.Delete<posdaUser>(user);
        }

        public int DeleteAll()
        {

            _sqlconneciton.DropTable<posdaUser>();

            return _sqlconneciton.CreateTable<posdaUser>();
        }

        public List<posdaUser> GetAll()
        {

            return _sqlconneciton.Table<posdaUser>().ToList();
        }

        public posdaUser Get(string user)
        {

            return _sqlconneciton.Table<posdaUser>().FirstOrDefault(x => x.user == user);
        }

        public int CheckUser(string user)
        {

            posdaUser usr = _sqlconneciton.Table<posdaUser>().FirstOrDefault(x => x.user == user);

            if (usr.user.ToString() != "") return 1; else return 0;
        }
        public posdaUser GetFirst()
        {

            return  _sqlconneciton.Table<posdaUser>().FirstOrDefault();
        }

        public void Dispose()
        {
            _sqlconneciton.Dispose();

        }
        #endregion
    }
}
