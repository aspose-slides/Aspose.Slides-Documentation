---
title: PPT und PPTX in PDF mit JavaScript konvertieren [Erweiterte Funktionen enthalten]
linktitle: PowerPoint zu PDF
type: docs
weight: 40
url: /de/nodejs-java/convert-powerpoint-to-pdf/
keywords:
- PowerPoint konvertieren
- Präsentation konvertieren
- PowerPoint zu PDF
- Präsentation zu PDF
- PPT zu PDF
- PPT zu PDF konvertieren
- PPTX zu PDF
- PPTX zu PDF konvertieren
- PowerPoint als PDF speichern
- PPT als PDF speichern
- PPTX als PDF speichern
- PPT nach PDF exportieren
- PPTX nach PDF exportieren
- Anhang
- PDF/A1a
- PDF/A1b
- PDF/UA
- Node.js
- JavaScript
- Aspose.Slides
description: "Konvertieren Sie PowerPoint PPT/PPTX in hochwertige, durchsuchbare PDFs mit Aspose.Slides für Node.js, inklusive schneller Codebeispiele und erweiterter Konvertierungsoptionen."
---
## **Übersicht**

Das Konvertieren von PowerPoint- und OpenDocument‑Präsentationen (PPT, PPTX, ODP usw.) in das PDF‑Format mit JavaScript bietet mehrere Vorteile, darunter Kompatibilität über verschiedene Geräte hinweg und das Bewahren von Layout und Formatierung Ihrer Präsentation. Dieser Leitfaden zeigt, wie Präsentationen in PDF‑Dokumente konvertiert werden, verschiedene Optionen zur Steuerung der Bildqualität verwendet, ausgeblendete Folien einbezogen, PDF‑Dateien mit Passwort geschützt, Schriftartsubstitutionen erkannt, bestimmte Folien zur Konvertierung ausgewählt und Konformitätsstandards auf Ausgabedokumente angewendet werden.

## **PowerPoint‑zu‑PDF‑Konvertierungen**

Mit Aspose.Slides können Sie Präsentationen in den folgenden Formaten in PDF konvertieren:

* **PPT**
* **PPTX**
* **ODP**

Um eine Präsentation in PDF zu konvertieren, übergeben Sie den Dateinamen als Argument an die [Presentation](https://reference.aspose.com/slides/nodejs-java/aspose.slides/presentation/)‑Klasse und speichern Sie die Präsentation anschließend mit der [save](https://reference.aspose.com/slides/nodejs-java/aspose.slides/presentation/save/)‑Methode als PDF. Die [Presentation](https://reference.aspose.com/slides/nodejs-java/aspose.slides/presentation/)‑Klasse stellt die [save](https://reference.aspose.com/slides/nodejs-java/aspose.slides/presentation/save/)‑Methode bereit, die typischerweise zum Konvertieren einer Präsentation in PDF verwendet wird.

{{% alert color="info" title="Note" %}}

Aspose.Slides for Node.js via Java fügt seine API‑Informationen und Versionsnummer in Ausgabedokumente ein. Beispielweise füllt Aspose.Slides beim Konvertieren einer Präsentation in PDF das Feld **Application** mit "*Aspose.Slides*" und das Feld **PDF Producer** mit einem Wert in der Form "*Aspose.Slides v XX.XX*" aus. **Hinweis**: Sie können Aspose.Slides nicht anweisen, diese Informationen aus Ausgabedokumenten zu ändern oder zu entfernen.

{{% /alert %}}

Aspose.Slides ermöglicht es Ihnen, zu konvertieren:

* Ganze Präsentationen in PDF
* Bestimmte Folien einer Präsentation in PDF

Aspose.Slides exportiert Präsentationen nach PDF und sorgt dafür, dass die resultierenden PDFs den Originalpräsentationen eng entsprechen. Elemente und Attribute werden bei der Konvertierung genau gerendert, darunter:

* Bilder
* Textfelder und Formen
* Textformatierung
* Absatzformatierung
* Hyperlinks
* Kopf‑ und Fußzeilen
* Aufzählungszeichen
* Tabellen

## **PowerPoint in PDF konvertieren**

Der standardmäßige PowerPoint‑zu‑PDF‑Konvertierungsprozess verwendet Standardoptionen. In diesem Fall versucht Aspose.Slides, die bereitgestellte Präsentation mit optimalen Einstellungen auf höchstem Qualitätsniveau in PDF zu konvertieren.

Das folgende Beispiel lädt eine Präsentation und speichert alle sichtbaren Folien als PDF mit den Standard‑Export‑Einstellungen.

```js
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");

let presentation = new aspose.slides.Presentation("PowerPoint.ppt");
try {
    presentation.save("PPT-to-PDF.pdf", aspose.slides.SaveFormat.Pdf);
} finally {
    presentation.dispose();
}
```

{{% alert color="info" title="Note" %}}

Aspose bietet einen kostenlosen Online‑[**PowerPoint‑to‑PDF‑Konverter**](https://products.aspose.app/slides/conversion/ppt-to-pdf), der den Präsentation‑zu‑PDF‑Konvertierungsprozess demonstriert. Sie können mit diesem Konverter einen Test für eine Live‑Implementierung des hier beschriebenen Verfahrens durchführen.

{{% /alert %}}

## **PowerPoint in PDF konvertieren mit Optionen**

Aspose.Slides stellt benutzerdefinierte Optionen — Eigenschaften der Klasse [PdfOptions](https://reference.aspose.com/slides/nodejs-java/aspose.slides/pdfoptions/) — zur Verfügung, mit denen Sie das resultierende PDF anpassen, das PDF mit einem Passwort schützen oder festlegen können, wie der Konvertierungsprozess ablaufen soll.

### **PowerPoint in PDF konvertieren mit benutzerdefinierten Optionen**

Mit benutzerdefinierten Konvertierungsoptionen können Sie Ihre bevorzugte Qualitäts‑Einstellung für Rasterbilder festlegen, bestimmen, wie Metadateien behandelt werden, einen Komprimierungsgrad für Text setzen, DPI für Bilder konfigurieren und vieles mehr.

Das folgende Beispiel exportiert eine Präsentation nach PDF 1.5 mit JPEG‑Qualität 90, Bildauflösung 300 DPI, Metadateien als PNG gespeichert und Flate‑Textkomprimierung.

```js
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");
const java = require("java");

let pdfOptions = new aspose.slides.PdfOptions();
pdfOptions.setJpegQuality(java.newByte(90));
pdfOptions.setSufficientResolution(300);
pdfOptions.setSaveMetafilesAsPng(true);
pdfOptions.setTextCompression(aspose.slides.PdfTextCompression.Flate);
pdfOptions.setCompliance(aspose.slides.PdfCompliance.Pdf15);

let presentation = new aspose.slides.Presentation("PowerPoint.pptx");
try {
    presentation.save("PowerPoint-to-PDF.pdf", aspose.slides.SaveFormat.Pdf, pdfOptions);
} finally {
    presentation.dispose();
}
```

### **Automatische Auswahl der Bildkomprimierung**

Enthält eine Präsentation viele Fotos oder Screenshots, kann das Reduzieren der Größe des exportierten PDFs das E‑Mail‑ oder Download‑Verfahren erleichtern. Rufen Sie [PdfOptions.setBestImagesCompressionRatio](https://reference.aspose.com/slides/nodejs-java/aspose.slides/pdfoptions/setbestimagescompressionratio/) mit `true` auf, um während des PDF‑Exports automatisch den am besten geeigneten Komprimierungsalgorithmus für jedes Bild auszuwählen.

Das folgende Beispiel lädt eine vorhandene Präsentation, aktiviert die automatische Bildkomprimierung und speichert sie als PDF‑Dokument. Alle anderen PDF‑Export‑Einstellungen behalten ihre Standardwerte.

```javascript
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");

let pdfOptions = new aspose.slides.PdfOptions();
pdfOptions.setBestImagesCompressionRatio(true);

let presentation = new aspose.slides.Presentation("presentation.pptx");
try {
    presentation.save("presentation.pdf", aspose.slides.SaveFormat.Pdf, pdfOptions);
} finally {
    presentation.dispose();
}
```

Diese Option wählt für jedes Bild einen Komprimierungsalgorithmus aus. Das Verringern des an [setJpegQuality](https://reference.aspose.com/slides/nodejs-java/aspose.slides/pdfoptions/setjpegquality/) übergebenen Werts reduziert stattdessen die JPEG‑Bildqualität, während das Verringern des an [setSufficientResolution](https://reference.aspose.com/slides/nodejs-java/aspose.slides/pdfoptions/setsufficientresolution/) übergebenen Werts das Herunterskalieren der Bilder auf eine niedrigere Auflösung erlaubt, was Details reduzieren kann. Das Aktivieren der automatischen Komprimierung senkt diese beiden Einstellungen nicht automatisch.

Die Auswahl von Bildkomprimierungs‑Algorithmen erfordert zusätzlichen Verarbeitungs‑ und Speicheraufwand. Die Größenreduktion hängt von den Bildern und den Export‑Einstellungen der Präsentation ab; eine feste Reduktion ist für jede Präsentation nicht garantiert.

### **Eingebettete OLE‑Dateien als PDF‑Anhänge erhalten**

Enthält eine Präsentation ein eingebettetes Excel‑Arbeitsbuch, möchten Sie vielleicht, dass PDF‑Empfänger sowohl auf die Daten des Arbeitsbuchs als auch auf die Folien zugreifen können. Rufen Sie [setIncludeOleData](https://reference.aspose.com/slides/nodejs-java/aspose.slides/pdfoptions/) mit `true` auf, um eingebettete OLE‑Dateien als Anhänge im resultierenden PDF zu erhalten.

Der Standardwert ist `false`: Das Vorschaubild oder Symbol des OLE‑Objekts wird auf der PDF‑Seite gerendert, das eingebettete Dokument jedoch nicht als Anhang eingefügt. Wird die Option auf `true` gesetzt, wird zusätzlich die Dateidaten eingebettet. Die Vorschau bleibt eine visuelle Darstellung; der Anhang ermöglicht dem Empfänger, die eingebettete Datei separat zu öffnen oder zu speichern. Das OLE‑Objekt wird nicht zu einem interaktiven Excel‑Arbeitsblatt auf der PDF‑Seite.

Das folgende Beispiel lädt eine Präsentation, die bereits ein eingebettetes Excel‑Arbeitsbuch enthält, und exportiert sie nach PDF mit dem angehängten Arbeitsbuch.

```js
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");

let pdfOptions = new aspose.slides.PdfOptions();
pdfOptions.setIncludeOleData(true);

let presentation = new aspose.slides.Presentation("presentation.pptx");
try {
    presentation.save("presentation.pdf", aspose.slides.SaveFormat.Pdf, pdfOptions);
} finally {
    presentation.dispose();
}
```

So prüfen Sie das Ergebnis:

1. Öffnen Sie das exportierte PDF in einem Viewer, der Dateianhänge unterstützt, z. B. Adobe Acrobat Reader.
2. Öffnen Sie das **Attachments**‑Panel des Viewers und suchen Sie das eingebettete Arbeitsbuch.
3. Speichern Sie den Anhang und öffnen Sie ihn in Excel, um die Daten zu prüfen, oder öffnen Sie ihn direkt, falls der Viewer dies zulässt. Die Vorschau auf der PDF‑Seite ist vom Anhang getrennt.

{{% alert color="info" title="Note" %}}

Die PDF/A‑Standards legen Beschränkungen für Anhänge fest: PDF/A‑1 verbietet eingebettete Dateien, PDF/A‑2 erlaubt nur PDF/A‑Anhänge und PDF/A‑3 erlaubt andere Dateitypen, einschließlich Excel‑Arbeitsbüchern. Diese Vorgaben stammen aus den Standards selbst, nicht aus Einschränkungen von Aspose.Slides. Dieses Beispiel verwendet die Standard‑PDF‑Konformitätseinstellung und demonstriert keinen PDF/A‑Export.

{{% /alert %}}

### **PowerPoint in PDF konvertieren mit ausgeblendeten Folien**

Enthält eine Präsentation ausgeblendete Folien, können Sie die Methode [setShowHiddenSlides](https://reference.aspose.com/slides/nodejs-java/aspose.slides/pdfoptions/setshowhiddenslides/) der Klasse [PdfOptions](https://reference.aspose.com/slides/nodejs-java/aspose.slides/pdfoptions/) verwenden, um die ausgeblendeten Folien als Seiten in das resultierende PDF aufzunehmen.

Das folgende Beispiel exportiert eine Präsentation nach PDF und schließt dabei alle ausgeblendeten Folien ein.

```js
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");

let pdfOptions = new aspose.slides.PdfOptions();
pdfOptions.setShowHiddenSlides(true);

let presentation = new aspose.slides.Presentation("PowerPoint.pptx");
try {
    presentation.save("PowerPoint-to-PDF.pdf", aspose.slides.SaveFormat.Pdf, pdfOptions);
} finally {
    presentation.dispose();
}
```

### **PowerPoint in ein passwortgeschütztes PDF konvertieren**

Das folgende Beispiel exportiert eine Präsentation in ein PDF, das zum Öffnen das Passwort `password` erfordert. Die Zugriffsrechte erlauben das Drucken, einschließlich qualitativ hochwertigem Druck.

```js
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");

let pdfOptions = new aspose.slides.PdfOptions();
pdfOptions.setPassword("password");
pdfOptions.setAccessPermissions(aspose.slides.PdfAccessPermissions.PrintDocument | aspose.slides.PdfAccessPermissions.HighQualityPrint);

let presentation = new aspose.slides.Presentation("PowerPoint.pptx");
try {
    presentation.save("PPTX-to-PDF.pdf", aspose.slides.SaveFormat.Pdf, pdfOptions);
} finally {
    presentation.dispose();
}
```

### **Schriftartsubstitutionen erkennen**

Aspose.Slides stellt die Methode [setWarningCallback](https://reference.aspose.com/slides/nodejs-java/aspose.slides/saveoptions/) der Klasse [PdfOptions](https://reference.aspose.com/slides/nodejs-java/aspose.slides/pdfoptions/) bereit, mit der Sie während des Präsentation‑zu‑PDF‑Konvertierungsprozesses Schriftartsubstitutionen erkennen können.

Das folgende Beispiel exportiert eine Präsentation nach PDF und gibt Schriftart‑Substitutions‑Warnungen in die Konsole aus. Eine Warnung wird nur dann ausgegeben, wenn während des Exports eine nicht verfügbare Schriftart substituiert wird.

```js
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");
const java = require("java");

const FontSubstitutionHandler = java.newProxy("com.aspose.slides.IWarningCallback", {
	warning: function (warning) {
		if (warning.getWarningType() === aspose.slides.WarningType.DataLoss && warning.getDescription().startsWith("Font will be substituted")) {
			console.warn("Font substitution warning: " + warning.getDescription());
		}
		return aspose.slides.ReturnAction.Continue;
	}
});

let pdfOptions = new aspose.slides.PdfOptions();
pdfOptions.setWarningCallback(FontSubstitutionHandler);

let presentation = new aspose.slides.Presentation("sample.pptx");
try {
    presentation.save("output.pdf", aspose.slides.SaveFormat.Pdf, pdfOptions);
} finally {
    presentation.dispose();
}
```

{{% alert color="info" title="Note" %}}

Weitere Informationen zur Schriftartsubstitution finden Sie im Artikel [Font Substitution](/slides/de/nodejs-java/font-substitution/).

{{% /alert %}} 

### **Umgang mit Schriften ohne eigene fette Variante**

Eine Präsentation kann fetten Text anwenden, obwohl die Schriftart keine eigene fette Variante besitzt. Der Text kann dennoch durch synthetisches Fettschriftbild hervorgehoben werden, das die regulären Glyphen künstlich verdickt. Wenn dieser Text im PDF zu stark erscheint oder vom gewünschten Aussehen abweicht, rufen Sie [PdfOptions.setRasterizeUnsupportedFontStyles](https://reference.aspose.com/slides/nodejs-java/aspose.slides/pdfoptions/) mit `true` auf. Diese Option rendert den betroffenen Text während des PDF‑Exports als Bitmap und kann das Aussehen bei bestimmten Schriften verbessern. Der Standardwert ist `false`.

Die Beispiel‑Präsentation enthält zwei Textfelder: eines mit normalem Text und eines, bei dem dieselbe Schriftart fett formatiert ist, obwohl sie keine eigene fette Variante hat. Das folgende Beispiel lädt die Präsentation, aktiviert die Rasterung nicht unterstützter Schriftschnitte und exportiert sie nach PDF:

```javascript
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");

let pdfOptions = new aspose.slides.PdfOptions();
pdfOptions.setRasterizeUnsupportedFontStyles(true);

let presentation = new aspose.slides.Presentation("unsupported-bold.pptx");
try {
    presentation.save("rasterized.pdf", aspose.slides.SaveFormat.Pdf, pdfOptions);
} finally {
    presentation.dispose();
}
```

Die nachfolgenden Vorschaubilder zeigen die Ausgabe mit deaktivierter bzw. aktivierter Option. In diesem Beispiel hat der fette Text bei deaktivierter Option stärkere Striche. Bei aktivierter Option sind die Striche leichter; der normale Text bleibt unverändert. Vergleichen Sie die Ergebnisse, bevor Sie die Einstellung für Ihre Präsentation wählen.

| Option deaktiviert (`false`, Standard) | Option aktiviert (`true`) |
|---|---|
| ![PDF with unsupported font style rasterization disabled](unsupported-bold-disabled.png) | ![PDF with unsupported font style rasterization enabled](unsupported-bold-enabled.png) |

In diesem Beispiel führt das Aktivieren der Option dazu, dass nur der fette Text zu einer Bitmap wird: Er kann ohne OCR nicht mehr ausgewählt, kopiert oder als Text durchsucht werden, und seine Kanten wirken bei 800 % Zoom weicher. Der normale Text bleibt durchsuchbar. Bei deaktivierter Option bleiben beide Zeichenketten als Text erhalten.

Diese Option rastert Text, der als fett formatiert ist, wenn die Schriftart keine eigene fette Variante besitzt. Stattdessen wählt [Font substitution](/slides/de/nodejs-java/font-substitution/) eine Ersatzschriftart, wenn die Originalschriftart nicht verfügbar ist.

## **Ausgewählte Folien aus PowerPoint in PDF konvertieren**

Das folgende Beispiel exportiert die Folien 1 und 3 einer Präsentation nach PDF. Die Foliennummern in diesem Array beginnen bei 1, und die Eingabep­rä­senta­tion muss mindestens drei Folien enthalten.

```js
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");
const java = require("java");

let presentation = new aspose.slides.Presentation("PowerPoint.pptx");
try {
    let slides = java.newArray("int", [1, 3]);
    presentation.save("PPTX-to-PDF.pdf", slides, aspose.slides.SaveFormat.Pdf);
} finally {
    presentation.dispose();
}
```

## **PowerPoint in PDF mit benutzerdefinierter Foliengröße konvertieren**

Das folgende Beispiel kopiert die erste Folie einer Präsentation in eine neue Präsentation mit einer Foliengröße von 612 × 792 Punkten (8,5 × 11 Zoll). Der Folieninhalt wird skaliert, um zu passen, und die einzelne Folie wird nach PDF exportiert.

```js
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");

const slideWidth = 612;
const slideHeight = 792;

let presentation = new aspose.slides.Presentation("SelectedSlides.pptx");
let resizedPresentation = new aspose.slides.Presentation();

try {
    resizedPresentation.getSlideSize().setSize(slideWidth, slideHeight, aspose.slides.SlideSizeScaleType.EnsureFit);
    let slide = presentation.getSlides().get_Item(0);
    resizedPresentation.getSlides().insertClone(0, slide);

    // Entferne die leere Folie, die bei der Erstellung der neuen Präsentation erstellt wurde.
    resizedPresentation.getSlides().removeAt(1);

    resizedPresentation.save("PDF_with_custom_slide_size.pdf", aspose.slides.SaveFormat.Pdf);
} finally {
    resizedPresentation.dispose();
    presentation.dispose();
}
```

## **PowerPoint in PDF in Notizfolien‑Ansicht konvertieren**

Das folgende Beispiel exportiert eine Präsentation nach PDF und platziert die Sprecher‑Notizen jeder Folie unterhalb der Folie. Verwenden Sie eine Präsentation mit Sprecher‑Notizen, um das Ergebnis zu sehen.

```js
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");

let notesOptions = new aspose.slides.NotesCommentsLayoutingOptions();
notesOptions.setNotesPosition(aspose.slides.NotesPositions.BottomFull);

let pdfOptions = new aspose.slides.PdfOptions();
pdfOptions.setSlidesLayoutOptions(notesOptions);

let presentation = new aspose.slides.Presentation("SelectedSlides.pptx");
try {
    presentation.save("PDF_with_notes.pdf", aspose.slides.SaveFormat.Pdf, pdfOptions);
} finally {
    presentation.dispose();
}
```

## **Zugänglichkeit und Konformitätsstandards für PDF**

Aspose.Slides ermöglicht ein Konvertierungsverfahren, das den [Web Content Accessibility Guidelines (**WCAG**)](https://www.w3.org/TR/WCAG-TECHS/pdf.html) entspricht. Sie können ein PowerPoint‑Dokument nach PDF exportieren und dabei folgende Konformitätsstandards verwenden: **PDF/A1a**, **PDF/A1b** und **PDF/UA**.

Der folgende Code demonstriert einen PowerPoint‑zu‑PDF‑Konvertierungsprozess, der mehrere PDFs basierend auf unterschiedlichen Konformitätsstandards erzeugt:

```js
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");

let presentation = new aspose.slides.Presentation("pres.pptx");
try {
    let pdfOptions = new aspose.slides.PdfOptions();

    pdfOptions.setCompliance(aspose.slides.PdfCompliance.PdfA1a);
    presentation.save("pres-a1a-compliance.pdf", aspose.slides.SaveFormat.Pdf, pdfOptions);

    pdfOptions.setCompliance(aspose.slides.PdfCompliance.PdfA1b);
    presentation.save("pres-a1b-compliance.pdf", aspose.slides.SaveFormat.Pdf, pdfOptions);

    pdfOptions.setCompliance(aspose.slides.PdfCompliance.PdfUa);
    presentation.save("pres-ua-compliance.pdf", aspose.slides.SaveFormat.Pdf, pdfOptions);
} finally {
    presentation.dispose();
}
```

{{% alert color="info" title="Note" %}}

Aspose.Slides unterstützt PDF‑Konvertierungs‑Operationen, mit denen Sie PDF‑Dateien in gängige Formate konvertieren können. Sie können [PDF to HTML](https://products.aspose.com/slides/nodejs-java/conversion/pdf-to-html/), [PDF to JPG](https://products.aspose.com/slides/nodejs-java/conversion/pdf-to-jpg/) und [PDF to PNG](https://products.aspose.com/slides/nodejs-java/conversion/pdf-to-png/) durchführen. Weitere Spezial‑PDF‑Konvertierungen – [PDF to SVG](https://products.aspose.com/slides/nodejs-java/conversion/pdf-to-svg/), [PDF to TIFF](https://products.aspose.com/slides/nodejs-java/conversion/pdf-to-tiff/) – werden ebenfalls unterstützt.

{{% /alert %}}

> **Hinweis:** Beim Export nach PDF/UA behandelt Aspose.Slides komplexe Grafiken wie SmartArt, Diagramme und Formeln als einzelne Figur. Einzelne Pfadelemente werden nicht als separater Inhalt erhalten und können als Artefakte markiert werden; alternativer Text wird nur für die gesamte Figur bereitgestellt.

## **FAQ**

**Kann ich mehrere PowerPoint‑Dateien in einem Batch‑Durchlauf in PDF konvertieren?**

Ja, Aspose.Slides unterstützt die Stapelverarbeitung mehrerer PPT‑ oder PPTX‑Dateien zu PDF. Sie können Ihre Dateien iterativ durchlaufen und den Konvertierungsprozess programmgesteuert anwenden.

**Ist es möglich, das konvertierte PDF mit einem Passwort zu schützen?**

Ja. Verwenden Sie die Klasse [PdfOptions](https://reference.aspose.com/slides/nodejs-java/aspose.slides/pdfoptions/), um ein Passwort zu setzen und Zugriffsrechte während des Konvertierungsprozesses zu definieren.

**Wie kann ich ausgeblendete Folien in das PDF aufnehmen?**

Rufen Sie die Methode [setShowHiddenSlides](https://reference.aspose.com/slides/nodejs-java/aspose.slides/pdfoptions/setshowhiddenslides/) mit `true` in der Klasse [PdfOptions](https://reference.aspose.com/slides/nodejs-java/aspose.slides/pdfoptions/) auf, um ausgeblendete Folien im resultierenden PDF zu inkludieren.

**Kann Aspose.Slides eine hohe Bildqualität im PDF beibehalten?**

Ja, Sie können die Bildqualität steuern, indem Sie Methoden wie [setJpegQuality](https://reference.aspose.com/slides/nodejs-java/aspose.slides/pdfoptions/setjpegquality/) und [setSufficientResolution](https://reference.aspose.com/slides/nodejs-java/aspose.slides/pdfoptions/setsufficientresolution/) in der Klasse [PdfOptions](https://reference.aspose.com/slides/nodejs-java/aspose.slides/pdfoptions/) verwenden, um hochwertige Bilder in Ihrem PDF sicherzustellen.

**Unterstützt Aspose.Slides die PDF/A‑Konformitätsstandards?**

Ja, Aspose.Slides ermöglicht den Export von PDFs, die den [verschiedenen Standards](https://reference.aspose.com/slides/nodejs-java/aspose.slides/pdfcompliance/) entsprechen, darunter PDF/A1a, PDF/A1b und PDF/UA, sodass Ihre Dokumente sowohl barrierefrei als auch archivierungstauglich sind.

## **Zusätzliche Ressourcen**

- [Aspose.Slides for Node.js via Java Documentation](/slides/de/nodejs-java/)
- [Aspose.Slides for Node.js via Java API Reference](https://reference.aspose.com/slides/nodejs-java/)
- [Aspose Free Online Converters](https://products.aspose.app/slides/conversion)