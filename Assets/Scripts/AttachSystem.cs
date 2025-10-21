using Unity.Mathematics;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit.Interactables;
using UnityEngine.XR.Interaction.Toolkit.Transformers;

public class AttachSystem : MonoBehaviour
{
    //Variables
    public Transform hiltAttachpoint;
    public int dettachVelocity;
    public GetHammerSpeed getHammerSpeed;
    bool hasAttachment;
    public GameObject attachedObject;
    public bool canAttach;



    private void Start()
    {
        getHammerSpeed = FindFirstObjectByType<GetHammerSpeed>();
        hasAttachment = false;
        canAttach = false;
    }

    private void OnTriggerEnter(Collider other)
    {

        //If overlapping object has the "Blade" Tag, and the hasAttachment variable is not true
        if (other.gameObject.CompareTag("Blade") && !hasAttachment)
        {
            //Set canAttach to the isCool variable from the overlapping objects SwordQuench Script.
            canAttach = other.GetComponent<SwordQuench>().isCool;
            if (canAttach)
            {
                //Disable any components on object that cause glitches when parenting is changed
                other.GetComponent<Collider>().enabled = false;
                other.GetComponent<XRGrabInteractable>().enabled = false;
                other.GetComponent<Rigidbody>().isKinematic = true;
                other.gameObject.transform.position = hiltAttachpoint.position;
                other.gameObject.transform.parent = transform;
                other.gameObject.transform.localEulerAngles = new Vector3(0, 0, 0);
                hasAttachment = true;
                gameObject.transform.localRotation = Quaternion.identity;
            }
        }
        //CODE DOESNT WORK CURRENTLY
        if (other.gameObject.CompareTag("Hammer") && getHammerSpeed.hammerYVelocity > dettachVelocity)
        {
            transform.SetParent(null);
            other.GetComponent<BoxCollider>().enabled = true;

        }
    }
}