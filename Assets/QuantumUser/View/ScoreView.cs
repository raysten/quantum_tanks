using Quantum;
using TMPro;
using UnityEngine;

namespace QuantumUser.View
{
    public class ScoreView : QuantumSceneViewComponent
    {
        [SerializeField]
        private TMP_Text _scoreText;

        public override void OnUpdateView()
        {
            if (_scoreText != null)
            {
                _scoreText.text = string.Empty;
                var tanksFilter = VerifiedFrame.Filter<PlayerLink, TankGun>();

                while (tanksFilter.Next(out var entity, out var playerLink, out var tankGun))
                {
                    var playerName = VerifiedFrame.GetPlayerData(playerLink.PlayerRef).PlayerNickname;
                    _scoreText.text += $"{playerName}: {tankGun.Score}  \n";
                }
            }
        }
    }
}
