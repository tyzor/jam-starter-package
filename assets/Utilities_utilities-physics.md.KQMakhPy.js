import{_ as i,c as a,a3 as e,o as n}from"./chunks/framework.TFRZ2p9Y.js";const l="/jam-starter-package/Images/physics-launcher.png",t="/jam-starter-package/Images/physics-launcher_example.gif",g=JSON.parse('{"title":"Physics","description":"","frontmatter":{},"headers":[],"relativePath":"Utilities/utilities-physics.md","filePath":"Utilities/utilities-physics.md"}'),h={name:"Utilities/utilities-physics.md"};function p(k,s,r,d,o,c){return n(),a("div",null,s[0]||(s[0]=[e('<h1 id="physics" tabindex="-1">Physics <a class="header-anchor" href="#physics" aria-label="Permalink to &quot;Physics&quot;">​</a></h1><h2 id="collisionchecks" tabindex="-1"><code>CollisionChecks</code> <a class="header-anchor" href="#collisionchecks" aria-label="Permalink to &quot;`CollisionChecks`&quot;">​</a></h2><blockquote><p><em>These implementations are based on the <a href="https:/www.jeffreythompson.org/collision-detection/circle-circle.php" target="_blank" rel="noreferrer">examples provided by Jeffery Thompson</a></em></p></blockquote><p>This static class provides simple math solutions for determining overlap of specified shapes. These will all return a <code>bool</code> value</p><ul><li>Rectangle <ul><li><code>Rect2Rect()</code></li></ul></li><li>Line <ul><li><code>Line2Line()</code></li><li><code>Line2Circle()</code></li><li><code>Line2Point()</code></li></ul></li><li>Circle <ul><li><code>Point2Circle()</code></li></ul></li><li>Point</li></ul><h2 id="physicslauncher" tabindex="-1"><code>PhysicsLauncher</code> <a class="header-anchor" href="#physicslauncher" aria-label="Permalink to &quot;`PhysicsLauncher`&quot;">​</a></h2><blockquote><p>NOTE This currently only moves on a 2D axis (X, Y)</p></blockquote><p>This <strong>struct</strong> is a helper that provides a random velocity based on the parameters set by you. The intention is that this is called elsewhere to get the information</p><p><img src="'+l+`" alt="example"></p><ul><li><code>SpawnLocation</code>: This can be retrieved to use as the spawn location, but is also used to display the gizmos</li><li><code>spawnAngle</code>: The number of degrees in either direction that the prefab can aim in <ul><li><div class="language-csharp vp-adaptive-theme"><button title="Copy Code" class="copy"></button><span class="lang">csharp</span><pre class="shiki shiki-themes github-light github-dark vp-code" tabindex="0"><code><span class="line"><span style="--shiki-light:#24292E;--shiki-dark:#E1E4E8;">Quaternion.</span><span style="--shiki-light:#6F42C1;--shiki-dark:#B392F0;">Euler</span><span style="--shiki-light:#24292E;--shiki-dark:#E1E4E8;">(</span><span style="--shiki-light:#005CC5;--shiki-dark:#79B8FF;">0f</span><span style="--shiki-light:#24292E;--shiki-dark:#E1E4E8;">, </span><span style="--shiki-light:#005CC5;--shiki-dark:#79B8FF;">0f</span><span style="--shiki-light:#24292E;--shiki-dark:#E1E4E8;">, Random.</span><span style="--shiki-light:#6F42C1;--shiki-dark:#B392F0;">Range</span><span style="--shiki-light:#24292E;--shiki-dark:#E1E4E8;">(</span><span style="--shiki-light:#D73A49;--shiki-dark:#F97583;">-</span><span style="--shiki-light:#24292E;--shiki-dark:#E1E4E8;">spawnAngle, spawnAngle)) </span><span style="--shiki-light:#D73A49;--shiki-dark:#F97583;">*</span><span style="--shiki-light:#24292E;--shiki-dark:#E1E4E8;"> spawnDirection.normalized;</span></span></code></pre></div></li></ul></li></ul><h3 id="gizmos" tabindex="-1">Gizmos <a class="header-anchor" href="#gizmos" aria-label="Permalink to &quot;Gizmos&quot;">​</a></h3><p>There is the option to display the Gizmos for this, however, it must be called outside</p><div class="language-csharp vp-adaptive-theme"><button title="Copy Code" class="copy"></button><span class="lang">csharp</span><pre class="shiki shiki-themes github-light github-dark vp-code" tabindex="0"><code><span class="line"><span style="--shiki-light:#D73A49;--shiki-dark:#F97583;">private</span><span style="--shiki-light:#D73A49;--shiki-dark:#F97583;"> void</span><span style="--shiki-light:#6F42C1;--shiki-dark:#B392F0;"> OnDrawGizmos</span><span style="--shiki-light:#24292E;--shiki-dark:#E1E4E8;">()</span></span>
<span class="line"><span style="--shiki-light:#24292E;--shiki-dark:#E1E4E8;">{</span></span>
<span class="line"><span style="--shiki-light:#24292E;--shiki-dark:#E1E4E8;">    launcher.</span><span style="--shiki-light:#6F42C1;--shiki-dark:#B392F0;">DrawGizmos</span><span style="--shiki-light:#24292E;--shiki-dark:#E1E4E8;">();</span></span>
<span class="line"><span style="--shiki-light:#24292E;--shiki-dark:#E1E4E8;">}</span></span></code></pre></div><p><img src="`+t+`" alt="example"></p><p>This example will launch a new rigidbody based prefab once every second.</p><div class="language-csharp vp-adaptive-theme"><button title="Copy Code" class="copy"></button><span class="lang">csharp</span><pre class="shiki shiki-themes github-light github-dark vp-code" tabindex="0"><code><span class="line"></span>
<span class="line"><span style="--shiki-light:#24292E;--shiki-dark:#E1E4E8;">[</span><span style="--shiki-light:#6F42C1;--shiki-dark:#B392F0;">SerializeField</span><span style="--shiki-light:#24292E;--shiki-dark:#E1E4E8;">]</span></span>
<span class="line"><span style="--shiki-light:#D73A49;--shiki-dark:#F97583;">private</span><span style="--shiki-light:#6F42C1;--shiki-dark:#B392F0;"> Rigidbody</span><span style="--shiki-light:#6F42C1;--shiki-dark:#B392F0;"> prefab</span><span style="--shiki-light:#24292E;--shiki-dark:#E1E4E8;">;</span></span>
<span class="line"><span style="--shiki-light:#24292E;--shiki-dark:#E1E4E8;">[</span><span style="--shiki-light:#6F42C1;--shiki-dark:#B392F0;">SerializeField</span><span style="--shiki-light:#24292E;--shiki-dark:#E1E4E8;">] </span></span>
<span class="line"><span style="--shiki-light:#D73A49;--shiki-dark:#F97583;">private</span><span style="--shiki-light:#6F42C1;--shiki-dark:#B392F0;"> PhysicsLauncher</span><span style="--shiki-light:#6F42C1;--shiki-dark:#B392F0;"> launcher</span><span style="--shiki-light:#24292E;--shiki-dark:#E1E4E8;">;</span></span>
<span class="line"></span>
<span class="line"><span style="--shiki-light:#D73A49;--shiki-dark:#F97583;">private</span><span style="--shiki-light:#D73A49;--shiki-dark:#F97583;"> float</span><span style="--shiki-light:#6F42C1;--shiki-dark:#B392F0;"> _time</span><span style="--shiki-light:#24292E;--shiki-dark:#E1E4E8;">;</span></span>
<span class="line"></span>
<span class="line"><span style="--shiki-light:#D73A49;--shiki-dark:#F97583;">private</span><span style="--shiki-light:#D73A49;--shiki-dark:#F97583;"> void</span><span style="--shiki-light:#6F42C1;--shiki-dark:#B392F0;"> Update</span><span style="--shiki-light:#24292E;--shiki-dark:#E1E4E8;">()</span></span>
<span class="line"><span style="--shiki-light:#24292E;--shiki-dark:#E1E4E8;">{</span></span>
<span class="line"><span style="--shiki-light:#D73A49;--shiki-dark:#F97583;">    if</span><span style="--shiki-light:#24292E;--shiki-dark:#E1E4E8;"> (_time </span><span style="--shiki-light:#D73A49;--shiki-dark:#F97583;">&lt;</span><span style="--shiki-light:#005CC5;--shiki-dark:#79B8FF;"> 1f</span><span style="--shiki-light:#24292E;--shiki-dark:#E1E4E8;">)</span></span>
<span class="line"><span style="--shiki-light:#24292E;--shiki-dark:#E1E4E8;">    {</span></span>
<span class="line"><span style="--shiki-light:#24292E;--shiki-dark:#E1E4E8;">        _time </span><span style="--shiki-light:#D73A49;--shiki-dark:#F97583;">+=</span><span style="--shiki-light:#24292E;--shiki-dark:#E1E4E8;"> Time.deltaTime;</span></span>
<span class="line"><span style="--shiki-light:#D73A49;--shiki-dark:#F97583;">        return</span><span style="--shiki-light:#24292E;--shiki-dark:#E1E4E8;">;</span></span>
<span class="line"><span style="--shiki-light:#24292E;--shiki-dark:#E1E4E8;">    }</span></span>
<span class="line"><span style="--shiki-light:#24292E;--shiki-dark:#E1E4E8;">    _time </span><span style="--shiki-light:#D73A49;--shiki-dark:#F97583;">=</span><span style="--shiki-light:#005CC5;--shiki-dark:#79B8FF;"> 0f</span><span style="--shiki-light:#24292E;--shiki-dark:#E1E4E8;">;</span></span>
<span class="line"><span style="--shiki-light:#24292E;--shiki-dark:#E1E4E8;">    </span></span>
<span class="line"><span style="--shiki-light:#D73A49;--shiki-dark:#F97583;">    var</span><span style="--shiki-light:#6F42C1;--shiki-dark:#B392F0;"> newInstance</span><span style="--shiki-light:#D73A49;--shiki-dark:#F97583;"> =</span><span style="--shiki-light:#6F42C1;--shiki-dark:#B392F0;"> Instantiate</span><span style="--shiki-light:#24292E;--shiki-dark:#E1E4E8;">(prefab, transform.position, Quaternion.identity);</span></span>
<span class="line"><span style="--shiki-light:#24292E;--shiki-dark:#E1E4E8;">    newInstance.velocity </span><span style="--shiki-light:#D73A49;--shiki-dark:#F97583;">=</span><span style="--shiki-light:#24292E;--shiki-dark:#E1E4E8;"> launcher.</span><span style="--shiki-light:#6F42C1;--shiki-dark:#B392F0;">GetLaunchVelocity</span><span style="--shiki-light:#24292E;--shiki-dark:#E1E4E8;">();</span></span>
<span class="line"><span style="--shiki-light:#24292E;--shiki-dark:#E1E4E8;">}</span></span></code></pre></div>`,16)]))}const y=i(h,[["render",p]]);export{g as __pageData,y as default};