using System.Text;
using XiaoFeng.Mqtt;
using XiaoFeng.Mqtt.Client;
using XiaoFeng.Mqtt.Server;

/****************************************************************
*  Copyright © (2024) www.eelf.cn All Rights Reserved.          *
*  Author : jacky                                               *
*  QQ : 7092734                                                 *
*  Email : jacky@eelf.cn                                        *
*  Site : www.eelf.cn                                           *
*  Create Time : 2024-08-28 17:12:42                            *
*  Version : v 1.0.0                                            *
*  CLR Version : 4.0.30319.42000                                *
*****************************************************************/
namespace ELF.Cube.Mqtt
{
    /// <summary>
    /// 帮助类
    /// </summary>
    public static class Helper
    {
        /// <summary>
        /// 获取MQTT服务端
        /// </summary>
        /// <param name="port">端口</param>
        /// <returns></returns>
        public static IMqttServer GetMqttServer(int port)
        {
            var server = new MqttServer(port);
            server.AddCredential("testa", "testa123");
            server.OnStarted += o =>
            {
                w("ELF (MQTT) server version 1.0.0 starting.");
                w("Config loaded from elfmqtt.conf.");
                w($"Listen {server.ServerOptions.EndPoint} mqtt://{server.ServerOptions.EndPoint}");
            };
            server.OnStoped += o =>
            {
                w("ELF MQTT Server Version 1.0.0 stoped.");
            };
            server.OnConnected += o =>
            {
                w($"New connection from {o.EndPoint} on port {server.ServerOptions.EndPoint.Port}");
            };
            server.OnError += (o, m) =>
            {
                w($"Error: {m}");
            };
            server.OnDisconnected += o =>
            {
                var data = o.GetClientData();
                var address = "";
                if (data != null && data.ConnectPacket != null)
                    address = data.ConnectPacket.ClientId;
                address += $"[{o.EndPoint}]";
                w($"Client {address} disconnected.");
            };
            server.OnMessage += (o, m) =>
            {
                w(m.Message);
            };
            return server;
        }
        /// <summary>
        /// 获取MQTT客户端
        /// </summary>
        /// <param name="url">服务端地址</param>
        /// <returns></returns>
        public static IMqttClient GetMqttClient(string url)
        {
            var client = new MqttClient(url);
            client.ClientOptions = new MqttClientOptions
            {
                UserName = "testa",
                Password = "testa123",
                ClientId = "EELFMQTT100001",
                KeepAlive = 10,
                ProtocolVersion = MqttProtocolVersion.V500,
                IsAutoConnect = true,
            };
            client.OnStarted += o =>
            {
                w("已连接.");
            };
            client.OnStoped += o =>
            {
                w("已停止.");
            };
            client.OnError += (o, e) =>
            {
                w(e);
            };
            client.OnMessage += p =>
            {
                if (p == null) w("出错");
                else
                {
                    if (p.ResultType == ResultType.Success)
                    {
                        if (p.Message.IsNullOrEmpty())
                            w(p.MqttPacket.ToString());
                        else
                            w(p.Message);
                    }
                    else
                        w(p.Message);
                }
            };
            client.OnPublishMessage += p =>
            {
                w($"Received->{p}");
                if (p.Topic != "$data")
                {
                    if (p.Payload != null && p.Payload.Length > 0)
                        LogHelper.Info(p.Payload.GetString());
                }
            };
            return client;
            //await client.ConnectAsync().ConfigureAwait(false);
            //while (true)
            //{
            //    var aaa = await client.PublishAsync("aa/bb", "aaaaa").ConfigureAwait(false);
            //    w($"send msg:{aaa}");
            //    await Task.Delay(6 * 1000).ConfigureAwait(false);
            //}
            //await client.SubscributeAsync("$data").ConfigureAwait(false);
            //await client.PingAsync().ConfigureAwait(false);
            //await client.PublishAsync("a/b","aaaa").ConfigureAwait(false);


            //await client.UnsubscributeAsync("a/b").ConfigureAwait(false);

        }
        /// <summary>
        /// 输出控制台
        /// </summary>
        /// <param name="msg">消息</param>
        public static void w(object msg)
        {
            var message = "";
            var valType = msg.GetType().GetValueType();
            if (valType == ValueTypes.Value || valType == ValueTypes.String || valType == ValueTypes.Enum) message = msg.ToString();
            else message = msg.ToJson();
            Console.WriteLine($"{message} - {DateTime.Now:yyyy-MM-dd HH:mm:ss.fffffff}");
        }
    }
}