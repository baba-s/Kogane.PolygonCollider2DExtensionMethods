using System.Collections.Generic;
using UnityEngine;

namespace Kogane
{
    /// <summary>
    /// PolygonCollider2D の拡張メソッド
    /// </summary>
    public static class PolygonCollider2DExtensionMethods
    {
        //================================================================================
        // 関数(static)
        //================================================================================
        /// <summary>
        /// 指定されたスプライトの形に合わせて PolygonCollider2D を更新します
        /// </summary>
        public static void UpdateFromSprite( this PolygonCollider2D self, SpriteRenderer spriteRenderer )
        {
            self.UpdateFromSprite( spriteRenderer.sprite );
        }

        /// <summary>
        /// 指定されたスプライトの形に合わせて PolygonCollider2D を更新します
        /// </summary>
        public static void UpdateFromSprite( this PolygonCollider2D self, Sprite sprite )
        {
            var physicsShapeCount = sprite.GetPhysicsShapeCount();

            self.pathCount = physicsShapeCount;

            var physicsShape = new List<Vector2>();

            for ( var i = 0; i < physicsShapeCount; i++ )
            {
                physicsShape.Clear();
                sprite.GetPhysicsShape( i, physicsShape );
                var points = physicsShape.ToArray();
                self.SetPath( i, points );
            }
        }
    }
}