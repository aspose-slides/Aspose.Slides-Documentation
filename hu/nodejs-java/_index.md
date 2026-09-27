---
title: Aspose.Slides Node.js-hez Java segítségével
second_title: Aspose.Slides Node.js-hez
type: docs
weight: 47
url: /hu/nodejs-java/
keywords:
- dokumentáció
- prezentáció feldolgozás
- prezentáció átalakítás
- PowerPoint
- OpenDocument
- Node.js
- JavaScript
- Aspose.Slides
description: "Kezdje itt: telepítse az Aspose.Slides for Node.js via Java könyvtárat, hozza létre az első prezentációt, és tekintse meg a gyakori feladatok útmutatóit, az API referenciát és a támogatást."
is_root: true
---
<img src="aspose_slides-for-nodejs-via-java.png" alt="Aspose.Slides for Node.js via Java" align="left" style="width:110px; margin: 0 30px 20px 0"/>

Az Aspose.Slides for Node.js via Java egy könyvtár a PowerPoint és OpenDocument prezentációk létrehozásához, olvasásához, szerkesztéséhez és átalakításához Node.js alkalmazásokban, a Microsoft PowerPoint nélkül.

Betölti és menti a PPT, PPTX, PPS, POT és ODP formátumokat, beleértve a makróval ellátott és sablonváltozatokat, valamint exportál PDF, XPS, HTML, SVG, TIFF, Markdown és képek formátumba.

<div style="clear:both"></div>

------

<div class="row">
<div class="col-md-4">
<p><b>Első lépések</b></p>
<hr>
<p>ELŐSLÉPÉSEK</p>
<ul>
<li><a href="/slides/hu/nodejs-java/installation/">Telepítés</a></li>
<li><a href="/slides/hu/nodejs-java/create-presentation/">Első prezentáció létrehozása</a></li>
<li><a href="/slides/hu/nodejs-java/getting-started/">Kezdő útmutató</a></li>
</ul>
<p>ÉRTÉKELÉS</p>
<ul>
<li><a href="/slides/hu/nodejs-java/supported-file-formats/">Támogatott fájlformátumok</a></li>
<li><a href="/slides/hu/nodejs-java/evaluate-aspose-slides/">Próba korlátozások</a></li>
<li><a href="/slides/hu/nodejs-java/licensing/">Licencelés</a></li>
</ul>
</div>
<div class="col-md-4">
<p><b>Készítsen Slides-szal</b></p>
<hr>
<p>ÁLTALÁNOS FELADATOK</p>
<ul>
<li><a href="/slides/hu/nodejs-java/open-presentation/">Prezentáció megnyitása</a></li>
<li><a href="/slides/hu/nodejs-java/save-presentation/">Prezentáció mentése</a></li>
<li><a href="/slides/hu/nodejs-java/convert-powerpoint-to-pdf/">PDF-be konvertálás</a></li>
<li><a href="/slides/hu/nodejs-java/convert-slide/">Diák renderelése képekként</a></li>
<li><a href="/slides/hu/nodejs-java/manage-text/">Szöveg és alakzatok szerkesztése</a></li>
</ul>
<p>SLIDES MUNKAFOLYAMOK</p>
<ul>
<li><a href="/slides/hu/nodejs-java/powerpoint-charts/">Diagramok</a></li>
<li><a href="/slides/hu/nodejs-java/powerpoint-animation/">Animációk</a></li>
<li><a href="/slides/hu/nodejs-java/manage-media-files/">Hang és videó</a></li>
<li><a href="/slides/hu/nodejs-java/presentation-design/">Diatervezés</a></li>
<li><a href="/slides/hu/nodejs-java/merge-presentation/">Prezentációk egyesítése</a></li>
</ul>
<p>PÉLDÁK</p>
<ul>
<li><a href="/slides/hu/nodejs-java/examples/">Példák diák elemei szerint</a></li>
</ul>
</div>
<div class="col-md-4">
<p><b>Referencia &amp; Támogatás</b></p>
<hr>
<p>REFERNCIA</p>
<ul>
<li><a href="https://reference.aspose.com/slides/hu/nodejs-java/">API referencia</a></li>
<li><a href="https://releases.aspose.com/slides/hu/nodejs-java/release-notes/">Kiadási megjegyzések</a></li>
<li><a href="/slides/hu/nodejs-java/known-issues/">Ismert problémák</a></li>
<li><a href="https://releases.aspose.com/slides/hu/nodejs-java/">Letöltés</a></li>
</ul>
<p>TÁMOGATÁS</p>
<ul>
<li><a href="https://forum.aspose.com/c/slides/hu/11">Ingyenes támogatási fórum</a></li>
<li><a href="https://helpdesk.aspose.com/">Fizetett támogatási helpdesk</a></li>
</ul>
</div>
</div>

------

## **Az első prezentációd**

A Node.js 20 vagy újabb verziója mellett a csomagnak Java Development Kit (JDK), Python és egy C++ build eszközlánc szükséges, mivel az npm a telepítés során lefordítja a `java` hidat. Lásd a [Telepítés](/slides/hu/nodejs-java/installation/) oldalt az egyes operációs rendszerek lépéseihez. Ezután hozzon létre egy projektet, és telepítse a csomagot az npm‑ből:

```bash
mkdir hello-slides
cd hello-slides
npm init -y
npm install aspose.slides.via.java
```

Mentse ezt a kódot *hello.js* néven a projekt mappájába:

```javascript
const asposeSlides = require("aspose.slides.via.java");

const presentation = new asposeSlides.Presentation();
try {
    const slide = presentation.getSlides().get_Item(0);
    const shape = slide.getShapes().addAutoShape(asposeSlides.ShapeType.Rectangle, 50, 50, 400, 100);
    shape.getTextFrame().setText("Hello, Aspose.Slides!");
    presentation.save("hello.pptx", asposeSlides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}

// Az Aspose.Slides egy Java virtuális gépen fut, amely folyamatosan futtatja a Node.js-t, ezért expliciten kell befejezni a folyamatot.
process.exit(0);
```

Futtassa a `node hello.js` paranccsal. A szkript ment egy *hello.pptx* fájlt, amely egy szövegdobozt tartalmazó diát tartalmaz. Licenc nélkül a mentett fájl értékelő vízjelet kap — lásd a [Licencelés](/slides/hu/nodejs-java/licensing/) oldalt. További módok a prezentáció létrehozására és kitöltésére a [Prezentációk létrehozása](/slides/hu/nodejs-java/create-presentation/) oldalon találhatók.