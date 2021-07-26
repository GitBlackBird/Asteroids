using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Asteroid : MonoBehaviour
{
    public float size = 1.0f;
    public float minSize = 0.5f;
    public float maxSize = 1.5f;
    public float speed = 5.0f;
    public float maxLifeTime = 30.0f;
    private Rigidbody2D rigidbody;

    private void Awake() {
        rigidbody = GetComponent<Rigidbody2D>();
    }
    private void Start()
    {
        this.transform.eulerAngles = new Vector3(0, 0, Random.value * 360.0f);
        this.transform.localScale = Vector3.one * this.size;

        rigidbody.mass = this.size;
    }
    public void SetTrajectory(Vector2 direction){
        rigidbody.AddForce(direction * this.speed);
        Destroy(this.gameObject, this.maxLifeTime);
    }

    
}
