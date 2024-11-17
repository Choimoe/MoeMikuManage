using OpenTK;
using OpenTK.Graphics.OpenGL;
using System.Drawing;

namespace MoeMikuManage
{
    public partial class ModelViewer
    {
        private void glControl1_Load(object sender, System.EventArgs e)
        {
            GL.ClearColor(0.0f, 0.0f, 0.0f, 0.0f);
            GL.Enable(EnableCap.DepthTest);//sonradan yazdık
        }
        private void glControl1_AutoSizeChanged(object sender, System.EventArgs e)
        {
            GL.Clear(ClearBufferMask.ColorBufferBit);
            GL.Clear(ClearBufferMask.DepthBufferBit);

            Matrix4 perspective = Matrix4.CreatePerspectiveFieldOfView(1.04f, glControl1.AspectRatio, 0.1f, 1000);
            Matrix4 lookat = Matrix4.LookAt(cameraPos.X, cameraPos.Y, cameraPos.Z, cameraDir.X, cameraDir.Y, cameraDir.Z, 0, 1, 0);
            GL.MatrixMode(MatrixMode.Projection);
            GL.LoadIdentity();
            GL.LoadMatrix(ref perspective);
            GL.MatrixMode(MatrixMode.Modelview);
            GL.LoadIdentity();
            GL.LoadMatrix(ref lookat);
            GL.Viewport(0, 0, glControl1.Width, glControl1.Height);

        }
        private void DrawSphere(Vector3 position, float radius)
        {
            // 绘制一个小球在给定的位置
            GL.PushMatrix();
            GL.Translate(position); // 移动到目标位置
            GL.Color4(1.0f, 0.0f, 0.0f, 0.3f); // 设置颜色为红色并设定透明度 (alpha = 0.5)
            GL.Begin(BeginMode.Triangles);

            int slices = 16; // 横向分割数
            int stacks = 16; // 纵向分割数
            for (int i = 0; i < slices; i++)
            {
                double phi1 = System.Math.PI * (i) / slices;
                double phi2 = System.Math.PI * (i + 1) / slices;
                for (int j = 0; j < stacks; j++)
                {
                    double theta1 = 2 * System.Math.PI * (j) / stacks;
                    double theta2 = 2 * System.Math.PI * (j + 1) / stacks;

                    Vector3 p1 = new Vector3((float)(radius * System.Math.Sin(phi1) * System.Math.Cos(theta1)),
                                              (float)(radius * System.Math.Cos(phi1)),
                                              (float)(radius * System.Math.Sin(phi1) * System.Math.Sin(theta1)));
                    Vector3 p2 = new Vector3((float)(radius * System.Math.Sin(phi1) * System.Math.Cos(theta2)),
                                              (float)(radius * System.Math.Cos(phi1)),
                                              (float)(radius * System.Math.Sin(phi1) * System.Math.Sin(theta2)));
                    Vector3 p3 = new Vector3((float)(radius * System.Math.Sin(phi2) * System.Math.Cos(theta2)),
                                              (float)(radius * System.Math.Cos(phi2)),
                                              (float)(radius * System.Math.Sin(phi2) * System.Math.Sin(theta2)));
                    Vector3 p4 = new Vector3((float)(radius * System.Math.Sin(phi2) * System.Math.Cos(theta1)),
                                              (float)(radius * System.Math.Cos(phi2)),
                                              (float)(radius * System.Math.Sin(phi2) * System.Math.Sin(theta1)));

                    GL.Vertex3(p1);
                    GL.Vertex3(p2);
                    GL.Vertex3(p3);

                    GL.Vertex3(p1);
                    GL.Vertex3(p3);
                    GL.Vertex3(p4);
                }
            }
            GL.End();
            GL.PopMatrix();
        }
        private void glControl1_Paint(object sender, System.Windows.Forms.PaintEventArgs e)
        {
            InitializeAndClearBuffers();
            SetupProjectionAndViewMatrices();
            DrawCoordinateAxes();
            BindAndUseProgram();
            SetUniformVariables();
            DrawModel();

            // 绘制小球在 cameraTarget 上
            DrawSphere(cameraTarget, 0.1f);  // 假设小球半径是 0.1f

            CleanupResources();
            SwapBuffers();
        }

        private void InitializeAndClearBuffers()
        {
            GL.Clear(ClearBufferMask.ColorBufferBit | ClearBufferMask.DepthBufferBit);
        }
        private void SetupProjectionAndViewMatrices()
        {
            Matrix4 perspective = Matrix4.CreatePerspectiveFieldOfView(1.04f, glControl1.AspectRatio, 0.1f, 1000);
            Matrix4 lookat = Matrix4.LookAt(cameraPos, cameraTarget, Vector3.UnitY);


            GL.MatrixMode(MatrixMode.Projection);
            GL.LoadIdentity();
            GL.LoadMatrix(ref perspective);

            GL.MatrixMode(MatrixMode.Modelview);
            GL.LoadIdentity();
            GL.LoadMatrix(ref lookat);
        }
        private void DrawCoordinateAxes()
        {
            GL.Begin(BeginMode.Lines);

            GL.Color3(Color.Blue);
            GL.Vertex3(0, 0.0, -1 * coordinateLinesLong);
            GL.Vertex3(0.0, 0.0, coordinateLinesLong);

            GL.Color3(Color.Green);
            GL.Vertex3(0.0, -1 * coordinateLinesLong, 0.0);
            GL.Vertex3(0.0, coordinateLinesLong, 0.0);

            GL.Color3(Color.Red);
            GL.Vertex3(-1 * coordinateLinesLong, 0.0, 0);
            GL.Vertex3(coordinateLinesLong, 0.0, 0);

            GL.End();
        }
        private void BindAndUseProgram()
        {
            GL.BindBuffer(BufferTarget.ArrayBuffer, VertexArrayObject);
            GL.BindVertexArray(VertexArrayObject);
            GL.UseProgram(ShaderObject);
        }
        private void SetUniformVariables()
        {
            Matrix4 perspective = Matrix4.CreatePerspectiveFieldOfView(1.04f, glControl1.AspectRatio, 0.1f, 1000);
            Matrix4 lookat = Matrix4.LookAt(cameraPos, cameraTarget, Vector3.UnitY);
            int modelAddress = GL.GetUniformLocation(ShaderObject, "model");
            int viewAddress = GL.GetUniformLocation(ShaderObject, "view");
            int projectionAddress = GL.GetUniformLocation(ShaderObject, "projection");

            Matrix4 rotX = Matrix4.CreateRotationX(x_angle_3d_model);
            Matrix4 rotY = Matrix4.CreateRotationY(y_angle_3d_model);
            Matrix4 rotZ = Matrix4.CreateRotationZ(z_angle_3d_model);

            Matrix4 model = Matrix4.Identity * rotZ * rotY * rotX;

            GL.UniformMatrix4(modelAddress, false, ref model);
            GL.UniformMatrix4(viewAddress, false, ref lookat);
            GL.UniformMatrix4(projectionAddress, false, ref perspective);

            GL.ActiveTexture(TextureUnit.Texture0);
            GL.BindTexture(TextureTarget.Texture2D, TextureObject);

            int texLocation = GL.GetUniformLocation(ShaderObject, "texture_diffuse1");
            GL.Uniform1(texLocation, 0);

            int location = GL.GetUniformLocation(ShaderObject, "material.ambient");
            GL.Uniform3(location, modelMat.ambient);
            location = GL.GetUniformLocation(ShaderObject, "material.diffuse");
            GL.Uniform3(location, modelMat.diffuse);
            location = GL.GetUniformLocation(ShaderObject, "material.specular");
            GL.Uniform3(location, modelMat.specular);
            location = GL.GetUniformLocation(ShaderObject, "material.shininess");
            GL.Uniform1(location, modelMat.shininess);

            location = GL.GetUniformLocation(ShaderObject, "light.ambient");
            GL.Uniform3(location, light.ambient);
            location = GL.GetUniformLocation(ShaderObject, "light.diffuse");
            GL.Uniform3(location, light.diffuse);
            location = GL.GetUniformLocation(ShaderObject, "light.specular");
            GL.Uniform3(location, light.specular);
            location = GL.GetUniformLocation(ShaderObject, "light.direction");
            GL.Uniform3(location, light.direction);
            location = GL.GetUniformLocation(ShaderObject, "light.intensity");
            GL.Uniform1(location, light.intensity);

            location = GL.GetUniformLocation(ShaderObject, "camPos");
            GL.Uniform3(location, new Vector3(0, 0, 8));
        }
        private void DrawModel()
        {
            GL.DrawArrays(BeginMode.Triangles, 0, vertexCount);
        }
        private void CleanupResources()
        {
            GL.BindBuffer(BufferTarget.ArrayBuffer, 0);
            GL.BindVertexArray(0);
            GL.UseProgram(0);
        }
        private void SwapBuffers()
        {
            glControl1.SwapBuffers();
        }
    }
}
