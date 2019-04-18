using System;
using System.Collections.Generic;
using System.Linq;
using System.Messaging;
using System.Text;
using System.Threading.Tasks;

namespace MSMQ
{
    public class MqHelper
    {
        /// <summary>
        /// 创建一个消息队列
        /// </summary>
        /// <param name="name">消息队列的名称</param>
        /// <returns>是否创建成功</returns>
        public static bool CreateNewMQ(string name)
        {
            if (!MessageQueue.Exists(".\\private$\\" + name))
            {

                MessageQueue mq = MessageQueue.Create(".\\private$\\" + name);
                mq.Label = "private$\\" + name;
                return true;
            }
            else
            {
                return false;
            }
        }
        /// <summary>
        /// 删除一个消息队列
        /// </summary>
        /// <param name="name">消息队列的名称</param>
        /// <returns>是否创建成功</returns>
        public static bool DeleteNewMQ(string name)
        {
            if (!MessageQueue.Exists(".\\private$\\" + name))
            {
                MessageQueue.Delete(".\\private$\\" + name);
                return true;
            }
            else
            {
                return false;
            }
        }
        /// <summary>
        /// 发送消息到指定消息队列
        /// </summary>
        /// <param name="mq_name">消息队列名称</param>
        /// <param name="msg_lable">消息头</param>
        /// <param name="msg_body">消息体</param>
        public static void SendMessage(string mq_name, string msg_lable, string msg_body)
        {
            MessageQueue mq = new MessageQueue(@".\private$\" + mq_name);
            Message message = new Message();
            message.Label = msg_lable;
            message.Body = msg_body;
            mq.Send(message);
        }
        /// <summary>
        /// 从指定消息队列获取第一条消息
        /// </summary>
        /// <param name="mq_name">消息队列名称</param>
        /// <returns>Message</returns>
        public static Message ReceiveMessage(string mq_name)
        {
            MessageQueue mq = new MessageQueue(@".\private$\" + mq_name);
            if (mq.GetAllMessages().Length > 0)
            {
                Message message = mq.Receive();
                if (message != null)
                {
                    message.Formatter = new XmlMessageFormatter(new Type[] { typeof(string) });
                }
                return message;
            }
            else
            {
                return null;
            }
        }
    }
}
