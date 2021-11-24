using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Timer : MonoBehaviour
{
    public float time = 0f;
    public Text text;

    // Update is called once per frame
    void Update()
    {
        time += Time.deltaTime;
        text.text = Mathf.Floor(time).ToString();
    }
    public void StartOver()
    {
        time = 0f;
    }
}
