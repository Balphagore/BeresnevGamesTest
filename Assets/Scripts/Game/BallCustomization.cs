using UnityEngine;

namespace BeresnevGamesTest.Game
{
    //Реагирует на ивент от класса, в котором выбирается цвет шарика и соответственно изменяет его.
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