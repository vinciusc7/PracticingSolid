using Simplecrud.Models;

namespace Simplecrud.Services
{
    public interface IItemServices
    {
        IEnumerable<ItemModel> GetAllItems();
        ItemModel GetItemById(int id);
        void CreateItems(ItemModel item);
        void UpdateItems(ItemModel item);
        void DeleteItems(int id);
    }
}
