using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SelectionManager : MonoBehaviour
{

    //public GameObject item;
    public GameObject tempParent;
    public Transform guide;

    public Material defaultMaterial;
    public Material selectedMaterial;
    private Transform _selection;

    // Update is called once per frame
    void Update()
    {
        if (_selection != null)
        {
            var selectedRenderer = _selection.GetComponent<Renderer>();
            selectedRenderer.material = defaultMaterial;
            _selection = null;

        }
        var ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit;
        if (Physics.Raycast(ray, out hit))
        {
            var selection = hit.transform;
            if (selection.CompareTag("Scalable"))
            {
                var selectedRenderer = selection.GetComponent<Renderer>();
                if (selectedRenderer != null)
                {
                    selectedRenderer.material = selectedMaterial;
                }
                _selection = selection;
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
}
