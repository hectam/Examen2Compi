using System;
using System.Collections.Generic;
using System.Text;

namespace DotNetWeb.Core.Statements
{
    public interface IExpressionEvaluate
    {
        dynamic Evaluate();
    }
}
