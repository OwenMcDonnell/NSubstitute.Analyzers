﻿using System.Threading.Tasks;
using Microsoft.CodeAnalysis.Diagnostics;
using NSubstitute.Analyzers.CSharp.DiagnosticAnalyzers;
using NSubstitute.Analyzers.Tests.Shared.DiagnosticAnalyzers;
using Xunit;

namespace NSubstitute.Analyzers.Tests.CSharp.DiagnosticAnalyzerTests.SubstituteAnalyzerTests
{
    public abstract class SubstituteDiagnosticVerifier : CSharpDiagnosticVerifier, ISubstituteAnalyzerVerifier
    {
        [Fact]
        public abstract Task ReturnsDiagnostic_WhenUsedForClassWithoutPublicOrProtectedConstructor();

        [Fact]
        public abstract Task ReturnsDiagnostic_WhenPassedParametersCount_GreaterThanCtorParametersCount();

        [Fact]
        public abstract Task ReturnsDiagnostic_WhenPassedParametersCount_LessThanCtorParametersCount();

        [Fact]
        public abstract Task ReturnsDiagnostic_WhenUsedWithWithoutProvidingOptionalParameters();

        [Fact]
        public abstract Task ReturnsDiagnostic_WhenUsedWithInternalClass_AndInternalsVisibleToNotApplied();

        [Fact]
        public abstract Task ReturnsNoDiagnostic_WhenUsedWithInternalClass_AndInternalsVisibleToAppliedToDynamicProxyGenAssembly2();

        [Fact]
        public abstract Task ReturnsDiagnostic_WhenUsedWithInternalClass_AndInternalsVisibleToAppliedToWrongAssembly();

        [Fact]
        public abstract Task ReturnsDiagnostic_WhenCorrespondingConstructorArgumentsNotCompatible();

        [Theory]
#pragma warning disable xUnit1003 // Theory methods must have test data
        public abstract Task ReturnsDiagnostic_WhenConstructorArgumentsRequireExplicitConversion(string ctorValues, string invocationValues);
#pragma warning restore xUnit1003 // Theory methods must have test data

        [Theory]
#pragma warning disable xUnit1003 // Theory methods must have test data
        public abstract Task ReturnsNoDiagnostic_WhenConstructorArgumentsAreImplicitlyConvertible(string ctorValues, string invocationValues);
#pragma warning restore xUnit1003 // Theory methods must have test data

        protected override DiagnosticAnalyzer GetDiagnosticAnalyzer()
        {
            return new SubstituteAnalyzer();
        }
    }
}