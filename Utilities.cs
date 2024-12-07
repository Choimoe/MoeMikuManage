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
    }
    public static class QuaternionExtensions
    {
        public static Vector3 ToEulerAngles(this Quaternion q)
        {
            // 提取四元数的各个分量
            float sinr_cosp = 2.0f * (q.W * q.X + q.Y * q.Z);
            float cosr_cosp = 1.0f - 2.0f * (q.X * q.X + q.Y * q.Y);
            float roll = (float)Math.Atan2(sinr_cosp, cosr_cosp);  // roll (x轴旋转)

            float sinp = 2.0f * (q.W * q.Y - q.Z * q.X);
            float pitch = Math.Abs(sinp) >= 1 ? CopySign((float)Math.PI / 2, sinp) : (float)Math.Asin(sinp); // pitch (y轴旋转)

            float siny_cosp = 2.0f * (q.W * q.Z + q.X * q.Y);
            float cosy_cosp = 1.0f - 2.0f * (q.Y * q.Y + q.Z * q.Z);
            float yaw = (float)Math.Atan2(siny_cosp, cosy_cosp); // yaw (z轴旋转)

            return new Vector3(roll, pitch, yaw);  // 返回欧拉角（以弧度表示）
        }

        // 自定义CopySign方法
        private static float CopySign(float magnitude, float sign)
        {
            return (float)(Math.Sign(sign) * Math.Abs(magnitude));
        }
    }

}
