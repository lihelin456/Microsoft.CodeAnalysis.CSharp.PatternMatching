﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.CodeAnalysis.CSharp.Syntax;

namespace Microsoft.CodeAnalysis.CSharp.PatternMatching
{
    public class VarTypePattern : TypePattern
    {
        private readonly Action<TypeSyntax> _action;

        public VarTypePattern(Action<TypeSyntax> action)
        {
            _action = action;
        }

        public override bool IsMatch(SyntaxNode node, SemanticModel semanticModel = null)
        {
            if (!(node is TypeSyntax typed))
                return false;
            if (!typed.IsVar)
                return false;

            _action?.Invoke(typed);

            return false;
        }
    }
}