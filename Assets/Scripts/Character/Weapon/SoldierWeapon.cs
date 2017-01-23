using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoldierWeapon : MagazineWeapon
{
    [Header("Transform Object")]
    public Transform fireLocation;
    public Transform playerLocation;

    public int maxCount;
    public Bullet prefab;
    //public float fireDelay;

    private List<Bullet> storage;

    void Start()
    {
        SetBulletTrails();
    }
 
    private void SetBulletTrails()
    {
        Transform storageObject = new GameObject("Bullets").transform;

        storage = new List<Bullet>();
        for (int i = 0; i < maxCount; i++)
        {
            GameObject gameObj = Instantiate(prefab.gameObject);
            gameObj.transform.SetParent(storageObject);
            gameObj.SetActive(false);

            storage.Add(gameObj.GetComponent<Bullet>());
        }

    }

    public override void Fire(Vector3 targetPosition)
    {
        targetPosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        Vector3 direction = targetPosition - transform.position;

        Ray2D ray = new Ray2D(fireLocation.position, targetPosition - playerLocation.position);
        RaycastHit2D rayHit = Physics2D.Raycast(ray.origin, ray.direction, 20f);

        //SetAngle(targetPosition, ray, rayHit);

        Bullet megazine = storage.Find(obj => !obj.gameObject.activeInHierarchy);

        if (megazine == null)
        {
            return;
        }

        GameObject gameObj = megazine.gameObject;

        float angle = Mathf.Atan2(ray.direction.y, ray.direction.x) * Mathf.Rad2Deg; //각도 구하는 식

        gameObj.transform.rotation = Quaternion.AngleAxis(angle, Vector3.forward);
        gameObj.transform.position = ray.origin;

        gameObj.SetActive(true);
        StartCoroutine(DisableObject(gameObj, 1f));

        if (rayHit.collider == null)
        {
            return;
        }

        if (rayHit.collider == null || rayHit.collider.tag != "Enemy")
        {
            return;
        }

        //Enemy enemy = rayHit.collider.GetComponent<Enemy>();
        //enemy.Damage(1);
    }

    private IEnumerator DisableObject(GameObject gameObj, float delay)
    {
        yield return new WaitForSeconds(delay);
        gameObj.SetActive(false);
    }
}
