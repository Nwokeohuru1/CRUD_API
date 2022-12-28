using UserAPI.Data;
using UserAPI.Data.Models;

using UserAPI.Repositories.Interface;

namespace UserAPI.Repositories
{
    public class ItemRepository : IItemRepository
    {
        private readonly UserDbContext _dbContext;

        public ItemRepository(UserDbContext dbContext)
        {
                _dbContext= dbContext;
        }
        public bool CreateItem(Item item)
        {
            try
            {
                _dbContext.Add(item);
                _dbContext.SaveChanges();//persist(commit) the data
                return true;
            }
            catch (Exception ex)
            {

                Console.WriteLine($"error is {ex}");
            }
            return false;
        }

        public bool DeleteItem(int id)
        {
            //var items = new Item();
            try
            {
                var item = GetItem(id);
                //var item = _dbContext.Items;

                if (item==null)
                {
                    return false;
                }
                item.DelFlag = true;

                _dbContext.Update(item);
                //_dbContext.Items.Update(item);
                _dbContext.SaveChanges();
                return true;
            }
            catch (Exception ex)
            {

                Console.WriteLine($"error is {ex}");
            }
            return false;

        }

        public List<Item> GetItems()
        {
            var items = new List<Item>();
            try
            {
                
                items = _dbContext.Items.Where(i=>i.DelFlag==false).ToList();
                return items;
            }
            catch (Exception ex)
            {

                Console.WriteLine($"error is {ex}");
            }
            return items; 
        }

        public Item GetItem(int id)
        {
            var items = new Item();
            try
            {

                items = _dbContext.Items.Where(i => i.DelFlag==false && i.Id==id).FirstOrDefault();
                return items;
            }
            catch (Exception ex)
            {

                Console.WriteLine($"error is {ex}");
            }
            return items;

        }

        public bool UpdateItem(int id, Item item)
        {
                   
            try
            {
                //var item1 = GetItem(item.Id);
               var item1 = _dbContext.Items.Where(i => i.Id == item.Id);
                if (item1 == null)
                {
                    return false;
                }
                
                _dbContext.Update(item);
                _dbContext.SaveChanges();
                return true;
            }
            catch (Exception ex)
            {

                Console.WriteLine($"error is {ex}");
            }
            return false;
        }
    }
}
