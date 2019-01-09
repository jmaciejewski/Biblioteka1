using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Biblioteka1.Models
{
    public class Book
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public long Id { get; set; }

        [Required]
        [StringLength(100, MinimumLength = 3)]
        [Display(Name = "Tytuł")]
        public String Title { get; set; }

        [Required]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        [Display(Name = "Data wydania")]
        [DataType(DataType.Date)]
        [Remote(
            action: "checkDate",
            controller: "Books",
            AdditionalFields = nameof(AuthorId),
            HttpMethod = "POST"
        )]
        public DateTime publicationDate { get; set; }

        [Required]
        [Range(1, Int32.MaxValue)]
        [Display(Name = "Ilość stron")]
        public int? pages { get; set; }

        [Required]
        [Range(1.0, 5.0)]
        [Display(Name = "Ocena")]
        public double rating { get; set; }

        [ForeignKey("Author")]
        [Display(Name = "Autor")]
        public long AuthorId { get; set; }

        public virtual Author Author { get; set; }
    }
}