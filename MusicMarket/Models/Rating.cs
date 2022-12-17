﻿using MusicMarket.Areas.Identity.Data;
using System.ComponentModel.DataAnnotations;

namespace MusicMarket.Models
{
    public class Rating
    {
        [Key]
        public int Id { get; set; }
        public int UserId { get; set; }
        public string Text { get; set; }
        public int Score { get; set; }

        public MusicMarketUser User { get; set; }
        public Product Product { get; set; }

    }
}
