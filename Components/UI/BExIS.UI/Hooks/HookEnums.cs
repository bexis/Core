﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BExIS.UI.Hooks
{
    //The hook status is used to adjust the hook in the UI.
    //This allows the hook to be deactivated, made available or hidden.
    public enum HookStatus
    {
        Disabled = 0, //Function behind the hook is deactivated       
        AccessDenied = 1, // User has no access to the function behind the hook
        Open = 2, // Function behind the hook is ready for use
        Ready = 3, // Function behind the hook was successfully completed
        Exist = 4 // Data behind the hook exists
    }

    public enum HookMode
    {
        view = 0, // this hook becomes the display data       
        edit = 1, // this hook becomes the edit edit
    }
}
