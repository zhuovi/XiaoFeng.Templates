using ELF.Cube.Socket;
using System.Net;
//开始写代码
//在这里写你的业务代码

//服务端代码
var server = Helper.GetServer(1006);
server.Start();


//客户端代码
var client = Helper.GetClient(new System.Net.IPEndPoint(IPAddress.Parse("127.0.0.1"), 1006));
client.Start();


//下边是处理用户在控制台输入数据时的处理

do
{
    Helper.w("请输入:");
    var line = Console.ReadLine();
    if (line.IsNullOrEmpty())
        continue;
    if (line.ToUpper() == "EXIT")
        break;

    Helper.w($"用户输入的数据为:{line}");
    //接到用户从控制台输入的数据进行操作


} while (true);
