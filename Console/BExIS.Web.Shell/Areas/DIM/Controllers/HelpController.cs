﻿using System.Web.Mvc;
using Vaiona.Web.Mvc.Models;
using Vaiona.Web.Extensions;
using Vaiona.Utils.Cfg;
using System.Xml.Linq;
using System.IO;
using BExIS.Xml.Helpers;
using BExIS.UI.Helpers;
using Vaiona.Web.Mvc.Modularity;

namespace BExIS.Modules.Dim.UI.Controllers
{
    public class HelpController : Controller
    {
        //
        // GET: /DDM/Help/

        public ActionResult Index()
        {
            var moduleInfo = ModuleManager.GetModuleInfo("DIM");
            string helpurl = moduleInfo.Plugin.Settings.GetEntryValue("help").ToString();

            return Redirect(helpurl);
        }
    }
}