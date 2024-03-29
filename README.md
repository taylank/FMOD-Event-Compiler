# FMOD-Event-Compiler
An editor tool to generate a helper class that converts FMOD event paths to const properties for easy access in code.

For a given collection of FMOD banks, the tool will auto generate a class with const properties that point to each event's path. Supports snapshots as well.

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
    
    .
    .
    .
    .
    

public class FMODSnapshots
{
    public const string UILayer = "snapshot:/UILayer";
    public const string GameOver = "snapshot:/GameOver";
}
```

Which you can then use like this:
`RuntimeManager.PlayOneShot(FMODEvents.UI.CoinLoot);`
