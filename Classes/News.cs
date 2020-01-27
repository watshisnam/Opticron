using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Opticron.Classes.DataHandler;

namespace Opticron.Classes
{
    public class News
    {
        #region Properties
        private int newsId;
        private string newsImage;
        private string newsDesc;

        
        #endregion

        #region Getters and Setters
        public int NewsId { get => newsId; set => newsId = value; }
        public string NewsImage { get => newsImage; set => newsImage = value; }
        public string NewsDesc { get => newsDesc; set => newsDesc = value; }
        #endregion

        #region Constructors

        public News()
        {
            
        }
        public News(int newsId , string newsImage , string newsDesc)
        {
            this.newsId = newsId;
            this.newsImage = newsImage;
            this.newsDesc = newsDesc;
        }
        #endregion

        #region Methods
        public List<News> SelectAllNews()
        {
            NewsDataHandler datahandler = new NewsDataHandler();
            return datahandler.SelectAllNews();
        }
        public void SelectNewsByID()
        {
            NewsDataHandler datahandler = new NewsDataHandler();
            News temp = datahandler.SelectNewsByID(this);
            this.newsId = temp.newsId;
            this.newsImage = temp.newsImage;
            this.newsDesc = temp.newsDesc;
        }
        public bool InsertNewNews()
        {
            NewsDataHandler datahandler = new NewsDataHandler();
            return datahandler.InsertNewNews(this);
        }
        public bool UpdateNews()
        {
            NewsDataHandler datahandler = new NewsDataHandler();
            return datahandler.UpdateNews(this);
        }
        public bool DeleteNews()
        {
            NewsDataHandler datahandler = new NewsDataHandler();
            return datahandler.DeleteNews(this);
        }
        #endregion
    }
}
