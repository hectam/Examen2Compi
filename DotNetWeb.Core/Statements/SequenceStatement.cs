using System;
using System.Collections.Generic;
using System.Text;
using DotNetWeb.Core.Expressions;

namespace DotNetWeb.Core.Statements
{
    public class SequenceStatement : Statement
    {
        public Statement Statement1 { get; }
        public Statement Statement2 { get; }

        public SequenceStatement(Statement statement1, Statement statement2)
        {
            Statement1 = statement1;
            Statement2 = statement2;
        }

        public static Statement SequenceToken(SequenceExpression expres)
		{
            return new SequenceStatement(
                new AssignationStatement(new Id(expres.Expression1.Token, expres.Expression1.Type),
                    expres.Expression1 as TypedExpression), expres.Expression2 is SequenceExpression sequenceExpression
                    ? SequenceToken(sequenceExpression)
                    : new AssignationStatement(new Id(expres.Expression2.Token, expres.Expression2.Type),
                        expres.Expression2 as TypedExpression));
        }
       
        public override void ValidateSemantic()
        {
            Statement1?.ValidateSemantic();
            Statement2?.ValidateSemantic();
        }

        public override void Interpret()
        {
            Statement1?.Interpret();
            Statement2?.Interpret();
        }

		public override string Generate(int tabs)
		{
            var code = Statement1?.Generate(tabs);
            code += Statement2?.Generate(tabs);
            return code;
        }
	}
}
