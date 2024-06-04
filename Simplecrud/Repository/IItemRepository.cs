using Simplecrud.Models;

namespace Simplecrud.Repository
{
    public interface IItemRepository
    {
        IEnumerable<ItemModel> GetAllItems();
        ItemModel GetItemById(int id);
        void CreateItem(ItemModel item);
        void UpdateItem(ItemModel item);
        void DeleteItem(int id);

    }
}
