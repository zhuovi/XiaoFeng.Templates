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