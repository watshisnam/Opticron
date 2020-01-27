using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Opticron.Classes.DataHandler;

namespace Opticron.Classes
{
    public class Offer
    {
        #region Properties
        private int offerId;
        private string offerTitle;
        private string offerDesc;
        private Product offerProd;

        #endregion

        #region Getters and Setters
        public int OfferId { get => offerId; set => offerId = value; }
        public string OfferTitle { get => offerTitle; set => offerTitle = value; }
        public string OfferDesc { get => offerDesc; set => offerDesc = value; }
        public Product OfferProd { get => offerProd; set => offerProd = value; }
        #endregion

        #region Constructors
        public Offer()
        {
               
        }
        public Offer(int offerId,string offerTitle,string offerDesc,Product offerProd)
        {
            this.offerId = offerId;
            this.offerTitle = offerTitle;
            this.offerDesc = offerDesc;
            this.offerProd = offerProd;
        }
        #endregion

        #region Methods
        public List<Offer> SelectAllOffers()
        {
            OfferDataHandler datahandler = new OfferDataHandler();
            return datahandler.SelectAllOffer();
        }
        public void SelectOfferByID()
        {
            OfferDataHandler datahandler = new OfferDataHandler();
            Offer temp = datahandler.SelectOfferByID(this);
            this.offerId = temp.offerId;
            this.offerTitle = temp.offerTitle;
            this.offerDesc = temp.offerDesc;
            this.offerProd = temp.offerProd;
        }
        public bool InsertNewOffer()
        {
            OfferDataHandler datahandler = new OfferDataHandler();
            return datahandler.InsertNewOffer(this);
        }
        public bool UpdateOffer()
        {
            OfferDataHandler datahandler = new OfferDataHandler();
            return datahandler.UpdateOffer(this);
        }
        public bool DeleteOffer()
        {
            OfferDataHandler datahandler = new OfferDataHandler();
            return datahandler.DeleteOffer(this);
        }
        #endregion
    }
}

