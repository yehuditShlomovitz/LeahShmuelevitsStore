using Entities;

namespace Repositories
{
    public interface IRatingRepository
    {
        Task<Rating> addRaeting(Rating rating);
    }
}