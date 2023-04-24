using FoodOrder.DAL;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Practices.EnterpriseLibrary.Data.Sql;
using System.Data.Common;
using System.Data.SqlClient;
using System.Data;
using FoodOrder.Areas.Food.Models;
using FoodOrder.BAL;

namespace FoodOrder.Areas.Food.Controllers
{
   /* [CheckAccess]*/
    [Area("Food")]
    [Route("Food/[controller]/[action]")]
    public class FoodController : Controller
    {
        private IConfiguration Configuration;
        public FoodController(IConfiguration _configuration)
        {
            Configuration = _configuration;
        }
        #region FoodAdd
        public IActionResult Add(int? FoodID)
        {
            // Catogary Drop Down
            DataTable dtd = new DataTable();
            String str = this.Configuration.GetConnectionString("MyConnetionString");
            SqlConnection conn1 = new SqlConnection(str);
            conn1.Open();
            SqlCommand cmd4 = conn1.CreateCommand();
            cmd4.CommandType = CommandType.StoredProcedure;
            cmd4.CommandText = "PR_MST_ContactCatogary_SelectForDropDown";
            SqlDataReader objsdr4 = cmd4.ExecuteReader();
            dtd.Load(objsdr4);
            List<Catogary_DropDownModel> list4 = new List<Catogary_DropDownModel>();
            foreach (DataRow dr in dtd.Rows)
            {
                Catogary_DropDownModel tlist4 = new Catogary_DropDownModel();
                tlist4.CatogaryID = Convert.ToInt32(dr["CatogaryID"]);
                tlist4.Catogary = dr["Catogary"].ToString();
                list4.Add(tlist4);
            }
            ViewBag.CatogaryList = list4;

            if (FoodID != null)
            {
                //String str = this.Configuration.GetConnectionString("MyConnetionString");
                SqlConnection conn = new SqlConnection(str);
                conn.Open();

                SqlCommand cmd = conn.CreateCommand();
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "PR_FF_Food_SelectAll_By_FoodID";
                cmd.Parameters.Add("@FoodID", SqlDbType.Int).Value = FoodID;

                DataTable dt = new DataTable();
                SqlDataReader sdr = cmd.ExecuteReader();
                dt.Load(sdr);

                FoodModel modelFoodModel = new FoodModel();

                foreach (DataRow dr in dt.Rows)
                {
                    modelFoodModel.FoodID = Convert.ToInt32(dr["FoodID"]);
                    modelFoodModel.Food = dr["Food"].ToString();
                    modelFoodModel.CatogaryID = Convert.ToInt32(dr["CatogaryID"]);
                    modelFoodModel.Price = Convert.ToDecimal(dr["Price"]);
                    modelFoodModel.Rate = dr["Rate"].ToString();
                    modelFoodModel.Type = dr["Type"].ToString();
                    modelFoodModel.PhotoPath = dr["Photopath"].ToString();

                }
                return View("FoodAddEdit", modelFoodModel);
            }
            return View("FoodAddEdit");
        }
        #endregion

        #region FoodList Client
        public IActionResult Index()
        {
            string str = this.Configuration.GetConnectionString("MyConnetionString");
            FF_FOOD dalFF = new FF_FOOD();

            SqlDatabase sqlDB = new SqlDatabase(str);
            DbCommand dbCMD = sqlDB.GetStoredProcCommand("PR_FF_Food_SelectAll");
            DataTable dt = dalFF.PR_FF_Food_SelectAll(str);
            return View("Index", dt);
        }
        #endregion

        #region FoodList Admin
        public IActionResult FoodList()
        {
            string str = this.Configuration.GetConnectionString("MyConnetionString");
            FF_FOOD dalFF = new FF_FOOD();

            SqlDatabase sqlDB = new SqlDatabase(str);
            DbCommand dbCMD = sqlDB.GetStoredProcCommand("PR_FF_Food_SelectAll");
            DataTable dt = dalFF.PR_FF_Food_SelectAll(str);
            return View("FoodList", dt);
        }
        #endregion

        #region Catogary Delete
        public IActionResult Delete(string conn, FoodModel modelFoodModel)
        {
            string str = this.Configuration.GetConnectionString("MyConnetionString");
            FF_FOOD dalFF = new FF_FOOD();
            DataTable dt = dalFF.PR_FF_Food_DeleteByPK(str, modelFoodModel.FoodID);
            return RedirectToAction("FoodList");

        }
        #endregion

        #region Food Insert/Update
        public IActionResult Save(FoodModel modelFoodModel)
        {
            string str = this.Configuration.GetConnectionString("MyConnetionString");
            FF_FOOD dalFF = new FF_FOOD();

            if (modelFoodModel.File != null)
            {
                string FilePath = "wwwroot\\Upload";
                string path = Path.Combine(Directory.GetCurrentDirectory(), FilePath);
                if (!Directory.Exists(path))
                {
                    Directory.CreateDirectory(path);
                }
                string fileNameWithPath = Path.Combine(path, modelFoodModel.File.FileName);
                modelFoodModel.PhotoPath = FilePath.Replace("wwwroot\\", "/") + "/" + modelFoodModel.File.FileName;
                using (var stream = new FileStream(fileNameWithPath, FileMode.Create))
                {
                    modelFoodModel.File.CopyTo(stream);
                }
            }

            if (modelFoodModel.FoodID == null)
            {
                DataTable dt = dalFF.PR_FF_Food_Insert(str, modelFoodModel);
                TempData["CatogaryInsertMsg"] = "Record Inserted Succesfully";
            }
            else
            {
                DataTable dt = dalFF.PR_FF_Food_UpdateByPk(str, modelFoodModel);
                TempData["CatogaryInsertMsg"] = "Record Updated Succesfully";
            }

            return FoodList();
        }
        #endregion
    }
}
