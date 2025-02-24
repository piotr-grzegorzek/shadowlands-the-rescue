using System.Collections;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    [SerializeField] private float _timeToDestroyBullet = 10f;
    private int _bulletDamage;

    public int BulletDamage { get => _bulletDamage; set => _bulletDamage = value; }

    private void Start()
    {
        StartCoroutine(DestroyBulletAfterTime());
    }

    private IEnumerator DestroyBulletAfterTime()
    {
        yield return new WaitForSeconds(_timeToDestroyBullet);
        DestroyBullet();
    }

    private void DestroyBullet()
    {
        Destroy(gameObject);
    }

    protected virtual void OnCollisionEnter(Collision collision)
    {
        EnemyHealth enemy = collision.gameObject.GetComponent<EnemyHealth>();
        if (enemy)
        {
            enemy.TakeDamage(BulletDamage);
        }
        DestroyBullet();
    }
}
