using Optix.Domain.Library.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Optix.Domain.Library.Implementations
{
    public class OpHttpDriver : IOpHttpDriver
    {
        async Task<T> IOpHttpDriver.GetAsync<T>(Uri uri)
        {
            return await Optix.Domain.Library.Models.OpHttpClasses.HttpGetMethodAsync<T>(uri);

        }
    }
}
