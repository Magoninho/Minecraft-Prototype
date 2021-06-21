using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Chunk : MonoBehaviour
{
	// mesh renderer and mesh filter for making the thing work
	public MeshRenderer meshRenderer;
	public MeshFilter meshFilter;

	// the current vertex index
	int vertexIndex = 0;
	// a list of vertices for the mesh
	List<Vector3> vertices = new List<Vector3>();
	// the list of triangles
	List<int> triangles = new List<int>();
	// uvs, something I don't know what is. Just copying
	List<Vector2> uvs = new List<Vector2>();

	bool[,,] voxelMap = new bool[VoxelData.ChunkWidth, VoxelData.ChunkHeight, VoxelData.ChunkWidth];

	void Start()
	{
		PopulateVoxelMap(); // generate map of blocks

		CreateMeshData();	// add voxel data to positions

		CreateMesh();		// creates the final mesh
	}

	// Defines if there is a block in the position
	void PopulateVoxelMap()
	{
		for (int y = 0; y < VoxelData.ChunkHeight; y++)
		{
			for (int x = 0; x < VoxelData.ChunkHeight; x++)
			{
				for (int z = 0; z < VoxelData.ChunkHeight; z++)
				{
					voxelMap[x, y, z] = true;
				}
			}
		}
	}

	// Create the Voxels in some x, y and z positions
	void CreateMeshData()
	{
		for (int y = 0; y < VoxelData.ChunkHeight; y++)
		{
			for (int x = 0; x < VoxelData.ChunkWidth; x++)
			{
				for (int z = 0; z < VoxelData.ChunkWidth; z++)
				{
					AddVoxelDataToChunk(new Vector3(x, y, z));
				}
			}
		}
	}

	// Checks if there is a voxel in a particular position
	bool CheckVoxel(Vector3 pos)
	{
		int x = Mathf.FloorToInt(pos.x);
		int y = Mathf.FloorToInt(pos.y);
		int z = Mathf.FloorToInt(pos.z);

		if (x < 0 || x > VoxelData.ChunkWidth - 1 || y < 0 || y > VoxelData.ChunkHeight - 1 || z < 0 || z > VoxelData.ChunkWidth - 1)
			return false;

		return voxelMap[x, y, z];
	}

	void AddVoxelDataToChunk(Vector3 pos)
	{
		for (int p = 0; p < 6; p++)
		{
			// if there is no voxel in the position + the unit from the faceChecks array (e.g. -1, 0, 1) 
			if (!CheckVoxel(pos + VoxelData.faceChecks[p]))
			{
				for (int i = 0; i < 6; i++)
				{
					int triangleIndex = VoxelData.voxelTris[p, i]; // indexes of the cube faces
																   // adding the corresponding voxel vertex that was got from the triangle index
					vertices.Add(VoxelData.voxelVerts[triangleIndex] + pos);

					uvs.Add(VoxelData.voxelUvs[i]);

					triangles.Add(vertexIndex);
					vertexIndex++;
				}
			}
		}
	}

	void CreateMesh()
	{
		Mesh mesh = new Mesh();
		mesh.Clear();
		mesh.vertices = vertices.ToArray();
		mesh.triangles = triangles.ToArray();
		mesh.uv = uvs.ToArray();

		mesh.RecalculateNormals();
		meshFilter.mesh = mesh;
	}


}
