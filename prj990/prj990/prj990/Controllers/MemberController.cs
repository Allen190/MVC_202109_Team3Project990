using prj990.Models;
using prj990.ViewModel;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web.Mvc;
using System.Web.Security;

namespace prj990.Controllers
  {
  [Authorize]  //指定Member控制器所有的動作方法必須通過授權才能執行。
  public class MemberController: Controller
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

    // GET: Restaurant
    public ActionResult Index()//會員後登入的餐廳
      {
      // 取得所有推薦餐廳

      tMember user = Session[CDictionary.SK_LOGINED_USER] as tMember;
      ViewBag.userid = user.fId;
      IEnumerable<tRestaurant> Restaurant = null;
      string keyword = Request.Form["txtKeyword"];//做餐廳的資料關鍵字搜尋
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
    public ActionResult Edit(int id)//管理者id=9餐廳資料的修改
      {

      tRestaurant prod = db.tRestaurant.FirstOrDefault(p => p.fId == id);
      if(prod == null)

        return RedirectToAction("Index");
      return View(prod);
      }
    [HttpPost]
    public ActionResult Edit(tRestaurant prod)//管理者id=9餐廳資料的修改存檔
      {

      tRestaurant prodEdit = db.tRestaurant.FirstOrDefault(p => p.fId == prod.fId);
      if(prodEdit != null)
        {
        prodEdit.fName = prod.fName;
        prodEdit.fAddress = prod.fAddress;
        prodEdit.fTel = prod.fTel;
        prodEdit.fPrice = prod.fPrice;
        prodEdit.fDiscount = prod.fDiscount;
        prodEdit.fData = prod.fData;
        prodEdit.fImg = prod.fImg;
        prodEdit.fInfo = prod.fInfo;
        db.SaveChanges();

        }
      return RedirectToAction("Index");
      }

    public ActionResult Delete(int id)//管理者id=9餐廳資料的刪除
      {

      tRestaurant prod = db.tRestaurant.FirstOrDefault(p => p.fId == id);
      if(prod != null)
        {
        db.tRestaurant.Remove(prod);
        db.SaveChanges();
        }
      return RedirectToAction("Index");
      }

    public ActionResult Create()//管理者id=9餐廳清單的新增
      {
      return View();
      }
    [HttpPost]
    public ActionResult Create(tRestaurant p)//管理者id=9餐廳清單的新增存檔
      {

      db.tRestaurant.Add(p);//新增找工廠宣告在最上面
      db.SaveChanges();//存回資料庫
      return RedirectToAction("Index");//存回
      }

    //Get:member

    public ActionResult MemberInfo()//登入的會員個人資料
      {

      string fUserId = User.Identity.Name;//取得會員帳號並指定給fUserId
      var Member = db.tMember.Where(m => m.fUserId == fUserId).ToList();
      return View(Member);
      }

    public ActionResult MemberInfoEdit()//登入會員個人資訊修改
      {
      string fUserId = User.Identity.Name;
      var Member = db.tMember.FirstOrDefault(m => m.fUserId == fUserId);
      if(Member == null)
        return RedirectToAction("MemberInfoList");
      return View(Member);
      }
    [HttpPost]
    public ActionResult MemberInfoEdit(tMember Info)//登入會員會員個人資訊修改後存檔
      {
      string fUserId = User.Identity.Name;
      tMember InfoEdit = db.tMember.FirstOrDefault(m => m.fUserId == fUserId);
      if(InfoEdit != null)
        {
        InfoEdit.fName = Info.fName;
        InfoEdit.fAddress = Info.fAddress;
        InfoEdit.fAge = Info.fAge;
        InfoEdit.fGender = Info.fGender;
        InfoEdit.fHobby = Info.fHobby;
        InfoEdit.fImg = Info.fImg;
        //  InfoEdit.fPoint = Info.fPoint;
        db.SaveChanges();
        }
      return RedirectToAction("MemberInfoList");
      }

    public ActionResult MemberPwd()//登入會員會員修改密碼
      {
      string fUserId = User.Identity.Name;
      var Member = db.tMember.FirstOrDefault(m => m.fUserId == fUserId);
      if(Member == null)

        return RedirectToAction("MemberInfoList");
      return View(Member);
      }
    [HttpPost]
    public ActionResult MemberPwd(tMember password)//登入會員修改密碼後存檔
      {
      string fUserId = User.Identity.Name;
      tMember Pwd = db.tMember.FirstOrDefault(m => m.fUserId == fUserId);
      if(Pwd != null)
        {
        Pwd.fPWd = password.fPWd;
        Pwd.fRePwd = password.fRePwd;
        db.SaveChanges();
        }
      return RedirectToAction("MemberInfoList");
      }


    public ActionResult MemberDelete(int id)//登入會員會員個人資訊刪除
      {

      tMember Info = db.tMember.FirstOrDefault(p => p.fId == id);
      if(Info != null)
        {
        db.tMember.Remove(Info);
        db.SaveChanges();
        }
      return RedirectToAction("Index","Home");
      }

    public ActionResult MemberInfopublic(int id)//公開的會員資料
      {
      Options();
      var Member = db.tMember.FirstOrDefault(a => a.fId == id);
      var activity = from a in (new db990DemoEntities2()).tActivity select a;
      var signup = from s in (new db990DemoEntities2()).tSignUp select s;
      CMemberViewModel viewmodel = new CMemberViewModel();
      viewmodel.Member = Member;
      viewmodel.Activity = activity;
      viewmodel.SignUp = signup;

      return View(viewmodel);

      }

    public ActionResult MemberInfoList()//登入會員會員個人活動清單
      {
      Options();
      string fUserId = User.Identity.Name;//取得會員帳號並指定給fUserId
      tMember user = Session[CDictionary.SK_LOGINED_USER] as tMember;
      if(user == null)
        {
        return RedirectToAction("Login","Home");
        }
      var mbr = db.tMember.FirstOrDefault(m => m.fUserId == fUserId);
      var activity = from a in (new db990DemoEntities2()).tActivity
                     orderby a.fId descending
                     select a;
      var signup = from s in (new db990DemoEntities2()).tSignUp select s;
      var host = from s in (new db990DemoEntities2()).tMember select s;
      CMemberViewModel viewmodel = new CMemberViewModel();
      viewmodel.Member = mbr;
      viewmodel.Activity = activity;
      viewmodel.SignUp = signup;
      viewmodel.Host = host;
      return View(viewmodel);
      }

    // GET: Activity
    public ActionResult ActivityList()//揪團活動清單
      {
      Options();
      揪團失敗();

      tMember user = Session[CDictionary.SK_LOGINED_USER] as tMember;
      ViewBag.userid = user.fId;
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
                orderby a.fActivityTime
                select a;
        }

      if(!string.IsNullOrEmpty(Date))
        {
        var actDate = Convert.ToDateTime(Date);
        //table = db.tActivity.Where(s => DbFunctions.TruncateTime(s.fActivityTime) == DbFunctions.TruncateTime(actDate));
        table = db.tActivity.Where(s => DbFunctions.TruncateTime(s.fActivityTime) == DbFunctions.TruncateTime(actDate) && s.fState == 1);
        table = table.OrderBy(a => a.fActivityTime);
        }
      else if(string.IsNullOrEmpty(Date))
        {
        table = from a in (new db990DemoEntities2()).tActivity where a.fState == 1
                orderby a.fActivityTime
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
    public ActionResult ActivityEdit(int id)
      {
      Options();
      db990DemoEntities2 db = new db990DemoEntities2();
      tActivity act = db.tActivity.FirstOrDefault(a => a.fId == id);
      if(act == null)
        return RedirectToAction("ActivityList");
      return View(act);
      }
    [HttpPost]
    public ActionResult ActivityEdit(tActivity act)
      {
      db990DemoEntities2 db = new db990DemoEntities2();
      tActivity actEdit = db.tActivity.FirstOrDefault(a => a.fId == act.fId);
      if(actEdit != null)
        {
        actEdit.fName = act.fName;
        actEdit.fRestaurant = act.fRestaurant;
        actEdit.fAddress = act.fAddress;
        actEdit.fConfirmTime = act.fConfirmTime;
        actEdit.fActivityTime = act.fActivityTime;
        actEdit.fPCount = act.fPCount;
        actEdit.fGender = act.fGender;
        actEdit.fCheckout = act.fCheckout;
        actEdit.fPrice = act.fPrice;
        actEdit.fInfo = act.fInfo;
        db.SaveChanges();
        }
      return RedirectToAction("ActivityList");
      }

    public ActionResult ActivityCancel(int id)
      {
      db990DemoEntities2 db = new db990DemoEntities2();
      tActivity act = db.tActivity.FirstOrDefault(a => a.fId == id);
      if(act != null)
        {
        act.fState = 2;
        db.SaveChanges();
        }
      return RedirectToAction("MemberInfoList");
      }

    public ActionResult ActivityCreate()
      {
      Options();
      //記錄登入者ID
      tMember user = Session[CDictionary.SK_LOGINED_USER] as tMember;
      if(user == null)
        {
        return RedirectToAction("Login","Home");
        }

      return View();
      }
    [HttpPost]
    public ActionResult ActivityCreate(tActivity a)
      {

      db990DemoEntities2 db = new db990DemoEntities2();
      db.tActivity.Add(a);
      db.SaveChanges();

      return RedirectToAction("ActivityList");
      }

    public ActionResult ActivityDelete(int id)//登入會員會員活動刪除測試用
      {

      tActivity Info = db.tActivity.FirstOrDefault(p => p.fId == id);
      if(Info != null)
        {
        db.tActivity.Remove(Info);
        db.SaveChanges();
        }
      return RedirectToAction("ActivityList","Member");
      }

    //從餐廳畫面連結的建立活動
    public ActionResult RestaurantActivityCreate(int Rid)
      {
      Options();
      //記錄登入者ID
      tMember user = Session[CDictionary.SK_LOGINED_USER] as tMember;
      if(user == null)
        {
        return RedirectToAction("Login","Home");
        }
      var restaurant = db.tRestaurant.Where(r => r.fId == Rid).FirstOrDefault();
      if(restaurant == null)
        {
        return View();
        }
      Session[CDictionary.SK_CHOOSE_RESTAURANT] = restaurant;//用session自動填入欄位資料
      ViewBag.Rname = restaurant.fName;
      ViewBag.Raddress = restaurant.fAddress;
      return View();
      }
    [HttpPost]
    public ActionResult RestaurantActivityCreate(tActivity a)//從餐廳葉面開啟活動後自動填入資料傳回儲存
      {
      db990DemoEntities2 db = new db990DemoEntities2();
      db.tActivity.Add(a);
      db.SaveChanges();
      return RedirectToAction("ActivityList");
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


    public ActionResult SignUp(int id)//會員報名活動
      {
      Options();
      //記錄登入者ID
      tMember user = Session[CDictionary.SK_LOGINED_USER] as tMember;
      if(user == null)
        {
        return RedirectToAction("Login","Home");
        }
      db990DemoEntities2 db = new db990DemoEntities2();
      tActivity act = db.tActivity.FirstOrDefault(a => a.fId == id);
      var signup = from s in db.tSignUp select s;
      var member = from m in db.tMember select m;
      CSignUpViewModel viewmodel = new CSignUpViewModel();
      viewmodel.Activity = act;
      viewmodel.SignUp = signup;
      viewmodel.Member = member;
      if(act == null)
        return RedirectToAction("ActivityList");
      if(act.fHostId == user.fId)
        {
        return Content("<script>alert('不可報名自己發起的活動');history.go(-1);</script>");
        }
      foreach(var item in signup)
        {
        if(item.fActivity == id && item.fMember == user.fId)
          {
          return Content("<script>alert('您已報名此活動');history.go(-1);</script>");
          }
        if(act.fGender == 2 && user.fGender != "男")
          return Content("<script>alert('本活動限男性報名');history.go(-1);</script>");
        else if(act.fGender == 3 && user.fGender != "女")
          return Content("<script>alert('本活動限女性報名');history.go(-1);</script>");
        }

      return View(viewmodel);
      }
    [HttpPost]
    public ActionResult SignUp(CSignUpViewModel singVM)
      {
      string message = Request.Form["txtmessage"];
      ViewBag.message = message;
      Options();
      db990DemoEntities2 db = new db990DemoEntities2();
      tActivity act = db.tActivity.FirstOrDefault(a => a.fId == singVM.txtFid);
      //記錄登入者ID
      tMember user = Session[CDictionary.SK_LOGINED_USER] as tMember;

      if(act != null)
        {
        tSignUp item = new tSignUp();
        item.fDate = DateTime.Now.ToString("yyyyMMddHHmmss");
        item.fMember = user.fId;
        item.fActivity = singVM.txtFid;
        item.fmessage = ViewBag.message;
        item.fState = 1;//狀態1=已報名
        db.tSignUp.Add(item);
        db.SaveChanges();
        }
      return RedirectToAction("MemberInfoList");
      }

    public ActionResult SignUpCancel(int id)
      {
      db990DemoEntities2 db = new db990DemoEntities2();
      tSignUp signup = db.tSignUp.FirstOrDefault(a => a.fId == id);
      if(signup != null)
        {
        db.tSignUp.Remove(signup);
        db.SaveChanges();
        }
      return RedirectToAction("MemberInfoList");
      }
    public ActionResult Logout()// 會員登出
      {
      FormsAuthentication.SignOut();
      return RedirectToAction("Login","Home");
      }

    public ActionResult SignUpList(int id)//活動報名清單
      {
      Options();
      tActivity act = db.tActivity.FirstOrDefault(a => a.fId == id);
      var signup = from s in db.tSignUp where s.fActivity == id select s;
      var member = from m in db.tMember select m;
      var MemberCount = (from s in db.tSignUp where s.fActivity == id && s.fState == 2 select s).Count();//入選人數
      var signupfailed = from s in db.tSignUp where s.fActivity == id && s.fState != 2 select s;//落選的報名資料

      if(MemberCount == act.fPCount)
        {
        act.fState = 3;
        foreach(var item in signupfailed)
          {
          item.fState = 4;
          }
        db.SaveChanges();
        }

      CSignUpViewModel viewmodel = new CSignUpViewModel();
      viewmodel.Activity = act;
      viewmodel.SignUp = signup;
      viewmodel.Member = member;
      viewmodel.入選人數 = MemberCount;

      return View(viewmodel);
      }

    public ActionResult ChatRoom(int id)//登入會員會後共同活動的會員聊天室
      {
      string fUserId = User.Identity.Name;//取得會員帳號並指定給fUserId
      tMember user = Session[CDictionary.SK_LOGINED_USER] as tMember;
      if(user == null)
        {
        return RedirectToAction("Login","Home");
        }
      var member = from m in db.tMember select m;
      var activity = db.tActivity.FirstOrDefault(a => a.fId == id);
      var signup = from s in db.tSignUp where s.fActivity == id && s.fState == 2 select s;
      foreach (var item in signup){ //判斷登入者是否可加入聊天室，避免從網址加入
      if(user.fId==item.fMember){
          break;
      }else if(user.fId==activity.fHostId){
          break;
        }
      else{
          return Content("<script>alert('資格不符');history.go(-1);</script>");
        }
      }
      var chatroom = from c in db.tChatRoom where c.fActivityId == id select c;
      CChatRoom viewmodel = new CChatRoom();
      viewmodel.User = user;
      viewmodel.Member = member;
      viewmodel.Activity = activity;
      viewmodel.SignUp = signup;
      viewmodel.ChatRoom = chatroom;

      return View(viewmodel);
      }
    [HttpPost]
    public ActionResult ChatRoom(CChatRoom CRVM)//送出訊息
      {
      tMember user = Session[CDictionary.SK_LOGINED_USER] as tMember;
      if(user == null)
        {
        return RedirectToAction("Login","Home");
        }

      tChatRoom chat = new tChatRoom();
      chat.fMemberId = user.fId;
      chat.fActivityId = CRVM.ActivityId;
      chat.fDate = DateTime.Now.ToString();
      chat.fMessage = Request.Form["message"];
      db.tChatRoom.Add(chat);
      db.SaveChanges();

      return RedirectToAction("ChatRoom");
      //return View("ChatRoom");
      }
    public ActionResult AddThisMember(int id)
      {
      var signup = db.tSignUp.FirstOrDefault(a => a.fId == id);
      var act = db.tActivity.FirstOrDefault(a => a.fId == signup.fActivity);
      var MemberCount = (from s in db.tSignUp where s.fActivity == act.fId && s.fState == 2 select s).Count();//入選人數

      if(signup != null)
        {
        signup.fState = 2;
        db.SaveChanges();
        }
      //if (MemberCount == act.fPCount)
      //{
      //    act.fState = 3;
      //    db.SaveChanges();
      //}
      return RedirectToAction("SignUpList",new { id = act.fId });
      }
    public ActionResult HiddenThisMember(int id)
      {
      var signup = db.tSignUp.FirstOrDefault(a => a.fId == id);
      int actid = (int)signup.fActivity;

      if(signup != null)
        {
        signup.fState = 3;
        db.SaveChanges();
        }
      return RedirectToAction("SignUpList",new { id = actid });
      }
    }
  }
