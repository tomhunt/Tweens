using UnityEngine;
using System.Collections.Generic;

public delegate float TweenFunc(float t, float b, float c, float d);
public delegate Vector3 VectorTweenFunc(float t, Vector3 b, Vector3 c, float d);

public struct Tweentr {
	public TweenFunc fnTween;
}

public class Tween {
	public enum Type {
		Linear,
		EaseInQuad,
		EaseInCubic,
		EaseInQuart,
		EaseInQuint,
		EaseInCirc,
		EaseInExpo,
		EaseInSine,
		EaseOutQuad,
		EaseOutCubic,
		EaseOutQuart,
		EaseOutQuint,
		EaseOutCirc,
		EaseOutExpo,
		EaseOutSine,
		EaseInOutQuad,
		EaseInOutCubic,
		EaseInOutQuart,		
		EaseInOutQuint,
		EaseInOutCirc,
		EaseInOutExpo,
		EaseInOutSine
	}

	public static readonly Dictionary<Tween.Type, TweenFunc> Lookup =
		new Dictionary<Tween.Type, TweenFunc>() {
			{Type.Linear, Linear},
			{Type.EaseInQuad, EaseInQuad},
			{Type.EaseInCubic,EaseInCubic},
			{Type.EaseInQuart,EaseInQuart},
			{Type.EaseInQuint,EaseInQuint},
			{Type.EaseInCirc,EaseInCirc},
			{Type.EaseInExpo,EaseInExpo},
			{Type.EaseInSine,EaseInSine},
			{Type.EaseOutQuad,EaseOutQuad},
			{Type.EaseOutCubic,EaseOutCubic},
			{Type.EaseOutQuart,EaseOutQuart},
			{Type.EaseOutQuint,EaseOutQuint},
			{Type.EaseOutCirc,EaseOutCirc},
			//{Type.EaseOutExpo,EaseOutExpo},
			{Type.EaseOutSine,EaseOutSine},
			{Type.EaseInOutQuad,EaseInOutQuad},
			{Type.EaseInOutCubic,EaseInOutCubic},
			{Type.EaseInOutQuart,EaseInOutQuart},
			{Type.EaseInOutQuint,EaseInOutQuint},
			{Type.EaseInOutCirc,EaseInOutCirc},
			{Type.EaseInOutExpo,EaseInOutExpo},
			{Type.EaseInOutSine, EaseInOutSine}
		};

	public static float Linear(float t, float b, float c, float d){
		return c*t/d + b;
	}

	public static float EaseInQuad(float t, float b, float c, float d){
		t /= d;
		return c*t*t + b;
	}

	public static float EaseOutQuad(float t, float b, float c, float d){
		t/=d;
		return -c*t*(t-2)+b;
	}

	public static float EaseInOutQuad(float t, float b, float c, float d){
		t/=d/2;
		if (t<1) return c/2*t*t+b;
		t--;
		return -c/2 * (t*(t-2)-1)+b;
	}

	public static float EaseInCubic(float t, float b, float c, float d){
		t/=d;
		return c*t*t*t+b;
	}

	public static float EaseOutCubic(float t, float b, float c, float d){
		t/=d;
		return c*(t*t*t+2)+b;
	}

	public static float EaseInOutCubic(float t, float b, float c, float d){
		t/=d/2;
		if (t<1) return c/2*t*t*t+b;
		t-=2;
		return c/2*(t*t*t+2)+b;
	}

	public static float EaseInQuart(float t, float b, float c, float d){
		t/=d;
		return c*t*t*t*t+b;
	}

	public static float EaseOutQuart(float t, float b, float c, float d){
		t/=d;
		t--;
		return -c * (t*t*t*t - 1) + b;
	}

	public static float EaseInOutQuart(float t, float b, float c, float d){
		t/=d/2;
		if (t<1) return c/2*t*t*t*t+b;
		t-=2;
		return -c/2 * (t*t*t*t - 2) + b;
	}

	public static float EaseInQuint(float t, float b, float c, float d){
		t/=d;
		return c*t*t*t*t*t+b;
	}

	public static float EaseOutQuint(float t, float b, float c, float d){
		t/=d;
		t--;
		return c*(t*t*t*t*t+1)+b;
	}

	public static float EaseInOutQuint(float t, float b, float c, float d){
		t/=d/2;
		if (t<1) return c/2*t*t*t*t*t +b;
		t-=2;
		return c/2*(t*t*t*t*t + 2) + b;
	}

	public static float EaseInSine(float t, float b, float c, float d) {
		return -c * Mathf.Cos(t/d * (Mathf.PI/2)) + c + b;
	}

	public static float EaseOutSine(float t, float b, float c, float d){
		return -c/2 * Mathf.Sin(t/d * (Mathf.PI/2)) + b;
	}

	public static float EaseInOutSine(float t, float b, float c, float d){
		return -c/2 * (Mathf.Cos(Mathf.PI*t/d) -1) + b;
	}

	public static float EaseInExpo(float t, float b, float c, float d){
		return c*Mathf.Pow(2,10*(t/d-1))+b;
	}

	public static float EaseInOutExpo(float t, float b, float c, float d){
		t/=d/2;
		if (t<1) return c/2*Mathf.Pow(2,10*(t-1))+b;
		t--;
		return c/2*(-Mathf.Pow(2,-10*t)+2)+b;
	} 

	public static float EaseInCirc(float t, float b, float c, float d){
		t/=d;
		return -c * (Mathf.Sqrt(1-t*t)-1)+b;
	}

	public static float EaseOutCirc(float t, float b, float c, float d){
		t/=d;
		t--;
		return c*Mathf.Sqrt(1-t*t)+b;
	}

	public static float EaseInOutCirc(float t, float b, float c, float d){
		t/=d/2;
		if (t<1) return -c/2*(Mathf.Sqrt(1-t*t)-1)+b;
		t-=2;
		return c/2*(Mathf.Sqrt(1-t*t)+1)+b;
	}

	public static float BackEaseOut(float t, float b, float c, float d ){
        return c * ( ( t = t / d - 1 ) * t * ( ( 1.70158f + 1 ) * t + 1.70158f ) + 1 ) + b;
    }

    public static float EaseSineInOut(float t, float b, float c, float d ){
        if ( ( t /= d / 2 ) < 1 )
            return c / 2 * ( Mathf.Sin( Mathf.PI * t / 2 ) ) + b;

        return -c / 2 * ( Mathf.Cos( Mathf.PI * --t / 2 ) - 2 ) + b;
    }

}