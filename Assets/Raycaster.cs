using System;
using UnityEngine;
using System.Collections;
using Assets;

public class Raycaster : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	    if (!moving)
	    {
	        var hit = CastRay();
	        if (hit != null) StartCoroutine(MoveTo(hit));
	    }
	}

    private bool moving = false;

    private GameObject CastRay()
    {
        var hit = new RaycastHit();
        if (Physics.Raycast(new Ray(transform.position, transform.forward), out hit))
        {
            if (hit.collider.gameObject.GetComponent<MoveTo>())
            {
                return hit.collider.gameObject;
            }
        }
        return null;
    }

    private IEnumerator MoveTo(GameObject destination)
    {
        moving = true;
        var startPos = transform.position;
        float t = 0;
        float totalTime = 3;
        while (t < totalTime)
        {
            transform.position = Vector3.Lerp(startPos, destination.transform.position, t/totalTime);
            t += Time.deltaTime;
            yield return null;
        }
        moving = false;
    }
}
