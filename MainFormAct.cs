using OpenTK;
using OpenTK.Graphics.OpenGL;
using System;
using System.Globalization;
using System.IO;
using System.Threading;
using System.Windows.Forms;

namespace MoeMikuManage
{
    public partial class ModelViewer : Form
    {
        public ModelViewer()
        {
            Thread.CurrentThread.CurrentUICulture = new CultureInfo("en-US");
            Thread.CurrentThread.CurrentCulture = new CultureInfo("en-US");
            this.InitializeComponent();
            glControl1.MouseDown += glControl1_MouseDown;
            glControl1.MouseMove += glControl1_MouseMove;
            glControl1.MouseUp += glControl1_MouseUp;
            glControl1.MouseWheel += glControl1_MouseWheel;
        }

        private void btnLoadModel_Click(object sender, EventArgs e)
        {
            OpenFileDialog file = new OpenFileDialog();
            file.Filter = "OBJ File |*.obj|STL File |*.stl";
            file.Title = "Select your Model File..";

            if (file.ShowDialog() == DialogResult.OK)
            {
                GL.Clear(ClearBufferMask.ColorBufferBit);
                GL.Clear(ClearBufferMask.DepthBufferBit);

                string fileExtension = Path.GetExtension(file.FileName).ToLower();

                if (fileExtension == ".obj")
                {
                    ModelLoadToBuffer(file.FileName.Substring(0, file.FileName.IndexOf(".obj")), 0);
                }
                else if (fileExtension == ".stl")
                {
                    ModelLoadToBuffer(file.FileName.Substring(0, file.FileName.IndexOf(".obj")), 1);
                }

                glControl1.Invalidate();
            }
        }

        private void btnRotate_Click(object sender, EventArgs e)
        {
            if (thread == null)
            {
                thread = new Thread(() =>
                {
                    while (true)
                    {
                        x_angle_3d_model += 0.05f;
                        y_angle_3d_model -= 0.05f;
                        z_angle_3d_model += 0.05f;
                        glControl1.Invalidate();
                        Thread.Sleep(100);
                    }
                });
                thread.Start();
            }
            else
            {
                thread.Abort();
                x_angle_3d_model = 0;
                y_angle_3d_model = 0;
                z_angle_3d_model = 0;
                thread = null;
                glControl1.Invalidate();
            }
        }
        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {

            if (thread != null)
            {
                thread.Abort();
                thread = null;
            }
        }
        private void Form1_KeyPress(object sender, System.Windows.Forms.KeyPressEventArgs e)
        {
            Console.WriteLine(e.KeyChar);
            char key = e.KeyChar.ToString().ToUpper()[0];
            Vector3 dir = cameraTarget - cameraPos;
            Vector3 forward = dir.Normalized();
            Vector3 right = Vector3.Cross(forward, Vector3.UnitY).Normalized();

            if (key == (char)Keys.W)
            {
                cameraPos += forward * moveVelocity;
                cameraTarget += forward * moveVelocity;
            }
            else if (key == (char)Keys.S)
            {
                cameraPos -= forward * moveVelocity;
                cameraTarget -= forward * moveVelocity;
            }
            if (key == (char)Keys.A)
            {
                cameraPos -= right * moveVelocity;
                cameraTarget -= right * moveVelocity;
            }
            else if (key == (char)Keys.D)
            {
                cameraPos += right * moveVelocity;
                cameraTarget += right * moveVelocity;
            }
            if (key == (char)Keys.Space || key == (char)Keys.Q)
            {
                cameraPos.Y += moveVelocity;
                cameraTarget.Y += moveVelocity;
            }
            else if (key == (char)Keys.E)
            {
                cameraPos.Y -= moveVelocity;
                cameraTarget.Y -= moveVelocity;
            }
            coordinateLinesLong = (float)(Math.Max(cameraPos.X, Math.Max(cameraPos.Y, cameraPos.Z)) * Math.Sqrt(2));
            glControl1.Invalidate();
            changeTextOutput();
        }

        private void glControl1_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                isDragging = true;
                lastMousePosition = e.Location;
            }
            else if (e.Button == MouseButtons.Middle)
            {
                isDragging_Mid = true;
                lastMousePosition = e.Location;
            }
        }

        private void glControl1_MouseMove(object sender, MouseEventArgs e)
        {
            if (isDragging && e.Button == MouseButtons.Left)
            {
                float deltaX = (e.Location.X - lastMousePosition.X) * rotationSpeed;
                float deltaY = (e.Location.Y - lastMousePosition.Y) * rotationSpeed;

                Matrix4 rotationX = Matrix4.CreateRotationX(deltaY);
                Matrix4 rotationY = Matrix4.CreateRotationY(deltaX);
                Matrix4 rotationTotal = rotationX * rotationY;
                Matrix3 rotationTotal3 = new Matrix3(rotationTotal.M11, rotationTotal.M12, rotationTotal.M13, rotationTotal.M21, rotationTotal.M22, rotationTotal.M23, rotationTotal.M31, rotationTotal.M32, rotationTotal.M33);

                Vector3 direction = cameraTarget - cameraPos;
                direction = Vector3.Transform(direction, rotationTotal3);

                cameraTarget = cameraPos + direction;
                cameraDir = direction;

                lastMousePosition = e.Location;
                glControl1.Invalidate();
            }
            else
            {
                if (isDragging_Mid && e.Button == MouseButtons.Middle)
                {
                    float deltaX = (e.Location.X - lastMousePosition.X) * rotationSpeed;
                    float deltaY = (e.Location.Y - lastMousePosition.Y) * rotationSpeed;

                    Matrix4 rotationX = Matrix4.CreateRotationX(deltaY);
                    Matrix4 rotationY = Matrix4.CreateRotationY(deltaX);
                    Matrix4 rotationTotal = rotationX * rotationY;
                    Matrix3 rotationTotal3 = new Matrix3(rotationTotal.M11, rotationTotal.M12, rotationTotal.M13, rotationTotal.M21, rotationTotal.M22, rotationTotal.M23, rotationTotal.M31, rotationTotal.M32, rotationTotal.M33);

                    Vector3 direction = cameraPos - cameraTarget;
                    direction = Vector3.Transform(direction, rotationTotal3);

                    cameraPos = cameraTarget + direction;
                    cameraDir = -direction;

                    lastMousePosition = e.Location;
                    glControl1.Invalidate();
                }
            }
            changeTextOutput();
        }

        private void glControl1_MouseUp(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                isDragging = false;
            }
            else if (e.Button == MouseButtons.Middle)
            {
                isDragging_Mid = false;
            }
        }
        private void glControl1_MouseWheel(object sender, MouseEventArgs e)
        {
            float zoomSpeed = 0.1f;
            float zoomFactor = e.Delta < 0 ? 1 + zoomSpeed : 1 - zoomSpeed;

            Vector3 direction = cameraTarget - cameraPos;
            direction = direction * zoomFactor;

            cameraPos = cameraTarget - direction;
            glControl1.Invalidate();
            changeTextOutput();
        }

    }
}
