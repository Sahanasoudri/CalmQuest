using UnityEngine;


public class Coin : MonoBehaviour
{
    
    [SerializeField]
    
    private AudioSource coinFX; 
  
    void OnTriggerEnter(Collider other)
    {
       
        coinFX.Play();
        Master.coinCount += 1;
        
        
        this.gameObject.SetActive(false); 
    }
}