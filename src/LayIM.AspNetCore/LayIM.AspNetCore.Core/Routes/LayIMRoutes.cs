﻿using LayIM.AspNetCore.Core.Application;
using LayIM.AspNetCore.Core.Dispatcher;
using LayIM.AspNetCore.Core.IM;
using LayIM.AspNetCore.Core.Models;
using LayIM.AspNetCore.Core.Razor;
using LayIM.AspNetCore.Core.Storage;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Caching.Memory;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace LayIM.AspNetCore.Core.Routes
{
    /// <summary>
    /// 业务实现细节，需要重构，业务不应该放在Routes里
    /// </summary>
    internal sealed partial class LayIMRoutes
    {
        public static RoutesCollection Routes => routes;
        public static IResourceDispatcher ResourceDispatcher
            => ResourceDispatcherCreator.dispatcher;

        static LayIMRoutes()
        {
            RegisterCommands();
            RegisterPages();
        }

        #region 注册相应命令
        /// <summary>
        /// 注册命令
        /// </summary>
        private static void RegisterCommands()
        {
            //获取当前LayIM配置
            routes.AddQuery(LayIMUrls.LAYIM_ROUTE_CONFIG, context =>
            {
                return Task.FromResult(new
                {
                    config = LayIMServiceLocator.Options.UIConfig,
                    uid = context.UserId(),
                    api = UrlConfig.DefaultUrlConfig,
                    other = OtherConfig.DefaultOtherConfig,
                    extend = ExtendConfig.DefaultExtendConfig
                });
            });
            //获取连接websocket的token
            routes.AddQuery(LayIMUrls.LAYIM_ROUTE_IM_TOKEN, async context => await api.Value.GetToken(context.UserId()));
            //layim初始化接口
            routes.AddQuery(LayIMUrls.LAYIM_ROUTE_INIT, async context => await GetInitData(context));
            //群员接口
            routes.AddQuery(LayIMUrls.LAYIM_ROUTE_GROUP_MEMBERS, async context => await GetGroupMembers(context));
            //上传图片
            routes.AddExecute(LayIMUrls.LAYIM_ROUTE_UPLOAD_IMAGE, async context => await GetUploadResult(context, true));
            //上传文件
            routes.AddExecute(LayIMUrls.LAYIM_ROUTE_UPLOAD_FILE, async context => await GetUploadResult(context, false));
            //保存聊天记录
            routes.AddExecute(LayIMUrls.LAYIM_ROUTE_SAVE_CHAT, context => SaveChatMessage(context));
        }
        /// <summary>
        /// 注册页面
        /// </summary>
        private static void RegisterPages()
        {
            routes.AddRazorPage(LayIMUrls.LAYIM_ROUTE_PAGE_CHATLOG, () => new ChatLogPage());
            routes.AddRazorPage(LayIMUrls.LAYIM_ROUTE_PAGE_HISTORY, () => new PartialChatLogBindPage(storage.Value));
        }
        #endregion

        
    }
}
