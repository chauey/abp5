using Volo.Abp;

namespace Dna.Abp.Authors
{
    public class AuthorAlreadyExistsException : BusinessException
    {
        public AuthorAlreadyExistsException(string name)
            : base(AbpDomainErrorCodes.AuthorAlreadyExists)
        {
            WithData("name", name);
        }
    }
}
