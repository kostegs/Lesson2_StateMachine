using UnityEngine;

[CreateAssetMenu(fileName = "CharacterConfig", menuName = "Configs/CharacterConfig")]
public class CharacterConfig : ScriptableObject
{
    [SerializeField] private RunningStateConfig _runningStateConfig;
    [SerializeField] private AirborneStateConfig _airborneStateConfig;

    public RunningStateConfig RunningStateConfig => _runningStateConfig;
    public AirborneStateConfig  AirborneStateConfig => _airborneStateConfig;
}
