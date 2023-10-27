namespace EFPROJECT1.Models
{
    public interface IProductRepository
    {
        Product GetById(int productID);
        List<Product> Products { get; }

        void CreateProduct (Product product);
        
        void UpdateProduct (Product product);

        void DeleteProduct (int ProductID);
    }
    public class ProductRepository : IProductRepository
    {
        private ProductContext _db;

        public ProductRepository(ProductContext db)
        {
            _db = db;
        }


        public List<Product> Products
        {
                 get { return _db.Products.ToList(); }
        }

        public void CreateProduct(Product product)
        {
           _db.Products.Add(product);
            _db.SaveChanges();
        }

        public void DeleteProduct(int ProductID)
        {
            var Product= GetById(ProductID);

            if(Product != null) {

                _db.Products.Remove(Product);
                _db.SaveChanges();
            }
        }

        public Product GetById(int productID)
        {
            return _db.Products.FirstOrDefault(p => p.ProductID == productID);
        }

        public void UpdateProduct(Product product)
        {
            _db.Products.Update(product);
            _db.SaveChanges();  
        }
    }
}
