---
title: Aspose.Slides för Node.js via .NET
second_title: Aspose.Slides för Node.js
type: docs
weight: 47
url: /sv/nodejs-net/
keywords:
- dokumentation
- presentationsbearbetning
- presentationskonvertering
- PowerPoint
- OpenDocument
- Node.js
- JavaScript
- Aspose.Slides
description: "Börja här: installera Aspose.Slides för Node.js via .NET, skapa en första presentation och hitta guiderna för vanliga uppgifter, licensiering, API‑referensen och support."
is_root: true
---
<img src="aspose_slides-for-nodejs-via-net.png" alt="Aspose.Slides för Node.js via .NET" align="left" style="width:110px; margin: 0 30px 20px 0"/>

Aspose.Slides för Node.js via .NET är ett bibliotek för att skapa, läsa, redigera och konvertera PowerPoint‑ och OpenDocument‑presentationer i Node.js‑applikationer, utan Microsoft PowerPoint eller Office‑automation. Det kör Aspose.Slides för .NET via edge‑js‑bron, så dess JavaScript‑API speglar .NET‑API:et, med camelCase‑medlemsnamn.

Det laddar och sparar PPT, PPTX, PPS, POT och ODP, inklusive makroaktiverade och mallvarianter, och exporterar till PDF, XPS, HTML, TIFF, Markdown och bilder.

<div style="clear:both"></div>

---

<div class="row">
<div class="col-md-4">
<p><b>Kom igång</b></p>
<hr>
<p>KOM IGÅNG</p>
<ul>
<li><a href="/slides/sv/nodejs-net/installation/">Installation</a></li>
<li><a href="/slides/sv/nodejs-net/create-presentation/">Skapa din första presentation</a></li>
<li><a href="/slides/sv/nodejs-net/developer-guide/">Utvecklarguide</a></li>
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
<li><a href="/slides/sv/nodejs-net/convert-slide/">Rendera bilder som bilder</a></li>
<li><a href="/slides/sv/nodejs-net/manage-text/">Redigera text</a></li>
</ul>
</div>
<div class="col-md-4">
<p><b>Referens &amp; Support</b></p>
<hr>
<p>REFERENS</p>
<ul>
<li><a href="https://reference.aspose.com/slides/sv/net/">.NET API‑referens</a></li>
<li><a href="https://releases.aspose.com/slides/sv/nodejs-net/release-notes/">Versionsanteckningar</a></li>
<li><a href="https://releases.aspose.com/slides/sv/nodejs-net/">Ladda ner</a></li>
</ul>
<p>SUPPORT</p>
<ul>
<li><a href="https://forum.aspose.com/c/slides/sv/11">Forum för gratis support</a></li>
<li><a href="https://helpdesk.aspose.com/">Betald support helpdesk</a></li>
</ul>
</div>
</div>

---

## **Din första presentation**

Du behöver Node.js 22 eller 24 och .NET SDK 8 eller senare; Linux behöver också några systempaket. [Installation](/slides/sv/nodejs-net/installation/) listar dem och de plattformar som testats. Skapa ett projekt, lägg till en överskrivning som talar om för npm vilken edge-js‑version som ska installeras, och installera paketet:

```sh
mkdir hello-slides
cd hello-slides
npm init -y
npm pkg set overrides.edge-js=26.1.0
npm install aspose.slides.via.net
```

En gång per maskin, återställ .NET‑paketen som biblioteket beror på. Spara `deps.csproj`‑filen från [Återställ .NET‑beroenden](/slides/sv/nodejs-net/installation/#restore-the-net-dependencies) i en `deps`‑mapp i projektmappen, och kör sedan:

```sh
dotnet restore deps/deps.csproj
```

Spara den här koden som *hello.js* i projektmappen:

```javascript
const asposeSlides = require("aspose.slides.via.net");
const { Presentation, ShapeType, SaveFormat } = asposeSlides;

// En ny presentation innehåller en tom bild.
const presentation = new Presentation();
try {
    const slide = presentation.slides.get(0);

    // Position och storlek är i punkter (1/72 tum): x, y, bredd, höjd.
    const rectangle = slide.shapes.addAutoShape(ShapeType.Rectangle, 50, 50, 400, 100);
    rectangle.addTextFrame("Hello, World!");

    presentation.save("hello.pptx", SaveFormat.Pptx);
    console.log("Saved hello.pptx");
} finally {
    // Frigör .NET‑objektet som ligger bakom presentationen.
    presentation.dispose();
}
```

Kör den från projektmappen:

```sh
node hello.js
```

Skriptet skriver ut `Saved hello.pptx` och sparar *hello.pptx* med en bild som innehåller en rektangel med texten. Utan licens har den sparade filen ett utvärderingsvattenstämpel — se [Licensiering](/slides/sv/nodejs-net/licensing/). För fler sätt att skapa och fylla en presentation, se [Skapa en presentation](/slides/sv/nodejs-net/create-presentation/).