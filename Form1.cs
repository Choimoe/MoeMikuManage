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

        private Quaternion startQuaternion, endQuaternion;
        private Vector3 startPosition, endPosition;
        private float startModelScale, endModelScale;


        private int easeInOutOpt = 0;


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
        private float EaseInOut(float t)
        {
            if (easeInOutOpt == 1)
                return 0.5f * (1f - (float)Math.Cos(Math.PI * t));
            else return t;
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

        private void animeSaveStart_Click(object sender, EventArgs e)
        {
            Quaternion qx = Quaternion.FromAxisAngle(Vector3.UnitX, modelRotation.X);
            Quaternion qy = Quaternion.FromAxisAngle(Vector3.UnitY, modelRotation.Y);
            Quaternion qz = Quaternion.FromAxisAngle(Vector3.UnitZ, modelRotation.Z);

            Quaternion quat = qx * qy * qz;
            // startQuaternion = Quaternion.Normalize(quat);
            startQuaternion = quat;
            startPosition = modelPosition;
            startModelScale = modelScale;
            changeDebugText(modelPosition, modelRotation);
        }

        private void 设置缓入缓出ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            easeInOutOpt = 1 - easeInOutOpt;
        }

        private void animeSaveEnd_Click(object sender, EventArgs e)
        {
            Quaternion qx = Quaternion.FromAxisAngle(Vector3.UnitX, modelRotation.X);
            Quaternion qy = Quaternion.FromAxisAngle(Vector3.UnitY, modelRotation.Y);
            Quaternion qz = Quaternion.FromAxisAngle(Vector3.UnitZ, modelRotation.Z);

            Quaternion quat = qx * qy * qz;
            // endQuaternion = Quaternion.Normalize(quat);
            endQuaternion = quat;
            endPosition = modelPosition;
            endModelScale = modelScale;
            changeDebugText(modelPosition, modelRotation);
        }

        private void animeStart_Click(object sender, EventArgs e)
        {
            if (thread == null)
            {
                thread = new Thread(() =>
                {
                    float t = 0f;
                    float duration = 1f;
                    Quaternion currentQuaternion;
                    Vector3 currentPosition;

                    while (true)
                    {
                        t += 0.01f / duration;
                        if (t > 1f)
                        {
                            t = 0f;
                            (endQuaternion, startQuaternion) = (startQuaternion, endQuaternion);
                            (endPosition, startPosition) = (startPosition, endPosition);
                            (endModelScale, startModelScale) = (startModelScale, endModelScale);
                        }

                        currentQuaternion = Quaternion.Slerp(startQuaternion, endQuaternion, EaseInOut(t));
                        modelScale = startModelScale + (endModelScale - startModelScale) * EaseInOut(t);

                        currentPosition = Vector3.Lerp(startPosition, endPosition, EaseInOut(t));

                        modelPosition = currentPosition;
                        modelRotation = currentQuaternion.ToEulerAngles();
                        changeDisplayText(t);

                        glControl1.Invalidate();

                        Thread.Sleep(5);
                    }
                });
                thread.Start();
            }
            else
            {
                thread.Abort();
                thread = null;

                modelPosition = startPosition;
                modelRotation = new Vector3(startQuaternion.X, startQuaternion.Y, startQuaternion.Z);
                changeTextOutput();

                glControl1.Invalidate();
            }
        }

        private void changeDisplayText(float time)
        {
            string modelPosText = $"modelPosition: X: {modelPosition.X:F2}, Y: {modelPosition.Y:F2}, Z: {modelPosition.Z:F2}";
            string modelRotText = $"modelRotation: X: {modelRotation.X:F2}, Y: {modelRotation.Y:F2}, Z: {modelRotation.Z:F2}";
            string curTime = $"curTime: t = {time:F2} (easeInOut = {EaseInOut(time):F2})";
            changeTextOutput();
            DirInfo.Text = DirInfo.Text + Environment.NewLine + modelPosText + Environment.NewLine + modelRotText + Environment.NewLine + curTime;
        }

        private void changeDebugText(Vector3 A, Vector3 B)
        {
            string modelPosText = $"curPosition: X: {A.X:F2}, Y: {A.Y:F2}, Z: {A.Z:F2}";
            string modelRotText = $"curRotation: X: {B.X:F2}, Y: {B.Y:F2}, Z: {B.Z:F2}";
            changeTextOutput();
            DirInfo.Text = DirInfo.Text + Environment.NewLine + modelPosText + Environment.NewLine + modelRotText;
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
