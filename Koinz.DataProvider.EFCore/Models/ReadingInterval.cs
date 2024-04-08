using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Koinz.DataProvider.EFCore.Models
{
    public partial class ReadingInterval
    {
        public int ReadingId { get; set; }
        public int? UserId { get; set; }
        public int? BookId { get; set; }
        public int? StartPage { get; set; }
        public int? EndPage { get; set; }

        public virtual Book Book { get; set; }
        public virtual User User { get; set; }
    }
}
