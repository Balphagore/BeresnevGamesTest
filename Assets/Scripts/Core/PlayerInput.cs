using UnityEngine;
using UnityEngine.InputSystem;

namespace BeresnevGamesTest.Core
{
    //Класс обрабатывающий движение мыши/пальца игрока и вызывющий ивент, на который впоследствии реагирует ракетки.
    public class PlayerInput : MonoBehaviour
    {
        float movementVector;

        public delegate void MovementHandle(float delta);
        public event MovementHandle MovementEvent;

        public void OnMovement(InputAction.CallbackContext context)
        {
            movementVector = context.ReadValue<Vector2>().x;
            MovementEvent?.Invoke(movementVector);
        }
    }
}