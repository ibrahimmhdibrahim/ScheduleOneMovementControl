using MelonLoader;
using UnityEngine;
using Il2CppScheduleOne.PlayerScripts;

[assembly: MelonInfo(
    typeof(ScheduleOneMovementControl.MovementControl),
    "ScheduleOneMovementControl",
    "1.3.0",
    "KodoBreaker"
)]

[assembly: MelonGame("TVGS", "Schedule I")]

namespace ScheduleOneMovementControl
{
    public class MovementControl : MelonMod
    {
        private MelonPreferences_Category category;

        private MelonPreferences_Entry<float> speed1;
        private MelonPreferences_Entry<float> speed2;
        private MelonPreferences_Entry<float> speed3;
        private MelonPreferences_Entry<float> JumpMultiplier;

        public override void OnInitializeMelon()
        {
            category = MelonPreferences.CreateCategory(
                "ScheduleOneMovementControl",
                "Schedule One Speed Control"
            );

            speed1 = category.CreateEntry(
                "Speed1", 1f, "Speed 1", "Select This Speed By Pressing The F5 Key."
            );

            speed2 = category.CreateEntry(
                "Speed2", 2f, "Speed 2", "Select This Speed By Pressing The F6 Key."
            );

            speed3 = category.CreateEntry(
                "Speed3", 3f, "Speed 3", "Select This Speed By Pressing The F7 Key."
            );


            JumpMultiplier = category.CreateEntry(
                "JumpMultiplier", 3f, "Jump Multiplier", "Change Jump Height By Pressing The F8 key."
            );

            MelonPreferences.Save();

            MelonLogger.Msg("ScheduleOneMovementControl loaded!");
            MelonLogger.Msg(
                $"F5 = Speed 1 ({speed1.Value}x) | " +
                $"F6 = Speed 2 ({speed2.Value}x) | " +
                $"F7 = Speed 3 ({speed3.Value}x)"
            );
            
            MelonLogger.Msg(
                $"JumpMultiplier at initialization: {PlayerMovement.JumpMultiplier}"
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
            else if (Input.GetKeyDown(KeyCode.F8))
                ApplyJumpForce(JumpMultiplier.Value, "Jump Multiplier");
            else if (Input.GetKeyDown(KeyCode.F9))
                ApplyJumpForce(1.0f, "Reset Jump Multiplier");
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

        private void ApplyJumpForce(float force, string settingName)
        {
            // PlayerMovement.JumpForce = force;
            PlayerMovement.JumpMultiplier = force;

            MelonLogger.Msg(
                $"JumpMultiplier={PlayerMovement.JumpMultiplier}" + ":" + settingName
            );
        }
    }
}