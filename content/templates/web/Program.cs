await ApplicationManager.Load(args).RegisterStarted(app =>
{
    //ע���������¼�
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
     * ������Ĭ��ҳ��
     * ��ʽ���к���ɾ���±ߴ���
     */
    app.MapGet("/", async context =>
    {
        var Response = context.Response;
        await Response.WriteHtmlAsync(@"<div class=""fay-title"" style=""width:800px;font-size:50px;line-height:80px;margin:auto;"">ħ������</div>").ConfigureAwait(false);
        await Task.CompletedTask;
    });
    /*
     * ������Ĭ��ҳ��
     * ��ʽ���к���ɾ���ϱߴ���
     */
})).ConfigureAwait(false);