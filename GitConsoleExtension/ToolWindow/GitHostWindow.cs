//------------------------------------------------------------------------------
// <copyright file="GitHostWindow.cs" company="Microsoft">
//     Copyright (c) Microsoft.  All rights reserved.
// </copyright>
//------------------------------------------------------------------------------

using System.Runtime.InteropServices;
using Microsoft.VisualStudio.Shell;

namespace GitConsoleExtension
{
    /// <summary>
    /// This class implements the tool window exposed by this package and hosts a user control.
    /// </summary>
    /// <remarks>
    /// In Visual Studio tool windows are composed of a frame (implemented by the shell) and a pane,
    /// usually implemented by the package implementer.
    /// <para>
    /// This class derives from the ToolWindowPane class provided from the MPF in order to use its
    /// implementation of the IVsUIElementPane interface.
    /// </para>
    /// </remarks>
    [Guid("bc7b9662-5078-4385-9d4d-002d7e4fd1ea")]
    public class GitHostWindow : ToolWindowPane
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="GitHostWindow"/> class.
        /// </summary>
        public GitHostWindow() : base(null)
        {
            this.Caption = "Git Integrated Window";

            // This is the user control hosted by the tool window; Note that, even if this class implements IDisposable,
            // we are not calling Dispose on this object. This is because ToolWindowPane calls Dispose on
            // the object returned by the Content property.
            this.Content = new GitConsoleExtension.GitHostWindowControl();
        }
    }
}
