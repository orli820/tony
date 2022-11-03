﻿using ClientMDA.ViewModels;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ClientMDA.ViewConponents
{
    public class 電影排行ViewComponent : ViewComponent //須繼承ViewComponent
    {
        //用這個 async Task<IViewComponentResult> InvokeAsync
        public async Task<IViewComponentResult> InvokeAsync(List<CMovieViewModel> datas)
        {
            return View(datas);
        }
    }
}
