namespace Laborator.Entities
{
    public class JewelryGroup
    {
        public int JewelryGroupId { get; set; }
        public string? GroupName { get; set; }
        /// <summary>
        /// Навигационное свойство 1-ко-многим
        /// </summary>
        public List<Jewelry> Jewelries { get; set; }
    }
}
