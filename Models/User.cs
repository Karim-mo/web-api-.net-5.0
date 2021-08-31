using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace web_api_course_.net_5._0.Models
{
    public class User
    {
        public int id { get; set; }
        [Required]
        public string name { get; set; }
        [Required]
        public string email { get; set; }
        [Required]
        public byte[] password { get; set; }
        [Required]
        public byte[] passwordSalt { get; set; }
        public List<Character> characters { get; set; }
    }
}