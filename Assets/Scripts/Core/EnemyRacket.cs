
namespace BeresnevGamesTest.Core
{
    //–акетка противника повтор€ет движени€ ракетки игрока, но реализована отдельным классом на случай изменени€ логики.
    //ќсновна€ логика идентична ракетке игрока и наследуетс€ от класса Racket
    public class EnemyRacket : Racket
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