﻿//initializing base app namespace and sub-namespaces. Passing App var into global scope.
if (typeof (AutoLogOutApp) == "undefined") {
    AutoLogOutApp = {};
    if (typeof(AutoLogOutApp.Resources) == "undefined") {
        AutoLogOutApp.Resources = {};
    }
}
