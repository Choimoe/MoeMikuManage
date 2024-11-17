using OpenTK;
using OpenTK.Graphics.OpenGL;
using System;
using System.Collections.Generic;
using System.IO;

namespace MoeMikuManage
{
    public partial class ModelViewer
    {
        private void ParseObjFile(string filePath)
        {
            ObjParser.ParseFile(filePath + ".obj");
            vertices = ObjParser.Vertices;
            normals = ObjParser.Normals;
            texCoords = ObjParser.TexCoords;
            faces = ObjParser.Faces;

            System.Console.WriteLine("vertices : " + vertices.Count);
            System.Console.WriteLine("triangles : " + triangles.Count);
            System.Console.WriteLine("normals : " + normals.Count);
            System.Console.WriteLine("texCoords : " + texCoords.Count);
        }
        private List<float> PrepareVertexBuffer()
        {
            List<float> vertexBuffer = new List<float>();
            foreach (int[] face in faces)
            {
                for (int i = 0; i < 3; i++)
                {
                    OpenTK.Vector3 vertex = vertices[face[i * 3]];
                    OpenTK.Vector2 texCoord = texCoords[face[i * 3 + 1]];
                    OpenTK.Vector3 normal = normals[face[i * 3 + 2]];

                    vertexBuffer.Add(vertex.X);
                    vertexBuffer.Add(vertex.Y);
                    vertexBuffer.Add(vertex.Z);
                    vertexBuffer.Add(texCoord.X);
                    vertexBuffer.Add(texCoord.Y);
                    vertexBuffer.Add(normal.X);
                    vertexBuffer.Add(normal.Y);
                    vertexBuffer.Add(normal.Z);
                }
            }

            return vertexBuffer;
        }
        private void ParseStlFile(string filePath)
        {
            using (BinaryReader reader = new BinaryReader(File.Open(filePath + ".stl", FileMode.Open)))
            {
                reader.BaseStream.Seek(80, SeekOrigin.Begin);

                uint numTriangles = reader.ReadUInt32();

                List<Vector3> vertices = new List<Vector3>();
                List<OpenTK.Vector3> normals = new List<Vector3>();

                for (int i = 0; i < numTriangles; i++)
                {
                    Vector3 normal = new Vector3(
                        reader.ReadSingle(),
                        reader.ReadSingle(),
                        reader.ReadSingle()
                    );

                    for (int j = 0; j < 3; j++)
                    {
                        Vector3 vertex = new Vector3(
                            reader.ReadSingle(),
                            reader.ReadSingle(),
                            reader.ReadSingle()
                        );

                        vertices.Add(vertex);
                        normals.Add(normal);
                    }

                    reader.ReadUInt16();
                }

                Console.WriteLine($"Vertices count: {vertices.Count}");
                Console.WriteLine($"Normals count: {normals.Count}");

                List<float> vertexBuffer = PrepareStlVertexBuffer(vertices, normals);
                ConfigureVBOAndVAO(vertexBuffer);
            }
        }
        private List<float> PrepareStlVertexBuffer(List<Vector3> vertices, List<Vector3> normals)
        {
            List<float> vertexBuffer = new List<float>();

            for (int i = 0; i < vertices.Count; i++)
            {
                Vector3 vertex = vertices[i];
                Vector3 normal = normals[i];

                vertexBuffer.Add(vertex.X);
                vertexBuffer.Add(vertex.Y);
                vertexBuffer.Add(vertex.Z);

                vertexBuffer.Add(normal.X);
                vertexBuffer.Add(normal.Y);
                vertexBuffer.Add(normal.Z);
            }

            return vertexBuffer;
        }
        private void ConfigureVBOAndVAO(List<float> vertexBuffer)
        {
            vertexCount = vertexBuffer.Count / 8;

            VertexBufferObject = GL.GenBuffer();
            GL.BindBuffer(BufferTarget.ArrayBuffer, VertexBufferObject);
            GL.BufferData(BufferTarget.ArrayBuffer, sizeof(float) * vertexBuffer.Count, vertexBuffer.ToArray(), BufferUsageHint.StaticDraw);

            VertexArrayObject = GL.GenVertexArray();
            GL.BindVertexArray(VertexArrayObject);

            GL.VertexAttribPointer(0, 3, VertexAttribPointerType.Float, false, 8 * sizeof(float), 0);
            GL.VertexAttribPointer(1, 2, VertexAttribPointerType.Float, false, 8 * sizeof(float), 3 * sizeof(float));
            GL.VertexAttribPointer(2, 3, VertexAttribPointerType.Float, false, 8 * sizeof(float), 5 * sizeof(float));

            GL.EnableVertexAttribArray(0);
            GL.EnableVertexAttribArray(1);
            GL.EnableVertexAttribArray(2);
        }
    }
}
