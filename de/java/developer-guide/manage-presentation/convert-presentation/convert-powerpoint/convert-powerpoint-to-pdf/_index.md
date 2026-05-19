---
title: PPT und PPTX in PDF konvertieren in Java [Erweiterte Funktionen enthalten]
linktitle: PowerPoint zu PDF
type: docs
weight: 40
url: /de/java/convert-powerpoint-to-pdf/
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
- Java
- Aspose.Slides
description: "PowerPoint PPT/PPTX in Java mit Aspose.Slides in hochwertige, durchsuchbare PDFs konvertieren, mit schnellen Codebeispielen und erweiterten Konvertierungsoptionen."
---
## **Übersicht**

Das Konvertieren von PowerPoint-Präsentationen (PPT, PPTX, ODP usw.) in das PDF-Format in Java bietet mehrere Vorteile, darunter Kompatibilität über verschiedene Geräte hinweg und das Bewahren des Layouts und der Formatierung Ihrer Präsentation. Diese Anleitung zeigt, wie Präsentationen in PDF-Dokumente konvertiert werden, verschiedene Optionen zur Steuerung der Bildqualität verwendet werden, versteckte Folien einbezogen werden, PDF-Dateien mit Passwort geschützt werden, Schriftart‑Ersetzungen erkannt werden, bestimmte Folien für die Konvertierung ausgewählt werden und Compliance‑Standards auf die Ausgabedokumente angewendet werden.

## **PowerPoint‑zu‑PDF‑Konvertierungen**

* **PPT**
* **PPTX**
* **ODP**

Um eine Präsentation in ein PDF zu konvertieren, übergeben Sie den Dateinamen als Argument an die [Presentation](https://reference.aspose.com/slides/de/java/com.aspose.slides/presentation/)‑Klasse und speichern Sie die Präsentation anschließend mit einer `save`‑Methode als PDF. Die [Presentation](https://reference.aspose.com/slides/de/java/com.aspose.slides/presentation/)‑Klasse stellt die `save`‑Methode bereit, die typischerweise zum Konvertieren einer Präsentation in PDF verwendet wird.

{{%  alert title="NOTE"  color="warning"   %}} 
Aspose.Slides für Java fügt seine API‑Informationen und Versionsnummer in Ausgabedokumente ein. Zum Beispiel füllt Aspose.Slides beim Konvertieren einer Präsentation in PDF das Feld Application mit „*Aspose.Slides*“ und das Feld PDF Producer mit einem Wert in der Form „*Aspose.Slides v XX.XX*“. **Hinweis**: Sie können Aspose.Slides nicht anweisen, diese Informationen aus Ausgabedokumenten zu ändern oder zu entfernen.
{{% /alert %}}

Aspose.Slides ermöglicht die Konvertierung von:
* Ganze Präsentationen in PDF
* Bestimmte Folien einer Präsentation in PDF

Aspose.Slides exportiert Präsentationen nach PDF und stellt sicher, dass die resultierenden PDFs dem Original sehr nahe kommen. Elemente und Attribute werden bei der Konvertierung exakt wiedergegeben, einschließlich:
* Bilder
* Textfelder und Formen
* Textformatierung
* Absatzformatierung
* Hyperlinks
* Kopf‑ und Fußzeilen
* Aufzählungszeichen
* Tabellen

## **PowerPoint in PDF konvertieren**

Der Standard‑PowerPoint‑zu‑PDF‑Konvertierungsprozess verwendet die Standardoptionen. In diesem Fall versucht Aspose.Slides, die bereitgestellte Präsentation mit optimalen Einstellungen und maximalen Qualitätsstufen in PDF zu konvertieren.

Der folgende Code zeigt, wie eine Präsentation (PPT, PPTX, ODP usw.) in PDF konvertiert wird:

```java
// Instanziieren Sie die Presentation-Klasse, die eine PowerPoint- oder OpenDocument-Datei darstellt.
Presentation presentation = new Presentation("PowerPoint.ppt");
try {
    // Speichern Sie die Präsentation als PDF.
    presentation.save("PPT-to-PDF.pdf", SaveFormat.Pdf);
} finally {
    presentation.dispose();
}
```

{{%  alert  color="primary"  %}} 
Aspose bietet einen kostenlosen Online‑**PowerPoint‑zu‑PDF‑Konverter**[**PowerPoint‑zu‑PDF‑Konverter**](https://products.aspose.app/slides/de/conversion/ppt-to-pdf), der den Präsentation‑zu‑PDF‑Konvertierungsprozess demonstriert. Sie können mit diesem Konverter einen Test durchführen, um die hier beschriebene Vorgehensweise live umzusetzen.
{{% /alert %}}

## **PowerPoint in PDF mit Optionen konvertieren**

Aspose.Slides bietet benutzerdefinierte Optionen – Eigenschaften der [PdfOptions](https://reference.aspose.com/slides/de/java/com.aspose.slides/pdfoptions/)‑Klasse –, mit denen Sie das resultierende PDF anpassen, das PDF mit einem Passwort schützen oder festlegen können, wie der Konvertierungsprozess ablaufen soll.

### **PowerPoint in PDF mit benutzerdefinierten Optionen konvertieren**

Mit benutzerdefinierten Konvertierungsoptionen können Sie die gewünschte Qualitätseinstellung für Rasterbilder festlegen, festlegen, wie Metadateien behandelt werden, ein Komprimierungslevel für Text setzen, die DPI für Bilder konfigurieren und mehr.

Das nachstehende Code‑Beispiel zeigt, wie eine PowerPoint‑Präsentation mit mehreren benutzerdefinierten Optionen in PDF konvertiert wird:

```java
// Instanziieren Sie die PdfOptions-Klasse.
PdfOptions pdfOptions = new PdfOptions();

// Set the quality for JPG images.
pdfOptions.setJpegQuality((byte)90);

// Set DPI for images.
pdfOptions.setSufficientResolution(300);

// Set the behavior for metafiles.
pdfOptions.setSaveMetafilesAsPng(true);

// Set the text compression level for textual content.
pdfOptions.setTextCompression(PdfTextCompression.Flate);

// Define the PDF compliance mode.
pdfOptions.setCompliance(PdfCompliance.Pdf15);

// Instanziieren Sie die Presentation-Klasse, die eine PowerPoint- oder OpenDocument-Datei darstellt.
Presentation presentation = new Presentation("PowerPoint.pptx");

try {
    // Speichern Sie die Präsentation als PDF-Dokument.
    presentation.save("PowerPoint-to-PDF.pdf", SaveFormat.Pdf, pdfOptions);
} finally {
    presentation.dispose();
}
```

### **PowerPoint in PDF mit versteckten Folien konvertieren**

Enthält eine Präsentation versteckte Folien, können Sie die Methode [setShowHiddenSlides](https://reference.aspose.com/slides/de/java/com.aspose.slides/pdfoptions/#setShowHiddenSlides-boolean-) der [PdfOptions](https://reference.aspose.com/slides/de/java/com.aspose.slides/pdfoptions/)‑Klasse verwenden, um die versteckten Folien als Seiten im resultierenden PDF einzubeziehen.

Der folgende Code zeigt, wie eine PowerPoint‑Präsentation in PDF konvertiert wird, wobei versteckte Folien einbezogen werden:

```java
// Instanziieren Sie die Presentation‑Klasse, die eine PowerPoint‑ oder OpenDocument‑Datei darstellt.
Presentation presentation = new Presentation("PowerPoint.pptx");
try {
    // Instanziieren Sie die PdfOptions‑Klasse.
    PdfOptions pdfOptions = new PdfOptions();

    // Versteckte Folien hinzufügen.
    pdfOptions.setShowHiddenSlides(true);

    // Präsentation als PDF speichern.
    presentation.save("PowerPoint-to-PDF.pdf", SaveFormat.Pdf, pdfOptions);
} finally {
    presentation.dispose();
}
```

### **PowerPoint in passwortgeschütztes PDF konvertieren**

Der folgende Code demonstriert, wie eine PowerPoint‑Präsentation mithilfe der Schutzparameter der [PdfOptions](https://reference.aspose.com/slides/de/java/com.aspose.slides/pdfoptions/)‑Klasse in ein passwortgeschütztes PDF konvertiert wird:

```java
// Instanziieren Sie die Presentation‑Klasse, die eine PowerPoint‑ oder OpenDocument‑Datei darstellt.
Presentation presentation = new Presentation("PowerPoint.pptx");
try {
    // Instanziieren Sie die PdfOptions‑Klasse.
    PdfOptions pdfOptions = new PdfOptions();

    // Setzen Sie ein PDF‑Passwort und Zugriffsberechtigungen.
    pdfOptions.setPassword("password");
    pdfOptions.setAccessPermissions(PdfAccessPermissions.PrintDocument | PdfAccessPermissions.HighQualityPrint);

    // Präsentation als PDF speichern.
    presentation.save("PPTX-to-PDF.pdf", SaveFormat.Pdf, pdfOptions);
} finally {
    presentation.dispose();
}
```

### **Schriftart‑Ersetzungen erkennen**

Aspose.Slides stellt die Methode [setWarningCallback](https://reference.aspose.com/slides/de/java/com.aspose.slides/saveoptions/#setWarningCallback-com.aspose.slides.IWarningCallback-) in der [PdfOptions](https://reference.aspose.com/slides/de/java/com.aspose.slides/pdfoptions/)‑Klasse bereit, mit der Sie Schriftart‑Ersetzungen während des Präsentation‑zu‑PDF‑Konvertierungsprozesses erkennen können.

Der folgende Code zeigt, wie Schriftart‑Ersetzungen erkannt werden:

```java
public static void main(String[] args) {
    // Instanziieren Sie die Presentation‑Klasse, die eine PowerPoint‑ oder OpenDocument‑Datei darstellt.
    Presentation presentation = new Presentation("sample.pptx");

    // Setzen Sie den Warn‑Callback in den PDF‑Optionen.
    PdfOptions pdfOptions = new PdfOptions();
    pdfOptions.setWarningCallback(new FontSubstitutionHandler());

    try {
        // Präsentation als PDF speichern.
        presentation.save("output.pdf", SaveFormat.Pdf, pdfOptions);
    } finally {
        presentation.dispose();
    }
}

// Implementierung des Warn‑Callbacks.
private static class FontSubstitutionHandler implements IWarningCallback {
    public int warning(IWarningInfo warning) {
        if (warning.getWarningType() == WarningType.DataLoss &&
                warning.getDescription().startsWith("Font will be substituted")) {
            System.out.println("Font substitution warning: " + warning.getDescription());
        }

        return ReturnAction.Continue;
    }
}
```

{{%  alert color="primary"  %}} 
Für weitere Informationen zum Empfangen von Callbacks für Schriftart‑Ersetzungen während des Rendering‑Prozesses finden Sie unter [Getting Warning Callbacks for Fonts Substitution](/slides/de/java/getting-warning-callbacks-for-fonts-substitution-in-aspose-slides/).

Weitere Informationen zu Schriftart‑Ersetzungen finden Sie im Artikel [Font Substitution](/slides/de/java/font-substitution/).
{{% /alert %}} 

## **Ausgewählte Folien in PowerPoint in PDF konvertieren**

Der folgende Code demonstriert, wie nur bestimmte Folien einer PowerPoint‑Präsentation in PDF konvertiert werden:

```java
// Instanziieren Sie die Presentation‑Klasse, die eine PowerPoint‑ oder OpenDocument‑Datei darstellt.
Presentation presentation = new Presentation("PowerPoint.pptx");
try {
    // Array von Foliennummern festlegen.
    int[] slides = { 1, 3 };

    // Präsentation als PDF speichern.
    presentation.save("PPTX-to-PDF.pdf", slides, SaveFormat.Pdf);
} finally {
    presentation.dispose();
}
```

## **PowerPoint in PDF mit benutzerdefinierter Foliengröße konvertieren**

Der folgende Code zeigt, wie eine PowerPoint‑Präsentation mit einer festgelegten Foliengröße in PDF konvertiert wird:

```java
float slideWidth = 612;
float slideHeight = 792;

// Instanziieren Sie die Presentation-Klasse, die eine PowerPoint- oder OpenDocument-Datei darstellt.
Presentation presentation = new Presentation("SelectedSlides.pptx");

// Erstellen Sie eine neue Präsentation mit angepasster Foliengröße.
Presentation resizedPresentation = new Presentation();

try {
    // Benutzerdefinierte Foliengröße festlegen.
    resizedPresentation.getSlideSize().setSize(slideWidth, slideHeight, SlideSizeScaleType.EnsureFit);
    
    // Klonen Sie die erste Folie aus der Originalpräsentation.
    ISlide slide = presentation.getSlides().get_Item(0);
    resizedPresentation.getSlides().insertClone(0, slide);

    // Speichern Sie die angepasste Präsentation als PDF mit Notizen.
    resizedPresentation.save("PDF_with_notes.pdf", SaveFormat.Pdf);
} finally {
    resizedPresentation.dispose();
    presentation.dispose();
}
```

## **PowerPoint in PDF mit Notizfolie‑Ansicht konvertieren**

Der folgende Code demonstriert, wie eine PowerPoint‑Präsentation in ein PDF konvertiert wird, das Notizen enthält:

```java
// Instanziieren Sie die Presentation‑Klasse, die eine PowerPoint‑ oder OpenDocument‑Datei darstellt.
Presentation presentation = new Presentation("SelectedSlides.pptx");
try {
    // PDF‑Optionen mit Notizenlayout konfigurieren.
    NotesCommentsLayoutingOptions notesOptions = new NotesCommentsLayoutingOptions();
    notesOptions.setNotesPosition(NotesPositions.BottomFull);
    PdfOptions pdfOptions = new PdfOptions();
    pdfOptions.setSlidesLayoutOptions(notesOptions);

    // Präsentation als PDF mit Notizen speichern.
    presentation.save("PDF_with_notes.pdf", SaveFormat.Pdf, pdfOptions);
} finally {
    presentation.dispose();
}
```

## **Barrierefreiheit und Compliance‑Standards für PDF**

Aspose.Slides ermöglicht ein Konvertierungsverfahren, das den [Web Content Accessibility Guidelines (**WCAG**)](https://www.w3.org/TR/WCAG-TECHS/pdf.html) entspricht. Sie können ein PowerPoint‑Dokument mit einem dieser Compliance‑Standards nach PDF exportieren: **PDF/A1a**, **PDF/A1b** und **PDF/UA**.

Der folgende Code demonstriert einen PowerPoint‑zu‑PDF‑Konvertierungsprozess, der mehrere PDFs basierend auf unterschiedlichen Compliance‑Standards erzeugt:

```java
Presentation presentation = new Presentation("pres.pptx");
try {
    PdfOptions pdfOptions = new PdfOptions();

    pdfOptions.setCompliance(PdfCompliance.PdfA1a);
    presentation.save("pres-a1a-compliance.pdf", SaveFormat.Pdf, pdfOptions);

    pdfOptions.setCompliance(PdfCompliance.PdfA1b);
    presentation.save("pres-a1b-compliance.pdf", SaveFormat.Pdf, pdfOptions);

    pdfOptions.setCompliance(PdfCompliance.PdfUa);
    presentation.save("pres-ua-compliance.pdf", SaveFormat.Pdf, pdfOptions);
} finally {
    presentation.dispose();
}
```

{{% alert title="Note" color="warning" %}} 
Aspose.Slides unterstützt PDF‑Konvertierungsoperationen, mit denen Sie PDF‑Dateien in gängige Dateiformate konvertieren können. Sie können die Konvertierungen [PDF to HTML](https://products.aspose.com/slides/de/java/conversion/pdf-to-html/), [PDF to image](https://products.aspose.com/slides/de/java/conversion/pdf-to-image/), [PDF to JPG](https://products.aspose.com/slides/de/java/conversion/pdf-to-jpg/) und [PDF to PNG](https://products.aspose.com/slides/de/java/conversion/pdf-to-png/) durchführen. Weitere PDF‑Konvertierungsoperationen zu Spezialformaten – [PDF to SVG](https://products.aspose.com/slides/de/java/conversion/pdf-to-svg/), [PDF to TIFF](https://products.aspose.com/slides/de/java/conversion/pdf-to-tiff/), und [PDF to XML](https://products.aspose.com/slides/de/java/conversion/pdf-to-xml/) – werden ebenfalls unterstützt.
{{% /alert %}}

> **Hinweis:** Beim Exportieren nach PDF/UA behandelt Aspose.Slides komplexe Grafiken wie SmartArt, Diagramme und Formeln als einzelne Figur. Einzelne Pfadelemente werden nicht als separater Inhalt erhalten und können als Artefakte markiert werden; Alternativtext wird nur für die gesamte Figur bereitgestellt.

## **FAQ**

**Kann ich mehrere PowerPoint‑Dateien stapelweise in PDF konvertieren?**

Ja, Aspose.Slides unterstützt die Batch‑Konvertierung mehrerer PPT‑ oder PPTX‑Dateien in PDF. Sie können Ihre Dateien iterativ durchlaufen und den Konvertierungsprozess programmgesteuert anwenden.

**Ist es möglich, das konvertierte PDF mit einem Passwort zu schützen?**

Ja, selbstverständlich. Verwenden Sie die [PdfOptions](https://reference.aspose.com/slides/de/java/com.aspose.slides/pdfoptions/)‑Klasse, um ein Passwort festzulegen und Zugriffsrechte während des Konvertierungsprozesses zu definieren.

**Wie kann ich versteckte Folien in das PDF einbeziehen?**

Verwenden Sie die Methode `setShowHiddenSlides` in der [PdfOptions](https://reference.aspose.com/slides/de/java/com.aspose.slides/pdfoptions/)‑Klasse, um versteckte Folien in das resultierende PDF aufzunehmen.

**Kann Aspose.Slides eine hohe Bildqualität im PDF beibehalten?**

Ja, Sie können die Bildqualität steuern, indem Sie Methoden wie `setJpegQuality` und `setSufficientResolution` in der [PdfOptions](https://reference.aspose.com/slides/de/java/com.aspose.slides/pdfoptions/)‑Klasse verwenden, um hochwertige Bilder in Ihrem PDF zu gewährleisten.

**Unterstützt Aspose.Slides die PDF/A‑Compliance‑Standards?**

Ja, Aspose.Slides ermöglicht den Export von PDFs, die den [verschiedenen Standards](https://reference.aspose.com/slides/de/java/com.aspose.slides/pdfcompliance/) entsprechen, einschließlich PDF/A1a, PDF/A1b und PDF/UA, sodass Ihre Dokumente die Anforderungen an Barrierefreiheit und Archivierung erfüllen.

## **Weitere Ressourcen**

- [Aspose.Slides für Java Dokumentation](/slides/de/java/)
- [Aspose.Slides für Java API‑Referenz](https://reference.aspose.com/slides/de/java/)
- [Aspose kostenlose Online‑Konverter](https://products.aspose.app/slides/de/conversion)