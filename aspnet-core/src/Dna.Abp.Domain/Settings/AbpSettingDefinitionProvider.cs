﻿using Volo.Abp.Settings;

namespace Dna.Abp.Settings;

public class AbpSettingDefinitionProvider : SettingDefinitionProvider
{
    public override void Define(ISettingDefinitionContext context)
    {
        //Define your own settings here. Example:
        //context.Add(new SettingDefinition(AbpSettings.MySetting1));
    }
}
