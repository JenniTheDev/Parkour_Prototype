using UnityEngine;

public class KillZone : MonoBehaviour {
    [SerializeField] private LayerMask killLayers;
   


    private void OnTriggerEnter(Collider other) {
        if ((killLayers & (1 << other.gameObject.layer)) != 0) {
            IKillZoneResetable itemToReset = other.gameObject.GetComponent<IKillZoneResetable>();
            if (itemToReset != null) {
                itemToReset.KillZoneReset();
            }
        }
    
        
    }




}
