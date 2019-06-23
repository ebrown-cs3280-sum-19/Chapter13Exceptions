using System;
using System.Reflection;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exceptions
{
    class Program
    {
        /// <summary>
        /// simulating high level method
        /// </summary>
        private void Method0()
        {
            try
            {
                Method1();
            }
            catch(Exception ex) // exception type you want to catch
            {
                string className = MethodInfo.GetCurrentMethod().DeclaringType.Name;
                string methodName = MethodInfo.GetCurrentMethod().Name;
                string message = ex.Message;
                HandleError(className, methodName, message);
            }
            finally
            {
                // code that will always run
                // would be used to close connections
            }
        }
        /// <summary>
        /// simulating a lower level method
        /// </summary>
        private void Method1()
        {
            try
            {
                Method2();
            }
            catch (Exception ex)
            {
                string className = MethodInfo.GetCurrentMethod().DeclaringType.Name;
                string methodName = MethodInfo.GetCurrentMethod().Name;
                string message = ex.Message;
                throw new Exception($"{className}.{methodName}->{message}");
            }
        }
        /// <summary>
        /// simulating a lower level method
        /// </summary>
        private void Method2()
        {
            try
            {
                int j = 0;
                j = 5 / j; // throws exeption
            }
            catch (Exception ex)
            {
                string className = MethodInfo.GetCurrentMethod().DeclaringType.Name;
                string methodName = MethodInfo.GetCurrentMethod().Name;
                string message = ex.Message;
                throw new Exception($"{className}.{methodName}->{message}");
            }
        }

        private void Method0NoCatch()
        {
            Method2StackTrace();
        }

        private void Method2StackTrace()
        {
            try
            {
                int j = 0;
                j = 5 / j;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.StackTrace);
                throw ex;
            }
        }

        private void HandleError(string className, string method, string message)
        {
            try
            {
                Console.WriteLine($"{className}.{method}->{message}");
            }
            catch (Exception ex)
            {

                System.IO.File.AppendAllText(@"C:\Users\Public\error.txt", 
                    $"{Environment.NewLine} HandleError Exception: {ex.Message}");
            }
           
        }

        static void Main(string[] args)
        {
            Program p = new Program();
            p.Method0();
            Console.ReadLine();
            p.Method0NoCatch();
            Console.ReadLine();
        }
    }
}
