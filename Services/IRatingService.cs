using Entities;

namespace Services
{
    public interface IRatingService
    {
        Task<Rating> addRaeting(Rating rating);
    }
}