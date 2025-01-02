using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using XiaoFeng.Net;

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
namespace ELF.Cube.Socket
{
    /// <summary>
    /// 帮助类
    /// </summary>
    public static class Helper
    {
        /// <summary>
        /// 获取服务端
        /// </summary>
        /// <param name="port">侦听端口</param>
        /// <returns>ISocketServer</returns>
        public static ISocketServer GetServer(int port)
        {
            //服务端
            var server = new XiaoFeng.Net.SocketServer(port)
            {
                //是否启用pong
                IsPong = true,
                //Pong时间
                PongTime = 30,
                //传输编码
                Encoding = System.Text.Encoding.UTF8,
                //认证 认证不过则直接断开
                Authentication = s =>
                {
                    //判断 客户端是否符合认证,不符合则直接返回false即可
                    return true;
                }
            };
            server.OnStart += (s, e) =>
            {
                //服务端启动事件
                wt($"服务端已启动!");
            };
            server.OnNewConnection += (s, e) =>
            {
                //客户端新连接事件
                wt($"新连接:{s.EndPoint}");
                //给当前客户端设置一个频道名  为后边按频道名发送作准备
                //一个客户端可以订阅多个频道
                //websocket可以从头里面获取标识
                //如果非websocket 可以从消息里设置频道消息
                if (s.RequestHeader.IndexOf("Channel:a") > 0)
                    s.AddChannel("a");
                else
                    s.AddChannel("b");
            };
            server.OnDisconnected += (s, e) =>
            {
                //客户端断开连接事件
                wt($"断开连接:{s.EndPoint}!");
            };
            server.OnMessage += (s, m, e) =>
            {
                //接收消息事件
                if (m.IndexOf("Channel:a") > 0)
                {
                    s.AddChannel("a");
                    return;
                }
                else if (m.IndexOf("Channel:b") > 0)
                {
                    s.AddChannel("b");
                    return;
                }
                wt($"消息:{s.EndPoint}-{m}");
                //把当前消息发送到频道名为a的所有客户端
                server.Send(Encoding.UTF8.GetBytes("消息"));
                //回复当前客户端消息
                s.Send($"接收到客户端消息:{m}");
                //发送消息给所有客户端
                //server.Send("消息");
            };
            server.OnMessageByte += (session, message, e) =>
            {
                //接收消息事件
                //session.Send("回复客户端消息");
            };
            server.OnError += (s, e) =>
            {
                //服务端出错事件
                wt($"出错:{e.Message}");
            };
            server.OnClientError += (c, m, e) =>
            {
                //客户端出错事件
            };
            server.OnError += (session, e) =>
            {
                //服务端出错事件
            };
            server.OnStop += (socket, e) =>
            {
                //服务端停止事件
                wt("服务端已停止");
            };
            //server.Start();
            //添加黑名单
            //server.AddBlack("10.10.10.10");
            //移除黑名单
            //server.RemoveBlack("10.10.10.10");
            //清空黑名单
            //server.ClearBlack();
            //断开所有客户端
            //客户端列表
            //var clients = server.Clients;
            return server;
        }
        /// <summary>
        /// 获取客户端代码
        /// </summary>
        /// <param name="point">服务端终节点</param>
        /// <returns></returns>
        public static ISocketClient GetClient(IPEndPoint point)
        {
            //客户端
            var client = new XiaoFeng.Net.SocketClient(point)
            {
                Encoding = Encoding.UTF8,
                ExclusiveAddressUse = true,
                SocketType = System.Net.Sockets.SocketType.Stream
            };
            client.OnAuthentication += (c, m, e) =>
            {
                //认证代码
            };
            client.OnClientError += (c, m, e) =>
            {
                //出错代码;
                wt(m);
            };
            client.OnMessage += (c, m, e) =>
            {
                //接收消息代码，当前数据为 字符串
                wt(m);
            };
            client.OnMessageByte += (c, m, e) =>
            {
                //接收消息代码，当前数据为 字节数组
            };
            client.OnStart += (c, e) =>
            {
                //启动后事件
                wt("客户端已启动");
            };
            client.OnStop += (c, e) =>
            {
                //停止后代码
                wt("客户端已停止");
            };
            //启动客户端
            //client.Start();
            //client.Send("发送消息");
            //停止客户端
            //client.Stop();
            return client;
        }
        /// <summary>
        /// 输出控制台
        /// </summary>
        /// <param name="msg">消息</param>
        /// <param name="isTime">是否显示时间</param>
        public static void w(object msg, bool isTime = false)
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
        public static void wt(object msg)
        {
            w(msg, true);
        }
    }
}