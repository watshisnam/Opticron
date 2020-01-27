using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Opticron.Classes.DataHandler
{
    public class EventDataHandler
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
        public EventDataHandler()
        {
            datahandler = new Datahandler();
        }
        #endregion

        #region Methods
        public List<Event> SelectAllEvents()//Generates a sql query and sends it to the datahander to run the query on the database. Gets the returned list of object arrays and extracts the data and puts it into a structured formate of an obejct.
        {
            List<Event> returnList = new List<Event>();
            sql = "SELECT * FROM[dbo].[Event]";
            List<object[]> tempList = datahandler.Select(sql);
            foreach (object[] item in tempList)
            {
                returnList.Add(new Event((int)item[0], (string)item[1], (string)item[2]));
            }
            return returnList;
        }
        public Event SelectEventByID(Event events)//Generates a sql query and sends it to the datahander to run the query on the database. Gets the returned list of object arrays and extracts the data and puts it into a structured formate of an obejct.
        {
            Event returnItem = new Event();
            sql = "SELECT * FROM[dbo].[Event]  WHERE [EventId] ='" + events.EventId + "'";
            object[] item = datahandler.Select(sql)[0];
            returnItem = new Event((int)item[0], (string)item[1], (string)item[2]);

            return returnItem;
        }

        public bool InsertNewEvent(Event newEvent)//Generates an sql query based off of the parameter given and sends the newly generated query to the datahandler which will then execute the query and return the results 

        {
            bool returnBool = false;
            sql = "INSERT INTO [dbo].[Event]" +
           "([EventDesc]" +
           ",[EventImage])" +
           "VALUES" +
           "'" + newEvent.EventDesc + "'" +
           "'" + newEvent.EventImage + "',)";
            returnBool = datahandler.Update(sql);
            return returnBool;
        }
        public bool UpdateEvent(Event newEvent)////Generates an sql query based off of the parameter given and sends the newly generated query to the datahandler which will then execute the query and return the results 
        {
            bool returnBool = false;
            sql = "UPDATE [dbo].[Event] SET " +
                "[EventDesc] ='" + newEvent.EventDesc + "' ," +
                "[EventImage] = '" + newEvent.EventImage + "'" +
                "WHERE [EventId]='" + newEvent.EventId + "'";
            returnBool = datahandler.Update(sql);
            return returnBool;
        }
        public bool DeleteEvent(Event events)
        //Generates an sql query based off of the parameter given and sends the newly generated query to the datahandler which will then execute the query and return the results 
        {
            bool returnBool = false;
            sql = "DELETE FROM[dbo].[Event] " +
                "WHERE [EventId] = '" + events.EventId+ "'";
            returnBool = datahandler.Update(sql);
            return returnBool;
        }
        #endregion
    }
}
