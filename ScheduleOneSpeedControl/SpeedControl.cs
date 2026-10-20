
using MelonLoader;
using UnityEngine;
using Il2CppScheduleOne.PlayerScripts;

[assembly: MelonInfo(
    typeof(ScheduleOneSpeedControl.SpeedControl),
    "ScheduleOneSpeedControl",
    "1.2.0",
    "KodoBreaker"
)]

[assembly: MelonGame("TVGS", "Schedule I")]

namespace ScheduleOneSpeedControl
{
    public class SpeedControl : MelonMod
    {
        private MelonPreferences_Category category;

        private MelonPreferences_Entry<float> normalSpeed;
        private MelonPreferences_Entry<float> fastSpeed;
        private MelonPreferences_Entry<float> veryFastSpeed;

        private float currentMultiplier = 1f;

        public override void OnInitializeMelon()
        {
            category = MelonPreferences.CreateCategory(
                "ScheduleOneSpeedControl",
                "Schedule One Speed Control"
            );

            normalSpeed = category.CreateEntry(
                "NormalSpeed", 1f, "F5 - Normal Speed"
            );

            fastSpeed = category.CreateEntry(
                "FastSpeed", 2f, "F6 - Fast Speed"
            );

            veryFastSpeed = category.CreateEntry(
                "VeryFastSpeed", 3f, "F7 - Very Fast Speed"
            );

            MelonPreferences.Save();

            MelonLogger.Msg("ScheduleOneSpeedControl loaded!");
            MelonLogger.Msg(
                $"F5 = {normalSpeed.Value}x | " +
                $"F6 = {fastSpeed.Value}x | " +
                $"F7 = {veryFastSpeed.Value}x"
            );
        }

        public override void OnUpdate()
        {
            if (Input.GetKeyDown(KeyCode.F5))
                ApplySpeed(normalSpeed.Value);
            else if (Input.GetKeyDown(KeyCode.F6))
                ApplySpeed(fastSpeed.Value);
            else if (Input.GetKeyDown(KeyCode.F7))
                ApplySpeed(veryFastSpeed.Value);
        }

        private void ApplySpeed(float multiplier)
        {
            if (multiplier < 0.1f)
                multiplier = 0.1f;

            currentMultiplier = multiplier;
            PlayerMovement.StaticMoveSpeedMultiplier = multiplier;

            MelonLogger.Msg(
                $"Movement speed set to {currentMultiplier:0.##}x"
            );
        }
    }
}
