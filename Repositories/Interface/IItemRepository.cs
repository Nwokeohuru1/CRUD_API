using UserAPI.Data.Models;

namespace UserAPI.Repositories.Interface
{
    public interface IItemRepository
    {
        List<Item> GetItems();
        Item GetItem(int id);
        bool CreateItem(Item item);
        bool UpdateItem(int id, Item item);
        bool DeleteItem(int id);

    }
}
