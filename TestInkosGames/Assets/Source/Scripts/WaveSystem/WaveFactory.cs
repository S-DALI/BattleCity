using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace EnemyWave
{
    public class WaveFactory 
    {
        private EnemyFactory enemyFactory;
        public WaveFactory(EnemyFactory enemyFactory)
        {
            this.enemyFactory = enemyFactory;
        }

        public void CreateWave(WaveData data,SpawnSettings position)
        {
            foreach (EnemySettings enemyToSpawn in data.Enemies)
            {
                enemyFactory.CreateEnemy(enemyToSpawn.Enemy,position.RandomSpawner());
            }
        }
    }
}
