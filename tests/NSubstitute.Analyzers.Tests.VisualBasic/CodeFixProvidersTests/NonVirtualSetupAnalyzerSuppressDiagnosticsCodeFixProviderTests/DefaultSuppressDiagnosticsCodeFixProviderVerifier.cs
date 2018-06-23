﻿using System.Threading.Tasks;
using Microsoft.CodeAnalysis.CodeFixes;
using Microsoft.CodeAnalysis.Diagnostics;
using NSubstitute.Analyzers.Tests.Shared.CodeFixProviders;
using NSubstitute.Analyzers.VisualBasic.CodeFixProviders;
using NSubstitute.Analyzers.VisualBasic.DiagnosticAnalyzers;
using Xunit;

namespace NSubstitute.Analyzers.Tests.VisualBasic.CodeFixProvidersTests.NonVirtualSetupAnalyzerSuppressDiagnosticsCodeFixProviderTests
{
    public abstract class DefaultSuppressDiagnosticsCodeFixProviderVerifier : VisualBasicSuppressDiagnosticSettingsVerifier, INonVirtualSetupAnalyzerSuppressDiagnosticsCodeFixVerifier
    {
        [Fact]
        public abstract Task SuppressesDiagnosticsInSettings_WhenSettingValueForNonVirtualMethod();

        [Fact]
        public abstract Task SuppressesDiagnosticsInSettings_WhenSettingValueForStaticMethod();

        [Fact]
        public abstract Task SuppressesDiagnosticsInSettings_WhenSettingValueForSealedOverrideMethod();

        [Fact]
        public abstract Task SuppressesDiagnosticsInSettings_WhenSettingValueForNonVirtualProperty();

        [Fact]
        public abstract Task SuppressesDiagnosticsInSettings_WhenSettingValueForNonVirtualIndexer();

        protected override DiagnosticAnalyzer GetDiagnosticAnalyzer()
        {
            return new NonVirtualSetupAnalyzer();
        }

        protected override CodeFixProvider GetCodeFixProvider()
        {
            return new DefaultSuppressDiagnosticsCodeFixProvider();
        }
    }
}