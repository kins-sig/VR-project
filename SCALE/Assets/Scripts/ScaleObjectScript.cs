﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScaleObjectScript : MonoBehaviour
{
    //public GameObject scalableObject;
    public GameObject item;
    public GameObject tempParent;
    public Transform guide;

    float minScaleFactor = 0.25f;
    float maxScaleFactor = 2.0f;

    // Start is called before the first frame update
    void Start()
    {
        item.GetComponent<Rigidbody>().useGravity = true;

    }

    // Update is called once per frame
    void Update()
    {
        var ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit; 
        if(Physics.Raycast(ray, out hit)){
            var selection = hit.transform;
			if (selection.CompareTag("Scalable"))
			{
                if (Input.GetKeyDown(KeyCode.E))
                {
                    Pickup(hit);
                }
                if (Input.GetKeyUp(KeyCode.E))
                {
                    Drop(hit);
                }
            }
		}
    }

    void OnCollisionEnter(Collision other)
	{
		if (other.gameObject.CompareTag("Button"))
		{
            Debug.Log("Button pressed");
            GetComponent<Rigidbody>().isKinematic = true; 
		}
	}

    void Pickup(RaycastHit hit)
	{
        hit.transform.gameObject.GetComponent<Rigidbody>().useGravity = false;
        hit.transform.gameObject.GetComponent<Rigidbody>().isKinematic = true;
        hit.transform.gameObject.transform.rotation = guide.transform.rotation;
        hit.transform.gameObject.transform.position = guide.transform.position;
        hit.transform.gameObject.transform.parent = tempParent.transform;

    }
    void Drop(RaycastHit hit)
    {
        hit.transform.gameObject.GetComponent<Rigidbody>().useGravity = true;
        hit.transform.gameObject.GetComponent<Rigidbody>().isKinematic = false;
        hit.transform.gameObject.transform.parent = null; 
        hit.transform.gameObject.transform.position = guide.transform.position;

    }


    public void UpScale()
    {
        var scale = gameObject.transform.localScale;
        if (scale.y < maxScaleFactor){
            scale += new Vector3(0.01f, 0.01f, 0.01f);
            gameObject.transform.localScale = scale;
        }
    }
    public void DownScale()
    {
        var scale = gameObject.transform.localScale;
        if (scale.y > minScaleFactor)
        {
            scale -= new Vector3(0.01f, 0.01f, 0.01f);
            gameObject.transform.localScale = scale;
        }
    }
}
