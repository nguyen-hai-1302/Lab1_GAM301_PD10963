using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class GameManager : MonoBehaviour
{
    public GameObject cube;
    public List<GameObject> cubes = new List<GameObject>();
    

    void Start()
    {
        StartCoroutine(Spawn());
    }

    void Update()
    {        
        
    }

    IEnumerator Spawn()
    {
        for (int i = 0; i < 10; i++)
        {
            yield return new WaitForSeconds(2f);
            Vector3 randomPosition = new Vector3(Random.Range(0f, 5f), Random.Range(0f, 5f), Random.Range(0f, 5f));
            GameObject cubeClone = Instantiate(cube, randomPosition, Quaternion.identity);
            cubes.Add(cubeClone);            
        }

        foreach (GameObject cubeClone in cubes)
        {
            StartCoroutine(Move(cubeClone));
            yield return new WaitForSeconds(5f);
        }        
    }   
    IEnumerator Move(GameObject cubeClone)
    {
        float elapsedTime = 0f;
        while (elapsedTime < 5f)
        {
            cubeClone.transform.position = Vector3.Lerp(cubeClone.transform.position, Vector3.zero, elapsedTime / 5f);
            elapsedTime += Time.deltaTime;
            yield return null;
        }
    }
    
}
