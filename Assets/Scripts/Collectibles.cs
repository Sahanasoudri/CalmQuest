using UnityEngine; 

public class CollectibleRotate : MonoBehaviour
{
    
    [SerializeField]
    private int rotateSpeed = 1; 


    
    void Update() 
    {
        
        transform.Rotate(0, rotateSpeed, 0, Space.World);

        
        
    }
}