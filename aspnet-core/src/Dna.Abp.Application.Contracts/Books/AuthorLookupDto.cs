using System;
using Volo.Abp.Application.Dtos;

namespace Dna.Abp.Books
{
    public class AuthorLookupDto : EntityDto<Guid>
    {
        public string Name { get; set; }
    }
}
