using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WallMove : MonoBehaviour
{
    // Start is called before the first frame update
    public float moveSpeed;
    public float minY;
    public float maxY;

    private float oldPosition;
    private GameObject gameObj;

    void Start()
    {
        moveSpeed = 2f;
        gameObj = gameObject;
        oldPosition = 7.5f;
        minY = -1; maxY = 1;
        gameObj.transform.Translate(new Vector3(0, Random.Range(minY, maxY + 1), 0));
    }

    // Update is called once per frame
    void Update()
    {
        gameObj.transform.Translate(new Vector3(-1 * Time.deltaTime * moveSpeed, 0, 0));
        
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.tag.Equals("ResetWall"))
        {
            gameObj.transform.position = new Vector3(oldPosition, Random.Range(minY, maxY + 1), 0);
        }
    }
}
