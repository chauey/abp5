using Volo.Abp.Application.Dtos;

namespace Dna.Abp.Authors
{
    public class GetAuthorListDto : PagedAndSortedResultRequestDto
    {
        public string Filter { get; set; }
    }
}
