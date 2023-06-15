namespace BeverageDispenser.Models
{
    /// <summary>
    /// Монета
    /// </summary>
    public class Coin
    {
        /// <summary>
        /// Индентификатор монеты
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// Номинал
        /// </summary>
        public Denomination Denomination { get; set; }

        /// <summary>
        /// Активен ли
        /// </summary>
        public bool IsDispenser { get; set; }
    }
     public enum Denomination
    {
        one = 1,
        two = 2,
        five = 5,
        ten = 10
    }
}
