using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Test : MonoBehaviour
{
    // Start is called before the first frame update
    public int count = 5;
    float rad = 0.35f;
    public GameObject ggo,parent;
    void Start()
    {
        float step = 360 / count;
        Debug.Log("step: " + step);
        for(int i = 0; i < count; i++)
        {
            float theta = i * step;
            float x = rad * (Mathf.Cos(theta * Mathf.Deg2Rad));
            float y = rad * (Mathf.Sin(theta * Mathf.Deg2Rad));
            GameObject g = Instantiate(ggo,parent.transform);
            g.transform.localPosition = new Vector3(x, y, 0);
            g.SetActive(true);
            Debug.Log("x: " + x + " -- y: " + y + " -- theta: " + theta);
        }
    }
}
