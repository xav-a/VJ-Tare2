using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraBehavior : MonoBehaviour
{

    //The background image to use
    public SpriteRenderer area;
    private Bounds areaBounds;
    public GameObject player;

    float camVertExtent, camHorzExtent;
	// Start is called before the first frame update
	void Start ()
    {
        this.camVertExtent = Camera.main.orthographicSize;
        this.camHorzExtent = Camera.main.aspect * this.camVertExtent;
        this.areaBounds = this.area.bounds;
	}

    // Update is called once per frame
    void LateUpdate()
    {
        this.ClampCamera();
    }

    private void ClampCamera()
    {
        float leftBound = this.areaBounds.min.x + camHorzExtent;
        float rightBound = this.areaBounds.max.x - camHorzExtent;
        float bottomBound = this.areaBounds.min.y + camVertExtent;
        float topBound = this.areaBounds.max.y - camVertExtent;

        float camX = Mathf.Clamp(
            player.transform.position.x,
            leftBound,
            rightBound
        );
        float camY = Mathf.Clamp(
            player.transform.position.y,
            bottomBound,
            topBound
        );

        this.transform.position = new Vector3(
            camX,
            camY,
            this.transform.position.z
        );
    }
}
