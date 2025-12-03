using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public int playerScore = 0;
public int mistakes = 0;

    public float playerSpeed = 2;
    public float horizontalSpeed = 3;

    
    public float rightLimit = 5.5F;
    public float leftLimit = -5.5F;


    
    void Update()
    {
        
        transform.Translate(Vector3.forward * playerSpeed * Time.deltaTime, Space.World);


        
        if (Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.LeftArrow))
        {
            
            if (this.gameObject.transform.position.x > leftLimit)
            {
                
                transform.Translate(Vector3.left * horizontalSpeed * Time.deltaTime);
            }
        }


        if (Input.GetKey(KeyCode.D) || Input.GetKey(KeyCode.RightArrow))
        {
            
            if (this.gameObject.transform.position.x < rightLimit)
            {
                
                transform.Translate(Vector3.left * horizontalSpeed * Time.deltaTime * -1);
            }
        }
    }
}