
namespace BeresnevGamesTest.Core
{
    //Ракетка игрока реагирует на ивент движения курсора/пальца игрока.
    //Основная логика идентична ракетке противника и наследуется от класса Racket
    public class PlayerRacket : Racket
    {
        public void Initialize(PlayerInput playerInput, float positionLimit)
        {
            playerInput.MovementEvent += OnMovementEvent;
            PositionLimit = positionLimit;
        }

        private void OnMovementEvent(float delta)
        {
            Move(delta);
        }
    }
}