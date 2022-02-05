using System.Threading.Tasks;

namespace Dna.Abp.Data;

public interface IAbpDbSchemaMigrator
{
    Task MigrateAsync();
}
