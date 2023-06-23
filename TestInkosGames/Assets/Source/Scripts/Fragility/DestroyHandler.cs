using UnityEngine;


public abstract class DestroyHandler : MonoBehaviour
{
    public abstract void HandleDestroy();

    public System.Action ObjectDestroy;

}

