using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace ThreadSample
{
    public class Program
    {
        private string A = "成员变量";
        public static string B = "静态变量";
        static void Main(string[] args)
        {
            //1、线程常用属性获取：
            //Thread thread = new Thread(OneTest);
            //thread.Name = "Test";
            //thread.Start();


            //2、ParameterizedThreadStart传递参数启动线程
            //string myParam = "abcdef";
            //ParameterizedThreadStart parameterized = new ParameterizedThreadStart(OneTest1);
            //Thread thread = new Thread(parameterized);
            //thread.Start(myParam);


            //3、使用静态变量或类成员变量启动线程
            //Program p = new Program();
            //Thread thread1 = new Thread(p.OneTest3);
            //thread1.Name = "Test1";
            //thread1.Start();
            //Thread thread2 = new Thread(OneTest4);
            //thread2.Name = "Test2";
            //thread2.Start();


            //4、委托Lambda写法
            //Thread thread = new Thread(() =>
            //{
            //    OneTest5("a", "b", 666, new Program());
            //});
            //thread.Name = "Test";
            //thread.Start();


            //5、暂停与阻塞
            //Thread thread = new Thread(OneTest6);
            //thread.Name = "小弟弟";
            //Console.WriteLine($"{DateTime.Now}:大家在吃饭，吃完饭后要带小弟弟逛街");
            //Console.WriteLine("吃完饭了");
            //Console.WriteLine($"{DateTime.Now}:小弟弟开始玩游戏");
            //Console.WriteLine("弟弟在干嘛？(线程状态)：" + Enum.GetName(typeof(ThreadState), GetThreadState(thread.ThreadState)));
            //thread.Start();
            //Console.WriteLine("弟弟在干嘛？(线程状态)：" + Enum.GetName(typeof(ThreadState), GetThreadState(thread.ThreadState)));
            //// 化妆 5 s
            //Console.WriteLine("不管他，大姐姐化妆先"); Thread.Sleep(TimeSpan.FromSeconds(5));
            //Console.WriteLine("弟弟在干嘛？(线程状态)：" + Enum.GetName(typeof(ThreadState), GetThreadState(thread.ThreadState)));
            //Console.WriteLine($"{DateTime.Now}:化完妆，等小弟弟打完游戏");
            //thread.Join();
            ////Join() 也可以实现简单的线程同步，即一个线程等待另一个线程完成。
            //Console.WriteLine("弟弟在干嘛？(线程状态)：" + Enum.GetName(typeof(ThreadState), GetThreadState(thread.ThreadState)));
            //Console.WriteLine("打完游戏了嘛？" + (!thread.IsAlive ? "true" : "false"));
            //Console.WriteLine($"{DateTime.Now}:走，逛街去");


            //6、线程调度顺序及优先级
            //Thread thread1 = new Thread(Test1);
            //Thread thread2 = new Thread(Test2);
            ////设置线程优先级（数值越大优先级越高）
            //thread1.Priority = ThreadPriority.Highest;
            //thread1.Start();
            //thread2.Start();


            //


            Console.ReadKey();
        }

        public static void Test1()
        {
            for (int i = 0; i < 10; i++)
            {
                Console.WriteLine("Test1:" + i);
            }
        }
        public static void Test2()
        {
            for (int i = 0; i < 10; i++)
            {
                Console.WriteLine("Test2:" + i);
            }
        }

        /// <summary>
        /// 获取线程状态
        /// </summary>
        /// <param name="ts"></param>
        /// <returns></returns>
        public static ThreadState GetThreadState(ThreadState ts)
        {
            return ts & (ThreadState.Unstarted |
                ThreadState.WaitSleepJoin |
                ThreadState.Stopped);
        }


        public static void OneTest6()
        {
            Console.WriteLine(Thread.CurrentThread.Name + "开始打游戏");
            for (int i = 0; i < 10; i++)
            {
                Console.WriteLine($"{DateTime.Now}:第几局：" + i);
                Thread.Sleep(TimeSpan.FromSeconds(2));      // 休眠 2 秒
            }
            Console.WriteLine(Thread.CurrentThread.Name + "打完了");
        }

        public static void OneTest5(string a, string b, int c, Program p)
        {
            Console.WriteLine("新的线程已经启动");
        }

        public void OneTest3()
        {
            Console.WriteLine("新的线程已经启动");
            Console.WriteLine(A);       // 本身对象的其它成员
        }
        public static void OneTest4()
        {
            Console.WriteLine("新的线程已经启动");
            Console.WriteLine(B);       // 全局静态变量
        }

        public static void OneTest1(object obj)
        {
            string str = obj as string;
            if (string.IsNullOrEmpty(str))
                return;

            Console.WriteLine("新的线程已经启动");
            Console.WriteLine(str);
        }

        public static void OneTest()
        {
            Thread thisTHread = Thread.CurrentThread;
            Console.WriteLine("线程标识：" + thisTHread.Name);
            Console.WriteLine("当前地域：" + thisTHread.CurrentCulture.Name);  // 当前地域
            Console.WriteLine("线程执行状态：" + thisTHread.IsAlive);
            Console.WriteLine("是否为后台线程：" + thisTHread.IsBackground);
            Console.WriteLine("是否为线程池线程：" + thisTHread.IsThreadPoolThread);
        }

    }
}
