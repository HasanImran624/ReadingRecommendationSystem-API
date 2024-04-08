using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Koinz.DataProvider.EFCore.Models
{
    public partial class Book
    {
        public Book()
        {
            ReadingIntervals = new HashSet<ReadingInterval>();
        }

        public int BookId { get; set; }
        public string BookName { get; set; }

        public virtual ICollection<ReadingInterval> ReadingIntervals { get; set; }
    }
}
