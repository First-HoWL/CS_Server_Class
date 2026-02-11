using C__Server_Class.Models;
using System.Xml.Linq;

namespace C__Server_Class.Services
{
    public class SushiService
    {
        private List<Sushi> _Sushies = new();
        private int _lastId = 0;

        public SushiService()
        {
            Add(new Sushi()
            {
                Id = 0,
                Name = "Philadelphia Roll",
                Description = "Yammi sushi roll of salmon",
                Count = 8,
                Weight = 250,
                Img = "https://sansushi.md/wp-content/uploads/2025/11/10-fd4dc0aa-6173-4113-afee-285c2c28a8aa.jpg",
                Price = 250.0
            });
            Add(new Sushi()
            {
                Id = 0,
                Name = "California Roll",
                Description = "Yammi sushi roll of sweet crab, with avocado and cucumber",
                Count = 8,
                Weight = 280,
                Img = "https://sansushi.md/wp-content/uploads/2025/11/11-ad51a86f-2e51-4332-80b2-d7f4cacd2da6.jpg",
                Price = 290.0
            });
        }

        public List<Sushi> GetAll() => _Sushies;
        public Sushi? GetProductById(int id) =>
            _Sushies.FirstOrDefault(p => p.Id == id);


        public int Add(Sushi sushi)
        {
            sushi.Id = GetLastId();
            _Sushies.Add(sushi);
            return sushi.Id;
        }

        public int GetLastId() => ++_lastId;


        public bool Update(Sushi sushi)
        {
            Sushi? FoundSushi = GetProductById(sushi.Id);
            if (FoundSushi == null || FoundSushi.Id == 0)
                return false;

            FoundSushi.Name = sushi.Name;
            FoundSushi.Description = sushi.Description;
            FoundSushi.Weight = sushi.Weight;
            FoundSushi.Count = sushi.Count;
            FoundSushi.Price = sushi.Price;
            FoundSushi.Img = sushi.Img;
            return true;
        }

        public bool Delete(int id)
        {
            Sushi? FoundSushi = GetProductById(id);
            if (FoundSushi == null || FoundSushi.Id == 0)
                return false;
            _Sushies.Remove(FoundSushi);
            return true;
        }
    }
    public class SushiSetService
    {
        private List<SushiSet> _SushiSets = new();
        private int _lastId = 0;

        public SushiSetService()
        {
            //Add(new Sushi()
            //{
            //    Id = 0,
            //    Name = "Philadelphia Roll",
            //    Description = "Yammi sushi roll of salmon",
            //    Count = 8,
            //    Weight = 250,
            //    Img = "https://sansushi.md/wp-content/uploads/2025/11/10-fd4dc0aa-6173-4113-afee-285c2c28a8aa.jpg",
            //    Price = 250.0
            //});
            //Add(new Sushi()
            //{
            //    Id = 0,
            //    Name = "California Roll",
            //    Description = "Yammi sushi roll of sweet crab, with avocado and cucumber",
            //    Count = 8,
            //    Weight = 280,
            //    Img = "https://sansushi.md/wp-content/uploads/2025/11/11-ad51a86f-2e51-4332-80b2-d7f4cacd2da6.jpg",
            //    Price = 290.0
            //});
        }

        public List<SushiSet> GetAll() => _SushiSets;
        public SushiSet? GetProductById(int id) =>
            _SushiSets.FirstOrDefault(p => p.Id == id);


        public int Add(SushiSet SushiSet)
        {
            SushiSet.Id = GetLastId();
            _SushiSets.Add(SushiSet);
            return SushiSet.Id;
        }

        public int GetLastId() => ++_lastId;


        public bool Update(SushiSet sushi)
        {
            SushiSet? FoundSushi = GetProductById(sushi.Id);
            if (FoundSushi == null || FoundSushi.Id == 0)
                return false;

            FoundSushi.Name = sushi.Name;
            FoundSushi.Description = sushi.Description;
            FoundSushi.Weight = sushi.Weight;
            FoundSushi.Count = sushi.Count;
            FoundSushi.Price = sushi.Price;
            FoundSushi.Img = sushi.Img;
            return true;
        }

        public bool Delete(int id)
        {
            SushiSet? FoundSushi = GetProductById(id);
            if (FoundSushi == null || FoundSushi.Id == 0)
                return false;
            _SushiSets.Remove(FoundSushi);
            return true;
        }
    }
    public class BucketService
    {
        private List<Bucket> _Buckets = new();
        private int _lastId = 0;

        public BucketService()
        {
            
        }

        public List<Bucket> GetAll() => _Buckets;
        public Bucket? GetProductById(int id) =>
            _Buckets.FirstOrDefault(p => p.Id == id);


        public int Add(Bucket Bucket)
        {
            Bucket.Id = GetLastId();
            _Buckets.Add(Bucket);
            return Bucket.Id;
        }

        public int GetLastId() => ++_lastId;


        public bool Update(Bucket Bucket)
        {
            Bucket? FoundBucket = GetProductById(Bucket.Id);
            if (FoundBucket == null || FoundBucket.Id == 0)
                return false;

            FoundBucket.Sushies = Bucket.Sushies;
            FoundBucket.PublicId = Bucket.PublicId;
            return true;
        }

        public bool Delete(int id)
        {
            Bucket? FoundBucket = GetProductById(id);
            if (FoundBucket == null || FoundBucket.Id == 0)
                return false;
            _Buckets.Remove(FoundBucket);
            return true;
        }
    }
    public class OrderService
    {
        private List<Order> _Orders = new();
        private int _lastId = 0;

        public OrderService()
        {
            
        }

        public List<Order> GetAll() => _Orders;
        public Order? GetProductById(int id) =>
            _Orders.FirstOrDefault(p => p.Id == id);


        public int Add(Order Order)
        {
            Order.Id = GetLastId();
            _Orders.Add(Order);
            return Order.Id;
        }

        public int GetLastId() => ++_lastId;


        public bool Update(Order Order)
        {
            Order? FoundOrder = GetProductById(Order.Id);
            if (FoundOrder == null || FoundOrder.Id == 0)
                return false;

            FoundOrder.Desc = Order.Desc;
            FoundOrder.Adress = Order.Adress;
            FoundOrder.Price = Order.Price;
            FoundOrder.Phone = Order.Phone;
            FoundOrder.Delivery = Order.Delivery;
            FoundOrder.Bucket = Order.Bucket;
            return true;
        }

        public bool Delete(int id)
        {
            Order? FoundOrder = GetProductById(id);
            if (FoundOrder == null || FoundOrder.Id == 0)
                return false;
            _Orders.Remove(FoundOrder);
            return true;
        }
    }


}
