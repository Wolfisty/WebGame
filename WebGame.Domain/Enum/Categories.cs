using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebGame.Domain.Enum
{
    public enum Categories
    {
        [Display(Name = "Математика")]
        Math = 0,
        [Display(Name = "Физика")]
        Phisics = 1,
    }
}
