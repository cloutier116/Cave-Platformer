using UnityEngine;
using System.Collections;
using System.Collections.Generic;


public class Platform : MonoBehaviour {

    public float trackerRange = 1.5f;

    public Vector3 pos1;
    public Vector3 pos2;

    public Tracker tracker;

    public bool useX, useY, useZ;

    Vector3 velocity = Vector3.zero;
    public float smoothTime = .05f;

    [Range(0, 1)]
    public float pos;

    Rigidbody2D rb;

	// Use this for initialization
	void Start () {
        rb = GetComponent<Rigidbody2D>();
	}
	
	// Update is called once per frame
	void Update () {

        if (tracker.objs.ContainsKey("Visor"))
        {
            if (useX)
            {
                pos = tracker.objs["Visor"].x;
                pos = (pos + trackerRange) / (2 * trackerRange);
                rb.position = Vector3.SmoothDamp(transform.position, Vector3.Lerp(pos1, pos2, pos), ref velocity, smoothTime);
            }
            else if (useY)
            {
                pos = tracker.objs["Visor"].y;
                pos = (pos - 1)/.6f;
                rb.position = Vector3.SmoothDamp(transform.position, Vector3.Lerp(pos1, pos2, pos), ref velocity, smoothTime);
            }
            else if(useZ)
            {
                pos = tracker.objs["Visor"].z;
                pos = (pos + trackerRange) / (2 * trackerRange);
                rb.position = Vector3.SmoothDamp(transform.position, Vector3.Lerp(pos1, pos2, pos), ref velocity, smoothTime);
            }
        }
	}

    
}
