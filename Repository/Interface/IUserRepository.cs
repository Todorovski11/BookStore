using Domain.Identity;


namespace Repository.Interface
{
    public interface IUserRepository
    {
        IEnumerable<BookStoreApplicationUser> GetAll();
        BookStoreApplicationUser Get(string? id);
        void Insert(BookStoreApplicationUser entity);
        void Update(BookStoreApplicationUser entity);
        void Delete(BookStoreApplicationUser entity);
    }

}