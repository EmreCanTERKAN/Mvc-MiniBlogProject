using System.ComponentModel.DataAnnotations;

namespace WebApplication1.Models
{
    public class BlogPost
    {
        public int Id { get; set; }

        //Gerekli olan koşulları tanımlıyoruz..
        [Required(ErrorMessage ="Başlık Gereklidir.")]
        [StringLength(100,ErrorMessage = "100 karakterden fazla olamaz")]
        public string Title { get; set; }
        [Required(ErrorMessage ="İçerik Gereklidir..")]
        public string Contant { get; set; }
        // Oluşturulduğunda default olarak o anki zamanı vercektir
        public DateTime CreatedAt { get; set; } = DateTime.Now;
    }
}
