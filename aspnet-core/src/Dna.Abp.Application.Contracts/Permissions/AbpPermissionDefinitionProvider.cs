using Dna.Abp.Localization;
using Volo.Abp.Authorization.Permissions;
using Volo.Abp.Localization;

namespace Dna.Abp.Permissions;

public class AbpPermissionDefinitionProvider : PermissionDefinitionProvider
{
    public override void Define(IPermissionDefinitionContext context)
    {
        var bookStoreGroup = context.AddGroup(AbpPermissions.GroupName, L("Permission:BookStore"));

        var booksPermission = bookStoreGroup.AddPermission(AbpPermissions.Books.Default, L("Permission:Books"));
        booksPermission.AddChild(AbpPermissions.Books.Create, L("Permission:Books.Create"));
        booksPermission.AddChild(AbpPermissions.Books.Edit, L("Permission:Books.Edit"));
        booksPermission.AddChild(AbpPermissions.Books.Delete, L("Permission:Books.Delete"));
    }

    private static LocalizableString L(string name)
    {
        return LocalizableString.Create<AbpResource>(name);
    }
}
