using UnityEngine;
using System.Collections; // Still needed to use the IEnumerator/Co-routine function

public class SegmentGenerator : MonoBehaviour
{
    // Variables for Control and Generation (New/Modified in Tutorial 9)

    [SerializeField] 
    // This allows the private variable to be visible in the Inspector panel.
    private int zPos = 50;  // Z position, initialized to 50 for the first segment

    [SerializeField]
    private bool creatingSegment = false; // Flag to prevent multiple segments from being generated simultaneously (False by default)

    private int segmentNum; // Variable to hold the random index (0, 1, or 2) for the segment array

    // Segment Array (Modified in Tutorial 9)
    // Square brackets [] denote an array, allowing multiple game objects to be stored in one variable.
    public GameObject[] segment; // Holds the segments linked in the Inspector (Elements 0, 1, 2)

    // Note: The previous individual variables (segmentMap01, etc.) are removed.


    // The method is changed from void Start() to void Update() (Modified in Tutorial 9)
    void Update() // Runs every single frame
    {
        // Control Logic (Introduced in Tutorial 9)
        // Checks if a segment is currently NOT being created.
        if (creatingSegment == false)
        {
            // If false, immediately set it to true to prevent the loop from running again this frame.
            creatingSegment = true; 
            
            // Start the Segment Generation Co-routine.
            StartCoroutine(SegmentGen());
        }
    }

    // Co-routine method for Segment Generation (Heavily modified in Tutorial 9)
    IEnumerator SegmentGen()
    {
        // 1. Generate a Random Segment Index (Introduced in Tutorial 9)
        // Generates a random integer between the lowest (0) and the highest possible (3, which only returns 0, 1, or 2).
        segmentNum = Random.Range(0, 3); 

        // 2. Instantiate (Duplicate and Place) the Segment (Introduced in Tutorial 9)
        Instantiate(segment[segmentNum], new Vector3(0, 0, zPos), Quaternion.identity);

        // Explanation of Instantiate arguments:
        // * segment[segmentNum]: Selects the game object from the array (0, 1, or 2).
        // * new Vector3(0, 0, zPos): Sets the position (X=0, Y=0, Z=zPos, e.g., 50, 100, 150...).
        // * Quaternion.identity: Ensures the segment is placed without rotational changes.

        // 3. Update the Z Position for the Next Segment (Introduced in Tutorial 9)
        zPos += 50; // Increases the Z position by 50 (the length of one segment).

        // 4. Wait Period (Modified in Tutorial 9)
        // Waits for 3 seconds before proceeding (reduced from 10 seconds).
        yield return new WaitForSeconds(3);

        // 5. Reset the Control Flag (Introduced in Tutorial 9)
        // Sets the boolean back to false, allowing the 'if' statement in Update() to run again, creating an infinite loop.
        creatingSegment = false; 
    }
}