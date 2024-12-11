using Domain.Identity;
using Microsoft.EntityFrameworkCore;
using Repository.Interface;



namespace Repository.Implementation
{
    public class UserRepository : IUserRepository
    {
        private readonly ApplicationDbContext _context;
        private Microsoft.EntityFrameworkCore.DbSet<BookStoreApplicationUser> entities;
        string errorMessage = string.Empty;

        public UserRepository(ApplicationDbContext context)
        {
            _context = context;
            entities = context.Set<BookStoreApplicationUser>();
            //entities = context.Set<BookStoreApplicationUser>();
        }

        public IEnumerable<BookStoreApplicationUser> GetAll()
        {
            return entities.AsEnumerable();
        }

        public BookStoreApplicationUser Get(string id)
        {
            return entities
               .Include(z => z.ShoppingCart)
               .Include("ShoppingCart.BooksInShoppingCarts")
               .Include("ShoppingCart.BooksInShoppingCarts.Book")
               .SingleOrDefault(s => s.Id == id);
        }

        public void Insert(BookStoreApplicationUser entity)
        {
            if (entity == null)
            {
                throw new ArgumentNullException("entity");
            }
            entities.Add(entity);
            context.SaveChanges();
        }

        public void Update(BookStoreApplicationUser entity)
        {
            if (entity == null)
            {
                throw new ArgumentNullException("entity");
            }
            entities.Update(entity);
            context.SaveChanges();
        }

        public void Delete(BookStoreApplicationUser entity)
        {
            if (entity == null)
            {
                throw new ArgumentNullException("entity");
            }
            entities.Remove(entity);
            context.SaveChanges();
        }

        IEnumerable<BookStoreApplicationUser> IUserRepository.GetAll()
        {
            throw new NotImplementedException();
        }

        BookStoreApplicationUser IUserRepository.Get(string? id)
        {
            throw new NotImplementedException();
        }

        public void Insert(T entity)
        {
            if (entity == null)
            {
                throw new ArgumentNullException("entity");
            }
            entities.Add(entity);
            context.SaveChanges();
        }

        public void Update(T entity)
        {
            if (entity == null)
            {
                throw new ArgumentNullException("entity");
            }
            entities.Update(entity);
            context.SaveChanges();
        }

        public void Delete(T entity)
        {
            if (entity == null)
            {
                throw new ArgumentNullException("entity");
            }
            entities.Remove(entity);
            context.SaveChanges();
        }
    }
}