using LenaTalent.Business.Concrete;
using LenaTalent.DAL.Abstract;
using LenaTalent.Entities.Context;
using LenaTalent.Entities.Models.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LenaTalent.DAL.Concrete
{
    public class FormDAL:Repository<Form, LenaTalentDbContext>,IFormDAL
    {
    }
}
