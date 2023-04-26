using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LenaTalent.Entities.Models.Entities
{
    public class FormData
    {
        public int ID { get; set; }
        public int FieldID { get; set; }
        public Field Field { get; set; }
        public int FormID { get; set; }
        public Form Form { get; set; }
        public string Value { get; set; }
    }
}
