using LenaTalent.Entities.Models.Identity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LenaTalent.Entities.Models.Entities
{
    public class Form
    {
        public Form() : base()
        {
            CreatedAt = DateTime.Now;
        }
        public int ID { get; set; }

        [Required(ErrorMessage = "Name alanı boş bırakılamaz.")]
        public string Name { get; set; }
        [Required(ErrorMessage = "Description alanı boş bırakılamaz.")]
        public string Description { get; set; }
        public DateTime CreatedAt { get; set; }
        public int CreatedBy { get; set; }
        public ICollection<Field> Fields { get; set; }
        public ICollection<FormData> FormData { get; set; }
    }
}

