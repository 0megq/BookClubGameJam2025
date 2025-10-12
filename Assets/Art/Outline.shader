Shader "Custom/Outline"
{
    Properties
    {
        _OutlineColor ("Outline Color", Color) = (1, 0, 0, 1)
        _OutlineWidth ("Outline Width", Float) = 1 // Adjust size as needed
    }
    SubShader
    {
        Tags { "RenderType" = "Opaque"}
        
        Pass
        {
            Cull Front // Render only the front faces to create an outline effect
            
            CGPROGRAM
            #pragma vertex vert
            #pragma fragment frag

            fixed4 _OutlineColor;
            float _OutlineWidth;

            float4 vert(float4 position : POSITION, float3 color: COLOR) : SV_POSITION
            {
                float3 normal = color * 2 - 1;
                float4 clipPosition = UnityObjectToClipPos(position);
                float3 clipNormal = mul((float3x3) UNITY_MATRIX_VP, mul((float3x3) UNITY_MATRIX_M, normal));
                
                float2 offset = normalize(clipNormal.xy) / _ScreenParams.xy * _OutlineWidth * clipPosition.w * 2;
                clipPosition.xy += offset;

                return clipPosition;
            }

            fixed4 frag() : SV_Target
            {
                return _OutlineColor; // Return the outline color
            }
            ENDCG
        }
    }
}
