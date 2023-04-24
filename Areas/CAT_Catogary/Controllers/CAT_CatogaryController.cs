using FoodOrder.Areas.CAT_Catogary.Models;
using FoodOrder.BAL;
using FoodOrder.DAL;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Practices.EnterpriseLibrary.Data.Sql;
using System.Data;
using System.Data.Common;
using System.Data.SqlClient;

namespace FoodOrder.Areas.CAT_Catogary.Controllers
{
    [CheckAccess]
    [Area("CAT_Catogary")]
    [Route("CAT_Catogary/[controller]/[action]")]
    public class CAT_CatogaryController : Controller
    {
        private IConfiguration Configuration;
        public CAT_CatogaryController(IConfiguration _configuration)
        {
            Configuration = _configuration;
        }
        #region Categoray Add
        public IActionResult Add(int? CatogaryID)
        {
     
            if (CatogaryID != null)
            {
                String str = this.Configuration.GetConnectionString("MyConnetionString");
                SqlConnection conn = new SqlConnection(str);
                conn.Open();

                SqlCommand cmd = conn.CreateCommand();
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "PR_CAT_Category_SelectByPK";
                cmd.Parameters.Add("@CatogaryID", SqlDbType.Int).Value = CatogaryID;

                DataTable dt = new DataTable();
                SqlDataReader sdr = cmd.ExecuteReader();
                dt.Load(sdr);

                CAT_CatogaryModel modelCAT_Catogary = new CAT_CatogaryModel();

                foreach (DataRow dr in dt.Rows)
                {
                    modelCAT_Catogary.CatogaryID = Convert.ToInt32(dr["CatogaryID"]);
                    modelCAT_Catogary.Catogary = dr["Catogary"].ToString();
                   
                }
                return View("CAT_CatogaryAddEdit", modelCAT_Catogary);
            }
            return View("CAT_CatogaryAddEdit");
        }
        #endregion

        #region CategorySelectAll
        public IActionResult Index()
        {
            string str = this.Configuration.GetConnectionString("MyConnetionString");
            FF_FOOD dalFF = new FF_FOOD();

            SqlDatabase sqlDB = new SqlDatabase(str);
            DbCommand dbCMD = sqlDB.GetStoredProcCommand("pr_CAT_Catogary_selectall");
            DataTable dt = dalFF.pr_CAT_Catogary_selectall(str);
            return View("Index",dt);
        }
        #endregion
        
        #region Catogary Delete
        public IActionResult Delete(string conn , CAT_CatogaryModel modelCAT_CatogaryModel)
        {
            string str = this.Configuration.GetConnectionString("MyConnetionString");
            FF_FOOD dalFF = new FF_FOOD();
           DataTable dt = dalFF.PR_CAT_Category_DeleteByPK(str, modelCAT_CatogaryModel.CatogaryID);
            return RedirectToAction("Index");
        }
        #endregion

        #region Category Save (Add)
        public IActionResult Save(CAT_CatogaryModel modelCAT_CatogaryModel)
        {

            string str = this.Configuration.GetConnectionString("MyConnetionString");
            FF_FOOD dalFF = new FF_FOOD();

            if (modelCAT_CatogaryModel.CatogaryID == null)
            {
                DataTable dt = dalFF.PR_CAT_Category_Insert(str, modelCAT_CatogaryModel);
                TempData["CatogaryInsertMsg"] = "Record Inserted Succesfully";
            }
            else
            {
                DataTable dt = dalFF.PR_CAT_Category_UpdateByPK(str, modelCAT_CatogaryModel);
                TempData["CatogaryInsertMsg"] = "Record Updated Succesfully";
            }

            return Index();
        }
        #endregion
    }
}
