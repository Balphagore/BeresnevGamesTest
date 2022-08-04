using System;
using System.Collections.Generic;
using UnityEngine;

namespace BeresnevGamesTest.Game
{
    [Serializable]
    public class PlayerDataModel
    {
        public int record;
        public int gamesPlayed;
        public int selectedSkinId;
    }

    [Serializable]
    public class SkinsDataModel
    {
        public List<Skin> skins;

        [Serializable]
        public class Skin
        {
            public int id;
            public Color color;
            public int gamesRequired;
        }
    }
}