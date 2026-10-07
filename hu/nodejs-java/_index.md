---
title: Aspose.Slides for Node.js Java segítségével
second_title: Aspose.Slides a Node.js-hez
type: docs
weight: 47
url: /hu/nodejs-java/
keywords:
- dokumentáció
- prezentációfeldolgozás
- prezentációkonvertálás
- PowerPoint
- OpenDocument
- Node.js
- JavaScript
- Aspose.Slides
description: "Kezdje itt: telepítse az Aspose.Slides for Node.js Java segítségével, hozza létre az első prezentációt, és találja meg az általános feladatok útmutatóit, az API referenciát és a támogatást."
is_root: true
---
<img src="aspose_slides-for-nodejs-via-java.png" alt="Aspose.Slides for Node.js via Java" align="left" style="width:110px; margin: 0 30px 20px 0"/>

Az Aspose.Slides for Node.js via Java egy könyvtár PowerPoint és OpenDocument prezentációk létrehozásához, olvasásához, szerkesztéséhez és konvertálásához Node.js alkalmazásokban, a Microsoft PowerPoint nélkül.

Támogatja a PPT, PPTX, PPS, POT és ODP fájlok betöltését és mentését, beleértve a makróval ellátott és sablon változatokat is, valamint exportál PDF, XPS, HTML, SVG, TIFF, Markdown és képek formátumokba.

<div style="clear:both"></div>

------

<div class="row">
<div class="col-md-4">
<p><b>Kezdő lépések</b></p>
<hr>
<p>ELINDÍTÁS</p>
<ul>
<li><a href="/slides/hu/nodejs-java/installation/">Telepítés</a></li>
<li><a href="/slides/hu/nodejs-java/create-presentation/">Készítsd el első prezentációd</a></li>
<li><a href="/slides/hu/nodejs-java/getting-started/">Első lépések útmutatója</a></li>
</ul>
<p>ÉRTÉKELÉS</p>
<ul>
<li><a href="/slides/hu/nodejs-java/supported-file-formats/">Támogatott fájlformátumok</a></li>
<li><a href="/slides/hu/nodejs-java/evaluate-aspose-slides/">Próba használati korlátok</a></li>
<li><a href="/slides/hu/nodejs-java/licensing/">Licencelés</a></li>
</ul>
</div>
<div class="col-md-4">
<p><b>Készítés a Slides-szal</b></p>
<hr>
<p>ÁLTALÁNOS FELADATOK</p>
<ul>
<li><a href="/slides/hu/nodejs-java/open-presentation/">Prezentáció megnyitása</a></li>
<li><a href="/slides/hu/nodejs-java/save-presentation/">Prezentáció mentése</a></li>
<li><a href="/slides/hu/nodejs-java/convert-powerpoint-to-pdf/">Konvertálás PDF-be</a></li>
<li><a href="/slides/hu/nodejs-java/convert-slide/">Diák renderelése képként</a></li>
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
<p>PELDÁK</p>
<ul>
<li><a href="/slides/hu/nodejs-java/examples/">Példák diakelemek szerint</a></li>
</ul>
</div>
<div class="col-md-4">
<p><b>Referencia és támogatás</b></p>
<hr>
<p>REFERENCIA</p>
<ul>
<li><a href="https://reference.aspose.com/slides/nodejs-java/">API referencia</a></li>
<li><a href="https://releases.aspose.com/slides/nodejs-java/release-notes/">Kiadási megjegyzések</a></li>
<li><a href="/slides/hu/nodejs-java/known-issues/">Ismert problémák</a></li>
<li><a href="https://products.aspose.com/slides/nodejs-java/">Termékoldal</a></li>
<li><a href="https://releases.aspose.com/slides/nodejs-java/">Letöltés</a></li>
</ul>
<p>TÁMOGATÁS</p>
<ul>
<li><a href="https://forum.aspose.com/c/slides/11">Ingyenes támogatási fórum</a></li>
<li><a href="https://helpdesk.aspose.com/">Fizetett támogatási helpdesk</a></li>
</ul>
</div>
</div>

------

## **Az első prezentációd**

A Node.js 20 vagy újabb verziója mellett a csomag Java Development Kit (JDK), Python és C++ build eszköztárat igényel, mivel az npm a telepítés során lefordítja a `java` hídjét. Tekintse meg a [Installation](/slides/hu/nodejs-java/installation/) oldalát az egyes operációs rendszerek lépéseiért. Ezután hozzon létre egy projektet, és telepítse a csomagot az npm‑ből:

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

// Az Aspose.Slides egy Java virtuális gépben fut, amely Node.js-t működésben tartja, ezért explicit módon kell befejezni a folyamatot.
process.exit(0);
```

Futtassa a `node hello.js` paranccsal. A szkript elmenti a *hello.pptx*-t egyetlen diát tartalmazó szövegdobozzal. Licenc nélkül a mentett fájl értékelési vízjelet tartalmaz — lásd a [Licensing](/slides/hu/nodejs-java/licensing/) oldalt. További módok a prezentációk létrehozására és feltöltésére a [Create Presentations](/slides/hu/nodejs-java/create-presentation/) oldalon találhatók.