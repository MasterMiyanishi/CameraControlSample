// ---------------------------------------------------------  
// CameraScreenChenge.cs  
//   
// 作成日:  2021/11/22
// 作成者:  MasterM
// ---------------------------------------------------------  
using UnityEngine;
using System.Collections;

public class CameraScreenChenge : MonoBehaviour {

    #region 変数  
    // 描画判定するためのターゲットオブジェクトを指定
    public GameObject g_player = default;
    // ターゲットの描画コンポーネント
    Renderer g_targetRenderer = default;
    // カメラコンポーネント
    Camera g_camera = default;
    #endregion

    #region プロパティ  

    #endregion

    #region メソッド  
    private void Start() {
        // ターゲットの描画情報取得
        g_targetRenderer = g_player.GetComponent<Renderer>();
        g_camera = GetComponent<Camera>();
    }
    private void Update() {

        // カメラにターゲットが表示されなくなった場合の処理
        if (!g_targetRenderer.isVisible) {

            // カメラから見たワールド座標を取得
            // ViewportToWorldPointに0,0,0を渡すとカメラから見た左下の座標を取得
            // ViewportToWorldPointに1,1,0を渡すとカメラから見た右上の座標を取得
            Vector3 rightUp = g_camera.ViewportToWorldPoint(new Vector3(1, 1, 0));
            Vector3 letDown = g_camera.ViewportToWorldPoint(new Vector3(0, 0, 0));

            // カメラ座標を取得
            Vector3 newScreenPosition = this.transform.position;
            // ターゲットが右にはみ出したかどうか
            if (g_player.transform.position.x > rightUp.x) {
                newScreenPosition += new Vector3(rightUp.x - letDown.x, 0,0);
            // ターゲットが左にはみ出したかどうか
            } else if (g_player.transform.position.x < letDown.x) {
                newScreenPosition -= new Vector3(rightUp.x - letDown.x, 0, 0);
            }
            // ターゲットが上にはみ出したかどうか
            if (g_player.transform.position.y > rightUp.y) {
                newScreenPosition += new Vector3( 0, rightUp.y - letDown.y, 0);
            // ターゲットが下にはみ出したかどうか
            } else if (g_player.transform.position.y < letDown.y) {
                newScreenPosition -= new Vector3( 0, rightUp.y - letDown.y, 0);
            }

            // カメラの座標を更新する
            this.transform.position = newScreenPosition;
        }
    }
    #endregion
}