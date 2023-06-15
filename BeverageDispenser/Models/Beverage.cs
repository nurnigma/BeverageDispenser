using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BeverageDispenser.Models
{
    public class Beverage
    {
        /// <summary>
        /// Идентификатор
        /// </summary>
        [Key]
        public int Id { get; set; }
        /// <summary>
        /// Наименования напитка
        /// </summary>
        [Required (ErrorMessage ="Заполните название напитка!")]
        public string Name { get; set; }
        /// <summary>
        /// Идентификатор цены и количества
        /// </summary>
        [ForeignKey("Cost")]
        public int CostId { get; set; }
        /// <summary>
        /// Цены и количество
        /// </summary>
        public Cost Cost { get; set; }

    }
}
