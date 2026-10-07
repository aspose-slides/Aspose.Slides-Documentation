---
title: Aspose.Slides Node.js-hez .NET-en keresztül
second_title: Aspose.Slides Node.js-hez
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
description: "Kezdje itt: telepítse az Aspose.Slides for Node.js via .NET-et, hozza létre az első bemutatót, és találja meg a gyakori feladatok, licencelés, az API referencia és a támogatás útmutatóit."
is_root: true
---
<img src="aspose_slides-for-nodejs-via-net.png" alt="Aspose.Slides for Node.js via .NET" align="left" style="width:110px; margin: 0 30px 20px 0"/>

Az Aspose.Slides for Node.js via .NET egy könyvtár PowerPoint és OpenDocument bemutatók létrehozásához, olvasásához, szerkesztéséhez és konvertálásához Node.js alkalmazásokban, Microsoft PowerPoint vagy Office Automation nélkül. A .NET‑es Aspose.Slides-et az edge‑js hídon keresztül futtatja, ezért a JavaScript API tükrözi a .NET API‑t, camelCase tagnevekkel.

A PPT, PPTX, PPS, POT és ODP formátumokat, köztük a makró‑támogatott és sablon változatokat is betölti és menti, valamint exportál PDF, XPS, HTML, TIFF, Markdown és képek formátumokba.

<div style="clear:both"></div>

------

<div class="row">
<div class="col-md-4">
<p><b>Első lépések</b></p>
<hr>
<p>ELKEZDÉS</p>
<ul>
<li><a href="/slides/hu/nodejs-net/installation/">Telepítés</a></li>
<li><a href="/slides/hu/nodejs-net/create-presentation/">Az első bemutató létrehozása</a></li>
<li><a href="/slides/hu/nodejs-net/developer-guide/">Fejlesztői útmutató</a></li>
</ul>
<p>ÉRTÉKELÉS</p>
<ul>
<li><a href="/slides/hu/nodejs-net/evaluate-aspose-slides/">Próbaidő korlátai</a></li>
<li><a href="/slides/hu/nodejs-net/licensing/">Licencelés</a></li>
</ul>
</div>
<div class="col-md-4">
<p><b>Építs Slides-szel</b></p>
<hr>
<p>GYAKORI FELADATOK</p>
<ul>
<li><a href="/slides/hu/nodejs-net/open-presentation/">Bemutató megnyitása és mentése</a></li>
<li><a href="/slides/hu/nodejs-net/convert-powerpoint-to-pdf/">PDF-re konvertálás</a></li>
<li><a href="/slides/hu/nodejs-net/convert-slide/">Diák renderelése képként</a></li>
<li><a href="/slides/hu/nodejs-net/manage-text/">Szöveg szerkesztése</a></li>
</ul>
</div>
<div class="col-md-4">
<p><b>Referenciák &amp; Támogatás</b></p>
<hr>
<p>REFERENCIA</p>
<ul>
<li><a href="https://reference.aspose.com/slides/net/">.NET API referencia</a></li>
<li><a href="https://releases.aspose.com/slides/nodejs-net/release-notes/">Kiadási megjegyzések</a></li>
<li><a href="https://products.aspose.com/slides/nodejs-net/">Termékoldal</a></li>
<li><a href="https://releases.aspose.com/slides/nodejs-net/">Letöltés</a></li>
</ul>
<p>TÁMOGATÁS</p>
<ul>
<li><a href="https://forum.aspose.com/c/slides/11">Ingyenes támogatási fórum</a></li>
<li><a href="https://helpdesk.aspose.com/">Fizetett támogatási helpdesk</a></li>
</ul>
</div>
</div>

------

## **Az első bemutató**

Szüksége van Node.js 22 vagy 24 és a .NET SDK 8 vagy újabb verzióra; Linux esetén néhány rendszercsomagra is szükség van. [Telepítés](/slides/hu/nodejs-net/installation/) felsorolja ezeket és a tesztelt platformokat. Hozzon létre egy projektet, adjon hozzá egy felülbírálást, amely megmondja az npm‑nek, melyik edge‑js kiadást kell telepíteni, majd telepítse a csomagot:

```sh
mkdir hello-slides
cd hello-slides
npm init -y
npm pkg set overrides.edge-js=26.1.0
npm install aspose.slides.via.net
```

Egyszer a gépen vissza kell állítani a .NET csomagokat, amelyektől a könyvtár függ. Mentse a `deps.csproj` fájlt a [A .NET függőségek visszaállítása](/slides/hu/nodejs-net/installation/#restore-the-net-dependencies) útvonalról egy `deps` mappába a projekt mappáján belül, majd futtassa:

```sh
dotnet restore deps/deps.csproj
```

Mentse ezt a kódot *hello.js* néven a projekt mappájába:

```javascript
const asposeSlides = require("aspose.slides.via.net");
const { Presentation, ShapeType, SaveFormat } = asposeSlides;

// Egy új bemutató egy üres diát tartalmaz.
const presentation = new Presentation();
try {
    const slide = presentation.slides.get(0);

    // A pozíció és méret pontokban van megadva (1/72 hüvelyk): x, y, szélesség, magasság.
    const rectangle = slide.shapes.addAutoShape(ShapeType.Rectangle, 50, 50, 400, 100);
    rectangle.addTextFrame("Hello, World!");

    presentation.save("hello.pptx", SaveFormat.Pptx);
    console.log("Saved hello.pptx");
} finally {
    // Felszabadítja a bemutatót alátámasztó .NET objektumot.
    presentation.dispose();
}
```

Futtassa a projekt mappájából:

```sh
node hello.js
```

A szkript kiírja a `Saved hello.pptx` üzenetet, és elmenti a *hello.pptx*-t egy diával, amely egy szöveget tartalmazó téglalapot tartalmaz. Licenc nélkül a mentett fájl értékelő vízjelt kap — lásd a [Licencelés](/slides/hu/nodejs-net/licensing/) részt. További módok a bemutató létrehozására és kitöltésére: [Bemutató létrehozása](/slides/hu/nodejs-net/create-presentation/).