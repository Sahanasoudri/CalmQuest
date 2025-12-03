using UnityEngine;
// Note: Additional 'using' statements might be required for the Text component.

public class Master : MonoBehaviour
{
    // Variable for Coin Count (Introduced in Tutorial 12)
    // Declared as public static int so that the CollectCoin script can interact directly with it.
    public static int coinCount = 0; // Initialized to zero [4]

    // Variable for the Text Box (Introduced in Tutorial 12)
    [SerializeField]
    // Serialized field allows the private variable to be linked in the Inspector panel.
    private GameObject coinDisplay; // Holds the reference to the UI text box [3, 4]

    // Note: The annotations and the 'Start' method are removed as they are not needed [4].

    void Update() // Runs every single frame
    {
        // Updates the text display to show the current coin count [3]
        // This is done in the quickest, easiest, and crudest way for simple display [3].
        
        // 1. Get the Text Component from the coinDisplay Game Object
        // 2. Access the '.text' property
        // 3. Set the text to the string "coins " concatenated with the current coinCount value
        coinDisplay.GetComponent<TMPro.TextMeshProUGUI>().text = "coins " + coinCount; 
    }
}