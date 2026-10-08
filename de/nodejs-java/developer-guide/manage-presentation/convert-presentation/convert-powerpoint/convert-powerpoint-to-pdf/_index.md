---
title: "PPT und PPTX in PDF in JavaScript konvertieren [Erweiterte Funktionen enthalten]"
linktitle: "PowerPoint zu PDF"
type: docs
weight: 40
url: /de/nodejs-java/convert-powerpoint-to-pdf/
keywords:
- "PowerPoint konvertieren"
- "Präsentation konvertieren"
- "PowerPoint zu PDF"
- "Präsentation zu PDF"
- "PPT zu PDF"
- "PPT zu PDF konvertieren"
- "PPTX zu PDF"
- "PPTX zu PDF konvertieren"
- "PowerPoint als PDF speichern"
- "PPT als PDF speichern"
- "PPTX als PDF speichern"
- "PPT nach PDF exportieren"
- "PPTX nach PDF exportieren"
- "Anhang"
- "PDF/A1a"
- "PDF/A1b"
- "PDF/UA"
- "Node.js"
- "JavaScript"
- "Aspose.Slides"
description: "Konvertieren Sie PowerPoint PPT/PPTX in hochwertige, durchsuchbare PDFs mithilfe von Aspose.Slides für Node.js, mit schnellen Codebeispielen und erweiterten Konvertierungsoptionen."
---
## **Übersicht**

Das Konvertieren von PowerPoint- und OpenDocument‑Präsentationen (PPT, PPTX, ODP usw.) in das PDF‑Format mit JavaScript bietet mehrere Vorteile, darunter Kompatibilität auf verschiedenen Geräten und das Bewahren des Layouts und der Formatierung Ihrer Präsentation. Dieser Leitfaden zeigt, wie Präsentationen in PDF‑Dokumente konvertiert werden, verschiedene Optionen zur Steuerung der Bildqualität verwendet, versteckte Folien einbezogen, PDF‑Dateien mit einem Passwort geschützt, Schriftartersetzungen erkannt, bestimmte Folien für die Konvertierung ausgewählt und Konformitätsstandards auf Ausgabedokumente angewendet werden.

## **PowerPoint‑zu‑PDF‑Konvertierungen**

Mit Aspose.Slides können Sie Präsentationen in den folgenden Formaten in PDF konvertieren:

* **PPT**
* **PPTX**
* **ODP**

Um eine Präsentation in PDF zu konvertieren, übergeben Sie den Dateinamen als Argument an die [Presentation](https://reference.aspose.com/slides/nodejs-java/aspose.slides/presentation/)‑Klasse und speichern Sie die Präsentation anschließend als PDF mit einer [save](https://reference.aspose.com/slides/nodejs-java/aspose.slides/presentation/save/)‑Methode. Die [Presentation](https://reference.aspose.com/slides/nodejs-java/aspose.slides/presentation/)‑Klasse stellt die [save](https://reference.aspose.com/slides/nodejs-java/aspose.slides/presentation/save/)‑Methode zur Verfügung, die typischerweise verwendet wird, um eine Präsentation in PDF zu konvertieren.

{{% alert color="info" title="Hinweis" %}}
Aspose.Slides for Node.js via Java fügt seinen API‑Informationen und die Versionsnummer in Ausgabedokumente ein. Beispielsweise füllt Aspose.Slides beim Konvertieren einer Präsentation zu PDF das Anwendungsfeld mit "*Aspose.Slides*" und das PDF‑Producer‑Feld mit einem Wert in der Form "*Aspose.Slides v XX.XX*". **Hinweis** dass Sie Aspose.Slides nicht anweisen können, diese Informationen aus Ausgabedokumenten zu ändern oder zu entfernen.
{{% /alert %}}

Aspose.Slides ermöglicht das Konvertieren:

* Gesamte Präsentationen zu PDF
* Bestimmte Folien einer Präsentation zu PDF

Aspose.Slides exportiert Präsentationen zu PDF und sorgt dafür, dass die resultierenden PDFs den Originalpräsentationen sehr nahekommen. Elemente und Attribute werden bei der Konvertierung exakt wiedergegeben, einschließlich:

* Bilder
* Textfelder und Formen
* Textformatierung
* Absatzformatierung
* Hyperlinks
* Kopf‑ und Fußzeilen
* Aufzählungszeichen
* Tabellen

## **PowerPoint zu PDF konvertieren**

Der standardmäßige PowerPoint‑zu‑PDF‑Konvertierungsprozess verwendet Standardoptionen. In diesem Fall versucht Aspose.Slides, die bereitgestellte Präsentation mit optimalen Einstellungen und maximaler Qualität in PDF zu konvertieren.

Das folgende Beispiel lädt eine Präsentation und speichert alle sichtbaren Folien mit den Standard‑Export‑Einstellungen als PDF.

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

{{% alert color="info" title="Hinweis" %}}
Aspose bietet einen kostenlosen Online‑[**PowerPoint‑zu‑PDF‑Konverter**](https://products.aspose.app/slides/conversion/ppt-to-pdf), der den Präsentation‑zu‑PDF‑Konvertierungsprozess demonstriert. Sie können diesen Konverter testen, um das hier beschriebene Verfahren live zu sehen.
{{% /alert %}}

## **PowerPoint zu PDF mit Optionen**

Aspose.Slides stellt benutzerdefinierte Optionen — Eigenschaften der [PdfOptions](https://reference.aspose.com/slides/nodejs-java/aspose.slides/pdfoptions/)‑Klasse — zur Verfügung, mit denen Sie das resultierende PDF anpassen, das PDF mit einem Passwort schützen oder festlegen können, wie der Konvertierungsprozess ablaufen soll.

### **PowerPoint zu PDF mit benutzerdefinierten Optionen**

Mit benutzerdefinierten Konvertierungsoptionen können Sie Ihre bevorzugte Qualitätseinstellung für Rasterbilder festlegen, bestimmen, wie Metadateien behandelt werden, ein Kompressionsniveau für Text setzen, DPI für Bilder konfigurieren und mehr.

Das folgende Beispiel exportiert eine Präsentation zu PDF 1.5 mit JPEG‑Qualität 90, Bildauflösung 300 DPI, Metadateien als PNG und Flate‑Textkompression.

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

Enthält eine Präsentation eine eingebettete Excel‑Arbeitsmappe, möchten Sie möglicherweise, dass PDF‑Empfänger sowohl die Daten der Arbeitsmappe als auch die Folien einsehen können. Rufen Sie [setIncludeOleData](https://reference.aspose.com/slides/nodejs-java/aspose.slides/pdfoptions/) mit `true` auf, um eingebettete OLE‑Dateien als Anhänge im resultierenden PDF zu erhalten.

Der Standardwert ist `false`: Das Vorschaubild oder Symbol des OLE‑Objekts wird auf der PDF‑Seite gerendert, aber die eingebettete Datei wird nicht als Anhang eingeschlossen. Wird die Option auf `true` gesetzt, wird zusätzlich die Datei selbst angehängt. Die Vorschau bleibt eine visuelle Darstellung; der Anhang ermöglicht es Empfängern, die eingebettete Datei separat zu öffnen oder zu speichern. Das OLE‑Objekt wird nicht zu einem interaktiven Excel‑Arbeitsblatt auf der PDF‑Seite.

Das folgende Beispiel lädt eine Präsentation, die bereits eine eingebettete Excel‑Arbeitsmappe enthält, und exportiert sie zu PDF mit der angehängten Arbeitsmappe.

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

1. Öffnen Sie das exportierte PDF in einem Viewer, der Datei‑Anhänge unterstützt, z. B. Adobe Acrobat Reader.
2. Öffnen Sie das **Attachments**‑Panel des Viewers und suchen Sie die eingebettete Arbeitsmappe.
3. Speichern Sie den Anhang und öffnen Sie ihn in Excel, um die Daten zu prüfen, oder öffnen Sie ihn direkt, falls der Viewer dies erlaubt. Die Vorschau auf der PDF‑Seite ist vom Anhang getrennt.

{{% alert color="info" title="Hinweis" %}}
Die PDF/A‑Standards legen Beschränkungen für Anhänge fest: PDF/A‑1 verbietet eingebettete Dateien, PDF/A‑2 erlaubt nur PDF/A‑Anhänge, und PDF/A‑3 erlaubt andere Dateitypen, einschließlich Excel‑Arbeitsmappen. Das sind Vorgaben der Standards, nicht Einschränkungen speziell von Aspose.Slides. Dieses Beispiel verwendet die Standard‑PDF‑Konformitätseinstellung und demonstriert keinen PDF/A‑Export.
{{% /alert %}}

### **PowerPoint zu PDF mit versteckten Folien**

Enthält eine Präsentation versteckte Folien, können Sie die Methode [setShowHiddenSlides](https://reference.aspose.com/slides/nodejs-java/aspose.slides/pdfoptions/setshowhiddenslides/) der [PdfOptions](https://reference.aspose.com/slides/nodejs-java/aspose.slides/pdfoptions/)‑Klasse verwenden, um die versteckten Folien als Seiten im resultierenden PDF zu übernehmen.

Das folgende Beispiel exportiert eine Präsentation zu PDF, wobei alle versteckten Folien einbezogen werden.

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

### **PowerPoint zu einem passwortgeschützten PDF konvertieren**

Das folgende Beispiel exportiert eine Präsentation zu einem PDF, das das Passwort `password` zum Öffnen erfordert. Die Zugriffsrechte erlauben das Drucken, einschließlich qualitativ hochwertigem Druck.

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

### **Schriftartersetzungen erkennen**

Aspose.Slides bietet die Methode [setWarningCallback](https://reference.aspose.com/slides/nodejs-java/aspose.slides/saveoptions/) in der [PdfOptions](https://reference.aspose.com/slides/nodejs-java/aspose.slides/pdfoptions/)‑Klasse, mit der Sie Schriftartersetzungen während der Präsentation‑zu‑PDF‑Konvertierung erkennen können.

Das folgende Beispiel exportiert eine Präsentation zu PDF und gibt Schriftartersetzungs‑Warnungen in der Konsole aus. Eine Warnung wird nur ausgegeben, wenn während des Exports eine nicht verfügbare Schriftart ersetzt wird.

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

{{% alert color="info" title="Hinweis" %}}
Weitere Informationen zur Schriftartersetzung finden Sie im Artikel [Schriftart‑Ersetzung](/slides/de/nodejs-java/font-substitution/).
{{% /alert %}} 

### **Umgang mit Schriftarten ohne eigenen Fettschrifttyp**

Eine Präsentation kann Text fett formatieren, obwohl die verwendete Schriftart keinen eigenen Fettschrifttyp besitzt. Der Text kann dennoch durch synthetisches Fetten hervorgehoben werden, wobei die regulären Glyphen künstlich verdickt werden. Wenn dieser Text zu schwer wirkt oder von der gewünschten Darstellung im PDF abweicht, rufen Sie [PdfOptions.setRasterizeUnsupportedFontStyles](https://reference.aspose.com/slides/nodejs-java/aspose.slides/pdfoptions/) mit `true` auf. Diese Option rendert den betroffenen Text während des PDF‑Exports als Bitmap und kann das Aussehen für bestimmte Schriftarten verbessern. Der Standardwert ist `false`.

Die Beispieldatei enthält zwei Textfelder: eines mit normalem Text und eines mit fetter Formatierung derselben Schriftart, die keinen eigenen Fettschrifttyp besitzt. Das folgende Beispiel lädt die Präsentation, aktiviert die Rasterisierung nicht unterstützter Schriftstil‑Varianten und exportiert sie zu PDF:

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

Die folgenden Vorschauen zeigen das Ergebnis mit deaktivierter bzw. aktivierter Option. In diesem Beispiel hat der fette Text bei deaktivierter Option stärkere Striche. Bei aktivierter Option sind die Striche leichter; der normale Text bleibt unverändert. Vergleichen Sie die Ergebnisse, bevor Sie die Einstellung für Ihre Präsentation wählen.

| Option deaktiviert (`false`, Standard) | Option aktiviert (`true`) |
|---|---|
| ![PDF with unsupported font style rasterization disabled](unsupported-bold-disabled.png) | ![PDF with unsupported font style rasterization enabled](unsupported-bold-enabled.png) |

In diesem Beispiel führt das Aktivieren der Option dazu, dass nur der fette Text in eine Bitmap umgewandelt wird: Er kann nicht ausgewählt, kopiert oder ohne OCR als Text durchsucht werden, und seine Kanten wirken bei 800 % Zoom weicher. Der normale Text bleibt durchsuchbar. Bei deaktivierter Option bleiben beide Zeichenketten als Text.

Diese Option rasterisiert Text, der als fett formatiert ist, wenn die Schriftart keinen eigenen Fettschrifttyp besitzt. [Schriftart‑Ersetzung](/slides/de/nodejs-java/font-substitution/) wählt stattdessen eine andere Schriftart, wenn die Originalschriftart nicht verfügbar ist.

## **Ausgewählte Folien von PowerPoint zu PDF konvertieren**

Das folgende Beispiel exportiert die Folien 1 und 3 einer Präsentation zu PDF. Die Foliennummern in diesem Array beginnen bei 1, und die Eingabedatei muss mindestens drei Folien enthalten.

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

## **PowerPoint zu PDF mit benutzerdefinierter Foliengröße**

Das folgende Beispiel kopiert die erste Folie einer Präsentation in eine neue Präsentation mit einer Foliengröße von 612 × 792 Punkten (8,5 × 11 Zoll). Der Folieninhalt wird skaliert, um zu passen, und die einzelne Folie wird zu PDF exportiert.

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

    // Entferne die leere Folie, mit der die neue Präsentation erstellt wurde.
    resizedPresentation.getSlides().removeAt(1);

    resizedPresentation.save("PDF_with_custom_slide_size.pdf", aspose.slides.SaveFormat.Pdf);
} finally {
    resizedPresentation.dispose();
    presentation.dispose();
}
```

## **PowerPoint zu PDF in Notiz‑Folien‑Ansicht**

Das folgende Beispiel exportiert eine Präsentation zu PDF und platziert die Sprecher‑Notizen jeder Folie unterhalb der Folie. Verwenden Sie eine Präsentation mit Sprecher‑Notizen, um das Ergebnis zu sehen.

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

## **Barrierefreiheit und Konformitätsstandards für PDF**

Aspose.Slides ermöglicht ein Konvertierungsverfahren, das den [Richtlinien für barrierefreie Webinhalte (**WCAG**)](https://www.w3.org/TR/WCAG-TECHS/pdf.html) entspricht. Sie können ein PowerPoint‑Dokument zu PDF exportieren und dabei einen dieser Konformitätsstandards verwenden: **PDF/A1a**, **PDF/A1b** und **PDF/UA**.

Dieser Code demonstriert einen PowerPoint‑zu‑PDF‑Konvertierungsprozess, der mehrere PDFs basierend auf unterschiedlichen Konformitätsstandards erzeugt:

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

{{% alert color="info" title="Hinweis" %}}
Aspose.Slides unterstützt PDF‑Konvertierungsoperationen, mit denen Sie PDF‑Dateien in gängige Formate konvertieren können. Sie können [PDF zu HTML](https://products.aspose.com/slides/nodejs-java/conversion/pdf-to-html/), [PDF zu JPG](https://products.aspose.com/slides/nodejs-java/conversion/pdf-to-jpg/) und [PDF zu PNG](https://products.aspose.com/slides/nodejs-java/conversion/pdf-to-png/) Konvertierungen durchführen. Weitere PDF‑Konvertierungsoperationen zu spezialisierten Formaten — [PDF zu SVG](https://products.aspose.com/slides/nodejs-java/conversion/pdf-to-svg/), [PDF zu TIFF](https://products.aspose.com/slides/nodejs-java/conversion/pdf-to-tiff/) — werden ebenfalls unterstützt.
{{% /alert %}}

> **Hinweis:** Beim Exportieren zu PDF/UA behandelt Aspose.Slides komplexe Grafiken wie SmartArt, Diagramme und Formeln als einzelne Abbildung. Einzelne Pfad‑Elemente werden nicht als separater Inhalt erhalten und können als Artefakte gekennzeichnet werden; Alternativtext wird nur für die gesamte Abbildung bereitgestellt.

## **FAQ**

**Kann ich mehrere PowerPoint‑Dateien stapelweise in PDF konvertieren?**

Ja, Aspose.Slides unterstützt die Batch‑Konvertierung mehrerer PPT‑ oder PPTX‑Dateien zu PDF. Sie können Ihre Dateien iterativ durchlaufen und den Konvertierungsprozess programmgesteuert anwenden.

**Ist es möglich, das konvertierte PDF mit einem Passwort zu schützen?**

Ja. Verwenden Sie die [PdfOptions](https://reference.aspose.com/slides/nodejs-java/aspose.slides/pdfoptions/)‑Klasse, um ein Passwort festzulegen und Zugriffsrechte während des Konvertierungsprozesses zu definieren.

**Wie kann ich versteckte Folien in das PDF einbeziehen?**

Rufen Sie [setShowHiddenSlides](https://reference.aspose.com/slides/nodejs-java/aspose.slides/pdfoptions/setshowhiddenslides/) mit `true` in der [PdfOptions](https://reference.aspose.com/slides/nodejs-java/aspose.slides/pdfoptions/)‑Klasse auf, um versteckte Folien im resultierenden PDF zu übernehmen.

**Kann Aspose.Slides eine hohe Bildqualität im PDF beibehalten?**

Ja, Sie können die Bildqualität steuern, indem Sie Methoden wie [setJpegQuality](https://reference.aspose.com/slides/nodejs-java/aspose.slides/pdfoptions/setjpegquality/) und [setSufficientResolution](https://reference.aspose.com/slides/nodejs-java/aspose.slides/pdfoptions/setsufficientresolution/) in der [PdfOptions](https://reference.aspose.com/slides/nodejs-java/aspose.slides/pdfoptions/)‑Klasse verwenden, um hochqualitative Bilder in Ihrem PDF sicherzustellen.

**Unterstützt Aspose.Slides PDF/A‑Konformitätsstandards?**

Ja, Aspose.Slides erlaubt den Export von PDFs, die den [verschiedenen Standards](https://reference.aspose.com/slides/nodejs-java/aspose.slides/pdfcompliance/) entsprechen, darunter PDF/A1a, PDF/A1b und PDF/UA, sodass Ihre Dokumente Barrierefreikeits‑ und Archivierungsanforderungen erfüllen.

## **Zusätzliche Ressourcen**

- [Aspose.Slides für Node.js via Java Dokumentation](/slides/de/nodejs-java/)
- [Aspose.Slides für Node.js via Java API‑Referenz](https://reference.aspose.com/slides/nodejs-java/)
- [Aspose kostenlose Online‑Konverter](https://products.aspose.app/slides/conversion)