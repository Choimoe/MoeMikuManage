using OpenTK.Graphics.OpenGL;
using StbImageSharp;
using System.IO;

namespace MoeMikuManage
{
    public partial class ModelViewer
    {
        private void LoadTexture(string filePath)
        {
            TextureObject = GL.GenTexture();
            GL.BindTexture(TextureTarget.Texture2D, TextureObject);

            GL.TexParameter(TextureTarget.Texture2D, TextureParameterName.TextureWrapS, (int)TextureWrapMode.Repeat);
            GL.TexParameter(TextureTarget.Texture2D, TextureParameterName.TextureWrapT, (int)TextureWrapMode.Repeat);
            GL.TexParameter(TextureTarget.Texture2D, TextureParameterName.TextureMinFilter, (int)TextureMinFilter.Linear);
            GL.TexParameter(TextureTarget.Texture2D, TextureParameterName.TextureMagFilter, (int)TextureMagFilter.Linear);

            StbImage.stbi_set_flip_vertically_on_load(1);

            try
            {
                ImageResult image = ImageResult.FromStream(File.OpenRead(filePath + "_diffuse.png"), ColorComponents.RedGreenBlueAlpha);
                GL.TexImage2D(TextureTarget.Texture2D, 0, PixelInternalFormat.Rgba, image.Width, image.Height, 0, PixelFormat.Rgba, PixelType.UnsignedByte, image.Data);
            }
            catch
            {
                string defaultTexturePath = filePath.Substring(0, filePath.LastIndexOf("/")) + "../Model/default_diffuse.png";
                ImageResult image = ImageResult.FromStream(File.OpenRead(defaultTexturePath), ColorComponents.RedGreenBlueAlpha);
                GL.TexImage2D(TextureTarget.Texture2D, 0, PixelInternalFormat.Rgba, image.Width, image.Height, 0, PixelFormat.Rgba, PixelType.UnsignedByte, image.Data);

                SetDefaultMaterialAndLight();
            }
        }

    }
}
