using Microsoft.EntityFrameworkCore.Infrastructure;
using Simplecrud.Context;
using Simplecrud.Models;

namespace Simplecrud.Repository
{
    public class ItemRepository : IItemRepository
    {
        private readonly AppDbContext _context;

        public ItemRepository(AppDbContext context)
        {
            _context = context;
        }

        public IEnumerable<ItemModel> GetAllItems()
        {
            return _context.Items.ToList();
        }

        public ItemModel GetItemById(int id)
        {
            return _context.Items.FirstOrDefault(x => x.Id == id);
        }

        public void CreateItem(ItemModel item)
        {
            if (item != null)
            {
                _context.Add(item);
                _context.SaveChanges();
            }
        }

        public void UpdateItem(ItemModel item)
        {
            var existingItem = _context.Items.Find(item.Id);
            if (existingItem != null)
            {
                _context.Entry(existingItem).CurrentValues.SetValues(item);
                _context.SaveChanges();
            }
        }
        public void DeleteItem(int id)
        {
            var item = GetItemById(id);

            if (item != null)
            {
                _context.Remove(item);
                _context.SaveChanges();
            }
        }

        
    }
}
