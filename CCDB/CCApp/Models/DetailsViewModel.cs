using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CCApp.Models
{
    public class DetailsViewModel
    {
        public Sesh Seshes { get; set; }
        public IEnumerable<Shout> Shouter { get; set; }
    }
}