using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Koinz.DataProvider.EFCore.Models
{
    public partial class User
    {
        public User()
        {
            ReadingIntervals = new HashSet<ReadingInterval>();
        }

        public int UserId { get; set; }

        public virtual ICollection<ReadingInterval> ReadingIntervals { get; set; }
    }
}
