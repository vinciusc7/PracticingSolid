using Simplecrud.Models;
using Simplecrud.Repository;

namespace Simplecrud.Services
{
    public class ItemServices : IItemServices
    {
        private readonly IItemRepository _itemRepository;

        public ItemServices(IItemRepository itemRepository)
        {
            _itemRepository = itemRepository;
        }

        public IEnumerable<ItemModel> GetAllItems() => _itemRepository.GetAllItems();
        public ItemModel GetItemById(int id) => _itemRepository.GetItemById(id);
        public void CreateItems(ItemModel item) => _itemRepository.CreateItem(item);
        public void UpdateItems(ItemModel item) => _itemRepository.UpdateItem(item);
        public void DeleteItems(int id) => _itemRepository.DeleteItem(id);
    }
}
