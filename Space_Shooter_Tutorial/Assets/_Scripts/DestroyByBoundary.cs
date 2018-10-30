using UnityEngine;
using UnityEngine.UI;

public class DestroyByBoundary : MonoBehaviour

{

        void OnTriggerExit(Collider other)
    {
        Destroy(other.gameObject);
    }
}
