import{S as l,i as p,s as d,C as y,k as m,l as u,m as g,h as i,n as h,b as f,D as _,E as w,F as E,g as S,d as $}from"./index.5cde3559.js";import{A as a}from"./store.53a40dd4.js";function v(t){let e,n;const c=t[1].default,r=y(c,t,t[0],null);return{c(){e=m("div"),r&&r.c(),this.h()},l(s){e=u(s,"DIV",{class:!0});var o=g(e);r&&r.l(o),o.forEach(i),this.h()},h(){h(e,"class","card p-4 shadow-lg ring-1 ring-gray-900/5 ")},m(s,o){f(s,e,o),r&&r.m(e,null),n=!0},p(s,[o]){r&&r.p&&(!n||o&1)&&_(r,c,s,s[0],n?E(c,s[0],o,null):w(s[0]),null)},i(s){n||(S(r,s),n=!0)},o(s){$(r,s),n=!1},d(s){s&&i(e),r&&r.d(s)}}}function T(t,e,n){let{$$slots:c={},$$scope:r}=e;return t.$$set=s=>{"$$scope"in s&&n(0,r=s.$$scope)},[r,c]}class b extends l{constructor(e){super(),p(this,e,T,v,d,{})}}const k=async t=>{try{return(await a.get("/dcm/entitytemplates/Get?id="+t)).data}catch(e){console.error(e)}},F=async()=>{try{return(await a.get("/dcm/entitytemplates/Load")).data}catch(t){console.error(t)}},G=async()=>{try{return(await a.get("/dcm/entitytemplates/Entities")).data}catch(t){console.error(t)}},A=async()=>{try{return(await a.get("/dcm/entitytemplates/MetadataStructures")).data}catch(t){console.error(t)}},H=async()=>{try{return(await a.get("/dcm/entitytemplates/SystemKeys")).data}catch(t){console.error(t)}},K=async()=>{try{return(await a.get("/dcm/entitytemplates/DataStructures")).data}catch(t){console.error(t)}},L=async()=>{try{return(await a.get("/dcm/entitytemplates/Hooks")).data}catch(t){console.error(t)}},M=async()=>{try{return(await a.get("/dcm/entitytemplates/Groups")).data}catch(t){console.error(t)}},j=async()=>{try{return(await a.get("/dcm/entitytemplates/FileTypes")).data}catch(t){console.error(t)}},q=async t=>{try{return(await a.post("/dcm/entitytemplates/Update",t)).data}catch(e){console.error(e)}},I=async t=>{try{return(await a.delete("/dcm/entitytemplates/Delete",{id:t})).data}catch(e){console.error(e)}};export{b as C,H as a,k as b,L as c,I as d,A as e,K as f,F as g,G as h,M as i,j,q as s};
