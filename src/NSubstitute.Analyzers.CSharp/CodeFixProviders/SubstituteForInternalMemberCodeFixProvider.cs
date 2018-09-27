using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.CodeFixes;
using Microsoft.CodeAnalysis.CSharp;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using NSubstitute.Analyzers.CSharp.DiagnosticAnalyzers;
using NSubstitute.Analyzers.Shared.CodeFixProviders;
using NSubstitute.Analyzers.Shared.DiagnosticAnalyzers;
using static Microsoft.CodeAnalysis.CSharp.SyntaxFactory;

namespace NSubstitute.Analyzers.CSharp.CodeFixProviders
{
    [ExportCodeFixProvider(LanguageNames.CSharp)]
    internal class SubstituteForInternalMemberCodeFixProvider : AbstractSubstituteForInternalMemberCodeFixProvider<InvocationExpressionSyntax, ExpressionSyntax, CompilationUnitSyntax>
    {
        protected override AbstractSubstituteProxyAnalysis<InvocationExpressionSyntax, ExpressionSyntax> GetSubstituteProxyAnalysis()
        {
            return new SubstituteProxyAnalysis();
        }

        protected override CompilationUnitSyntax AppendInternalsVisibleToAttribute(CompilationUnitSyntax compilationUnitSyntax)
        {
            return compilationUnitSyntax.WithAttributeLists(
                compilationUnitSyntax.AttributeLists.Add(
                    AttributeList(
                            SingletonSeparatedList(
                                Attribute(
                                        QualifiedName(
                                            QualifiedName(
                                                QualifiedName(
                                                    IdentifierName("System"),
                                                    IdentifierName("Runtime")),
                                                IdentifierName("CompilerServices")),
                                            IdentifierName("InternalsVisibleTo")))
                                    .WithArgumentList(
                                        AttributeArgumentList(
                                            SingletonSeparatedList(
                                                AttributeArgument(
                                                    LiteralExpression(
                                                        SyntaxKind.StringLiteralExpression,
                                                        Literal("DynamicProxyGenAssembly2"))))))))
                        .WithTarget(
                            AttributeTargetSpecifier(
                                Token(SyntaxKind.AssemblyKeyword)))));
        }
    }
}