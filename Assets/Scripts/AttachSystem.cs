using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit.Interactables;
using UnityEngine.XR.Interaction.Toolkit.Transformers;

public class AttachSystem : MonoBehaviour
{
    public Transform hiltAttachpoint;
    public int dettachVelocity;
    public GetHammerSpeed getHammerSpeed;



    private void Start()
    {
        getHammerSpeed = FindFirstObjectByType<GetHammerSpeed>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Blade"))
        {
            //other.GetComponent<XRGrabInteractable>().enabled = false;
            //other.GetComponent<Rigidbody>().Sleep();
            other.GetComponent<Rigidbody>().isKinematic = true;
            other.GetComponent<BoxCollider>().enabled = false;
            //other.GetComponent<XRBaseGrabTransformer>().enabled = false;
            other.gameObject.transform.position = hiltAttachpoint.position;
            other.gameObject.transform.parent = transform;
            other.gameObject.transform.localEulerAngles = new Vector3(90, 0, 0);
        }
        if (other.gameObject.CompareTag("Hammer") && getHammerSpeed.hammerYVelocity > dettachVelocity)
        {
            transform.SetParent(null);
            other.GetComponent<BoxCollider>().enabled = true;

        }
    }
}