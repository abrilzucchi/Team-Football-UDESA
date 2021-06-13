using Core.Games;
using Core.Player;
using Core.Utils;
using UnityEngine;

namespace Teams.AbruTeam
{
    public class Medio : TeamPlayer
    {
        public override void OnUpdate()
        {
            if(EstaEnMiCancha())
                VoyABuscarLaPelota();
            else
            {
                VoyAMiLugar();
            }
        }

        private void VoyAMiLugar()
        {
            if (GetBallPosition().z > 2)
            {
                GoTo(FieldPosition.C3);
                return;
            }

            if (GetBallPosition().z < -2)
            {
                GoTo(FieldPosition.C1);
                return;
            }

            GoTo(GetInitialPosition());
        }

        private void VoyABuscarLaPelota()
        {
            MoveBy(GetDirectionTo(new Vector3(GetBallPosition().x, GetBallPosition().y, GetBallPosition().z)));
        }

        private bool EstaEnMiCancha()
        {
            return Vector3.Distance(GetBallPosition(),GetMyGoalPosition()) < 13;
        }

        public override void OnReachBall()
        {
            if(Vector3.Distance(GetPosition(),GetRivalGoalPosition()) < 10)
                ShootBall(GetDirectionTo(GetRivalGoalPosition()),ShootForce.High);
        }

        public override void OnScoreBoardChanged(ScoreBoard scoreBoard)
        {

        }

        public override FieldPosition GetInitialPosition() => FieldPosition.B2;

        public override string GetPlayerDisplayName() => "Maradona";
    }
}