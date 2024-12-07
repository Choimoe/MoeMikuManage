using MoeMikuManage.Render;
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

        private Quaternion startQuaternion, endQuaternion, curQuaternion;
        private Vector3 startPosition, endPosition;
        private float startModelScale, endModelScale;

        Vector3 cameraDir = new Vector3(0, 0, 0);
        Vector3 cameraPos = new Vector3(20, 10, 40);

        float coordinateLinesLong = 10;
        float moveVelocity = 1f;

        private int easeInOutOpt = 0;
        private int animating = 0;


        Material modelMat;
        DirectionalLight light;

        

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

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            
        }

        private void renderToolStripMenuItem_Click(object sender, EventArgs e)
        {
            rayTracingOutput.Visible = false;
        }

        private void rayTracingToolStripMenuItem_Click(object sender, EventArgs e)
        {
            rayTracingOutput.Visible = true;
            startRenderRayTracing();
        }

        private void startRenderRayTracing()
        {
            Vector3 lightPos = new Vector3(0.81f, 2.04f, -0.11f);
            RayTracing t = new RayTracing(vertices, normals, faces, lightPos, cameraPos, cameraDir);
            t.RenderScene();
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

        

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void trackBar2_Scroll(object sender, EventArgs e)
        {

        }

        private void 设置缓入缓出ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            changeEaseInOutOpt();
        }

        private void animeSaveEnd_Click(object sender, EventArgs e)
        {
            animeSaveEndPosRot();
        }
        private void animeSaveStart_Click(object sender, EventArgs e)
        {
            animeSaveStartPosRot();
        }

        private void animeStart_Click(object sender, EventArgs e)
        {
            animating = 1 - animating;
            changeAnimeThread();
        }

        private void ValueChanged(object sender, EventArgs e)
        {
            updatePosValue();
            updatePosTextValue();

            glControl1.Invalidate();
        }

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
