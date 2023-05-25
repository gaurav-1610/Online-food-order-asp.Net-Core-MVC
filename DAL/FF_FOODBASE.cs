using FoodOrder.BAL;
using Microsoft.Practices.EnterpriseLibrary.Data.Sql;
using System.Data.Common;
using System.Data;
using FoodOrder.Areas.CAT_Catogary.Models;
using FoodOrder.Areas.Food.Models;
using FoodOrder.Areas.Cart.Models;
using FoodOrder.Areas.Payment.Models;
using FoodOrder.Models;

namespace FoodOrder.DAL
{
    public class FF_FOODBASE
    {
        
        #region SelectALL

        #region pr_CAT_Catogary_selectall

        public DataTable pr_CAT_Catogary_selectall(string conn)
        {
            try
            {
                SqlDatabase sqlDB = new SqlDatabase(conn);
                DbCommand dbCMD = sqlDB.GetStoredProcCommand("pr_CAT_Catogary_selectall");
              
                DataTable dt = new DataTable();
                using (IDataReader dr = sqlDB.ExecuteReader(dbCMD))
                {
                    dt.Load(dr);
                }
                return dt;
            }
            catch (Exception e)
            {

                return null;

            }
        }
        #endregion

        #region PR_FF_Food_SelectAll

        public DataTable PR_FF_Food_SelectAll(string conn)
        {
            try
            {
                SqlDatabase sqlDB = new SqlDatabase(conn);
                DbCommand dbCMD = sqlDB.GetStoredProcCommand("PR_FF_Food_SelectAll");

                DataTable dt = new DataTable();
                using (IDataReader dr = sqlDB.ExecuteReader(dbCMD))
                {
                    dt.Load(dr);
                }
                return dt;
            }
            catch (Exception e)
            {

                return null;

            }
        }
        #endregion

        #region PR_Cart_SelectAll

        public DataTable PR_Cart_SelectAll(string conn)
        {
            try
            {
                SqlDatabase sqlDB = new SqlDatabase(conn);
                DbCommand dbCMD = sqlDB.GetStoredProcCommand("PR_Cart_SelectAll");

                DataTable dt = new DataTable();
                using (IDataReader dr = sqlDB.ExecuteReader(dbCMD))
                {
                    dt.Load(dr);
                }
                return dt;
            }
            catch (Exception e)
            {

                return null;

            }
        }
        #endregion

        #region PR_Order_SelectAll

        public DataTable PR_Order_SelectAll(string conn)
        {
            try
            {
                SqlDatabase sqlDB = new SqlDatabase(conn);
                DbCommand dbCMD = sqlDB.GetStoredProcCommand("PR_Order_SelectAll");

                DataTable dt = new DataTable();
                using (IDataReader dr = sqlDB.ExecuteReader(dbCMD))
                {
                    dt.Load(dr);
                }
                return dt;
            }
            catch (Exception e)
            {

                return null;

            }
        }
        #endregion

        #region PR_Customer_SelectAll

        public DataTable PR_Customer_SelectAll(string conn)
        {
            try
            {
                SqlDatabase sqlDB = new SqlDatabase(conn);
                DbCommand dbCMD = sqlDB.GetStoredProcCommand("PR_Customer_SelectAll");

                DataTable dt = new DataTable();
                using (IDataReader dr = sqlDB.ExecuteReader(dbCMD))
                {
                    dt.Load(dr);
                }
                return dt;
            }
            catch (Exception e)
            {

                return null;

            }
        }
        #endregion

        #region PR_FF_Food_SelectAll_By_CatogaryID

        public DataTable PR_FF_Food_SelectAll_By_CatogaryID(string conn,int CatogaryID)
        {
            try
            {
                SqlDatabase sqlDB = new SqlDatabase(conn);
                DbCommand dbCMD = sqlDB.GetStoredProcCommand("PR_FF_Food_SelectAll_By_CatogaryID");
                sqlDB.AddInParameter(dbCMD, "CatogaryID", SqlDbType.NVarChar,CatogaryID);

                DataTable dt = new DataTable();
                using (IDataReader dr = sqlDB.ExecuteReader(dbCMD))
                {
                    dt.Load(dr);
                }
                return dt;
            }
            catch (Exception e)
            {

                return null;

            }
        }
        #endregion

        #region PR_FF_Food_SelectAll_By_FoodID

        public DataTable PR_FF_Food_SelectAll_By_FoodID(string conn, int FoodID)
        {
            try
            {
                SqlDatabase sqlDB = new SqlDatabase(conn);
                DbCommand dbCMD = sqlDB.GetStoredProcCommand("PR_FF_Food_SelectAll_By_FoodID");
                sqlDB.AddInParameter(dbCMD, "FoodID", SqlDbType.Int, FoodID);

                DataTable dt = new DataTable();
                using (IDataReader dr = sqlDB.ExecuteReader(dbCMD))
                {
                    dt.Load(dr);
                }
                return dt;
            }
            catch (Exception e)
            {

                return null;

            }
        }
        #endregion

        #endregion

        #region Insert

        #region PR_FF_Food_Insert

        public DataTable PR_FF_Food_Insert(string conn, FoodModel modelFoodModel)
        {
            try
            {
                SqlDatabase sqlDB = new SqlDatabase(conn);
                DbCommand dbCMD = sqlDB.GetStoredProcCommand("PR_FF_Food_Insert");
                sqlDB.AddInParameter(dbCMD, "Food", SqlDbType.NVarChar, modelFoodModel.Food);
                sqlDB.AddInParameter(dbCMD, "CatogaryID", SqlDbType.NVarChar, modelFoodModel.CatogaryID);
                sqlDB.AddInParameter(dbCMD, "Price", SqlDbType.Decimal, modelFoodModel.Price);
                sqlDB.AddInParameter(dbCMD, "Rate", SqlDbType.NVarChar, modelFoodModel.Rate);
                sqlDB.AddInParameter(dbCMD, "Type", SqlDbType.NVarChar, modelFoodModel.Type);
                sqlDB.AddInParameter(dbCMD, "Photopath", SqlDbType.NVarChar, modelFoodModel.PhotoPath);

                DataTable dt = new DataTable();

                using (IDataReader dr = sqlDB.ExecuteReader(dbCMD))
                {
                    dt.Load(dr);

                }
                return dt;
            }
            catch (Exception e)
            {

                return null;

            }
        }
        #endregion


        #region PR_CAT_Category_Insert

        public DataTable PR_CAT_Category_Insert(string conn, CAT_CatogaryModel modelCAT_CatogaryModel)
        {
            try
            {
                SqlDatabase sqlDB = new SqlDatabase(conn);
                DbCommand dbCMD = sqlDB.GetStoredProcCommand("PR_CAT_Category_Insert");
                sqlDB.AddInParameter(dbCMD, "Catogary", SqlDbType.NVarChar, modelCAT_CatogaryModel.Catogary);
      
                DataTable dt = new DataTable();

                using (IDataReader dr = sqlDB.ExecuteReader(dbCMD))
                {
                    dt.Load(dr);

                }
                return dt;
            }
            catch (Exception e)
            {

                return null;

            }
        }
        #endregion

        #region PR_Order_Insert

        public DataTable PR_Order_Insert(string conn, PaymentModel modelPaymentModel)
        {
            try
            {
                SqlDatabase sqlDB = new SqlDatabase(conn);
                DbCommand dbCMD = sqlDB.GetStoredProcCommand("PR_Order_Insert");

                var userName = @CV.UserName();
                sqlDB.AddInParameter(dbCMD, "Name", SqlDbType.NVarChar, userName);
                sqlDB.AddInParameter(dbCMD, "OrderDate", SqlDbType.DateTime, DBNull.Value);
                sqlDB.AddInParameter(dbCMD, "@ReceivedAmount", SqlDbType.Decimal, modelPaymentModel.ReceivedAmount);

                DataTable dt = new DataTable();

                using (IDataReader dr = sqlDB.ExecuteReader(dbCMD))
                {
                    dt.Load(dr);

                }
                return dt;
            }
            catch (Exception e)
            {

                return null;

            }
        }
        #endregion

        #region PR_Payment_Insert

        public DataTable PR_Payment_Insert(string conn, PaymentModel modelPaymentModel)
        {
            try
            {
                SqlDatabase sqlDB = new SqlDatabase(conn);
                DbCommand dbCMD = sqlDB.GetStoredProcCommand("PR_Payment_Insert");
                sqlDB.AddInParameter(dbCMD, "Name", SqlDbType.NVarChar, modelPaymentModel.cardName);
                sqlDB.AddInParameter(dbCMD, "ReceivedAmount", SqlDbType.NVarChar, modelPaymentModel.ReceivedAmount);
                sqlDB.AddInParameter(dbCMD, "PaymentDate", SqlDbType.DateTime, DBNull.Value);

                DataTable dt = new DataTable();

                using (IDataReader dr = sqlDB.ExecuteReader(dbCMD))
                {
                    dt.Load(dr);

                }
                return dt;
            }
            catch (Exception e)
            {

                return null;

            }
        }
        #endregion

        #region PR_Cart_Insert_Order

        public DataTable PR_Cart_Insert_Order(string conn, CartModel modelCartModel)
        {
            try
            {
                SqlDatabase sqlDB = new SqlDatabase(conn);
                DbCommand dbCMD = sqlDB.GetStoredProcCommand("PR_Cart_Insert_Order");
                sqlDB.AddInParameter(dbCMD, "FoodID", SqlDbType.Int, modelCartModel.FoodID);
                
                DataTable dt = new DataTable();

                using (IDataReader dr = sqlDB.ExecuteReader(dbCMD))
                {
                    dt.Load(dr);

                }
                return dt;
            }
            catch (Exception e)
            {

                return null;

            }
        }
        #endregion

        #endregion

        #region Update
        #region PR_CAT_Category_UpdateByPK

        public DataTable PR_CAT_Category_UpdateByPK(string conn, CAT_CatogaryModel modelCAT_CatogaryModel)
        {
            try
            {
                SqlDatabase sqlDB = new SqlDatabase(conn);
                DbCommand dbCMD = sqlDB.GetStoredProcCommand("PR_CAT_Category_UpdateByPK");
           
                sqlDB.AddInParameter(dbCMD, "CatogaryID", SqlDbType.Int, modelCAT_CatogaryModel.CatogaryID);
                sqlDB.AddInParameter(dbCMD, "Catogary", SqlDbType.NVarChar, modelCAT_CatogaryModel.Catogary);
                

                DataTable dt = new DataTable();

                using (IDataReader dr = sqlDB.ExecuteReader(dbCMD))
                {
                    dt.Load(dr);

                }
                return dt;
            }
            catch (Exception e)
            {

                return null;

            }
        }
        #endregion

        #region PR_FF_Food_UpdateByPk

        public DataTable PR_FF_Food_UpdateByPk(string conn, FoodModel modelFoodModel)
        {
            try
            {
                SqlDatabase sqlDB = new SqlDatabase(conn);
                DbCommand dbCMD = sqlDB.GetStoredProcCommand("PR_FF_Food_UpdateByPk");

                sqlDB.AddInParameter(dbCMD, "FoodID", SqlDbType.Int, modelFoodModel.FoodID);
                sqlDB.AddInParameter(dbCMD, "Food", SqlDbType.NVarChar, modelFoodModel.Food);
                sqlDB.AddInParameter(dbCMD, "CatogaryID", SqlDbType.NVarChar, modelFoodModel.CatogaryID);
                sqlDB.AddInParameter(dbCMD, "Price", SqlDbType.Decimal, modelFoodModel.Price);
                sqlDB.AddInParameter(dbCMD, "Rate", SqlDbType.NVarChar, modelFoodModel.Rate);
                sqlDB.AddInParameter(dbCMD, "Type", SqlDbType.NVarChar, modelFoodModel.Type);
                sqlDB.AddInParameter(dbCMD, "Photopath", SqlDbType.NVarChar, modelFoodModel.PhotoPath);


                DataTable dt = new DataTable();

                using (IDataReader dr = sqlDB.ExecuteReader(dbCMD))
                {
                    dt.Load(dr);

                }
                return dt;
            }
            catch (Exception e)
            {

                return null;

            }
        }
        #endregion

        #region PR_Cart_UpdateByPK

        public DataTable PR_Cart_UpdateByPK(string conn, CartModel modelCartModel)
        {
            try
            {
                SqlDatabase sqlDB = new SqlDatabase(conn);
                DbCommand dbCMD = sqlDB.GetStoredProcCommand("PR_Cart_UpdateByPK");

                sqlDB.AddInParameter(dbCMD, "CartID", SqlDbType.Int, modelCartModel.CartID);
                sqlDB.AddInParameter(dbCMD, "Quantity", SqlDbType.Int, modelCartModel.Quantity);

                if (modelCartModel.Quantity==0)
                {
                    DbCommand dbCMD1 = sqlDB.GetStoredProcCommand("PR_Cart_DeleteByPK");
                    sqlDB.AddInParameter(dbCMD1, "CartID", SqlDbType.Int, modelCartModel.CartID);
                    DataTable dt1 = new DataTable();

                    using (IDataReader dr1 = sqlDB.ExecuteReader(dbCMD1))
                    {
                        dt1.Load(dr1);

                    }
                    return dt1;
                }


                DataTable dt = new DataTable();

                using (IDataReader dr = sqlDB.ExecuteReader(dbCMD))
                {
                    dt.Load(dr);

                }
                return dt;
            }
            catch (Exception e)
            {

                return null;

            }
        }
        #endregion

        #endregion

        #region delete
        #region PR_CAT_Category_DeleteByPK

        public DataTable PR_CAT_Category_DeleteByPK(string conn, int? CatogaryID)
        {
            try
            {
                SqlDatabase sqlDB = new SqlDatabase(conn);
                DbCommand dbCMD = sqlDB.GetStoredProcCommand("PR_CAT_Category_DeleteByPK");
                sqlDB.AddInParameter(dbCMD, "CatogaryID", SqlDbType.Int, CatogaryID);

                DataTable dt = new DataTable();
                using (IDataReader dr = sqlDB.ExecuteReader(dbCMD))
                {
                    dt.Load(dr);
                }
                return dt;
            }
            catch (Exception e)
            {

                return null;

            }
        }
        #endregion

        #region PR_FF_Food_DeleteByPK

        public DataTable PR_FF_Food_DeleteByPK(string conn, int? FoodID) 
        {
            try
            {
                SqlDatabase sqlDB = new SqlDatabase(conn);
                DbCommand dbCMD = sqlDB.GetStoredProcCommand("PR_FF_Food_DeleteByPK");
                sqlDB.AddInParameter(dbCMD, "FoodID", SqlDbType.Int, FoodID);

                DataTable dt = new DataTable();
                using (IDataReader dr = sqlDB.ExecuteReader(dbCMD))
                {
                    dt.Load(dr);
                }
                return dt;
            }
            catch (Exception e)
            {

                return null;

            }
        }
        #endregion

        #region PR_Order_DeleteByPK

        public DataTable PR_Order_DeleteByPK(string conn, int? OrderID)
        {
            try
            {
                SqlDatabase sqlDB = new SqlDatabase(conn);
                DbCommand dbCMD = sqlDB.GetStoredProcCommand("PR_Order_DeleteByPK");
                sqlDB.AddInParameter(dbCMD, "OrderID", SqlDbType.Int, OrderID);

                DataTable dt = new DataTable();
                using (IDataReader dr = sqlDB.ExecuteReader(dbCMD))
                {
                    dt.Load(dr);
                }
                return dt;
            }
            catch (Exception e)
            {

                return null;

            }
        }
        #endregion

        #region PR_Cart_RemoveAll

        public DataTable PR_CART_RemoveAll(string conn)
        {
            try
            {
                SqlDatabase sqlDB = new SqlDatabase(conn);
                DbCommand dbCMD = sqlDB.GetStoredProcCommand("PR_CART_RemoveAll");

                DataTable dt = new DataTable();
                using (IDataReader dr = sqlDB.ExecuteReader(dbCMD))
                {
                    dt.Load(dr);
                }
                return dt;
            }
            catch (Exception e)
            {

                return null;

            }
        }
        #endregion

        #endregion

    }
}
