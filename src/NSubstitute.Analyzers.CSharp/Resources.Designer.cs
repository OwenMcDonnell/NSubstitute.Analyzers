﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.42000
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace NSubstitute.Analyzers.CSharp {
    using System;
    using System.Reflection;
    
    
    /// <summary>
    ///   A strongly-typed resource class, for looking up localized strings, etc.
    /// </summary>
    // This class was auto-generated by the StronglyTypedResourceBuilder
    // class via a tool like ResGen or Visual Studio.
    // To add or remove a member, edit your .ResX file then rerun ResGen
    // with the /str option, or rebuild your VS project.
    [global::System.CodeDom.Compiler.GeneratedCodeAttribute("System.Resources.Tools.StronglyTypedResourceBuilder", "4.0.0.0")]
    [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
    [global::System.Runtime.CompilerServices.CompilerGeneratedAttribute()]
    internal class Resources {
        
        private static global::System.Resources.ResourceManager resourceMan;
        
        private static global::System.Globalization.CultureInfo resourceCulture;
        
        [global::System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1811:AvoidUncalledPrivateCode")]
        internal Resources() {
        }
        
        /// <summary>
        ///   Returns the cached ResourceManager instance used by this class.
        /// </summary>
        [global::System.ComponentModel.EditorBrowsableAttribute(global::System.ComponentModel.EditorBrowsableState.Advanced)]
        internal static global::System.Resources.ResourceManager ResourceManager {
            get {
                if (object.ReferenceEquals(resourceMan, null)) {
                    global::System.Resources.ResourceManager temp = new global::System.Resources.ResourceManager("NSubstitute.Analyzers.CSharp.Resources", typeof(Resources).GetTypeInfo().Assembly);
                    resourceMan = temp;
                }
                return resourceMan;
            }
        }
        
        /// <summary>
        ///   Overrides the current thread's CurrentUICulture property for all
        ///   resource lookups using this strongly typed resource class.
        /// </summary>
        [global::System.ComponentModel.EditorBrowsableAttribute(global::System.ComponentModel.EditorBrowsableState.Advanced)]
        internal static global::System.Globalization.CultureInfo Culture {
            get {
                return resourceCulture;
            }
            set {
                resourceCulture = value;
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Non-virtual members can not be intercepted..
        /// </summary>
        internal static string NonVirtualSetupSpecificationDescription {
            get {
                return ResourceManager.GetString("NonVirtualSetupSpecificationDescription", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Member {0} can not be intercepted. Only interface members and virtual, overriding, and abstract members can be intercepted..
        /// </summary>
        internal static string NonVirtualSetupSpecificationMessageFormat {
            get {
                return ResourceManager.GetString("NonVirtualSetupSpecificationMessageFormat", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Non-virtual setup specification..
        /// </summary>
        internal static string NonVirtualSetupSpecificationTitle {
            get {
                return ResourceManager.GetString("NonVirtualSetupSpecificationTitle", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Can not provide constructor arguments when substituting for a delegate..
        /// </summary>
        internal static string SubstituteConstructorArgumentsForDelegateeDescription {
            get {
                return ResourceManager.GetString("SubstituteConstructorArgumentsForDelegateeDescription", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Can not provide constructor arguments when substituting for a delegate..
        /// </summary>
        internal static string SubstituteConstructorArgumentsForDelegateMemberTitle {
            get {
                return ResourceManager.GetString("SubstituteConstructorArgumentsForDelegateMemberTitle", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Can not provide constructor arguments when substituting for a delegate. Use Substitute.For&lt;{0}&gt;() instead..
        /// </summary>
        internal static string SubstituteConstructorArgumentsForDelegateMessageFormat {
            get {
                return ResourceManager.GetString("SubstituteConstructorArgumentsForDelegateMessageFormat", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Can not provide constructor arguments when substituting for an interface..
        /// </summary>
        internal static string SubstituteConstructorArgumentsForInterfaceDescription {
            get {
                return ResourceManager.GetString("SubstituteConstructorArgumentsForInterfaceDescription", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Can not provide constructor arguments when substituting for an interface..
        /// </summary>
        internal static string SubstituteConstructorArgumentsForInterfaceMemberTitle {
            get {
                return ResourceManager.GetString("SubstituteConstructorArgumentsForInterfaceMemberTitle", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Can not provide constructor arguments when substituting for an interface. Use Substitute.For&lt;{0}&gt;() instead..
        /// </summary>
        internal static string SubstituteConstructorArgumentsForInterfaceMessageFormat {
            get {
                return ResourceManager.GetString("SubstituteConstructorArgumentsForInterfaceMessageFormat", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Unable to find matching constructor..
        /// </summary>
        internal static string SubstituteConstructorMismatchDescription {
            get {
                return ResourceManager.GetString("SubstituteConstructorMismatchDescription", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Unable to find matching constructor..
        /// </summary>
        internal static string SubstituteConstructorMismatchMemberTitle {
            get {
                return ResourceManager.GetString("SubstituteConstructorMismatchMemberTitle", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Arguments passed to {0} do not match the constructor arguments for {1}. Check the {1} constructors and make sure you have passed the required arguments and argument types..
        /// </summary>
        internal static string SubstituteConstructorMismatchMessageFormat {
            get {
                return ResourceManager.GetString("SubstituteConstructorMismatchMessageFormat", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Constructor parameters count mismatch..
        /// </summary>
        internal static string SubstituteForConstructorParametersMismatchDescription {
            get {
                return ResourceManager.GetString("SubstituteForConstructorParametersMismatchDescription", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Arguments count passed to {0} do not match the constructor arguments count for {1}. Check the {1} constructors and make sure you have passed the required arguments count..
        /// </summary>
        internal static string SubstituteForConstructorParametersMismatchMessageFormat {
            get {
                return ResourceManager.GetString("SubstituteForConstructorParametersMismatchMessageFormat", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Constructor parameters count mismatch..
        /// </summary>
        internal static string SubstituteForConstructorParametersMismatchTitle {
            get {
                return ResourceManager.GetString("SubstituteForConstructorParametersMismatchTitle", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Substitute for internal member..
        /// </summary>
        internal static string SubstituteForInternalMemberDescription {
            get {
                return ResourceManager.GetString("SubstituteForInternalMemberDescription", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Can not substitute for internal type. To substitute for internal type expose your type to DynamicProxyGenAssembly2 via [assembly: InternalsVisibleTo(&quot;DynamicProxyGenAssembly2&quot;)].
        /// </summary>
        internal static string SubstituteForInternalMemberMessageFormat {
            get {
                return ResourceManager.GetString("SubstituteForInternalMemberMessageFormat", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Can not create..
        /// </summary>
        internal static string SubstituteForInternalMemberTitle {
            get {
                return ResourceManager.GetString("SubstituteForInternalMemberTitle", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Can only substitute for parts of classes, not interfaces or delegates..
        /// </summary>
        internal static string SubstituteForPartsOfUsedForInterfaceDescription {
            get {
                return ResourceManager.GetString("SubstituteForPartsOfUsedForInterfaceDescription", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Can only substitute for parts of classes, not interfaces or delegates.Use Substitute.For&lt;{0}&gt; instead of Substitute.ForPartsOf&lt;{0}&gt; here..
        /// </summary>
        internal static string SubstituteForPartsOfUsedForInterfaceMessageFormat {
            get {
                return ResourceManager.GetString("SubstituteForPartsOfUsedForInterfaceMessageFormat", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Substitute.ForPartsOf used for interface..
        /// </summary>
        internal static string SubstituteForPartsOfUsedForInterfaceTitle {
            get {
                return ResourceManager.GetString("SubstituteForPartsOfUsedForInterfaceTitle", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Could not find accessible constructor..
        /// </summary>
        internal static string SubstituteForWithoutAccessibleConstructorDescription {
            get {
                return ResourceManager.GetString("SubstituteForWithoutAccessibleConstructorDescription", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Could not find accessible constructor. Make sure that type {0} exposes public or protected constructors..
        /// </summary>
        internal static string SubstituteForWithoutAccessibleConstructorMessageFormat {
            get {
                return ResourceManager.GetString("SubstituteForWithoutAccessibleConstructorMessageFormat", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Could not find accessible constructor..
        /// </summary>
        internal static string SubstituteForWithoutAccessibleConstructorTitle {
            get {
                return ResourceManager.GetString("SubstituteForWithoutAccessibleConstructorTitle", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Can not substitute for multiple classes..
        /// </summary>
        internal static string SubstituteMultipleClassesDescription {
            get {
                return ResourceManager.GetString("SubstituteMultipleClassesDescription", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Can not substitute for multiple classes..
        /// </summary>
        internal static string SubstituteMultipleClassesMemberTitle {
            get {
                return ResourceManager.GetString("SubstituteMultipleClassesMemberTitle", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Can not substitute for multiple classes. To substitute for multiple types only one type can be a concrete class; other types can only be interfaces..
        /// </summary>
        internal static string SubstituteMultipleClassesMessageFormat {
            get {
                return ResourceManager.GetString("SubstituteMultipleClassesMessageFormat", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Unused received check..
        /// </summary>
        internal static string UnusedReceivedDescription {
            get {
                return ResourceManager.GetString("UnusedReceivedDescription", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Unused received check..
        /// </summary>
        internal static string UnusedReceivedForOrdinaryMethodDescription {
            get {
                return ResourceManager.GetString("UnusedReceivedForOrdinaryMethodDescription", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Unused received check. To fix, make sure there is a call after &quot;{0}&quot;. Correct: &quot;SubstituteExtensions.{0}(sub).SomeCall();&quot;. Incorrect: &quot;SubstituteExtensions.{0}(sub);&quot;.
        /// </summary>
        internal static string UnusedReceivedForOrdinaryMethodMessageFormat {
            get {
                return ResourceManager.GetString("UnusedReceivedForOrdinaryMethodMessageFormat", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Received check..
        /// </summary>
        internal static string UnusedReceivedForOrdinaryMethodTitle {
            get {
                return ResourceManager.GetString("UnusedReceivedForOrdinaryMethodTitle", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Unused received check. To fix, make sure there is a call after &quot;{0}&quot;. Correct: &quot;sub.{0}().SomeCall();&quot;. Incorrect: &quot;sub.{0}();&quot;.
        /// </summary>
        internal static string UnusedReceivedMessageFormat {
            get {
                return ResourceManager.GetString("UnusedReceivedMessageFormat", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Received check..
        /// </summary>
        internal static string UnusedReceivedTitle {
            get {
                return ResourceManager.GetString("UnusedReceivedTitle", resourceCulture);
            }
        }
    }
}
