using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using UserAPI.Data.Models;
using UserAPI.Repositories.Interface;

namespace UserAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ItemsController : ControllerBase
    {
        public readonly IItemRepository _itemRepository;
        public ItemsController(IItemRepository itemRepository)
        {
            _itemRepository= itemRepository;
        }
        [HttpGet]
        [Route("All")]
        public IActionResult GetItems() 
        {
            var items = _itemRepository.GetItems();  
            return Ok(items);
        }

        [HttpGet]
        [Route("Id")]
        public IActionResult GetItem(int id)
        {
            var item = _itemRepository.GetItem(id);
            if (item==null)
            {
                return NoContent();
            }
            return Ok(item);

        }
        [HttpPost]
        [Route("Create")]
        public IActionResult CreateItem(Item item)
        {
            bool result = _itemRepository.CreateItem(item);
            if (!result)

            {
                return StatusCode(StatusCodes.Status400BadRequest, "something went wrong, please contact administrator");
            }
            return StatusCode(StatusCodes.Status201Created, "successfully created");
        }

        [HttpPost]
        [Route("Update")]
        public IActionResult ModifyItem(int id, Item item)
        {
            bool result = _itemRepository.UpdateItem(id,item);
            if (!result)

            {
                return StatusCode(StatusCodes.Status400BadRequest, "Item not found");
            }
            return StatusCode(StatusCodes.Status200OK, "successfully Updated");
        }



        [HttpPost]
        [Route("Delete")]
        public IActionResult DeleteItem(int id)
        {
            bool result = _itemRepository.DeleteItem(id);
            if (!result)

            {
                return StatusCode(StatusCodes.Status404NotFound, "Item not found");
            }
            return StatusCode(StatusCodes.Status200OK, "successfully Deleted");
        }
    }
}
