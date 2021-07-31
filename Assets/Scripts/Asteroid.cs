using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Asteroid : MonoBehaviour
{
    public float size = 1.0f;
    public float minSize = 0.5f;
    public float maxSize = 1.5f;
    public float minSpeed = 5f;
    public float maxSpeed = 20f;
    public float speed = 5f;
    public float maxLifeTime = 30.0f;

    private Rigidbody2D rigidbody;

    private void Awake() {
        rigidbody = GetComponent<Rigidbody2D>();
    }

    private void Start()
    {
        this.transform.eulerAngles = new Vector3(0, 0, Random.value * 360.0f);
        this.transform.localScale = Vector3.one * this.size;   
    }

    public void SetTrajectory(Vector2 direction){
        rigidbody.AddForce(direction * Random.Range(minSpeed, maxSpeed));
        this.speed = Random.Range(minSpeed, maxSpeed);
        Destroy(this.gameObject, this.maxLifeTime);
    }

    private void OnCollisionEnter2D(Collision2D collision) {
        if (collision.gameObject.tag == "Bullet") {
            if ((this.size * 0.5f) >= this.minSize) {

                CreateSplit(getDeflectorAngle(45));
                CreateSplit(getDeflectorAngle(-45));    
            }

            FindObjectOfType<GameManager>().AsteroidDestroyed(this);
            Destroy(this.gameObject);
        }
    }

    private void CreateSplit(Vector2 newDirection){
        Vector2 position = this.transform.position;
        position += Random.insideUnitCircle * 0.5f;
        Asteroid half = Instantiate(this, position, this.transform.rotation);
        half.size = this.size * 0.5f;
        half.SetTrajectory(newDirection);
    } 

    private Vector2 getDeflectorAngle(float angle) {
        float cosAngle = Mathf.Cos(angle * Mathf.Deg2Rad);
        float sinAngle = Mathf.Sin(angle * Mathf.Deg2Rad);

        float velocityX = this.rigidbody.velocity.normalized.x;
        float velocityY = this.rigidbody.velocity.normalized.y;

        Vector2 resultVector = new Vector2(
            velocityX * cosAngle - velocityY * sinAngle, 
            velocityX * sinAngle + velocityY * cosAngle
        );

        return resultVector;
    }
}
