using Microsoft.EntityFrameworkCore;
using solidCsharp.Model;
using System.Linq;

namespace solidCsharp.Repository
{
    public class ProductRepository : BaseReadOnlyRepository<Product, ProductRepository>, IProductRepository
	{
		public ProductRepository(DbContextOptions<ProductRepository> options)
			: base(options)
		{
			var itens = this.Items.ToArray();

			if (itens.Length == 0)
			{
				this.Items.Add(new Product() { Id = "1", Name = "Produto 1", Price = 10 });
				this.Items.Add(new Product() { Id = "2", Name = "Produto 2", Price = 20 });
				this.SaveChanges();
			}
		}

		
	}
}
