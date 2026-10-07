---
title: Aspose.Slides voor Node.js via .NET
second_title: Aspose.Slides voor Node.js
type: docs
weight: 47
url: /nl/nodejs-net/
keywords:
- documentatie
- presentatieverwerking
- presentatieconversie
- PowerPoint
- OpenDocument
- Node.js
- JavaScript
- Aspose.Slides
description: "Begin hier: installeer Aspose.Slides voor Node.js via .NET, maak een eerste presentatie, en vind de gidsen voor algemene taken, licenties, de API-referentie en ondersteuning."
is_root: true
---
<img src="aspose_slides-for-nodejs-via-net.png" alt="Aspose.Slides voor Node.js via .NET" align="left" style="width:110px; margin: 0 30px 20px 0"/>

Aspose.Slides voor Node.js via .NET is een bibliotheek voor het maken, lezen, bewerken en converteren van PowerPoint‑ en OpenDocument‑presentaties in Node.js‑toepassingen, zonder Microsoft PowerPoint of Office‑automatisering. Het draait Aspose.Slides voor .NET via de edge‑js‑brug, zodat de JavaScript‑API de .NET‑API weerspiegelt, met camelCase‑member‑namen.

Het laadt en slaat PPT, PPTX, PPS, POT en ODP op, inclusief macro‑ingeschakelde en sjabloon‑varianten, en exporteert naar PDF, XPS, HTML, TIFF, Markdown en afbeeldingen.

<div style="clear:both"></div>

------

<div class="row">
<div class="col-md-4">
<p><b>Aan de slag</b></p>
<hr>
<p>Eerste stappen</p>
<ul>
<li><a href="/slides/nl/nodejs-net/installation/">Installatie</a></li>
<li><a href="/slides/nl/nodejs-net/create-presentation/">Maak je eerste presentatie</a></li>
<li><a href="/slides/nl/nodejs-net/developer-guide/">Ontwikkelaarsgids</a></li>
</ul>
<p>Evalueren</p>
<ul>
<li><a href="/slides/nl/nodejs-net/evaluate-aspose-slides/">Beperkingen proefversie</a></li>
<li><a href="/slides/nl/nodejs-net/licensing/">Licenties</a></li>
</ul>
</div>
<div class="col-md-4">
<p><b>Bouw met Slides</b></p>
<hr>
<p>Algemene taken</p>
<ul>
<li><a href="/slides/nl/nodejs-net/open-presentation/">Open en sla een presentatie op</a></li>
<li><a href="/slides/nl/nodejs-net/convert-powerpoint-to-pdf/">Converteer naar PDF</a></li>
<li><a href="/slides/nl/nodejs-net/convert-slide/">Render dia's als afbeeldingen</a></li>
<li><a href="/slides/nl/nodejs-net/manage-text/">Bewerk tekst</a></li>
</ul>
</div>
<div class="col-md-4">
<p><b>Referentie &amp; Ondersteuning</b></p>
<hr>
<p>Referentie</p>
<ul>
<li><a href="https://reference.aspose.com/slides/net/">.NET API-referentie</a></li>
<li><a href="https://releases.aspose.com/slides/nodejs-net/release-notes/">Release‑opmerkingen</a></li>
<li><a href="https://products.aspose.com/slides/nodejs-net/">Productpagina</a></li>
<li><a href="https://releases.aspose.com/slides/nodejs-net/">Download</a></li>
</ul>
<p>Ondersteuning</p>
<ul>
<li><a href="https://forum.aspose.com/c/slides/11">Gratis ondersteuningsforum</a></li>
<li><a href="https://helpdesk.aspose.com/">Betaalde ondersteunings‑helpdesk</a></li>
</ul>
</div>
</div>

------

## **Je eerste presentatie**

Je hebt Node.js 22 of 24 en de .NET SDK 8 of hoger nodig; Linux heeft ook een paar systeempakketten nodig. [Installatie](/slides/nl/nodejs-net/installation/) somt ze op en de platforms die zijn getest. Maak een project, voeg een override toe die npm vertelt welke edge‑js‑release geïnstalleerd moet worden, en installeer het pakket:

```sh
mkdir hello-slides
cd hello-slides
npm init -y
npm pkg set overrides.edge-js=26.1.0
npm install aspose.slides.via.net
```

Eenmaal per machine, herstel de .NET‑pakketten waarvan de bibliotheek afhankelijk is. Sla het `deps.csproj`‑bestand op van [Herstel de .NET‑afhankelijkheden](/slides/nl/nodejs-net/installation/#restore-the-net-dependencies) in een `deps`‑map binnen de projectmap, en voer vervolgens uit:

```sh
dotnet restore deps/deps.csproj
```

Sla deze code op als *hello.js* in de projectmap:

```javascript
const asposeSlides = require("aspose.slides.via.net");
const { Presentation, ShapeType, SaveFormat } = asposeSlides;

// Een nieuwe presentatie bevat één lege dia.
const presentation = new Presentation();
try {
    const slide = presentation.slides.get(0);

    // Positie en grootte zijn in punten (1/72 inch): x, y, breedte, hoogte.
    const rectangle = slide.shapes.addAutoShape(ShapeType.Rectangle, 50, 50, 400, 100);
    rectangle.addTextFrame("Hello, World!");

    presentation.save("hello.pptx", SaveFormat.Pptx);
    console.log("Saved hello.pptx");
} finally {
    // Vrijgeven van het .NET‑object dat de presentatie ondersteunt.
    presentation.dispose();
}
```

Voer het uit vanuit de projectmap:

```sh
node hello.js
```

Het script geeft `Saved hello.pptx` weer en slaat *hello.pptx* op met één dia met een rechthoek die de tekst bevat. Zonder licentie draagt het opgeslagen bestand een evaluatiewatermerk — zie [Licensing](/slides/nl/nodejs-net/licensing/). Voor meer manieren om een presentatie te maken en te vullen, zie [Maak een presentatie](/slides/nl/nodejs-net/create-presentation/).