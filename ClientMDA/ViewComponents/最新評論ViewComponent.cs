using ClientMDA.Models;
using ClientMDA.ViewModels;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ClientMDA.ViewConponents
{
    public class 最新評論ViewComponent : ViewComponent //須繼承ViewComponent
    {
        private readonly MDAContext _MDAcontext;

        public 最新評論ViewComponent(MDAContext MDAcontext)  //相依性注入
        {
            _MDAcontext = MDAcontext;
            _MDAcontext.評論圖片明細commentImagesLists.ToList();
            _MDAcontext.評論圖片總表commentImages.ToList();
        }

        //用這個 async Task<IViewComponentResult> InvokeAsync
        public async Task<IViewComponentResult> InvokeAsync(List<CCommentViewModel> datas)
        {
            var mPoster = _MDAcontext.評論圖片明細commentImagesLists.Select(i => i);
            datas = _MDAcontext.電影評論movieComments.OrderByDescending(c => c.發佈時間commentTime).Select
                    (c => new CCommentViewModel
                    {
                        comment = c,
                        暱稱nickName = c.會員編號member.暱稱nickName,
                        cImgFrList = _MDAcontext.評論圖片明細commentImagesLists.Where(i => i.評論編號commentId == c.評論編號commentId)
                        .Select(c => c.評論圖庫編號commentImage.圖片image).ToList()
                    }).Take(6).ToList();

            return View(datas);
        }
    }
}
