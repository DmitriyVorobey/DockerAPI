using System.Threading.Tasks;
using DockerAPI.Models;

namespace DockerAPI.Repositories
{
    public interface IItemRepository
    {
        Task<Item> GetItem();
        Task SaveItem(Item item);
    }
}