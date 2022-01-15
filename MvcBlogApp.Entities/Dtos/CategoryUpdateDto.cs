using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MvcBlogApp.Entities.Dtos
{
    public class CategoryUpdateDto
    {
        [Required]
        public int Id { get; set; }
        [DisplayName("Kategori Adı")]
        [Required(ErrorMessage = "{0} boş geçilemez")]
        [MaxLength(70, ErrorMessage = "{0} {1} karakterden uzun olamaz")]
        [MinLength(5, ErrorMessage = "{0} {1} karakterden kısa olamaz")]
        public string Name { get; set; }
        [DisplayName("Kategori Açıklaması")]
        [Required(ErrorMessage = "{0} boş geçilemez")]
        [MaxLength(500, ErrorMessage = "{0} {1} karakterden uzun olamaz")]
        [MinLength(5, ErrorMessage = "{0} {1} karakterden kısa olamaz")]
        public string Description { get; set; }
        [DisplayName("Kategori Not Alanı")]
        [Required(ErrorMessage = "{0} boş geçilemez")]
        [MaxLength(70, ErrorMessage = "{0} {1} karakterden uzun olamaz")]
        [MinLength(5, ErrorMessage = "{0} {1} karakterden kısa olamaz")]
        public string Note { get; set; }
        [DisplayName("Aktif mi?")]
        [Required(ErrorMessage = "{0} boş geçilemez")]
        public bool IsActive { get; set; }
        [DisplayName("Silindi mi?")]
        [Required(ErrorMessage = "{0} boş geçilemez")]
        public bool IsDeleted { get; set; }
    }
}
