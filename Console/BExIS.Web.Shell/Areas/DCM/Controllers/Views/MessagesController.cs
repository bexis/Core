﻿using BExIS.App.Bootstrap.Attributes;
using BExIS.Dlm.Entities.Data;
using BExIS.Security.Entities.Authorization;
using BExIS.UI.Hooks;
using BExIS.UI.Hooks.Caches;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Vaiona.Utils.Cfg;

namespace BExIS.Modules.Dcm.UI.Controllers
{
    public class MessagesController : Controller
    {
        /// <summary>
        /// resultmessages view need to load the svelte builded script
        /// </summary>
        /// <returns></returns>
        [BExISEntityAuthorize(typeof(Dataset), "id", RightType.Write)]
        public ActionResult Start(long id, int version = 0)
        {
            string filepath = Path.Combine(AppConfiguration.AppRoot, "Areas/DCM/Scripts/svelte/messages.js");
            return File(filepath, "application/javascript");
        }

        /// <summary>
        /// load ResultMessages from the cuirrent EditDatasetDetailsCache
        /// </summary>
        /// <param name="id"></param>
        /// <param name="version"></param>
        /// <returns></returns>
        [BExISEntityAuthorize(typeof(Dataset), "id", RightType.Write)]
        [JsonNetFilter]
        public JsonResult Load(long id, int version = 0)
        {
            List<ResultMessage> messages = new List<ResultMessage>();

            var hookManager = new HookManager();
            var cache = hookManager.LoadCache<EditDatasetDetailsCache>("dataset", "details", HookMode.edit, id);

            if (cache != null && cache.Messages.Any())
            {
                messages = cache.Messages.ToList();
            }

            return Json(messages, JsonRequestBehavior.AllowGet);
        }
    }
}