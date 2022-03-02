using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BookStore.Models.ViewModels
{
    public class PageInfo
    {
        public int  TotalNumBooks {get; set;}
        public int ProjectsPerPage { get; set; }
        public int CurrentPage { get; set; }
        //this has to be done after those ^^^ to work at runtime
        public int TotalPages => (int) Math.Ceiling((double) TotalNumBooks / ProjectsPerPage); //casting
    }
}
