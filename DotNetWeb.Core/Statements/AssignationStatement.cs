using System;
using System.Collections.Generic;
using System.Text;
using DotNetWeb.Core.Expressions;

namespace DotNetWeb.Core.Statements
{
    public class AssignationStatement : Statement
    {
        public Id Id { get; }
        public TypedExpression Expression { get; }

        public AssignationStatement(Id id, TypedExpression expression)
        {
            Id = id;
            Expression = expression;
        }
        public override void ValidateSemantic()
        {
            if (Id.GetExpressionType() != Expression.GetExpressionType())
            {
                throw new ApplicationException($"Types different");
            }
        }

        public override void Interpret()
        {
            EnvironmentManager.UpdateVariable(Id.Token.Lexeme, Expression.Evaluate());
        }

		public override string Generate(int tabs)
		{
            var code = GetCodeInit(tabs);
            code += $"\n <h>{Id.Generate()} = {Expression.Generate()}</h>{Environment.NewLine}";
            return code;
        }
	}
}
