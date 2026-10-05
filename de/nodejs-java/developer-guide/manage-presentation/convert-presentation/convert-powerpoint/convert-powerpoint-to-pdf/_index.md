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
description: "PowerPoint PPT/PPTX mit Aspose.Slides für Node.js in hochwertige, durchsuchbare PDFs konvertieren, mit schnellen Codebeispielen und erweiterten Konvertierungsoptionen."
---
## **Übersicht**

Das Konvertieren von PowerPoint- und OpenDocument-Präsentationen (PPT, PPTX, ODP usw.) in das PDF-Format in JavaScript bietet mehrere Vorteile, darunter Kompatibilität über verschiedene Geräte hinweg und die Erhaltung des Layouts und der Formatierung Ihrer Präsentation. Dieses Handbuch zeigt, wie Präsentationen in PDF-Dokumente konvertiert werden, verschiedene Optionen zur Steuerung der Bildqualität verwendet werden, versteckte Folien einbezogen werden, PDF-Dateien mit einem Passwort geschützt werden, Schriftart‑Ersetzungen erkannt werden, bestimmte Folien für die Konvertierung ausgewählt werden und Compliance‑Standards auf die Ausgabedokumente angewendet werden.

## **PowerPoint-zu-PDF-Konvertierungen**

Mit Aspose.Slides können Sie Präsentationen in den folgenden Formaten in PDF konvertieren:

* **PPT**
* **PPTX**
* **ODP**

Um eine Präsentation in PDF zu konvertieren, übergeben Sie den Dateinamen als Argument an die [Presentation](https://reference.aspose.com/slides/nodejs-java/aspose.slides/presentation/)‑Klasse und speichern Sie die Präsentation anschließend mit der [save](https://reference.aspose.com/slides/nodejs-java/aspose.slides/presentation/#save)-Methode als PDF. Die [Presentation](https://reference.aspose.com/slides/nodejs-java/aspose.slides/presentation/)‑Klasse stellt die [save](https://reference.aspose.com/slides/nodejs-java/aspose.slides/presentation/#save)-Methode bereit, die typischerweise zum Konvertieren einer Präsentation in PDF verwendet wird.

{{% alert color="info" title="Note" %}}
Aspose.Slides für Node.js via Java fügt seine API‑Informationen und Versionsnummer in Ausgabedokumente ein. Zum Beispiel füllt Aspose.Slides beim Konvertieren einer Präsentation in PDF das Anwendungsfeld mit "*Aspose.Slides*" und das PDF‑Producer‑Feld mit einem Wert in der Form "*Aspose.Slides v XX.XX*". **Hinweis**: Sie können Aspose.Slides nicht anweisen, diese Informationen in den Ausgabedokumenten zu ändern oder zu entfernen.
{{% /alert %}}

Aspose.Slides ermöglicht das Konvertieren von:

* Gesamte Präsentationen in PDF
* Bestimmte Folien einer Präsentation in PDF

Aspose.Slides exportiert Präsentationen nach PDF und stellt sicher, dass die resultierenden PDFs dem Original sehr ähnlich sind. Elemente und Attribute werden bei der Konvertierung genau wiedergegeben, einschließlich:

* Bilder
* Textfelder und Formen
* Textformatierung
* Absatzformatierung
* Hyperlinks
* Kopf‑ und Fußzeilen
* Aufzählungszeichen
* Tabellen

## **PowerPoint zu PDF konvertieren**

Der Standard‑PowerPoint-zu‑PDF‑Konvertierungsprozess verwendet Standardoptionen. In diesem Fall versucht Aspose.Slides, die bereitgestellte Präsentation mit optimalen Einstellungen und maximaler Qualität in PDF zu konvertieren.

Das folgende Beispiel lädt eine Präsentation und speichert alle sichtbaren Folien mit den Standard‑Exporteinstellungen in ein PDF.

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
Aspose bietet einen kostenlosen Online‑[**PowerPoint zu PDF Konverter**](https://products.aspose.app/slides/conversion/ppt-to-pdf), der den Präsentation‑zu‑PDF‑Konvertierungsprozess demonstriert. Sie können mit diesem Konverter einen Test für eine Live‑Implementierung des hier beschriebenen Verfahrens durchführen.
{{% /alert %}}

## **PowerPoint zu PDF mit Optionen konvertieren**

Aspose.Slides bietet benutzerdefinierte Optionen – Eigenschaften der Klasse [PdfOptions](https://reference.aspose.com/slides/nodejs-java/aspose.slides/pdfoptions/), die es Ihnen ermöglichen, das resultierende PDF anzupassen, das PDF mit einem Passwort zu schützen oder festzulegen, wie der Konvertierungsprozess ablaufen soll.

### **PowerPoint zu PDF mit benutzerdefinierten Optionen konvertieren**

Mit benutzerdefinierten Konvertierungsoptionen können Sie Ihre bevorzugte Qualitätsstufe für Rasterbilder festlegen, bestimmen, wie Metadateien behandelt werden, ein Komprimierungsniveau für Text einstellen, die DPI für Bilder konfigurieren und vieles mehr.

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

### **Eingebettete OLE‑Dateien als PDF‑Anhänge erhalten**

Wenn eine Präsentation eine eingebettete Excel‑Arbeitsmappe enthält, möchten Sie möglicherweise, dass PDF‑Empfänger sowohl die Daten der Arbeitsmappe als auch die Folien sehen können. Rufen Sie [setIncludeOleData](https://reference.aspose.com/slides/nodejs-java/aspose.slides/pdfoptions/#setIncludeOleData) mit `true` auf, um eingebettete OLE‑Dateien als Anhänge im resultierenden PDF zu erhalten.

Der Standardwert ist `false`: Das Vorschaubild oder Symbol des OLE‑Objekts wird auf der PDF‑Seite gerendert, aber die eingebettete Datei wird nicht als Anhang hinzugefügt. Wird die Option auf `true` gesetzt, wird zusätzlich die Dateidaten beigefügt. Die Vorschau bleibt eine visuelle Darstellung; der Anhang ermöglicht es Empfängern, die eingebettete Datei separat zu öffnen oder zu speichern. Das OLE‑Objekt wird nicht zu einem interaktiven Excel‑Arbeitsblatt auf der PDF‑Seite.

Das folgende Beispiel lädt eine Präsentation, die bereits eine eingebettete Excel‑Arbeitsmappe enthält, und exportiert sie mit angehängter Arbeitsmappe in ein PDF.

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

Um das Ergebnis zu prüfen:

1. Öffnen Sie das exportierte PDF in einem Viewer, der Dateianhänge unterstützt, z. B. Adobe Acrobat Reader.
2. Öffnen Sie das **Attachments**‑Panel des Viewers und suchen Sie die eingebettete Arbeitsmappe.
3. Speichern Sie den Anhang und öffnen Sie ihn in Excel, um die Daten zu prüfen, oder öffnen Sie ihn direkt, falls der Viewer dies erlaubt. Die Vorschau auf der PDF‑Seite ist vom Anhang getrennt.

{{% alert color="info" title="Note" %}}
Die PDF/A‑Standards legen Beschränkungen für Anhänge fest: PDF/A-1 verbietet eingebettete Dateien, PDF/A-2 erlaubt nur PDF/A‑Anhänge, und PDF/A-3 erlaubt andere Dateitypen, einschließlich Excel‑Arbeitsmappen. Diese Vorgaben stammen aus den Standards und sind keine Beschränkungen, die speziell von Aspose.Slides auferlegt werden. Dieses Beispiel verwendet die standardmäßige PDF‑Compliance‑Einstellung und demonstriert keinen PDF/A‑Export.
{{% /alert %}}

### **PowerPoint zu PDF mit versteckten Folien konvertieren**

Wenn eine Präsentation versteckte Folien enthält, können Sie die Methode [setShowHiddenSlides](https://reference.aspose.com/slides/nodejs-java/aspose.slides/pdfoptions/#setShowHiddenSlides) aus der Klasse [PdfOptions](https://reference.aspose.com/slides/nodejs-java/aspose.slides/pdfoptions/) verwenden, um die versteckten Folien als Seiten im resultierenden PDF einzubeziehen.

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

Das folgende Beispiel exportiert eine Präsentation in ein PDF, das zum Öffnen das Passwort `password` benötigt. Die Zugriffsrechte erlauben das Drucken, einschließlich hochwertigem Drucken.

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

### **Schriftart‑Ersetzungen erkennen**

Aspose.Slides bietet die Methode [setWarningCallback](https://reference.aspose.com/slides/nodejs-java/aspose.slides/saveoptions/#setWarningCallback) in der Klasse [PdfOptions](https://reference.aspose.com/slides/nodejs-java/aspose.slides/pdfoptions/) an, mit der Sie Schriftart‑Ersetzungen während des Präsentation‑zu‑PDF‑Konvertierungsprozesses erkennen können.

Das folgende Beispiel exportiert eine Präsentation in PDF und gibt Schriftart‑Ersetzungswarnungen in der Konsole aus. Eine Warnung wird nur ausgegeben, wenn während des Exports eine nicht verfügbare Schriftart ersetzt wird.

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
Für weitere Informationen zu Schriftart‑Ersetzungen siehe den Artikel [Schriftart‑Ersetzung](/slides/de/nodejs-java/font-substitution/).
{{% /alert %}} 

## **Ausgewählte Folien von PowerPoint in PDF konvertieren**

Das folgende Beispiel exportiert die Folien 1 und 3 einer Präsentation in PDF. Die Foliennummern in diesem Array beginnen bei 1, und die Eingabe‑Präsentation muss mindestens drei Folien enthalten.

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

## **PowerPoint zu PDF mit benutzerdefinierter Foliengröße konvertieren**

Das folgende Beispiel kopiert die erste Folie einer Präsentation in eine neue Präsentation mit einer Foliengröße von 612 × 792 Punkten (8,5 × 11 Zoll). Es skaliert den Folieninhalt, um zu passen, und exportiert die einzelne Folie in ein PDF.

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

    // Entfernen Sie die leere Folie, die bei der Erstellung der neuen Präsentation erzeugt wurde.
    resizedPresentation.getSlides().removeAt(1);

    resizedPresentation.save("PDF_with_custom_slide_size.pdf", aspose.slides.SaveFormat.Pdf);
} finally {
    resizedPresentation.dispose();
    presentation.dispose();
}
```

## **PowerPoint zu PDF im Notizen‑Folien‑Ansicht konvertieren**

Das folgende Beispiel exportiert eine Präsentation in PDF und platziert die Sprecher‑Notizen jeder Folie unterhalb der Folie. Verwenden Sie eine Präsentation, die Sprecher‑Notizen enthält, um das Ergebnis zu sehen.

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

## **Barrierefreiheit und Compliance‑Standards für PDF**

Aspose.Slides ermöglicht die Verwendung eines Konvertierungsverfahrens, das den [Web Content Accessibility Guidelines (**WCAG**)](https://www.w3.org/TR/WCAG-TECHS/pdf.html) entspricht. Sie können ein PowerPoint‑Dokument in PDF exportieren und dabei einen dieser Compliance‑Standards verwenden: **PDF/A1a**, **PDF/A1b** und **PDF/UA**.

Dieser Code demonstriert einen PowerPoint‑zu‑PDF‑Konvertierungsprozess, der basierend auf verschiedenen Compliance‑Standards mehrere PDFs erzeugt:

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
Aspose.Slides unterstützt PDF‑Konvertierungsoperationen, mit denen Sie PDF‑Dateien in gängige Formate konvertieren können. Sie können [PDF zu HTML](https://products.aspose.com/slides/nodejs-java/conversion/pdf-to-html/), [PDF zu JPG](https://products.aspose.com/slides/nodejs-java/conversion/pdf-to-jpg/) und [PDF zu PNG](https://products.aspose.com/slides/nodejs-java/conversion/pdf-to-png/) Konvertierungen durchführen. Weitere PDF‑Konvertierungsoperationen zu speziellen Formaten – [PDF zu SVG](https://products.aspose.com/slides/nodejs-java/conversion/pdf-to-svg/), [PDF zu TIFF](https://products.aspose.com/slides/nodejs-java/conversion/pdf-to-tiff/) – werden ebenfalls unterstützt.
{{% /alert %}}

> **Hinweis:** Beim Export nach PDF/UA behandelt Aspose.Slides komplexe Grafiken wie SmartArt, Diagramme und Formeln als einzelne Figur. Einzelne Pfadelemente werden nicht als separater Inhalt erhalten und können als Artefakte markiert werden; Alternativtext wird nur für die gesamte Figur bereitgestellt.

## **FAQ**

**Kann ich mehrere PowerPoint‑Dateien in großen Mengen in PDF konvertieren?**

Ja, Aspose.Slides unterstützt die Stapelkonvertierung mehrerer PPT‑ oder PPTX‑Dateien in PDF. Sie können Ihre Dateien iterativ durchlaufen und den Konvertierungsprozess programmgesteuert anwenden.

**Ist es möglich, das konvertierte PDF mit einem Passwort zu schützen?**

Ja. Verwenden Sie die Klasse [PdfOptions](https://reference.aspose.com/slides/nodejs-java/aspose.slides/pdfoptions/), um ein Passwort festzulegen und Zugriffsrechte während des Konvertierungsprozesses zu definieren.

**Wie kann ich versteckte Folien in das PDF einbeziehen?**

Rufen Sie die Methode [setShowHiddenSlides](https://reference.aspose.com/slides/nodejs-java/aspose.slides/pdfoptions/#setShowHiddenSlides) mit `true` in der Klasse [PdfOptions](https://reference.aspose.com/slides/nodejs-java/aspose.slides/pdfoptions/) auf, um versteckte Folien in das resultierende PDF einzubeziehen.

**Kann Aspose.Slides eine hohe Bildqualität im PDF beibehalten?**

Ja, Sie können die Bildqualität steuern, indem Sie Methoden wie [setJpegQuality](https://reference.aspose.com/slides/nodejs-java/aspose.slides/pdfoptions/#setJpegQuality) und [setSufficientResolution](https://reference.aspose.com/slides/nodejs-java/aspose.slides/pdfoptions/#setSufficientResolution) in der Klasse [PdfOptions](https://reference.aspose.com/slides/nodejs-java/aspose.slides/pdfoptions/) verwenden, um hochqualitative Bilder in Ihrem PDF zu gewährleisten.

**Unterstützt Aspose.Slides PDF/A‑Compliance‑Standards?**

Ja, Aspose.Slides ermöglicht das Exportieren von PDFs, die den [verschiedenen Standards](https://reference.aspose.com/slides/nodejs-java/aspose.slides/pdfcompliance/) entsprechen, einschließlich PDF/A1a, PDF/A1b und PDF/UA, sodass Ihre Dokumente die Anforderungen an Barrierefreiheit und Archivierung erfüllen.

## **Zusätzliche Ressourcen**

- [Aspose.Slides für Node.js via Java Dokumentation](/slides/de/nodejs-java/)
- [Aspose.Slides für Node.js via Java API‑Referenz](https://reference.aspose.com/slides/nodejs-java/)
- [Aspose kostenlose Online‑Konverter](https://products.aspose.app/slides/conversion)