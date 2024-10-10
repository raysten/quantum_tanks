using Quantum;
using TMPro;
using UnityEngine;

namespace QuantumUser.View
{
    public class TanksGameView : QuantumSceneViewComponent
    {
        [SerializeField]
        private TMP_Text _scoreText;

        public override void OnUpdateView()
        {
            if (_scoreText != null)
            {
                _scoreText.text = string.Empty;
                var tanksFilter = VerifiedFrame.Filter<PlayerLink, TankRotator>();

                while (tanksFilter.Next(out var entity, out var playerLink, out var tankRotator))
                {
                    var playerName = VerifiedFrame.GetPlayerData(playerLink.PlayerRef).PlayerNickname;
                    _scoreText.text += $"{playerName}: {tankRotator.Score}  \n";
                }
            }
        }
    }
}
