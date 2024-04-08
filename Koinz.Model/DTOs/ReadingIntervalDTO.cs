using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Koinz.Model.DTOs
{
     public class ReadingIntervalDTO
    {
        public int UserId { get; set; }
        public int BookId { get; set; }
        public int StartPage { get; set; }
        public int EndPage { get; set; }

    }
}
