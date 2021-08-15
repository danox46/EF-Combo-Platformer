using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets._2D;

public class AoE : MonoBehaviour
{
    [SerializeField] private List<Rigidbody2D> hits;
    private Transform user;
    [SerializeField] private float damage;



    private void Awake()
    {
        hits = new List<Rigidbody2D>();
        user = GetComponentInParent<Transform>();
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void ClearHits()
    {
        hits = new List<Rigidbody2D>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag == "Enemy" && !hits.Contains(collision.attachedRigidbody))
        {
            collision.attachedRigidbody.AddForce(new Vector2(-damage / 10 * user.localScale.x, damage * 2f), ForceMode2D.Force);
            collision.GetComponent<PlatformerCharacter2D>().GetDamage(damage);
            hits.Add(collision.attachedRigidbody);
            Debug.Log("Pushing enemy");
        }
    }

}
