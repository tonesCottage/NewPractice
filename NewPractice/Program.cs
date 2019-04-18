using BISNETTurboClientRefWS;
using MSMQ;
using Newtonsoft.Json;
using System;
using System.Messaging;

namespace NewPractice
{
    class Program
    {
        public string key { set; get; }
        public delegate void MyDelegate(params int[] args);
        public static void TestMethod(int value)
        {
            int i = value;
        }
        public void TestMethod(uint value) { }
        public static void TestMethod<T>(params T[] arg) { }
        static void Main(string[] args)
        {
            int MaterialUnit = Int32.Parse("0.51267");
            string str = "{'key':'123456789'}";
            Type type = typeof(Program);
            Type tp = JsonConvert.DeserializeObject<Type>(str);

            
            Action<int> act =(Action<int>) Delegate.CreateDelegate(typeof(Action<int>), type.GetMethod("TestMethod"));
            act(10);

            MqHelper.SendMessage("TestMq", "test", "fuck denglu");
            Message message = MqHelper.ReceiveMessage("TestMq");
            Console.WriteLine(message.Body);
            Console.ReadLine();
        }
    }
}
