# FMOD-Event-Compiler
An editor tool to generate a helper class that converts FMOD event paths to const properties for easy access in code.

For a given collection of FMOD banks, the tool will auto generate a class with const properties that point to each event's path.

Example:
![image](https://user-images.githubusercontent.com/4481766/170176607-304f6c98-bbf7-4d72-96a4-e02483c48a8c.png)

For this FMOD project, the generated code looks like this:

```
public class FMODEvents
{
    public class UI
    {
        public const string Click = "event:/UI/Click";
        public const string Unlock = "event:/UI/Unlock";
        public const string Hover = "event:/UI/Hover";
        public const string Repair = "event:/UI/Repair";
        public const string CoinLoot = "event:/UI/CoinLoot";
        public const string Upgrade = "event:/UI/Upgrade";
    }

    public class Abilities
    {
        public const string RamDash = "event:/Abilities/RamDash";
        public const string Gust = "event:/Abilities/Gust";
        public const string Burst = "event:/Abilities/Burst";
        public const string StinkExhaust = "event:/Abilities/StinkExhaust";
        public const string Repulse = "event:/Abilities/Repulse";
        public const string WeaponChange = "event:/Abilities/WeaponChange";
        public const string RapidFire = "event:/Abilities/RapidFire";
        public const string Dash = "event:/Abilities/Dash";
        public const string Concussive = "event:/Abilities/Concussive";
    }

    public class Explosions
    {
        public const string RailgunFire = "event:/Explosions/RailgunFire";
        public const string FlakExplode = "event:/Explosions/FlakExplode";
        public const string FlakFire = "event:/Explosions/FlakFire";
        public const string FlakHit = "event:/Explosions/FlakHit";
        public const string MetalShieldHit = "event:/Explosions/MetalShieldHit";
        public const string BasicCannonFire = "event:/Explosions/BasicCannonFire";
        public const string ShipExplode = "event:/Explosions/ShipExplode";
        public const string StoneShieldHit = "event:/Explosions/StoneShieldHit";
        public const string CannonballHit = "event:/Explosions/CannonballHit";
    }

    public class Ambience
    {
        public const string OceanAmbience = "event:/Ambience/OceanAmbience";
        public const string IslandAmbience = "event:/Ambience/IslandAmbience";
    }

    public class MiscFX
    {
        public const string Thunder = "event:/MiscFX/Thunder";
        public const string WindHowl = "event:/MiscFX/WindHowl";
        public const string WindzoneHowl = "event:/MiscFX/WindzoneHowl";
        public const string EngineHumEnemy = "event:/MiscFX/EngineHumEnemy";
        public const string EngineHum = "event:/MiscFX/EngineHum";
        public const string EngineHover = "event:/MiscFX/EngineHover";
        public const string CannonballWhistle = "event:/MiscFX/CannonballWhistle";
        public const string GrapplingHook = "event:/MiscFX/GrapplingHook";
        public const string LightningZap = "event:/MiscFX/LightningZap";
        public const string SwordClash = "event:/MiscFX/SwordClash";
        public const string SwordSwing = "event:/MiscFX/SwordSwing";
        public const string SwordPowerDown = "event:/MiscFX/SwordPowerDown";
    }

    public class Music
    {
        public class WinLose
        {
            public const string GameWon = "event:/Music/WinLose/GameWon";
            public const string RoundLoseStinger = "event:/Music/WinLose/RoundLoseStinger";
            public const string GameLost = "event:/Music/WinLose/GameLost";
            public const string RoundWinStinger = "event:/Music/WinLose/RoundWinStinger";
        }

        public class Combat
        {
            public const string CombatMusic5 = "event:/Music/Combat/CombatMusic5";
            public const string CombatMusic4 = "event:/Music/Combat/CombatMusic4";
            public const string CombatMusic6 = "event:/Music/Combat/CombatMusic6";
            public const string CombatMusic2 = "event:/Music/Combat/CombatMusic2";
            public const string CombatMusic3 = "event:/Music/Combat/CombatMusic3";
            public const string CombatMusic1 = "event:/Music/Combat/CombatMusic1";
        }

        public class TitleAndScreens
        {
            public const string Preparations = "event:/Music/TitleAndScreens/Preparations";
            public const string Store = "event:/Music/TitleAndScreens/Store";
            public const string MainTheme = "event:/Music/TitleAndScreens/MainTheme";
        }

        public const string KillStinger = "event:/Music/KillStinger";
    }
}

public class FMODSnapshots
{
    public const string UILayer = "snapshot:/UILayer";
    public const string GameOver = "snapshot:/GameOver";
}
```
