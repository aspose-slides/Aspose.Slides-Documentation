---
title: PPT- und PPTX-Dateien in PDF konvertieren in JavaScript [Erweiterte Funktionen enthalten]
linktitle: PPT und PPTX in PDF konvertieren
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
- ODP zu PDF
- ODP zu PDF konvertieren
- PowerPoint als PDF speichern
- PDF/A1a
- PDF/A1b
- PDF/UA
- JavaScript
- Node.js
- Aspose.Slides für Node.js via Java
description: "Erfahren Sie, wie Sie PPT-, PPTX- und ODP-Präsentationen in PDF in JavaScript mit Aspose.Slides konvertieren. Implementieren Sie erweiterte Funktionen wie Passwortschutz, Compliance-Standards und benutzerdefinierte Optionen für hochwertige, barrierefreie PDF-Dokumente."
---

## **Übersicht**

Die Konvertierung von PowerPoint‑ und OpenDocument‑Präsentationen (PPT, PPTX, ODP usw.) in PDF‑Format mit JavaScript bietet mehrere Vorteile, darunter Kompatibilität über verschiedene Geräte hinweg und die Erhaltung von Layout und Formatierung Ihrer Präsentation. Dieser Leitfaden zeigt, wie Präsentationen in PDF‑Dokumente umgewandelt werden, verschiedene Optionen zur Steuerung der Bildqualität verwendet, versteckte Folien einbezogen, PDF‑Dateien passwortgeschützt werden, Schriftart‑Ersetzungen erkannt, bestimmte Folien für die Konvertierung ausgewählt und Compliance‑Standards auf Ausgabedokumente angewendet werden.

## **PowerPoint‑zu‑PDF‑Konvertierungen**

Mit Aspose.Slides können Sie Präsentationen in den folgenden Formaten in PDF konvertieren:

* **PPT**
* **PPTX**
* **ODP**

Um eine Präsentation in PDF zu konvertieren, übergeben Sie den Dateinamen als Argument an die [Presentation](https://reference.aspose.com/slides/nodejs-java/aspose.slides/presentation/)‑Klasse und speichern die Präsentation anschließend mit einer `save`‑Methode als PDF. Die [Presentation](https://reference.aspose.com/slides/nodejs-java/aspose.slides/presentation/)‑Klasse stellt die `save`‑Methode bereit, die typischerweise zur Konvertierung einer Präsentation in PDF verwendet wird.

{{%  alert title="NOTE"  color="warning"   %}} 

Aspose.Slides for Node.js via Java fügt seine API‑Informationen und Versionsnummer in Ausgabedokumente ein. Beispielweise füllt Aspose.Slides beim Konvertieren einer Präsentation zu PDF das Feld „Application“ mit „*Aspose.Slides*“ und das Feld „PDF Producer“ mit einem Wert im Format „*Aspose.Slides v XX.XX*“. **Hinweis**: Sie können Aspose.Slides nicht anweisen, diese Informationen aus Ausgabedokumenten zu ändern oder zu entfernen.

{{% /alert %}}

Aspose.Slides ermöglicht das Konvertieren von:

* Gesamten Präsentationen zu PDF
* Bestimmten Folien einer Präsentation zu PDF

Aspose.Slides exportiert Präsentationen nach PDF und sorgt dafür, dass die resultierenden PDFs den Originalpräsentationen sehr nahe kommen. Elemente und Attribute werden bei der Konvertierung präzise gerendert, einschließlich:

* Bilder
* Textfelder und Formen
* Textformatierung
* Absatzformatierung
* Hyperlinks
* Kopf‑ und Fußzeilen
* Aufzählungszeichen
* Tabellen

## **PowerPoint zu PDF konvertieren**

Der Standard‑PowerPoint‑zu‑PDF‑Konvertierungsprozess verwendet die Standardoptionen. In diesem Fall versucht Aspose.Slides, die bereitgestellte Präsentation mit optimalen Einstellungen und maximaler Qualität in PDF zu konvertieren.

Der folgende Code zeigt, wie eine Präsentation (PPT, PPTX, ODP usw.) zu PDF konvertiert wird:
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

Aspose bietet einen kostenlosen Online‑[**PowerPoint‑zu‑PDF‑Konverter**](https://products.aspose.app/slides/conversion/ppt-to-pdf), der den Präsentation‑zu‑PDF‑Konvertierungsprozess demonstriert. Sie können mit diesem Konverter einen Testlauf für eine Live‑Implementierung des hier beschriebenen Verfahrens durchführen.

{{% /alert %}}

## **PowerPoint zu PDF mit Optionen konvertieren**

Aspose.Slides stellt benutzerdefinierte Optionen – Eigenschaften der [PdfOptions](https://reference.aspose.com/slides/nodejs-java/aspose.slides/pdfoptions/)‑Klasse – bereit, mit denen Sie das resultierende PDF anpassen, mit einem Passwort schützen oder festlegen können, wie der Konvertierungsprozess ablaufen soll.

### **PowerPoint zu PDF mit benutzerdefinierten Optionen konvertieren**

Mit benutzerdefinierten Konvertierungsoptionen können Sie Ihre bevorzugten Qualitätseinstellungen für Rasterbilder festlegen, bestimmen, wie Metadateien behandelt werden, ein Komprimierungslevel für Text setzen, DPI für Bilder konfigurieren und mehr.

Das nachstehende Codebeispiel demonstriert, wie eine PowerPoint‑Präsentation mit mehreren benutzerdefinierten Optionen in PDF konvertiert wird.
```js
// Instanziieren Sie die PdfOptions-Klasse.
let pdfOptions = new aspose.slides.PdfOptions();

// Legen Sie die Qualität für JPG-Bilder fest.
pdfOptions.setJpegQuality(java.newByte(90));

// Legen Sie die DPI für Bilder fest.
pdfOptions.setSufficientResolution(300);

// Legen Sie das Verhalten für Metadateien fest.
pdfOptions.setSaveMetafilesAsPng(true);

// Legen Sie das Textkompressionslevel für textuelle Inhalte fest.
pdfOptions.setTextCompression(aspose.slides.PdfTextCompression.Flate);

// Definieren Sie den PDF-Konformitätsmodus.
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


### **PowerPoint zu PDF mit versteckten Folien konvertieren**

Enthält eine Präsentation versteckte Folien, können Sie die Methode [setShowHiddenSlides](https://reference.aspose.com/slides/nodejs-java/aspose.slides/PdfOptions#setShowHiddenSlides) der [PdfOptions](https://reference.aspose.com/slides/nodejs-java/aspose.slides/PdfOptions)‑Klasse verwenden, um die versteckten Folien als Seiten im resultierenden PDF einzuschließen.

Dieser JavaScript‑Code zeigt, wie eine PowerPoint‑Präsentation zu PDF konvertiert wird, wobei versteckte Folien einbezogen werden:
```js
// Instanziieren Sie die Presentation-Klasse, die eine PowerPoint- oder OpenDocument-Datei darstellt.
let presentation = new aspose.slides.Presentation("PowerPoint.pptx");
try {
    // Instanziieren Sie die PdfOptions-Klasse.
    let pdfOptions = new aspose.slides.PdfOptions();

    // Versteckte Folien hinzufügen.
    pdfOptions.setShowHiddenSlides(true);

    // Speichern Sie die Präsentation als PDF.
    presentation.save("PowerPoint-to-PDF.pdf", aspose.slides.SaveFormat.Pdf, pdfOptions);
} finally {
    presentation.dispose();
}
```


### **PowerPoint zu passwortgeschütztem PDF konvertieren**

Dieser JavaScript‑Code demonstriert, wie eine PowerPoint‑Präsentation mit den Schutzparametern der [PdfOptions](https://reference.aspose.com/slides/nodejs-java/aspose.slides/PdfOptions)‑Klasse in ein passwortgeschütztes PDF umgewandelt wird:
```js
// Instanziieren Sie die Presentation-Klasse, die eine PowerPoint- oder OpenDocument-Datei repräsentiert.
let presentation = new aspose.slides.Presentation("PowerPoint.pptx");
try {
    // Instanziieren Sie die PdfOptions-Klasse.
    let pdfOptions = new aspose.slides.PdfOptions();

    // Legen Sie ein PDF-Passwort und Zugriffsberechtigungen fest.
    pdfOptions.setPassword("password");
    pdfOptions.setAccessPermissions(aspose.slides.PdfAccessPermissions.PrintDocument | aspose.slides.PdfAccessPermissions.HighQualityPrint);

    // Speichern Sie die Präsentation als PDF.
    presentation.save("PPTX-to-PDF.pdf", aspose.slides.SaveFormat.Pdf, pdfOptions);
} finally {
    presentation.dispose();
}
```


### **Schriftart‑Ersetzungen erkennen**

Aspose.Slides bietet die Methode [setWarningCallback](https://reference.aspose.com/slides/nodejs-java/aspose.slides/saveoptions/#setWarningCallback) unter der [PdfOptions](https://reference.aspose.com/slides/nodejs-java/aspose.slides/PdfOptions)‑Klasse, mit der Sie Schriftart‑Ersetzungen während des Präsentation‑zu‑PDF‑Konvertierungsprozesses erkennen können.

Dieser JavaScript‑Code zeigt, wie Schriftart‑Ersetzungen erkannt werden:
```js
// Warnungs-Callback in PDF-Optionen festlegen.
let pdfOptions = new aspose.slides.PdfOptions();
pdfOptions.setWarningCallback(FontSubstitutionHandler);

// Instanziieren Sie die Presentation-Klasse, die eine PowerPoint- oder OpenDocument-Datei repräsentiert.
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

Weitere Informationen zum Empfangen von Callbacks für Schriftart‑Ersetzungen während des Renderings finden Sie unter [Getting Warning Callbacks for Fonts Substitution](/slides/de/nodejs-java/getting-warning-callbacks-for-fonts-substitution-in-aspose-slides/).

Weitere Informationen zu Schriftart‑Ersetzungen finden Sie im Artikel [Font Substitution](/slides/de/nodejs-java/font-substitution/).

{{% /alert %}} 

## **Ausgewählte Folien in PowerPoint zu PDF konvertieren**

Dieser JavaScript‑Code demonstriert, wie nur bestimmte Folien einer PowerPoint‑Präsentation zu PDF konvertiert werden:
```js
// Instanziieren Sie die Presentation-Klasse, die eine PowerPoint- oder OpenDocument-Datei darstellt.
let presentation = new aspose.slides.Presentation("PowerPoint.pptx");
try {
    // Array mit Foliennummern festlegen.
    let slides = java.newArray("int", [1, 3]);

    // Präsentation als PDF speichern.
    presentation.save("PPTX-to-PDF.pdf", slides, aspose.slides.SaveFormat.Pdf);
} finally {
    presentation.dispose();
}
```


## **PowerPoint zu PDF mit benutzerdefinierter Foliengröße konvertieren**

Dieser JavaScript‑Code demonstriert, wie eine PowerPoint‑Präsentation zu PDF mit einer angegebenen Foliengröße konvertiert wird:
```js
const slideWidth = 612;
const slideHeight = 792;

// Instanziieren Sie die Presentation‑Klasse, die eine PowerPoint‑ oder OpenDocument‑Datei darstellt.
let presentation = new aspose.slides.Presentation("SelectedSlides.pptx");

// Erstellen Sie eine neue Präsentation mit angepasster Foliengröße.
let resizedPresentation = new aspose.slides.Presentation();

try {
    // Legen Sie die benutzerdefinierte Foliengröße fest.
    resizedPresentation.getSlideSize().setSize(slideWidth, slideHeight, aspose.slides.SlideSizeScaleType.EnsureFit);

    // Klonen Sie die erste Folie aus der Originalpräsentation.
    let slide = presentation.getSlides().get_Item(0);
    resizedPresentation.getSlides().insertClone(0, slide);

    // Speichern Sie die skalierte Präsentation als PDF mit Notizen.
    resizedPresentation.save("PDF_with_notes.pdf", aspose.slides.SaveFormat.Pdf);
} finally {
    resizedPresentation.dispose();
    presentation.dispose();
}
```


## **PowerPoint zu PDF in Notiz‑Folien‑Ansicht konvertieren**

Dieser JavaScript‑Code demonstriert, wie eine PowerPoint‑Präsentation zu einem PDF konvertiert wird, das Notizen enthält:
```js
// Instanziieren Sie die Presentation‑Klasse, die eine PowerPoint‑ oder OpenDocument‑Datei repräsentiert.
let presentation = new aspose.slides.Presentation("SelectedSlides.pptx");
try {
    // Konfigurieren Sie die PDF‑Optionen mit Notizenlayout.
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

Aspose.Slides ermöglicht ein Konvertierungsverfahren, das den [Web Content Accessibility Guidelines (**WCAG**)](https://www.w3.org/TR/WCAG-TECHS/pdf.html) entspricht. Sie können ein PowerPoint‑Dokument zu PDF exportieren und dabei einen der folgenden Compliance‑Standards verwenden: **PDF/A1a**, **PDF/A1b** und **PDF/UA**.

Dieser JavaScript‑Code demonstriert einen PowerPoint‑zu‑PDF‑Konvertierungsprozess, der mehrere PDFs basierend auf unterschiedlichen Compliance‑Standards erzeugt:
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

Aspose.Slides unterstützt PDF‑Konvertierungs‑Operationen, mit denen Sie PDF‑Dateien in gängige Dateiformate umwandeln können. Sie können [PDF zu HTML](https://products.aspose.com/slides/nodejs-java/conversion/pdf-to-html/), [PDF zu JPG](https://products.aspose.com/slides/nodejs-java/conversion/pdf-to-jpg/) und [PDF zu PNG](https://products.aspose.com/slides/nodejs-java/conversion/pdf-to-png/) konvertieren. Weitere PDF‑Konvertierungs‑Operationen zu spezialisierten Formaten – [PDF zu SVG](https://products.aspose.com/slides/nodejs-java/conversion/pdf-to-svg/), [PDF zu TIFF](https://products.aspose.com/slides/nodejs-java/conversion/pdf-to-tiff/) – werden ebenfalls unterstützt.

{{% /alert %}}

## **FAQ**

**Kann ich mehrere PowerPoint‑Dateien stapelweise zu PDF konvertieren?**

Ja, Aspose.Slides unterstützt die Batch‑Konvertierung mehrerer PPT‑ oder PPTX‑Dateien zu PDF. Sie können Ihre Dateien iterativ durchlaufen und den Konvertierungsprozess programmgesteuert anwenden.

**Ist es möglich, das konvertierte PDF mit einem Passwort zu schützen?**

Absolut. Verwenden Sie die [PdfOptions](https://reference.aspose.com/slides/nodejs-java/aspose.slides/PdfOptions)‑Klasse, um ein Passwort festzulegen und Zugriffsrechte während des Konvertierungsprozesses zu definieren.

**Wie füge ich versteckte Folien in das PDF ein?**

Verwenden Sie die Methode `setShowHiddenSlides` in der [PdfOptions](https://reference.aspose.com/slides/nodejs-java/aspose.slides/PdfOptions)‑Klasse, um versteckte Folien im resultierenden PDF zu berücksichtigen.

**Kann Aspose.Slides eine hohe Bildqualität im PDF beibehalten?**

Ja, Sie können die Bildqualität steuern, indem Sie Methoden wie `setJpegQuality` und `setSufficientResolution` der [PdfOptions](https://reference.aspose.com/slides/nodejs-java/aspose.slides/PdfOptions)‑Klasse einsetzen, um hochqualitative Bilder in Ihrem PDF zu gewährleisten.

**Unterstützt Aspose.Slides PDF/A‑Compliance‑Standards?**

Ja, Aspose.Slides ermöglicht den Export von PDFs, die verschiedenen Standards entsprechen, darunter PDF/A1a, PDF/A1b und PDF/UA, sodass Ihre Dokumente sowohl barrierefrei als auch archivierungsfähig sind.

## **Weitere Ressourcen**

- [Aspose.Slides for Node.js via Java Documentation](/slides/de/nodejs-java/)
- [Aspose.Slides for Node.js via Java API Reference](https://reference.aspose.com/slides/nodejs-java/)
- [Aspose Free Online Converters](https://products.aspose.app/slides/conversion)