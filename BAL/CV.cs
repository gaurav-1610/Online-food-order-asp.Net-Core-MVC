using FoodOrder.Areas.Cart.Controllers;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace FoodOrder.BAL
{
    public static class CV
    {
        private static IHttpContextAccessor _httpContextAccessor;

        static CV()
        {
            _httpContextAccessor = new HttpContextAccessor();
        }
        
        public static string? UserName()
        {
            string? UserName = null;

            if (_httpContextAccessor.HttpContext.Session.GetString("UserName") != null)
            {
                UserName = _httpContextAccessor.HttpContext.Session.GetString("UserName").ToString();
            }
            return UserName;
        }

        public static int? UserID()
        {
            int? UserID = null;
            if (_httpContextAccessor.HttpContext.Session.GetString("UserID") != null)
            {
                UserID = Convert.ToInt32(_httpContextAccessor.HttpContext.Session.GetString("UserID"));
            }
            return UserID;
        }
        /*public static int CartID()
        {
            int CartID = 1;
            if (_httpContextAccessor.HttpContext.Session.GetString("CartID") != null)
            {
                CartID = Convert.ToInt32(_httpContextAccessor.HttpContext.Session.GetString("CartID"));
            }
            return CartID;
        }
        public static int Quantity()
        {
            int Quantity = 1 ;
            if (_httpContextAccessor.HttpContext.Session.GetString("Quantity") != null)
            {
                Quantity = Convert.ToInt32(_httpContextAccessor.HttpContext.Session.GetString("Quantity"));
            }
            return Quantity;
        }*/
    }
}