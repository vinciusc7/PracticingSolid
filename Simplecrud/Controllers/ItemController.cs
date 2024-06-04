using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Simplecrud.Models;
using Simplecrud.Services;

namespace Simplecrud.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class ItemController : ControllerBase
    {
        private readonly IItemServices _itemServices;

        public ItemController(IItemServices itemServices)
        {
            _itemServices = itemServices;
        }

        [HttpGet("GetAllItems")]
        public ActionResult<IEnumerable<ItemModel>> GetAllItems()
        {
            var items = _itemServices.GetAllItems();
            return Ok(items);
        }
        [HttpGet("{id:int}")]
        public ActionResult<ItemModel> GetItemById(int id)
        {
            if (id == null)
            {
                return BadRequest("Informe o id do item");
            }
            ItemModel item = _itemServices.GetItemById(id);
            if (item == null)
            {
                return NotFound("Nenhum item encontrado");
            }
            return Ok(item);
        }
        [HttpPost("CreateItem")]
        public ActionResult CreateItem(ItemModel item)
        {
            if (item is null)
            {
                return BadRequest("Cadastre o item corretamente");
            }
            _itemServices.CreateItems(item);
            return CreatedAtAction(nameof(GetItemById), new { id = item.Id }, item);
        }
        [HttpPut("UpdateItem")]
        public ActionResult UpdateItem(int id, ItemModel item)
        {
            ItemModel existingItem = _itemServices.GetItemById(id);
            if (existingItem == null)
            {
                return NotFound("O item não foi encontrado");
            }
            _itemServices.UpdateItems(item);
            return Ok("Item alterado");
        }
        [HttpDelete("DeleteItem")]
        public ActionResult DeleteItem(int id)
        {
            ItemModel existingItem = _itemServices.GetItemById(id);
            if (existingItem is null)
            {
                return NotFound("O item não foi encontrado");
            }
            _itemServices.DeleteItems(id);
            return Ok("Item deletado");
        }
    }
}
