using OpenTK;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Threading;
using System.Windows.Forms;

namespace MoeMikuManage
{
    public partial class ModelViewer
    {
        private void changeEaseInOutOpt()
        {
            easeInOutOpt = 1 - easeInOutOpt;
        }
        private void animeSaveEndPosRot()
        {
            Quaternion qx = Quaternion.FromAxisAngle(Vector3.UnitX, modelRotation.X);
            Quaternion qy = Quaternion.FromAxisAngle(Vector3.UnitY, modelRotation.Y);
            Quaternion qz = Quaternion.FromAxisAngle(Vector3.UnitZ, modelRotation.Z);

            Quaternion quat = qx * qy * qz;
            endQuaternion = quat;
            endPosition = modelPosition;
            endModelScale = modelScale;
            changeDebugText(modelPosition, modelRotation);
        }

        private void animeSaveStartPosRot()
        {
            Quaternion qx = Quaternion.FromAxisAngle(Vector3.UnitX, modelRotation.X);
            Quaternion qy = Quaternion.FromAxisAngle(Vector3.UnitY, modelRotation.Y);
            Quaternion qz = Quaternion.FromAxisAngle(Vector3.UnitZ, modelRotation.Z);

            Quaternion quat = qx * qy * qz;
            startQuaternion = quat;
            startPosition = modelPosition;
            startModelScale = modelScale;
            changeDebugText(modelPosition, modelRotation);
        }

        private void startAnimeThread()
        {
            thread = new Thread(() =>
            {
                float t = 0f;
                float duration = 1f;
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

                    curQuaternion = Quaternion.Slerp(startQuaternion, endQuaternion, EaseInOut(t));
                    modelScale = startModelScale + (endModelScale - startModelScale) * EaseInOut(t);

                    currentPosition = Vector3.Lerp(startPosition, endPosition, EaseInOut(t));

                    modelPosition = currentPosition;
                    modelRotation = curQuaternion.ToEulerAngles();
                    changeDisplayText(t);

                    glControl1.Invalidate();

                    Thread.Sleep(5);
                }
            });
            thread.Start();
        }

        private void changeAnimeThread()
        {
            if (thread == null)
            {
                startAnimeThread();
            }
            else
            {
                thread.Abort();
                thread = null;

                modelPosition.X = (float)Xpos.Value;
                modelPosition.Y = (float)Ypos.Value;
                modelPosition.Z = (float)Zpos.Value;

                modelRotation.X = (float)(rotX.Value * Math.PI / 180.0);
                modelRotation.Y = (float)(rotY.Value * Math.PI / 180.0);
                modelRotation.Z = (float)(rotZ.Value * Math.PI / 180.0);

                modelScale = (float)Math.Exp(scale.Value);

                changeTextOutput();

                glControl1.Invalidate();
            }
        }
    }
}
