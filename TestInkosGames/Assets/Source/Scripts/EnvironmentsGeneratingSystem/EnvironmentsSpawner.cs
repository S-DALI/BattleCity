using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnvironmentsSpawner : MonoBehaviour
{
    [SerializeField] private GameObject[] wallsPrefab;
    [SerializeField] private int width = 45;
    [SerializeField] private int height = 20;

    private void Start()
    {
       WallCreator creator = new WallCreator();
       EnvironmentsCell[,] environments = creator.Create(width, height);
       for (int x = 1; x < environments.GetLength(0) - 1; x++)
       {
           for (int y = 1; y < environments.GetLength(1) - 1; y++)
           {
              Environment environment = Instantiate(wallsPrefab[Random.Range(0,wallsPrefab.Length)],new Vector2(x,y),Quaternion.identity).GetComponent<Environment>();
                
                environment.wallLeft.SetActive(environments[x, y].isWallLeftCreated);
                environment.wallBack.SetActive(environments[x, y].isWallBackCreated);
            }
       }
    }
}
