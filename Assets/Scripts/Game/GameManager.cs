using UnityEngine;
using BeresnevGamesTest.Core;

namespace BeresnevGamesTest.Game
{
    //����� ����������� ����������� ������ ������� � ���������������� ��.
    //����������� �� ������������ ������ ���� ����, �������� � �������� ��� ������.
    public class GameManager : CoreManager
    {
        [Header("Game")]
        [SerializeField]
        private PlayerDataSerializer playerDataSerializer;
        [SerializeField]
        private PlayerStats playerStats;
        [SerializeField]
        private GameInterface gameInterface;
        [SerializeField]
        private BallCustomization ballCustomization;

        public override void Start()
        {
            base.Start();
            ballCustomization.Initialize(playerStats);
            gameInterface.Initialize(playerStats, playerDataSerializer);
            playerStats.Initialize(BallMovement, gameInterface, playerDataSerializer);
            playerDataSerializer.Initialize(playerStats);
        }
    }
}