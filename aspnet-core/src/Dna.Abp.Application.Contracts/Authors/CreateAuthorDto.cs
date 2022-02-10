using System;
using System.ComponentModel.DataAnnotations;

namespace Dna.Abp.Authors
{
    public class CreateAuthorDto
    {
        [Required]
        [StringLength(AuthorConsts.MaxNameLength)]
        public string Name { get; set; }

        [Required]
        public DateTime BirthDate { get; set; }
        
        public string ShortBio { get; set; }

        public Guid AuthorId { get; set; }

    }
}
