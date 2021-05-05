using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*
 * ProceduralBlock accepts a block prefab which is a series of building prefabs instantiated together to form a Manhattan block with random heights formed by Perlin noise
 * This script instantiates these blocks at set regular intervals, being spaced to appear like a Manhattan city grid
 */
public class ProceduralGrid: MonoBehaviour
{
    // Set the number of blocks in the X and Z axes
    public int numBlocksX = 12;
    public int numBlocksZ = 8;
    // Set the blocks aligned with the entire grid
    public Vector3 blockAlign = new Vector3(-62.5f, 0, -40f);

    // Set the block prefab
    public GameObject block;
    void Start()
    {
        // For each coordinate, instantiate a block
        for (int x = 0; x < numBlocksX; x++)
        {
            for (int z = 0; z < numBlocksZ; z++)
            {
                // Set the spacing between each block which forms the roads
                int blockSpacingX = 16;
                int blockSpacingZ = 7;
                
                // Instantiate the block
                Instantiate(block, transform.position + blockAlign + new Vector3(blockSpacingX * x, 0.5f, blockSpacingZ * z), transform.rotation);
            }
        }
    }
}
