using DotNetWeb.Core.Expressions;
using System;
using System.Collections.Generic;
using System.Text;

namespace DotNetWeb.Core.Statements
{
    public class ExpressionStatement : Statement
    {
        public TypedExpression Expression { get; }

        public ExpressionStatement(TypedExpression expression)
        {
            Expression = expression;
        }
        public override void ValidateSemantic()
        {
            //throw new System.NotImplementedException();
        }

        public override void Interpret()
        {
            Console.WriteLine($"{Expression.Evaluate()}");
        }

		public override string Generate(int tabs)
		{
			throw new NotImplementedException();
		}
	}
}

