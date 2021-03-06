using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.CSharp;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using NSubstitute.Analyzers.Shared.Extensions;

namespace NSubstitute.Analyzers.CSharp.Extensions
{
    internal static class SyntaxExtensions
    {
        private static readonly int[] ParentInvocationKindHierarchy =
        {
            (int)SyntaxKind.SimpleMemberAccessExpression,
            (int)SyntaxKind.InvocationExpression
        };

        public static InvocationExpressionSyntax GetParentInvocationExpression(this SyntaxNode node)
        {
            return node.GetParentNode(ParentInvocationKindHierarchy) as InvocationExpressionSyntax;
        }
    }
}