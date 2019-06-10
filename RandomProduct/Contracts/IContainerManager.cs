using System;
using System.Collections.Generic;
using System.Text;

namespace RandomProduct.Contracts
{
    public interface IContainerManager
    {
        IContainerManager Register<TContract, TInstance>();
        TContract Resolve<TContract>() where TContract : class;
    }
}
