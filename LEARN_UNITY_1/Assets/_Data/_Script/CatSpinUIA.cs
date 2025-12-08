using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class CatSpinUIA : MonoBehaviour
{
    public float rotationSpeed = 250f;   // tốc độ xoay chính

    public float wobbleAngle = 10f;      // độ nghiêng lắc lư
    public float wobbleSpeed = 5f;       // tốc độ nghiêng

    private float wobbleTime = 0f;

    public float moveAmplitude = 0.1f;   // biên độ tịnh tiến (3–4)
    public float moveSpeed = 2f;       // tốc độ nhún

    private float startY;
    private float t = 0f;

    void Start()
    {
        startY = transform.position.y;
    }

    void Update()
    {
        // Xoay liên tục quanh trục Y
        transform.Rotate(0f, rotationSpeed * Time.deltaTime, 0f, Space.Self);

        // Nhún lên xuống theo trục Y
        t += Time.deltaTime * moveSpeed;

        float newY = startY + Mathf.Sin(t) * moveAmplitude;

        transform.position = new Vector3(
            transform.position.x,
            newY,
            transform.position.z
        );


        //// Tạo hiệu ứng “lắc lư điên điên”
        //wobbleTime += Time.deltaTime * wobbleSpeed;
        //float wobble = Mathf.Sin(wobbleTime) * wobbleAngle;

        //transform.localRotation = Quaternion.Euler(wobble, transform.localEulerAngles.y, wobble);
    }
}
