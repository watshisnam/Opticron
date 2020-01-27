using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Opticron.Classes.DataHandler;

namespace Opticron.Classes
{
    public class Gallery
    {
        #region Properties
        private int galleryId;
        private string galleryDesc;
        private Dictionary<int, string> galleryImage;

        #endregion

        #region Getters and Setters
        public int GalleryId { get => galleryId; set => galleryId = value; }
        public string GalleryDesc { get => galleryDesc; set => galleryDesc = value; }
        public Dictionary<int,string> GalleryImage { get => galleryImage; set => galleryImage = value; }
        #endregion

        #region Constructors
        public Gallery()
        {

        }
        public Gallery(int galleryId,string galleryDesc, Dictionary<int, string> galleryImage)
        {
            this.galleryId = galleryId;
            this.galleryDesc = galleryDesc;
            this.galleryImage = galleryImage;
        }
        #endregion

        #region Methods
        public List<Gallery> SelectAllGallery()
        {
            GalleryDataHandler datahandler = new GalleryDataHandler();
            return datahandler.SelectAllGallery();
        }
        public void SelectGalleryByID()
        {
            GalleryDataHandler datahandler = new GalleryDataHandler();
            Gallery temp = datahandler.SelectGalleryByID(this);
            this.galleryId = temp.galleryId;
            this.galleryDesc = temp.galleryDesc;
            this.galleryImage = temp.galleryImage;
            
        }
        public bool InsertNewGallery()
        {
            GalleryDataHandler datahandler = new GalleryDataHandler();
            return datahandler.InsertNewGallery(this);

        }
        public bool UpdateGallery()
        {
            GalleryDataHandler datahandler = new GalleryDataHandler();
            return datahandler.UpdateGallery(this);

        }
        public bool UpdateGalleryImages()
        {
            GalleryDataHandler datahandler = new GalleryDataHandler();
            return datahandler.UpdateGalleryImages(this);

        }
        public bool DeleteGallery()
        {
            GalleryDataHandler datahandler = new GalleryDataHandler();
            return datahandler.DeleteGallery(this);

        }
        #endregion
    }
}
