using CrudInterfaces;
using Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chapter8Basis
{
    public class ItemController<TEntity>
    {
        private readonly IRead<Item> reader;
        private readonly ISave<Item> saver;
        private readonly IDelete<Item> deleter;

        public OrderController(IRead<Item> orderReader, ISave<Item> orderSaver, IDelete<Item> orderDeleter)
        {
            reader = orderReader;
            saver = orderSaver;
            deleter = orderDeleter;
        }

        public void CreateOrder(Item item)
        {
            saver.Save(item);
            Console.WriteLine("CreateItem: Saving item of " + item.product);
        }

        public Item GetSingleOrder(Guid identity)
        {
            Item item = reader.ReadOne(identity);
            Console.WriteLine("GetSingleOrder: Saving item of " + item.product);
            return item;
        }

        public void UpdateOrder(Item item)
        {
            saver.Save(item);
            Console.WriteLine("UpdateOrder: Saving item of " + item.product);
        }

        public void DeleteOrder(Item item)
        {
            deleter.Delete(item);
            Console.WriteLine("DeleteOrder: Delete item of " + item.product);
        }
    }
}