using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(AudioSource))]
public class bullet : MonoBehaviour
{
    //Drag in the Bullet Prefab from the Component Inspector.
    public GameObject Bullet;

    //Enter the Speed of the Bullet from the Component Inspector.
    public float BulletForce = 100.0f;

    //Destroy time
    public float destroyTime = 3.0f;

    AudioSource myaudio;

    private ParticleSystem gunEffect;

    // Start is called before the first frame update
    void Start()
    {
        myaudio = GetComponent<AudioSource>();
        gunEffect = gameObject.GetComponent<ParticleSystem>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.LeftControl) || Input.GetMouseButtonDown(0))
        {
            //create a bullet instance
            GameObject currentBullet = Instantiate(Bullet, this.transform.position, this.transform.rotation) as GameObject;

            //fix scale
            currentBullet.transform.localScale = new Vector3(0.2f, 0.2f, 0.2f);

            //add force to shoot
            currentBullet.GetComponent<Rigidbody>().AddForce(transform.forward * BulletForce);
            myaudio.Play();
            gunEffect.Play();

            //Destroy it after a certain time
            Destroy(currentBullet, destroyTime);
        }

    }
}
