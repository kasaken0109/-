using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestAction : MonoBehaviour, TestBase
{
    /// <summary> 複製を繰り返す回数/// </summary>
    [SerializeField] private int m_repeatNum = 5;
    /// <summary> 複製する限界の距離/// </summary>
    [SerializeField] private float m_limitDistance = 30;
    /// <summary> 複製するゲームオブジェクト/// </summary>
    private GameObject m_object;
    private Vector3 vector;
    private int m_count = 0;
    // Start is called before the first frame update
    void Start()
    {
        m_object = GameObject.CreatePrimitive(PrimitiveType.Sphere);
        vector = m_object.transform.position;
    }

    void Update()
    {
        while (true)
        {
            if (Vector3.Distance(vector, transform.position) > m_limitDistance)
            {
                break;
            }
            DeplicateShape(m_object, m_repeatNum, this.transform);
            this.transform.position += new Vector3(0, 3, 0);
            m_count += 1;
            Debug.Log(m_count);
        }
    }

    public void DeplicateShape()
    {

    }
    /// <summary>
    /// 指定されたゲームオブジェクトを指定回数複製する
    /// </summary>
    /// <param name="gameObject">対象</param>
    /// <param name="repeatNum">複製回数</param>
    public void DeplicateShape(GameObject gameObject, int repeatNum)
    {
        for (int i = 0; i < repeatNum; i++)
        {
            Instantiate(gameObject);
        }
    }

    /// <summary>
    /// 指定されたゲームオブジェクトを指定場所に指定回数複製する
    /// </summary>
    /// <param name="gameObject">対象</param>
    /// <param name="repeatNum">回数</param>
    /// <param name="m_spwanPoint">位置</param>
    public void DeplicateShape(GameObject gameObject, int repeatNum, Transform m_spwanPoint)
    {
        for (int i = 0; i < repeatNum; i++)
        {
            Instantiate(gameObject,m_spwanPoint.position, m_spwanPoint.rotation);
        }
    }
}
