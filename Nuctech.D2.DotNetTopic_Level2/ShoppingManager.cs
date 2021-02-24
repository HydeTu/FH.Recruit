using System;
using System.Collections.Generic;
using System.Linq;

namespace Nuctech.D2.DotNetTopic
{
    public class ShoppingManager : IShoppingManager
    {
        public ShoppingManager()
        {
            this.InitItemList();

            this.CurrentTaxRateTable = new TaxRateTable();
        }

        public ITaxRateTable CurrentTaxRateTable
        {
            get;
            protected set;
        }

        public IShoppingList CreateRandomShoppingList()
        {
            IShoppingList result = new ShoppingList(DateTime.Now);

            int count = _random.Next(3, _items.Count);
            for (int i = 0; i < count; i++)
            {
                result.Add(_items.ElementAt(_random.Next(_items.Count - 1)).Value, _random.Next(0, 10));
            }
            return result;
        }

        public IItem GetItem(int id)
        {
            if (_items != null && _items.ContainsKey(id))
            {
                return _items[id];
            }
            else
            {
                return null;
            }
        }

        protected Dictionary<int, IItem> _items = new Dictionary<int, IItem>();
        private readonly Random _random = new Random(DateTime.Now.Millisecond);

        /// <summary>
        /// Initialize items. Only for demo.
        /// </summary>
        protected void InitItemList()
        {
            for (int i = 0; i < _random.Next(5, 20); i++)
            {
                Item item = CreateRandomItem();
                _items.Add(item.ID, item);
            }
        }

        private Item CreateRandomItem()
        {
            Array typeArray = Enum.GetValues(typeof(EnumItemType));
            EnumItemType selectedType = (EnumItemType)typeArray.GetValue(_random.Next(0, typeArray.Length - 1));
            Item result = new Item(GetNewId()) { Type = selectedType };
            result.Name = string.Format("{0}{1:d3}", selectedType, result.ID);
            result.Price = Math.Abs(_random.Next(-3000, 9000)) / 100f;
            return result;
        }

        private int GetNewId()
        {
            while (true)
            {
                var result = _random.Next(1, 1000);
                if (!_items.ContainsKey(result))
                    return result;
            }
        }
    }
}