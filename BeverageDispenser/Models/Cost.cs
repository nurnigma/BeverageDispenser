using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BeverageDispenser.Models
{
    /// <summary>
    /// Цена и количества напитка
    /// </summary>
    public class Cost
    {
        /// <summary>
        /// Идентификатор 
        /// </summary>
        [Key]
        public int Id { get; set; }

        /// <summary>
        /// Цена за напиток
        /// </summary>
        [Required(ErrorMessage ="Заполните поле!")]
        public decimal Price { get; set; }
       
        /// <summary>
        /// Количество
        /// </summary>
        [Required(ErrorMessage ="Введите количество напитка")]
        public uint Count { get; set; } 
    }
}
