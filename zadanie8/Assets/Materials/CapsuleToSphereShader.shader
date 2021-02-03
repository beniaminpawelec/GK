Shader "Custom/CapsuleToSphereShader"
{
	 SubShader
    {
        Pass {
			CGPROGRAM

			#pragma vertex vert 
			#pragma fragment frag
			#include "UnityCG.cginc"
         
            struct v2f {
                float4 pos : SV_POSITION;
                fixed4 color : COLOR;
            };

			v2f vert (appdata_full v)
			{
				v2f o;
				float4 newPos = v.vertex.y > 0.5 
					? float4(v.vertex.x, v.vertex.y - 1, v.vertex.zw) 
					: v.vertex;
                o.pos = UnityObjectToClipPos(newPos);
                o.color.xyz = v.color * v.normal;
                o.color.w = 1.0;
                return o;
			}

			fixed4 frag (v2f i) : SV_Target { return i.color; }

			ENDCG
		}
    }
}
