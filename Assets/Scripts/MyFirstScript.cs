using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MyFirstScript : MonoBehaviour
{

    public float speed;

    // Start is called before the first frame update
    void Start()
    {
        print("start test");
    }

    // Update is called once per frame
    void Update()
    {
        print(speed);
    }

    void OnDestroy()
    {
        print("end test");
    }
}
