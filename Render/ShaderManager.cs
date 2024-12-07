using OpenTK;
using OpenTK.Graphics.OpenGL;
using System.IO;

namespace MoeMikuManage
{
    public partial class ModelViewer
    {
        private void CompileAndLinkShaders()
        {
            string vertexPath = "model_vert.shader";
            string fragmentPath = "model_frag.shader";

            string VertexShaderSource = File.ReadAllText(vertexPath);
            string FragmentShaderSource = File.ReadAllText(fragmentPath);

            int VertexShader = GL.CreateShader(ShaderType.VertexShader);
            GL.ShaderSource(VertexShader, VertexShaderSource);
            GL.CompileShader(VertexShader);

            CheckShaderCompilation(VertexShader);

            int FragmentShader = GL.CreateShader(ShaderType.FragmentShader);
            GL.ShaderSource(FragmentShader, FragmentShaderSource);
            GL.CompileShader(FragmentShader);

            CheckShaderCompilation(FragmentShader);

            ShaderObject = GL.CreateProgram();

            GL.AttachShader(ShaderObject, VertexShader);
            GL.AttachShader(ShaderObject, FragmentShader);

            GL.LinkProgram(ShaderObject);

            CheckProgramLinking(ShaderObject);
        }
        private void CheckShaderCompilation(int shader)
        {
            GL.GetShader(shader, ShaderParameter.CompileStatus, out int success);
            if (success == 0)
            {
                string infoLog = GL.GetShaderInfoLog(shader);
                System.Console.WriteLine(infoLog);
            }
        }

        private void CheckProgramLinking(int program)
        {
            GL.GetProgram(program, GetProgramParameterName.LinkStatus, out int success);
            if (success == 0)
            {
                string infoLog = GL.GetProgramInfoLog(program);
                System.Console.WriteLine(infoLog);
            }
        }
        private void SetUniformVariables()
        {
            Matrix4 perspective = Matrix4.CreatePerspectiveFieldOfView(1.04f, glControl1.AspectRatio, 0.1f, 1000);
            Matrix4 lookat = Matrix4.LookAt(cameraPos, cameraTarget, Vector3.UnitY);

            int modelAddress = GL.GetUniformLocation(ShaderObject, "model");
            int viewAddress = GL.GetUniformLocation(ShaderObject, "view");
            int projectionAddress = GL.GetUniformLocation(ShaderObject, "projection");

            Matrix4 translation = Matrix4.CreateTranslation(modelPosition);
            
            
            Matrix4.CreateTranslation(modelPosition);
            Matrix4 rotationMatrix;
            if (animating == 1)
            {
                rotationMatrix = Matrix4.CreateFromQuaternion(curQuaternion);
            }
            else
            {
                Quaternion qx = Quaternion.FromAxisAngle(Vector3.UnitX, modelRotation.X);
                Quaternion qy = Quaternion.FromAxisAngle(Vector3.UnitY, modelRotation.Y);
                Quaternion qz = Quaternion.FromAxisAngle(Vector3.UnitZ, modelRotation.Z);
                Quaternion rotationQuat = qx * qy * qz;
                rotationMatrix = Matrix4.CreateFromQuaternion(rotationQuat);
            }
            
            Matrix4 scale = Matrix4.CreateScale(modelScale);

            Matrix4 model = scale * rotationMatrix * translation;

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
            GL.Uniform3(location, cameraPos);
        }
    }

}
