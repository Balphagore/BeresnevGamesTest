using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

namespace BeresnevGamesTest.Game
{
    //Класс обрабатывающий элементы интерфейса. 
    public class GameInterface : MonoBehaviour
    {
        [SerializeField]
        private GameObject recordText;
        [SerializeField]
        private GameObject scoreText;
        [SerializeField]
        private Text recordValueText;
        [SerializeField]
        private Text scoreValueText;
        [SerializeField]
        private GameObject skinsPanel;
        [SerializeField]
        private Text gamesPlayedValueText;
        [SerializeField]
        private GameObject skinPrefab;
        [SerializeField]
        private Transform skinsContainerTransform;
        [SerializeField]
        private GameObject endGamePanel;
        [SerializeField]
        private Text resultText;

        private SkinsDataModel skinsData;
        private int gamesPlayed;

        public delegate void UpdateBallSkinHandle(Color newColor,int skinId);
        public event UpdateBallSkinHandle UpdateBallSkinEvent;

        public void Initialize(PlayerStats playerStats, PlayerDataSerializer playerDataSerializer)
        {
            playerStats.UpdateRecordEvent += OnUpdateRecordEvent;
            playerStats.UpdateScoreEvent += OnUpdateScoreEvent;
            playerStats.UpdateSkinsDataEvent += OnUpdateSkinsDataEvent;
            playerStats.EndGameEvent += OnEndGameEvent;
            playerDataSerializer.UpdatePlayerDataEvent += OnUpdatePlayerDataEvent;
            Time.timeScale = 1f;
        }

        private void OnEndGameEvent()
        {
            recordText.SetActive(false);
            scoreText.SetActive(false);
            recordValueText.gameObject.SetActive(false);
            scoreValueText.gameObject.SetActive(false);
            resultText.text = scoreValueText.text;
            endGamePanel.SetActive(true);
            Time.timeScale = 0f;
        }

        private void OnUpdatePlayerDataEvent(PlayerDataModel playerData)
        {
            gamesPlayed = playerData.gamesPlayed;
            for (int i = 0; i < skinsData.skins.Count; i++)
            {
                GameObject prefab = Instantiate(skinPrefab, skinsContainerTransform);
                prefab.name = "Skin" + i;
                prefab.GetComponentInChildren<Image>().color = skinsData.skins[i].color;
                gamesPlayedValueText.text = gamesPlayed.ToString();
                int gamesRequired = skinsData.skins[i].gamesRequired;
                prefab.GetComponentInChildren<Text>().text = gamesPlayed + "/" + gamesRequired;
                Button btn = prefab.GetComponentInChildren<Button>();
                if (gamesPlayed >= gamesRequired)
                {
                    int tmp = i;
                    btn.onClick.AddListener(delegate { OnLevelButtonClick(tmp); });
                }
                else
                {
                    btn.gameObject.SetActive(false);
                }
            }
            skinsPanel.SetActive(false);
            endGamePanel.SetActive(false);
        }

        private void OnUpdateSkinsDataEvent(SkinsDataModel skinsData)
        {
            this.skinsData = skinsData;
        }

        private void OnUpdateScoreEvent(int newPlayerScore, int newEnemyScore)
        {
            scoreValueText.text = newPlayerScore + " - " + newEnemyScore;
        }

        private void OnUpdateRecordEvent(int newRecord)
        {
            recordValueText.text = newRecord.ToString();
        }

        private void OnLevelButtonClick(object tmp)
        {
            UpdateBallSkinEvent?.Invoke(skinsData.skins[(int)tmp].color, (int)tmp);
        }

        public void OnSkinsButtonClick()
        {
            Time.timeScale = 0f;
            skinsPanel.SetActive(true);
        }

        public void OnBackButtonClick()
        {
            Time.timeScale = 1f;
            skinsPanel.SetActive(false);
        }

        public void OnRestartButtonClick()
        {
            SceneManager.LoadScene(0);
        }
    }
}