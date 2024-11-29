await ApplicationManager.Load(args).RegisterStarted(app =>
{
    //ע���������¼�
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
}, app =>
{

    #region ���Դ��� ���������¿�ɾ��
    /*
    * ==========================================
    * ������Ĭ��ҳ��
    * ��ʽ���к���ɾ�����´���
    * Ĭ��·���� /
    * �������� ��ʾΪվ�������Ϣ
    * �������� ��ʾΪ��Ŀ����
    * ==========================================
    *                     ||
    *                     \/
    */
    app.UseStartPage("/");
    /*
     *                    /\
     *                    ||
     * ==========================================
     * ������Ĭ��ҳ��
     * ��ʽ���к���ɾ�����ϴ���
     * ==========================================
     */
    #endregion

}).ConfigureAwait(false);