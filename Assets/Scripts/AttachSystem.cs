using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit.Interactables;
using UnityEngine.XR.Interaction.Toolkit.Transformers;

public class AttachSystem : MonoBehaviour
{
    public Transform hiltAttachpoint;

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Blade"))
        {
            other.GetComponent<XRGrabInteractable>().enabled = false;
            other.GetComponent<Rigidbody>().Sleep();
            other.GetComponent<Rigidbody>().isKinematic = true;
            other.GetComponent<BoxCollider>().enabled = false;
            other.GetComponent<XRBaseGrabTransformer>().enabled = false;
            other.gameObject.transform.position = hiltAttachpoint.position;
            other.gameObject.transform.parent = transform;
            other.gameObject.transform.rotation = Quaternion.identity;
        }
    }
}