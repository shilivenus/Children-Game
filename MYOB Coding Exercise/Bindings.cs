using MYOB_Coding_Exercise.Interface;
using Ninject.Modules;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace MYOB_Coding_Exercise
{
    public class Bindings : NinjectModule
    {
        public override void Load()
        {
            Bind<IApiCall>().To<ApiCall>();
            Bind<IEliminator>().To<ChildrenGame>();
            Bind<IExecute>().To<GameController>();
            Bind<IHttpClient>().To<MYOBHttpClient>();
        }
    }
}
