// See https://aka.ms/new-console-template for more information
using XiaoFeng;
//开始写代码
//在这里写你的业务代码
Console.WriteLine("Hello, World!");

//下边是处理用户在控制台输入数据时的处理

do
{
    Console.WriteLine("请输入:");
    var line = Console.ReadLine();
    if (line.IsNullOrEmpty())
        continue;
    if (line.ToUpper() == "EXIT")
        break;

    w($"用户输入的数据为:{line}");
    //接到用户从控制台输入的数据进行操作


} while (true);

//输出控制台
static void w(object msg)
{
    var message = "";
    var valType = msg.GetType().GetValueType();
    if (valType == ValueTypes.Value || valType == ValueTypes.String || valType == ValueTypes.Enum) message = msg.ToString();
    else message = msg.ToJson();
    Console.WriteLine($"{message} - {DateTime.Now:yyyy-MM-dd HH:mm:ss.fffffff}");
}