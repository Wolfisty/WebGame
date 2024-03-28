using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebGame.Domain.Entity;
using WebGame.Domain.Enum;

namespace WebGame.Domain.ViewModels
{
    public class UserViewModel
    {
        public long Id { get; set; }

        public string Password { get; set; }

        public string Name { get; set; }

        public Role Role { get; set; }

        public Profile Profile { get; set; }

        public int Rating { get; set; }

        public List<long> CompletedTasks { get; set; }
    }
}
