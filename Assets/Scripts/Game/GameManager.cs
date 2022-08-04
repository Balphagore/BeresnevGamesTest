using UnityEngine;
using BeresnevGamesTest.Core;

namespace BeresnevGamesTest.Game
{
    // ласс разрешающий зависимости других классов и инициализирующий их.
    //Ќаследуетс€ от аналогичного класса €дра игры, дцблиру€ и расшир€€ его логику.
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