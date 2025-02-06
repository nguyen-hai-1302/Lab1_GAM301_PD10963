using System.Collections;
using UnityEngine;

public class Cube : MonoBehaviour
{    
    private Material material;

    void Start()
    {
        material = GetComponent<Renderer>().material;        
    }

    void Update()
    {
        //if (Input.GetKeyDown(KeyCode.Space))
        //{
        //    StartCoroutine(Transparent());
        //    Debug.Log("Space");
        //}
        if(transform.position == Vector3.zero)
        {
            StartCoroutine(Transparent());
        }
        
    }
   
    IEnumerator Transparent()
    {
        Color colorA = material.color;
        float elapsedTime = 0f;

        while (elapsedTime < 5f)
        {
            elapsedTime += Time.deltaTime;
            float Alpha = Mathf.Lerp(colorA.a, 0f, elapsedTime / 5f);
            material.color = new Color(colorA.r, colorA.g, colorA.b, Alpha);
            yield return null;
        }
        material.color = new Color(colorA.r, colorA.g, colorA.b, 0f);
        if (material.color.a <= 0f)
        {
            Destroy(gameObject);
        }
        
    }
    
}
