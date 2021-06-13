using Core.Games;
using Core.Player;
using Core.Utils;
using UnityEngine;

namespace Teams.AbruTeam
{
    public class Delantero : TeamPlayer
    {
        
        private Vector3 _lastPosition;

        private int _counter;
        
        public override void OnUpdate()
        {
            if (Vector3.Distance(GetBallPosition(), GetMyGoalPosition()) > 10)
            {
                MoveBy(GetDirectionTo(new Vector3(GetBallPosition().x,GetBallPosition().y,GetBallPosition().z)));
            }
            else
            {
                GoTo(GetAttackPosition());
            }
            
            _counter++;

            if (_counter <= 10) return;
            _lastPosition = GetPosition();
            _counter = 0;
        }

        private FieldPosition GetAttackPosition()
        {
            return GetBallPosition().z > 0 ? FieldPosition.F3 : FieldPosition.F1;
        }

        public override void OnReachBall()
        {
            var direction = (_lastPosition - GetPosition()).normalized;
            if (Vector3.Dot(direction, GetDirectionTo(GetRivalGoalPosition())) > 0)
            {
                if(Vector3.Distance(GetPosition(),GetRivalGoalPosition()) < 7)
                    ShootBall(GetDirectionTo(GetRivalGoalPosition()),ShootForce.High);
            }
        }

        public override void OnScoreBoardChanged(ScoreBoard scoreBoard)
        {

        }

        public override FieldPosition GetInitialPosition() => FieldPosition.C2;

        public override string GetPlayerDisplayName() => "Delantero";

         

        public override string GetPlayerDisplayName() => "AbruMessi";
    }
}