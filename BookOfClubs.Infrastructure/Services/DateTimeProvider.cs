using BookOfClubs.Application.Common.Interfaces.Services;

namespace BookOfClubs.Infrastructure.Services
{
    public class DateTimeProvider : IDateTimeProvider
    {
        public DateTimeOffset Now => DateTimeOffset.Now;
    }
}
