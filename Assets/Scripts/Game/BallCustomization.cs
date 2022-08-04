using UnityEngine;

namespace BeresnevGamesTest.Game
{
    //��������� �� ����� �� ������, � ������� ���������� ���� ������ � �������������� �������� ���.
    public class BallCustomization : MonoBehaviour
    {
        [SerializeField]
        private Renderer ballRenderer;

        public void Initialize(PlayerStats playerStats)
        {
            playerStats.UpdateBallSkinEvent += OnUpdateBallSkinEvent;
        }

        private void OnUpdateBallSkinEvent(Color newColor, int skinId)
        {
            ballRenderer.material.color = newColor;
        }
    }
}