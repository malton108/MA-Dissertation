using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*
 * ProceduralBlocks takes a building prefab which is instantiated multiple times inside of a block
 * This grid is set as a Manhattan style grid
 * A building is generated in ProceduralBuilding which instantiates a BuildingPiece whose height is calculated and affected by Perlin noise
 */
public class ProceduralBlocks : MonoBehaviour
{
    // Set the building prefab which will be instantiated multiple times inside the block
    public GameObject building;
    void Start()
    {
        // Set the length of the block. Each X coordinate represents 1 lot, so each block in this instance is 13 lots long
        int blockLength = 13;
        // Set the depth of each block. A block is 2 lots deep, so the depth in this instance is set to 2
        int blockDepth = 2;
        // For each coordinate in the block, instantiate a building
        for (int x = 0; x < blockLength; x++)
        {
            for (int z = 0; z < blockDepth; z++)
            {
                // Set a buildingSpace in each axes. As buildings are 1 unit wide and 2 units deep, the space in the Z axis needs to be double the space in the X axis
                int buildingSpaceX = 1;
                int buildingSpaceZ = 2;
                // Instantiate the building
                Instantiate(building, transform.position + new Vector3(buildingSpaceX * x, 0, buildingSpaceZ * z), transform.rotation);
            }
        }
    }
}
