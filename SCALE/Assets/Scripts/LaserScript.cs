using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LaserScript : MonoBehaviour
{

    LineRenderer scaleUpLine; 
    LineRenderer scaleDownLine; 


    // Start is called before the first frame update
    void Start()
    {
        scaleUpLine = GameObject.FindWithTag("ScaleUp").GetComponent<LineRenderer>();
        scaleUpLine.enabled = false; 
        scaleDownLine = GameObject.FindWithTag("ScaleDown").GetComponent<LineRenderer>();
        scaleDownLine.enabled = false; 
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetButtonDown("Fire1"))
        {
            StopCoroutine("FireLaserUp");
            StartCoroutine("FireLaserUp");
        }
            
        if (Input.GetButtonDown("Fire2"))
        {
            StopCoroutine("FireLaserDown");
            StartCoroutine("FireLaserDown");
        }
    }

    IEnumerator FireLaserUp()
	{
        scaleUpLine.enabled = true;
		while (Input.GetButton("Fire1"))
		{
            Ray ray = new Ray(transform.position, transform.forward);
            RaycastHit hit;
            scaleUpLine.SetPosition(0, ray.origin);

            if(Physics.Raycast(ray, out hit,100))
			{
                scaleUpLine.SetPosition(1, hit.point);
                if(hit.collider.CompareTag("Scaleable")){
                    Debug.Log("We hit a player!");

                }

            }
			else 
                scaleUpLine.SetPosition(1, ray.GetPoint(100));
            

            yield return null;
		}
        scaleUpLine.enabled = false; 
	}

    IEnumerator FireLaserDown()
	{
        scaleDownLine.enabled = true;
		while (Input.GetButton("Fire2"))
		{
            Ray ray = new Ray(transform.position, transform.forward);
            RaycastHit hit;
            scaleDownLine.SetPosition(0, ray.origin);

            if(Physics.Raycast(ray, out hit,100))
			{
                if(hit.collider.name == "companion cube"){
                    Debug.Log("BAM");
                }
                scaleDownLine.SetPosition(1, hit.point);
                if(hit.collider.CompareTag("Scaleable")){
                    Debug.Log("We hit a player!");

                }

            }
			else 
                scaleDownLine.SetPosition(1, ray.GetPoint(100));
            
            if(hit.collider.CompareTag("Scaleable")){
                Debug.Log("BAM");
            }

            yield return null;
		}
        scaleDownLine.enabled = false; 
	}
    void OnCollisionEnter(Collision other){
        if(other.gameObject.CompareTag ("Scalable")){
            Debug.Log("HI");
        }
    }
    // void UpScale(Vector3 scale) {
 
    //      scale += new Vector3(0.1f,0.1f,0.1f);
    //      a.transform.localScale = scale;
    //  }
    //  void DownScale(Vector3 scale)
    //  {
    //      scale -= new Vector3(0.1f, 0.1f, 0.1f);
    //      a.transform.localScale = scale;
    //  }
}
