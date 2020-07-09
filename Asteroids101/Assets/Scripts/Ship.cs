using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Ship Class
public class Ship : MonoBehaviour
{
    [SerializeField]
    GameObject ship;

    [SerializeField]
    GameObject Bullet;

    [SerializeField]
    GameObject HUD;

    Vector2 thrustdirection = new Vector2(1, 0);
    const float ThrustForce = 2f;
    const float DegreesPerSecond = 120f;
    float radius = 0.75f;

    // Start is called before the first frame update
    void Start()
    {

        
    }

    void FixedUpdate()
    {
        if (Input.GetAxis("Thrust") > 0)
        {
            ship.GetComponent<Rigidbody2D>().AddForce(ThrustForce * thrustdirection, ForceMode2D.Force);
        }

    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetAxis("Rotate")!=0)
        {
            float rotationinput = Input.GetAxis("Rotate");
            float rotationAmount = DegreesPerSecond * Time.deltaTime; 
            if (rotationinput < 0) 
            {
                rotationAmount *= -1; 
            }
            transform.Rotate(Vector3.forward, rotationAmount);
            float angle = transform.eulerAngles.z * Mathf.Deg2Rad;
            thrustdirection.x = Mathf.Cos(angle);
            thrustdirection.y = Mathf.Sin(angle);

        }
        if(Input.GetKeyDown(KeyCode.LeftControl))
        {
           GameObject b1 = Instantiate<GameObject>(Bullet);
            b1.transform.position = transform.position;
            b1.GetComponent<Bullet>().applyforce(thrustdirection);
            AudioManager.Play(AudioClipName.PlayerShot);
        }
        
    }
    void OnCollisionEnter2D(Collision2D coll)
    {
        GameObject ast = coll.gameObject;
        if (ast.tag == "Asteroid")
        {
            AudioManager.Play(AudioClipName.PlayerDeath);
            HUD.GetComponent<HUD>().Stoptimer();
            Destroy(gameObject);
        }
    }


}
