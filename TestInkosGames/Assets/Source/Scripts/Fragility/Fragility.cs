using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fragility : MonoBehaviour
{
    [SerializeField] private int maxStrength;
    protected int currentStrength;
    private DestroyHandler destroyHandler;
    private void Start()
    {
        currentStrength = maxStrength;
        destroyHandler = GetComponent<DestroyHandler>();
        if (destroyHandler == null)
        {
            Debug.LogError("Fragility can`t work without DestroyHandler component");
        }
    }

    public virtual void takeDamage(int damage)
    {
        currentStrength -= damage;
        if(currentStrength <= 0)
            objectDestroy();
    }
    public virtual void objectDestroy()
    {
        destroyHandler.HandleDestroy();
    }
}
