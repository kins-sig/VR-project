using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OpenDoor : MonoBehaviour {

    public Animator _animatorLD = null; //animator for left door
    public Animator _animatorRD = null; //animator for right door
    // public GameObject OpenPanel =null; //GameObject for showing panel with text press e to activate door
    
    private bool isTriggerActive = false;
    private bool isDoorOpened = false;

    AudioSource audio; 

    // Use this for initialization
	void Start ()
    {
        audio = GetComponent<AudioSource>();

	}

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            //When player activate trigger we show text
            isTriggerActive = true;
            //gameObject.GetComponent<Rigidbody>().isKinematic = true;
            // OpenPanel.SetActive(true);

        }
    }

    private void OnTriggerExit(Collider other)
    {
        //When player left triggered zone we hide panel with text
        isTriggerActive = false;
        audio.Play(); 
        _animatorLD.SetBool("isopen", false);
        _animatorLD.Play("LDoorClose");
        _animatorRD.SetBool("isopen", false);
        _animatorRD.Play("RDoorClose");
        isDoorOpened = false;


        // OpenPanel.SetActive(false);
    }

    // Update is called once per frame
    void Update ()
    {
	    if(isTriggerActive==true)
        {
            //Player pressed button and pres key E
            if (isDoorOpened == false)
            {
                Debug.Log("OPENING");
                audio.Play(); 
                //OPEN LEFT DOOR
                _animatorLD.SetBool("isopen", true);
                _animatorLD.Play("LDoorOpen");
                // //OPEN RIGHT DOOR
                _animatorRD.SetBool("isopen", true);
                _animatorRD.Play("RDoorOpen");
                isDoorOpened = true;
            }
            // else
            // {
            //     Debug.Log("CLOSING");
            //     //Close left and right door
            //     _animatorLD.SetBool("isopen", false);
            //     _animatorLD.Play("LDoorClose");
            //     _animatorRD.SetBool("isopen", false);
            //     _animatorRD.Play("RDoorClose");
            //     isDoorOpened = false;
            // }
        }
	}
}
