using Core.Games;
using Core.Player;
using Core.Utils;
using UnityEngine;

namespace Teams.AbruTeam
{
    public class Arquero : TeamPlayer
    {
        private const int MidField = 10;
        public override FieldPosition GetInitialPosition() => FieldPosition.A2;
        public override string GetPlayerDisplayName() => "Arq";

        private Vector3 _lastPosition;

        private int _counter;
        
        public override void OnUpdate()
        {
            _counter++;

            if (_counter > 60)
            {
                _lastPosition = GetPosition();
                _counter = 0;
            }
            
            if (Vector3.Distance(GetBallPosition(), GetMyGoalPosition()) < MidField)
            {
                MoveBy(GetDirectionTo(new Vector3(GetBallPosition().x,GetBallPosition().y,GetBallPosition().z)));
            }
            else
            {
                GoTo(GetInitialPosition());
            }
            
           
        }

        public override void OnReachBall()
        {

            
            ShootBall(
                GetBallPosition().z > 0
                    ? GetDirectionTo(GetPositionFor(FieldPosition.F3))
                    : GetDirectionTo(GetPositionFor(FieldPosition.F1)), ShootForce.High);
        }

        public override void OnScoreBoardChanged(ScoreBoard scoreBoard)
        {

        }
    }
}