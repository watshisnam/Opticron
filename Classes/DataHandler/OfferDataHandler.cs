using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Opticron.Classes.DataHandler
{
    public class OfferDataHandler
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
        public OfferDataHandler()
        {
            datahandler = new Datahandler();
        }
        #endregion

        #region Methods
        public List<Offer> SelectAllOffer()//Generates a sql query and sends it to the datahander to run the query on the database. Gets the returned list of object arrays and extracts the data and puts it into a structured formate of an obejct.
        {
            List<Offer> returnList = new List<Offer>();
            sql = "SELECT * FROM[dbo].[Offer]";
            List<object[]> tempList = datahandler.Select(sql);
            foreach (object[] item in tempList)
            {
                Offer temp = new Offer((int)item[0], (string)item[1], (string)item[2], new Product((int)item[3], "", "", "", new Category()));
                temp.OfferProd.SelectProductByID();
                returnList.Add(temp);
            }
            return returnList;
        }
        public Offer SelectOfferByID(Offer offer)//Generates a sql query and sends it to the datahander to run the query on the database. Gets the returned list of object arrays and extracts the data and puts it into a structured formate of an obejct.
        {
            Offer returnItem = new Offer();
            sql = "SELECT * FROM[dbo].[Offer]  WHERE [OfferId] ='" + offer.OfferId + "'";
            object[] item = datahandler.Select(sql)[0];
            returnItem = new Offer((int)item[0], (string)item[1], (string)item[2], new Product((int)item[3], "", "", "", new Category()));
            returnItem.OfferProd.SelectProductByID();

            return returnItem;
        }

        public bool InsertNewOffer(Offer newOffer)//Generates an sql query based off of the parameter given and sends the newly generated query to the datahandler which will then execute the query and return the results 

        {
            bool returnBool = false;
            sql = "INSERT INTO [dbo].[Offer]" +
           "([OfferTitle]" +
           ",[OfferDesc]," +
           "[OfferProd])" +
           "VALUES" +
           "'" + newOffer.OfferTitle + "'" +
            "'" + newOffer.OfferDesc + "'" +
           "'" + newOffer.OfferProd.ProductId+ "',)";
            returnBool = datahandler.Update(sql);
            return returnBool;
        }
        public bool UpdateOffer(Offer newOffer)////Generates an sql query based off of the parameter given and sends the newly generated query to the datahandler which will then execute the query and return the results 
        {
            bool returnBool = false;
            sql = "UPDATE [dbo].[Offer] SET " +
                "[OfferTitle] ='" + newOffer.OfferTitle + "' ," +
                "[OfferDesc] = '" + newOffer.OfferDesc + "' ," +
                "[OfferProd] = '" + newOffer.OfferProd.ProductId + "'" +
                "WHERE [OfferId]='" + newOffer.OfferId + "'";
            returnBool = datahandler.Update(sql);
            return returnBool;
        }
        public bool DeleteOffer(Offer offer)
        //Generates an sql query based off of the parameter given and sends the newly generated query to the datahandler which will then execute the query and return the results 
        {
            bool returnBool = false;
            sql = "DELETE FROM[dbo].[Offer] " +
                "WHERE [OfferId] = '" + offer.OfferId+ "'";
            returnBool = datahandler.Update(sql);
            return returnBool;
        }
        #endregion
    }
}
