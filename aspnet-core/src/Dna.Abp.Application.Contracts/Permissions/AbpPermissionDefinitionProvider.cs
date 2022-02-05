using Dna.Abp.Localization;
using Volo.Abp.Authorization.Permissions;
using Volo.Abp.Localization;

namespace Dna.Abp.Permissions;

public class AbpPermissionDefinitionProvider : PermissionDefinitionProvider
{
    public override void Define(IPermissionDefinitionContext context)
    {
        var myGroup = context.AddGroup(AbpPermissions.GroupName);
        //Define your own permissions here. Example:
        //myGroup.AddPermission(AbpPermissions.MyPermission1, L("Permission:MyPermission1"));
    }

    private static LocalizableString L(string name)
    {
        return LocalizableString.Create<AbpResource>(name);
    }
}
