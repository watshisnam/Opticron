using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Opticron.Classes.DataHandler
{
    public class ProductDataHandler
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
        public ProductDataHandler()
        {
            datahandler = new Datahandler();
        }
        #endregion

        #region Methods
        public List<Product> SelectAllProducts()//Generates a sql query and sends it to the datahander to run the query on the database. Gets the returned list of object arrays and extracts the data and puts it into a structured formate of an obejct.
        {
            List<Product> returnList = new List<Product>();
            sql = "SELECT * FROM[dbo].[Product]";
            List<object[]> tempList = datahandler.Select(sql);
            foreach (object[] item in tempList)
            {
                Product temp = new Product((int)item[0], (string)item[1], (string)item[2], (string)item[3], new Category((int)item[4], "", ""));
                temp.ProductCategory.SelectCaregoryByID();
                returnList.Add(temp);

            }
            return returnList;
        }
        public Product SelecProductByID(Product product)//Generates a sql query and sends it to the datahander to run the query on the database. Gets the returned list of object arrays and extracts the data and puts it into a structured formate of an obejct.
        {
            Product returnItem = new Product();
            sql = "SELECT * FROM[dbo].[Product]  WHERE [ProductId] ='" + product.ProductId+ "'";
            object[] item = datahandler.Select(sql)[0];
            returnItem = new Product((int)item[0], (string)item[1], (string)item[2], (string)item[3], new Category((int)item[4], "", ""));
            returnItem.ProductCategory.SelectCaregoryByID();
            return returnItem;
        }

        public bool InsertNewProduct(Product product)//Generates an sql query based off of the parameter given and sends the newly generated query to the datahandler which will then execute the query and return the results 
        {
            bool returnBool = false;
            sql = "INSERT INTO [dbo].[Product]([ProductImage],[ProductName],[ProductDesc],ProdCategory])" +
                "VALUES('"+product.ProductImage+"'," +
                "'"+product.ProductName+"'," +
                "'"+product.ProductDesc+"'," +
                "'"+product.ProductCategory.CategoryId+"')";
            returnBool = datahandler.Update(sql);
            return returnBool;
        }
        public bool UpdateProduct(Product newProduct)
        //Generates an sql query based off of the parameter given and sends the newly generated query to the datahandler which will then execute the query and return the results 
        {
            bool returnBool = false;
            sql = "UPDATE [dbo].[Product]" +
                "SET[ProductImage] = '"+newProduct.ProductImage+"'," +
                "[ProductName] = '"+ newProduct.ProductName + "'," +
                "[ProductDesc] = '"+ newProduct.ProductDesc+ "'," +
                "[ProdCategory] = '"+ newProduct.ProductCategory.CategoryId+ "' " +
                "WHERE [ProductId]= '"+ newProduct.ProductId + "'";
            returnBool = datahandler.Update(sql);
            return returnBool;
        }
        public bool DeleteProduct(Product product)
        //Generates an sql query based off of the parameter given and sends the newly generated query to the datahandler which will then execute the query and return the results 
        {
            bool returnBool = false;
            sql = "DELETE FROM [dbo].[Product] " +
                "WHERE[ProductId] = '"+ product.ProductId + "'";
            returnBool = datahandler.Update(sql);
            return returnBool;
        }
        #endregion
    }
}

