using Core.Games;
using Core.Player;
using JetBrains.Annotations;
using UnityEngine;

namespace Teams.AbruTeam
{
    [UsedImplicitly]
    public class ExampleTeam : Team
    {
        public TeamPlayer GetPlayerOne() => new Arquero();

        public TeamPlayer GetPlayerTwo() => new Medio();

        public TeamPlayer GetPlayerThree() => new Delantero();
        
        public Color PrimaryColor => new Color(0.6f, 0.6f, 0.6f);

        public string GetName() => "16-More_Abru_Franco";

        public string TeamShield => "Black";


    }
}