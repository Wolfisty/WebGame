using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebGame.Domain.Entity;

namespace WebGame.Domain.ViewModels
{
    public class ProfileViewModel
    {
        public long Id { get; set; }

        public byte Age { get; set; }

        public long UserId { get; set; }

        public User User { get; set; }
    }
}
