using DevionGames;
using UnityEngine;

[ComponentMenu("Custom/Health Action")]
[System.Serializable]
public class HealthAction : Action
{
    public enum HealType { HealUp, HealDown }

    [SerializeField] int _changeAmount = 10;
    [SerializeField] HealType _healType;

    private GameObject _target;
    private PlayerHealth _playerHealth;

    public override void OnStart()
    {
        _target = GameObject.Find("PlayerBody");
        _playerHealth = _target.GetComponent<PlayerHealth>();
    }

    public override ActionStatus OnUpdate()
    {
        if (_healType == HealType.HealUp)
        {
            _playerHealth.CurrentHealth += _changeAmount;
        }
        else
        {
            _playerHealth.TakeDamage(_changeAmount);
        }
        return ActionStatus.Success;
    }
}
