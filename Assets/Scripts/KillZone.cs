using UnityEngine;

public class KillZone : MonoBehaviour {
    [SerializeField] private LayerMask killLayers;
   [SerializeField] private LayerMask player;


    private void OnTriggerEnter(Collider other) {
        if ((killLayers & (1 << other.gameObject.layer)) != 0) {
            other.gameObject.SetActive(false);
        }
    
        
    }




}
