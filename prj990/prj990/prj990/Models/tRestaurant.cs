﻿//------------------------------------------------------------------------------
// <auto-generated>
//     ??撘Ⅳ?舐蝭?Ｙ???
//
//     撠?獢脰???霈?航撠?函??蝔??Ｙ??芷???銵??
//     憒???Ｙ?蝔?蝣潘?撠?閬神撠?獢???霈??
// </auto-generated>
//------------------------------------------------------------------------------

namespace prj990.Models
  {
  using System.ComponentModel;
  using System.ComponentModel.DataAnnotations;

  public partial class tRestaurant
    {
    public int fId { get; set; }
    [DisplayName("餐廳編號")]
    public string fRId { get; set; }
    [DisplayName("餐聽")]

    public string fName { get; set; }
    [DisplayName("地址")]

    public string fAddress { get; set; }
    [DisplayName("電話")]
    [StringLength(10,ErrorMessage = "電話限制10字元")]
    public string fTel { get; set; }
    [DisplayName("價位")]


    public string fPrice { get; set; }
    [DisplayName("優惠")]
    public string fDiscount { get; set; }
    [DisplayName("營業時間")]
    public string fData { get; set; }
    [DisplayName("照片")]
    [FileExtensions]
    public string fImg { get; set; }
    [DisplayName("餐聽資訊")]
    [StringLength(50,ErrorMessage = "限制50字元")]
    public string fInfo { get; set; }
    }
  }
