using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LenaTalent.Entities.Models.Entities
{
    public class Field
    {
        public int ID { get; set; }
        public bool Required { get; set; }
        public string Name { get; set; }
        public string DataType { get; set; }
        public int FormID { get; set; }
        public Form Form { get; set; }
    }
}
