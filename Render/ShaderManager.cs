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

    }
}
