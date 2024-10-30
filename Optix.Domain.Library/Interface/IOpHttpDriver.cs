using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Optix.Domain.Library.Interface
{
    public interface IOpHttpDriver
    {
        Task<T> GetAsync<T>(Uri uri);
    }
}
