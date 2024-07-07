// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File:SpaceWork.cs
// 
//  Author:Pablo Perdomo Falcón
//  Web:https://www.pabllopf.dev/
// 
//  Copyright (c) 2021 GNU General Public License v3.0
// 
//  This program is free software:you can redistribute it and/or modify
//  it under the terms of the GNU General Public License as published by
//  the Free Software Foundation, either version 3 of the License, or
//  (at your option) any later version.
// 
//  This program is distributed in the hope that it will be useful,
//  but WITHOUT ANY WARRANTY without even the implied warranty of
//  MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.See the
//  GNU General Public License for more details.
// 
//  You should have received a copy of the GNU General Public License
//  along with this program.If not, see <http://www.gnu.org/licenses/>.
// 
//  --------------------------------------------------------------------------

using System;
using Alis.Extension.Graphic.ImGui;
using Alis.Sample.ImGui.Demos;

namespace Alis.Sample.ImGui
{
    /// <summary>
    /// The space work class
    /// </summary>
    public class SpaceWork
    {
        /// <summary>
        ///     The window
        /// </summary>
        public IntPtr Window;

        /// <summary>
        /// Gets or sets the value of the viewport
        /// </summary>
        public ImGuiViewportPtr Viewport;

        /// <summary>
        ///     The io
        /// </summary>
        public ImGuiIoPtr Io;

        /// <summary>
        ///     The style
        /// </summary>
        public ImGuiStyle Style;
        
        /// <summary>
        ///     The context
        /// </summary>
        public IntPtr ContextGui;

        private readonly ImGuiDemo imGuiDemo = new ImGuiDemo();

        private readonly ImPlotDemo imPlotDemo = new ImPlotDemo();

        private readonly ImGuizmoDemo imGuizmoDemo = new ImGuizmoDemo();

        private readonly ImNodeDemo imNodeDemo = new ImNodeDemo();

        /// <summary>
        /// Initializes a new instance of the <see cref="SpaceWork"/> class
        /// </summary>
        public SpaceWork()
        {
        }

        /// <summary>
        /// Updates this instance
        /// </summary>
        public void Update()
        {
            imGuiDemo.Run();
            imPlotDemo.Run();
            imGuizmoDemo.Run();
            imNodeDemo.Run();
        }
    }
}