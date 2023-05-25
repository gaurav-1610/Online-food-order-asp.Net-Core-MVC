using FoodOrder.Models;
using Microsoft.AspNetCore.Mvc;
using FoodOrder.DAL;
using System.Data;
using System.Configuration;
using FoodOrder.BAL;

namespace FoodOrder.Controllers
{
    
    public class SEC_UserController : Controller
    {
        private IConfiguration Configuration;
        
        public SEC_UserController(IConfiguration _configuration)
        {
            Configuration = _configuration;
        }

        public IActionResult Index()
        {
            //return View("Login");
            return RedirectToAction("Index", "Food", new { area = "Food" });
        }
        public IActionResult LoginView()
        {
            return View("Registration");
        }
        public IActionResult LoginFood()
        {
            return View("RegistrationFood");
        }
        public IActionResult UserLogin()
        {
            return View("Login");
        }
        public IActionResult UserLoginFood()
        {
            return View("LoginFood");
        }

        [HttpPost]
        public IActionResult Login(SEC_UserModel modelSEC_User)
        {
            string connstr = this.Configuration.GetConnectionString("MyConnetionString");
            string error = null;

            SEC_DAL dal_reg = new SEC_DAL();
            DataTable dt_reg = dal_reg.PR_REG_Registration_Insert(connstr, modelSEC_User);

            if (modelSEC_User.UserName == null)
            {
                error += "User Name is required";
            }
            if (modelSEC_User.Password == null)
            {
                error += "<br/>Password is required";
            }

            if (error != null)
            {
                TempData["Error"] = error;
                return RedirectToAction("Index");
            }
            else
            {
                SEC_DAL dal = new SEC_DAL();
                DataTable dt = dal.PR_REG_Registration_SelectBy_UserName_Password(connstr, modelSEC_User);
                if (dt.Rows.Count > 0)
                {
                    foreach (DataRow dr in dt.Rows)
                    {
                        HttpContext.Session.SetString("UserName", dr["UserName"].ToString());
                        HttpContext.Session.SetString("UserID", dr["UserID"].ToString());
                        HttpContext.Session.SetString("Password", dr["Password"].ToString());
                        HttpContext.Session.SetString("isAdmin", dr["isAdmin"].ToString());
                        break;
                    }
                }
                else
                {
                    TempData["Error"] = "User Name or Password is invalid!";
                    return RedirectToAction("UserLogin");
                }
                if (HttpContext.Session.GetString("UserName") != null && HttpContext.Session.GetString("Password") != null)
                {
                    return RedirectToAction("Index", "Home" , modelSEC_User);
                }
            }
            return RedirectToAction("Index");
        }



        [HttpPost]
        public IActionResult LoginFood(SEC_UserModel modelSEC_User)
        {
            string connstr = this.Configuration.GetConnectionString("MyConnetionString");
            string error = null;

            if (modelSEC_User.UserName == null)
            {
                error += "User Name is required";
            }
            if (modelSEC_User.Password == null)
            {
                error += "<br/>Password is required";
            }

            if (error != null)
            {
                TempData["Error"] = error;
                return RedirectToAction("Index");
            }
            else
            {
                SEC_DAL dal = new SEC_DAL();
                DataTable dt = dal.PR_REG_Registration_SelectBy_UserName_Password(connstr, modelSEC_User);
                if (dt.Rows.Count > 0)
                {
                    foreach (DataRow dr in dt.Rows)
                    {
                        HttpContext.Session.SetString("UserName", dr["UserName"].ToString());
                        HttpContext.Session.SetString("UserID", dr["UserID"].ToString());
                        HttpContext.Session.SetString("Password", dr["Password"].ToString());
                        HttpContext.Session.SetString("isAdmin", dr["isAdmin"].ToString());
                        break;
                    }
                }
                else
                {
                    TempData["Error"] = "User Name or Password is invalid!";
                    return RedirectToAction("UserLoginFood");
                }
                if (HttpContext.Session.GetString("UserName") != null && HttpContext.Session.GetString("Password") != null)
                {
                    return RedirectToAction("Index_food", "Home", modelSEC_User);
                }
            }
            return RedirectToAction("Index");
        }

        public IActionResult Logout()
        {
            HttpContext.Session.Clear();
            return RedirectToAction("Index");
        }
    }
}
