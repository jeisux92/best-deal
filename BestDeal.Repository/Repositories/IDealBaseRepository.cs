namespace BestDeal.Repository.Repositories;

public interface IDealBaseRepository<out T> where T : class
{
    IEnumerable<T> GetProductsByNameAndPrice(string name, double value);
}