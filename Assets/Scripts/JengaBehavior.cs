using UnityEngine;

public class JengaBehavior : MonoBehaviour
{
    public GameObject prefabsObject;
    public Camera camera;

    const float Force = 20;
    const int DefaultNumberOfLayer = 10;
    const float CenterX = 0;
    const float StartY = 8;
    const float CenterZ= 0;

    private Vector3 _previousPosition;
    private static System.Random random = new System.Random();
    // Start is called before the first frame update
    void Start()
    {
        Debug.Log(_previousPosition);
        int numberOfLayers = PlayerPrefs.GetInt("NumberOfLayers");
        if(numberOfLayers == 0)
        {
            numberOfLayers = DefaultNumberOfLayer;
            PlayerPrefs.SetInt("NumberOfLayers", numberOfLayers);
        }
        GenerateJengaBlock(numberOfLayers);
    }

    private void GenerateJengaBlock(int numberOfLayers)
    {
        float prefabsObjectHeight = prefabsObject.transform.localScale.y;
        // a quick reminder: length = 3 * width
        float prefabsObjectWidth = prefabsObject.transform.localScale.z;
        float layerY = StartY;
        for (int i = 0; i < numberOfLayers; i++)
        {
            Quaternion quaternion;
            Vector3 transitionVector;
            Vector3 position;
            if(i % 2 != 0)
            {
                quaternion = Quaternion.identity;
                transitionVector = new Vector3(0, 0, prefabsObjectWidth);
                position = new Vector3(CenterX, layerY, CenterZ - prefabsObjectWidth);
            } else
            {
                quaternion = Quaternion.Euler(0, 90, 0);
                transitionVector = new Vector3(prefabsObjectWidth, 0, 0);
                position = new Vector3(CenterX - prefabsObjectWidth, layerY, CenterZ);
            }
            for(int j = 0; j < 3; j++)
            {
                GameObject gameObject = Instantiate(prefabsObject, position, quaternion);
                position += transitionVector;
            }
            layerY += prefabsObjectHeight;
        }
    }

    Rigidbody rigidbody;
    Vector3 originalRigidbodyPosition;
    float distance;
    Vector3 originalScreenTargetPosition;
    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            RaycastHit raycastHit;
            Ray ray = camera.ScreenPointToRay(Input.mousePosition);
            if (Physics.Raycast(ray, out raycastHit) && raycastHit.collider.tag == "woodenBlock")
            {
                rigidbody = raycastHit.rigidbody;
                originalRigidbodyPosition = rigidbody.position;
                //rigidbody.velocity = (originalRigidbodyPosition;
                distance = Vector3.Distance(ray.origin, raycastHit.point);
                originalScreenTargetPosition = camera.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, distance));

            }
            else
            {
                _previousPosition = camera.ScreenToViewportPoint(Input.mousePosition);
            }
        }
        if(Input.GetMouseButton(0) && rigidbody == null)
        {
            Vector3 direction = _previousPosition - camera.ScreenToViewportPoint(Input.mousePosition);

            camera.transform.RotateAround(new Vector3(), new Vector3(1, 0, 0), direction.z * 100);
            camera.transform.RotateAround(new Vector3(), new Vector3(0, 1, 0), -direction.x * 100);
            _previousPosition = camera.ScreenToViewportPoint(Input.mousePosition);
        }
        if (Input.GetMouseButtonUp(0) && rigidbody != null)
        {
            rigidbody = null;
        }
        //RotateCameraAroundObject();
        //MoveWoodenBlockOnClickTouch();
    }

    private void FixedUpdate()
    {
        if(rigidbody != null)
        {
            float force = (float) random.NextDouble() * Force;
            Vector3 mousePositionOffset = camera.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, distance)) - originalScreenTargetPosition;
            rigidbody.velocity = (originalRigidbodyPosition + mousePositionOffset - rigidbody.transform.position) * 500 * Time.deltaTime;

        }
        //MoveWoodenBlockOnClickTouch();
    }

    private void RotateCameraAroundObject()
    {
        if (Input.GetMouseButtonDown(0))
        {
            _previousPosition = camera.ScreenToViewportPoint(Input.mousePosition);
        }
        if (Input.GetMouseButton(0))
        {
            Vector3 direction = _previousPosition - camera.ScreenToViewportPoint(Input.mousePosition);

            camera.transform.RotateAround(new Vector3(), new Vector3(1, 0, 0), direction.z * 100);
            camera.transform.RotateAround(new Vector3(), new Vector3(0, 1, 0), -direction.x * 100);
            _previousPosition = camera.ScreenToViewportPoint(Input.mousePosition);
        }
    }

    private void MoveWoodenBlockOnClickTouch()
    {
        if(Input.GetMouseButtonDown(0) || Input.touchCount == 1)
        {
            RaycastHit raycastHit;
            Ray ray = camera.ScreenPointToRay(Input.mousePosition);
            if(Physics.Raycast(ray, out raycastHit))
            {
                if(raycastHit.collider.tag == "woodenBlock")
                {
                    Rigidbody rigidbody = raycastHit.rigidbody;
                    Vector3 originalRigidbodyPosition = rigidbody.position;
                    //rigidbody.velocity = (originalRigidbodyPosition;
                    float distance = Vector3.Distance(ray.origin, raycastHit.point);
                    Vector3 originalScreenTargetPosition = camera.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, distance));

                    Vector3 mousePositionOffset = camera.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, distance)) - originalScreenTargetPosition;
                    rigidbody.velocity = (originalRigidbodyPosition + mousePositionOffset - rigidbody.transform.position) * 500 * Time.deltaTime;

                }
            }
        }
    }

    //public GameObject projectile;
    //public float speed = 50;
    //RaycastHit hit;
    //Vector3 camPos;
    //Quaternion camAngle;

    //private void Start()
    //{
    //    // Store the camera's position
    //    camPos = DataPrefs.Fetch("camPos", () => GetComponent<Camera>().transform.position);
    //    // Store the camera's rotation
    //    camAngle = DataPrefs.Fetch("camAngle", () => GetComponent<Camera>().transform.rotation);
    //}

    //private void Update()
    //{
    //    if (!Input.GetMouseButtonUp(0))
    //    {
    //        return;
    //    }

    //    var ray = GetComponent<Camera>().ScreenPointToRay(Input.mousePosition);
        // Store the ray's origin
        //var origin = DataPrefs.Fetch($"origin{Time.frameCount}", () => ray.origin);
        //// Store the ray's direction
        //var direction = DataPrefs.Fetch($"direction{Time.frameCount}", () => ray.direction);

        // Raycast using the stored ray values
    //    var cast = new Ray(origin, direction);
    //    if (!Physics.Raycast(cast, out hit, Mathf.Infinity))
    //    {
    //        return;
    //    }

    //    // Instantiate projectile at the stored camera position & angle
    //    var newProjectile = Instantiate(projectile, camPos, camAngle);
    //    // Use the hit position and the stored camera position for velocity
    //    newProjectile.GetComponent<Rigidbody>().velocity = (hit.point - camPos).normalized * speed;
    //}
}
