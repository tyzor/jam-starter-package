import{_ as i,c as a,a3 as e,o as t}from"./chunks/framework.TFRZ2p9Y.js";const n="/jam-starter-package/Images/draw-label.png",l="/jam-starter-package/Images/draw-circle.png",h="/jam-starter-package/Images/draw-arrow.png",y=JSON.parse('{"title":"Draw.cs","description":"","frontmatter":{},"headers":[],"relativePath":"Utilities/utilities-draw.md","filePath":"Utilities/utilities-draw.md"}'),r={name:"Utilities/utilities-draw.md"};function p(k,s,o,d,E,c){return t(),a("div",null,s[0]||(s[0]=[e('<h1 id="draw-cs" tabindex="-1"><code>Draw.cs</code> <a class="header-anchor" href="#draw-cs" aria-label="Permalink to &quot;`Draw.cs`&quot;">​</a></h1><p>This class extends the existing Debug.Draw methods to include</p><h2 id="label" tabindex="-1">Label <a class="header-anchor" href="#label" aria-label="Permalink to &quot;Label&quot;">​</a></h2><p><img src="'+n+`" alt="example"></p><p>This can only be called from <a href="https:/docs.unity3d.com/6000.0/Documentation/ScriptReference/MonoBehaviour.OnDrawGizmos.html" target="_blank" rel="noreferrer"><code>OnDrawGizmos()</code></a> or <a href="https:/docs.unity3d.com/6000.0/Documentation/ScriptReference/MonoBehaviour.OnDrawGizmosSelected.html" target="_blank" rel="noreferrer"><code>OnDrawGizmosSelected()</code></a> as this uses the UnityEditor.Handles class to draw the text.</p><ul><li><code>Offset</code>: This represents the distance the text should move to the right. <em>You can apply a negative number to move the label to the left.</em></li></ul><div class="language-csharp vp-adaptive-theme"><button title="Copy Code" class="copy"></button><span class="lang">csharp</span><pre class="shiki shiki-themes github-light github-dark vp-code" tabindex="0"><code><span class="line"><span style="--shiki-light:#D73A49;--shiki-dark:#F97583;">private</span><span style="--shiki-light:#D73A49;--shiki-dark:#F97583;"> void</span><span style="--shiki-light:#6F42C1;--shiki-dark:#B392F0;"> OnDrawGizmos</span><span style="--shiki-light:#24292E;--shiki-dark:#E1E4E8;">()</span></span>
<span class="line"><span style="--shiki-light:#24292E;--shiki-dark:#E1E4E8;">{</span></span>
<span class="line"><span style="--shiki-light:#24292E;--shiki-dark:#E1E4E8;">    Draw.</span><span style="--shiki-light:#6F42C1;--shiki-dark:#B392F0;">Label</span><span style="--shiki-light:#24292E;--shiki-dark:#E1E4E8;">(Vector3.zero, </span><span style="--shiki-light:#032F62;--shiki-dark:#9ECBFF;">&quot;Vector3.zero&quot;</span><span style="--shiki-light:#24292E;--shiki-dark:#E1E4E8;">);</span></span>
<span class="line"><span style="--shiki-light:#24292E;--shiki-dark:#E1E4E8;">    Draw.</span><span style="--shiki-light:#6F42C1;--shiki-dark:#B392F0;">Label</span><span style="--shiki-light:#24292E;--shiki-dark:#E1E4E8;">(Vector3.up, </span><span style="--shiki-light:#032F62;--shiki-dark:#9ECBFF;">&quot;Vector3.up&quot;</span><span style="--shiki-light:#24292E;--shiki-dark:#E1E4E8;">, </span><span style="--shiki-light:#6F42C1;--shiki-dark:#B392F0;">offset</span><span style="--shiki-light:#24292E;--shiki-dark:#E1E4E8;">: </span><span style="--shiki-light:#005CC5;--shiki-dark:#79B8FF;">0f</span><span style="--shiki-light:#24292E;--shiki-dark:#E1E4E8;">);</span></span>
<span class="line"><span style="--shiki-light:#24292E;--shiki-dark:#E1E4E8;">    Draw.</span><span style="--shiki-light:#6F42C1;--shiki-dark:#B392F0;">Label</span><span style="--shiki-light:#24292E;--shiki-dark:#E1E4E8;">(Vector3.up, </span><span style="--shiki-light:#032F62;--shiki-dark:#9ECBFF;">&quot;Vector3.up&quot;</span><span style="--shiki-light:#24292E;--shiki-dark:#E1E4E8;">, </span><span style="--shiki-light:#6F42C1;--shiki-dark:#B392F0;">offset</span><span style="--shiki-light:#24292E;--shiki-dark:#E1E4E8;">: </span><span style="--shiki-light:#005CC5;--shiki-dark:#79B8FF;">1f</span><span style="--shiki-light:#24292E;--shiki-dark:#E1E4E8;">);</span></span>
<span class="line"><span style="--shiki-light:#24292E;--shiki-dark:#E1E4E8;">}</span></span></code></pre></div><h2 id="circle" tabindex="-1">Circle <a class="header-anchor" href="#circle" aria-label="Permalink to &quot;Circle&quot;">​</a></h2><blockquote><p><em><strong>NOTE</strong> This currently only faces the forward direction</em></p></blockquote><p><img src="`+l+`" alt="example"></p><div class="language-csharp vp-adaptive-theme"><button title="Copy Code" class="copy"></button><span class="lang">csharp</span><pre class="shiki shiki-themes github-light github-dark vp-code" tabindex="0"><code><span class="line"><span style="--shiki-light:#24292E;--shiki-dark:#E1E4E8;">Draw.</span><span style="--shiki-light:#6F42C1;--shiki-dark:#B392F0;">Circle</span><span style="--shiki-light:#24292E;--shiki-dark:#E1E4E8;">(Vector3.zero, Color.green);</span></span>
<span class="line"><span style="--shiki-light:#24292E;--shiki-dark:#E1E4E8;">Draw.</span><span style="--shiki-light:#6F42C1;--shiki-dark:#B392F0;">Circle</span><span style="--shiki-light:#24292E;--shiki-dark:#E1E4E8;">(Vector3.zero, Color.blue, </span><span style="--shiki-light:#6F42C1;--shiki-dark:#B392F0;">radius</span><span style="--shiki-light:#24292E;--shiki-dark:#E1E4E8;">: </span><span style="--shiki-light:#005CC5;--shiki-dark:#79B8FF;">0.5f</span><span style="--shiki-light:#24292E;--shiki-dark:#E1E4E8;">);</span></span>
<span class="line"><span style="--shiki-light:#24292E;--shiki-dark:#E1E4E8;">Draw.</span><span style="--shiki-light:#6F42C1;--shiki-dark:#B392F0;">Circle</span><span style="--shiki-light:#24292E;--shiki-dark:#E1E4E8;">(Vector3.zero, Color.red, </span><span style="--shiki-light:#6F42C1;--shiki-dark:#B392F0;">radius</span><span style="--shiki-light:#24292E;--shiki-dark:#E1E4E8;">: </span><span style="--shiki-light:#005CC5;--shiki-dark:#79B8FF;">1.5f</span><span style="--shiki-light:#24292E;--shiki-dark:#E1E4E8;">, </span><span style="--shiki-light:#6F42C1;--shiki-dark:#B392F0;">segments</span><span style="--shiki-light:#24292E;--shiki-dark:#E1E4E8;">: </span><span style="--shiki-light:#005CC5;--shiki-dark:#79B8FF;">32</span><span style="--shiki-light:#24292E;--shiki-dark:#E1E4E8;">);</span></span></code></pre></div><h2 id="arrow" tabindex="-1">Arrow <a class="header-anchor" href="#arrow" aria-label="Permalink to &quot;Arrow&quot;">​</a></h2><p><img src="`+h+`" alt="example"></p><div class="language-csharp vp-adaptive-theme"><button title="Copy Code" class="copy"></button><span class="lang">csharp</span><pre class="shiki shiki-themes github-light github-dark vp-code" tabindex="0"><code><span class="line"><span style="--shiki-light:#24292E;--shiki-dark:#E1E4E8;">Draw.</span><span style="--shiki-light:#6F42C1;--shiki-dark:#B392F0;">Arrow</span><span style="--shiki-light:#24292E;--shiki-dark:#E1E4E8;">(Vector3.zero, </span><span style="--shiki-light:#6F42C1;--shiki-dark:#B392F0;">direction</span><span style="--shiki-light:#24292E;--shiki-dark:#E1E4E8;">: Vector3.up, Color.green);</span></span>
<span class="line"><span style="--shiki-light:#24292E;--shiki-dark:#E1E4E8;">Draw.</span><span style="--shiki-light:#6F42C1;--shiki-dark:#B392F0;">Arrow</span><span style="--shiki-light:#24292E;--shiki-dark:#E1E4E8;">(Vector3.zero, </span><span style="--shiki-light:#6F42C1;--shiki-dark:#B392F0;">direction</span><span style="--shiki-light:#24292E;--shiki-dark:#E1E4E8;">: Vector3.forward, Color.blue);</span></span>
<span class="line"><span style="--shiki-light:#24292E;--shiki-dark:#E1E4E8;">Draw.</span><span style="--shiki-light:#6F42C1;--shiki-dark:#B392F0;">Arrow</span><span style="--shiki-light:#24292E;--shiki-dark:#E1E4E8;">(Vector3.zero, </span><span style="--shiki-light:#6F42C1;--shiki-dark:#B392F0;">direction</span><span style="--shiki-light:#24292E;--shiki-dark:#E1E4E8;">: Vector3.right, Color.red);</span></span></code></pre></div>`,14)]))}const u=i(r,[["render",p]]);export{y as __pageData,u as default};