using UnityEngine;

namespace BeresnevGamesTest.Core
{
    //Класс обрабатывающий движения шарика и его взаимодействие с краями игрового поля.
    public class BallMovement : MonoBehaviour
    {
        [SerializeField]
        private float speed;

        private Rigidbody ballRigidbody;
        private Vector3 direction;

        public delegate void AddScoreHandle(bool isPlayerPoint);
        public event AddScoreHandle AddScoreEvent;

        public void Initialize()
        {
            ballRigidbody = gameObject.GetComponent<Rigidbody>();
            RespawnBall();
        }

        private void OnCollisionEnter(Collision collision)
        {
            Vector3 normal = collision.contacts[0].normal;
            ballRigidbody.velocity = Vector3.zero;
            Transform collisionTransform = collision.collider.transform;
            if (collision.collider.transform.parent.tag == "Racket")
            {
                Vector3 newDirection = new Vector3(collisionTransform.position.x - collision.contacts[0].point.x, collisionTransform.position.y - collision.contacts[0].point.y, collisionTransform.position.z - collision.contacts[0].point.z);
                ballRigidbody.AddForce(Vector3.Reflect((direction - newDirection).normalized * speed, normal));
            }
            else
            {
                if (collision.collider.tag == "Barrier")
                {
                    ballRigidbody.AddForce(Vector3.Reflect(direction.normalized * speed, normal));
                }
                else
                {
                    if (collision.collider.tag == "PlayerEdge")
                    {
                        RespawnBall();
                        AddScoreEvent?.Invoke(false);
                    }
                    else
                    {
                        if (collision.collider.tag == "EnemyEdge")
                        {
                            RespawnBall();
                            AddScoreEvent?.Invoke(true);
                        }
                    }
                }
            }
        }

        public void FixedUpdate()
        {
            direction = gameObject.GetComponent<Rigidbody>().velocity;
        }

        private void RespawnBall()
        {
            ballRigidbody.velocity = Vector3.zero;
            transform.position = Vector3.zero;
            ballRigidbody.AddForce(new Vector3(Random.Range(-0.1f, 0.1f), 0, Random.Range(-1f, 1f)).normalized * speed);
        }
    }
}