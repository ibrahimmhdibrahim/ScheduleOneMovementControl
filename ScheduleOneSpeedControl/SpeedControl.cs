
using MelonLoader;
using UnityEngine;
using Il2CppScheduleOne.PlayerScripts;

[assembly: MelonInfo(
    typeof(ScheduleOneSpeedControl.SpeedControl),
    "ScheduleOneSpeedControl",
    "1.3.0",
    "KodoBreaker"
)]

[assembly: MelonGame("TVGS", "Schedule I")]

namespace ScheduleOneSpeedControl
{
    public class SpeedControl : MelonMod
    {
        private MelonPreferences_Category category;

        private MelonPreferences_Entry<float> speed1;
        private MelonPreferences_Entry<float> speed2;
        private MelonPreferences_Entry<float> speed3;

        public override void OnInitializeMelon()
        {
            category = MelonPreferences.CreateCategory(
                "ScheduleOneSpeedControl",
                "Schedule One Speed Control"
            );

            speed1 = category.CreateEntry(
                "Speed1", 1f, "Speed 1", "Select this speed by pressing the F5 key."
            );

            speed2 = category.CreateEntry(
                "Speed2", 2f, "Speed 2", "Select this speed by pressing the F6 key."
            );

            speed3 = category.CreateEntry(
                "Speed3", 3f, "Speed 3", "Select this speed by pressing the F7 key."
            );

            MelonPreferences.Save();

            MelonLogger.Msg("ScheduleOneSpeedControl loaded!");
            MelonLogger.Msg(
                $"F5 = Speed 1 ({speed1.Value}x) | " +
                $"F6 = Speed 2 ({speed2.Value}x) | " +
                $"F7 = Speed 3 ({speed3.Value}x)"
            );
        }

        public override void OnUpdate()
        {
            if (Input.GetKeyDown(KeyCode.F5))
                ApplySpeed(speed1.Value, "Speed 1");
            else if (Input.GetKeyDown(KeyCode.F6))
                ApplySpeed(speed2.Value, "Speed 2");
            else if (Input.GetKeyDown(KeyCode.F7))
                ApplySpeed(speed3.Value, "Speed 3");
        }

        private void ApplySpeed(float multiplier, string slotName)
        {
            if (multiplier < 0.1f)
                multiplier = 0.1f;

            PlayerMovement.StaticMoveSpeedMultiplier = multiplier;

            MelonLogger.Msg(
                $"{slotName} activated: {multiplier:0.##}x"
            );
        }
    }
}
