using ELF.Cube.Mqtt;
//开始写代码
//在这里写你的业务代码

//服务端代码
var server = Helper.GetMqttServer(1006);
server.AddCredential("eelf", "eelf.cn");
server.Start();


//客户端代码
//var client = Helper.GetMqttClient("mqtt://eelf:eelf.cn@127.0.0.1:1006");
//await client.ConnectAsync().ConfigureAwait(false);

/*
//向频道 aa/bb 发送消息 aaaaaa
var aaa = await client.PublishAsync("aa/bb", "aaaaaa").ConfigureAwait(false);
Helper.wt($"send msg:{aaa}");

//订阅
await client.SubscributeAsync("$data").ConfigureAwait(false);
//启动ping
await client.PingAsync().ConfigureAwait(false);
//向频道 a/b 发送消息 aaaa
await client.PublishAsync("a/b", "aaaa").ConfigureAwait(false);

//取消订阅
await client.UnsubscributeAsync("a/b").ConfigureAwait(false);
*/



//下边是处理用户在控制台输入数据时的处理

do
{
    Helper.w("请输入:");
    var line = Console.ReadLine();
    if (line.IsNullOrEmpty())
        continue;
    if (line.ToUpper() == "EXIT")
        break;

    Helper.wt($"用户输入的数据为:{line}");
    //接到用户从控制台输入的数据进行操作


} while (true);
