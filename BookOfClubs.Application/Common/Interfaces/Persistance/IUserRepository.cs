using BookOfClubs.Domain.Entities;

namespace BookOfClubs.Application.Common.Interfaces.Persistance
{
    public interface IUserRepository
    {
        User? GetUserByEmail(string email);
        void Add(User user);
    }
}
