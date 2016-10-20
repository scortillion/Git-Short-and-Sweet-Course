using UnityEngine;
using System.Collections;

public class EnemySpawner : MonoBehaviour
{
    public GameObject enemyPrefab;
    public float width = 10f;
    public float height = 5f;

    public float speed = 1f;
    public float padding = 1f;

    private float xmin;
    private  float xmax;

    private bool movingRight = true;


    // Use this for initialization
    void Start()
    {
        float distanceToCamera = transform.position.z - Camera.main.transform.position.z;
        Vector3 leftEdge = Camera.main.ViewportToWorldPoint(new Vector3(0, 0, distanceToCamera));
        Vector3 rightEdge = Camera.main.ViewportToWorldPoint(new Vector3(1, 0, distanceToCamera));
        xmin = leftEdge.x;
        xmax = rightEdge.x;

        foreach (Transform child in transform)
        {
            //EnemyFormation is the Parent so we want the position of the Parent
            //If you do not do it this way the ship is spawned OUTSIDE of the EnemyFormation GameObject
            //This keeps all spawned ships as children of the EnemyFormation and under that GameObject
            GameObject enemy = Instantiate(enemyPrefab, child.transform.position, Quaternion.identity) as GameObject;
            enemy.transform.parent = child;
        }
    }

    void OnDrawGizmos()
    {
        Gizmos.DrawWireCube(transform.position, new Vector3(width,height,0));
    }

    // Update is called once per frame
    void Update()
    {
        if (movingRight)
        {
            transform.position += Vector3.right * speed * Time.deltaTime;            
        }
        else
        {
            transform.position += Vector3.left * speed * Time.deltaTime;           
        }

        float rightEdgeOfFormation = transform.position.x + (0.5f * width);
        float leftEdgeOfFormation = transform.position.x - (0.5f * width);
        if (leftEdgeOfFormation < xmin)
        {
            movingRight = true;
        } else if (rightEdgeOfFormation > xmax)
        {
            movingRight = false;
        }
    }
}