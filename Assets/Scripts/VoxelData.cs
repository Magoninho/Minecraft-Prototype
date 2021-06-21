using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// https://i.imgur.com/jkoSUBd.png

public static class VoxelData
{

	public static readonly int ChunkWidth = 5;
	public static readonly int ChunkHeight = 5;

	// the vortex vertices
	public static readonly Vector3[] voxelVerts = new Vector3[8]
	{
		new Vector3(0.0f, 0.0f, 0.0f),
		new Vector3(1.0f, 0.0f, 0.0f),
		new Vector3(1.0f, 1.0f, 0.0f),
		new Vector3(0.0f, 1.0f, 0.0f),
		new Vector3(0.0f, 0.0f, 1.0f),
		new Vector3(1.0f, 0.0f, 1.0f),
		new Vector3(1.0f, 1.0f, 1.0f),
		new Vector3(0.0f, 1.0f, 1.0f)
	};

	// Basically the order of vertex indexes for connecting the triangles for making the cube
	public static readonly int[,] voxelTris = new int[6, 6] {
		{0, 3, 1, 1, 3, 2}, // Back face
		{5, 6, 4, 4, 6, 7}, // Front face
		{3, 7, 2, 2, 7, 6}, // Top face
		{1, 5, 0, 0, 5, 4}, // Bottom face
		{4, 7, 0, 0, 7, 3}, // Left face
		{1, 2, 5, 5, 2, 6}	// Right face
	};

	// texture stuff
	public static readonly Vector2[] voxelUvs = new Vector2[6] {
		new Vector2(0.0f, 0.0f),
		new Vector2(0.0f, 1.0f),
		new Vector2(1.0f, 0.0f),
		new Vector2(1.0f, 0.0f),
		new Vector2(0.0f, 1.0f),
		new Vector2(1.0f, 1.0f)
	};

	// neighbors
	public static readonly Vector3[] faceChecks = new Vector3[6] {
		new Vector3(0.0f, 0.0f, -1.0f),
		new Vector3(0.0f, 0.0f, 1.0f),
		new Vector3(0.0f, 1.0f, 0.0f),
		new Vector3(0.0f, -1.0f, 0.0f),
		new Vector3(-1.0f, 0.0f, 0.0f),
		new Vector3(1.0f, 0.0f, 0.0f)
	};

}
