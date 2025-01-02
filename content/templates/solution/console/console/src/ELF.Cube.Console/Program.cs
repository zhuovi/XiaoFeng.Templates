// See https://aka.ms/new-console-template for more information
using XiaoFeng;
//开始写代码
//在这里写你的业务代码
w("Hello, World!");

//下边是处理用户在控制台输入数据时的处理

do
{
    Console.WriteLine("请输入:");
    var line = Console.ReadLine();
    if (line.IsNullOrEmpty())
        continue;
    if (line.ToUpper() == "EXIT")
        break;

    wt($"用户输入的数据为:{line}");
    //接到用户从控制台输入的数据进行操作


} while (true);

/// <summary>
/// 输出控制台
/// </summary>
/// <param name="msg">消息</param>
/// <param name="isTime">是否显示时间</param>
static void w(object msg, bool isTime = false)
{
    var message = "";
    var valType = msg.GetType().GetValueType();
    if (valType == ValueTypes.Value || valType == ValueTypes.String || valType == ValueTypes.Enum) message = msg.ToString();
    else message = msg.ToJson();
    Console.Write($"{message}");
    if (isTime)
        Console.Write($" - {DateTime.Now:yyyy-MM-dd HH:mm:ss.fffffff}");
    Console.WriteLine();
}
/// <summary>
/// 输出控制台
/// </summary>
/// <param name="msg">消息</param>
static void wt(object msg)
{
    w(msg, true);
}