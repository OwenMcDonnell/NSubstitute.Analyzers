﻿using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.CSharp;
using NSubstitute.Analyzers.Tests.Shared.CodeFixProviders;

namespace NSubstitute.Analyzers.Tests.CSharp.CodeFixProviderTests
{
    public abstract class CSharpCodeFixVerifier : CodeFixVerifier
    {
        protected override string Language { get; } = LanguageNames.CSharp;

        protected override string FileExtension { get; } = "cs";

        protected override CompilationOptions GetCompilationOptions()
        {
            return new CSharpCompilationOptions(OutputKind.DynamicallyLinkedLibrary);
        }
    }
}