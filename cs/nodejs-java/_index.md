---
title: Aspose.Slides for Node.js via Java
second_title: Aspose.Slides for Node.js
type: docs
weight: 47
url: /cs/nodejs-java/
keywords:
- dokumentace
- zpracování prezentací
- převod prezentací
- PowerPoint
- OpenDocument
- Node.js
- JavaScript
- Aspose.Slides
description: "Začněte zde: nainstalujte Aspose.Slides for Node.js via Java, vytvořte první prezentaci a najděte průvodce pro běžné úkoly, API reference a podporu."
is_root: true
---
<img src="aspose_slides-for-nodejs-via-java.png" alt="Aspose.Slides for Node.js via Java" align="left" style="width:110px; margin: 0 30px 20px 0"/>

Aspose.Slides for Node.js via Java je knihovna pro vytváření, čtení, úpravy a převod prezentací PowerPoint a OpenDocument v aplikacích Node.js, bez potřeby Microsoft PowerPoint.

Načítá a ukládá PPT, PPTX, PPS, POT a ODP, včetně variant s makry a šablonami, a exportuje do PDF, XPS, HTML, SVG, TIFF, Markdown a obrázků.

<div style="clear:both"></div>

------

<div class="row">
<div class="col-md-4">
<p><b>Začínáme</b></p>
<hr>
<p>GETTING STARTED</p>
<ul>
<li><a href="/slides/cs/nodejs-java/installation/">Instalace</a></li>
<li><a href="/slides/cs/nodejs-java/create-presentation/">Vytvořte svou první prezentaci</a></li>
<li><a href="/slides/cs/nodejs-java/getting-started/">Průvodce pro začátečníky</a></li>
</ul>
<p>EVALUATE</p>
<ul>
<li><a href="/slides/cs/nodejs-java/supported-file-formats/">Podporované formáty souborů</a></li>
<li><a href="/slides/cs/nodejs-java/evaluate-aspose-slides/">Omezení zkušební verze</a></li>
<li><a href="/slides/cs/nodejs-java/licensing/">Licencování</a></li>
</ul>
</div>
<div class="col-md-4">
<p><b>Práce se Slides</b></p>
<hr>
<p>COMMON TASKS</p>
<ul>
<li><a href="/slides/cs/nodejs-java/open-presentation/">Otevřít prezentaci</a></li>
<li><a href="/slides/cs/nodejs-java/save-presentation/">Uložit prezentaci</a></li>
<li><a href="/slides/cs/nodejs-java/convert-powerpoint-to-pdf/">Převést do PDF</a></li>
<li><a href="/slides/cs/nodejs-java/convert-slide/">Vykreslit snímky jako obrázky</a></li>
<li><a href="/slides/cs/nodejs-java/manage-text/">Upravit text a tvary</a></li>
</ul>
<p>SLIDES WORKFLOWS</p>
<ul>
<li><a href="/slides/cs/nodejs-java/powerpoint-charts/">Grafy</a></li>
<li><a href="/slides/cs/nodejs-java/powerpoint-animation/">Animace</a></li>
<li><a href="/slides/cs/nodejs-java/manage-media-files/">Audio a video</a></li>
<li><a href="/slides/cs/nodejs-java/presentation-design/">Návrh snímků</a></li>
<li><a href="/slides/cs/nodejs-java/merge-presentation/">Sloučit prezentace</a></li>
</ul>
<p>EXAMPLES</p>
<ul>
<li><a href="/slides/cs/nodejs-java/examples/">Příklady podle prvků snímku</a></li>
</ul>
</div>
<div class="col-md-4">
<p><b>Reference a podpora</b></p>
<hr>
<p>REFERENCE</p>
<ul>
<li><a href="https://reference.aspose.com/slides/cs/nodejs-java/">API reference</a></li>
<li><a href="https://releases.aspose.com/slides/cs/nodejs-java/release-notes/">Poznámky k vydání</a></li>
<li><a href="/slides/cs/nodejs-java/known-issues/">Známé problémy</a></li>
<li><a href="https://releases.aspose.com/slides/cs/nodejs-java/">Stáhnout</a></li>
</ul>
<p>SUPPORT</p>
<ul>
<li><a href="https://forum.aspose.com/c/slides/cs/11">Bezplatné fórum podpory</a></li>
<li><a href="https://helpdesk.aspose.com/">Placená podpora (helpdesk)</a></li>
</ul>
</div>
</div>

------

## **Your first presentation**

Kromě Node.js 20 nebo novějšího balíček vyžaduje Java Development Kit (JDK), Python a C++ build toolchain, protože npm během instalace kompiluje svůj most `java`. Viz [Installation](/slides/cs/nodejs-java/installation/) pro kroky na každém operačním systému. Pak vytvořte projekt a nainstalujte balíček z npm:

```bash
mkdir hello-slides
cd hello-slides
npm init -y
npm install aspose.slides.via.java
```

Uložte tento kód jako *hello.js* ve složce projektu:

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

// Aspose.Slides běží v Java virtuálním stroji, který udržuje Node.js běžící, takže proces ukončete explicitně.
process.exit(0);
```

Spusťte jej příkazem `node hello.js`. Skript uloží *hello.pptx* s jedním snímkem obsahujícím textové pole. Bez licence obsahuje uložený soubor evaluační vodoznak — viz [Licensing](/slides/cs/nodejs-java/licensing/). Další způsoby, jak vytvořit a naplnit prezentaci, najdete v [Create Presentations](/slides/cs/nodejs-java/create-presentation/).