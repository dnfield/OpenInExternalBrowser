//------------------------------------------------------------------------------
// <copyright file="UriHandlerPackage.cs" company="Company">
//     Copyright (c) Company.  All rights reserved.
// </copyright>
//------------------------------------------------------------------------------



namespace Tvl.VisualStudio.OpenInExternalBrowser
{
    using System;
    using System.ComponentModel.Design;
    using System.Diagnostics;
    using System.Diagnostics.CodeAnalysis;
    using System.Globalization;
    using System.Runtime.InteropServices;
    using Microsoft.VisualStudio;
    using Microsoft.VisualStudio.OLE.Interop;
    using Microsoft.VisualStudio.Shell;
    using Microsoft.VisualStudio.Shell.Interop;
    using Microsoft.Win32;

    /// <summary>
    /// This is the class that implements the package exposed by this assembly.
    /// </summary>
    /// <remarks>
    /// <para>
    /// The minimum requirement for a class to be considered a valid package for Visual Studio
    /// is to implement the IVsPackage interface and register itself with the shell.
    /// This package uses the helper classes defined inside the Managed Package Framework (MPF)
    /// to do it: it derives from the Package class that provides the implementation of the
    /// IVsPackage interface and uses the registration attributes defined in the framework to
    /// register itself and its components with the shell. These attributes tell the pkgdef creation
    /// utility what data to put into .pkgdef file.
    /// </para>
    /// <para>
    /// To get loaded into VS, the package must be referred by &lt;Asset Type="Microsoft.VisualStudio.VsPackage" ...&gt; in .vsixmanifest file.
    /// </para>
    /// </remarks>
    [PackageRegistration(UseManagedResourcesOnly = true)]
    [Guid(UriHandlerPackage.PackageGuidString)]
    [ProvideOptionPage(typeof(UrlCommandFilterOptionsDialog), UrlCommandFilterOptionsDialog.Category, UrlCommandFilterOptionsDialog.SubCategory, 100, 101, true)]
    [ProvideProfile(typeof(UrlCommandFilterOptionsDialog), UrlCommandFilterOptionsDialog.Category, UrlCommandFilterOptionsDialog.SubCategory, 100, 101, true)]
    [InstalledProductRegistration("OpenInExternalBrowser", "Uri Command Handler", "1.2")]
    [SuppressMessage("StyleCop.CSharp.DocumentationRules", "SA1650:ElementDocumentationMustBeSpelledCorrectly", Justification = "pkgdef, VS and vsixmanifest are valid VS terms")]
    public sealed class UriHandlerPackage : Package
    {
        /// <summary>
        /// UriHandlerPackage GUID string.
        /// </summary>
        public const string PackageGuidString = "bab480c6-5c64-46d2-bc76-3242a93acedc";

        /// <summary>
        /// Initializes a new instance of the <see cref="UriHandlerPackage"/> class.
        /// </summary>
        public UriHandlerPackage()
        {
            // Inside this method you can place any initialization code that does not require
            // any Visual Studio service because at this point the package object is created but
            // not sited yet inside Visual Studio environment. The place to do all the other
            // initialization is the Initialize method.
        }

        #region Package Members

        /// <summary>
        /// Initialization of the package; this method is called right after the package is sited, so this is the place
        /// where you can put all the initialization code that rely on services provided by VisualStudio.
        /// </summary>
        protected override void Initialize()
        {
            base.Initialize();
        }

        #endregion
    }
}
