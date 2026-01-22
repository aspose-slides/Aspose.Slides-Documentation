---
title: PPT und PPTX nach PDF in JavaScript konvertieren [Erweiterte Funktionen enthalten]
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
- PDF/A1a
- PDF/A1b
- PDF/UA
- Node.js
- JavaScript
- Aspose.Slides
description: "PowerPoint PPT/PPTX mit Aspose.Slides für Node.js in hochwertige, durchsuchbare PDFs konvertieren, mit schnellen Codebeispielen und erweiterten Konvertierungsoptionen."
---

## **Übersicht**

Das Konvertieren von PowerPoint- und OpenDocument-Präsentationen (PPT, PPTX, ODP usw.) in das PDF-Format mit JavaScript bietet mehrere Vorteile, darunter Kompatibilität über verschiedene Geräte hinweg und die Erhaltung von Layout und Formatierung Ihrer Präsentation. Dieser Leitfaden zeigt, wie Sie Präsentationen in PDF-Dokumente konvertieren, verschiedene Optionen zur Steuerung der Bildqualität nutzen, ausgeblendete Folien einbeziehen, PDF-Dateien mit Passwort schützen, Schriftart‑Ersetzungen erkennen, bestimmte Folien für die Konvertierung auswählen und Compliance‑Standards auf die Ausgabedokumente anwenden.

## **PowerPoint‑zu‑PDF‑Konvertierungen**

Mit Aspose.Slides können Sie Präsentationen in den folgenden Formaten in PDF konvertieren:

* **PPT**
* **PPTX**
* **ODP**

Um eine Präsentation in PDF zu konvertieren, übergeben Sie den Dateinamen als Argument an die [Presentation](https://reference.aspose.com/slides/nodejs-java/aspose.slides/presentation/)‑Klasse und speichern Sie die Präsentation anschließend mit einer `save`‑Methode als PDF. Die [Presentation](https://reference.aspose.com/slides/nodejs-java/aspose.slides/presentation/)‑Klasse stellt die `save`‑Methode bereit, die typischerweise zum Konvertieren einer Präsentation in PDF verwendet wird.

{{%  alert title="NOTE"  color="warning"   %}} 
Aspose.Slides für Node.js via Java fügt Informationen zur API und Versionsnummer in Ausgabedokumente ein. Beim Konvertieren einer Präsentation in PDF füllt Aspose.Slides das Feld „Application“ mit „*Aspose.Slides*“ und das Feld „PDF Producer“ mit einem Wert im Format „*Aspose.Slides v XX.XX*“. **Hinweis:** Sie können Aspose.Slides nicht anweisen, diese Informationen aus Ausgabedokumenten zu entfernen oder zu ändern.
{{% /alert %}}

Aspose.Slides ermöglicht das Konvertieren von:

* Gesamten Präsentationen in PDF
* Bestimmten Folien einer Präsentation in PDF

Aspose.Slides exportiert Präsentationen nach PDF und stellt sicher, dass die resultierenden PDFs den Originalpräsentationen sehr nahe kommen. Elemente und Attribute werden bei der Konvertierung genau wiedergegeben, einschließlich:

* Bilder
* Textfelder und Formen
* Textformatierung
* Absatzformatierung
* Hyperlinks
* Kopf‑ und Fußzeilen
* Aufzählungszeichen
* Tabellen

## **PowerPoint in PDF konvertieren**

Der Standard‑PowerPoint‑zu‑PDF‑Konvertierungsprozess verwendet die Standardoptionen. In diesem Fall versucht Aspose.Slides, die bereitgestellte Präsentation mit optimalen Einstellungen und höchster Qualitätsstufe in PDF zu konvertieren.

Der folgende Code zeigt, wie Sie eine Präsentation (PPT, PPTX, ODP usw.) in PDF konvertieren:
```js
// Instanziieren Sie die Presentation-Klasse, die eine PowerPoint- oder OpenDocument-Datei repräsentiert.
let presentation = new aspose.slides.Presentation("PowerPoint.ppt");
try {
    // Speichern Sie die Präsentation als PDF.
    presentation.save("PPT-to-PDF.pdf", aspose.slides.SaveFormat.Pdf);
} finally {
    presentation.dispose();
}
```


{{%  alert  color="primary"  %}} 
Aspose bietet einen kostenlosen Online‑[**PowerPoint‑zu‑PDF‑Konverter**](https://products.aspose.app/slides/conversion/ppt-to-pdf), der den Konvertierungsprozess demonstriert. Sie können diesen Konverter testen, um die hier beschriebene Vorgehensweise live zu sehen.
{{% /alert %}}

## **PowerPoint in PDF mit Optionen konvertieren**

Aspose.Slides stellt benutzerdefinierte Optionen – Eigenschaften der [PdfOptions](https://reference.aspose.com/slides/nodejs-java/aspose.slides/pdfoptions/)‑Klasse – bereit, mit denen Sie das resultierende PDF anpassen, mit einem Passwort schützen oder das Vorgehen der Konvertierung festlegen können.

### **PowerPoint in PDF mit benutzerdefinierten Optionen konvertieren**

Mit benutzerdefinierten Konvertierungsoptionen können Sie die bevorzugte Qualitätsstufe für Rasterbilder festlegen, das Verhalten von Metadateien bestimmen, ein Komprimierungslevel für Text setzen, die DPI für Bilder konfigurieren und mehr.

Das folgende Codebeispiel demonstriert, wie Sie eine PowerPoint‑Präsentation mit mehreren benutzerdefinierten Optionen in PDF konvertieren.
```js
// Instanziieren Sie die PdfOptions-Klasse.
let pdfOptions = new aspose.slides.PdfOptions();

// Legen Sie die Qualität für JPG-Bilder fest.
pdfOptions.setJpegQuality(java.newByte(90));

// DPI für Bilder festlegen.
pdfOptions.setSufficientResolution(300);

// Verhalten für Metadateien festlegen.
pdfOptions.setSaveMetafilesAsPng(true);

// Festlegen des Textkomprimierungsgrades für Textinhalte.
pdfOptions.setTextCompression(aspose.slides.PdfTextCompression.Flate);

// Definieren Sie den PDF-Compliance-Modus.
pdfOptions.setCompliance(aspose.slides.PdfCompliance.Pdf15);

// Instanziieren Sie die Presentation-Klasse, die eine PowerPoint- oder OpenDocument-Datei darstellt.
let presentation = new aspose.slides.Presentation("PowerPoint.pptx");
try {
    // Speichern Sie die Präsentation als PDF-Dokument.
    presentation.save("PowerPoint-to-PDF.pdf", aspose.slides.SaveFormat.Pdf, pdfOptions);
} finally {
    presentation.dispose();
}
```


### **PowerPoint in PDF mit ausgeblendeten Folien konvertieren**

Enthält eine Präsentation ausgeblendete Folien, können Sie die [setShowHiddenSlides](https://reference.aspose.com/slides/nodejs-java/aspose.slides/PdfOptions#setShowHiddenSlides)‑Methode der [PdfOptions](https://reference.aspose.com/slides/nodejs-java/aspose.slides/PdfOptions)‑Klasse verwenden, um die ausgeblendeten Folien als Seiten im resultierenden PDF einzuschließen.

Dieses JavaScript‑Beispiel zeigt, wie Sie eine PowerPoint‑Präsentation mit ausgeblendeten Folien in PDF konvertieren:
```js
// Instanziieren Sie die Presentation-Klasse, die eine PowerPoint- oder OpenDocument-Datei repräsentiert.
let presentation = new aspose.slides.Presentation("PowerPoint.pptx");
try {
    // Instanziieren Sie die PdfOptions-Klasse.
    let pdfOptions = new aspose.slides.PdfOptions();

    // Versteckte Folien hinzufügen.
    pdfOptions.setShowHiddenSlides(true);

    // Präsentation als PDF speichern.
    presentation.save("PowerPoint-to-PDF.pdf", aspose.slides.SaveFormat.Pdf, pdfOptions);
} finally {
    presentation.dispose();
}
```


### **PowerPoint in passwortgeschütztes PDF konvertieren**

Dieses JavaScript‑Beispiel demonstriert, wie Sie eine PowerPoint‑Präsentation mit den Schutzparametern der [PdfOptions](https://reference.aspose.com/slides/nodejs-java/aspose.slides/PdfOptions)‑Klasse in ein passwortgeschütztes PDF konvertieren:
```js
// Instanziieren Sie die Presentation-Klasse, die eine PowerPoint- oder OpenDocument-Datei darstellt.
let presentation = new aspose.slides.Presentation("PowerPoint.pptx");
try {
    // Instanziieren Sie die PdfOptions-Klasse.
    let pdfOptions = new aspose.slides.PdfOptions();

    // Setzen Sie ein PDF-Passwort und Zugriffsrechte.
    pdfOptions.setPassword("password");
    pdfOptions.setAccessPermissions(aspose.slides.PdfAccessPermissions.PrintDocument | aspose.slides.PdfAccessPermissions.HighQualityPrint);

    // Speichern Sie die Präsentation als PDF.
    presentation.save("PPTX-to-PDF.pdf", aspose.slides.SaveFormat.Pdf, pdfOptions);
} finally {
    presentation.dispose();
}
```


### **Schriftart‑Ersetzungen erkennen**

Aspose.Slides stellt die [setWarningCallback](https://reference.aspose.com/slides/nodejs-java/aspose.slides/saveoptions/#setWarningCallback)‑Methode der [PdfOptions](https://reference.aspose.com/slides/nodejs-java/aspose.slides/PdfOptions)‑Klasse bereit, mit der Sie Schriftart‑Ersetzungen während des PowerPoint‑zu‑PDF‑Konvertierungsprozesses erkennen können.

Dieses JavaScript‑Beispiel zeigt, wie Schriftart‑Ersetzungen erkannt werden:
```js
// Setzen Sie die Warnungsrückruffunktion in den PDF-Optionen.
let pdfOptions = new aspose.slides.PdfOptions();
pdfOptions.setWarningCallback(FontSubstitutionHandler);

// Instanziieren Sie die Presentation-Klasse, die eine PowerPoint- oder OpenDocument-Datei darstellt.
let presentation = new aspose.slides.Presentation("sample.pptx");

// Speichern Sie die Präsentation als PDF.
presentation.save("output.pdf", aspose.slides.SaveFormat.Pdf, pdfOptions);
presentation.dispose();
```

```js
const FontSubstitutionHandler = java.newProxy("com.aspose.slides.IWarningCallback", {
	warning: function (warning) {
		if (warning.getWarningType() === aspose.slides.WarningType.DataLoss) {
			console.warn("Font substitution warning: " + warning.getDescription());
		}
		return aspose.slides.ReturnAction.Continue;
	}
});
```


{{%  alert color="primary"  %}} 
Weitere Informationen zu Schriftart‑Ersetzungen finden Sie im Artikel [Font Substitution](/slides/de/nodejs-java/font-substitution/).
{{% /alert %}} 

## **Ausgewählte Folien in PowerPoint in PDF konvertieren**

Dieses JavaScript‑Beispiel demonstriert, wie Sie nur bestimmte Folien einer PowerPoint‑Präsentation in PDF konvertieren:
```js
// Instanziieren Sie die Presentation-Klasse, die eine PowerPoint- oder OpenDocument-Datei darstellt.
let presentation = new aspose.slides.Presentation("PowerPoint.pptx");
try {
    // Array von Foliennummern festlegen.
    let slides = java.newArray("int", [1, 3]);

    // Präsentation als PDF speichern.
    presentation.save("PPTX-to-PDF.pdf", slides, aspose.slides.SaveFormat.Pdf);
} finally {
    presentation.dispose();
}
```


## **PowerPoint in PDF mit benutzerdefinierter Foliengröße konvertieren**

Dieses JavaScript‑Beispiel demonstriert, wie Sie eine PowerPoint‑Präsentation mit einer festgelegten Foliengröße in PDF konvertieren:
```js
const slideWidth = 612;
const slideHeight = 792;

// Instanziieren Sie die Presentation‑Klasse, die eine PowerPoint‑ oder OpenDocument‑Datei repräsentiert.
let presentation = new aspose.slides.Presentation("SelectedSlides.pptx");

// Erstellen Sie eine neue Präsentation mit einer angepassten Foliengröße.
let resizedPresentation = new aspose.slides.Presentation();

try {
    // Legen Sie die benutzerdefinierte Foliengröße fest.
    resizedPresentation.getSlideSize().setSize(slideWidth, slideHeight, aspose.slides.SlideSizeScaleType.EnsureFit);

    // Klonen Sie die erste Folie aus der ursprünglichen Präsentation.
    let slide = presentation.getSlides().get_Item(0);
    resizedPresentation.getSlides().insertClone(0, slide);

    // Speichern Sie die skalierte Präsentation als PDF mit Notizen.
    resizedPresentation.save("PDF_with_notes.pdf", aspose.slides.SaveFormat.Pdf);
} finally {
    resizedPresentation.dispose();
    presentation.dispose();
}
```


## **PowerPoint in PDF im Notiz‑Folien‑Modus konvertieren**

Dieses JavaScript‑Beispiel demonstriert, wie Sie eine PowerPoint‑Präsentation in ein PDF konvertieren, das die Notizen enthält:
```js
// Instanziieren Sie die Presentation-Klasse, die eine PowerPoint- oder OpenDocument-Datei darstellt.
let presentation = new aspose.slides.Presentation("SelectedSlides.pptx");
try {
    // Konfigurieren Sie die PDF-Optionen mit Notizenlayout.
    let notesOptions = new aspose.slides.NotesCommentsLayoutingOptions();
    notesOptions.setNotesPosition(aspose.slides.NotesPositions.BottomFull);
    let pdfOptions = new aspose.slides.PdfOptions();
    pdfOptions.setSlidesLayoutOptions(notesOptions);

    // Speichern Sie die Präsentation als PDF mit Notizen.
    presentation.save("PDF_with_notes.pdf", aspose.slides.SaveFormat.Pdf, pdfOptions);
} finally {
    presentation.dispose();
}
```


## **Barrierefreiheit und Compliance‑Standards für PDF**

Aspose.Slides ermöglicht ein Konvertierungsverfahren, das den [Web Content Accessibility Guidelines (**WCAG**)](https://www.w3.org/TR/WCAG-TECHS/pdf.html) entspricht. Sie können ein PowerPoint‑Dokument mit einem der folgenden Compliance‑Standards in PDF exportieren: **PDF/A1a**, **PDF/A1b** und **PDF/UA**.

Dieses JavaScript‑Beispiel demonstriert einen PowerPoint‑zu‑PDF‑Konvertierungsprozess, der mehrere PDFs basierend auf unterschiedlichen Compliance‑Standards erzeugt:
```js
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


{{% alert title="Note" color="warning" %}} 
Aspose.Slides unterstützt PDF‑Konvertierungsoperationen, mit denen Sie PDF‑Dateien in gängige Formate konvertieren können. Sie können [PDF zu HTML](https://products.aspose.com/slides/nodejs-java/conversion/pdf-to-html/), [PDF zu JPG](https://products.aspose.com/slides/nodejs-java/conversion/pdf-to-jpg/) und [PDF zu PNG](https://products.aspose.com/slides/nodejs-java/conversion/pdf-to-png/) konvertieren. Weitere PDF‑Konvertierungen in Spezialformate – [PDF zu SVG](https://products.aspose.com/slides/nodejs-java/conversion/pdf-to-svg/), [PDF zu TIFF](https://products.aspose.com/slides/nodejs-java/conversion/pdf-to-tiff/) – werden ebenfalls unterstützt.
{{% /alert %}}

## **FAQ**

**Kann ich mehrere PowerPoint‑Dateien stapelweise in PDF konvertieren?**

Ja, Aspose.Slides unterstützt die Batch‑Konvertierung mehrerer PPT‑ oder PPTX‑Dateien in PDF. Sie können Ihre Dateien iterativ verarbeiten und den Konvertierungsprozess programmgesteuert anwenden.

**Ist es möglich, das konvertierte PDF mit einem Passwort zu schützen?**

Auf jeden Fall. Verwenden Sie die [PdfOptions](https://reference.aspose.com/slides/nodejs-java/aspose.slides/PdfOptions)‑Klasse, um ein Passwort zu setzen und Zugriffsrechte während des Konvertierungsprozesses festzulegen.

**Wie kann ich ausgeblendete Folien in das PDF einbeziehen?**

Verwenden Sie die `setShowHiddenSlides`‑Methode der [PdfOptions](https://reference.aspose.com/slides/nodejs-java/aspose.slides/PdfOptions)‑Klasse, um ausgeblendete Folien im resultierenden PDF zu integrieren.

**Kann Aspose.Slides eine hohe Bildqualität im PDF gewährleisten?**

Ja, Sie können die Bildqualität steuern, indem Sie Methoden wie `setJpegQuality` und `setSufficientResolution` der [PdfOptions](https://reference.aspose.com/slides/nodejs-java/aspose.slides/PdfOptions)‑Klasse verwenden, um hochqualitative Bilder im PDF zu erhalten.

**Unterstützt Aspose.Slides die PDF/A‑Compliance‑Standards?**

Ja, Aspose.Slides ermöglicht den Export von PDFs, die verschiedene Standards wie PDF/A1a, PDF/A1b und PDF/UA erfüllen, sodass Ihre Dokumente Barrierefreiheit und Archivierungsanforderungen genügen.

## **Zusätzliche Ressourcen**

- [Aspose.Slides für Node.js via Java Dokumentation](/slides/de/nodejs-java/)
- [Aspose.Slides für Node.js via Java API‑Referenz](https://reference.aspose.com/slides/nodejs-java/)
- [Aspose Kostenlose Online‑Konverter](https://products.aspose.app/slides/conversion)