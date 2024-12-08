using MoeMikuManage.RayTracing;
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
        private int raytracing = 0;


        Material modelMat;
        DirectionalLight light;

        private byte[] _pixelBuffer;
        private RayTracingScene _rayTracingScene;



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
            RayTracingSettingsPlane.Visible = false;
            raytracing = 0;
        }

        private void rayTracingToolStripMenuItem_Click(object sender, EventArgs e)
        {
            RayTracingSettingsPlane.Visible = true;
            raytracing = 1;
            // WIDTH = glControl1.Size.Width;
            // HEIGHT = glControl1.Size.Height;
            InitializeRayTracing();
            glControl1.Invalidate();
        }
        private int WIDTH = 800;
        private int HEIGHT = 600;
        private void InitializeRayTracing()
        {
            _rayTracingScene = new RayTracingScene();

            // Create objects
            _rayTracingScene.Objects.Add(new SpherePrimitive(
                new Vector3(-0.5f, -0.5f, -3), 0.5f,
                new Vector3(1, 0, 0), MaterialType.DIFFUSE, 64.0f));

            _rayTracingScene.Objects.Add(new SpherePrimitive(
                new Vector3(0.5f, -0.5f, -3), 0.5f,
                new Vector3(0, 0, 1), MaterialType.DIFFUSE, 32.0f));

            _rayTracingScene.Objects.Add(new PlanePrimitive(
                new Vector3(0, -1, 0), new Vector3(0, 1, 0),
                new Vector3(0.6f, 0.3f, 0.2f), MaterialType.DIFFUSE, 16.0f));

            // Add lights
            _rayTracingScene.Lights.Add(new Light(
                new Vector3(1, 1, 1), new Vector3(1, 1, 1)));

            _pixelBuffer = new byte[WIDTH * HEIGHT * 3];
        }
        private void RenderRayTracingScene()
        {
            var pixelBuffer = new Vector3[WIDTH * HEIGHT];
            _rayTracingScene.setCamera(cameraPos);

            for (int y = 0; y < HEIGHT; ++y)
            {
                for (int x = 0; x < WIDTH; ++x)
                {
                    float u = (x - WIDTH / 2.0f) / WIDTH;
                    float v = (y - HEIGHT / 2.0f) / HEIGHT;

                    Vector3 forward = cameraDir.Normalized();
                    Vector3 up = new Vector3(0, 1, 0);
                    Vector3 right = Vector3.Cross(forward, up).Normalized();
                    up = Vector3.Cross(right, forward).Normalized();

                    Vector3 rayDirection = (right * u + up * v + forward).Normalized();

                    Ray ray = new Ray(cameraPos, rayDirection);

                    Vector3 color = _rayTracingScene.Trace(ray);
                    pixelBuffer[y * WIDTH + x] = color;
                }
            }

            for (int i = 0; i < WIDTH * HEIGHT; ++i)
            {
                _pixelBuffer[i * 3 + 0] = (byte)(255 * Math.Min(1.0f, pixelBuffer[i].X));
                _pixelBuffer[i * 3 + 1] = (byte)(255 * Math.Min(1.0f, pixelBuffer[i].Y));
                _pixelBuffer[i * 3 + 2] = (byte)(255 * Math.Min(1.0f, pixelBuffer[i].Z));
            }
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void RTLightPosXSet_Scroll(object sender, EventArgs e)
        {
            Vector3 pos = _rayTracingScene.Lights[0].Position;
            _rayTracingScene.Lights[0].Position = new Vector3(RTLightPosXSet.Value / 20f, pos.Y, pos.Z);
            glControl1.Invalidate();
        }

        private void RTLightPosYSet_Scroll(object sender, EventArgs e)
        {
            Vector3 pos = _rayTracingScene.Lights[0].Position;
            _rayTracingScene.Lights[0].Position = new Vector3(pos.X, RTLightPosYSet.Value / 20f, pos.Z);
            glControl1.Invalidate();
        }

        private void RTLightPosZSet_Scroll(object sender, EventArgs e)
        {
            Vector3 pos = _rayTracingScene.Lights[0].Position;
            _rayTracingScene.Lights[0].Position = new Vector3(pos.X, pos.Y, RTLightPosZSet.Value / 20f);
            glControl1.Invalidate();
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
