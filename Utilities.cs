using OpenTK;
using System;

namespace MoeMikuManage
{
    public partial class ModelViewer
    {
        private struct Material
        {
            public Vector3 ambient;
            public Vector3 diffuse;
            public Vector3 specular;
            public float shininess;
        }

        private struct DirectionalLight
        {
            public Vector3 direction;
            public Vector3 ambient;
            public Vector3 diffuse;
            public Vector3 specular;
            public float intensity;
        }

        private float EaseInOut(float t)
        {
            if (easeInOutOpt == 1)
                return 0.5f * (1f - (float)Math.Cos(Math.PI * t));
            else return t;
        }

        private void updatePosValue() {
            modelPosition.X = (float)Xpos.Value;
            modelPosition.Y = (float)Ypos.Value;
            modelPosition.Z = (float)Zpos.Value;

            modelRotation.X = (float)(rotX.Value * Math.PI / 180.0);
            modelRotation.Y = (float)(rotY.Value * Math.PI / 180.0);
            modelRotation.Z = (float)(rotZ.Value * Math.PI / 180.0);

            modelScale = (float)Math.Exp(scale.Value);
        }

        private void updatePosTextValue()
        {
            XposLable.Text = "x: " + Xpos.Value.ToString();
            YposLable.Text = "y: " + Ypos.Value.ToString();
            ZposLable.Text = "z: " + Zpos.Value.ToString();
            rotXLable.Text = "rotx: " + rotX.Value.ToString();
            rotYLable.Text = "roty: " + rotY.Value.ToString();
            rotZLable.Text = "rotz: " + rotZ.Value.ToString();
            scaleLable.Text = "scale: " + scale.Value.ToString();
        }

        
    }
    public static class QuaternionExtensions
    {
        public static Vector3 ToEulerAngles(this Quaternion q)
        {
            float sinr_cosp = 2.0f * (q.W * q.X + q.Y * q.Z);
            float cosr_cosp = 1.0f - 2.0f * (q.X * q.X + q.Y * q.Y);
            float roll = (float)Math.Atan2(sinr_cosp, cosr_cosp);

            float sinp = 2.0f * (q.W * q.Y - q.Z * q.X);
            float pitch = Math.Abs(sinp) >= 1 ? CopySign((float)Math.PI / 2, sinp) : (float)Math.Asin(sinp);

            float siny_cosp = 2.0f * (q.W * q.Z + q.X * q.Y);
            float cosy_cosp = 1.0f - 2.0f * (q.Y * q.Y + q.Z * q.Z);
            float yaw = (float)Math.Atan2(siny_cosp, cosy_cosp);

            return new Vector3(roll, pitch, yaw);
        }

        private static float CopySign(float magnitude, float sign)
        {
            return (float)(Math.Sign(sign) * Math.Abs(magnitude));
        }
    }

}
