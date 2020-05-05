using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CamMouseLook : MonoBehaviour
{
   public Vector2 mouseLook;
    public Vector2 smoothV;
    public float sensitivity ; 
    public float smoothing;
	//GameObject mainCamera;


	public GameObject character;
    void Start()
    {
        //mainCamera = GameObject.FindWithTag("MainCamera");

        Cursor.lockState = CursorLockMode.Locked;
        character = transform.parent.gameObject;

    }

    void Update()
    {
        Vector2 vct2 = new Vector2(Input.GetAxisRaw("Mouse X"), Input.GetAxisRaw("Mouse Y"));
        smoothV.x = Mathf.Lerp(smoothV.x, vct2.x, 1 / smoothing); 
        smoothV.y = Mathf.Lerp(smoothV.y, vct2.y, 1 / smoothing); 
        mouseLook += smoothV;
        transform.localRotation = Quaternion.AngleAxis(-mouseLook.y, Vector3.right);
        character.transform.localRotation = Quaternion.AngleAxis(mouseLook.x, character.transform.up);

        //if (carrying)
        //{
        //    carry(carriedObject);
        //    checkDrop();
        //    //rotateObject();
        //}
        //else
        //{
        //    pickup();
        //}
    }
	//void rotateObject()
	//{
	//	carriedObject.transform.Rotate(5, 10, 15);
	//}

	//void carry(GameObject o)
	//{
	//	o.transform.position = Vector3.Lerp(o.transform.position, mainCamera.transform.position + mainCamera.transform.forward * distance, Time.deltaTime * smooth);
	//}

	//void pickup()
	//{
	//	if (Input.GetKeyDown(KeyCode.E))
	//	{
	//		int x = Screen.width / 2;
	//		int y = Screen.height / 2;

	//		Ray ray = GetComponent<Camera>().ScreenPointToRay(new Vector3(x, y));
	//		RaycastHit hit;
	//		if (Physics.Raycast(ray, out hit))
	//		{
	//			Pickupable p = hit.collider.GetComponent<Pickupable>();
	//			distance = p.transform.localScale.y * 4;
	//			if (p != null)
	//			{
	//				carrying = true;
	//				carriedObject = p.gameObject;
	//				p.gameObject.GetComponent<Rigidbody>().isKinematic = true;
	//			}
	//		}
	//	}
	//}

	//void checkDrop()
	//{
	//	if (Input.GetKeyDown(KeyCode.E))
	//	{
	//		dropObject();
	//	}
	//}

	//void dropObject()
	//{
	//	carrying = false;
	//	carriedObject.gameObject.GetComponent<Rigidbody>().isKinematic = false;
	//	carriedObject = null;
	//}
}
