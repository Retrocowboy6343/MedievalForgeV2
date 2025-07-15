using System.Collections;
using Unity.VisualScripting;
using UnityEngine;

public class SmeltableItem : MonoBehaviour
{
    //variables
    [SerializeField] private int smeltingTime;
    [SerializeField] private int cooldownTime = 25;
    public bool isWorkable;
    private bool canSmelt;
    public Material coolMaterial;
    public Material hotMaterial;
    private MeshRenderer meshRenderer;

    private void Start()
    {
        meshRenderer = GetComponent<MeshRenderer>();
        meshRenderer.material = coolMaterial;
        isWorkable = false;
        canSmelt = true;
    }
    private void Update()
    {
        if (!canSmelt)
        {
            StopCoroutine(SmeltTimer());
        }
    }

    IEnumerator SmeltTimer()
    {
        yield return new WaitForSeconds(smeltingTime);
        OnSmelt();
        Debug.Log("yeah");
    }
    IEnumerator CooldownTimer()
    {
        yield return new WaitForSeconds(cooldownTime);
        OnCooldown();
    }
    private void OnSmelt()
    {
        if (canSmelt)
        {
            isWorkable = true;
            meshRenderer.material = hotMaterial;
        }
        
    }
    private void OnCooldown()
    {
        isWorkable = false;
        meshRenderer.material = coolMaterial;
    }
    private void OnTriggerEnter(Collider other)
    {
        Debug.Log("Entered trigger");
        if (other.CompareTag("Furnace"))
        {
            canSmelt = true;
            StartCoroutine(SmeltTimer());
            StopCoroutine(CooldownTimer());
        }
        //if (other.gameObject.CompareTag("QBucket"))
        {
            //StopAllCoroutines();
            //OnCooldown();
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Furnace") && !isWorkable)
        {
            StopCoroutine(SmeltTimer());
            Debug.Log("smelting should have stopped");
            canSmelt = false;
        }
        if (other.CompareTag("Furnace") && isWorkable)
        {
            StartCoroutine(CooldownTimer());
            canSmelt = true;
        }
    }
}
