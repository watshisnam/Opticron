using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Opticron.Classes.DataHandler;

namespace Opticron.Classes
{
    public class Product
    {
        #region Properties
        private int productId;
        private string productImage;
        private string productName;
        private string productDesc;
        private Category productCategory;
        #endregion 

        #region Getters and Setters
        public int ProductId { get => productId; set => productId = value; }
        public string ProductImage { get => productImage; set => productImage = value; }
        public string ProductName { get => productName; set => productName = value; }
        public string ProductDesc { get => productDesc; set => productDesc = value; }
        public Category ProductCategory { get => productCategory; set => productCategory = value; }
        
        #endregion

        #region Constructors
        public Product()
        {
                
        }

        public Product(int productId , string productImage ,string productName, string productDesc , Category productCategory)
        {
            this.productId = productId;
            this.productImage = productImage;
            this.productName = productName;
            this.productDesc = productDesc;
            this.productCategory = productCategory;
        }
        #endregion

        #region Methods
        public List<Product> SelectProduct()
        {
            ProductDataHandler datahandler = new ProductDataHandler();
            return datahandler.SelectAllProducts();
        }
        public void SelectProductByID()
        {
            ProductDataHandler datahandler = new ProductDataHandler();
            Product temp = datahandler.SelecProductByID(this);
            this.productId = temp.productId;
            this.productImage = temp.productImage;
            this.productName = temp.productName;
            this.productDesc = temp.productDesc;
            this.productCategory = temp.productCategory;
        }
        public bool InsertNewProduct()
        {
            ProductDataHandler datahandler = new ProductDataHandler();
            return datahandler.InsertNewProduct(this);
        }
        public bool UpdateProduct()
        {
            ProductDataHandler datahandler = new ProductDataHandler();
            return datahandler.UpdateProduct(this);
        }
        public bool DeleteProduct()
        {
            ProductDataHandler datahandler = new ProductDataHandler();
            return datahandler.DeleteProduct(this);
        }
        #endregion
    }
}
