using UnityEngine;

namespace BeresnevGamesTest.Core
{
    //������������ ����� ����������� ����������� ������ ������� � ���������������� ��.
    //�� ��������� ������ ���� ����, ��� ������� �������������� �������������� ��������.
    //��������� ��������� ����������� �� ���� � ��������� ��� ������.
    public class CoreManager : MonoBehaviour
    {
        [Header("Core")]
        [SerializeField]
        private PlayerInput playerInput;
        [SerializeField]
        private GameField gameField;
        [SerializeField]
        private PlayerRacket playerRacket;
        [SerializeField]
        private EnemyRacket enemyRacket;
        [SerializeField]
        private BallMovement ballMovement;

        public BallMovement BallMovement { get => ballMovement; set => ballMovement = value; }

        public virtual void Start()
        {
            float positionLimit = gameField.Initialize();
            playerRacket.Initialize(playerInput, positionLimit);
            enemyRacket.Initialize(playerInput, positionLimit);
            ballMovement.Initialize();
        }
    }
}