﻿using ClientMDA.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ClientMDA.ViewModels
{
    public class CCommentViewModel
    {
        private 電影評論movieComment _comment;
        private 回覆樓數floor _floor;
        private 標籤明細hashtagsList _hashtagsList;
        private 評論圖片明細commentImagesList _commentImgList;

        public 電影評論movieComment comment
        {
            get { return _comment; }
            set { _comment = value; }
        }
        public 回覆樓數floor floor
        {
            get { return _floor; }
            set { _floor = value; }
        }
        public 標籤明細hashtagsList hashtagsList
        {
            get { return _hashtagsList; }
            set { _hashtagsList = value; }
        }
        public 評論圖片明細commentImagesList commentImgList
        {
            get { return _commentImgList; }
            set { _commentImgList = value; }
        }

        public CCommentViewModel()
        {
            _comment = new 電影評論movieComment();
            _floor = new 回覆樓數floor();
            _hashtagsList = new 標籤明細hashtagsList();
            _commentImgList = new 評論圖片明細commentImagesList();
        }

        //---------------------------電影評論---------------------------//

        [DisplayName("評論編號")]
        public int 評論編號commentId
        {
            get { return _comment.評論編號commentId; }
            set { _comment.評論編號commentId = value; }
        }

        [DisplayName("會員編號")]
        public int 會員編號memberId
        {
            get { return _comment.會員編號memberId; }
            set { _comment.會員編號memberId = value; }
        }

        [DisplayName("電影編號")]
        public int 電影編號movieId
        {
            get { return _comment.電影編號movieId; }
            set { _comment.電影編號movieId = value; }
        }

        [DisplayName("評分")]
        public decimal? 評分rate
        {
            get { return _comment.評分rate; }
            set { _comment.評分rate = value; }
        }

        [DisplayName("期待度")]
        public decimal? 期待度anticipation
        {
            get { return _comment.期待度anticipation; }
            set { _comment.期待度anticipation = value; }
        }

        [DisplayName("評論標題")]
        public string 評論標題commentTitle
        {
            get { return _comment.評論標題commentTitle; }
            set { _comment.評論標題commentTitle = value; }
        }

        [DisplayName("評論內容")]
        public string 評論內容comments
        {
            get { return _comment.評論內容comments; }
            set { _comment.評論內容comments = value; }
        }

        [DisplayFormat(DataFormatString = "{0:yyyy/MM/dd HH:mm}")]
        [DisplayName("發佈時間")]
        public DateTime 發佈時間commentTime
        {
            get { return _comment.發佈時間commentTime; }
            set { _comment.發佈時間commentTime = value; }
        }
        [DisplayFormat(DataFormatString = "{0:yyyy/MM/dd}")]
        [DisplayName("觀影日期")]
        public DateTime? 觀影日期viewingTime
        {
            get { return _comment.觀影日期viewingTime; }
            set { _comment.觀影日期viewingTime = value; }
        }

        [DisplayName("觀影方式")]
        public string 觀影方式source
        {
            get { return _comment.觀影方式source; }
            set { _comment.觀影方式source = value; }
        }

        [DisplayName("公開等級編號")]
        public int? 公開等級編號publicId
        {
            get { return _comment.公開等級編號publicId; }
            set { _comment.公開等級編號publicId = value; }
        }

        //公開等級編號publicId
        //public int 公開等級編號publicId1 { get; set; }
        public string 公開等級public { get; set; }

        [DisplayName("是否開放討論串")]
        public bool? 是否開放討論串oxFloor
        {
            get { return _comment.是否開放討論串oxFloor; }
            set { _comment.是否開放討論串oxFloor = value; }
        }

        [DisplayName("屏蔽")]
        public int 屏蔽invisible
        {
            get { return _comment.屏蔽invisible; }
            set { _comment.屏蔽invisible = value; }
        }

        //public virtual 公開等級編號publicId 公開等級編號public { get; set; }

        //---------------------------電影---------------------------//

        public string 中文標題titleCht { get; set; }

        //public virtual 電影movie 電影編號movie { get; set; }

        //---------------------------會員---------------------------//
        public string 暱稱nickName { get; set; }
        public string 會員照片image { get; set; }

        //public virtual 會員member 會員編號member { get; set; }

        //---------------------------回覆---------------------------//

        //public int 樓數編號floorId { get; set; }
        public string 回覆內容floors { get; set; }
        public DateTime 發佈時間floorTime { get; set; }
        public int? 被按讚次數thumbsUp { get; set; }
        public int? 被倒讚次數thumbsDown { get; set; }
        //public int 屏蔽invisible { get; set; }

        //---------------------------標籤---------------------------//

        public int 標籤明細編號chId { get; set; }
        public int 標籤編號hashtagId { get; set; }

        //標籤總表hashtag
        //public int 標籤編號hashtagId { get; set; }
        public string 標籤hashtag { get; set; }

        //public virtual 標籤總表hashtag 標籤編號hashtag { get; set; }

        //---------------------------評論圖片---------------------------//

        public int 評論圖片編號ccId { get; set; }
        public int 評論圖庫編號commentImageId { get; set; }

        //評論圖片總表commentImage
        //public int 評論圖庫編號commentImageId { get; set; }
        public string 圖片image { get; set; }
        //public int 屏蔽invisible { get; set; }
        //public virtual 評論圖片總表commentImage 評論圖庫編號commentImage { get; set; }

        public List<string> cImgFrList { get; set; }
    }
}
