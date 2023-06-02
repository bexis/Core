import{A as ze,s as Ge}from"../chunks/ProgressBar.svelte_svelte_type_style_lang.f6568725.js";import{S as $,i as ee,s as te,C as fe,k as T,a as U,l as A,m as V,h as g,c as z,n as v,b as E,G as D,K as H,D as ue,E as ce,F as de,g as P,v as be,d as S,f as he,L as Ve,ad as Se,ai as F,R as Q,ah as ne,M as G,a2 as Ke,ab as ge,T as Be,ag as me,aj as W,w as je,q as B,e as X,r as j,H as ie,P as pe,u as J,y as ae,z as se,A as oe,B as re,o as Fe,V as We,U as Je,W as Qe}from"../chunks/index.83db4375.js";const Xe=l=>({}),ve=l=>({});function ke(l){let e,t,r;const i=l[17].panel,f=fe(i,l,l[16],ve);return{c(){e=T("div"),f&&f.c(),this.h()},l(n){e=A(n,"DIV",{class:!0,role:!0,"aria-labelledby":!0,tabindex:!0});var s=V(e);f&&f.l(s),s.forEach(g),this.h()},h(){v(e,"class",t="tab-panel "+l[2]),v(e,"role","tabpanel"),v(e,"aria-labelledby",l[1]),v(e,"tabindex","0")},m(n,s){E(n,e,s),f&&f.m(e,null),r=!0},p(n,s){f&&f.p&&(!r||s&65536)&&ue(f,i,n,n[16],r?de(i,n[16],s,Xe):ce(n[16]),ve),(!r||s&4&&t!==(t="tab-panel "+n[2]))&&v(e,"class",t),(!r||s&2)&&v(e,"aria-labelledby",n[1])},i(n){r||(P(f,n),r=!0)},o(n){S(f,n),r=!1},d(n){n&&g(e),f&&f.d(n)}}}function Ye(l){let e,t,r,i,f,n,s,a;const o=l[17].default,c=fe(o,l,l[16],null);let u=l[5].panel&&ke(l);return{c(){e=T("div"),t=T("div"),c&&c.c(),i=U(),u&&u.c(),this.h()},l(b){e=A(b,"DIV",{class:!0,"data-testid":!0});var d=V(e);t=A(d,"DIV",{class:!0,role:!0,"aria-labelledby":!0});var k=V(t);c&&c.l(k),k.forEach(g),i=z(d),u&&u.l(d),d.forEach(g),this.h()},h(){v(t,"class",r="tab-list "+l[3]),v(t,"role","tablist"),v(t,"aria-labelledby",l[0]),v(e,"class",f="tab-group "+l[4]),v(e,"data-testid","tab-group")},m(b,d){E(b,e,d),D(e,t),c&&c.m(t,null),D(e,i),u&&u.m(e,null),n=!0,s||(a=[H(e,"click",l[18]),H(e,"keypress",l[19]),H(e,"keydown",l[20]),H(e,"keyup",l[21])],s=!0)},p(b,[d]){c&&c.p&&(!n||d&65536)&&ue(c,o,b,b[16],n?de(o,b[16],d,null):ce(b[16]),null),(!n||d&8&&r!==(r="tab-list "+b[3]))&&v(t,"class",r),(!n||d&1)&&v(t,"aria-labelledby",b[0]),b[5].panel?u?(u.p(b,d),d&32&&P(u,1)):(u=ke(b),u.c(),P(u,1),u.m(e,null)):u&&(be(),S(u,1,1,()=>{u=null}),he()),(!n||d&16&&f!==(f="tab-group "+b[4]))&&v(e,"class",f)},i(b){n||(P(c,b),P(u),n=!0)},o(b){S(c,b),S(u),n=!1},d(b){b&&g(e),c&&c.d(b),u&&u.d(),s=!1,Ve(a)}}}const Ze="space-y-4",we="flex overflow-x-auto hide-scrollbar",xe="";function $e(l,e,t){let r,i,f,{$$slots:n={},$$scope:s}=e;const a=Se(n);let{justify:o="justify-start"}=e,{border:c="border-b border-surface-400-500-token"}=e,{active:u="border-b-2 border-surface-900-50-token"}=e,{hover:b="hover:variant-soft"}=e,{flex:d="flex-none"}=e,{padding:k="px-4 py-2"}=e,{rounded:p="rounded-tl-container-token rounded-tr-container-token"}=e,{spacing:N="space-y-1"}=e,{regionList:C=""}=e,{regionPanel:y=""}=e,{labelledby:R=""}=e,{panel:L=""}=e;F("active",u),F("hover",b),F("flex",d),F("padding",k),F("rounded",p),F("spacing",N);function m(_){G.call(this,l,_)}function I(_){G.call(this,l,_)}function M(_){G.call(this,l,_)}function q(_){G.call(this,l,_)}return l.$$set=_=>{t(22,e=Q(Q({},e),ne(_))),"justify"in _&&t(6,o=_.justify),"border"in _&&t(7,c=_.border),"active"in _&&t(8,u=_.active),"hover"in _&&t(9,b=_.hover),"flex"in _&&t(10,d=_.flex),"padding"in _&&t(11,k=_.padding),"rounded"in _&&t(12,p=_.rounded),"spacing"in _&&t(13,N=_.spacing),"regionList"in _&&t(14,C=_.regionList),"regionPanel"in _&&t(15,y=_.regionPanel),"labelledby"in _&&t(0,R=_.labelledby),"panel"in _&&t(1,L=_.panel),"$$scope"in _&&t(16,s=_.$$scope)},l.$$.update=()=>{t(4,r=`${Ze} ${e.class??""}`),l.$$.dirty&16576&&t(3,i=`${we} ${o} ${c} ${C}`),l.$$.dirty&32768&&t(2,f=`${xe} ${y}`)},e=ne(e),[R,L,f,i,r,a,o,c,u,b,d,k,p,N,C,y,s,n,m,I,M,q]}class et extends ${constructor(e){super(),ee(this,e,$e,Ye,te,{justify:6,border:7,active:8,hover:9,flex:10,padding:11,rounded:12,spacing:13,regionList:14,regionPanel:15,labelledby:0,panel:1})}}const tt=l=>({}),ye=l=>({});function Ie(l){let e,t;const r=l[21].lead,i=fe(r,l,l[20],ye);return{c(){e=T("div"),i&&i.c(),this.h()},l(f){e=A(f,"DIV",{class:!0});var n=V(e);i&&i.l(n),n.forEach(g),this.h()},h(){v(e,"class","tab-lead")},m(f,n){E(f,e,n),i&&i.m(e,null),t=!0},p(f,n){i&&i.p&&(!t||n[0]&1048576)&&ue(i,r,f,f[20],t?de(r,f[20],n,tt):ce(f[20]),ye)},i(f){t||(P(i,f),t=!0)},o(f){S(i,f),t=!1},d(f){f&&g(e),i&&i.d(f)}}}function lt(l){let e,t,r,i,f,n,s,a,o,c,u,b,d,k,p,N=[{type:"radio"},{name:l[1]},{__value:l[2]},l[10](),{tabindex:"-1"}],C={};for(let m=0;m<N.length;m+=1)C=Q(C,N[m]);let y=l[11].lead&&Ie(l);const R=l[21].default,L=fe(R,l,l[20],null);return d=Ke(l[29][0]),{c(){e=T("label"),t=T("div"),r=T("div"),i=T("input"),f=U(),n=T("div"),y&&y.c(),s=U(),a=T("div"),L&&L.c(),this.h()},l(m){e=A(m,"LABEL",{class:!0});var I=V(e);t=A(I,"DIV",{class:!0,"data-testid":!0,role:!0,"aria-controls":!0,"aria-selected":!0,tabindex:!0});var M=V(t);r=A(M,"DIV",{class:!0});var q=V(r);i=A(q,"INPUT",{type:!0,name:!0,tabindex:!0}),q.forEach(g),f=z(M),n=A(M,"DIV",{class:!0});var _=V(n);y&&y.l(_),s=z(_),a=A(_,"DIV",{class:!0});var le=V(a);L&&L.l(le),le.forEach(g),_.forEach(g),M.forEach(g),I.forEach(g),this.h()},h(){ge(i,C),v(r,"class","h-0 w-0 overflow-hidden"),v(a,"class","tab-label"),v(n,"class",o="tab-interface "+l[7]),v(t,"class",c="tab "+l[6]),v(t,"data-testid","tab"),v(t,"role","tab"),v(t,"aria-controls",l[3]),v(t,"aria-selected",l[4]),v(t,"tabindex",u=l[4]?0:-1),v(e,"class",l[8]),d.p(i)},m(m,I){E(m,e,I),D(e,t),D(t,r),D(r,i),i.autofocus&&i.focus(),l[27](i),i.checked=i.__value===l[0],D(t,f),D(t,n),y&&y.m(n,null),D(n,s),D(n,a),L&&L.m(a,null),b=!0,k||(p=[H(i,"change",l[28]),H(i,"click",l[25]),H(i,"change",l[26]),H(t,"keydown",l[9]),H(t,"keydown",l[22]),H(t,"keyup",l[23]),H(t,"keypress",l[24])],k=!0)},p(m,I){ge(i,C=Be(N,[{type:"radio"},(!b||I[0]&2)&&{name:m[1]},(!b||I[0]&4)&&{__value:m[2]},m[10](),{tabindex:"-1"}])),I[0]&1&&(i.checked=i.__value===m[0]),m[11].lead?y?(y.p(m,I),I[0]&2048&&P(y,1)):(y=Ie(m),y.c(),P(y,1),y.m(n,s)):y&&(be(),S(y,1,1,()=>{y=null}),he()),L&&L.p&&(!b||I[0]&1048576)&&ue(L,R,m,m[20],b?de(R,m[20],I,null):ce(m[20]),null),(!b||I[0]&128&&o!==(o="tab-interface "+m[7]))&&v(n,"class",o),(!b||I[0]&64&&c!==(c="tab "+m[6]))&&v(t,"class",c),(!b||I[0]&8)&&v(t,"aria-controls",m[3]),(!b||I[0]&16)&&v(t,"aria-selected",m[4]),(!b||I[0]&16&&u!==(u=m[4]?0:-1))&&v(t,"tabindex",u),(!b||I[0]&256)&&v(e,"class",m[8])},i(m){b||(P(y),P(L,m),b=!0)},o(m){S(y),S(L,m),b=!1},d(m){m&&g(e),l[27](null),y&&y.d(),L&&L.d(m),d.r(),k=!1,Ve(p)}}}const nt="text-center cursor-pointer transition-colors duration-100",it="";function at(l,e,t){let r,i,f,n,s;const a=["group","name","value","controls","regionTab","active","hover","flex","padding","rounded","spacing"];let o=me(e,a),{$$slots:c={},$$scope:u}=e;const b=Se(c);let{group:d}=e,{name:k}=e,{value:p}=e,{controls:N=""}=e,{regionTab:C=""}=e,{active:y=W("active")}=e,{hover:R=W("hover")}=e,{flex:L=W("flex")}=e,{padding:m=W("padding")}=e,{rounded:I=W("rounded")}=e,{spacing:M=W("spacing")}=e,q;function _(h){if(["Enter","Space"].includes(h.code))h.preventDefault(),q.click();else if(h.code==="ArrowRight"){const Y=q.closest(".tab-list");if(!Y)return;const K=Array.from(Y.querySelectorAll(".tab")),Z=q.closest(".tab");if(!Z)return;const w=K.indexOf(Z),_e=w+1>=K.length?0:w+1,O=K[_e],x=O==null?void 0:O.querySelector("input");O&&x&&(x.click(),O.focus())}else if(h.code==="ArrowLeft"){const Y=q.closest(".tab-list");if(!Y)return;const K=Array.from(Y.querySelectorAll(".tab")),Z=q.closest(".tab");if(!Z)return;const w=K.indexOf(Z),_e=w-1<0?K.length-1:w-1,O=K[_e],x=O==null?void 0:O.querySelector("input");O&&x&&(x.click(),O.focus())}}function le(){return delete o.class,o}const Ne=[[]];function qe(h){G.call(this,l,h)}function Ce(h){G.call(this,l,h)}function He(h){G.call(this,l,h)}function Oe(h){G.call(this,l,h)}function Re(h){G.call(this,l,h)}function Me(h){je[h?"unshift":"push"](()=>{q=h,t(5,q)})}function Ue(){d=this.__value,t(0,d)}return l.$$set=h=>{t(31,e=Q(Q({},e),ne(h))),t(30,o=me(e,a)),"group"in h&&t(0,d=h.group),"name"in h&&t(1,k=h.name),"value"in h&&t(2,p=h.value),"controls"in h&&t(3,N=h.controls),"regionTab"in h&&t(12,C=h.regionTab),"active"in h&&t(13,y=h.active),"hover"in h&&t(14,R=h.hover),"flex"in h&&t(15,L=h.flex),"padding"in h&&t(16,m=h.padding),"rounded"in h&&t(17,I=h.rounded),"spacing"in h&&t(18,M=h.spacing),"$$scope"in h&&t(20,u=h.$$scope)},l.$$.update=()=>{l.$$.dirty[0]&5&&t(4,r=p===d),l.$$.dirty[0]&24592&&t(19,i=r?y:R),t(8,f=`${nt} ${L} ${m} ${I} ${i} ${e.class??""}`),l.$$.dirty[0]&262144&&t(7,n=`${it} ${M}`),l.$$.dirty[0]&4096&&t(6,s=`${C}`)},e=ne(e),[d,k,p,N,r,q,s,n,f,_,le,b,C,y,R,L,m,I,M,i,u,c,qe,Ce,He,Oe,Re,Me,Ue,Ne]}class st extends ${constructor(e){super(),ee(this,e,at,lt,te,{group:0,name:1,value:2,controls:3,regionTab:12,active:13,hover:14,flex:15,padding:16,rounded:17,spacing:18},null,[-1,-1])}}function Ee(l,e,t){const r=l.slice();return r[3]=e[t],r}function De(l){let e,t,r,i,f,n,s=l[0],a=[];for(let o=0;o<s.length;o+=1)a[o]=Le(Ee(l,s,o));return{c(){e=T("hr"),t=U(),r=T("b"),i=B("debug infos:"),f=U();for(let o=0;o<a.length;o+=1)a[o].c();n=X()},l(o){e=A(o,"HR",{}),t=z(o),r=A(o,"B",{});var c=V(r);i=j(c,"debug infos:"),c.forEach(g),f=z(o);for(let u=0;u<a.length;u+=1)a[u].l(o);n=X()},m(o,c){E(o,e,c),E(o,t,c),E(o,r,c),D(r,i),E(o,f,c);for(let u=0;u<a.length;u+=1)a[u]&&a[u].m(o,c);E(o,n,c)},p(o,c){if(c&1){s=o[0];let u;for(u=0;u<s.length;u+=1){const b=Ee(o,s,u);a[u]?a[u].p(b,c):(a[u]=Le(b),a[u].c(),a[u].m(n.parentNode,n))}for(;u<a.length;u+=1)a[u].d(1);a.length=s.length}},d(o){o&&g(e),o&&g(t),o&&g(r),o&&g(f),pe(a,o),o&&g(n)}}}function Le(l){let e,t=l[3].name+"",r,i,f=l[3].displayName+"",n,s,a=l[3].status+"",o;return{c(){e=T("p"),r=B(t),i=B("|"),n=B(f),s=B("| Status : "),o=B(a)},l(c){e=A(c,"P",{});var u=V(e);r=j(u,t),i=j(u,"|"),n=j(u,f),s=j(u,"| Status : "),o=j(u,a),u.forEach(g)},m(c,u){E(c,e,u),D(e,r),D(e,i),D(e,n),D(e,s),D(e,o)},p(c,u){u&1&&t!==(t=c[3].name+"")&&J(r,t),u&1&&f!==(f=c[3].displayName+"")&&J(n,f),u&1&&a!==(a=c[3].status+"")&&J(o,a)},d(c){c&&g(e)}}}function ot(l){let e,t,r,i,f,n,s,a=l[0]&&l[1]&&De(l);return{c(){e=T("label"),t=T("input"),r=B(`\r
	show debug information`),i=U(),a&&a.c(),f=X(),this.h()},l(o){e=A(o,"LABEL",{});var c=V(e);t=A(c,"INPUT",{type:!0}),r=j(c,`\r
	show debug information`),c.forEach(g),i=z(o),a&&a.l(o),f=X(),this.h()},h(){v(t,"type","checkbox")},m(o,c){E(o,e,c),D(e,t),t.checked=l[1],D(e,r),E(o,i,c),a&&a.m(o,c),E(o,f,c),n||(s=H(t,"change",l[2]),n=!0)},p(o,[c]){c&2&&(t.checked=o[1]),o[0]&&o[1]?a?a.p(o,c):(a=De(o),a.c(),a.m(f.parentNode,f)):a&&(a.d(1),a=null)},i:ie,o:ie,d(o){o&&g(e),o&&g(i),a&&a.d(o),o&&g(f),n=!1,s()}}}function rt(l,e,t){let{hooks:r}=e,i=!1;function f(){i=this.checked,t(1,i)}return l.$$set=n=>{"hooks"in n&&t(0,r=n.hooks)},[r,i,f]}class ft extends ${constructor(e){super(),ee(this,e,rt,ot,te,{hooks:0})}}const ut=async l=>{try{return(await ze.get("/dcm/view/load?id="+l)).data}catch(e){console.error(e)}},ct=async()=>(Ge("https://localhost:44345","davidschoene","123456"),console.log("id",window.view.id),{model:await ut(6)}),yt=Object.freeze(Object.defineProperty({__proto__:null,load:ct},Symbol.toStringTag,{value:"Module"}));function dt(l){let e,t,r,i,f,n,s,a,o,c,u,b;return{c(){e=T("h1"),t=B(l[2]),r=B(`\r
Dataset Id: `),i=B(l[0]),f=B(`\r
Version: `),n=B(l[1]),s=U(),a=T("b"),o=B("version selection"),c=U(),u=T("b"),b=B("download")},l(d){e=A(d,"H1",{});var k=V(e);t=j(k,l[2]),k.forEach(g),r=j(d,`\r
Dataset Id: `),i=j(d,l[0]),f=j(d,`\r
Version: `),n=j(d,l[1]),s=z(d),a=A(d,"B",{});var p=V(a);o=j(p,"version selection"),p.forEach(g),c=z(d),u=A(d,"B",{});var N=V(u);b=j(N,"download"),N.forEach(g)},m(d,k){E(d,e,k),D(e,t),E(d,r,k),E(d,i,k),E(d,f,k),E(d,n,k),E(d,s,k),E(d,a,k),D(a,o),E(d,c,k),E(d,u,k),D(u,b)},p(d,[k]){k&4&&J(t,d[2]),k&1&&J(i,d[0]),k&2&&J(n,d[1])},i:ie,o:ie,d(d){d&&g(e),d&&g(r),d&&g(i),d&&g(f),d&&g(n),d&&g(s),d&&g(a),d&&g(c),d&&g(u)}}}function bt(l,e,t){let{id:r}=e,{version:i}=e,{title:f=""}=e;return l.$$set=n=>{"id"in n&&t(0,r=n.id),"version"in n&&t(1,i=n.version),"title"in n&&t(2,f=n.title)},[r,i,f]}class ht extends ${constructor(e){super(),ee(this,e,bt,dt,te,{id:0,version:1,title:2})}}function Pe(l,e,t){const r=l.slice();return r[11]=e[t],r[13]=t,r}function Te(l){let e,t;return e=new et({props:{$$slots:{default:[_t]},$$scope:{ctx:l}}}),{c(){ae(e.$$.fragment)},l(r){se(e.$$.fragment,r)},m(r,i){oe(e,r,i),t=!0},p(r,i){const f={};i&16414&&(f.$$scope={dirty:i,ctx:r}),e.$set(f)},i(r){t||(P(e.$$.fragment,r),t=!0)},o(r){S(e.$$.fragment,r),t=!1},d(r){re(e,r)}}}function Ae(l){let e,t,r;const i=[{id:l[2]},{version:l[1]},l[11],{value:l[13]}];function f(s){l[6](s)}let n={};for(let s=0;s<i.length;s+=1)n=Q(n,i[s]);return l[3]!==void 0&&(n.group=l[3]),e=new st({props:n}),je.push(()=>We(e,"group",f)),{c(){ae(e.$$.fragment)},l(s){se(e.$$.fragment,s)},m(s,a){oe(e,s,a),r=!0},p(s,a){const o=a&22?Be(i,[a&4&&{id:s[2]},a&2&&{version:s[1]},a&16&&Je(s[11]),i[3]]):{};!t&&a&8&&(t=!0,o.group=s[3],Qe(()=>t=!1)),e.$set(o)},i(s){r||(P(e.$$.fragment,s),r=!0)},o(s){S(e.$$.fragment,s),r=!1},d(s){re(e,s)}}}function _t(l){let e,t,r=l[4],i=[];for(let n=0;n<r.length;n+=1)i[n]=Ae(Pe(l,r,n));const f=n=>S(i[n],1,1,()=>{i[n]=null});return{c(){for(let n=0;n<i.length;n+=1)i[n].c();e=X()},l(n){for(let s=0;s<i.length;s+=1)i[s].l(n);e=X()},m(n,s){for(let a=0;a<i.length;a+=1)i[a]&&i[a].m(n,s);E(n,e,s),t=!0},p(n,s){if(s&30){r=n[4];let a;for(a=0;a<r.length;a+=1){const o=Pe(n,r,a);i[a]?(i[a].p(o,s),P(i[a],1)):(i[a]=Ae(o),i[a].c(),P(i[a],1),i[a].m(e.parentNode,e))}for(be(),a=r.length;a<i.length;a+=1)f(a);he()}},i(n){if(!t){for(let s=0;s<r.length;s+=1)P(i[s]);t=!0}},o(n){i=i.filter(Boolean);for(let s=0;s<i.length;s+=1)S(i[s]);t=!1},d(n){pe(i,n),n&&g(e)}}}function gt(l){let e,t,r,i,f,n;t=new ht({props:{id:l[2],version:l[1],title:l[0]}});let s=l[4]&&Te(l);return f=new ft({props:{hooks:l[4]}}),{c(){e=T("div"),ae(t.$$.fragment),r=U(),s&&s.c(),i=U(),ae(f.$$.fragment)},l(a){e=A(a,"DIV",{});var o=V(e);se(t.$$.fragment,o),r=z(o),s&&s.l(o),i=z(o),se(f.$$.fragment,o),o.forEach(g)},m(a,o){E(a,e,o),oe(t,e,null),D(e,r),s&&s.m(e,null),D(e,i),oe(f,e,null),n=!0},p(a,[o]){const c={};o&4&&(c.id=a[2]),o&2&&(c.version=a[1]),o&1&&(c.title=a[0]),t.$set(c),a[4]?s?(s.p(a,o),o&16&&P(s,1)):(s=Te(a),s.c(),P(s,1),s.m(e,i)):s&&(be(),S(s,1,1,()=>{s=null}),he());const u={};o&16&&(u.hooks=a[4]),f.$set(u)},i(a){n||(P(t.$$.fragment,a),P(s),P(f.$$.fragment,a),n=!0)},o(a){S(t.$$.fragment,a),S(s),S(f.$$.fragment,a),n=!1},d(a){a&&g(e),re(t),s&&s.d(),re(f)}}}function mt(l,e,t){let r,{data:i}=e,f;f=i.model;let n="",s,a,o=0,c;Fe(async()=>{console.log("onmount",f),t(4,r=f.hooks),t(0,n=f.title),t(1,s=f.version),t(2,a=f.id),console.log(f)});function u(b){o=b,t(3,o)}return l.$$set=b=>{"data"in b&&t(5,i=b.data)},t(4,r=c),[n,s,a,o,r,i,u]}class It extends ${constructor(e){super(),ee(this,e,mt,gt,te,{data:5})}}export{It as component,yt as universal};
