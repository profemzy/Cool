﻿using System;
using System.ComponentModel.DataAnnotations;

namespace Cool.Models
{
    public class Book
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public string Name { get; set; }
    }
}