﻿using System.ComponentModel.DataAnnotations;

namespace BasicASPTutorial.Models
{
    public class Student
    {
        [Key]
        public int Id { get; set; }

        [Required(ErrorMessage = "กรุณาใส่ชื่อนักเรียน")]
        public string Name { get; set; }

        [Required]
        [Range(0, 100, ErrorMessage = "คะแนน 0 - 100")]
        public int Score { get; set; }
    }
}
