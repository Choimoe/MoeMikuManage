using OpenTK;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MoeMikuManage
{
    public partial class ModelViewer
    {
        private void changeTextOutput()
        {
            Vector3 forward = (cameraTarget - cameraPos).Normalized();
            string cameraPosText = $"Camera Position: X: {cameraPos.X:F2}, Y: {cameraPos.Y:F2}, Z: {cameraPos.Z:F2}";
            string cameraDirText = $"Camera Direction: X: {forward.X:F2}, Y: {forward.Y:F2}, Z: {forward.Z:F2}";
            string cameraTarText = $"Camera Target: X: {cameraTarget.X:F2}, Y: {cameraTarget.Y:F2}, Z: {cameraTarget.Z:F2}";
            DirInfo.Text = cameraPosText + Environment.NewLine + cameraDirText + Environment.NewLine + cameraTarText;
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
    }
}
