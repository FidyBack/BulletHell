using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SizeAndCamera : MonoBehaviour {

    public Vector3 screenBounds() {
        Camera MainCamera = GameObject.FindGameObjectWithTag("MainCamera").GetComponent<Camera>();
        return MainCamera.ScreenToWorldPoint(new Vector3(Screen.width, Screen.height, MainCamera.transform.position.z));
    }

    public Vector3 objectSize() {
        return new Vector3(gameObject.GetComponent<SpriteRenderer>().bounds.extents.x, gameObject.GetComponent<SpriteRenderer>().bounds.extents.y); //extents.x = width / 2, extents.y = height / 2 
    }
}

