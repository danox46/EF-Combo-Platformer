using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets._2D;

public class AoE : MonoBehaviour
{
    [SerializeField] private List<Rigidbody2D> hits;
    private Rigidbody2D user;
    [SerializeField] private float damage;
    public Vector2 pushVector;
    public bool moving;
    public Vector2 shotSpeed;



    private void Awake()
    {
        hits = new List<Rigidbody2D>();
        user = this.GetComponentInParent<Rigidbody2D>();
    }

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (moving)
        {
            if(user.GetComponent<PlatformerCharacter2D>().GetFacing_Right())
                transform.position = new Vector3(transform.position.x + (shotSpeed.x * Time.deltaTime), transform.position.y + (shotSpeed.y*Time.deltaTime));
            else
                transform.position = new Vector3(transform.position.x - (shotSpeed.x * Time.deltaTime), transform.position.y + (shotSpeed.y * Time.deltaTime));
        }
    }

    public void Shot()
    {
        moving = true;
    }

    public void EndShot()
    {
        moving = false;
        this.transform.localPosition = new Vector3(0, 0, 0);
    }

    public void ClearHits()
    {
        this.transform.localPosition = new Vector3(0, 0, 0);
        hits = new List<Rigidbody2D>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        //Debug.Log(user.name + " is trigering an attack on " + collision.name);

        if (user.tag == "Player")
        {
            if (collision.tag == "Enemy" && !hits.Contains(collision.attachedRigidbody))
            {
                collision.attachedRigidbody.AddForce(pushVector, ForceMode2D.Force);
                collision.GetComponent<PlatformerCharacter2D>().GetDamage(damage);
                hits.Add(collision.attachedRigidbody);
                Debug.Log("Pushing enemy");
            }
        }

        if (user.tag == "Enemy")
        {
            //Debug.Log("triggering enemy attack");

            if (collision.tag == "Player" && !hits.Contains(collision.attachedRigidbody))
            {
                collision.attachedRigidbody.AddForce(pushVector, ForceMode2D.Force);
                collision.GetComponent<PlatformerCharacter2D>().GetDamage(damage);
                hits.Add(collision.attachedRigidbody);
                Debug.Log("Pushing enemy");
            }
        }
    }

}
