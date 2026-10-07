---
title: Aspose.Slides för Node.js via .NET
second_title: Aspose.Slides för Node.js
type: docs
weight: 47
url: /sv/nodejs-net/
keywords:
- dokumentation
- presentationbearbetning
- presentationkonvertering
- PowerPoint
- OpenDocument
- Node.js
- JavaScript
- Aspose.Slides
description: "Börja här: installera Aspose.Slides för Node.js via .NET, skapa en första presentation och hitta guiderna för vanliga uppgifter, licensiering, API-referensen och support."
is_root: true
---
<img src="aspose_slides-for-nodejs-via-net.png" alt="Aspose.Slides for Node.js via .NET" align="left" style="width:110px; margin: 0 30px 20px 0"/>

Aspose.Slides for Node.js via .NET är ett bibliotek för att skapa, läsa, redigera och konvertera PowerPoint‑ och OpenDocument‑presentationer i Node.js‑applikationer, utan Microsoft PowerPoint eller Office‑automatisering. Det kör Aspose.Slides for .NET genom edge‑js‑bron, så dess JavaScript‑API speglar .NET‑API:et, med camelCase‑medlemsnamn.

Det läser och sparar PPT, PPTX, PPS, POT och ODP, inklusive makro‑aktiverade och mall‑varianter, och exporterar till PDF, XPS, HTML, TIFF, Markdown och bilder.

<div style="clear:both"></div>

------

<div class="row">
<div class="col-md-4">
<p><b>Kom igång</b></p>
<hr>
<p>KOM IGÅNG</p>
<ul>
<li><a href="/slides/sv/nodejs-net/installation/">Installation</a></li>
<li><a href="/slides/sv/nodejs-net/create-presentation/">Skapa din första presentation</a></li>
<li><a href="/slides/sv/nodejs-net/developer-guide/">Utvecklardokumentation</a></li>
</ul>
<p>UTVÄRDERA</p>
<ul>
<li><a href="/slides/sv/nodejs-net/evaluate-aspose-slides/">Begränsningar i provversion</a></li>
<li><a href="/slides/sv/nodejs-net/licensing/">Licensiering</a></li>
</ul>
</div>
<div class="col-md-4">
<p><b>Bygg med Slides</b></p>
<hr>
<p>VANLIGA UPPGIFTER</p>
<ul>
<li><a href="/slides/sv/nodejs-net/open-presentation/">Öppna och spara en presentation</a></li>
<li><a href="/slides/sv/nodejs-net/convert-powerpoint-to-pdf/">Konvertera till PDF</a></li>
<li><a href="/slides/sv/nodejs-net/convert-slide/">Rendera bildspel som bilder</a></li>
<li><a href="/slides/sv/nodejs-net/manage-text/">Redigera text</a></li>
</ul>
</div>
<div class="col-md-4">
<p><b>Referens &amp; Support</b></p>
<hr>
<p>REFERENS</p>
<ul>
<li><a href="https://reference.aspose.com/slides/net/">.NET API-referens</a></li>
<li><a href="https://releases.aspose.com/slides/nodejs-net/release-notes/">Versionsanteckningar</a></li>
<li><a href="https://products.aspose.com/slides/nodejs-net/">Produktsida</a></li>
<li><a href="https://releases.aspose.com/slides/nodejs-net/">Nedladdning</a></li>
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

Du behöver Node.js 22 eller 24 samt .NET SDK 8 eller senare; Linux kräver också några systempaket. [Installation](/slides/sv/nodejs-net/installation/) listar dem och de plattformar som har testats. Skapa ett projekt, lägg till en åsidosättning som talar om för npm vilken edge-js‑version som ska installeras, och installera paketet:

```sh
mkdir hello-slides
cd hello-slides
npm init -y
npm pkg set overrides.edge-js=26.1.0
npm install aspose.slides.via.net
```

En gång per maskin, återställ .NET‑paketen som biblioteket beror på. Spara `deps.csproj`‑filen från [Restore the .NET Dependencies](/slides/sv/nodejs-net/installation/#restore-the-net-dependencies) i en `deps`‑mapp i projektmappen, och kör sedan:

```sh
dotnet restore deps/deps.csproj
```

Spara denna kod som *hello.js* i projektmappen:

```javascript
const asposeSlides = require("aspose.slides.via.net");
const { Presentation, ShapeType, SaveFormat } = asposeSlides;

// En ny presentation innehåller ett tomt bildspel.
const presentation = new Presentation();
try {
    const slide = presentation.slides.get(0);

    // Position och storlek anges i punkter (1/72 tum): x, y, bredd, höjd.
    const rectangle = slide.shapes.addAutoShape(ShapeType.Rectangle, 50, 50, 400, 100);
    rectangle.addTextFrame("Hello, World!");

    presentation.save("hello.pptx", SaveFormat.Pptx);
    console.log("Saved hello.pptx");
} finally {
    // Frigör .NET-objektet som ligger bakom presentationen.
    presentation.dispose();
}
```

Kör den från projektmappen:

```sh
node hello.js
```

Skriptet skriver ut `Saved hello.pptx` och sparar *hello.pptx* med ett bildspel som innehåller en rektangel med texten. Utan licens har den sparade filen ett utvärderingsvattenmärke — se [Licensing](/slides/sv/nodejs-net/licensing/). För fler sätt att skapa och fylla en presentation, se [Create a Presentation](/slides/sv/nodejs-net/create-presentation/).