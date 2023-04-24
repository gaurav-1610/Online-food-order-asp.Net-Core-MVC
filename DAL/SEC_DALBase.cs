using System.Data.Common;
using System.Data;
using Microsoft.Practices.EnterpriseLibrary.Data.Sql;
using FoodOrder.Models;
using FoodOrder.BAL;

namespace FoodOrder.DAL
{
    public class SEC_DALBase
    {
        #region Method: PR_REG_Registration_SelectByPK
        public DataTable PR_REG_Registration_SelectByPK(string ConnStr, int? UserID)
        {
            try
            {
                SqlDatabase sqlDB = new SqlDatabase(ConnStr);
                DbCommand dbCMD = sqlDB.GetStoredProcCommand("dbo.PR_REG_Registration_SelectByPK");
                sqlDB.AddInParameter(dbCMD, "UserID", SqlDbType.Int, UserID);

                DataTable dt = new DataTable();
                using (IDataReader dr = sqlDB.ExecuteReader(dbCMD))
                {
                    dt.Load(dr);
                }

                return dt;
            }
            catch (Exception ex)
            {
                return null;
            }
        }
        #endregion

        #region Method: PR_REG_Registration_SelectBy_UserName_Password
        public DataTable PR_REG_Registration_SelectBy_UserName_Password(string ConnStr, SEC_UserModel modelSEC_User)
        {
            try
            {   

                SqlDatabase sqlDB = new SqlDatabase(ConnStr);
                DbCommand dbCMD = sqlDB.GetStoredProcCommand("dbo.PR_REG_Registration_SelectBy_UserName_Password");
                sqlDB.AddInParameter(dbCMD, "UserName", SqlDbType.VarChar, modelSEC_User.UserName);
                /*sqlDB.AddInParameter(dbCMD, "UserName", SqlDbType.VarChar, modelSEC_User.UserName);*/
                sqlDB.AddInParameter(dbCMD, "Password", SqlDbType.VarChar, modelSEC_User.Password);

                DataTable dt = new DataTable();
                using (IDataReader dr = sqlDB.ExecuteReader(dbCMD))
                {
                    dt.Load(dr);
                }

                return dt;
            }
            catch (Exception ex)
            {
                return null;
            }
        }
        #endregion

        #region Method: PR_REG_Registration_Insert
        public decimal? PR_REG_Registration_Insert(string ConnStr,string UserName, string Password, string FirstName, string LastName, string Email , string Address)
        {
            try
            {
                SqlDatabase sqlDB = new SqlDatabase(ConnStr);
                DbCommand dbCMD = sqlDB.GetStoredProcCommand("dbo.PR_REG_Registration_Insert");
                sqlDB.AddInParameter(dbCMD, "UserName", SqlDbType.VarChar, UserName);
                sqlDB.AddInParameter(dbCMD, "FirstName", SqlDbType.VarChar, FirstName);
                sqlDB.AddInParameter(dbCMD, "LastName", SqlDbType.VarChar, LastName);
                sqlDB.AddInParameter(dbCMD, "Password", SqlDbType.VarChar, Password);
                sqlDB.AddInParameter(dbCMD, "Email", SqlDbType.VarChar, FirstName);
                sqlDB.AddInParameter(dbCMD, "Address", SqlDbType.VarChar, LastName);

                var vResult = sqlDB.ExecuteScalar(dbCMD);
                if (vResult == null)
                    return null;

                return (decimal)Convert.ChangeType(vResult, vResult.GetType());
            }
            catch (Exception ex)
            {
                return null;
            }
        }
        #endregion

    }
}
