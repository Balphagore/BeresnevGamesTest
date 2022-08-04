using System.IO;
using UnityEngine;

namespace BeresnevGamesTest.Game
{
    //��������� �� persistentDataPath JSON ���� � ������� ������. ���� ���� �����������, ���������� ���� ��������� ������, ������� ������� � ���������������� ���� � ����������.
    //��� �� ��������� �� ������ ��������� ����� ������ � ���������� ������ ������� � ������������ ���� � ����� �� ���.
    public class PlayerDataSerializer : MonoBehaviour
    {
        [SerializeField]
        private string path;
        private PlayerDataModel playerData;
        [SerializeField]
        private PlayerDataModel defaultPlayerData;

        public delegate void UpdatePlayerDataHandle(PlayerDataModel playerData);
        public event UpdatePlayerDataHandle UpdatePlayerDataEvent;

        public void Initialize(PlayerStats playerStats)
        {
            playerStats.UpdateRecordEvent += OnUpdateRecordEvent;
            playerStats.UpdateBallSkinEvent += OnUpdateBallSkinEvent;

            path = Path.Combine(Application.persistentDataPath, "PlayerData.json");
            if (File.Exists(path))
            {
                string json = File.ReadAllText(path);
                playerData = JsonUtility.FromJson<PlayerDataModel>(json);
            }
            else
            {
                File.WriteAllText(path, JsonUtility.ToJson(defaultPlayerData));
                playerData = defaultPlayerData;
            }
            UpdatePlayerDataEvent?.Invoke(playerData);
            playerData.gamesPlayed++;
            File.WriteAllText(path, JsonUtility.ToJson(playerData));
        }

        private void OnUpdateBallSkinEvent(Color newColor, int skinId)
        {
            playerData.selectedSkinId = skinId;
            File.WriteAllText(path, JsonUtility.ToJson(playerData));
        }

        private void OnUpdateRecordEvent(int newRecord)
        {
            playerData.record = newRecord;
            File.WriteAllText(path, JsonUtility.ToJson(playerData));
        }
    }
}