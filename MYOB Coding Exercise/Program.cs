using MYOB_Coding_Exercise.Interface;
using MYOB_Coding_Exercise.Model;
using Ninject;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace MYOB_Coding_Exercise
{
    public class Program
    {
        /// <summary>
        /// Application entry point
        /// </summary>
        /// <param name="args"></param>
        public static void Main(string[] args)
        {
            try
            {
                var kernel = new StandardKernel();
                kernel.Load(Assembly.GetExecutingAssembly());

                var gameController = kernel.Get<IExecute>();

                gameController.Execute();
            }
            catch(Exception e)
            {
                Console.WriteLine(e.Message);
            }           
        }
    }
}
