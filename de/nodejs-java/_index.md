---
title: Aspose.Slides für Node.js via Java
second_title: Aspose.Slides für Node.js
type: docs
weight: 47
url: /de/nodejs-java/
keywords:
- Dokumentation
- Präsentationsverarbeitung
- Präsentationskonvertierung
- PowerPoint
- OpenDocument
- Node.js
- JavaScript
- Aspose.Slides
description: "Beginnen Sie hier: installieren Sie Aspose.Slides für Node.js via Java, erstellen Sie eine erste Präsentation und finden Sie die Anleitungen für gängige Aufgaben, die API-Referenz und den Support."
is_root: true
---
<img src="aspose_slides-for-nodejs-via-java.png" alt="Aspose.Slides für Node.js via Java" align="left" style="width:110px; margin: 0 30px 20px 0"/>

Aspose.Slides for Node.js via Java ist eine Bibliothek zum Erstellen, Lesen, Bearbeiten und Konvertieren von PowerPoint- und OpenDocument-Präsentationen in Node.js‑Anwendungen, ohne Microsoft PowerPoint.

Sie lädt und speichert PPT, PPTX, PPS, POT und ODP, einschließlich makro‑aktivierter und Vorlagen‑Varianten, und exportiert nach PDF, XPS, HTML, SVG, TIFF, Markdown und Bildern.

<div style="clear:both"></div>

------

<div class="row">
<div class="col-md-4">
<p><b>Erste Schritte</b></p>
<hr>
<p>ERSTE SCHRITTE</p>
<ul>
<li><a href="/slides/de/nodejs-java/installation/">Installation</a></li>
<li><a href="/slides/de/nodejs-java/create-presentation/">Erstellen Sie Ihre erste Präsentation</a></li>
<li><a href="/slides/de/nodejs-java/getting-started/">Leitfaden für den Einstieg</a></li>
</ul>
<p>EVALUIEREN</p>
<ul>
<li><a href="/slides/de/nodejs-java/supported-file-formats/">Unterstützte Dateiformate</a></li>
<li><a href="/slides/de/nodejs-java/evaluate-aspose-slides/">Einschränkungen der Testversion</a></li>
<li><a href="/slides/de/nodejs-java/licensing/">Lizenzierung</a></li>
</ul>
</div>
<div class="col-md-4">
<p><b>Erstellen mit Slides</b></p>
<hr>
<p>ÜBLICHE AUFGABEN</p>
<ul>
<li><a href="/slides/de/nodejs-java/open-presentation/">Präsentation öffnen</a></li>
<li><a href="/slides/de/nodejs-java/save-presentation/">Präsentation speichern</a></li>
<li><a href="/slides/de/nodejs-java/convert-powerpoint-to-pdf/">In PDF konvertieren</a></li>
<li><a href="/slides/de/nodejs-java/convert-slide/">Folien als Bilder rendern</a></li>
<li><a href="/slides/de/nodejs-java/manage-text/">Text und Formen bearbeiten</a></li>
</ul>
<p>SLIDES‑ARBEITSABFLÄUFE</p>
<ul>
<li><a href="/slides/de/nodejs-java/powerpoint-charts/">Diagramme</a></li>
<li><a href="/slides/de/nodejs-java/powerpoint-animation/">Animationen</a></li>
<li><a href="/slides/de/nodejs-java/manage-media-files/">Audio und Video</a></li>
<li><a href="/slides/de/nodejs-java/presentation-design/">Folien‑Design</a></li>
<li><a href="/slides/de/nodejs-java/merge-presentation/">Präsentationen zusammenführen</a></li>
</ul>
<p>BEISPIELE</p>
<ul>
<li><a href="/slides/de/nodejs-java/examples/">Beispiele nach Folienelement</a></li>
</ul>
</div>
<div class="col-md-4">
<p><b>Referenz &amp; Support</b></p>
<hr>
<p>REFERENZ</p>
<ul>
<li><a href="https://reference.aspose.com/slides/de/nodejs-java/">API‑Referenz</a></li>
<li><a href="https://releases.aspose.com/slides/de/nodejs-java/release-notes/">Versionshinweise</a></li>
<li><a href="/slides/de/nodejs-java/known-issues/">Bekannte Probleme</a></li>
<li><a href="https://releases.aspose.com/slides/de/nodejs-java/">Download</a></li>
</ul>
<p>SUPPORT</p>
<ul>
<li><a href="https://forum.aspose.com/c/slides/de/11">Kostenloses Support‑Forum</a></li>
<li><a href="https://helpdesk.aspose.com/">Kostenpflichtiger Support‑Helpdesk</a></li>
</ul>
</div>
</div>

------

## **Ihre erste Präsentation**

Zusätzlich zu Node.js 20 oder höher benötigt das Paket ein Java Development Kit (JDK), Python und ein C++‑Build‑Toolchain, weil npm während der Installation seine `java`‑Bridge kompiliert. Siehe [Installation](/slides/de/nodejs-java/installation/) für die Schritte auf jedem Betriebssystem. Erstellen Sie dann ein Projekt und installieren Sie das Paket über npm:

```bash
mkdir hello-slides
cd hello-slides
npm init -y
npm install aspose.slides.via.java
```

Speichern Sie diesen Code als *hello.js* im Projektordner:

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

// Aspose.Slides läuft in einer Java-Virtual-Maschine, die Node.js am Laufen hält, daher den Prozess explizit beenden.
process.exit(0);
```

Führen Sie ihn mit `node hello.js` aus. Das Skript speichert *hello.pptx* mit einer Folie, die ein Textfeld enthält. Ohne Lizenz enthält die gespeicherte Datei ein Evaluations‑Wasserzeichen — siehe [Licensing](/slides/de/nodejs-java/licensing/). Für weitere Möglichkeiten zum Erstellen und Befüllen einer Präsentation siehe [Create Presentations](/slides/de/nodejs-java/create-presentation/).