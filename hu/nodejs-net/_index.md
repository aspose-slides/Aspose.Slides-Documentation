---
title: Aspose.Slides for Node.js via .NET
second_title: Aspose.Slides for Node.js
type: docs
weight: 47
url: /hu/nodejs-net/
keywords:
- dokumentáció
- prezentációfeldolgozás
- prezentációkonverzió
- PowerPoint
- OpenDocument
- Node.js
- JavaScript
- Aspose.Slides
description: "Kezdje itt: telepítse az Aspose.Slides for Node.js via .NET‑t, hozza létre az első prezentációt, és találja meg az útmutatókat a gyakori feladatokhoz, a licenceléshez, az API referenciához és a támogatáshoz."
is_root: true
---
<img src="aspose_slides-for-nodejs-via-net.png" alt="Aspose.Slides for Node.js via .NET" align="left" style="width:110px; margin: 0 30px 20px 0"/>

Az Aspose.Slides for Node.js via .NET egy könyvtár PowerPoint és OpenDocument prezentációk létrehozásához, olvasásához, szerkesztéséhez és konvertálásához Node.js alkalmazásokban, Microsoft PowerPoint vagy Office Automation nélkül. Az edge-js hídon keresztül futtatja az Aspose.Slides for .NET‑et, így JavaScript API-ja tükrözi a .NET API‑t, camelCase tagnevekkel.

Betölti és menti a PPT, PPTX, PPS, POT és ODP formátumokat, beleértve a makró‑támogatott és sablon változatokat is, valamint exportál PDF, XPS, HTML, TIFF, Markdown és képek formátumba.

<div style="clear:both"></div>

------

<div class="row">
<div class="col-md-4">
<p><b>Első lépések</b></p>
<hr>
<p>GETTING STARTED</p>
<ul>
<li><a href="/slides/hu/nodejs-net/installation/">Telepítés</a></li>
<li><a href="/slides/hu/nodejs-net/create-presentation/">Az első prezentáció létrehozása</a></li>
<li><a href="/slides/hu/nodejs-net/developer-guide/">Fejlesztői útmutató</a></li>
</ul>
<p>EVALUATE</p>
<ul>
<li><a href="/slides/hu/nodejs-net/evaluate-aspose-slides/">Próba korlátozások</a></li>
<li><a href="/slides/hu/nodejs-net/licensing/">Licencelés</a></li>
</ul>
</div>
<div class="col-md-4">
<p><b>Slides használata</b></p>
<hr>
<p>COMMON TASKS</p>
<ul>
<li><a href="/slides/hu/nodejs-net/open-presentation/">Prezentáció megnyitása és mentése</a></li>
<li><a href="/slides/hu/nodejs-net/convert-powerpoint-to-pdf/">Konvertálás PDF‑be</a></li>
<li><a href="/slides/hu/nodejs-net/convert-slide/">Dia képpé konvertálása</a></li>
<li><a href="/slides/hu/nodejs-net/manage-text/">Szöveg szerkesztése</a></li>
</ul>
</div>
<div class="col-md-4">
<p><b>Referenciák &amp; támogatás</b></p>
<hr>
<p>REFERENCE</p>
<ul>
<li><a href="https://reference.aspose.com/slides/hu/net/">.NET API referencia</a></li>
<li><a href="https://releases.aspose.com/slides/hu/nodejs-net/release-notes/">Kiadási megjegyzések</a></li>
<li><a href="https://releases.aspose.com/slides/hu/nodejs-net/">Letöltés</a></li>
</ul>
<p>SUPPORT</p>
<ul>
<li><a href="https://forum.aspose.com/c/slides/hu/11">Ingyenes támogatási fórum</a></li>
<li><a href="https://helpdesk.aspose.com/">Fizetős támogatási helpdesk</a></li>
</ul>
</div>
</div>

------

## **Az első prezentációja**

Node.js 22 vagy 24, valamint a .NET SDK 8 vagy újabb szükséges; Linuxon néhány rendszercsomagot is telepíteni kell. A [Telepítés](/slides/hu/nodejs-net/installation/) felsorolja ezeket és a tesztelt platformokat. Hozzon létre egy projektet, adjon meg egy felülbírálást, amely megmondja az npm‑nek, melyik edge‑js kiadást telepítse, és telepítse a csomagot:

```sh
mkdir hello-slides
cd hello-slides
npm init -y
npm pkg set overrides.edge-js=26.1.0
npm install aspose.slides.via.net
```

Gépenként egyszer állítsa vissza a könyvtár által igényelt .NET csomagokat. Mentse el a `deps.csproj` fájlt a [Restore the .NET Dependencies](/slides/hu/nodejs-net/installation/#restore-the-net-dependencies) útmutatóból egy `deps` mappába a projekt könyvtárán belül, majd futtassa:

```sh
dotnet restore deps/deps.csproj
```

Mentse el ezt a kódot *hello.js* néven a projekt könyvtárába:

```javascript
const asposeSlides = require("aspose.slides.via.net");
const { Presentation, ShapeType, SaveFormat } = asposeSlides;

// Egy új prezentáció egy üres diát tartalmaz.
const presentation = new Presentation();
try {
    const slide = presentation.slides.get(0);

    // A pozíció és a méret pontban (1/72 hüvelyk) vannak megadva: x, y, szélesség, magasság.
    const rectangle = slide.shapes.addAutoShape(ShapeType.Rectangle, 50, 50, 400, 100);
    rectangle.addTextFrame("Hello, World!");

    presentation.save("hello.pptx", SaveFormat.Pptx);
    console.log("Saved hello.pptx");
} finally {
    // Engedje el a prezentációt alátámasztó .NET objektumot.
    presentation.dispose();
}
```

Futtassa a projekt könyvtárából:

```sh
node hello.js
```

A szkript kiírja a `Saved hello.pptx` üzenetet, és elmenti a *hello.pptx* fájlt egy diát tartalmazó téglalappal, amely a szöveget mutatja. Licenc nélkül a mentett fájl egy értékelő vízjelet kap – lásd a [Licencelés](/slides/hu/nodejs-net/licensing/) oldalt. További módokért a prezentáció létrehozására és feltöltésére, lásd a [Create a Presentation](/slides/hu/nodejs-net/create-presentation/).