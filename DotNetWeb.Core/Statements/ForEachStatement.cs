using System;
using System.Collections.Generic;
using System.Text;

namespace DotNetWeb.Core.Statements
{
    public class ForEachStatement : Statement
    {
        public Statement Statement { get; set; }
        public Token For { get; set; }
        public Token Each { get; set; }
        public ForEachStatement(Token first, Token second, Statement statement)
        {
            For = first;
            Each = second;
            Statement = statement;
        }
       
        public override void Interpret()
        {
            Statement?.Interpret();
        }

        public override void ValidateSemantic()
        {
            Statement?.ValidateSemantic();
        }

        public override string Generate(int tabs)
        {
            var code = Statement.Generate(tabs);
            code += Statement.Generate(tabs + 1);

            return code;
        }
    }
}
