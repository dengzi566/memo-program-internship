using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class planetroll : MonoBehaviour
{
    public RectTransform rectTransform;
    public float speed = 1.0f;
    public float xMin = 0.0f;
    public float xMax = 1.781f;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        float x = Mathf.Repeat(Time.time * speed, xMax - xMin) + xMin;
        if (x >= xMax - 0.01f)
        {
            x = xMin;
        }
        Vector3 pos = rectTransform.localPosition;
        pos.x = x-0.864f;
        rectTransform.localPosition = pos;

    }
}
