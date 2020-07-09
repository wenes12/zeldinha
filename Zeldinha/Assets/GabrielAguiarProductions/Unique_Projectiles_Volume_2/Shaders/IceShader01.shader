// Shader created with Shader Forge v1.38 
// Shader Forge (c) Neat Corporation / Joachim Holmer - http://www.acegikmo.com/shaderforge/
// Note: Manually altering this data may prevent you from opening it in Shader Forge
/*SF_DATA;ver:1.38;sub:START;pass:START;ps:flbk:,iptp:0,cusa:False,bamd:0,cgin:,lico:1,lgpr:1,limd:0,spmd:1,trmd:0,grmd:0,uamb:True,mssp:True,bkdf:False,hqlp:False,rprd:True,enco:False,rmgx:False,imps:True,rpth:0,vtps:0,hqsc:True,nrmq:1,nrsp:0,vomd:0,spxs:False,tesm:0,olmd:1,culm:0,bsrc:3,bdst:7,dpts:2,wrdp:False,dith:0,atcv:False,rfrpo:True,rfrpn:Refraction,coma:15,ufog:True,aust:True,igpj:True,qofs:0,qpre:3,rntp:2,fgom:False,fgoc:False,fgod:False,fgor:False,fgmd:0,fgcr:0.5,fgcg:0.5,fgcb:0.5,fgca:1,fgde:0.01,fgrn:0,fgrf:300,stcl:False,atwp:False,stva:128,stmr:255,stmw:255,stcp:6,stps:0,stfa:0,stfz:0,ofsf:0,ofsu:0,f2p0:True,fnsp:False,fnfb:False,fsmp:False;n:type:ShaderForge.SFN_Final,id:2865,x:33504,y:32651,varname:node_2865,prsc:2|diff-9133-OUT,normal-5964-RGB,emission-3003-OUT,alpha-1522-OUT;n:type:ShaderForge.SFN_Multiply,id:6343,x:32834,y:32356,varname:node_6343,prsc:2|A-7736-RGB,B-6665-RGB,C-3180-OUT;n:type:ShaderForge.SFN_Color,id:6665,x:32620,y:32395,ptovrint:False,ptlb:Color,ptin:_Color,varname:_Color,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,c1:0.3823529,c2:0.7955374,c3:1,c4:1;n:type:ShaderForge.SFN_Tex2d,id:7736,x:32620,y:32222,ptovrint:True,ptlb:Main Texture,ptin:_MainTex,varname:_MainTex,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,tex:06a153c05e9db484d80af7cb91566419,ntxv:0,isnm:False;n:type:ShaderForge.SFN_Tex2d,id:5964,x:33267,y:32728,ptovrint:True,ptlb:Normal Map,ptin:_BumpMap,varname:_BumpMap,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,tex:4356798f500d5da4ab251b427856ea61,ntxv:3,isnm:True;n:type:ShaderForge.SFN_Fresnel,id:4223,x:32654,y:33110,varname:node_4223,prsc:2|EXP-3227-OUT;n:type:ShaderForge.SFN_Slider,id:3227,x:32334,y:33137,ptovrint:False,ptlb:FresnelArea,ptin:_FresnelArea,varname:node_3227,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,min:0,cur:2.820513,max:10;n:type:ShaderForge.SFN_Multiply,id:8604,x:32843,y:33110,varname:node_8604,prsc:2|A-1470-RGB,B-4223-OUT,C-9988-OUT;n:type:ShaderForge.SFN_Color,id:1470,x:32654,y:32963,ptovrint:False,ptlb:FresnelColor,ptin:_FresnelColor,varname:node_1470,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,c1:0.5588235,c2:0.8904665,c3:1,c4:1;n:type:ShaderForge.SFN_Slider,id:9988,x:32497,y:33278,ptovrint:False,ptlb:FresnelPower,ptin:_FresnelPower,varname:node_9988,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,min:1,cur:1.406627,max:20;n:type:ShaderForge.SFN_Slider,id:1522,x:33121,y:32910,ptovrint:False,ptlb:Opacity,ptin:_Opacity,varname:node_1522,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,min:0,cur:1,max:1;n:type:ShaderForge.SFN_Slider,id:3180,x:32463,y:32574,ptovrint:False,ptlb:ColorBrightness,ptin:_ColorBrightness,varname:node_3180,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,min:0,cur:3.760684,max:10;n:type:ShaderForge.SFN_VertexColor,id:5669,x:32837,y:32692,varname:node_5669,prsc:2;n:type:ShaderForge.SFN_Multiply,id:9133,x:33267,y:32359,varname:node_9133,prsc:2|A-6343-OUT,B-8604-OUT;n:type:ShaderForge.SFN_Multiply,id:8176,x:33278,y:32991,varname:node_8176,prsc:2|A-5669-RGB,B-8604-OUT;n:type:ShaderForge.SFN_Multiply,id:3003,x:33444,y:32397,varname:node_3003,prsc:2|A-9133-OUT,B-5669-RGB;proporder:6665-3180-7736-5964-1470-3227-9988-1522;pass:END;sub:END;*/

Shader "GAP/IceShader01" {
    Properties {
        _Color ("Color", Color) = (0.3823529,0.7955374,1,1)
        _ColorBrightness ("ColorBrightness", Range(0, 10)) = 3.760684
        _MainTex ("Main Texture", 2D) = "white" {}
        _BumpMap ("Normal Map", 2D) = "bump" {}
        _FresnelColor ("FresnelColor", Color) = (0.5588235,0.8904665,1,1)
        _FresnelArea ("FresnelArea", Range(0, 10)) = 2.820513
        _FresnelPower ("FresnelPower", Range(1, 20)) = 1.406627
        _Opacity ("Opacity", Range(0, 1)) = 1
        [HideInInspector]_Cutoff ("Alpha cutoff", Range(0,1)) = 0.5
    }
    SubShader {
        Tags {
            "IgnoreProjector"="True"
            "Queue"="Transparent"
            "RenderType"="Transparent"
        }
        Pass {
            Name "FORWARD"
            Tags {
                "LightMode"="ForwardBase"
            }
            Blend SrcAlpha OneMinusSrcAlpha
            ZWrite Off
            
            CGPROGRAM
            #pragma vertex vert
            #pragma fragment frag
            #define UNITY_PASS_FORWARDBASE
            #define _GLOSSYENV 1
            #include "UnityCG.cginc"
            #include "UnityPBSLighting.cginc"
            #include "UnityStandardBRDF.cginc"
            #pragma multi_compile_fwdbase
            #pragma multi_compile_fog
            #pragma only_renderers d3d9 d3d11 glcore gles gles3 metal 
            #pragma target 2.0
            uniform float4 _Color;
            uniform sampler2D _MainTex; uniform float4 _MainTex_ST;
            uniform sampler2D _BumpMap; uniform float4 _BumpMap_ST;
            uniform float _FresnelArea;
            uniform float4 _FresnelColor;
            uniform float _FresnelPower;
            uniform float _Opacity;
            uniform float _ColorBrightness;
            struct VertexInput {
                float4 vertex : POSITION;
                float3 normal : NORMAL;
                float4 tangent : TANGENT;
                float2 texcoord0 : TEXCOORD0;
                float4 vertexColor : COLOR;
            };
            struct VertexOutput {
                float4 pos : SV_POSITION;
                float2 uv0 : TEXCOORD0;
                float4 posWorld : TEXCOORD1;
                float3 normalDir : TEXCOORD2;
                float3 tangentDir : TEXCOORD3;
                float3 bitangentDir : TEXCOORD4;
                float4 vertexColor : COLOR;
                UNITY_FOG_COORDS(5)
            };
            VertexOutput vert (VertexInput v) {
                VertexOutput o = (VertexOutput)0;
                o.uv0 = v.texcoord0;
                o.vertexColor = v.vertexColor;
                o.normalDir = UnityObjectToWorldNormal(v.normal);
                o.tangentDir = normalize( mul( unity_ObjectToWorld, float4( v.tangent.xyz, 0.0 ) ).xyz );
                o.bitangentDir = normalize(cross(o.normalDir, o.tangentDir) * v.tangent.w);
                o.posWorld = mul(unity_ObjectToWorld, v.vertex);
                o.pos = UnityObjectToClipPos( v.vertex );
                UNITY_TRANSFER_FOG(o,o.pos);
                return o;
            }
            float4 frag(VertexOutput i) : COLOR {
                i.normalDir = normalize(i.normalDir);
                float3x3 tangentTransform = float3x3( i.tangentDir, i.bitangentDir, i.normalDir);
                float3 viewDirection = normalize(_WorldSpaceCameraPos.xyz - i.posWorld.xyz);
                float3 _BumpMap_var = UnpackNormal(tex2D(_BumpMap,TRANSFORM_TEX(i.uv0, _BumpMap)));
                float3 normalLocal = _BumpMap_var.rgb;
                float3 normalDirection = normalize(mul( normalLocal, tangentTransform )); // Perturbed normals
////// Lighting:
////// Emissive:
                float4 _MainTex_var = tex2D(_MainTex,TRANSFORM_TEX(i.uv0, _MainTex));
                float3 node_8604 = (_FresnelColor.rgb*pow(1.0-max(0,dot(normalDirection, viewDirection)),_FresnelArea)*_FresnelPower);
                float3 node_9133 = ((_MainTex_var.rgb*_Color.rgb*_ColorBrightness)*node_8604);
                float3 emissive = (node_9133*i.vertexColor.rgb);
                float3 finalColor = emissive;
                fixed4 finalRGBA = fixed4(finalColor,_Opacity);
                UNITY_APPLY_FOG(i.fogCoord, finalRGBA);
                return finalRGBA;
            }
            ENDCG
        }
    }
    FallBack "Diffuse"
    CustomEditor "ShaderForgeMaterialInspector"
}
