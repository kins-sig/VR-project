using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LaserScript : MonoBehaviour
{

    LineRenderer scaleUpLine; 
    LineRenderer scaleDownLine; 
    AudioSource audio; 


    // Start is called before the first frame update
    void Start()
    {
        scaleUpLine = GameObject.FindWithTag("ScaleUp").GetComponent<LineRenderer>();
        scaleUpLine.enabled = false; 
        scaleDownLine = GameObject.FindWithTag("ScaleDown").GetComponent<LineRenderer>();
        scaleDownLine.enabled = false; 
        audio = GetComponent<AudioSource>();
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
        audio.Play();
		while (Input.GetButton("Fire1"))
		{
            Ray ray = new Ray(transform.position, transform.forward);
            RaycastHit hit;
            scaleUpLine.SetPosition(0, ray.origin);

            if(Physics.Raycast(ray, out hit,100))
			{
                scaleUpLine.SetPosition(1, hit.point);
                if(hit.collider.CompareTag("Scalable")){
                    Debug.Log("We hit a player!");
                    hit.collider.gameObject.GetComponent<ScaleObjectScript>().UpScale(); 

                }

            }
			else 
                scaleUpLine.SetPosition(1, ray.GetPoint(100));
            

            yield return null;
		}
        scaleUpLine.enabled = false; 
        audio.Stop();
	}

    IEnumerator FireLaserDown()
	{
        scaleDownLine.enabled = true;
        audio.Play();
		while (Input.GetButton("Fire2"))
		{
            Ray ray = new Ray(transform.position, transform.forward);
            RaycastHit hit;
            scaleDownLine.SetPosition(0, ray.origin);

            if(Physics.Raycast(ray, out hit,100))
			{
                if(hit.collider.tag == "Scalable"){
                        Debug.Log("BAM");
                    hit.collider.gameObject.GetComponent<ScaleObjectScript>().DownScale();
                }
                scaleDownLine.SetPosition(1, hit.point);
            }
			else 
                scaleDownLine.SetPosition(1, ray.GetPoint(100));

            yield return null;
		}
        scaleDownLine.enabled = false; 
        audio.Stop(); 
	}

}
