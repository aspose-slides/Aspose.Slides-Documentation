---
title: Aspose.Slides für Node.js über .NET
second_title: Aspose.Slides für Node.js
type: docs
weight: 47
url: /de/nodejs-net/
keywords:
- Dokumentation
- Präsentationsverarbeitung
- Präsentationskonvertierung
- PowerPoint
- OpenDocument
- Node.js
- JavaScript
- Aspose.Slides
description: "Starten Sie hier: Installieren Sie Aspose.Slides für Node.js über .NET, erstellen Sie eine erste Präsentation und finden Sie die Anleitungen für gängige Aufgaben, Lizenzierung, die API-Referenz und den Support."
is_root: true
---
<img src="aspose_slides-for-nodejs-via-net.png" alt="Aspose.Slides für Node.js über .NET" align="left" style="width:110px; margin: 0 30px 20px 0"/>

Aspose.Slides für Node.js über .NET ist eine Bibliothek zum Erstellen, Lesen, Bearbeiten und Konvertieren von PowerPoint‑ und OpenDocument‑Präsentationen in Node.js‑Anwendungen, ohne Microsoft PowerPoint oder Office‑Automation. Sie führt Aspose.Slides für .NET über die edge‑js‑Brücke aus, sodass ihre JavaScript‑API die .NET‑API mit camelCase‑Membernamen spiegelt.

Sie lädt und speichert PPT, PPTX, PPS, POT und ODP, einschließlich makroaktivierter und Vorlagen‑Varianten, und exportiert nach PDF, XPS, HTML, TIFF, Markdown und Bildern.

<div style="clear:both"></div>

------

<div class="row">
<div class="col-md-4">
<p><b>Erste Schritte</b></p>
<hr>
<p>ERSTE SCHRITTE</p>
<ul>
<li><a href="/slides/de/nodejs-net/installation/">Installation</a></li>
<li><a href="/slides/de/nodejs-net/create-presentation/">Erstellen Sie Ihre erste Präsentation</a></li>
<li><a href="/slides/de/nodejs-net/developer-guide/">Entwicklerhandbuch</a></li>
</ul>
<p>BEWERTEN</p>
<ul>
<li><a href="/slides/de/nodejs-net/evaluate-aspose-slides/">Einschränkungen der Testversion</a></li>
<li><a href="/slides/de/nodejs-net/licensing/">Lizenzierung</a></li>
</ul>
</div>
<div class="col-md-4">
<p><b>Erstellen mit Slides</b></p>
<hr>
<p>ALLGEMEINE AUFGABEN</p>
<ul>
<li><a href="/slides/de/nodejs-net/open-presentation/">Präsentation öffnen und speichern</a></li>
<li><a href="/slides/de/nodejs-net/convert-powerpoint-to-pdf/">In PDF konvertieren</a></li>
<li><a href="/slides/de/nodejs-net/convert-slide/">Folien als Bilder rendern</a></li>
<li><a href="/slides/de/nodejs-net/manage-text/">Text bearbeiten</a></li>
</ul>
</div>
<div class="col-md-4">
<p><b>Referenz &amp; Support</b></p>
<hr>
<p>REFERENZ</p>
<ul>
<li><a href="https://reference.aspose.com/slides/net/">.NET API-Referenz</a></li>
<li><a href="https://releases.aspose.com/slides/nodejs-net/release-notes/">Release-Notizen</a></li>
<li><a href="https://products.aspose.com/slides/nodejs-net/">Produktseite</a></li>
<li><a href="https://releases.aspose.com/slides/nodejs-net/">Download</a></li>
</ul>
<p>SUPPORT</p>
<ul>
<li><a href="https://forum.aspose.com/c/slides/11">Kostenloses Support-Forum</a></li>
<li><a href="https://helpdesk.aspose.com/">Kostenpflichtiger Support-Helpdesk</a></li>
</ul>
</div>
</div>

------

## **Ihre erste Präsentation**

Sie benötigen Node.js 22 oder 24 sowie das .NET SDK 8 oder höher; unter Linux werden außerdem einige Systempakete benötigt. [Installation](/slides/de/nodejs-net/installation/) listet sie und die getesteten Plattformen auf. Erstellen Sie ein Projekt, fügen Sie eine Überschreibung hinzu, die npm mitteilt, welche edge‑js‑Version zu installieren ist, und installieren Sie das Paket:

```sh
mkdir hello-slides
cd hello-slides
npm init -y
npm pkg set overrides.edge-js=26.1.0
npm install aspose.slides.via.net
```

Einmal pro Maschine stellen Sie die .NET‑Pakete wieder her, von denen die Bibliothek abhängt. Speichern Sie die `deps.csproj`‑Datei aus [Wiederherstellung der .NET‑Abhängigkeiten](/slides/de/nodejs-net/installation/#restore-the-net-dependencies) in einem `deps`‑Ordner im Projektordner und führen Sie dann aus:

```sh
dotnet restore deps/deps.csproj
```

Speichern Sie diesen Code als *hello.js* im Projektordner:

```javascript
const asposeSlides = require("aspose.slides.via.net");
const { Presentation, ShapeType, SaveFormat } = asposeSlides;

// Eine neue Präsentation enthält eine leere Folie.
const presentation = new Presentation();
try {
    const slide = presentation.slides.get(0);

    // Position und Größe sind in Punkten (1/72 Zoll): x, y, Breite, Höhe.
    const rectangle = slide.shapes.addAutoShape(ShapeType.Rectangle, 50, 50, 400, 100);
    rectangle.addTextFrame("Hello, World!");

    presentation.save("hello.pptx", SaveFormat.Pptx);
    console.log("Saved hello.pptx");
} finally {
    // Das .NET-Objekt freigeben, das die Präsentation unterstützt.
    presentation.dispose();
}
```

Führen Sie ihn aus dem Projektordner aus:

```sh
node hello.js
```

Das Skript gibt `Saved hello.pptx` aus und speichert *hello.pptx* mit einer Folie, die ein Rechteck mit dem Text enthält. Ohne Lizenz enthält die gespeicherte Datei ein Evaluationswasserzeichen — siehe [Lizenzierung](/slides/de/nodejs-net/licensing/). Weitere Möglichkeiten, eine Präsentation zu erstellen und zu füllen, finden Sie unter [Erstellen einer Präsentation](/slides/de/nodejs-net/create-presentation/).