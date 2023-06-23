using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstacleDestroy : DestroyHandler
{
    public override void HandleDestroy()
    {
        Destroy(gameObject);
    }
}
