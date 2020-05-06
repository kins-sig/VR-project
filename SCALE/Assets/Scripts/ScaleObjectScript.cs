using System.Collections;
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
		if (Input.GetKeyDown(KeyCode.E))
		{
            Pickup();
		}
		if (Input.GetKeyUp(KeyCode.E))
		{
            Drop(); 
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

    void Pickup()
	{
        item.GetComponent<Rigidbody>().useGravity = false;
        item.GetComponent<Rigidbody>().isKinematic = true;
        item.transform.rotation = guide.transform.rotation;
        item.transform.position = guide.transform.position;
        item.transform.parent = tempParent.transform;

    }
    void Drop()
    {
        item.GetComponent<Rigidbody>().useGravity = true;
        item.GetComponent<Rigidbody>().isKinematic = false;
        item.transform.parent = null; 
        item.transform.position = guide.transform.position;

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
