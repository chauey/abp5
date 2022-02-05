using Volo.Abp.Modularity;

namespace Dna.Abp;

[DependsOn(
    typeof(AbpApplicationModule),
    typeof(AbpDomainTestModule)
    )]
public class AbpApplicationTestModule : AbpModule
{

}
