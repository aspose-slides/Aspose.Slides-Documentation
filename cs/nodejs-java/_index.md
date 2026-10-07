---
title: Aspose.Slides pro Node.js přes Java
second_title: Aspose.Slides pro Node.js
type: docs
weight: 47
url: /cs/nodejs-java/
keywords:
- dokumentace
- zpracování prezentací
- konverze prezentací
- PowerPoint
- OpenDocument
- Node.js
- JavaScript
- Aspose.Slides
description: "Začněte zde: nainstalujte Aspose.Slides for Node.js via Java, vytvořte první prezentaci a najděte průvodce pro běžné úkoly, referenci API a podporu."
is_root: true
---
<img src="aspose_slides-for-nodejs-via-java.png" alt="Aspose.Slides for Node.js via Java" align="left" style="width:110px; margin: 0 30px 20px 0"/>

Aspose.Slides for Node.js via Java je knihovna pro vytváření, čtení, úpravu a konverzi prezentací PowerPoint a OpenDocument v aplikacích Node.js, bez Microsoft PowerPoint.

Načítá a ukládá soubory PPT, PPTX, PPS, POT a ODP, včetně variant s makry a šablon, a exportuje do PDF, XPS, HTML, SVG, TIFF, Markdown a obrázků.

<div style="clear:both"></div>

------

<div class="row">
<div class="col-md-4">
<p><b>Začínáme</b></p>
<hr>
<p>ZAHÁJENÍ PRÁCE</p>
<ul>
<li><a href="/slides/cs/nodejs-java/installation/">Instalace</a></li>
<li><a href="/slides/cs/nodejs-java/create-presentation/">Vytvořte první prezentaci</a></li>
<li><a href="/slides/cs/nodejs-java/getting-started/">Průvodce zahájením</a></li>
</ul>
<p>HODNOCENÍ</p>
<ul>
<li><a href="/slides/cs/nodejs-java/supported-file-formats/">Podporované formáty souborů</a></li>
<li><a href="/slides/cs/nodejs-java/evaluate-aspose-slides/">Omezení zkušební verze</a></li>
<li><a href="/slides/cs/nodejs-java/licensing/">Licencování</a></li>
</ul>
</div>
<div class="col-md-4">
<p><b>Vytvářejte pomocí Slides</b></p>
<hr>
<p>OBVYKLÉ ÚKOLY</p>
<ul>
<li><a href="/slides/cs/nodejs-java/open-presentation/">Otevřít prezentaci</a></li>
<li><a href="/slides/cs/nodejs-java/save-presentation/">Uložit prezentaci</a></li>
<li><a href="/slides/cs/nodejs-java/convert-powerpoint-to-pdf/">Převést do PDF</a></li>
<li><a href="/slides/cs/nodejs-java/convert-slide/">Vykreslit snímky jako obrázky</a></li>
<li><a href="/slides/cs/nodejs-java/manage-text/">Upravit text a tvary</a></li>
</ul>
<p>PROCESY SLIDES</p>
<ul>
<li><a href="/slides/cs/nodejs-java/powerpoint-charts/">Grafy</a></li>
<li><a href="/slides/cs/nodejs-java/powerpoint-animation/">Animace</a></li>
<li><a href="/slides/cs/nodejs-java/manage-media-files/">Audio a video</a></li>
<li><a href="/slides/cs/nodejs-java/presentation-design/">Návrh snímků</a></li>
<li><a href="/slides/cs/nodejs-java/merge-presentation/">Sloučit prezentace</a></li>
</ul>
<p>PŘÍKLADY</p>
<ul>
<li><a href="/slides/cs/nodejs-java/examples/">Příklady podle prvků snímku</a></li>
</ul>
</div>
<div class="col-md-4">
<p><b>Reference &amp; podpora</b></p>
<hr>
<p>REFERENCE</p>
<ul>
<li><a href="https://reference.aspose.com/slides/nodejs-java/">API reference</a></li>
<li><a href="https://releases.aspose.com/slides/nodejs-java/release-notes/">Poznámky k vydání</a></li>
<li><a href="/slides/cs/nodejs-java/known-issues/">Známé problémy</a></li>
<li><a href="https://products.aspose.com/slides/nodejs-java/">Stránka produktu</a></li>
<li><a href="https://releases.aspose.com/slides/nodejs-java/">Stáhnout</a></li>
</ul>
<p>PODPOŘA</p>
<ul>
<li><a href="https://forum.aspose.com/c/slides/11">Bezplatné fórum podpory</a></li>
<li><a href="https://helpdesk.aspose.com/">Placená podpora helpdesk</a></li>
</ul>
</div>
</div>

------

## **Vaše první prezentace**

Kromě Node.js 20 nebo novějšího balíček vyžaduje JDK (Java Development Kit), Python a C++ build toolchain, protože npm během instalace kompiluje svůj `java` bridge. Viz [Instalace](/slides/cs/nodejs-java/installation/) pro kroky na každém operačním systému. Poté vytvořte projekt a nainstalujte balíček z npm:

```bash
mkdir hello-slides
cd hello-slides
npm init -y
npm install aspose.slides.via.java
```

Uložte tento kód jako *hello.js* do složky projektu:

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

// Aspose.Slides běží v Java virtuálním stroji, který udržuje běh Node.js, takže ukončete proces explicitně.
process.exit(0);
```

Spusťte jej pomocí `node hello.js`. Skript uloží *hello.pptx* s jedním snímkem obsahujícím textové pole. Bez licence má uložený soubor vodotisk hodnocení — viz [Licencování](/slides/cs/nodejs-java/licensing/). Pro více způsobů, jak vytvořit a naplnit prezentaci, viz [Vytváření prezentací](/slides/cs/nodejs-java/create-presentation/).