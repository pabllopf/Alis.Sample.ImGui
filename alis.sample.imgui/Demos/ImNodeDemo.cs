// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File:ImNodeDemo.cs
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

using System.Diagnostics;
using Alis.Extension.Graphic.ImGui.Extras.Node;

namespace Alis.Sample.ImGui.Demos
{
    /// <summary>
    ///     The im node demo class
    /// </summary>
    /// <seealso cref="IDemo" />
    public class ImNodeDemo : IDemo
    {
        /// <summary>
        /// Initializes this instance
        /// </summary>
        public void Initialize()
        {
        }

        /// <summary>
        /// Starts this instance
        /// </summary>
        public void Start()
        {
        }

        /// <summary>
        ///     Runs this instance
        /// </summary>
        public void Run()
        {
            DefaultDemo();
        }

        /// <summary>
        ///     Defaults the demo
        /// </summary>
        [Conditional("DEBUG")]
        private void DefaultDemo()
        {
            Extension.Graphic.ImGui.Native.ImGui.Begin("simple node editor");

            ImNodes.BeginNodeEditor();
            ImNodes.BeginNode(1);

            ImNodes.BeginNodeTitleBar();
            Extension.Graphic.ImGui.Native.ImGui.TextUnformatted("simple node :)");
            ImNodes.EndNodeTitleBar();

            ImNodes.BeginInputAttribute(2);
            Extension.Graphic.ImGui.Native.ImGui.Text("input");
            ImNodes.EndInputAttribute();

            ImNodes.BeginOutputAttribute(3);
            Extension.Graphic.ImGui.Native.ImGui.Indent(40);
            Extension.Graphic.ImGui.Native.ImGui.Text("output");
            ImNodes.EndOutputAttribute();

            ImNodes.EndNode();
            ImNodes.EndNodeEditor();

            Extension.Graphic.ImGui.Native.ImGui.End();
        }
    }
}