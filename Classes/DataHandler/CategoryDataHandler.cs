using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Opticron.Classes.DataHandler
{
    public class CategoryDataHandler
    {
        #region Properties
        private string sql;
        private Datahandler datahandler;
        #endregion

        #region Getters and Setters
        public string Sql { get => sql; set => sql = value; }
        public Datahandler Datahandler { get => datahandler; set => datahandler = value; }
        #endregion

        #region Constructor
        public CategoryDataHandler()
        {
            datahandler = new Datahandler();
        }
        #endregion

        #region Methods
        public List<Category> SelectAllCategories()//Generates a sql query and sends it to the datahander to run the query on the database. Gets the returned list of object arrays and extracts the data and puts it into a structured formate of an obejct.
        {
            List<Category> returnList = new List<Category>();
            sql = "SELECT * FROM[dbo].[Category]";
            List<object[]> tempList = datahandler.Select(sql);
            foreach (object[] item in tempList)
            {
                returnList.Add(new Category((int)item[0],(string)item[1],(string)item[2]));
            }
            return returnList;
        }
        public Category SelectCategoryByID(Category category)//Generates a sql query and sends it to the datahander to run the query on the database. Gets the returned list of object arrays and extracts the data and puts it into a structured formate of an obejct.
        {
            Category returnItem = new Category();
            sql = "SELECT * FROM[dbo].[Category]  WHERE [CategoryId] ='"+category.CategoryId+"'";
            object[] item = datahandler.Select(sql)[0];            
            returnItem =new Category((int)item[0], (string)item[1], (string)item[2]);
            
            return returnItem;
        }

        public bool InsertNewCategory(Category newCategory)//Generates an sql query based off of the parameter given and sends the newly generated query to the datahandler which will then execute the query and return the results 

        {
            bool returnBool = false;
            sql = "INSERT INTO [dbo].[Category]" +
           "([CategoryName]" +
           ",[CategoryImage])" +
           "VALUES" +
           "'"+newCategory.CategoryName+"'" +
           "'"+newCategory.CategoryImage+"',)";
            returnBool = datahandler.Update(sql);
            return returnBool;
        }
        public bool UpdateCategory(Category newCategory)////Generates an sql query based off of the parameter given and sends the newly generated query to the datahandler which will then execute the query and return the results 
        {
            bool returnBool = false;
            sql = "UPDATE [dbo].[Category] SET " +
                "[CategoryName] ='" + newCategory.CategoryName + "' ," +
                "[CategoryImage] = '" + newCategory.CategoryImage + "'" +
                "WHERE [CategoryId]='" + newCategory.CategoryId + "'";
            returnBool = datahandler.Update(sql);
            return returnBool;
        }
        public bool DeleteCategory(Category category)
        //Generates an sql query based off of the parameter given and sends the newly generated query to the datahandler which will then execute the query and return the results 
        {
            bool returnBool = false;
            sql = "DELETE FROM[dbo].[Category] " +
                "WHERE [CategoryId] = '"+category.CategoryId+"'";
            returnBool = datahandler.Update(sql);
            return returnBool;
        }
        #endregion
    }
}
