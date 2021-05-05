using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PerlinNoise : MonoBehaviour
{
    // Initialise an instance of Perlin noise, which is set once Start() is called
    public static PerlinNoise perlinInstance = null;
    // A float value to decrease/increase the effect of Perlin noise
    public float noiseLevel = 2f;
    // Initialise the 2D texture to be affected by Perlin noise
    private Texture2D perlinTexture;

    /*
     * Start creates an instance of Perlin noise, which is created through Unity's Mathf.PerlinNoise function. This Perlin noise is then mapped onto a 2D Texture.
     * This 2D texture is used in PerlinHeight to obtain a height value in a given position, which is used as the height of the building.
     * By doing this, the heights of every building are set according to a 2D Perllin texture map.
     * This function works simiarly to the script in ImaginaryCities by mirrorfishmedia
     */
    void Start()
    {
        // Set the instance of the Perlin noise
        perlinInstance = this;

        // Set the size of the texture to be affected by Perlin noise. This is the size of the grid the city is being generated on
        int xTexture = 130;
        int yTexture = 85;

        // A 2D texture to apply the Perlin noise to for the heights of the buildings
        perlinTexture = new Texture2D(xTexture, yTexture);

        // Generate random Vector2 coordinates to produce a random result for the perlin noise
        Vector2 randomNoise = new Vector2(Random.Range(0, 99999), Random.Range(0, 99999));

        // Nested for loops to iterate through each coordinate
        for (int x = 0; x < xTexture; x++)
        {
            for (int y = 0; y < yTexture; y++)
            {
                // Coordinates to use to obtain the perlin noise value. These coordinates are multiplied by the noiseLevel to decrease/increase the effect of the perlin noise. Randomness is created through the randomNoise
                float xCoord = ((float)x / xTexture) * noiseLevel + randomNoise.x;
                float yCoord = ((float)y / yTexture) * noiseLevel + randomNoise.y;

                // Using Unity's PerlinNoise Math function to obtain a value of perlin noise at the calculated coordinate
                float perlinValue = Mathf.PerlinNoise(xCoord, yCoord);

                // Obtaining a colour value using the calculated perlin noise value
                Color colour = new Color(perlinValue, perlinValue, perlinValue);

                // SetPixel converts the colour at the given coordinate into a texture, which can be added to perlinTexture - creating the Perlin Noise effect
                perlinTexture.SetPixel(x, y, colour);
            }
        }
        // Apply the calculated values to the 2D texture
        perlinTexture.Apply();
    }

    /*
     * PerlinHeight takes a X and Z coordinate which is used against the created perlinTexture on the X and Y axes.
     * The grayscale value of that pixel in that position is obtained and returned to set the height of the building in that position.
     * This float must be between 0.0 and 1.0, as the maximum height a building can be is set and multiplied by this value
     */
    public float PerlinHeight(float xPosition, float zPosition)
    {
        // The grayscale value of the pixel in the position in perlinTexture is obtained and returned to set the height of the buildings
        return perlinTexture.GetPixel(Mathf.FloorToInt(xPosition), Mathf.FloorToInt(zPosition)).grayscale;
    }
}
