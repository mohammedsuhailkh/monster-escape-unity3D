// using System.Collections;
// using System.Collections.Generic;
// using UnityEngine;

// public class enemySpawner : MonoBehaviour
// {

//     [SerializeField] private GameObject[] monsterReference;
//     [SerializeField] private Transform leftPos, rightPos;
//     private int randomIndex;
//     private int randomside;
//     private GameObject spawnedMonsters;

//     // Start is called before the first frame update
//     void Start()
//     {
//         StartCoroutine(SpawnedMonsters());
//     }

//     // Update is called once per frame
//     IEnumerator SpawnedMonsters()
//     {
//         while (true)
//         {
//             yield return new WaitForSeconds(Random.Range(1, 5));
//             randomIndex = Random.Range(0, monsterReference.Length);
            
            
//             randomside = Random.Range(0, 2);

//             spawnedMonsters = Instantiate(monsterReference[randomIndex]);

//             if (randomside == 0)
//             {
//                 spawnedMonsters.transform.position = new Vector3(leftPos.position.x, leftPos.position.y);
//                 spawnedMonsters.GetComponent<monsters>().speed = Random.Range(5, 10);

//                 // spawnedMonsters.transform.localScale = new Vector3(1f, 1f, 1f);
//             }
//             else
//             {
//                 spawnedMonsters.transform.position = new Vector3(rightPos.position.x, rightPos.position.y);
//                 spawnedMonsters.GetComponent<monsters>().speed = -Random.Range(5, 10);
//                 spawnedMonsters.transform.rotation = Quaternion.Euler(0, -100, 0);

//                 // spawnedMonsters.transform.localScale = new Vector3(-1f, 1f, 1f);
//             }
//         }
//     }
// }


using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemySpawner : MonoBehaviour
{
    [SerializeField] private GameObject[] monsterReference;
    [SerializeField] private Transform leftPos, rightPos;
    private int randomIndex;
    private int randomside;
    private GameObject spawnedMonsters;

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(SpawnedMonsters());
    }

    // Update is called once per frame
    IEnumerator SpawnedMonsters()
    {
        while (true)
        {
            yield return new WaitForSeconds(Random.Range(4, 7));
            randomIndex = Random.Range(0, monsterReference.Length);

            randomside = Random.Range(0, 2);

            spawnedMonsters = Instantiate(monsterReference[randomIndex]);

            if (randomside == 0)
            {
                spawnedMonsters.transform.position = new Vector3(leftPos.position.x, leftPos.position.y);
                spawnedMonsters.GetComponent<monsters>().speed = Random.Range(5, 10);
                spawnedMonsters.transform.rotation = Quaternion.Euler(0, 100, 0);
               
            }
            else
           {
                spawnedMonsters.transform.position = new Vector3(rightPos.position.x, rightPos.position.y);
                spawnedMonsters.GetComponent<monsters>().speed = -Random.Range(5, 10);
                spawnedMonsters.transform.rotation = Quaternion.Euler(0, -100, 0);
            }
        }
    }
}
