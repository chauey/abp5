using Dna.Abp.EntityFrameworkCore;
using Volo.Abp.Modularity;

namespace Dna.Abp;

[DependsOn(
    typeof(AbpEntityFrameworkCoreTestModule)
    )]
public class AbpDomainTestModule : AbpModule
{

}
