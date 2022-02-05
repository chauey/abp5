using Dna.Abp.EntityFrameworkCore;
using Volo.Abp.Autofac;
using Volo.Abp.BackgroundJobs;
using Volo.Abp.Modularity;

namespace Dna.Abp.DbMigrator;

[DependsOn(
    typeof(AbpAutofacModule),
    typeof(AbpEntityFrameworkCoreModule),
    typeof(AbpApplicationContractsModule)
    )]
public class AbpDbMigratorModule : AbpModule
{
    public override void ConfigureServices(ServiceConfigurationContext context)
    {
        Configure<AbpBackgroundJobOptions>(options => options.IsJobExecutionEnabled = false);
    }
}
