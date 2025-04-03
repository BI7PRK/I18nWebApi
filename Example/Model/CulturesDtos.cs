using System.ComponentModel.DataAnnotations;

namespace I18nWebApi.Model
{
    public class CulturesDtos
    {
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        public string Code { get; set; }

        public bool IsDefault { get; set; }
    }

    public class CulturesKeyDtos
    {
        public int Id { get; set; }
        [Required]
        public string Key { get; set; }

        public int TypeId { get; set; }

    }

    public class UserLoginDtos
    {
        [Required]
        public string Username { get; set; }
        [Required]
        public string Password { get; set; }
    }
}
