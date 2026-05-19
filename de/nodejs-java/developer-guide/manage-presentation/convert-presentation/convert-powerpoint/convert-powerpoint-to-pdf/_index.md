---
title: PPT und PPTX in PDF konvertieren in JavaScript [Erweiterte Funktionen enthalten]
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
description: "Konvertieren Sie PowerPoint PPT/PPTX in hochwertige, durchsuchbare PDFs mit Aspose.Slides für Node.js, inklusive schneller Codebeispiele und erweiterten Konvertierungsoptionen."
---
## **Übersicht**

Die Konvertierung von PowerPoint- und OpenDocument-Präsentationen (PPT, PPTX, ODP usw.) in das PDF-Format mit JavaScript bietet mehrere Vorteile, darunter die Kompatibilität über verschiedene Geräte hinweg und die Bewahrung des Layouts und der Formatierung Ihrer Präsentation. Dieser Leitfaden zeigt, wie man Präsentationen in PDF-Dokumente konvertiert, verschiedene Optionen zur Steuerung der Bildqualität verwendet, ausgeblendete Folien einbezieht, PDF-Dateien passwortschützt, Schriftart-Substitutionen erkennt, bestimmte Folien für die Konvertierung auswählt und Compliance-Standards auf die Ausgabedokumente anwendet.

## **PowerPoint-zu-PDF-Konvertierungen**

Mit Aspose.Slides können Sie Präsentationen in den folgenden Formaten in PDF konvertieren:

* **PPT**
* **PPTX**
* **ODP**

Um eine Präsentation in PDF zu konvertieren, übergeben Sie den Dateinamen als Argument an die [Presentation](https://reference.aspose.com/slides/de/nodejs-java/aspose.slides/presentation/)‑Klasse und speichern Sie die Präsentation anschließend mit der Methode `save` als PDF. Die [Presentation](https://reference.aspose.com/slides/de/nodejs-java/aspose.slides/presentation/)‑Klasse stellt die Methode `save` bereit, die typischerweise zur Konvertierung einer Präsentation in PDF verwendet wird.

{{%  alert title="NOTE"  color="warning"   %}} 
Aspose.Slides für Node.js via Java fügt seine API-Informationen und Versionsnummer in Ausgabedokumente ein. Beispielsweise füllt Aspose.Slides beim Konvertieren einer Präsentation in PDF das Feld Application mit „*Aspose.Slides*“ und das Feld PDF Producer mit einem Wert in der Form „*Aspose.Slides v XX.XX*“. **Hinweis**: Sie können Aspose.Slides nicht anweisen, diese Informationen aus den Ausgabedokumenten zu ändern oder zu entfernen.
{{% /alert %}}

Aspose.Slides ermöglicht es Ihnen, zu konvertieren:

* Gesamte Präsentationen in PDF
* Bestimmte Folien einer Präsentation in PDF

Aspose.Slides exportiert Präsentationen nach PDF und stellt sicher, dass die resultierenden PDFs eng mit den Originalpräsentationen übereinstimmen. Elemente und Attribute werden bei der Konvertierung exakt wiedergegeben, einschließlich:

* Bilder
* Textfelder und Formen
* Textformatierung
* Absatzformatierung
* Hyperlinks
* Kopf‑ und Fußzeilen
* Aufzählungszeichen
* Tabellen

## **PowerPoint in PDF konvertieren**

Der standardmäßige PowerPoint‑zu‑PDF‑Konvertierungsprozess verwendet die Standardoptionen. In diesem Fall versucht Aspose.Slides, die bereitgestellte Präsentation mit optimalen Einstellungen und maximaler Qualitätsstufe in PDF zu konvertieren.

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
Aspose bietet einen kostenlosen Online-**PowerPoint‑zu‑PDF‑Konverter**(https://products.aspose.app/slides/de/conversion/ppt-to-pdf) an, der den Präsentation‑zu‑PDF‑Konvertierungsprozess demonstriert. Sie können mit diesem Konverter einen Test durchführen, um eine Live‑Implementierung des hier beschriebenen Verfahrens zu sehen.
{{% /alert %}}

## **PowerPoint in PDF mit Optionen konvertieren**

Aspose.Slides stellt benutzerdefinierte Optionen—Eigenschaften der Klasse [PdfOptions](https://reference.aspose.com/slides/de/nodejs-java/aspose.slides/pdfoptions/)—zur Verfügung, mit denen Sie das resultierende PDF anpassen, das PDF mit einem Passwort schützen oder festlegen können, wie der Konvertierungsprozess ablaufen soll.

### **PowerPoint in PDF mit benutzerdefinierten Optionen konvertieren**

Mit benutzerdefinierten Konvertierungsoptionen können Sie Ihre bevorzugte Qualitätseinstellung für Rastergrafiken festlegen, bestimmen, wie Metadateien gehandhabt werden sollen, ein Kompressionsniveau für Text festlegen, die DPI für Bilder konfigurieren und vieles mehr.

Das nachstehende Codebeispiel demonstriert, wie Sie eine PowerPoint‑Präsentation mit mehreren benutzerdefinierten Optionen in PDF konvertieren:

```js
// Instanziieren Sie die PdfOptions-Klasse.
let pdfOptions = new aspose.slides.PdfOptions();

// Legen Sie die Qualität für JPG-Bilder fest.
pdfOptions.setJpegQuality(java.newByte(90));

// Legen Sie die DPI für Bilder fest.
pdfOptions.setSufficientResolution(300);

// Definieren Sie das Verhalten für Metadateien.
pdfOptions.setSaveMetafilesAsPng(true);

// Legen Sie das Textkomprimierungsniveau für Textinhalte fest.
pdfOptions.setTextCompression(aspose.slides.PdfTextCompression.Flate);

// Definieren Sie den PDF-Compliance-Modus.
pdfOptions.setCompliance(aspose.slides.PdfCompliance.Pdf15);

// Instanziieren Sie die Presentation-Klasse, die eine PowerPoint- oder OpenDocument-Datei repräsentiert.
let presentation = new aspose.slides.Presentation("PowerPoint.pptx");
try {
    // Speichern Sie die Präsentation als PDF-Dokument.
    presentation.save("PowerPoint-to-PDF.pdf", aspose.slides.SaveFormat.Pdf, pdfOptions);
} finally {
    presentation.dispose();
}
```

### **PowerPoint in PDF mit ausgeblendeten Folien konvertieren**

Enthält eine Präsentation ausgeblendete Folien, können Sie die Methode [setShowHiddenSlides](https://reference.aspose.com/slides/de/nodejs-java/aspose.slides/PdfOptions#setShowHiddenSlides) der Klasse [PdfOptions](https://reference.aspose.com/slides/de/nodejs-java/aspose.slides/PdfOptions) verwenden, um die ausgeblendeten Folien als Seiten im resultierenden PDF einzubeziehen.

Der folgende JavaScript‑Code zeigt, wie Sie eine PowerPoint‑Präsentation mit einbezogenen ausgeblendeten Folien in PDF konvertieren:

```js
// Instanziieren Sie die Presentation-Klasse, die eine PowerPoint- oder OpenDocument-Datei repräsentiert.
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

### **PowerPoint in passwortgeschütztes PDF konvertieren**

Der folgende JavaScript‑Code demonstriert, wie Sie eine PowerPoint‑Präsentation mit den Schutzparametern der Klasse [PdfOptions](https://reference.aspose.com/slides/de/nodejs-java/aspose.slides/PdfOptions) in ein passwortgeschütztes PDF konvertieren:

```js
// Instanziieren Sie die Presentation-Klasse, die eine PowerPoint- oder OpenDocument-Datei repräsentiert.
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

### **Schriftart‑Substitutionen erkennen**

Aspose.Slides stellt die Methode [setWarningCallback](https://reference.aspose.com/slides/de/nodejs-java/aspose.slides/saveoptions/#setWarningCallback) unter der Klasse [PdfOptions](https://reference.aspose.com/slides/de/nodejs-java/aspose.slides/PdfOptions) bereit, mit der Sie Schriftart‑Substitutionen während des Präsentation‑zu‑PDF‑Konvertierungsprozesses erkennen können.

Der folgende JavaScript‑Code zeigt, wie Sie Schriftart‑Substitutionen erkennen:

```js
// Setzen Sie den Warncallback in den PDF-Optionen.
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
Für weitere Informationen zu Schriftart‑Substitutionen siehe den Artikel [Font Substitution](/slides/de/nodejs-java/font-substitution/).
{{% /alert %}} 

## **Ausgewählte Folien in PowerPoint in PDF konvertieren**

Der folgende JavaScript‑Code demonstriert, wie Sie nur bestimmte Folien einer PowerPoint‑Präsentation in PDF konvertieren:

```js
// Instanziieren Sie die Presentation-Klasse, die eine PowerPoint- oder OpenDocument-Datei repräsentiert.
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

Der folgende JavaScript‑Code demonstriert, wie Sie eine PowerPoint‑Präsentation mit einer angegebenen Foliengröße in PDF konvertieren:

```js
const slideWidth = 612;
const slideHeight = 792;

// Instanziieren Sie die Presentation‑Klasse, die eine PowerPoint‑ oder OpenDocument‑Datei repräsentiert.
let presentation = new aspose.slides.Presentation("SelectedSlides.pptx");

// Erstellen Sie eine neue Präsentation mit angepasster Foliengröße.
let resizedPresentation = new aspose.slides.Presentation();

try {
    // Benutzerdefinierte Foliengröße festlegen.
    resizedPresentation.getSlideSize().setSize(slideWidth, slideHeight, aspose.slides.SlideSizeScaleType.EnsureFit);

    // Erste Folie aus der Originalpräsentation klonen.
    let slide = presentation.getSlides().get_Item(0);
    resizedPresentation.getSlides().insertClone(0, slide);

    // Angepasste Präsentation als PDF mit Notizen speichern.
    resizedPresentation.save("PDF_with_notes.pdf", aspose.slides.SaveFormat.Pdf);
} finally {
    resizedPresentation.dispose();
    presentation.dispose();
}
```

## **PowerPoint in PDF im Notizfolien‑Modus konvertieren**

Der folgende JavaScript‑Code demonstriert, wie Sie eine PowerPoint‑Präsentation in ein PDF konvertieren, das Notizen enthält:

```js
// Instanziieren Sie die Presentation‑Klasse, die eine PowerPoint‑ oder OpenDocument‑Datei repräsentiert.
let presentation = new aspose.slides.Presentation("SelectedSlides.pptx");
try {
    // PDF-Optionen mit Notizenlayout konfigurieren.
    let notesOptions = new aspose.slides.NotesCommentsLayoutingOptions();
    notesOptions.setNotesPosition(aspose.slides.NotesPositions.BottomFull);
    let pdfOptions = new aspose.slides.PdfOptions();
    pdfOptions.setSlidesLayoutOptions(notesOptions);

    // Präsentation als PDF mit Notizen speichern.
    presentation.save("PDF_with_notes.pdf", aspose.slides.SaveFormat.Pdf, pdfOptions);
} finally {
    presentation.dispose();
}
```

## **Barrierefreiheit und Compliance‑Standards für PDF**

Aspose.Slides ermöglicht die Verwendung eines Konvertierungsverfahrens, das den [Web Content Accessibility Guidelines (**WCAG**)](https://www.w3.org/TR/WCAG-TECHS/pdf.html) entspricht. Sie können ein PowerPoint‑Dokument in PDF exportieren und dabei einen dieser Compliance‑Standards verwenden: **PDF/A1a**, **PDF/A1b** und **PDF/UA**.

Der folgende JavaScript‑Code demonstriert einen PowerPoint‑zu‑PDF‑Konvertierungsprozess, der basierend auf verschiedenen Compliance‑Standards mehrere PDFs erzeugt:

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
Aspose.Slides unterstützt PDF‑Konvertierungsoperationen, mit denen Sie PDF‑Dateien in gängige Dateiformate konvertieren können. Sie können Konvertierungen zu [PDF to HTML](https://products.aspose.com/slides/de/nodejs-java/conversion/pdf-to-html/), [PDF to JPG](https://products.aspose.com/slides/de/nodejs-java/conversion/pdf-to-jpg/) und [PDF to PNG](https://products.aspose.com/slides/de/nodejs-java/conversion/pdf-to-png/) durchführen. Weitere PDF‑Konvertierungen in spezialisierte Formate – [PDF to SVG](https://products.aspose.com/slides/de/nodejs-java/conversion/pdf-to-svg/), [PDF to TIFF](https://products.aspose.com/slides/de/nodejs-java/conversion/pdf-to-tiff/) – werden ebenfalls unterstützt.
{{% /alert %}}

> **Hinweis:** Beim Exportieren nach PDF/UA behandelt Aspose.Slides komplexe Grafiken wie SmartArt, Diagramme und Formeln als eine einzelne Figur. Einzelne Pfadelemente werden nicht als separater Inhalt erhalten und können als Artefakte markiert werden; alternativer Text wird nur für die gesamte Figur bereitgestellt.

## **FAQ**

**Kann ich mehrere PowerPoint‑Dateien gleichzeitig in PDF konvertieren?**  
Ja, Aspose.Slides unterstützt die Stapelkonvertierung mehrerer PPT‑ oder PPTX‑Dateien in PDF. Sie können Ihre Dateien iterativ verarbeiten und den Konvertierungsprozess programmgesteuert anwenden.

**Ist es möglich, das konvertierte PDF mit einem Passwort zu schützen?**  
Selbstverständlich. Verwenden Sie die Klasse [PdfOptions](https://reference.aspose.com/slides/de/nodejs-java/aspose.slides/PdfOptions), um ein Passwort zu setzen und Zugriffsberechtigungen während des Konvertierungsprozesses zu definieren.

**Wie kann ich ausgeblendete Folien in das PDF einbeziehen?**  
Verwenden Sie die Methode `setShowHiddenSlides` in der Klasse [PdfOptions](https://reference.aspose.com/slides/de/nodejs-java/aspose.slides/PdfOptions), um ausgeblendete Folien in das resultierende PDF aufzunehmen.

**Kann Aspose.Slides eine hohe Bildqualität im PDF beibehalten?**  
Ja, Sie können die Bildqualität steuern, indem Sie Methoden wie `setJpegQuality` und `setSufficientResolution` in der Klasse [PdfOptions](https://reference.aspose.com/slides/de/nodejs-java/aspose.slides/PdfOptions) verwenden, um hochqualitative Bilder in Ihrem PDF zu gewährleisten.

**Unterstützt Aspose.Slides PDF/A‑Compliance‑Standards?**  
Ja, Aspose.Slides ermöglicht den Export von PDFs, die verschiedenen Standards entsprechen, darunter PDF/A1a, PDF/A1b und PDF/UA, sodass Ihre Dokumente sowohl Zugänglichkeits‑ als auch Archivierungsanforderungen erfüllen.

## **Zusätzliche Ressourcen**

- [Aspose.Slides für Node.js via Java Dokumentation](/slides/de/nodejs-java/)
- [Aspose.Slides für Node.js via Java API‑Referenz](https://reference.aspose.com/slides/de/nodejs-java/)
- [Aspose Kostenlose Online‑Konverter](https://products.aspose.app/slides/de/conversion)