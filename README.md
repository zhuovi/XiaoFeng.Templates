# XiaoFeng.Templates

![fayelf](https://camo.githubusercontent.com/4fb01e4715af3d34835b6872ef93a6b21c5371337d44c410d32e8d7c208e196a/68747470733a2f2f7777772e65656c662e636e2f6c6f676f782e706e67)

![GitHub top language](https://img.shields.io/github/languages/top/zhuovi/xiaofeng?logo=github)
![GitHub License](https://img.shields.io/github/license/zhuovi/xiaofeng?logo=github)
![Nuget Downloads](https://img.shields.io/nuget/dt/xiaofeng?logo=nuget)
![Nuget](https://img.shields.io/nuget/v/xiaofeng?logo=nuget)
![Nuget (with prereleases)](https://img.shields.io/nuget/vpre/xiaofeng?label=dev%20nuget&logo=nuget)

Nuget��XiaoFeng.Mvc.Templates

| QQȺ�� | QQȺ | ���ں� |
| :----:| :----: | :----: |
| 748408911  | ![QQ Ⱥ](https://user-images.githubusercontent.com/16105174/198058269-0ea5928c-a2fc-4049-86da-cca2249229ae.png) | ![�����˸��Ƽ�](https://user-images.githubusercontent.com/16105174/198059698-adbf29c3-60c2-4c76-b894-21793b40cf34.jpg) |


Դ�룺 https://github.com/zhuovi/XiaoFeng.Templates

�̳̣� https://www.eelf.cn

ͨ��Visual Studio ��������Ŀ��ͨ����������Ŀʱ����һЩ��Ŀ�е�����������ɴ���XiaoFeng.Mvc��ܵ�����Ŀ��XiaoFeng.Mvc �ʹ��뿪����ܣ����ڴ��� ASP.NET Core Ӧ�ó������Ŀģ�塣��ģ�廹��������REST API��Socket ��Ŀģ�塢Mqtt ��Ŀģ�塣

## ��л֧��

| ���� | LOGO |
| :----:| :----: |
| JetBrains | [![JetBrains](https://github.com/user-attachments/assets/e7fae613-0d85-4c13-be9a-ec343fc30e63)](https://jb.gg/OpenSourceSupport) |
| Visual Studio | [![Visual Studio](https://camo.githubusercontent.com/062bd93be4d796bb609715f79a861eac611ae9e43cf29e7d652f49b306c16b19/68747470733a2f2f76697375616c73747564696f2e6d6963726f736f66742e636f6d2f77702d636f6e74656e742f75706c6f6164732f323032312f31302f50726f647563742d49636f6e2e737667)](https://visualstudio.microsoft.com/) |

## XiaoFeng

XiaoFeng generator with [XiaoFeng](https://github.com/zhuovi/XiaoFeng).

## Install

.NET CLI

```shell
> dotnet new install XiaoFeng.Templates::1.0.0
```


# XiaoFeng ��������
| �����ռ� | ������� | ��Դ״̬ | ˵�� | �������� |
| :----| :---- | :---- | :----: | :---- |
| XiaoFeng.Prototype | XiaoFeng.Core | :white_check_mark: | ��չ�� | ToCase ����ת��<br/>ToTimestamp,ToTimestamps ʱ��תʱ���<br/>GetBasePath ��ȡ�ļ�����·��,֧��Linux,Windows<br/>GetFileName ��ȡ�ļ�����<br/>GetMatch,GetMatches,GetMatchs,IsMatch,ReplacePatten,RemovePattern ������ʽ����<br/> |
| XiaoFeng.Net | XiaoFeng.Net | :white_check_mark: | ����� | XiaoFeng����⣬��װ��Socket�ͻ��ˣ�����ˣ�Socket,WebSocket�������ݵ�ǰ�������ʵ�ֶ��ģ������ȹ��ܡ�|
| XiaoFeng.Http | XiaoFeng.Core | :white_check_mark: | ģ������� | ģ���������� |
| XiaoFeng.Data | XiaoFeng.Core | :white_check_mark: | ���ݿ������ | ֧��SQLSERVER,MYSQL,ORACLE,����,SQLITE,ACCESS,OLEDB,ODBC����ʮ�����ݿ� |
| XiaoFeng.Cache | XiaoFeng.Core | :white_check_mark: | ����� |  �ڴ滺��,Redis,MemcachedCache,MemoryCache,FileCache���� |
| XiaoFeng.Config | XiaoFeng.Core | :white_check_mark: | �����ļ��� | ͨ������ģ���Զ����������ļ�����Ϊxml,json,ini�ļ���ʽ |
| XiaoFeng.Cryptography | XiaoFeng.Core | :white_check_mark: | �����㷨�� | AES,DES,RSA,MD5,DES3,SHA,HMAC,RC4�����㷨 |
| XiaoFeng.Excel | XiaoFeng.Excel | :white_check_mark: | Excel������ | Excel����������excel,�༭excel,��ȡexcel���ݣ��߿����壬��ʽ�ȹ���  |
| XiaoFeng.Ftp | XiaoFeng.Ftp | :white_check_mark: | FTP����� | FTP�ͻ��� |
| XiaoFeng.IO | XiaoFeng.Core | :white_check_mark: | �ļ������� | �ļ���д���� |
| XiaoFeng.Json | XiaoFeng.Core | :white_check_mark: | Json���л��������л��� | Json���л��������л��� |
| XiaoFeng.Xml | XiaoFeng.Core | :white_check_mark: | Xml���л��������л��� | Xml���л��������л��� |
| XiaoFeng.Log | XiaoFeng.Core | :white_check_mark: | ��־�� | д��־�ļ�,���ݿ� |
| XiaoFeng.Memcached | XiaoFeng.Memcached | :white_check_mark: | Memcached����� | Memcached�м��,֧��.NET��ܡ�.NET�ں˺�.NET��׼��,һ�ַǳ���������Ŀͻ��˹��ߡ�ʵ����Set,Add,Replace,PrePend,Append,Cas,Get,Gets,Gat,Gats,Delete,Touch,Stats,Stats Items,Stats Slabs,Stats Sizes,Flush_All,Increment,Decrement,�̳߳ع��ܡ�|
| XiaoFeng.Redis | XiaoFeng.Redis | :white_check_mark: | Redis����� | Redis�м��,֧��.NET��ܡ�.NET�ں˺�.NET��׼��,һ�ַǳ���������Ŀͻ��˹��ߡ�ʵ����Hash,Key,String,ZSet,Stream,Log,List,���ķ���,�̳߳ع���; |
| XiaoFeng.Threading | XiaoFeng.Core | :white_check_mark: | �߳̿� | �߳�����,�̶߳��� |
| XiaoFeng.Mvc | XiaoFeng.Mvc | :x: | �ʹ���WEB������� | .net core �����࣬���ٿ���CMS��ܣ������ĵʹ���ƽ̨���Դ���ɫȨ�ޣ�WebAPIƽ̨����̨�������йܵ�������������Ϊ:Ӧ��.exe install ������ ����˵��,����� delete ɾ�� start ����  stop ֹͣ�� |
| XiaoFeng.Proxy | XiaoFeng.Proxy | :white_check_mark: | ����� | ������ |
| XiaoFeng.TDengine | XiaoFeng.TDengine | :white_check_mark: | TDengine �ͻ��� | ������ |
| XiaoFeng.GB28181 | XiaoFeng.GB28181 | :white_check_mark: | ��Ƶ��ؿ⣬SIP��⣬GB28181Э�� | ������ |
| XiaoFeng.Onvif | XiaoFeng.Onvif | :white_check_mark: | ��Ƶ��ؿ�OnvifЭ�� | XiaoFeng.Onvif ����.NETƽ̨ʹ��C#��װOnvif���ýӿڡ��豸��ý�塢��̨�ȹ��ܣ� �ܾ�WCF�������ö�̬��������wsdl���ļ� �� ʹ��ԭ��XML��չ������Է�װ���������е��������򶼿ɿء� |
| FayElf.Plugins.WeChat | FayElf.Plugins.WeChat | :white_check_mark: | ΢�Ź��ںţ�С������� | ΢�Ź��ںţ�С������⡣ |
| XiaoFeng.Mqtt | XiaoFeng.Mqtt | :white_check_mark: | MQTTЭ�� | XiaoFeng.Mqtt�м��,֧��.NET��ܡ�.NET�ں˺�.NET��׼��,һ�ַǳ���������Ŀͻ��˹��ߡ�ʵ����MQTT�ͻ��ˣ�MQTT�����,ͬʱ֧��TCP��WebSocket���ӡ�֧��Э��汾3.0.0,3.1.0,5.0.0�� |
| XiaoFeng.Modbus | XiaoFeng.Modbus | :white_check_mark: | MODBUSЭ�� | MODBUSЭ��,֧��RTU��ASCII��TCP���ַ�ʽ����ͨ�ţ��Զ����߱����������� |
| XiaoFeng.DouYin | XiaoFeng.DouYin | :white_check_mark: | ��������ƽ̨SDK | ��������ƽ̨�ӿ� |
| XiaoFeng.KuaiShou | XiaoFeng.KuaiShou | :white_check_mark: | ���ֿ���ƽ̨SDK | ���ֿ���ƽ̨�ӿ� |
| XiaoFeng.Mvc.AdminWinDesk | XiaoFeng.Mvc.AdminWinDesk | :white_check_mark: | XiaoFeng.Mvc��̨Ƥ�� | ģ��windows�����̨Ƥ�� |
| FayElf.Cube.Blog | FayElf.Cube.Blog | :white_check_mark: | XiaoFeng.Mvc�����ļ������� | ʹ�õʹ��뿪����ܣ�XiaoFeng.Mvc��+Windows��̨Ƥ��(XiaoFeng.Mvc.AdminWinDesk)��������һ������ƽ̨�� |
| XiaoFeng.Ofd | XiaoFeng.Ofd | :white_check_mark: | OFD��д�� | OFD ��д����⣬֧���ĵ������ɡ��ĵ��༭���ĵ���ע������ǩ�����ĵ��ϲ����ĵ���֡��ĵ�ת����PDF���ĵ���ѯ�ȹ��ܡ� |
| XiaoFeng.Templates | XiaoFeng.Templates | :white_check_mark: | ��Ŀģ�� | XiaoFeng.Mvc �ʹ��뿪����ܣ����ڴ��� ASP.NET Core Ӧ�ó������Ŀģ�塣��ģ�廹��������REST API��ģ�廹��������REST API��Socket ��Ŀģ�塢Mqtt ��Ŀģ�塣 |

## �÷�ʵ��

�� cmd �����������

### ���

```shell
E:\Work\XiaoFeng.Templates> dotnet pack
```

### ��װ

```shell
> dotnet new install XiaoFeng.Templates
```

### ����

```shell
> dotnet new install XiaoFeng.Templates --force
```

### ж��

```shell
> dotnet new uninstall XiaoFeng.Templates
```

## �ĵ�

### ��Ŀģ��̳̼�ʵ��

| ���� | ��ַ |
|:--|:--|
|�̳�|[��Ŀģ��̳���ַ](https://learn.microsoft.com/zh-cn/dotnet/core/tutorials/cli-templates-create-item-template)|
|ʵ��|[��Ŀģ��ʵ����ַ](https://github.com/dotnet/templating)|

