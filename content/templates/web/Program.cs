await ApplicationManager.Load(args).RegisterStarted(app =>
{
    //注册启动后事件
}).RunAsync(() => WebHost.CreateHost(args, services =>
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
            GuidFormat = "N",
            OmitEmptyNode = true
        };
    });
}, app =>
{
    /*
     * 启动后默认页面
     * 正式运行后请删除下边代码
     */
    app.MapGet("/", async context =>
    {
        var Response = context.Response;
        await Response.WriteHtmlAsync(@"<div class=""fay-title"" style=""width:800px;font-size:50px;line-height:80px;margin:auto;"">魔法精灵</div>").ConfigureAwait(false);
        await Task.CompletedTask;
    });
    /*
     * 启动后默认页面
     * 正式运行后请删除上边代码
     */
})).ConfigureAwait(false);