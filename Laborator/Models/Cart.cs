using Laborator.Entities;

namespace Laborator.Models
{
    public class Cart
    {
        public Dictionary<int, CartItem> Items { get; set; }
        public Cart()
        {
            Items = new Dictionary<int, CartItem>();
        }
        /// <summary>
        /// Количество объектов в корзине
        /// </summary>
        public int Count
        {
            get
            {
                return Items.Sum(item => item.Value.Quantity);
            }
        }
        /// <summary>
        /// Количество калорий
        /// </summary>
        public int Price
        {
            get
            {
                return Items.Sum(item => item.Value.Quantity *
               item.Value.Jewelry.Price);
            }
        }

        /// <summary>
        /// Добавление в корзину
        /// </summary>
        /// <param name="jewelry">добавляемый объект</param>
        public virtual void AddToCart(Jewelry jewelry)
        {
            // если объект есть в корзине
            // то увеличить количество
            if (Items.ContainsKey(jewelry.JewelryId))
                Items[jewelry.JewelryId].Quantity++;
            // иначе - добавить объект в корзину
            else
                Items.Add(jewelry.JewelryId, new CartItem
                {
                    Jewelry = jewelry,
                    Quantity = 1
                });
        }

        /// <summary>
        /// Удалить объект из корзины
        /// </summary>
        /// <param name="id">id удаляемого объекта</param>
        public virtual void RemoveFromCart(int id)
        {
            Items.Remove(id);
        }

        /// <summary>
        /// Очистить корзину
        /// </summary>
        public virtual void ClearAll()
        {
            Items.Clear();
        }
    }
    /// <summary>
    /// Клас описывает одну позицию в корзине
    /// </summary>
    public class CartItem
    {
        public Jewelry Jewelry { get; set; }
        public int Quantity { get; set; }
    }
}