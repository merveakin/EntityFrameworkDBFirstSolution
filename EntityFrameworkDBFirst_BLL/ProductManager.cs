using EntityFrameworkDBFirst_BLL.ViewModels;
using EntityFrameworkDBFirst_DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityFrameworkDBFirst_BLL
{
    public class ProductManager
    {
        //GLOBAL ALAN 
        NORTHWNDEntities myDBContext = new NORTHWNDEntities();
        public List<ProductViewModels> TumUrunleriGetir()
        {
            List<ProductViewModels> urunler = new List<ProductViewModels>();
            var data = myDBContext.Products.ToList();

            foreach (var item in data)
            {
                ProductViewModels p = new ProductViewModels()
                {
                    CategoryID = item.CategoryID,
                    ProductID = item.ProductID,
                    UnitPrice = item.UnitPrice,
                    UnitsInStock = item.UnitsInStock,
                    Discontinued = item.Discontinued,
                    UnitsOnOrder = item.UnitsOnOrder,
                    ReorderLevel = item.ReorderLevel,
                    SupplierID = item.SupplierID,
                    ProductName = item.ProductName,
                    QuantityPerUnit = item.QuantityPerUnit
                };

                //CategoryName
                //1.YOL
              //  p.CategoryName = item.Categories.CategoryName;


                //2.YOL
                p.CategoryName = myDBContext.Categories.FirstOrDefault(x => x.CategoryID == item.CategoryID)?.CategoryName;

                urunler.Add(p);
            }

            return urunler;
        }


        //deneme button1 oluşturuldu.

        //public bool YeniUrunEkle(ProductViewModels p)
        //{
        //    bool sonuc = false;
        //    Products newProduct = new Products
        //    {
        //        ProductName = p.ProductName,
        //        Discontinued = p.Discontinued,
        //        CategoryID = p.CategoryID
        //    };

        //    myDBContext.Products.Add(newProduct);
        //    int affectedRows = myDBContext.SaveChanges();
        //    if (affectedRows > 0)
        //    {
        //        sonuc = true;
        //    }

        //    return sonuc;
        //}

    }
}
