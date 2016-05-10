Shader "Custom/test" {
	Properties {
		_Color ("Color", Color) = (1,1,1,1)
		_MainTex ("Albedo (RGB)", 2D) = "white" {}
		_Glossiness ("Smoothness", Range(0,1)) = 0.5
		_Metallic ("Metallic", Range(0,1)) = 0.0
	}
	SubShader {
		Tags { "Queue" = "Geometry" }
                 Pass
                  {            
                     GLSLPROGRAM 
				#ifdef VERTEX
				  #include "UnityCG.glslinc"
				varying vec4 globalColor;
				varying vec4 texCoords;

				void main()
				{
				   float displacementHeight = 50.0;
				   float displacementY = displacementHeight * sin(_Time.y + 10.0 * gl_Vertex.x * gl_Vertex.y * gl_Vertex.z);
				   vec4 modifiedPosition = gl_Vertex;
				        	
				   modifiedPosition.z += displacementY;
				   gl_Position = gl_ModelViewProjectionMatrix * modifiedPosition;
				   globalColor = vec4(1.0 - abs(1.0 / (gl_Vertex.x * 2.0 + gl_Vertex.y * 0.5 + gl_Vertex.z * 4.0)) * (abs(sin (_Time.y)) + 1.0), 1.0 - abs(1.0 / (gl_Vertex.x * 0.5 + gl_Vertex.y * 2.0 + gl_Vertex.z * 2.0)) * (abs(sin (_Time.y)) + 1.0), 0.75, 0.25);
				   texCoords = gl_MultiTexCoord0;
				}
				#endif

				#ifdef FRAGMENT
				precision mediump float;

				varying vec4 globalColor;
				varying vec4 texCoords;

				uniform sampler2D texSampler2D;

				void main()
				{
				      	gl_FragColor = globalColor * texture2D(texSampler2D, texCoords.xy);
				}
				#endif 
				  ENDGLSL        
         	}
	}
	FallBack "Diffuse"
}
