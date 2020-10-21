using System;
using System.Net;
using static System.Console;
using System.Net.NetworkInformation;
using System.Linq;
using System.Reflection;

namespace WorkingWithNetwork
{
    class Program
    {
        static void Main(string[] args)
        {
            WriteLine("Enter a url: ");
            var url = Console.ReadLine();
            if (string.IsNullOrWhiteSpace(url)){
                url = "https://google.com";
            }
            var uri = new Uri(url);
            WriteLine($"URL:{url}");
            WriteLine($"Scheme:{uri.Scheme}");
            WriteLine($"Port:{uri.Port}");
            WriteLine($"Host:{uri.Host}");
            WriteLine($"Path:{uri.AbsolutePath}");
            WriteLine($"Query:{uri.Query}");

            IPHostEntry entry= Dns.GetHostEntry(uri.Host);
            WriteLine($"{entry.HostName} has the following IP address: ");
            foreach(IPAddress address in entry.AddressList){
                WriteLine($"{address}");
            }

            try {
                var ping = new Ping();
                WriteLine("Pinging server, please wait...");
                PingReply reply= ping.Send(uri.Host);
                WriteLine($"{uri.Host} was pinged and replied {reply.Status}.");
                if (reply.Status == IPStatus.Success){
                    WriteLine("Reply from {0} took {1:N0}ms", reply.Address, reply.RoundtripTime);
                }
            } catch (Exception ex){
                WriteLine($"{ex.GetType().ToString()} says {ex.Message}");
            }

            //CUSTOME ATTRIBUTE
            WriteLine();
            WriteLine($"*Types:");
            var assembly = Assembly.GetEntryAssembly();
            Type[] types = assembly.GetTypes();
            foreach(Type type in types){
                WriteLine();
                WriteLine($"Type:{type.FullName}");
                MemberInfo[] members = type.GetMembers();
                foreach(MemberInfo member in members){
                    WriteLine("{0}:{1}({2})", 
                    arg0: member.MemberType,
                    arg1: member.Name,
                    arg2: member.DeclaringType.Name
                    );
                    var coders = member.GetCustomAttributes<CoderAttribute>().OrderByDescending(c=>c.LastModified);
                    foreach (CoderAttribute coder in coders){
                        WriteLine("-> Modified by {0} on {1}", coder.Coder, coder.LastModified.ToShortDateString());
                    }
                }
            }

        }
        //CUSTOM ATTRIBUTE
        [Coder("Mark's price", "22 August 2020")]
        [Coder("Ron's price", "21 October 2020")]
        public void DoStuff(){
            

        }
    }
}
