using System;
using System.Collections.Generic;
using System.Text;

namespace AccessFlow.Interfaces
{
    public interface IAccessController
    {
        bool CanAccess(string systemName);
    }
}
