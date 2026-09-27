---
title: Aspose.Slides voor Node.js via Java
second_title: Aspose.Slides voor Node.js
type: docs
weight: 47
url: /nl/nodejs-java/
keywords:
- documentatie
- presentatieverwerking
- presentatieconversie
- PowerPoint
- OpenDocument
- Node.js
- JavaScript
- Aspose.Slides
description: "Begin hier: installeer Aspose.Slides voor Node.js via Java, maak een eerste presentatie en vind de handleidingen voor algemene taken, de API‑referentie en ondersteuning."
is_root: true
---
<img src="aspose_slides-for-nodejs-via-java.png" alt="Aspose.Slides voor Node.js via Java" align="left" style="width:110px; margin: 0 30px 20px 0"/>

Aspose.Slides voor Node.js via Java is een bibliotheek voor het maken, lezen, bewerken en converteren van PowerPoint‑ en OpenDocument‑presentaties in Node.js‑applicaties, zonder Microsoft PowerPoint.

Het laadt en slaat PPT, PPTX, PPS, POT en ODP op, inclusief macro‑ondersteunde en sjabloonvarianten, en exporteert naar PDF, XPS, HTML, SVG, TIFF, Markdown en afbeeldingen.

<div style="clear:both"></div>

------

<div class="row">
<div class="col-md-4">
<p><b>Aan de slag</b></p>
<hr>
<p>AAN DE SLAG</p>
<ul>
<li><a href="/slides/nl/nodejs-java/installation/">Installatie</a></li>
<li><a href="/slides/nl/nodejs-java/create-presentation/">Maak uw eerste presentatie</a></li>
<li><a href="/slides/nl/nodejs-java/getting-started/">Startgids</a></li>
</ul>
<p>EVALUEREN</p>
<ul>
<li><a href="/slides/nl/nodejs-java/supported-file-formats/">Ondersteunde bestandsformaten</a></li>
<li><a href="/slides/nl/nodejs-java/evaluate-aspose-slides/">Beperkingen van de proefversie</a></li>
<li><a href="/slides/nl/nodejs-java/licensing/">Licenties</a></li>
</ul>
</div>
<div class="col-md-4">
<p><b>Bouw met Slides</b></p>
<hr>
<p>ALGEMENE TAKEN</p>
<ul>
<li><a href="/slides/nl/nodejs-java/open-presentation/">Open een presentatie</a></li>
<li><a href="/slides/nl/nodejs-java/save-presentation/">Sla een presentatie op</a></li>
<li><a href="/slides/nl/nodejs-java/convert-powerpoint-to-pdf/">Converteer naar PDF</a></li>
<li><a href="/slides/nl/nodejs-java/convert-slide/">Render dia's als afbeeldingen</a></li>
<li><a href="/slides/nl/nodejs-java/manage-text/">Bewerk tekst en vormen</a></li>
</ul>
<p>SLIDES‑WERKSTROMEN</p>
<ul>
<li><a href="/slides/nl/nodejs-java/powerpoint-charts/">Grafieken</a></li>
<li><a href="/slides/nl/nodejs-java/powerpoint-animation/">Animaties</a></li>
<li><a href="/slides/nl/nodejs-java/manage-media-files/">Audio en video</a></li>
<li><a href="/slides/nl/nodejs-java/presentation-design/">Dia‑ontwerp</a></li>
<li><a href="/slides/nl/nodejs-java/merge-presentation/">Presentaties samenvoegen</a></li>
</ul>
<p>VOORBEELDEN</p>
<ul>
<li><a href="/slides/nl/nodejs-java/examples/">Voorbeelden per slide‑element</a></li>
</ul>
</div>
<div class="col-md-4">
<p><b>Referentie &amp; Ondersteuning</b></p>
<hr>
<p>REFERENTIE</p>
<ul>
<li><a href="https://reference.aspose.com/slides/nl/nodejs-java/">API-referentie</a></li>
<li><a href="https://releases.aspose.com/slides/nl/nodejs-java/release-notes/">Release‑opmerkingen</a></li>
<li><a href="/slides/nl/nodejs-java/known-issues/">Bekende problemen</a></li>
<li><a href="https://releases.aspose.com/slides/nl/nodejs-java/">Download</a></li>
</ul>
<p>ONDERSTEUNING</p>
<ul>
<li><a href="https://forum.aspose.com/c/slides/nl/11">Gratis ondersteuningsforum</a></li>
<li><a href="https://helpdesk.aspose.com/">Betaalde ondersteuningshelpdesk</a></li>
</ul>
</div>
</div>

------

## **Uw eerste presentatie**

Naast Node.js 20 of hoger heeft het pakket een Java Development Kit (JDK), Python en een C++‑build‑toolchain nodig, omdat npm tijdens de installatie de `java`‑bridge compileert. Zie [Installation](/slides/nl/nodejs-java/installation/) voor de stappen per besturingssysteem. Maak daarna een project aan en installeer het pakket via npm:

```bash
mkdir hello-slides
cd hello-slides
npm init -y
npm install aspose.slides.via.java
```

Sla deze code op als *hello.js* in de projectmap:

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

// Aspose.Slides draait in een Java-virtual machine die Node.js actief houdt, dus beëindig het proces expliciet.
process.exit(0);
```

Voer het uit met `node hello.js`. Het script slaat *hello.pptx* op met één dia die een tekstvak bevat. Zonder licentie bevat het opgeslagen bestand een evaluatiewatermerk — zie [Licensing](/slides/nl/nodejs-java/licensing/). Voor meer manieren om een presentatie te maken en te vullen, zie [Create Presentations](/slides/nl/nodejs-java/create-presentation/).