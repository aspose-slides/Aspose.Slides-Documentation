---
title: PowerPoint in PDF in Node.js via .NET konvertieren
linktitle: PowerPoint zu PDF
type: docs
weight: 30
url: /de/nodejs-net/convert-powerpoint-to-pdf/
keywords:
- PowerPoint zu PDF
- PowerPoint zu PDF konvertieren
- PPTX zu PDF
- PPT zu PDF
- ODP zu PDF
- Präsentation als PDF speichern
- PDF/A
- PdfOptions
- PowerPoint
- Präsentation
- Node.js
- JavaScript
- Aspose.Slides
description: "Konvertieren Sie PPTX-, PPT- und ODP-Präsentationen in PDF mit JavaScript mittels Aspose.Slides für Node.js via .NET und erzeugen Sie archivierungsfähige PDF/A-Dateien mit PdfOptions."
---
## **Übersicht**

Aspose.Slides for Node.js via .NET konvertiert PowerPoint- und OpenDocument-Präsentationen in PDF, ohne Microsoft PowerPoint zu benötigen. Jede sichtbare Folie wird zu einer PDF-Seite in derselben Größe wie die Folie, und der Text bleibt auswähl- und durchsuchbar. Dieser Artikel zeigt die Standardkonvertierung und eine Konvertierung zu PDF/A mit [PdfOptions](https://reference.aspose.com/slides/de/net/aspose.slides.export/pdfoptions/).

Die Beispiele erwarten eine Präsentation namens `sample.pptx` im Projektordner, den Sie in [Installation](/slides/de/nodejs-net/installation/) eingerichtet haben. Jede PowerPoint‑Präsentation ist geeignet. Speichern Sie jedes Beispiel als `.js`‑Datei im Projektordner und führen Sie es von dort mit `node` aus.

{{% alert color="info" title="Note" %}}
Aspose.Slides for Node.js via .NET hat keine eigene API‑Referenz. Sie spiegelt die Aspose.Slides for .NET API mit camelCase‑Namen wider, sodass die API‑Links in diesem Artikel zu den entsprechenden Klassen und Mitgliedern in der [Aspose.Slides for .NET API reference](https://reference.aspose.com/slides/de/net/) führen.
{{% /alert %}}

## **Konvertieren einer Präsentation zu PDF**

Um eine Präsentation in PDF zu konvertieren, führen Sie die folgenden Schritte aus:

1. Öffnen Sie die Präsentation, indem Sie ihren Pfad an den [Presentation](https://reference.aspose.com/slides/de/net/aspose.slides/presentation/presentation/)‑Konstruktor übergeben. Der gleiche Code funktioniert für PPTX-, PPT- und ODP‑Dateien.
2. Rufen Sie die [save](https://reference.aspose.com/slides/de/net/aspose.slides/presentation/save/)‑Methode mit dem Ausgabepfad und `SaveFormat.Pdf` auf.
3. Rufen Sie `dispose` in einem `finally`‑Block auf, um die .NET‑Ressourcen, die der Präsentation zugrunde liegen, freizugeben.

```javascript
const { Presentation, SaveFormat } = require("aspose.slides.via.net");

const presentation = new Presentation("sample.pptx");
try {
    presentation.save("sample.pdf", SaveFormat.Pdf);
    console.log("Saved sample.pdf");
} finally {
    presentation.dispose();
}
```

Das Skript schreibt `sample.pdf` in den Projektordner. Die Konvertierung verwendet die Standardeinstellungen: Jede Folie, die nicht ausgeblendet ist, wird zu einer Seite in Folienreihenfolge. Ohne Lizenz wird auf jeder Seite ein Evaluierungs‑Wasserzeichen angezeigt; siehe [Licensing](/slides/de/nodejs-net/licensing/).

## **Konvertieren einer Präsentation zu PDF/A**

Um die Ausgabe zu steuern, übergeben Sie ein [PdfOptions](https://reference.aspose.com/slides/de/net/aspose.slides.export/pdfoptions/)‑Objekt als dritten Parameter von `save`. Das folgende Beispiel setzt die [compliance](https://reference.aspose.com/slides/de/net/aspose.slides.export/pdfoptions/compliance/)‑Eigenschaft auf `PdfCompliance.PdfA2b`, wodurch eine PDF/A‑2b‑Datei erzeugt wird. PDF/A ist der ISO‑Standard für die Langzeitarchivierung: Unter anderem muss jede im Dokument verwendete Schriftart in die Datei eingebettet werden.

```javascript
const { Presentation, SaveFormat, PdfOptions, PdfCompliance } = require("aspose.slides.via.net");

const pdfOptions = new PdfOptions();
pdfOptions.compliance = PdfCompliance.PdfA2b;

const presentation = new Presentation("sample.pptx");
try {
    presentation.save("sample-pdfa.pdf", SaveFormat.Pdf, pdfOptions);
    console.log("Saved sample-pdfa.pdf");
} finally {
    presentation.dispose();
}
```

Das Skript schreibt `sample-pdfa.pdf` mit denselben Seiten wie die Standardkonvertierung. Um zu prüfen, ob eine Datei dem Standard entspricht, überprüfen Sie sie mit einem PDF/A‑Validator wie [veraPDF](https://verapdf.org/). Andere [PdfCompliance](https://reference.aspose.com/slides/de/net/aspose.slides.export/pdfcompliance/)‑Werte wählen andere Standards, wie `PdfA1b`, `PdfA2a` oder `PdfUa` für Barrierefreiheit.

## **FAQ**

**Wie kann ich ausgeblendete Folien in das PDF einfügen?**

Ausgeblendete Folien werden standardmäßig übersprungen. Setzen Sie die [showHiddenSlides](https://reference.aspose.com/slides/de/net/aspose.slides.export/pdfoptions/showhiddenslides/)‑Eigenschaft von `PdfOptions` auf `true` und übergeben Sie die Optionen an `save`.

**Kann ich das PDF mit einem Passwort schützen?**

Ja. Setzen Sie die [password](https://reference.aspose.com/slides/de/net/aspose.slides.export/pdfoptions/password/)‑Eigenschaft von `PdfOptions`, bevor Sie `save` aufrufen. PDF‑Reader fragen dann nach diesem Passwort, bevor sie die Datei öffnen.

**Kann ich nur einige Folien konvertieren?**

Ja. Übergeben Sie ein Array von Folienpositionen als vierten Parameter von `save`. Positionen beginnen bei 1, und der dritte Parameter kann `null` sein, wenn Sie keine Optionen benötigen: `presentation.save("selected.pdf", SaveFormat.Pdf, null, [1, 3])` schreibt ein PDF mit der ersten und dritten Folie.

**Warum sieht der Text anders aus, wenn ich unter Linux konvertiere?**

Aspose.Slides kann nur Schriftarten verwenden, die auf dem Rechner installiert sind, auf dem die Konvertierung ausgeführt wird. Wenn eine Präsentation eine fehlende Schriftart verwendet, z. B. Calibri auf einem typischen Linux‑Server, verwendet Aspose.Slides stattdessen eine installierte Schriftart, was das Aussehen des Textes und den Zeilenumbruch ändern kann. Installieren Sie die von Ihren Präsentationen genutzten Schriftarten, um das gleiche Ergebnis wie unter Windows zu erhalten.

**Kann ich das PDF als Buffer statt als Datei erhalten?**

Ja. `presentation.saveToBuffer(SaveFormat.Pdf)` gibt das PDF als Node.js `Buffer` zurück, was praktisch ist, wenn Sie das Ergebnis in einer HTTP‑Antwort senden. Es akzeptiert außerdem `PdfOptions` als zweiten Parameter.