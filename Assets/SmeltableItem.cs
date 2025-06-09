using System.Collections;
using UnityEngine;

public class SmeltableItem : MonoBehaviour
{
    //variables
    [SerializeField] private int timeToSmelt;
    private bool isSmelted;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    IEnumerator SmeltTimer()
    {
        yield return new WaitForSeconds(timeToSmelt);
        OnSmelt();
    }
    private void OnSmelt()
    {
        isSmelted = true;
    }
}
