using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using CrudImplementations;
using Model;

namespace Chapter8Basis
{
    class Program
    {
        static void Main(string[] args)
        {
            Guid gid = new Guid("dddddddd-dddd-dddd-dddd-dddddddddddd");
            Order order = new Order();
            order.product = "Paper";
            order.id = gid;
            order.amount = 32;

            Console.WriteLine(order.toString());


            Console.WriteLine("=========CreateSeparateServices=========");
            OrderController sep = CreateSeparateServices();

            //#s 1 & 2 on corresponding Doc.
            sep.CreateOrder(order);
            sep.DeleteOrder(order);
            
            ItemController itmCon = CreateGenericServicesItem();



            Console.WriteLine("=========CreateSingleService=========");
            OrderController sing = CreateSingleService();

            //#s 3 & 4 on corresponding Doc.
            sing.CreateOrder(order);
            sing.DeleteOrder(order);

            Console.WriteLine("=========GenericController<Order>=========");
            GenericController<Order> generic = CreateGenericServices();


            //#5 on corresponding Doc.
            generic.CreateEntity(order);

            Item item = new Item();
            item.product = "Cup";
            item.cost = .06;
            GenericController<Item> genItem = CreateGenericServicesItem();

            Console.WriteLine("Hit any key to quit");
            Console.ReadKey();
        }

        static OrderController CreateSeparateServices()
        {
            var reader = new Reader<Order>();
            var saver = new Saver<Order>();
            var deleter = new Deleter<Order>();
            return new OrderController(reader, saver, deleter);
        }

        static OrderController CreateSingleService()
        {
            var crud = new Crud<Order>();
            return new OrderController(crud, crud, crud);
        }

        static GenericController<Order> CreateGenericServices()
        {
            var reader = new Reader<Order>();
            var saver = new Saver<Order>();
            var deleter = new Deleter<Order>();
            // This must be declared using reflection...
            GenericController<Order> ctl = (GenericController<Order>)Activator.CreateInstance(typeof(GenericController<Order>), reader, saver, deleter);
            //This does not work 
            //GenericController<Order> ctl = new GenericController(reader, saver, deleter);
            return ctl;
        }

        
        //#6 in corresponding Doc.
        static GenericController<Item> CreateGenericServicesItem()
        {
            var reader = new Reader<Item>();
            var saver = new Saver<Item>();
            var deleter = new Deleter<Item>();
            // This must be declared using reflection...
            GenericController<Item> ctl = (GenericController<Item>)Activator.CreateInstance(typeof(GenericController<Item>), reader, saver, deleter);
            //This does not work 
            //GenericController<Order> ctl = new GenericController(reader, saver, deleter);
            return ctl;
        }

    }
}
