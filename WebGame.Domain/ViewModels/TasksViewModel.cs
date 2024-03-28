using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebGame.Domain.Enum;

namespace WebGame.Domain.ViewModels
{
    public class TasksViewModel
    {
        public long Id { get; set; }

        public string Content { get; set; }

        public string Answer { get; set; }

        public string Img { get; set; }

        public Categories Category { get; set; }

        public Section Section { get; set; }
    }
}
