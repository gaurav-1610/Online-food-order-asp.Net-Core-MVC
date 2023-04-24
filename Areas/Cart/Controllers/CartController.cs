using FoodOrder.BAL;
using FoodOrder.DAL;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Practices.EnterpriseLibrary.Data.Sql;
using System.Data.Common;
using System.Data;
using FoodOrder.Areas.Cart.Models;
using FoodOrder.Areas.Food.Models;
using System.Data.SqlClient;
using Newtonsoft.Json;
using FoodOrder.Models;

namespace FoodOrder.Areas.Cart.Controllers
{
    /*[CheckAccess]*/
    [Area("Cart")]
    [Route("Cart/[controller]/[action]")]
    public class CartController : Controller
    {
        private static List<FoodModel> list = new List<FoodModel>();

        private IConfiguration Configuration;
        public CartController(IConfiguration _configuration)
        {
            Configuration = _configuration;
        }
        
        #region CartList Client
        public IActionResult Index()
        {

            string cookieValue = Request.Cookies["cart"];
            if (!string.IsNullOrEmpty(cookieValue))
            {
                list = JsonConvert.DeserializeObject<List<FoodModel>>(cookieValue);
            }
            decimal total = list.Sum(x => x.SubTotal);
            ViewBag.Total = total;

            // Save the updated list to the cookie
            string newCookieValue = JsonConvert.SerializeObject(list);
            var option = new CookieOptions
            {
                Expires = DateTime.MaxValue,
                IsEssential = true
            };
            Response.Cookies.Append("cart", newCookieValue, option);
            return View("CartList", list);
        }
        #endregion

        #region CartListAdmin
        public IActionResult CartListAdmin()
        {
            
            string cookieValue = Request.Cookies["cart"];
            if (!string.IsNullOrEmpty(cookieValue))
            {
                list = JsonConvert.DeserializeObject<List<FoodModel>>(cookieValue);
            }

            return View("CartListAdmin", list);
        }
        #endregion

        #region Cart RemoveAll Client
        public IActionResult RemoveAll()
        {
            string cookieValue = Request.Cookies["cart"];
            if (!string.IsNullOrEmpty(cookieValue))
            {
                list = JsonConvert.DeserializeObject<List<FoodModel>>(cookieValue);
            }
            list.Clear();
            string newCookieValue = JsonConvert.SerializeObject(list);
            var option = new CookieOptions
            {
                Expires = DateTime.MaxValue,
                IsEssential = true
            };
            Response.Cookies.Append("cart", newCookieValue, option);
            return View("CartList", list);
        }
        #endregion

        #region Cart RemoveAll Admin
        public IActionResult RemoveAllAdmin()
        {

            string cookieValue = Request.Cookies["cart"];
            if (!string.IsNullOrEmpty(cookieValue))
            {
                list = JsonConvert.DeserializeObject<List<FoodModel>>(cookieValue);
            }
            list.Clear();
            string newCookieValue = JsonConvert.SerializeObject(list);
            var option = new CookieOptions
            {
                Expires = DateTime.MaxValue,
                IsEssential = true
            };
            Response.Cookies.Append("cart", newCookieValue, option);
            return View("CartListAdmin", list);
        }
        #endregion

        #region Cart Insert Order
        /*public IActionResult Save(CartModel modelCartModel)
        {
            string str = this.Configuration.GetConnectionString("MyConnetionString");
            FF_FOOD dalFF = new FF_FOOD();

            var userName = CV.UserName();
            if (modelCartModel.CartID == null && (userName == "admin"))
            {
                DataTable dt = dalFF.PR_Cart_Insert_Order(str, modelCartModel);
                TempData["CatogaryInsertMsg"] = "Record Inserted Succesfully";
                return CartListAdmin();
            }
            else if (modelCartModel.CartID == null)
            {
                DataTable dt = dalFF.PR_Cart_Insert_Order(str, modelCartModel);
                TempData["CatogaryInsertMsg"] = "Record Inserted Succesfully";
                return Index();
            }
            else if (modelCartModel.CartID != null && (userName == "admin"))
            {
                DataTable dt = dalFF.PR_Cart_UpdateByPK(str, modelCartModel);
                TempData["CartInsertMsg"] = "Record Updated Succesfully";
                return CartListAdmin();
            }
            else
            {
                DataTable dt = dalFF.PR_Cart_UpdateByPK(str, modelCartModel);
                TempData["CatogaryInsertMsg"] = "Record Updated Succesfully";
                return Index();
            }

            //return Index();
        }*/
        #endregion

        #region AddCart
        [HttpPost]
        public IActionResult AddCart(int FoodID,SEC_UserModel modelSEC_UserModel)
        {
            FF_FOOD dalFF = new FF_FOOD();
            string str = this.Configuration.GetConnectionString("MyConnetionString");

            DataTable dt = dalFF.PR_FF_Food_SelectAll_By_FoodID(str,FoodID);

            FoodModel vlst = new FoodModel();
            vlst.FoodID = (int)(dt.Rows[0]["FoodID"]);
            vlst.Food = (string)dt.Rows[0]["Food"];
            vlst.CatogaryID = (int)(dt.Rows[0]["CatogaryID"]);
            vlst.Price = (decimal)dt.Rows[0]["Price"];
            vlst.Rate= (string)dt.Rows[0]["Rate"];
            vlst.Type = (string)dt.Rows[0]["Type"];
            vlst.PhotoPath = (string)dt.Rows[0]["Photopath"];
            vlst.Quantity = 1;
            vlst.SubTotal = vlst.Price * vlst.Quantity;

            // Retrieve the existing list from the cookie
            string cookieValue = Request.Cookies["cart"];
            if (!string.IsNullOrEmpty(cookieValue))
            {
                list = JsonConvert.DeserializeObject<List<FoodModel>>(cookieValue);
            }
            
            // Add the new item to the list
            list.Add(vlst);

            decimal total = list.Sum(x => x.SubTotal);
            ViewBag.Total = total;

            // Save the updated list to the cookie
            string newCookieValue = JsonConvert.SerializeObject(list);
            var option = new CookieOptions
            {
                Expires = DateTime.MaxValue,
                IsEssential = true
            };
            Response.Cookies.Append("cart", newCookieValue, option);
            var uname = @CV.UserName();
            if (uname == "admin")
            {
                return RedirectToAction("MenuListAdmin", "Menu", new { area = "Menu" });
            }
            else
            {
                return RedirectToAction("Index", "Food", new { area = "Food" });
            }
            
        }
        #endregion

        #region DeleteCart
        [HttpPost]
        public IActionResult DeleteCart(int? FoodID)
        {
            if (FoodID.HasValue)
            {
                list.RemoveAll(x => x.FoodID == FoodID);

                decimal total = list.Sum(x => x.SubTotal);
                ViewBag.Total = total;
                var cookieValue = JsonConvert.SerializeObject(list);
                var option = new CookieOptions
                {
                    Expires = DateTime.MaxValue,
                    IsEssential = true
                };
                Response.Cookies.Append("cart", cookieValue, option);
            }

            return RedirectToAction("Index");


        }
        #endregion

        #region UpdateCart

        [HttpPost]
        public IActionResult UpdateCart(int FoodID, string action, SEC_UserModel modelSEC_UserModel)
        {
            var cookieValue = Request.Cookies["cart"];

            if (!string.IsNullOrEmpty(cookieValue))
            {
                list = JsonConvert.DeserializeObject<List<FoodModel>>(cookieValue);
            }

            var itemToUpdate = list.FirstOrDefault(x => x.FoodID == FoodID);
            if (itemToUpdate != null)
            {
                if (action == "increment")
                {
                    itemToUpdate.Quantity++;
                }
                else if (action == "decrement")
                {
                    if (itemToUpdate.Quantity > 0)
                    {
                        itemToUpdate.Quantity--;
                    }
                    
                }
                if(itemToUpdate.Quantity == 0)
                {
                    list.Remove(itemToUpdate);
                }
                itemToUpdate.SubTotal = itemToUpdate.Price * itemToUpdate.Quantity;
            }
            decimal total = list.Sum(x => x.SubTotal);
            ViewBag.Total = total;

            var newCookieValue = JsonConvert.SerializeObject(list);
            var option = new CookieOptions
            {
                Expires = DateTime.MaxValue,
                IsEssential = true
            };
            Response.Cookies.Append("cart", newCookieValue, option);
            var uname = @CV.UserName();
            if (uname == "admin" )
            {
                return RedirectToAction("CartListAdmin", "Cart", new { area = "Cart" });
            }
            else
            {
                return RedirectToAction("Index");
            }
            //return RedirectToAction("Index");
        }
        #endregion

    }
}
