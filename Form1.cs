using OpenTK;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Threading;
using System.Windows.Forms;

namespace MoeMikuManage
{
    public partial class ModelViewer : Form
    {
        Thread thread = null;

        #region 3D NESNE OPENGL
        List<Vector3> vertices = new List<Vector3>();
        List<int> triangles = new List<int>();
        List<Vector3> normals = new List<Vector3>();
        List<Vector2> texCoords = new List<Vector2>();
        private List<int[]> faces = new List<int[]>();

        private bool isDragging = false;
        private bool isDragging_Mid = false;
        private Point lastMousePosition;
        private float rotationSpeed = 0.005f; // 旋转速度
        private Vector3 cameraTarget = new Vector3(0, 0, 0); // 摄像机的初始中心点

        private string win_name = "MoeMikuManage";
        private Vector3 modelPosition = Vector3.Zero;
        private Vector3 modelRotation = Vector3.Zero;
        private float modelScale = 1.0f;

        int vertexCount;
        int VertexBufferObject, VertexArrayObject, ShaderObject, TextureObject;
        float x_angle_3d_model = 0, y_angle_3d_model = 0, z_angle_3d_model = 0;


        Material modelMat;
        DirectionalLight light;

        private void changeTextOutput()
        {
            Vector3 forward = (cameraTarget - cameraPos).Normalized();
            string cameraPosText = $"Camera Position: X: {cameraPos.X:F2}, Y: {cameraPos.Y:F2}, Z: {cameraPos.Z:F2}";
            string cameraDirText = $"Camera Direction: X: {forward.X:F2}, Y: {forward.Y:F2}, Z: {forward.Z:F2}";
            string cameraTarText = $"Camera Target: X: {cameraTarget.X:F2}, Y: {cameraTarget.Y:F2}, Z: {cameraTarget.Z:F2}";
            DirInfo.Text = cameraPosText + Environment.NewLine + cameraDirText + Environment.NewLine + cameraTarText;
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void splitContainer1_Panel2_Paint(object sender, PaintEventArgs e)
        {

        }

        private void splitContainer1_Panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void 关于ToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void btnRotate_Click(object sender, EventArgs e)
        {
            ValueChanged(sender, e);

            Xpos.ValueChanged += ValueChanged;
            Ypos.ValueChanged += ValueChanged;
            Zpos.ValueChanged += ValueChanged;
            rotX.ValueChanged += ValueChanged;
            rotY.ValueChanged += ValueChanged;
            rotZ.ValueChanged += ValueChanged;
            scale.ValueChanged += ValueChanged;
        }

        private void ValueChanged(object sender, EventArgs e)
        {
            modelPosition.X = (float)Xpos.Value;
            modelPosition.Y = (float)Ypos.Value;
            modelPosition.Z = (float)Zpos.Value;

            // 更新旋转角度（转换为弧度）
            modelRotation.X = (float)(rotX.Value * Math.PI / 180.0);
            modelRotation.Y = (float)(rotY.Value * Math.PI / 180.0);
            modelRotation.Z = (float)(rotZ.Value * Math.PI / 180.0);

            // 更新缩放
            modelScale = (float)Math.Exp(scale.Value);
            XposLable.Text = "x: " + Xpos.Value.ToString();
            YposLable.Text = "y: " + Ypos.Value.ToString();
            ZposLable.Text = "z: " + Zpos.Value.ToString();
            rotXLable.Text = "rotx: " + rotX.Value.ToString();
            rotYLable.Text = "roty: " + rotY.Value.ToString();
            rotZLable.Text = "rotz: " + rotZ.Value.ToString();
            scaleLable.Text = "scale: " + scale.Value.ToString();

            glControl1.Invalidate();
        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void trackBar2_Scroll(object sender, EventArgs e)
        {

        }

        Vector3 cameraDir = new Vector3(0, 0, 0);
        Vector3 cameraPos = new Vector3(20, 10, 40);

        float coordinateLinesLong = 10;
        float moveVelocity = 1f;

        private void ModelLoadToBuffer(string filePath, int file_type)
        {
            this.Text = win_name + " - [" + filePath + "]";
            List<float> vertexBuffer;
            if (file_type == 0)
            {
                ParseObjFile(filePath);
                vertexBuffer = PrepareVertexBuffer();
            }
            else
            {
                ParseStlFile(filePath);
                vertexBuffer = PrepareStlVertexBuffer(vertices, normals);
            }
            ConfigureVBOAndVAO(vertexBuffer);
            CompileAndLinkShaders();
            LoadTexture(filePath);
            SetDefaultMaterialAndLight();
        }
        #endregion
    }
}
