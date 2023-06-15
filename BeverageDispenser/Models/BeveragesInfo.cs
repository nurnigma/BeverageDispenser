namespace BeverageDispenser.Models
{
    /// <summary>
    /// Информация о напитках для вью
    /// </summary>
    public class BeveragesInfo
    {
        /// <summary>
        /// Индентификатор напитка
        /// </summary>
        public int DrinkId { get; set; }

        /// <summary>
        /// Наименование напитка
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Цена
        /// </summary>
        public decimal Price { get; set; }

        /// <summary>
        /// Количество
        /// </summary>
        public uint Count { get; set; } 
    }
}
