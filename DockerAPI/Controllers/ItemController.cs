using DockerAPI.Models;
using DockerAPI.Repositories;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace DockerAPI.Controllers
{
    [ApiController]
    public class ItemController : ControllerBase
    {
        private readonly IItemRepository _itemRepository;

        public ItemController(IItemRepository itemRepository)
        {
            this._itemRepository = itemRepository;
        }

        [HttpGet("item")]
        public async Task<Item> GetItem()
        {
            return await _itemRepository.GetItem();
        }

        [HttpPost("item")]
        public async Task PostItem([FromBody]Item item)
        {
            await _itemRepository.SaveItem(item);
        }
    }
}
