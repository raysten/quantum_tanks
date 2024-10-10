using Quantum;
using TMPro;

namespace QuantumUser.View
{
    public class TanksGameView : QuantumSceneViewComponent
    {
        public TMP_Text ScoreBoard;

        public override void OnUpdateView()
        {
            if (ScoreBoard != null)
            {
                ScoreBoard.text = "<b>Score</b>\n";
                var shipsFilter = VerifiedFrame.Filter<PlayerLink, TankRotator>();

                while (shipsFilter.Next(out var entity, out var playerLink, out var tankRotator))
                {
                    var playerName = VerifiedFrame.GetPlayerData(playerLink.PlayerRef).PlayerNickname;
                    ScoreBoard.text += $"{playerName}: {tankRotator.Score}  \n";
                }
            }
        }
    }
}
