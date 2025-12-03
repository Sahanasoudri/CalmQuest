using UnityEngine;
using System.Collections;

public class CollisionDetect : MonoBehaviour
{
   

    [SerializeField]
    GameObject thePlayer; 

    [SerializeField]
    GameObject playerAnim; // 
    [SerializeField]
    AudioSource Collision; 

    [SerializeField]
    GameObject mainCam; 

    [SerializeField]
    GameObject FadeOut; 

   
    void OnTriggerEnter(Collider other)
    {
        
        StartCoroutine(CollisionEnd()); 
    }

    
    IEnumerator CollisionEnd() 
    {
        // 1. Play Collision Sound
        Collision.Play(); 

        // 2. Stop Player Movement
        thePlayer.GetComponent<PlayerMovement>().enabled = false; 

        // 3. Play Stumble Animation
        playerAnim.GetComponent<Animator>().Play("Stumble Backwards"); 

        // 4. Play Camera Shake Animation
        mainCam.GetComponent<Animator>().Play("collisionCam"); 

        // 5. Wait for 3 seconds (Crucial timing element)
        yield return new WaitForSeconds(3f); 

        // 6. Activate Fade Out Screen (Transition to black)
        FadeOut.SetActive(true); 
    }
}