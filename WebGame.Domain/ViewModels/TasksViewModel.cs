using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebGame.Domain.ViewModels
{
    public class TasksViewModel
    {
        public long Id { get; set; }

        public string Content { get; set; }

        public string Answer { get; set; }

        public string Img { get; set; }
    }
}
