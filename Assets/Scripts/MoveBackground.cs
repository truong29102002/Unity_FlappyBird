using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveBackground : MonoBehaviour
{
    // Start is called before the first frame update
    public float moveSpeed;
    public float moveRange;

    private Vector3 oldPosition;
    private GameObject gameObj;

    void Start()
    {
        moveSpeed = 2f;
        moveRange = 5.4f;
        gameObj = gameObject;
        oldPosition = gameObj.transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        gameObj.transform.Translate(new Vector3(-1 * Time.deltaTime * moveSpeed, 0, 0));

        if (Vector3.Distance(oldPosition, gameObj.transform.position) > moveRange)
        {
            gameObj.transform.position = oldPosition;
        }
    }
}
