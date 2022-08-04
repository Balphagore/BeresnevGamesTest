using UnityEngine;
using BeresnevGamesTest.Core;

namespace BeresnevGamesTest.Game
{
    //Хранит и обрабатывает параметры текущей сессии(счет игрока, счет противника).
    //Рагирует на ивенты загрузки данных игрока и касания шариком зачетных зон.
    public class PlayerStats : MonoBehaviour
    {
        [SerializeField]
        private int maxEnemyScore;

        [SerializeField]
        private SkinsDataModel skinsData;

        private int playerScore;
        private int enemyScore;

        private PlayerDataModel playerData;

        public delegate void UpdateRecordHandle(int newRecord);
        public event UpdateRecordHandle UpdateRecordEvent;
        public delegate void UpdateSkinsDataHandle(SkinsDataModel skinsData);
        public event UpdateSkinsDataHandle UpdateSkinsDataEvent;
        public delegate void UpdateBallSkinHandle(Color newColor, int skinId);
        public event UpdateBallSkinHandle UpdateBallSkinEvent;
        public delegate void UpdateScoreHandle(int newPlayerScore,int newEnemyScore);
        public event UpdateScoreHandle UpdateScoreEvent;
        public delegate void EndGameHandle();
        public event EndGameHandle EndGameEvent;

        public void Initialize(BallMovement ballMovement, GameInterface gameInterface, PlayerDataSerializer playerDataSerializer)
        {
            playerDataSerializer.UpdatePlayerDataEvent += OnUpdatePlayerDataEvent;
            ballMovement.AddScoreEvent += OnAddScoreEvent;
            gameInterface.UpdateBallSkinEvent += OnUpdateBallSkinEvent;
            UpdateScoreEvent?.Invoke(playerScore,enemyScore);
            UpdateSkinsDataEvent?.Invoke(skinsData);
        }

        private void OnUpdateBallSkinEvent(Color newColor, int skinId)
        {
            UpdateBallSkinEvent?.Invoke(newColor, skinId);
        }

        private void OnUpdatePlayerDataEvent(PlayerDataModel playerData)
        {
            this.playerData = playerData;
            UpdateRecordEvent?.Invoke(playerData.record);
            if (playerData.selectedSkinId >= 0)
            {
                UpdateBallSkinEvent?.Invoke(skinsData.skins[playerData.selectedSkinId].color, playerData.selectedSkinId);
            }
            else
            {
                UpdateBallSkinEvent?.Invoke(Color.white, playerData.selectedSkinId);
            }
        }

        private void OnAddScoreEvent(bool isPlayerPoint)
        {
            if (isPlayerPoint)
            {
                playerScore++;
                if (playerScore > playerData.record)
                {
                    playerData.record = playerScore;
                    UpdateRecordEvent?.Invoke(playerData.record);
                }
            }
            else
            {
                enemyScore++;
                if(enemyScore>= maxEnemyScore)
                {
                    EndGameEvent?.Invoke();
                }
            }
            UpdateScoreEvent?.Invoke(playerScore, enemyScore);
        }
    }
}