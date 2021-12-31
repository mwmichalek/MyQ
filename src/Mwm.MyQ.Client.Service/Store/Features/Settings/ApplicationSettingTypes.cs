﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mwm.MyQ.Client.Service.Store.Features.Settings;

public class ApplicationSettingTypes {

    public static List<IApplicationSetting> DefaultSettings = new List<IApplicationSetting> {
        new IsInFocusOnlyTskFilter(),
        new IsGroupedByCompanyFlag(),
        new IsActionStatusOnlyFlag()
    };
}

public class IsInFocusOnlyTskFilter : PrimativeApplicationSetting<bool> {
    public IsInFocusOnlyTskFilter() => CurrentValue = false;
}

public class IsGroupedByCompanyFlag : PrimativeApplicationSetting<bool> {

    public IsGroupedByCompanyFlag() => CurrentValue = true;
}

public class IsActionStatusOnlyFlag : PrimativeApplicationSetting<bool> { 

    public IsActionStatusOnlyFlag() => CurrentValue = false;
}

