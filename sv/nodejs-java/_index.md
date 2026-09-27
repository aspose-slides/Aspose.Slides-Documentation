---
title: Aspose.Slides för Node.js via Java
second_title: Aspose.Slides för Node.js
type: docs
weight: 47
url: /sv/nodejs-java/
keywords:
- dokumentation
- presentationbearbetning
- presentationskonvertering
- PowerPoint
- OpenDocument
- Node.js
- JavaScript
- Aspose.Slides
description: "Börja här: installera Aspose.Slides för Node.js via Java, skapa en första presentation och hitta guiderna för vanliga uppgifter, API‑referensen och support."
is_root: true
---
<img src="aspose_slides-for-nodejs-via-java.png" alt="Aspose.Slides för Node.js via Java" align="left" style="width:110px; margin: 0 30px 20px 0"/>

Aspose.Slides for Node.js via Java är ett bibliotek för att skapa, läsa, redigera och konvertera PowerPoint- och OpenDocument-presentationer i Node.js‑applikationer, utan Microsoft PowerPoint.

Det laddar och sparar PPT, PPTX, PPS, POT och ODP, inklusive makroaktiverade och mallvarianter, och exporterar till PDF, XPS, HTML, SVG, TIFF, Markdown och bilder.

<div style="clear:both"></div>

------

<div class="row">
<div class="col-md-4">
<p><b>Kom igång</b></p>
<hr>
<p>Kom igång</p>
<ul>
<li><a href="/slides/sv/nodejs-java/installation/">Installation</a></li>
<li><a href="/slides/sv/nodejs-java/create-presentation/">Skapa din första presentation</a></li>
<li><a href="/slides/sv/nodejs-java/getting-started/">Kom igång‑guide</a></li>
</ul>
<p>Utvärdera</p>
<ul>
<li><a href="/slides/sv/nodejs-java/supported-file-formats/">Stödda filformat</a></li>
<li><a href="/slides/sv/nodejs-java/evaluate-aspose-slides/">Begränsningar i provversionen</a></li>
<li><a href="/slides/sv/nodejs-java/licensing/">Licensiering</a></li>
</ul>
</div>
<div class="col-md-4">
<p><b>Bygg med Slides</b></p>
<hr>
<p>Vanliga uppgifter</p>
<ul>
<li><a href="/slides/sv/nodejs-java/open-presentation/">Öppna en presentation</a></li>
<li><a href="/slides/sv/nodejs-java/save-presentation/">Spara en presentation</a></li>
<li><a href="/slides/sv/nodejs-java/convert-powerpoint-to-pdf/">Konvertera till PDF</a></li>
<li><a href="/slides/sv/nodejs-java/convert-slide/">Rendera bildspel som bilder</a></li>
<li><a href="/slides/sv/nodejs-java/manage-text/">Redigera text och former</a></li>
</ul>
<p>SLIDES‑ARBETSFLÖDEN</p>
<ul>
<li><a href="/slides/sv/nodejs-java/powerpoint-charts/">Diagram</a></li>
<li><a href="/slides/sv/nodejs-java/powerpoint-animation/">Animationer</a></li>
<li><a href="/slides/sv/nodejs-java/manage-media-files/">Audio och video</a></li>
<li><a href="/slides/sv/nodejs-java/presentation-design/">Slide‑design</a></li>
<li><a href="/slides/sv/nodejs-java/merge-presentation/">Slå ihop presentationer</a></li>
</ul>
<p>EXEMPEL</p>
<ul>
<li><a href="/slides/sv/nodejs-java/examples/">Exempel per slide‑element</a></li>
</ul>
</div>
<div class="col-md-4">
<p><b>Referens &amp; Support</b></p>
<hr>
<p>REFERENS</p>
<ul>
<li><a href="https://reference.aspose.com/slides/nodejs-java/">API‑referens</a></li>
<li><a href="https://releases.aspose.com/slides/nodejs-java/release-notes/">Versionsnotiser</a></li>
<li><a href="/slides/sv/nodejs-java/known-issues/">Kända problem</a></li>
<li><a href="https://releases.aspose.com/slides/nodejs-java/">Ladda ner</a></li>
</ul>
<p>SUPPORT</p>
<ul>
<li><a href="https://forum.aspose.com/c/slides/11">Gratis supportforum</a></li>
<li><a href="https://helpdesk.aspose.com/">Betald supporthelpdesk</a></li>
</ul>
</div>
</div>

------

## **Din första presentation**

Förutom Node.js 20 eller senare kräver paketet ett Java Development Kit (JDK), Python och en C++‑byggkedja, eftersom npm kompilerar sin `java`‑brygga under installationen. Se [Installation](/slides/sv/nodejs-java/installation/) för stegen för varje operativsystem. Skapa sedan ett projekt och installera paketet från npm:

```bash
mkdir hello-slides
cd hello-slides
npm init -y
npm install aspose.slides.via.java
```

Spara denna kod som *hello.js* i projektmappen:

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

// Aspose.Slides körs i en Java-virtuell maskin som håller Node.js igång, så avsluta processen explicit.
process.exit(0);
```

Kör den med `node hello.js`. Skriptet sparar *hello.pptx* med en slide som innehåller en textruta. Utan licens får den sparade filen ett utvärderingsvattenstämpel — se [Licensiering](/slides/sv/nodejs-java/licensing/). För fler sätt att skapa och fylla en presentation, se [Skapa presentationer](/slides/sv/nodejs-java/create-presentation/).