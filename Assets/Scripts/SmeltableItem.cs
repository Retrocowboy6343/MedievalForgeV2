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
        //set variables
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
    //IEnumerators which wait for a specified amount of time before running a method
    IEnumerator SmeltTimer()
    {
        //wait {smeltingTime} then activate OnSmelt();
        yield return new WaitForSeconds(smeltingTime);
        OnSmelt();
        
    }
    IEnumerator CooldownTimer()
    {
        //wait {smeltingTime} then activate Cooldown();
        yield return new WaitForSeconds(cooldownTime);
        OnCooldown();
    }
    private void OnSmelt()
    {
        if (canSmelt)
        {
            //if canSmelt is true, set isWorkable to true and set the meshrenderer's matieral to hotMaterial
            isWorkable = true;
            meshRenderer.material = hotMaterial;
        }
        
    }
    private void OnCooldown()
    {
        //set isWorkable to false and change meshrenderer's material to coolmaterial
        isWorkable = false;
        meshRenderer.material = coolMaterial;
    }
    private void OnTriggerEnter(Collider other)
    {
        
        if (other.CompareTag("Furnace"))
        {
            //if the object has the "Furnace" tag, then start SmeltTimer() couroutine and stop CooldownTimer if its running.
            canSmelt = true;
            StartCoroutine(SmeltTimer());
            StopCoroutine(CooldownTimer());
        }
        
    }
    private void OnTriggerExit(Collider other)
    {
        //if the ingot leaves the furnace prematurely, cancel smelt
        if (other.CompareTag("Furnace") && !isWorkable)
        {
            StopCoroutine(SmeltTimer());
            canSmelt = false;
        }
        //if ingot leaves furnace after being smelted, start CooldownTimer
        if (other.CompareTag("Furnace") && isWorkable)
        {
            StartCoroutine(CooldownTimer());
            canSmelt = true;
        }
    }
}
