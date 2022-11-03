using ClientMDA.Models;
using ClientMDA.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace ClientMDA.Controllers
{
    public class HomePageController : Controller
    {
        private readonly ILogger<HomePageController> _logger;
        private readonly MDAContext _MDA;

        public HomePageController(ILogger<HomePageController> logger, MDAContext MDA)
        {
            _logger = logger;
            _MDA = MDA;
        }

        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Index(CHomepageViewModel p)
        {
            if (p.會員編號Member_ID != 0)
            {
                電影評論movieComment m = new 電影評論movieComment();
                m.會員編號memberId = p.會員編號Member_ID;
                m.電影編號movieId = p.電影編號Movie_ID;
                m.評分rate = p.評分Rate;
                m.發佈時間commentTime = p.發佈時間Comment_Time = DateTime.Now;
                _MDA.電影評論movieComments.Add(m);
                _MDA.SaveChanges();
            }
            else if (p.電影編號Movie_IDbook != 0)
            {
                我的片單myMovieList l = new 我的片單myMovieList();
                l.會員編號memberId = p.會員編號Member_IDbook;
                l.片單總表編號movieListId = p.片單總表編號MovieList_ID;
                l.電影編號movieId = p.電影編號Movie_IDbook;
                _MDA.我的片單myMovieLists.Add(l);
                _MDA.SaveChanges();
            }
            else if (p.我的片單MyMovieList_ID != 0)
            {
                我的片單myMovieList l = new 我的片單myMovieList();
                l.我的片單myMovieListId = p.我的片單MyMovieList_ID;
                _MDA.我的片單myMovieLists.Remove(l);
                _MDA.SaveChanges();
            }
            return View();
        }

        public IActionResult 排行()
        {
            var s = (from a in _MDA.電影圖片movieIimagesLists
                     join b in _MDA.電影排行movieRanks on a.圖片編號image.電影名稱movieName equals b.電影movie
                     where a.圖片編號image.電影名稱movieName == b.電影movie
                     orderby b.排行編號rankId ascending
                     select new CHomePageRankViewModel
                     {
                         圖片雲端ImageIMDB = a.圖片編號image.圖片雲端imageImdb,
                         電影編號Movie_ID = a.電影編號movieId,
                         電影Movie = b.電影movie,
                         電影英Movie_En = a.電影編號movie.英文標題titleEng,
                         電影排名Movie_Rank = b.電影排名movieRank,
                         周末票房BoxOffice_Weekend = b.周末票房boxOfficeWeekend,
                         累積票房BoxOffice_Gross=b.累積票房boxOfficeGross,
                         周次Weeks=b.周次weeks,
                     }).ToList();
            return View(s);
        }

        //public IActionResult 新片排行()
        //{
        //    var s = (from a in _MDA.電影圖片movieIimagesLists
        //             join b in _MDA.電影排行movieRanks on a.圖片編號image.電影名稱movieName equals b.電影movie
        //             where a.圖片編號image.電影名稱movieName == b.電影movie
        //             orderby b.排行編號rankId ascending
        //             select new CHomePageRankViewModel
        //             {
        //                 圖片雲端ImageIMDB = a.圖片編號image.圖片雲端imageImdb,
        //                 電影編號Movie_ID = a.電影編號movieId,
        //                 電影Movie = b.電影movie,
        //                 電影英Movie_En = a.電影編號movie.英文標題titleEng,
        //                 電影排名Movie_Rank = b.電影排名movieRank

        //             }).ToList();

        //    return ViewComponent("新片排行", s);
        //}

        [HttpPost]
        public IActionResult 排行(CHomePageRankViewModel p)
        {
            if (p.會員編號Member_ID != 0)
            {
                我的片單myMovieList l = new 我的片單myMovieList();
                l.會員編號memberId = p.電影編號Movie_IDbook;
                l.片單總表編號movieListId = p.片單總表編號MovieList_ID;
                l.電影編號movieId = p.電影編號Movie_IDbook;
                _MDA.我的片單myMovieLists.Add(l);
                _MDA.SaveChanges();
            }
            else if (p.我的片單MyMovieList_ID != 0)
            {
                我的片單myMovieList l = new 我的片單myMovieList();
                l.我的片單myMovieListId = p.我的片單MyMovieList_ID;
                _MDA.我的片單myMovieLists.Remove(l);
                _MDA.SaveChanges();
            }
            return View();
        }

        public IActionResult 本周()
        {
            var d = (from a in _MDA.電影movies
                     join b in _MDA.電影圖片總表movieImages on a.中文標題titleCht equals b.電影名稱movieName
                     where a.上映日期releaseDate >= DateTime.Now.AddDays(-7) && a.上映日期releaseDate <= DateTime.Now.AddDays(7)
                     orderby a.上映日期releaseDate
                     select new CHomePageNewViewModel
                     {
                         電影編號Movie_ID = a.電影編號movieId,
                         中文標題Title_Cht = a.中文標題titleCht,
                         電影英Movie_En = a.英文標題titleEng,
                         期待度anticipation = a.期待度anticipation,
                         片長Runtime = a.片長runtime,
                         上映日期Release_Date = a.上映日期releaseDate,
                         圖片雲端ImageIMDB = b.圖片雲端imageImdb
                     }).ToList();
            return View(d);
        }

        //public IActionResult 本周新片()
        //{
        //    var s = (from a in _MDA.電影圖片movieIimagesLists
        //             join b in _MDA.電影排行movieRanks on a.圖片編號image.電影名稱movieName equals b.電影movie
        //             where a.圖片編號image.電影名稱movieName == b.電影movie
        //             orderby b.排行編號rankId ascending
        //             select new CHomePageRankViewModel
        //             {
        //                 圖片雲端ImageIMDB = a.圖片編號image.圖片雲端imageImdb,
        //                 電影編號Movie_ID = a.電影編號movieId,
        //                 電影Movie = b.電影movie,
        //                 電影英Movie_En = a.電影編號movie.英文標題titleEng,
        //                 電影排名Movie_Rank = b.電影排名movieRank

        //             }).ToList();

        //    return ViewComponent("本周新片", s);
        //}

        public IActionResult 期待()
        {
            var d = (from a in _MDA.電影movies
                     join b in _MDA.電影圖片總表movieImages on a.中文標題titleCht equals b.電影名稱movieName
                     where (a.上映日期releaseDate >= DateTime.Now.AddDays(30) && a.期待度anticipation != null)

                     orderby a.期待度anticipation descending

                     select new CHomePageExpectViewModel
                     {
                         電影編號Movie_ID = a.電影編號movieId,
                         中文標題Title_Cht = a.中文標題titleCht,
                         電影英Movie_En = a.英文標題titleEng,
                         期待度anticipation = a.期待度anticipation,
                         上映日期Release_Date = a.上映日期releaseDate,
                         圖片雲端ImageIMDB = b.圖片雲端imageImdb
                     }).ToList();
            return View(d);
        }


        public IActionResult Privacy()
        {
            return View();
        }

        public IActionResult test3()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }

        public IActionResult test()
        {
            return View();
        }

    }
}
