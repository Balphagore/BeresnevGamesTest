using UnityEngine;

namespace BeresnevGamesTest.Core
{
    //Класс обрабатывающий движения ракеток.
    public class Racket : MonoBehaviour
    {
        [SerializeField]
        private Transform modelTransform;

        private float position;
        private float positionLimit;

        public virtual void Move(float delta)
        {
            position += delta*Time.deltaTime;
            position = Mathf.Clamp(position, -positionLimit, positionLimit);
            transform.position = new Vector3(position, transform.position.y, transform.position.z);
        }

        public float PositionLimit
        {
            get => positionLimit;

            set
            {
                positionLimit = value-modelTransform.localScale.x/2;
            }
        }
    }
}