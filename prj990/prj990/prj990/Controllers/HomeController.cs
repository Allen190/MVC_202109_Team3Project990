using prj990.Models;
using prj990.ViewModel;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web.Mvc;
using System.Web.Security;//Web表單驗證用

namespace prj990.Controllers
  {
  public class HomeController: Controller
    {
    db990DemoEntities2 db = new db990DemoEntities2();
    private void 揪團失敗() //超過審核時間未成團活動狀態改為揪團失敗
      {
      var Activity = from a in db.tActivity select a;
      foreach(var item in Activity)
        {
        if(item.fState == 1 && item.fConfirmTime < DateTime.Now)
          {
          item.fState = 5;
          }
        }
      db.SaveChanges();
      }
    public ActionResult Home()
      {
      return View();
      }
    public ActionResult Index()
      {

      IEnumerable<tRestaurant> Restaurant = null;
      string keyword = Request.Form["txtKeyword"];
      if(string.IsNullOrEmpty(keyword))
        Restaurant = from p in (new db990DemoEntities2()).tRestaurant select p;
      else
        Restaurant = from p in (new db990DemoEntities2()).tRestaurant
                     where p.fName.Contains(keyword) ||
                            p.fAddress.Contains(keyword) ||
                            p.fData.Contains(keyword)
                     select p;
      return View(Restaurant);
      }



    public ActionResult Login()
      {

      return View();
      }
    [HttpPost]
    public ActionResult Login(string fUserId,string fPWd)
      {
      db990DemoEntities2 db = new db990DemoEntities2();//新增找工廠
      var member = db.tMember.Where(m => m.fUserId == fUserId && m.fPWd == fPWd).FirstOrDefault();
      if(member == null)
        {
        ViewBag.Message = "帳密錯誤，登入失敗...";
        return View();
        }
      Session["MemberName"] = member.fName;
      Session[CDictionary.SK_LOGINED_USER] = member;
      FormsAuthentication.RedirectFromLoginPage(fUserId,true);

      return RedirectToAction("MemberInfoList","Member");
      }

    public ActionResult Register()
      {
      return View();
      }

    [HttpPost]
    public ActionResult Register(tMember pMember)
      {
      db990DemoEntities2 db = new db990DemoEntities2();

      //若模型沒有通過驗證則顯示目前的View
      if(ModelState.IsValid == false)
        {
        return View();
        }
      // 依帳號取得會員並指定給member
      var member = db.tMember
          .Where(m => m.fUserId == pMember.fUserId)
          .FirstOrDefault();
      //若member為null，表示會員未註冊
      if(member == null)
        {
        //將會員記錄新增到tMember資料表
        db.tMember.Add(pMember);
        db.SaveChanges();
        //執行Home控制器的Login動作方法
        return RedirectToAction("Login");
        }
      ViewBag.Message = "此帳號己有人使用，註冊失敗";
      return View();

      }

    public ActionResult ActivityList()//揪團活動清單
      {
      Options();

      //tMember user = Session[CDictionary.SK_LOGINED_USER] as tMember;
      //ViewBag.userid = user.fId;
      IEnumerable<tActivity> table = null;
      string keyword = Request.Form["txtKeyword"];
      int gender = Convert.ToInt32(Request.Form["gender"]);
      int checkout = Convert.ToInt32(Request.Form["checkout"]);
      string Date = Request.Form["actTime"];
      string city = Request.Form["txtCity"];
      string dist = Request.Form["txtDist"];


      if(string.IsNullOrEmpty(keyword))
        {
        table = from a in (new db990DemoEntities2()).tActivity where a.fState == 1
                select a;

        }

      if(!string.IsNullOrEmpty(Date))
        {
        var actDate = Convert.ToDateTime(Date);
        //table = db.tActivity.Where(s => DbFunctions.TruncateTime(s.fActivityTime) == DbFunctions.TruncateTime(actDate));
        table = db.tActivity.Where(s => DbFunctions.TruncateTime(s.fActivityTime) == DbFunctions.TruncateTime(actDate) && s.fState == 1);

        }
      else if(string.IsNullOrEmpty(Date))
        {
        table = from a in (new db990DemoEntities2()).tActivity where a.fState == 1

                select a;
        }
      if(!string.IsNullOrEmpty(keyword))
        {
        table = table.Where(a => a.fName.Contains(keyword) ||
                a.fRestaurant.Contains(keyword) ||
                a.fAddress.Contains(keyword)
                );
        }

      if(!string.IsNullOrEmpty(dist))
        {
        table = table.Where(a => a.fAddress.Contains(dist) && a.fAddress.Contains(city));
        }
      else if(string.IsNullOrEmpty(dist) && !string.IsNullOrEmpty(city))
        {
        table = table.Where(a => a.fAddress.Contains(city));
        }
      if(gender != 0)
        table = table.Where(s => s.fGender == gender);
      if(checkout != 0)
        table = table.Where(s => s.fCheckout == checkout);

      var host = from m in (new db990DemoEntities2()).tMember
                 select m;

      ActivityViewModel viewmodel = new ActivityViewModel();//使用到兩個資料表用viewmodel
      viewmodel.Activity = table;
      viewmodel.Member = host;
      return View(viewmodel);
      }
    private void Options()
      {
      ViewBag.gender1 = "不限";
      ViewBag.gender2 = "限男性";
      ViewBag.gender3 = "限女性";

      ViewBag.checkout1 = "各付各的";
      ViewBag.checkout2 = "AA(均分)";
      ViewBag.checkout3 = "我請客";
      ViewBag.checkout4 = "你請客";
      }


    //public ActionResult Edit(int id)
    //{
    //    db990DemoEntities2 db = new db990DemoEntities2();//新增找工廠
    //    tRestaurant prod = db.tRestaurant.FirstOrDefault(p => p.fId == id);
    //    if (prod == null)

    //        return RedirectToAction("Index");
    //        return View(prod);
    //}
    //[HttpPost]
    //public ActionResult Edit(tRestaurant prod)
    //{
    //    db990DemoEntities2 db = new db990DemoEntities2();//新增找工廠
    //    tRestaurant prodEdit = db.tRestaurant.FirstOrDefault(p => p.fId == prod.fId);
    //    if (prodEdit != null)
    //    {
    //        prodEdit.fName = prod.fName;
    //        prodEdit.fAddress = prod.fAddress;
    //        prodEdit.fTel = prod.fTel;
    //        prodEdit.fPrice = prod.fPrice;
    //        prodEdit.fDiscount= prod.fDiscount;
    //        prodEdit.fData = prod.fData;
    //        prodEdit.fImg = prod.fImg;
    //        prodEdit.fInfo = prod.fInfo;
    //        db.SaveChanges();

    //    }
    //    return RedirectToAction("Index");
    //}
    //public ActionResult Delete(int id)
    //{
    //    db990DemoEntities2 db = new db990DemoEntities2();//新增找工廠
    //    tRestaurant prod = db.tRestaurant.FirstOrDefault(p => p.fId == id);
    //        if(prod!=null)
    //         {
    //        db.tRestaurant.Remove(prod);
    //        db.SaveChanges();
    //         }
    //         return RedirectToAction("Index");
    //}

    //public ActionResult Create()
    //{

    //    return View();
    //}
    //[HttpPost]
    //public ActionResult Create(tRestaurant p)//製作一個參數
    //{
    //    db990DemoEntities2 db = new db990DemoEntities2();//新增找工廠
    //    db.tRestaurant.Add(p);//新增找工廠宣告在最上面
    //    db.SaveChanges();//存回資料庫
    //    return RedirectToAction("Index");//存回
    //}
    }
  }
