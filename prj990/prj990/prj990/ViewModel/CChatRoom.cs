using prj990.Models;
using System.Collections.Generic;

namespace prj990.ViewModel
{
 public class CChatRoom
 {
  public tMember User { get; set; }
  public IEnumerable<tMember> Member { get; set; }
  public tActivity Activity { get; set; }
  public IEnumerable<tSignUp> SignUp { get; set; }
  public IEnumerable<tChatRoom> ChatRoom { get; set; }
  public int ActivityId { get; set; }
 }
}
