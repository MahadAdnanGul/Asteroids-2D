using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;

public class AsteroidSpawner : MonoBehaviour
{

    [SerializeField]
    GameObject prefabAsteroid;


    // Start is called before the first frame update
    void Start()
    {
        GameObject rocktest = Instantiate(prefabAsteroid) as GameObject;
        CircleCollider2D col = rocktest.GetComponent<CircleCollider2D>();
        float radius = col.radius;
        Destroy(rocktest);


        float middlex =( (ScreenUtils.ScreenRight - ScreenUtils.ScreenLeft) / 2f)+ScreenUtils.ScreenLeft;
        float middley = ((ScreenUtils.ScreenTop - ScreenUtils.ScreenBottom) / 2f) + ScreenUtils.ScreenBottom;
        GameObject rock1 = Instantiate(prefabAsteroid) as GameObject;
        GameObject rock2 = Instantiate(prefabAsteroid) as GameObject;
        GameObject rock3 = Instantiate(prefabAsteroid) as GameObject;
        GameObject rock4 = Instantiate(prefabAsteroid) as GameObject;

        Asteroid rockerl = rock1.gameObject.GetComponent<Asteroid>();
        Asteroid rockerR=  rock2.gameObject.GetComponent<Asteroid>();
        Asteroid rockerU = rock3.gameObject.GetComponent<Asteroid>();
        Asteroid rockerD = rock4.gameObject.GetComponent<Asteroid>();

        Vector3 Up = new Vector3(middlex, ScreenUtils.ScreenBottom-radius, -Camera.main.transform.position.z);
        Vector3 Down = new Vector3(middlex, ScreenUtils.ScreenTop+radius, -Camera.main.transform.position.z);
        Vector3 Left = new Vector3(ScreenUtils.ScreenRight+radius, middley, -Camera.main.transform.position.z);
        Vector3 Right = new Vector3(ScreenUtils.ScreenLeft-radius, middley, -Camera.main.transform.position.z);

        rockerl.Initialize(Direction.Left,Left);
        rockerR.Initialize(Direction.Right, Right);
        rockerU.Initialize(Direction.Up, Up);
        rockerD.Initialize(Direction.Down, Down);



    }


}
