using System;
namespace subscribed
{
    //用户1类
    class cls_user1
    {
        public void received()
        {
            Console.WriteLine("user1 received!");
        }
    }
    //用户2类
    class cls_user2
    {
        public void receiverd()
        {
            Console.WriteLine("user2 received!");
        }
    }
    //发布类
    class send_message
    {
        public delegate void send();//委托
        public event send sended_all;//事件
        public void sended()
        {
            if (sended_all != null)
            {
                Console.WriteLine("Start to send!");
                sended_all();
            }
        }
    }
    class Program
        {
            static void Main(string[] args)
            {
                cls_user1 user1 = new cls_user1();
                cls_user2 user2 = new cls_user2();
                send_message send_test = new send_message();
                send_test.sended_all += new send_message.send(user1.received); //注册方法
                send_test.sended_all += new send_message.send(user2.receiverd);
                send_test.sended();
            }
        }
}