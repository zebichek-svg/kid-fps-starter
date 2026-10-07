using UnityEngine;

public class BasicShooter : MonoBehaviour
{
    [Header("Shooting Settings")]
    public Camera fpsCamera;
    public float fireRate = 0.2f;
    public float range = 50f;
    public float damage = 25f;
    
    [Header("Effects")]
    public Transform muzzlePoint;
    public ParticleSystem muzzleFlash;

    private MouseLook mouseLook;
    private float nextFireTime;

    private void Start()
    {
        if (fpsCamera == null)
            fpsCamera = Camera.main;

        mouseLook = fpsCamera.GetComponent<MouseLook>();
    }

    private void Update()
    {
        if (Input.GetButtonDown("Fire1") && Time.time >= nextFireTime)
        {
            Shoot();
            nextFireTime = Time.time + fireRate;
        }
    }

    private void Shoot()
    {
        if (mouseLook != null)
            mouseLook.ApplyRecoil();

        if (muzzleFlash != null)
            muzzleFlash.Play();

        Vector3 origin = fpsCamera.transform.position;
        Vector3 direction = fpsCamera.transform.forward;

        Ray ray = new Ray(origin, direction);

        if (Physics.Raycast(ray, out RaycastHit hit, range))
        {
            Debug.DrawLine(origin, hit.point, Color.red, 1f);

            if (hit.collider.CompareTag("Target"))
            {
                TargetHealth target = hit.collider.GetComponent<TargetHealth>();
                if (target != null)
                {
                    target.TakeDamage(damage);
                    GameManager.instance.AddScore(target.points);
                }
            }
        }
    }
}
