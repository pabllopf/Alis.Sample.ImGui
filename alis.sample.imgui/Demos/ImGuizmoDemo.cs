using Alis.Core.Aspect.Math.Vector;
using Alis.Extension.Graphic.ImGui;
using Alis.Extension.Graphic.ImGui.Extras.GuizMo;

namespace Alis.Sample.ImGui.Demos
{
    public class ImGuizmoDemo : IDemo
    {
        private float[] matrixTranslation = new float[3];
        float[] matrixRotation = new float[3];
        float[] matrixScale = new float[3];

        Vector3 translation = new Vector3();
        Vector3 rotation = new Vector3();
        Vector3 scale = new Vector3();

        private bool isOpen = false;

        private float[] matrix = new float[16]
        {
            1.0f, 0.0f, 0.0f, 0.0f,
            0.0f, 1.0f, 0.0f, 0.0f,
            0.0f, 0.0f, 1.0f, 0.0f,
            0.0f, 0.0f, 2.0f, 1.0f
        };

        private float[] cameraView = new float[16]
        {
            1.0f, 0.0f, 0.0f, 0.0f,
            0.0f, 1.0f, 0.0f, 0.0f,
            0.0f, 0.0f, 1.0f, 0.0f,
            0.0f, 0.0f, 0.0f, 1.0f
        };

        private float[] cameraProjection = new float[16]
        {
            2.0f / 800.0f, 0.0f, 0.0f, 0.0f,
            0.0f, 2.0f / 600.0f, 0.0f, 0.0f,
            0.0f, 0.0f, -1.0f, 0.0f,
            -1.0f, -1.0f, 0.0f, 1.0f
        };

        private float[] identityMatrix = new float[16]
        {
            1.0f, 0.0f, 0.0f, 0.0f,
            0.0f, 1.0f, 0.0f, 0.0f,
            0.0f, 0.0f, 1.0f, 0.0f,
            0.0f, 0.0f, 0.0f, 1.0f
        };

        public void Run()
        {
            Extension.Graphic.ImGui.Native.ImGui.PushStyleColor(ImGuiCol.WindowBg, new Vector4(0.35f, 0.3f, 0.3f, 1.0f));
            
            
            if (Extension.Graphic.ImGui.Native.ImGui.Begin("Gizmo", ref isOpen))
            {
                ImGuizMo.Enable(true);
                ImGuizMo.SetDrawList();
                
                Extension.Graphic.ImGui.Native.ImGui.Text("ImGuizmo is a small library that allows you to manipulate 3D objects in the scene.");
                Extension.Graphic.ImGui.Native.ImGui.Text("You can use it to move, rotate and scale objects in the scene.");

                ImGuizMo.DecomposeMatrixToComponents(ref matrix, ref matrixTranslation, ref matrixRotation, ref matrixScale);

                translation.X = matrixTranslation[0];
                translation.Y = matrixTranslation[1];
                translation.Z = matrixTranslation[2];

                rotation.X = matrixRotation[0];
                rotation.Y = matrixRotation[1];
                rotation.Z = matrixRotation[2];

                scale.X = matrixScale[0];
                scale.Y = matrixScale[1];
                scale.Z = matrixScale[2];

                Extension.Graphic.ImGui.Native.ImGui.SliderFloat3("Translation", ref translation, -10.0f, 10.0f);
                Extension.Graphic.ImGui.Native.ImGui.SliderFloat3("Rotation", ref rotation, -180.0f, 180.0f);
                Extension.Graphic.ImGui.Native.ImGui.SliderFloat3("Scale", ref scale, 0.1f, 10.0f);

                matrixTranslation[0] = translation.X;
                matrixTranslation[1] = translation.Y;
                matrixTranslation[2] = translation.Z;

                matrixRotation[0] = rotation.X;
                matrixRotation[1] = rotation.Y;
                matrixRotation[2] = rotation.Z;

                matrixScale[0] = scale.X;
                matrixScale[1] = scale.Y;
                matrixScale[2] = scale.Z;
                
                ImGuizMo.RecomposeMatrixFromComponents(ref matrixTranslation, ref matrixRotation, ref matrixScale, ref matrix);

                Extension.Graphic.ImGui.Native.ImGui.Text($"Translation: {translation}");
                Extension.Graphic.ImGui.Native.ImGui.Text($"Rotation: {rotation}");
                Extension.Graphic.ImGui.Native.ImGui.Text($"Scale: {scale}");
                
                ImGuizMo.SetOrthographic(false);
                ImGuizMo.SetRect(0, 0, Extension.Graphic.ImGui.Native.ImGui.GetIo().DisplaySize.X, Extension.Graphic.ImGui.Native.ImGui.GetIo().DisplaySize.Y);
                
                ImGuizMo.DrawGrid(ref cameraView, ref cameraProjection, ref identityMatrix, 10.0f);
                ImGuizMo.Manipulate(cameraView, cameraProjection, Operation.Translate | Operation.Rotate | Operation.Scale, Mode.Local, matrix);
                
                ImGuizMo.ViewManipulate(ref cameraView, 2.5f, new Vector2(Extension.Graphic.ImGui.Native.ImGui.GetWindowPos().X, Extension.Graphic.ImGui.Native.ImGui.GetWindowPos().Y), new Vector2(Extension.Graphic.ImGui.Native.ImGui.GetWindowWidth(), Extension.Graphic.ImGui.Native.ImGui.GetWindowHeight()), 0x10101010);
                
                
                
            }
            
           
            Extension.Graphic.ImGui.Native.ImGui.End();
            Extension.Graphic.ImGui.Native.ImGui.PopStyleColor();
           
        }
    }
}