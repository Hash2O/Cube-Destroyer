using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovingObjects : MonoBehaviour
{
    [SerializeField] private float _speed;

    [SerializeField] private Camera cam;
    // Start is called before the first frame update
    void Start()
    {
        cam = Camera.main;
    }

    // Update is called once per frame
    void Update()
    {
        /*
        //Ici, on fait converger les objets vers la caméra...
        float directionX = cam.transform.position.x - transform.position.x;
        float directionY = cam.transform.position.y - transform.position.y;
        float directionZ = cam.transform.position.z - transform.position.z;
        Vector3 cubeDirection = new Vector3(directionX, directionY, directionZ);
        */

        //Ici, on oriente les objets pour qu'ils se dirigent vers le plan de la caméra
        transform.Translate(- cam.transform.forward *_speed * Time.deltaTime);
        
        /*
        //Ici, on détruit les cubes qui sortent du cadre si besoin (sinon object pooling)
        if (transform.position.z < cam.transform.position.z -5)
        {
            Destroy(gameObject);
        }
        */
    }

    //Ici, on détruit le cube grace à un clic de la souris dessus
    private void OnMouseDown()
    {
        //Destroy(gameObject);
        gameObject.SetActive(false);
    }
}
