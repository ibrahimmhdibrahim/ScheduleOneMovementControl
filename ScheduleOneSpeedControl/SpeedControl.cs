using MelonLoader;
using UnityEngine;
using Il2CppScheduleOne.PlayerScripts;

[assembly: MelonInfo(
    typeof(ScheduleOneSpeedControl.SpeedControl),
    "ScheduleOneSpeedControl",
    "1.0.0",
    "KodoBreaker"
)]

[assembly: MelonGame("TVGS", "Schedule I")]

namespace ScheduleOneSpeedControl
{
    public class SpeedControl : MelonMod
    {
        public override void OnInitializeMelon()
        {
            MelonLogger.Msg("ScheduleOneSpeedControl loaded!");
            MelonLogger.Msg("F5 = 1x | F6 = 2x | F7 = 3x");
        }

        public override void OnUpdate()
        {
            if (UnityEngine.Input.GetKeyDown(UnityEngine.KeyCode.F5))
                SetSpeed(1f);

            if (UnityEngine.Input.GetKeyDown(UnityEngine.KeyCode.F6))
                SetSpeed(2f);

            if (UnityEngine.Input.GetKeyDown(UnityEngine.KeyCode.F7))
                SetSpeed(3f);
        }

        private void SetSpeed(float multiplier)
        {
            PlayerMovement.StaticMoveSpeedMultiplier = multiplier;
            MelonLogger.Msg($"Movement multiplier set to {multiplier}x");
        }
    }
}