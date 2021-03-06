﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using FluentAssertions;
using Microsoft.CodeAnalysis.CodeActions;
using Microsoft.CodeAnalysis.CodeFixes;
using Microsoft.CodeAnalysis.Diagnostics;
using NSubstitute.Analyzers.Shared.TinyJson;

namespace NSubstitute.Analyzers.Tests.Shared.CodeFixProviders
{
    public abstract class CodeFixCodeActionsVerifier : CodeFixVerifier
    {
        protected async Task VerifyCodeActions(string source, params string[] expectedCodeActionTitles)
        {
            var codeActions = await ApplyFixProvider(GetDiagnosticAnalyzer(), GetCodeFixProvider(), source);

            codeActions.Should().NotBeNull();
            codeActions.Select(action => action.Title).Should().BeEquivalentTo(expectedCodeActionTitles ?? Array.Empty<string>());
        }

        protected override string GetSettings()
        {
            return Json.Encode(new object());
        }

        private async Task<List<CodeAction>> ApplyFixProvider(DiagnosticAnalyzer analyzer, CodeFixProvider codeFixProvider, string source)
        {
            var document = CreateDocument(source);
            var analyzerDiagnostics = await GetSortedDiagnosticsFromDocuments(analyzer, new[] { document }, false);
            var attempts = analyzerDiagnostics.Length;

            var actions = new List<CodeAction>();

            for (var i = 0; i < attempts; ++i)
            {
                var context = new CodeFixContext(document, analyzerDiagnostics[0], (a, d) => actions.Add(a), CancellationToken.None);
                await codeFixProvider.RegisterCodeFixesAsync(context);
            }

            return actions;
        }
    }
}