using FoodOrder.BAL;
using FoodOrder.DAL;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Practices.EnterpriseLibrary.Data.Sql;
using System.Data.Common;
using System.Data;

namespace FoodOrder.Areas.Menu.Controllers
{
    /*[CheckAccess]*/
    [Area("Menu")]
    [Route("Menu/[controller]/[action]")]
    public class MenuController : Controller
    {
        private IConfiguration Configuration;
        public MenuController(IConfiguration _configuration)
        {
            Configuration = _configuration;
        }
        #region MenuList Client
        public IActionResult Index()
        {
            string str = this.Configuration.GetConnectionString("MyConnetionString");
            FF_FOOD dalFF = new FF_FOOD();

            SqlDatabase sqlDB = new SqlDatabase(str);
            DbCommand dbCMD = sqlDB.GetStoredProcCommand("PR_FF_Food_SelectAll");
            DataTable dt = dalFF.PR_FF_Food_SelectAll(str);
            return View("MenuList", dt);
        }
        #endregion

        #region MenuList Admin
        public IActionResult MenuListAdmin()
        {
            string str = this.Configuration.GetConnectionString("MyConnetionString");
            FF_FOOD dalFF = new FF_FOOD();

            SqlDatabase sqlDB = new SqlDatabase(str);
            DbCommand dbCMD = sqlDB.GetStoredProcCommand("PR_FF_Food_SelectAll");
            DataTable dt = dalFF.PR_FF_Food_SelectAll(str);
            return View("MenuListAdmin", dt);
        }
        #endregion
    }
}
