using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Opticron.Classes.DataHandler;

namespace Opticron.Classes
{
    public class Event
    {
        #region Properties
        private int eventId;
        private string eventImage;
        private string eventDesc;        
        #endregion

        #region Getters and Setters
        public int EventId { get => eventId; set => eventId = value; }
        public string EventImage { get => eventImage; set => eventImage = value; }
        public string EventDesc { get => eventDesc; set => eventDesc = value; }
        #endregion

        #region Constructors
        public Event()
        {

        }

        public Event(int eventId , string eventImage , string eventDesc)
        {
            this.eventId = eventId;
            this.eventImage = eventImage;
            this.eventDesc = eventDesc;
        }
        #endregion

        #region Methods
        public List<Event> SelectAllEvents()
        {
            EventDataHandler datahandler = new EventDataHandler();
            return datahandler.SelectAllEvents();
        }
        public void SelectEventByID()
        {
            EventDataHandler datahandler = new EventDataHandler();
            Event temp = datahandler.SelectEventByID(this);
            this.eventId = temp.eventId;
            this.eventImage = temp.eventImage;
            this.eventDesc = temp.eventDesc;
        }
        public bool InsertNewEvent()
        {
            EventDataHandler datahandler = new EventDataHandler();
            return datahandler.InsertNewEvent(this);
        }
        public bool UpdateEvent()
        {
            EventDataHandler datahandler = new EventDataHandler();
            return datahandler.UpdateEvent(this);
        }
        public bool DeleteEvent()
        {
            EventDataHandler datahandler = new EventDataHandler();
            return datahandler.DeleteEvent(this);
        }
        #endregion
    }
}
