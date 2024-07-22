using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FacingCamera : MonoBehaviour
{
    Transform[] children;

    // Start is called before the first frame update
    void Start()
    {
        // Get all the children of the parent object
        children = new Transform[transform.childCount];
        for (int i = 0; i < transform.childCount; i++)
        {
            children[i] = transform.GetChild(i);
        }

    }

    // Update is called once per frame
    void Update()
    {
        for (int i = 0; i < children.Length; i++)
        {
            // Set the rotation of each child object to be the same as the parent object
            children[i].rotation = Camera.main.transform.rotation;
        }
    }
}
