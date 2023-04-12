// ---------------------------------------------------------  
// ScrollLockCamera.cs  
//   
// 作成日:  2021/11/22
// 作成者:  MasterM
// ---------------------------------------------------------  
using UnityEngine;
using System.Collections;

public class ScrollLockCamera : MonoBehaviour
{

    #region 変数  
    // 移動する範囲の最大位置を指定する
    public float g_maxUp = 0;
    public float g_maxDown = 0;
    public float g_maxLeft = 0;
    public float g_maxRight = 0;

    #endregion

    #region プロパティ  

    #endregion

    #region メソッド  
    private void Update() {

        // 移動範囲制限
        this.transform.position = new Vector3( 
            Mathf.Clamp(this.transform.position.x, g_maxLeft,g_maxRight), 
            Mathf.Clamp(this.transform.position.y, g_maxDown, g_maxUp),
            this.transform.position.z);
    }

    #endregion
}