using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Opticron.Classes.DataHandler
{
    public class NewsDataHandler
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
        public NewsDataHandler()
        {
            datahandler = new Datahandler();
        }
        #endregion

        #region Methods
        public List<News> SelectAllNews()//Generates a sql query and sends it to the datahander to run the query on the database. Gets the returned list of object arrays and extracts the data and puts it into a structured formate of an obejct.
        {
            List<News> returnList = new List<News>();
            sql = "SELECT * FROM[dbo].[News]";
            List<object[]> tempList = datahandler.Select(sql);
            foreach (object[] item in tempList)
            {
                returnList.Add(new News((int)item[0], (string)item[1], (string)item[2]));
            }
            return returnList;
        }
        public News SelectNewsByID(News news)//Generates a sql query and sends it to the datahander to run the query on the database. Gets the returned list of object arrays and extracts the data and puts it into a structured formate of an obejct.
        {
            News returnItem = new News();
            sql = "SELECT * FROM[dbo].[News]  WHERE [NewsId] ='" + news.NewsId+ "'";
            object[] item = datahandler.Select(sql)[0];
            returnItem = new News((int)item[0], (string)item[1], (string)item[2]);

            return returnItem;
        }

        public bool InsertNewNews(News newNews)//Generates an sql query based off of the parameter given and sends the newly generated query to the datahandler which will then execute the query and return the results 

        {
            bool returnBool = false;
            sql = "INSERT INTO [dbo].[News]" +
           "([NewsDesc]" +
           ",[NewsImage])" +
           "VALUES" +
           "'" + newNews.NewsDesc+ "'" +
           "'" + newNews.NewsImage + "',)";
            returnBool = datahandler.Update(sql);
            return returnBool;
        }
        public bool UpdateNews(News newNews)////Generates an sql query based off of the parameter given and sends the newly generated query to the datahandler which will then execute the query and return the results 
        {
            bool returnBool = false;
            sql = "UPDATE [dbo].[News] SET " +
                "[NewsDesc] ='" + newNews.NewsDesc+ "' ," +
                "[NewsImage] = '" + newNews.NewsImage + "'" +
                "WHERE [NewsId]='" + newNews.NewsId + "'";
            returnBool = datahandler.Update(sql);
            return returnBool;
        }
        public bool DeleteNews(News news)
        //Generates an sql query based off of the parameter given and sends the newly generated query to the datahandler which will then execute the query and return the results 
        {
            bool returnBool = false;
            sql = "DELETE FROM[dbo].[News] " +
                "WHERE [NewsId] = '" + news.NewsId+ "'";
            returnBool = datahandler.Update(sql);
            return returnBool;
        }
        #endregion
    }
}
