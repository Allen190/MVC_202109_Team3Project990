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
  using System;
  using System.ComponentModel;
  using System.ComponentModel.DataAnnotations;


  public partial class tMember
    {
    public int fId { get; set; }

    [DisplayName("帳號")]
    [Required(ErrorMessage = "帳號不可空白")]
    public string fUserId { get; set; }
    [DisplayName("密碼")]
    [Required(ErrorMessage = "密碼不可空白")]
    public string fPWd { get; set; }

    [DisplayName("姓名")]
    [Required(ErrorMessage = "姓名不可空白")]
    public string fName { get; set; }
    [DisplayName("信箱")]
    [EmailAddress]
    [Required]
    public string fEmail { get; set; }
    [DisplayName("電話")]
    [Phone(ErrorMessage = "格式錯誤")]
    [StringLength(10,ErrorMessage = "電話不正確")]
    [Required]
    public string fTel { get; set; }
    [DisplayName("性別")]
    public string fGender { get; set; }
    [DisplayName("年齡")]

    public string fAge { get; set; }
    [DisplayName("地址")]
    public string fAddress { get; set; }
    [DisplayName("照片")]
    [Required]
    public string fImg { get; set; }
    [DisplayName("興趣喜好")]
    public string fHobby { get; set; }
    [DisplayName("跟隨")]
    public string fFollow { get; set; }
    [DisplayName("積分")]
    public Nullable<int> fPoint { get; set; }
    [DisplayName("黑名單")]
    public string fLock { get; set; }
    [DisplayName("確認密碼")]
    [Compare("fPWd",ErrorMessage = "兩組密碼必須相同")]
    public string fRePwd { get; set; }
    }
  }
