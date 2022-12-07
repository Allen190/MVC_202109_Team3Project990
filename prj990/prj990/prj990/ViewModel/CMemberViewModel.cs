using prj990.Models;
using System.Collections.Generic;

namespace prj990.ViewModel
  {
  public class CMemberViewModel
    {
    public tMember Member { get; set; }
    public IEnumerable<tActivity> Activity { get; set; }
    public IEnumerable<tSignUp> SignUp { get; set; }
    public IEnumerable<tMember> Host { get; set; }
    }
  }
