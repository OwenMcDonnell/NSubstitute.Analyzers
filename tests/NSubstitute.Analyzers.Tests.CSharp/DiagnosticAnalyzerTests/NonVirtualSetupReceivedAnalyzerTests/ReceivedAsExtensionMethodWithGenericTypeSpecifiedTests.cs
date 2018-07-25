﻿using System.Threading.Tasks;
using Microsoft.CodeAnalysis;
using NSubstitute.Analyzers.Shared;
using NSubstitute.Analyzers.Tests.Shared.DiagnosticAnalyzers;

namespace NSubstitute.Analyzers.Tests.CSharp.DiagnosticAnalyzerTests.NonVirtualSetupReceivedAnalyzerTests
{
    public class ReceivedAsExtensionMethodWithGenericTypeSpecifiedTests : NonVirtualSetupReceivedDiagnosticVerifier
    {
        public override async Task ReportsDiagnostics_WhenCheckingReceivedCallsForNonVirtualMethod()
        {
            var source = @"using NSubstitute;

namespace MyNamespace
{
    public class Foo
    {
        public int Bar()
        {
            return 2;
        }
    }

    public class FooTests
    {
        public void Test()
        {
            var substitute = NSubstitute.Substitute.For<Foo>();
            substitute.Received<Foo>().Bar();
        }
    }
}";
            var expectedDiagnostic = new DiagnosticResult
            {
                Id = DiagnosticIdentifiers.NonVirtualReceivedSetupSpecification,
                Severity = DiagnosticSeverity.Warning,
                Message = "Member Bar can not be intercepted. Only interface members and virtual, overriding, and abstract members can be intercepted.",
                Locations = new[]
                {
                    new DiagnosticResultLocation(18, 13)
                }
            };

            await VerifyDiagnostic(source, expectedDiagnostic);
        }

        public override async Task ReportsNoDiagnostics_WhenCheckingReceivedCallsForVirtualMethod()
        {
            var source = @"using NSubstitute;

namespace MyNamespace
{
    public class Foo
    {
        public virtual int Bar()
        {
            return 2;
        }
    }

    public class FooTests
    {
        public void Test()
        {
            var substitute = NSubstitute.Substitute.For<Foo>();
            substitute.Received<Foo>().Bar();
        }
    }
}";
            await VerifyDiagnostic(source);
        }

        public override async Task ReportsNoDiagnostics_WhenCheckingReceivedCallsForNonSealedMethod()
        {
            var source = @"using NSubstitute;

namespace MyNamespace
{
    public class Foo
    {
        public virtual int Bar()
        {
            return 2;
        }
    }

    public class Foo2 : Foo
    {
        public override int Bar() => 1;
    }

    public class FooTests
    {
        public void Test()
        {
            var substitute = NSubstitute.Substitute.For<Foo2>();
            substitute.Received<Foo2>().Bar();
        }
    }
}";
            await VerifyDiagnostic(source);
        }

        public override async Task ReportsNoDiagnostics_WhenCheckingReceivedCallsForDelegate()
        {
            var source = @"using NSubstitute;
using System;

namespace MyNamespace
{
    public class FooTests
    {
        public void Test()
        {
            var substitute = Substitute.For<Func<int>>();
            substitute.Received<Func<int>>()();
        }
    }
}";
            await VerifyDiagnostic(source);
        }

        public override async Task ReportsDiagnostics_WhenCheckingReceivedCallsForSealedMethod()
        {
            var source = @"using NSubstitute;

namespace MyNamespace
{
    public class Foo
    {
        public virtual int Bar()
        {
            return 2;
        }
    }

    public class Foo2 : Foo
    {
        public sealed override int Bar() => 1;
    }

    public class FooTests
    {
        public void Test()
        {
            var substitute = NSubstitute.Substitute.For<Foo2>();
            substitute.Received<Foo2>().Bar();
        }
    }
}";
            var expectedDiagnostic = new DiagnosticResult
            {
                Id = DiagnosticIdentifiers.NonVirtualReceivedSetupSpecification,
                Severity = DiagnosticSeverity.Warning,
                Message =
                    "Member Bar can not be intercepted. Only interface members and virtual, overriding, and abstract members can be intercepted.",
                Locations = new[]
                {
                    new DiagnosticResultLocation(23, 13)
                }
            };

            await VerifyDiagnostic(source, expectedDiagnostic);
        }

        public override async Task ReportsNoDiagnostics_WhenCheckingReceivedCallsForAbstractMethod()
        {
            var source = @"using NSubstitute;

namespace MyNamespace
{
    public abstract class Foo
    {
        public abstract int Bar();
    }

    public class FooTests
    {
        public void Test()
        {
            var substitute = NSubstitute.Substitute.For<Foo>();
            substitute.Received<Foo>().Bar();
        }
    }
}";

            await VerifyDiagnostic(source);
        }

        public override async Task ReportsNoDiagnostics_WhenCheckingReceivedCallsForInterfaceMethod()
        {
            var source = @"using NSubstitute;

namespace MyNamespace
{
    public interface IFoo
    {
        int Bar();
    }

    public class FooTests
    {
        public void Test()
        {
            var substitute = NSubstitute.Substitute.For<IFoo>();
            substitute.Received<IFoo>().Bar();
        }
    }
}";
            await VerifyDiagnostic(source);
        }

        public override async Task ReportsNoDiagnostics_WhenCheckingReceivedCallsForInterfaceProperty()
        {
            var source = @"using NSubstitute;

namespace MyNamespace
{
    public interface IFoo
    {
        int Bar { get; }
    }

    public class FooTests
    {
        public void Test()
        {
            var substitute = NSubstitute.Substitute.For<IFoo>();
            var x = substitute.Received<IFoo>().Bar;
        }
    }
}";
            await VerifyDiagnostic(source);
        }

        public override async Task ReportsNoDiagnostics_WhenCheckingReceivedCallsForGenericInterfaceMethod()
        {
            var source = @"using NSubstitute;

namespace MyNamespace
{
   public interface IFoo<T>
    {
        int Bar<T>();
    }

    public class FooTests
    {
        public void Test()
        {
            var substitute = NSubstitute.Substitute.For<IFoo<int>>();
            substitute.Received<IFoo<int>>().Bar<int>();
        }
    }
}";
            await VerifyDiagnostic(source);
        }

        public override async Task ReportsNoDiagnostics_WhenCheckingReceivedCallsForAbstractProperty()
        {
            var source = @"using NSubstitute;

namespace MyNamespace
{
    public abstract class Foo
    {
        public abstract int Bar { get; }
    }

    public class FooTests
    {
        public void Test()
        {
            var substitute = NSubstitute.Substitute.For<Foo>();
            var x = substitute.Received<Foo>().Bar;
        }
    }
}";

            await VerifyDiagnostic(source);
        }

        public override async Task ReportsNoDiagnostics_WhenCheckingReceivedCallsForInterfaceIndexer()
        {
            var source = @"using NSubstitute;

namespace MyNamespace
{
    public interface IFoo
    {
        int this[int i] { get; }
    }

    public class FooTests
    {
        public void Test()
        {
            var substitute = NSubstitute.Substitute.For<IFoo>();
            var x = substitute.Received<IFoo>()[1];
        }
    }
}";
            await VerifyDiagnostic(source);
        }

        public override async Task ReportsNoDiagnostics_WhenCheckingReceivedCallsForVirtualProperty()
        {
            var source = @"using NSubstitute;

namespace MyNamespace
{
    public class Foo
    {
        public virtual int Bar { get; }
    }

    public class FooTests
    {
        public void Test()
        {
            var substitute = NSubstitute.Substitute.For<Foo>();
            var x = substitute.Received<Foo>().Bar;
        }
    }
}";

            await VerifyDiagnostic(source);
        }

        public override async Task ReportsDiagnostics_WhenCheckingReceivedCallsForNonVirtualProperty()
        {
            var source = @"using NSubstitute;

namespace MyNamespace
{
    public class Foo
    {
        public int Bar { get; }
    }

    public class FooTests
    {
        public void Test()
        {
            var substitute = NSubstitute.Substitute.For<Foo>();
            var x = substitute.Received<Foo>().Bar;
        }
    }
}";

            var expectedDiagnostic = new DiagnosticResult
            {
                Id = DiagnosticIdentifiers.NonVirtualReceivedSetupSpecification,
                Severity = DiagnosticSeverity.Warning,
                Message =
                    "Member Bar can not be intercepted. Only interface members and virtual, overriding, and abstract members can be intercepted.",
                Locations = new[]
                {
                    new DiagnosticResultLocation(15, 21)
                }
            };

            await VerifyDiagnostic(source, expectedDiagnostic);
        }

        public override async Task ReportsNoDiagnostics_WhenCheckingReceivedCallsForVirtualIndexer()
        {
            var source = @"using NSubstitute;

namespace MyNamespace
{
    public class Foo
    {
        public virtual int this[int x] => 0;
    }

    public class FooTests
    {
        public void Test()
        {
            var substitute = NSubstitute.Substitute.For<Foo>();
            var x = substitute.Received<Foo>()[1];
        }
    }
}";
            await VerifyDiagnostic(source);
        }

        public override async Task ReportsDiagnostics_WhenCheckingReceivedCallsForNonVirtualIndexer()
        {
            var source = @"using NSubstitute;

namespace MyNamespace
{
    public class Foo
    {
        public int this[int x] => 0;
    }

    public class FooTests
    {
        public void Test()
        {
            var substitute = NSubstitute.Substitute.For<Foo>();
            var x = substitute.Received<Foo>()[1];
        }
    }
}";

            var expectedDiagnostic = new DiagnosticResult
            {
                Id = DiagnosticIdentifiers.NonVirtualReceivedSetupSpecification,
                Severity = DiagnosticSeverity.Warning,
                Message =
                    "Member this[] can not be intercepted. Only interface members and virtual, overriding, and abstract members can be intercepted.",
                Locations = new[]
                {
                    new DiagnosticResultLocation(15, 21)
                }
            };

            await VerifyDiagnostic(source, expectedDiagnostic);
        }

        public override async Task ReportsNoDiagnostics_WhenUsingUnfortunatelyNamedMethod()
        {
            var source = @"

namespace NSubstitute
{
    public class Foo
    {
        public int Bar()
        {
            return 1;
        }
    }

    public static class SubstituteExtensions
    {
        public static T Received<T>(this T returnValue, decimal x)
        {
            return default(T);
        }
    }

    public class FooTests
    {
        public void Test()
        {
            Foo substitute = null;
            substitute.Received(1m).Bar();
        }
    }
}";
            await VerifyDiagnostic(source);
        }
    }
}