using UnityEngine;

public class SwordQuench : MonoBehaviour
{

    //variables
    public Material coolMaterial;
    public Material hotMaterial;
    [SerializeField] private int cooldownTime;
    

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnObjectSpawn()
    {
        
    }

    IEnumerator CooldownTimer()
    {
        yield return new WaitForSeconds(cooldownTime);
        OnCooldown();
    }
    private void OnCooldown()
    {
        meshRenderer.material = coolMaterial;
    }
}
