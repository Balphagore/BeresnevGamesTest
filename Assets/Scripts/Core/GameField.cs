using UnityEngine;

namespace BeresnevGamesTest.Core
{
    //Класс генерирующий рамки игрового поля. Для его корректной работы надо задать только размеры Plane. Коллайдеры автоматически растянутся и установятся в нужные места.
    public class GameField : MonoBehaviour
    {
        [SerializeField]
        private Transform gameFieldTransform;
        [SerializeField]
        private Transform leftBarrierTransform;
        [SerializeField]
        private Transform rightBarrierTransform;
        [SerializeField]
        private Transform topBarrierTransform;
        [SerializeField]
        private Transform bottomBarrierTransform;

        public float Initialize()
        {
            Vector2 gameFieldSize = new Vector2(gameFieldTransform.localScale.x * 10f, gameFieldTransform.localScale.z * 10f);

            leftBarrierTransform.position = new Vector3(-gameFieldSize.x / 2 - leftBarrierTransform.localScale.x / 2, leftBarrierTransform.localScale.x / 2, 0);
            leftBarrierTransform.localScale = new Vector3(1, 1, gameFieldSize.y);
            rightBarrierTransform.position = new Vector3(gameFieldSize.x / 2 + rightBarrierTransform.localScale.x / 2, rightBarrierTransform.localScale.x / 2, 0);
            rightBarrierTransform.localScale = new Vector3(1, 1, gameFieldSize.y);

            topBarrierTransform.position = new Vector3(0, rightBarrierTransform.localScale.y / 2, gameFieldSize.y / 2 + leftBarrierTransform.localScale.y / 2);
            topBarrierTransform.localScale = new Vector3(gameFieldSize.x, 1, 1);
            bottomBarrierTransform.position = new Vector3(0, rightBarrierTransform.localScale.y / 2, -gameFieldSize.y / 2 - leftBarrierTransform.localScale.y / 2);
            bottomBarrierTransform.localScale = new Vector3(gameFieldSize.x, 1, 1);

            return gameFieldSize.x / 2;
        }
    }
}