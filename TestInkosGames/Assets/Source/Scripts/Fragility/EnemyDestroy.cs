using EnemyWave;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyDestroy : DestroyHandler
{
    public override void HandleDestroy()
    {
        ObjectDestroy?.Invoke();
        WaveSystem.Instance.EnemyDead();
        Destroy(gameObject);
    }
}
