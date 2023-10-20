// using System.Collections;
// using System.Collections.Generic;
// using UnityEngine;
// using UnityEngine.SceneManagement;

// public class GrassManager : MonoBehaviour
// {
//     public GameObject grassPrefab;
//     public int planeWidth = 110; 
//     public int planeHeight = 30;
//     public int grassSpread = 10;

//     private Dictionary<Vector2, GameObject> grassTiles;
//     private int playerX = 90;
//     private int playerY = 90;
//     private Queue<GameObject> grassPool;

//     void Start()
//     {
//         grassTiles = new Dictionary<Vector2, GameObject>();
//         grassPool = new Queue<GameObject>();

//         GeneratePlane();
//         UpdateGrass();
//     }

//     void GeneratePlane()
//     {
//         for (int i = 0; i < planeWidth; i++)
//         {
//             for (int j = 0; j < planeHeight; j++)
//             {
//                 Vector2 pos = new Vector2(i, j);
//                 grassTiles.Add(pos, null);
//             }
//         }
//     }

//     GameObject GetGrassFromPool()
//     {
//         if (grassPool.Count > 0)
//         {
//             GameObject grass = grassPool.Dequeue();
//             grass.SetActive(true);
//             return grass;
//         }
//         else
//         {
//             GameObject grass = Instantiate(grassPrefab);
//             return grass;
//         }
//     }

//     void ReturnGrassToPool(GameObject grass)
//     {
//         grass.SetActive(false);
//         grassPool.Enqueue(grass);
//     }

// void UpdateGrass()
// {
//     List<Vector2> grassToRemove = new List<Vector2>();

//     foreach (var kvp in grassTiles)
//     {
//         Vector2 pos = kvp.Key;
//         if (Mathf.Abs(pos.x - playerX) > grassSpread || Mathf.Abs(pos.y - playerY) > grassSpread)
//         {
//             if (grassTiles[pos] != null)
//             {
//                 ReturnGrassToPool(grassTiles[pos]);
//                 grassToRemove.Add(pos);
//             }
//         }
//     }

//     foreach (var pos in grassToRemove)
//     {
//         grassTiles.Remove(pos);
//     }

//     for (int i = Mathf.Max(0, playerX - grassSpread); i <= Mathf.Min(planeWidth - 1, playerX + grassSpread); i++)
//     {
//         for (int j = Mathf.Max(0, playerY - grassSpread); j <= Mathf.Min(planeHeight - 1, playerY + grassSpread); j++)
//         {
//             Vector2 pos = new Vector2(i, j);
//             if (!grassTiles.ContainsKey(pos) || grassTiles[pos] == null)
//             {
//                 GameObject grass = GetGrassFromPool();
//                 grass.transform.position = new Vector3(i, grassPrefab.transform.position.y, j);
//                 grassTiles[pos] = grass;
//             }
//         }
//     }
// }



//  public void PlayerMove(float newX, float newY)
// {
//     playerX = Mathf.RoundToInt(newX);
//     playerY = Mathf.RoundToInt(newY);
//     UpdateGrass();
// }

// }
