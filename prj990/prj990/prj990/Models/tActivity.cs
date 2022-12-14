//------------------------------------------------------------------------------
// <auto-generated>
//     ??撘Ⅳ?舐蝭?Ｙ???
//
//     撠?獢脰???霈?航撠?函??蝔??Ｙ??芷???銵??
//     憒???Ｙ?蝔?蝣潘?撠?閬神撠?獢???霈??
// </auto-generated>
//------------------------------------------------------------------------------

namespace prj990.Models
{
 using System;
 using System.ComponentModel;
 using System.ComponentModel.DataAnnotations;

 public partial class tActivity /*: IValidatableObject*/
 {
  public int fId { get; set; }
  [DisplayName("活動名稱")]
  [Required]
  public string fName { get; set; }
  [DisplayName("餐聽")]
  [Required]
  public string fRestaurant { get; set; }
  [DisplayName("地址")]
  [Required]
  public string fAddress { get; set; }
  [DisplayName("審核時間")]
  [Required]

  public Nullable<System.DateTime> fConfirmTime { get; set; }
  [DisplayName("活動時間")]
  [Required]

  public Nullable<System.DateTime> fActivityTime { get; set; }
  [DisplayName("活動資訊")]
  [Required]
  public string fInfo { get; set; }
  [DisplayName("邀請人數")]
  [Required]
  [Range(0,100,ErrorMessage = "人數必須在0-100")]

  public Nullable<int> fPCount { get; set; }
  [DisplayName("性別限制")]
  public Nullable<int> fGender { get; set; }
  [DisplayName("付費方式")]
  public Nullable<int> fCheckout { get; set; }
  public Nullable<int> fHostId { get; set; }
  public Nullable<int> fPoint { get; set; }
  [DisplayName("預計金額")]
  [Required]

  public string fPrice { get; set; }
  public string fRInfo { get; set; }
  public Nullable<int> fState { get; set; }
  //[DisplayName("活動照片")]
  //[Required]
  public string fImag { get; set; }

  //public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
  //{
  //int result = DateTime.Compare((DateTime)this.fActivityTime,(DateTime)this.fConfirmTime);
  //if(result >= 0)
  //{
  //yield return new ValidationResult("start date must be less than the end date!",
  //                                  new[] { "ConfirmEmail" });
  //}
  //}
 }
}
