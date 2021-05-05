using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;

/*
 * ProceduralBuildings takes a buildingPiece object which is instantiated and set to the calculated height affected by Perlin noise
 * This building is then instantiated in ProceduralBlocks multiple times to form a block of buildings with various heights
 * The heights of each building is determined by PerlinNoise, which creates a 2D texture affected by perlin noise whose heights are obtained and used with a set number of layers
 */
public class ProceduralBuildings : MonoBehaviour
{
    // The max and min height a building can be
    public int minHeight = 1;
    public int maxHeight = 15;

    // Check if the user wants to write the heights of buildings to a file
    public bool writeBuildings = false;

    // Check if the building heights should be random
    public bool randomHeights = false;

    // Setting the buildingPiece prefab. This prefab fills the size of a lot in a block
    public GameObject buildingPiece;
    void Start()
    {
        // The position is used to obtain a specific value to use as the height from a 2D texure affected by perlin noise
        float perlinHeight = PerlinNoise.perlinInstance.PerlinHeight(transform.position.x, transform.position.z);

        // If the user wants random building heights then produce that
        float maxPerlinHeight;
        if (randomHeights)
        {
            // The max height a building can be multiplied by the value affected by perlin noise
            maxPerlinHeight = minHeight + ((maxHeight - minHeight) * Random.Range(0.0f, 1.0f));
        }
        // If the user doesn't want random heights then use the Perlin noise heights
        else
        {
            // The max height a building can be multiplied by the value affected by perlin noise
            maxPerlinHeight = minHeight + ((maxHeight - minHeight) * perlinHeight);
        }
        // If the height of the building is greater than or equal to 0, then instantiate the building
        if (maxPerlinHeight >= 0)
        {
            // Create the building and set its height and move it into position
            GameObject building = Instantiate(buildingPiece, this.transform.position, transform.rotation);
            if (writeBuildings)
            {
                // Write height to file for testing if true
                WriteBuildingHeight(maxPerlinHeight);
            }
            building.transform.localScale = new Vector3(1, maxPerlinHeight, 2);
            building.transform.position += new Vector3(0, maxPerlinHeight / 2, 0);
        }
    }

    /*
     * WriteBuildingHeight writes the building height to a text file for use in testing
     */
    void WriteBuildingHeight(float height)
    {
        string filePath = @"C:\MA-DISS\BuildingHeights.csv";
        File.AppendAllText(filePath, height.ToString());
        File.AppendAllText(filePath, "\n");
    }
}
