await ApplicationManager.Load(args).RegisterStarted(app =>
{
    //注册启动后事件
}).RunAsync(services =>
{
    services.AddControllers()
#if DEBUG
    .AddRazorRuntimeCompilation()
#endif
    .AddXiaoFengJson(options =>
    {
        options.DefaultSettings = new JsonSerializerSetting
        {
            DateTimeFormat = "yyyy-MM-dd HH:mm:ss",
            DateFormat = "yyyy-MM-dd",
            TimeFormat = "HH:mm:ss",
            GuidFormat = "N",
            OmitEmptyNode = true
        };
    });
    services.ConfigureWebApiOptions(options =>
    {
        //webApi
        options.SignatureQueryName = "sign";
        options.CreateSignature = (dict, key) =>
        {
            if (dict == null || dict.Count == 0) return "".SimpleHashEncrypt(key, 3);
            return (from a in dict.Keys select $"{a}={dict[a]}").Join("&").SimpleHashEncrypt(key, 3);
        };
    });
}, app =>
{

    #region 调试代码 生产环境下可删除
    /*
    * ==========================================
    * 启动后默认页面
    * 正式运行后请删除以下代码
    * 默认路由是 /
    * 开发环境 显示为站点参数信息
    * 生产环境 显示为项目名称
    * ==========================================
    *                     ||
    *                     \/
    */
    app.UseStartPage("/");
    /*
     *                    /\
     *                    ||
     * ==========================================
     * 启动后默认页面
     * 正式运行后请删除以上代码
     * ==========================================
     */
    #endregion

}).ConfigureAwait(false);