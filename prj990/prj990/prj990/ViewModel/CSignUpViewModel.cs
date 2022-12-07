using prj990.Models;
using System.Collections.Generic;

namespace prj990.ViewModel
{
 public class CSignUpViewModel
 {
  public int txtFid { get; set; }
  public int 入選人數 { get; set; }
  public tActivity Activity { get; set; }
  public IEnumerable<tSignUp> SignUp { get; set; }
  public IEnumerable<tMember> Member { get; set; }

 }
}
