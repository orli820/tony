using ClientMDA.Models;
using ClientMDA.ViewModels;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json;
using System.Threading.Tasks;

namespace ClientMDA.Controllers
{
    public class CommentController : Controller
    {
        private readonly MDAContext _MDAcontext;

        public CommentController(MDAContext MDAcontext)  //相依性注入
        {
            _MDAcontext = MDAcontext;
        }

        public IActionResult 評論首頁() //最新/熱門/關注評論
        {
            List<CCommentViewModel> datas = null;
            var mPoster = _MDAcontext.評論圖片明細commentImagesLists.Select(i => i);
            datas = _MDAcontext.電影評論movieComments.OrderBy(c => c.評論編號commentId).Select
                    (c => new CCommentViewModel
                    {
                        comment = c,
                        暱稱nickName = c.會員編號member.暱稱nickName,
                        cImgFrList = _MDAcontext.評論圖片明細commentImagesLists.Where(i => i.評論編號commentId == c.評論編號commentId)
                        .Select(c => c.評論圖庫編號commentImage.圖片image).ToList()
                    }).Take(6).ToList();
            return View(datas);
        }

        public IActionResult 電影評論(int? id) //電影單則評論
        {
            CCommentViewModel datas = null;
            datas = _MDAcontext.電影評論movieComments.Where(c => c.評論編號commentId == id).Select
            (c => new CCommentViewModel
            {
                comment = c,
                公開等級public = c.公開等級編號public.公開等級public,
                中文標題titleCht = c.電影編號movie.中文標題titleCht,
                暱稱nickName = c.會員編號member.暱稱nickName,
                會員照片image = c.會員編號member.會員照片image,
                //回覆內容floors = c.回覆樓數floors.
                //發佈時間floorTime = c.
                //被按讚次數thumbsUp
                //被倒讚次數thumbsDown
                //標籤明細編號chId =c.標籤明細hashtagsLists
                //標籤編號hashtagId
                //標籤hashtag
                //評論圖片編號ccId
                //評論圖庫編號commentImageId
                //圖片image
            }).FirstOrDefault();

            return View(datas);
        }
        
        public IActionResult 會員評論() //會員個別評論頁面
        {
            return View();
        }
        #region follow report
        [HttpPost]
        public IActionResult Report檢舉(我的追蹤清單myFollowList vm) 
        {

            我的追蹤清單myFollowList follow = new 我的追蹤清單myFollowList()
            {
                會員編號memberId = vm.會員編號memberId,
                對象targetId = vm.對象targetId, 
                追讚倒編號actionTypeId = vm.追讚倒編號actionTypeId, 
                連接編號connectId = vm.連接編號connectId,
                檢舉理由reportReason=vm.檢舉理由reportReason,
                處理狀態status=0,
            };
            _MDAcontext.我的追蹤清單myFollowLists.Add(follow);
            _MDAcontext.SaveChanges();
            //ViewBag.txtSuccess = "s";
            return Redirect($"~/Comment/會員評論/{vm.連接編號connectId}");
        }
            public IActionResult follow會員(int followMid) //點按追蹤會員
        {
            string user = HttpContext.Session.GetString(CDictionary.SK_LOGINED_USER);
            
            if (string.IsNullOrEmpty(user))
            {
                HttpContext.Session.SetString(CDictionary.SK登後要前往的頁面, $"~/Comment/會員評論/{followMid}");
                return Redirect("~/Member/Login");
            }
            會員member mem = JsonSerializer.Deserialize<會員member>(user);
            我的追蹤清單myFollowList follow = new 我的追蹤清單myFollowList()
            {
                會員編號memberId=mem.會員編號memberId,
                對象targetId=1, //會員
                追讚倒編號actionTypeId=0, //追蹤
                連接編號connectId= followMid,
            };
            _MDAcontext.我的追蹤清單myFollowLists.Add(follow);
            _MDAcontext.SaveChanges();
            return RedirectToAction("會員評論", new { id= followMid });
        }
        public IActionResult unfollow會員(int followMid) //點按追蹤會員
        {
            string user = HttpContext.Session.GetString(CDictionary.SK_LOGINED_USER);
            會員member mem = JsonSerializer.Deserialize<會員member>(user);
            if (string.IsNullOrEmpty(user))
            {
                HttpContext.Session.SetString(CDictionary.SK登後要前往的頁面, $"~/Comment/會員評論/{followMid}");
                return Redirect("~/Member/Login");
            }
            我的追蹤清單myFollowList follow = new 我的追蹤清單myFollowList()
            {
                會員編號memberId = mem.會員編號memberId,
                對象targetId = 1, //會員
                追讚倒編號actionTypeId = 0, //追蹤
                連接編號connectId = followMid,
            };
            _MDAcontext.我的追蹤清單myFollowLists.Add(follow);
            _MDAcontext.SaveChanges();
            //return RedirectToAction("會員評論", new { id = followMid });
            return Content("1", "text/plain");
        }
        public IActionResult follow評論(int followCid) //點按追蹤評論
        {
            string user = HttpContext.Session.GetString(CDictionary.SK_LOGINED_USER);
            會員member mem = JsonSerializer.Deserialize<會員member>(user);
            if (string.IsNullOrEmpty(user))
            {
                HttpContext.Session.SetString(CDictionary.SK登後要前往的頁面, $"~/Comment/電影評論/{followCid}");
                return Redirect("~/Member/Login");
            }
            我的追蹤清單myFollowList follow = new 我的追蹤清單myFollowList()
            {
                會員編號memberId = mem.會員編號memberId,
                對象targetId = 2, //評論
                追讚倒編號actionTypeId = 0, //追蹤
                連接編號connectId = followCid,
            };
            _MDAcontext.我的追蹤清單myFollowLists.Add(follow);
            _MDAcontext.SaveChanges();
            return RedirectToAction("電影評論", new { id = followCid });
        }
        #endregion
    }
}