using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Opticron.Classes.DataHandler;

namespace Opticron.Classes
{
    public class Category
    {
        #region properties
        private int categoryId;
        private string categoryName;
        private string categoryImage;
        #endregion

        #region Getter and Setters
        public int CategoryId { get => categoryId; set => categoryId = value; }
        public string CategoryName { get => categoryName; set => categoryName = value; }
        public string CategoryImage { get => categoryImage; set => categoryImage = value; }
        #endregion

        #region Constructors
        public Category()
        {

        }

        public Category(int categoryId , string categoryName, string categoryImage)
        {
            this.categoryId = categoryId;
            this.categoryName = categoryName;
            this.categoryImage = categoryImage;
            
        }
        #endregion

        #region Methods
        public List<Category> SelectAllCategoies()
        {
            CategoryDataHandler datahandler = new CategoryDataHandler();
            return datahandler.SelectAllCategories();
        }
        public void SelectCaregoryByID()
        {
            CategoryDataHandler datahandler = new CategoryDataHandler();
            Category temp = datahandler.SelectCategoryByID(this);
            this.categoryId = temp.categoryId;
            this.categoryImage = temp.categoryImage;
            this.categoryName = temp.categoryName;
        }
        public bool InsertNewCategory()
        {
            CategoryDataHandler datahandler = new CategoryDataHandler();
            return datahandler.InsertNewCategory(this);
        }
        public bool UpdateCategory()
        {
            CategoryDataHandler datahandler = new CategoryDataHandler();
            return datahandler.UpdateCategory(this);
        }
        public bool DeleteCategory()
        {
            CategoryDataHandler datahandler = new CategoryDataHandler();
            return datahandler.DeleteCategory(this);
        }
        #endregion
    }
}
