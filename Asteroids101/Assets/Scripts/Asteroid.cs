using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SocialPlatforms;

public class Asteroid : MonoBehaviour
{
    Rigidbody2D r2d;
    CircleCollider2D c2d;

    [SerializeField]
    Sprite green;

    [SerializeField]
    Sprite magenta;

    [SerializeField]
    Sprite white;

    // Start is called before the first frame update
    void Start()
    {
        r2d = gameObject.GetComponent<Rigidbody2D>();
        c2d = gameObject.GetComponent<CircleCollider2D>();
    }
    

    public void Initialize(Direction dir,Vector3 pos)
    {
        transform.position = pos;
        int rand = Random.Range(0, 3);
        if (rand == 0)
            GetComponent<SpriteRenderer>().sprite = green;
        if (rand == 1)
            GetComponent<SpriteRenderer>().sprite = magenta;
        if (rand == 2)
            GetComponent<SpriteRenderer>().sprite = white;


        
        const float MinImpulseForce = 1f;
        const float MaxImpulseForce = 2f;
        float angle = 0;
        if (dir == Direction.Up)
        {
            angle = Random.Range(75*Mathf.Deg2Rad, 105 * Mathf.Deg2Rad);
        }
        else if (dir == Direction.Down)
        {
            angle = Random.Range(255 * Mathf.Deg2Rad, 285 * Mathf.Deg2Rad);
        }
        else if (dir == Direction.Left)
        {
            angle = Random.Range(165 * Mathf.Deg2Rad, 195 * Mathf.Deg2Rad);
        }
        else if (dir == Direction.Right)
        {
            angle = Random.Range(0 * Mathf.Deg2Rad,  15* Mathf.Deg2Rad);
        }

        Vector2 direction = new Vector2(
            Mathf.Cos(angle), Mathf.Sin(angle));
        float magnitude = Random.Range(MinImpulseForce, MaxImpulseForce);
        GetComponent<Rigidbody2D>().AddForce(
            direction * magnitude,
            ForceMode2D.Impulse);
    }

    public void startmoving()
    {
        print("IN STARTMOVING");
        int rand = Random.Range(0, 3);
        if (rand == 0)
            GetComponent<SpriteRenderer>().sprite = green;
        if (rand == 1)
            GetComponent<SpriteRenderer>().sprite = magenta;
        if (rand == 2)
            GetComponent<SpriteRenderer>().sprite = white;

        const float MinImpulseForce = 1f;
        const float MaxImpulseForce = 2f;
        float angle = Random.Range(0 * Mathf.Deg2Rad, 360 * Mathf.Deg2Rad);
        Vector2 direction = new Vector2(
            Mathf.Cos(angle), Mathf.Sin(angle));
        float magnitude = Random.Range(MinImpulseForce, MaxImpulseForce);
        GetComponent<Rigidbody2D>().AddForce(
            direction * magnitude,
            ForceMode2D.Impulse);
    }
    void OnCollisionEnter2D(Collision2D coll)
    {
        GameObject bullet = coll.gameObject;
        if (bullet.tag == "Bullet")
        {

            if(transform.localScale.x <0.5)
            {
                AudioManager.Play(AudioClipName.AsteroidHit);
                Destroy(gameObject);
                Destroy(bullet);
            }
            else
            {
                Vector3 loc_size = transform.localScale;
                loc_size.x = loc_size.x / 2;
                loc_size.y = loc_size.y / 2;
                transform.localScale = loc_size;
                GetComponent<CircleCollider2D>().radius /= 2;
                GameObject newast = Instantiate(gameObject);
                newast.GetComponent<Asteroid>().startmoving();
                GameObject newast2 = Instantiate(gameObject);
                newast2.GetComponent<Asteroid>().startmoving();
                //Instantiate(gameObject);
                //gameObject.GetComponent<Asteroid>().startmoving();





                AudioManager.Play(AudioClipName.AsteroidHit);

                Destroy(gameObject);
                Destroy(bullet);
            }
            
        }
    }

    // Update is called once per frame
}
