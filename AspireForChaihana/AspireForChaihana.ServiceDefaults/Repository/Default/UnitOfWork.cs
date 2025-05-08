using System.Data.Entity;
using WebApplication1.DataBase;
using WebApplication1.DataBase_and_more;

namespace WebApplication1.Repository.Default
{
	public class UnitOfWork : IUnitOfWork
	{
		protected readonly WebDbForCustomers _context;

		public UnitOfWork(WebDbForCustomers context)
		{
			_context = context;
			Carts = new CartRepository(_context);
			Addresses = new AddressRepository(_context);
			Orders = new OrderRepository(_context);
			CartElements = new CartElementRepository(_context);
			Users = new UserRepository(_context);
			Products = new ProductRepository(_context);
			Categories = new CategoryRepository(_context);
			Bookings = new BookingRepository(_context);
		}

		/*public UnitOfWork(
		WebDbForCustomers context,
		CartRepository cartRepository,
		AddressRepository addressRepository,
		OrderRepository orderRepository,
		CartElementRepository cartElementRepository,
		UserRepository userRepository,
		ProductRepository productRepository,
		CategoryRepository categoryRepository,
		BookingRepository bookingRepository)
		{
			_context = context;
			Carts = cartRepository;
			Addresses = addressRepository;
			Orders = orderRepository;
			CartElements = cartElementRepository;
			Users = userRepository;
			Products = productRepository;
			Categories = categoryRepository;
			Bookings = bookingRepository;
		}*/

		public CartRepository Carts { get; }
		public AddressRepository Addresses { get; }
		public OrderRepository Orders { get; }
		public CartElementRepository CartElements { get; }
		public UserRepository Users { get; }
		public ProductRepository Products { get; }
		public CategoryRepository Categories { get; }
		public BookingRepository Bookings { get; }

		public async Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
		{
			return await _context.SaveChangesAsync(cancellationToken);
		}

		public void Dispose()
		{
			_context.Dispose();
		}
	}
}
