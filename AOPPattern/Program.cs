using System;
using Castle.DynamicProxy;

namespace AOPPattern
{
    class Program
    {
        static void Main(string[] args)
        {
            var proxyGenerator = new ProxyGenerator();

            var target = new Target();

            var proxy = proxyGenerator.CreateClassProxyWithTarget(target, new LoggingInterceptor());

            proxy.DoSomething();
        }
    }

    public class LoggingInterceptor : IInterceptor
    {
        public void Intercept(IInvocation invocation)
        {
            Console.WriteLine("+++Enter" + invocation.Method.Name);
            invocation.Proceed();
            Console.WriteLine("+++After" + invocation.Method.Name);
        }
    }

    [AttributeUsage(AttributeTargets.Class | AttributeTargets.Method, Inherited = false, AllowMultiple = true)]
    sealed class LoggingAspectAttribute : Attribute
    {
        public LoggingAspectAttribute()
        {
            // TODO: Implement code here
            throw new NotImplementedException();
        }
    }

    [AttributeUsage(AttributeTargets.All, Inherited = false, AllowMultiple = true)]
    sealed class MyAttribute : Attribute
    {
        // See the attribute guidelines at 
        //  http://go.microsoft.com/fwlink/?LinkId=85236
        public MyAttribute()
        {
            // TODO: Implement code here
            throw new NotImplementedException();
        }
    }
    public class Target
    {
        
        [LoggingAspect]
        public virtual void DoSomething(){
            Console.WriteLine("Inside Target");
        }
    }
}
