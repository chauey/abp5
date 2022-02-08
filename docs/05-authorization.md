Web Application Development Tutorial - Part 5: Authorization
https://docs.abp.io/en/abp/latest/Tutorials/Part-5?UI=NG&DB=EF

## Permissions
1. Permission Names
    - Update `aspnet-core\src\Dna.Abp.Application.Contracts\Permissions\AbpPermissions.cs`

   ```ts
   namespace Dna.Abp.Permissions;
   {
       public static class AbpPermissions
       {
           public const string GroupName = "Abp";

           public static class Books
           {
               public const string Default = GroupName + ".Books";
               public const string Create = Default + ".Create";
               public const string Edit = Default + ".Edit";
               public const string Delete = Default + ".Delete";
           }
       }
   }

   ```


1. Permission Definitions
    - update `aspnet-core\src\Dna.Abp.Application.Contracts\Permissions\AbpPermissionDefinitionProvider.cs`

    ```cs
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
    ```

...