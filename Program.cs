using System;
using System.Threading;
namespace repayment
{
    class Credit_Card    //信用卡
    {
        private int Credit_Limit = 10000; //总信用额度
        public int Repay_Date = 5;    //每月5号为还款日
        public int Used_Credit_Limit = 0;//已使用额度
        public int Show_Used()
        {
            Console.WriteLine("待还额度：" + Used_Credit_Limit);
            return Used_Credit_Limit;
        }
        public void Use(int num)
        {
            if (Used_Credit_Limit + num > Credit_Limit)
            {
                Console.WriteLine("超出信用额度，支付失败！");
            }
            else
            {
                Used_Credit_Limit += num;
                Console.WriteLine("信用卡花费："+num);
            }
        }
    }
    class Cash_Card    //储蓄卡
    {
        public int Card_balance;//余额
        public  Cash_Card(int Card_balance)
        {
            this.Card_balance = Card_balance;
        }
        public void Use(int num)
        {
            if (num <= Card_balance)
            {
                Card_balance -= num;
                Console.WriteLine("本卡已消费:" + num + "余额:" + Card_balance);
            }
            else
                Console.WriteLine("余额不足！");
        }
        public void used_to_repay()

        {
            Console.WriteLine("本次消费用于信用卡还款");
        }
    }
    class payment
    {
        public void send_message(Credit_Card credit_Card)
        {
            Console.WriteLine("已到还款日，请进行还款：");
            credit_Card.Show_Used();
        }
        public delegate void pay(); //委托
        public event pay pay_all;//事件
        public void payed(int data, Credit_Card credit_Card,Cash_Card cash_Card)
        {
                
            /*触发条件：
                 * 1.进行了正确储蓄卡选择
                 * 2.到达了还款日期
                 * 3.储蓄卡余额大于需要偿还的额度*/
            if (pay_all != null && data== credit_Card.Repay_Date &&cash_Card.Card_balance>= credit_Card.Used_Credit_Limit)
            {
                cash_Card.Use(credit_Card.Used_Credit_Limit);
                pay_all();

            }
            else
            {
                Console.WriteLine("未满足还款条件");
            }
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            Credit_Card Credit_Card1=new Credit_Card();
            Cash_Card Cash_Card1 = new Cash_Card(50000);//卡1余额50000
            Cash_Card Cash_Card2 = new Cash_Card(4000);//卡2余额200

            payment pay_test=new payment();

            for (int i = 1; i <= Credit_Card1.Repay_Date; i++)
            {
                Console.WriteLine("当前日期：  "+i+"  日");    //模拟信用卡使用
                Thread.Sleep(500);
                Credit_Card1.Use(1000);
                if (i==Credit_Card1.Repay_Date)
                {
                    pay_test.send_message(Credit_Card1);    //账单发送
                    Console.WriteLine("储蓄卡1余额：" + Cash_Card1.Card_balance);
                    Console.WriteLine("储蓄卡2余额：" + Cash_Card2.Card_balance);
                    int Cash_Card_Num = Console.Read() - 48;
                    if (Cash_Card_Num == 1)
                    {
                        pay_test.pay_all += new payment.pay(Cash_Card1.used_to_repay);
                        pay_test.payed(i, Credit_Card1, Cash_Card1);
                    }
                    else if (Cash_Card_Num == 2)
                    {                        
                        pay_test.pay_all += new payment.pay(Cash_Card2.used_to_repay);
                        pay_test.payed(i, Credit_Card1, Cash_Card2);
                    }
                        else
                    {
                        Console.WriteLine("该卡不存在，还款失败");
                    }

                }
            }  
        }
    }

}