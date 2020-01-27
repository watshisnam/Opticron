using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Opticron.Classes.DataHandler
{
    public class GalleryDataHandler
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
        public GalleryDataHandler()
        {
            datahandler = new Datahandler();
        }
        #endregion

        #region Methods
        public List<Gallery> SelectAllGallery()//Generates a sql query and sends it to the datahander to run the query on the database. Gets the returned list of object arrays and extracts the data and puts it into a structured formate of an obejct.
        {
            List<Gallery> returnList = new List<Gallery>();
            sql = "SELECT * FROM [Opticron].[dbo].[Gallery]";
            List<object[]> tempList = datahandler.Select(sql);
            foreach (object[] item in tempList)
            {
                Dictionary<int, string> imageList = new Dictionary<int, string>();
                string tempSql = "SELECT * FROM [dbo].[GalleryImage] " +
                    "WHERE [GalleryId] = '"+(int)item[0]+"'";
                List<object[]> temp = datahandler.Select(tempSql);
                foreach (object[] ob in temp)
                {
                    imageList.Add((int)ob[0],(string)ob[1]);
                }
                returnList.Add(new Gallery((int)item[0],(string)item[1],imageList));
            }
            return returnList;
        }
        public Gallery SelectGalleryByID(Gallery gallery)//Generates a sql query and sends it to the datahander to run the query on the database. Gets the returned list of object arrays and extracts the data and puts it into a structured formate of an obejct.
        {
            Gallery returnItem = new Gallery();
            sql = "SELECT [G].[GalleryId],[G].[GalleryDesc],[I].[ImageId],[I].[Image] FROM[dbo].[Gallery]AS[G]INNER JOIN[dbo].[GalleryImage] AS[I] ON[I].[GalleryId] = [G].[GalleryId] " +
                "WHERE[G].[GalleryId] = '"+gallery.GalleryId+"'";
            List<object[]> tempList = datahandler.Select(sql);
            object[] item = tempList[0];
            returnItem = new Gallery((int)item[0], (string)item[1], new Dictionary<int, string>());
            foreach (object[] temp in tempList)
            {
                returnItem.GalleryImage.Add((int)temp[2],(string)temp[3]);
            }


            return returnItem;
        }

        public bool InsertNewGallery(Gallery newGallery)//Generates an sql query based off of the parameter given and sends the newly generated query to the datahandler which will then execute the query and return the results 

        {
            bool returnBool = false;
            sql = "BEGIN TRANSACTION;" +
                "INSERT INTO [dbo].[Gallery]([GalleryDesc]) VALUES('"+newGallery.GalleryDesc+"');" +
                "DECLARE @ID = SCOPE_IDENTITY();" +
                "";
            foreach (KeyValuePair<int,string> item in newGallery.GalleryImage)
            {
                sql +="INSERT INTO [dbo].[GalleryImage]([GalleryId],[Image])" +
                    "VALUES (@ID,'"+item.Value+"'); " +
                    "" ;
            }
            sql += "COOMIT TRANSACTION;";

            returnBool = datahandler.Update(sql);
            return returnBool;
        }
        public bool UpdateGallery(Gallery newGallery)////Generates an sql query based off of the parameter given and sends the newly generated query to the datahandler which will then execute the query and return the results 
        {
            bool returnBool = false;
            sql = "UPDATE [dbo].[Gallery] SET " +
                "[GalleryDesc] = '"+newGallery.GalleryDesc+"'" +
                "WHERE [GalleryId] = '"+newGallery.GalleryId+"'";
            returnBool = datahandler.Update(sql);
            return returnBool;
        }
        public bool UpdateGalleryImages(Gallery gallery)
        {
            bool returnBool = false;
            sql = "DELETE FROM [dbo].[GalleryImage] " +
                "WHERE [GalleryId] = '" + gallery.GalleryId + "'";
            returnBool = datahandler.Update(sql);
            foreach (KeyValuePair<int,string> item in gallery.GalleryImage)
            {
                sql = "INSERT INTO [dbo].[GalleryImage]([GalleryId],[Image])" +
                    "VALUES ('"+gallery.GalleryId+"','" + item.Value + "'); ";
            }
            
            return returnBool;
        }
        public bool DeleteGallery(Gallery gallery)
        //Generates an sql query based off of the parameter given and sends the newly generated query to the datahandler which will then execute the query and return the results 
        {
            bool returnBool = false;
            sql = "DELETE FROM [dbo].[GalleryImage] " +
                "WHERE [GalleryId] = '"+gallery.GalleryId+"'" +
                "DELETE FROM[dbo].[Gallery] " +
                "WHERE [GalleryId] = '" + gallery.GalleryId + "'";
            returnBool = datahandler.Update(sql);
            return returnBool;
        }
        #endregion
    }
}
