﻿using System.Threading.Tasks;
using Microsoft.CodeAnalysis;
using NSubstitute.Analyzers.Shared;
using NSubstitute.Analyzers.Tests.Shared.DiagnosticAnalyzers;

namespace NSubstitute.Analyzers.Tests.VisualBasic.DiagnosticAnalyzersTests.NonVirtualSetupReceivedAnalyzerTests
{
    public class ReceivedAsOrdinaryMethodWithGenericTypeSpecifiedTests : NonVirtualSetupReceivedDiagnosticVerifier
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
            SubstituteExtensions.Received<Foo>(substitute).Bar();
        }
    }
}";
            var expectedDiagnostic = new DiagnosticResult
            {
                Id = DiagnosticIdentifiers.NonVirtualReceivedSetupSpecification,
                Severity = DiagnosticSeverity.Warning,
                Message = "Member Bar can not be intercepted. Only interface members and overrideable, overriding, and must override members can be intercepted.",
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
            SubstituteExtensions.Received<Foo>(substitute).Bar();
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
            SubstituteExtensions.Received<Foo2>(substitute).Bar();
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
            SubstituteExtensions.Received<Func<int>>(substitute)();
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
            SubstituteExtensions.Received<Foo2>(substitute).Bar();
        }
    }
}";
            var expectedDiagnostic = new DiagnosticResult
            {
                Id = DiagnosticIdentifiers.NonVirtualReceivedSetupSpecification,
                Severity = DiagnosticSeverity.Warning,
                Message =
                    "Member Bar can not be intercepted. Only interface members and overrideable, overriding, and must override members can be intercepted.",
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
            SubstituteExtensions.Received<Foo>(substitute).Bar();
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
            SubstituteExtensions.Received<IFoo>(substitute).Bar();
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
            var x = SubstituteExtensions.Received<IFoo>(substitute).Bar;
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
            SubstituteExtensions.Received<IFoo<int>>(substitute).Bar<int>();
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
            var x = SubstituteExtensions.Received<Foo>(substitute).Bar;
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
            var x = SubstituteExtensions.Received<IFoo>(substitute)[1];
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
            var x = SubstituteExtensions.Received<Foo>(substitute).Bar;
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
            var x = SubstituteExtensions.Received<Foo>(substitute).Bar;
        }
    }
}";

            var expectedDiagnostic = new DiagnosticResult
            {
                Id = DiagnosticIdentifiers.NonVirtualReceivedSetupSpecification,
                Severity = DiagnosticSeverity.Warning,
                Message =
                    "Member Bar can not be intercepted. Only interface members and overrideable, overriding, and must override members can be intercepted.",
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
            var x = SubstituteExtensions.Received<Foo>(substitute)[1];
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
            var x = SubstituteExtensions.Received<Foo>(substitute)[1];
        }
    }
}";

            var expectedDiagnostic = new DiagnosticResult
            {
                Id = DiagnosticIdentifiers.NonVirtualReceivedSetupSpecification,
                Severity = DiagnosticSeverity.Warning,
                Message =
                    "Member this[] can not be intercepted. Only interface members and overrideable, overriding, and must override members can be intercepted.",
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
            substitute.Received<Foo>(1m).Bar();
        }
    }
}";
            await VerifyDiagnostic(source);
        }
    }
}
