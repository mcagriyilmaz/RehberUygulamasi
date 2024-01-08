using System.ComponentModel.DataAnnotations;

namespace RehberUygulamasi.Models
{
    public class Rehber
    {
        [Key]
        public int Id { get; set; }
        public string Ad { get; set; } = string.Empty;
        public string? Soyad { get; set; }
        public string TelefonNumarasi { get; set; } = string.Empty;
        public string? Mail { get; set; }
        public string? DogumTarih { get; set; }
        public string? Adres { get; set; }
        public string? Hakkinda { get; set; }
    }
}
