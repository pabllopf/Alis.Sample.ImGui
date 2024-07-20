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
using Alis.Core.Aspect.Math.Definition;
using Alis.Core.Ecs;
using Alis.Core.Ecs.Component.Render;
using Alis.Core.Ecs.Entity;
using Alis.Extension.Graphic.ImGui;
using Alis.Sample.ImGui.Demos;

namespace Alis.Sample.ImGui.Core
{
    /// <summary>
    ///     The space work class
    /// </summary>
    public class SpaceWork
    {
        /// <summary>
        ///     The icon demo
        /// </summary>
        public readonly IconDemo iconDemo = new IconDemo();

        /// <summary>
        ///     The im gui demo
        /// </summary>
        public readonly ImGuiDemo imGuiDemo = new ImGuiDemo();

        /// <summary>
        ///     The im guizmo demo
        /// </summary>
        public readonly ImGuizmoDemo imGuizmoDemo = new ImGuizmoDemo();

        /// <summary>
        ///     The im node demo
        /// </summary>
        public readonly ImNodeDemo imNodeDemo = new ImNodeDemo();

        /// <summary>
        ///     The im plot demo
        /// </summary>
        public readonly ImPlotDemo imPlotDemo = new ImPlotDemo();

        /// <summary>
        ///     The context
        /// </summary>
        public IntPtr ContextGui;

        /// <summary>
        ///     The io
        /// </summary>
        public ImGuiIoPtr Io;

        /// <summary>
        /// The renderer game
        /// </summary>
        public IntPtr rendererGame;

        /// <summary>
        ///     The style
        /// </summary>
        public ImGuiStyle Style;

        /// <summary>
        ///     Gets or sets the value of the viewport
        /// </summary>
        public ImGuiViewportPtr Viewport;

        /// <summary>
        ///     The window
        /// </summary>
        public IntPtr Window;

        /// <summary>
        /// The window game
        /// </summary>
        public IntPtr windowGame;

        /// <summary>
        ///     Initializes a new instance of the <see cref="SpaceWork" /> class
        /// </summary>
        public SpaceWork()
        {
            VideoGame = VideoGame
                .Builder()
                .Settings(setting => setting
                    .General(general => general
                        .Name("Rogue Legacy")
                        .Author("Pablo Perdomo Falcón")
                        .Description("Sample of a rogue legacy game")
                        .Debug(true)
                        .License("GNU General Public License v3.0")
                        .Icon("app.bmp")
                        .Build())
                    .Audio(audio => audio
                        .Build())
                    .Graphic(graphic => graphic
                        .Window(window => window
                            .Resolution(1024, 640)
                            .Background(Color.Black)
                            .Build())
                        .Build())
                    .Physic(physic => physic
                        .Gravity(0.0f, -9.8f)
                        .Debug(true)
                        .DebugColor(Color.Green)
                        .Build())
                    .Build())
                .World(sceneManager => sceneManager
                    .Add<Scene>(gameScene => gameScene
                        .Add<GameObject>(gameObject => gameObject
                            .Name("Player")
                            .WithTag("Player")
                            .Transform(transform => transform
                                .Position(0, 0)
                                .Scale(2, 2)
                                .Rotation(0)
                                .Build())
                            .AddComponent<Sprite>(sprite => sprite.Builder()
                                .SetTexture("tile000.bmp")
                                .Build())
                            .AddComponent<Animator>(animator => animator.Builder()
                                .AddAnimation(animation => animation
                                    .Name("Idle")
                                    .Order(0)
                                    .Speed(0.2f)
                                    .AddFrame(frame => frame
                                        .FilePath("tile000.bmp")
                                        .Build())
                                    .AddFrame(frame => frame
                                        .FilePath("tile001.bmp")
                                        .Build())
                                    .AddFrame(frame => frame
                                        .FilePath("tile002.bmp")
                                        .Build())
                                    .AddFrame(frame => frame
                                        .FilePath("tile003.bmp")
                                        .Build())
                                    .Build())
                                .Build())
                            .AddComponent<Camera>(camera => camera.Builder()
                                .Resolution(1024, 640)
                                .BackgroundColor(Color.DarkGreen)
                                .Build())
                            .Build())

                        // Decoration tree-001
                        .Add<GameObject>(gameObject => gameObject
                            .Name("tree-001")
                            .Transform(transform => transform
                                .Position(100, 100)
                                .Scale(2, 2)
                                .Rotation(0)
                                .Build())
                            .AddComponent<Sprite>(sprite => sprite.Builder()
                                .SetTexture("tree-001.bmp")
                                .Build())
                            .Build())

                        // Decoration tree-001
                        .Add<GameObject>(gameObject => gameObject
                            .Name("tree-002")
                            .Transform(transform => transform
                                .Position(400, 400)
                                .Scale(2, 2)
                                .Rotation(0)
                                .Build())
                            .AddComponent<Sprite>(sprite => sprite.Builder()
                                .SetTexture("tree-001.bmp")
                                .Build())
                            .Build())
                        .Add<GameObject>(gameObject => gameObject
                            .Name("tree-001")
                            .Transform(transform => transform
                                .Position(-100, -100)
                                .Scale(2, 2)
                                .Rotation(0)
                                .Build())
                            .AddComponent<Sprite>(sprite => sprite.Builder()
                                .SetTexture("tree-001.bmp")
                                .Build())
                            .Build())
                        .Add<GameObject>(gameObject => gameObject
                            .Name("tree-001")
                            .Transform(transform => transform
                                .Position(-200, -200)
                                .Scale(2, 2)
                                .Rotation(0)
                                .Build())
                            .AddComponent<Sprite>(sprite => sprite.Builder()
                                .SetTexture("tree-001.bmp")
                                .Build())
                            .Build())
                        .Build())
                    .Build())
                .BuildPreview();
        }
        
        /// <summary>
        /// Gets or sets the value of the fps
        /// </summary>
        public int Fps { get; set; } = 60;

        /// <summary>
        /// Gets the value of the video game
        /// </summary>
        public VideoGame VideoGame { get; }

        /// <summary>
        /// Initializes this instance
        /// </summary>
        public void Initialize()
        {
            VideoGame.InitPreview();

            imGuiDemo.Initialize();
            imPlotDemo.Initialize();
            imGuizmoDemo.Initialize();
            imNodeDemo.Initialize();
            iconDemo.Initialize();
        }

        /// <summary>
        /// Starts this instance
        /// </summary>
        public void Start()
        {
            imGuiDemo.Start();
            imPlotDemo.Start();
            imGuizmoDemo.Start();
            imNodeDemo.Start();
            iconDemo.Start();
            
        }

        /// <summary>
        ///     Updates this instance
        /// </summary>
        public void Update()
        {
            imGuiDemo.Run();
            imPlotDemo.Run();
            imGuizmoDemo.Run();
            imNodeDemo.Run();
            iconDemo.Run();
        }
    }
}