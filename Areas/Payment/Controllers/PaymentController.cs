using FoodOrder.Areas.Food.Models;
using FoodOrder.Areas.Payment.Models;
using FoodOrder.BAL;
using FoodOrder.DAL;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Practices.EnterpriseLibrary.Data.Sql;
using System.Data;
using System.Data.Common;


namespace FoodOrder.Areas.Payment.Controllers
{
    [CheckAccess]
    [Area("Payment")]
    [Route("Payment/[controller]/[action]")]
    public class PaymentController : Controller
    {
        private IConfiguration Configuration;
        public PaymentController(IConfiguration _configuration)
        {
            Configuration = _configuration;
        }

        #region PaymentSelectAll
        public IActionResult Index()
        {   
            return View("PaymentList");
        }
        #endregion

        #region PaymentSelectAll
        public IActionResult FoodView()
        {
            return RedirectToAction("Index", "Food", new { area = "Food" });
        }
        #endregion

        #region PaymentListAdmin
        public IActionResult PaymentListAdmin()
        {
            return View("PaymentListAdmin");
        }
        #endregion 

        #region Order SelectAll
        public IActionResult OrderSelectAll()
        {
            string str = this.Configuration.GetConnectionString("MyConnetionString");
            FF_FOOD dalFF = new FF_FOOD();

            SqlDatabase sqlDB = new SqlDatabase(str);
            DbCommand dbCMD = sqlDB.GetStoredProcCommand("PR_Order_SelectAll");
            DataTable dt = dalFF.PR_Order_SelectAll(str);
            return View("OrderList", dt);
        }
        #endregion

        #region Customer SelectAll
        public IActionResult CustomerSelectAll()
        {
            string str = this.Configuration.GetConnectionString("MyConnetionString");
            FF_FOOD dalFF = new FF_FOOD();

            SqlDatabase sqlDB = new SqlDatabase(str);
            DbCommand dbCMD = sqlDB.GetStoredProcCommand("PR_Customer_SelectAll");
            DataTable dt = dalFF.PR_Order_SelectAll(str);
            return View("CustomerList", dt);
        }
        #endregion

        #region Order Delete
        public IActionResult OrderDelete(string conn, PaymentModel modelPaymentModel)
        {
            string str = this.Configuration.GetConnectionString("MyConnetionString");
            FF_FOOD dalFF = new FF_FOOD();
            DataTable dt = dalFF.PR_Order_DeleteByPK(str, modelPaymentModel.OrderID);
            return RedirectToAction("OrderSelectAll");

        }
        #endregion

        #region Payment & Order Insert
        public IActionResult Save(PaymentModel modelPaymentModel)
        {
            string str = this.Configuration.GetConnectionString("MyConnetionString");
            FF_FOOD dalFF = new FF_FOOD();

            var userName = CV.UserName();

            if (modelPaymentModel.PaymentID == null && (userName=="admin"))
            {   
                DataTable dt1 = dalFF.PR_Order_Insert(str, modelPaymentModel);
                DataTable dt = dalFF.PR_Payment_Insert(str, modelPaymentModel);
                TempData["paymentMsg"] = "Payment Succesfully";
                return PaymentListAdmin();
            }
            else
            {
                DataTable dt1 = dalFF.PR_Order_Insert(str, modelPaymentModel);
                DataTable dt = dalFF.PR_Payment_Insert(str, modelPaymentModel);
                TempData["paymentMsg"] = "Payment Succesfully";
                return Index();
            }
            
            
        }
        #endregion
    }
}
