
namespace BeresnevGamesTest.Core
{
    //������� ������ ��������� �� ����� �������� �������/������ ������.
    //�������� ������ ��������� ������� ���������� � ����������� �� ������ Racket
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