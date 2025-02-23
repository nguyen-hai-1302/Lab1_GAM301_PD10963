using UnityEngine;
using System.Collections;
using TMPro;

public class GUIManager : MonoBehaviour
{
    private float updateCount = 0;
    private float fixedUpdateCount = 0;
    private float updateUpdateCountPerSecond;
    private float updateFixedUpdateCountPerSecond;
    public TextMeshProUGUI MS;
    public TextMeshProUGUI FPS;

    void Awake()
    {
        // Uncommenting this will cause framerate to drop to 10 frames per second.
        // This will mean that FixedUpdate is called more often than Update.
        Application.targetFrameRate = 100;
        StartCoroutine(Loop());
    }

    // Increase the number of calls to Update.
    void Update()
    {
        updateCount += 1;
    }

    // Increase the number of calls to FixedUpdate.
    void FixedUpdate()
    {
        fixedUpdateCount += 1;
    }

    // Show the number of calls to both messages.
    void OnGUI()
    {
        //GUIStyle fontSize = new GUIStyle(GUI.skin.GetStyle("label"));
        //fontSize.fontSize = 24;
        //GUI.Label(new Rect(100, 100, 200, 50), "MS: " + updateUpdateCountPerSecond.ToString(), fontSize);
        //GUI.Label(new Rect(100, 150, 200, 50), "FPS: " + updateFixedUpdateCountPerSecond.ToString(), fontSize);
        MS.text = "UC: " + updateUpdateCountPerSecond.ToString();
        FPS.text = "FUC: " + updateFixedUpdateCountPerSecond.ToString();
    }

    // Update both CountsPerSecond values every second.
    IEnumerator Loop()
    {
        while (true)
        {
            yield return new WaitForSeconds(1);
            updateUpdateCountPerSecond = updateCount;
            updateFixedUpdateCountPerSecond = fixedUpdateCount;

            updateCount = 0;
            fixedUpdateCount = 0;
        }
    }

}
