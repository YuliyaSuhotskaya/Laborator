namespace Laborator.Entities
{
    public class Jewelry
    {
        public int JewelryId { get; set; } // id украшения
        public string? JewelryName { get; set; } // название украшения
        public string? Description { get; set; } // описание украшения
        public int Price { get; set; } // цена одного украшения
        public string Image { get; set; } // имя файла изображения

        // Навигационные свойства
        /// <summary>
        /// группа украшений (например, кольца, браслеты и т.д.)
        /// </summary>
        public int JewelryGroupId { get; set; }
        public JewelryGroup Group { get; set; }
    }
}
