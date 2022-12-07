using prj990.Models;
using System.Collections.Generic;

namespace prj990.ViewModel

{
    public class ActivityViewModel
    {

        public IEnumerable<tActivity> Activity { get; set; }
        public IEnumerable<tMember> Member { get; set; }

    }
}
