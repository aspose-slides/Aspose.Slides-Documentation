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
- PPT in PDF konvertieren
- PPTX zu PDF
- PPTX in PDF konvertieren
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
description: "Konvertieren Sie PowerPoint PPT/PPTX in hochwertige, durchsuchbare PDFs in Java mit Aspose.Slides, einschließlich schneller Codebeispiele und erweiterter Konvertierungsoptionen."
---
## **Übersicht**

Das Konvertieren von PowerPoint-Präsentationen (PPT, PPTX, ODP usw.) in das PDF-Format in Java bietet mehrere Vorteile, darunter die Kompatibilität über verschiedene Geräte hinweg und die Bewahrung des Layouts und der Formatierung Ihrer Präsentation. Dieser Leitfaden zeigt, wie Sie Präsentationen in PDF-Dokumente konvertieren, verschiedene Optionen zur Steuerung der Bildqualität verwenden, versteckte Folien einbinden, PDF-Dateien mit einem Passwort schützen, Schriftartersetzungen erkennen, bestimmte Folien für die Konvertierung auswählen und Compliance-Standards auf Ausgabedokumente anwenden.

## **PowerPoint-zu-PDF-Konvertierungen**

Mit Aspose.Slides können Sie Präsentationen in den folgenden Formaten in PDF konvertieren:

* **PPT**
* **PPTX**
* **ODP**

Um eine Präsentation in PDF zu konvertieren, übergeben Sie den Dateinamen als Argument an die [Presentation](https://reference.aspose.com/slides/de/java/com.aspose.slides/presentation/)‑Klasse und speichern Sie die Präsentation anschließend mit einer `save`‑Methode als PDF. Die [Presentation](https://reference.aspose.com/slides/de/java/com.aspose.slides/presentation/)‑Klasse stellt die `save`‑Methode bereit, die typischerweise zum Konvertieren einer Präsentation in PDF verwendet wird.

{{%  alert title="NOTE"  color="warning"   %}} 
Aspose.Slides für Java fügt seine API‑Informationen und Versionsnummer in Ausgabedokumente ein. Beispielweise füllt Aspose.Slides beim Konvertieren einer Präsentation zu PDF das Anwendungsfeld mit „*Aspose.Slides*“ und das PDF‑Producer‑Feld mit einem Wert in der Form „*Aspose.Slides v XX.XX*“. **Hinweis**: Sie können Aspose.Slides nicht anweisen, diese Informationen aus Ausgabedokumenten zu ändern oder zu entfernen.
{{% /alert %}}

Aspose.Slides ermöglicht Ihnen die Konvertierung:

* Gesamte Präsentationen zu PDF
* Bestimmte Folien einer Präsentation zu PDF

Aspose.Slides exportiert Präsentationen nach PDF und stellt sicher, dass die resultierenden PDFs dem Original sehr nahekommen. Elemente und Attribute werden bei der Konvertierung genau wiedergegeben, einschließlich:

* Bilder
* Textfelder und Formen
* Textformatierung
* Absatzformatierung
* Hyperlinks
* Kopf‑ und Fußzeilen
* Aufzählungszeichen
* Tabellen

## **PowerPoint zu PDF konvertieren**

Der Standard‑PowerPoint‑zu‑PDF‑Konvertierungsprozess verwendet Standardoptionen. In diesem Fall versucht Aspose.Slides, die bereitgestellte Präsentation mit optimalen Einstellungen und höchster Qualitätsstufe in PDF zu konvertieren.

Dieser Code zeigt, wie Sie eine Präsentation (PPT, PPTX, ODP usw.) in PDF konvertieren:

```java
import com.aspose.slides.*;

// Instanziieren Sie die Presentation-Klasse, die eine PowerPoint- oder OpenDocument-Datei darstellt.
Presentation presentation = new Presentation("PowerPoint.ppt");
try {
    // Speichern Sie die Präsentation als PDF.
    presentation.save("PPT-to-PDF.pdf", SaveFormat.Pdf);
} finally {
    presentation.dispose();
}
```

{{%  alert  color="info"  %}} 
Aspose bietet einen kostenlosen Online‑[**PowerPoint‑zu‑PDF‑Konverter**](https://products.aspose.app/slides/de/conversion/ppt-to-pdf) an, der den Präsentation‑zu‑PDF‑Konvertierungsprozess demonstriert. Sie können mit diesem Konverter einen Test durchführen, um die hier beschriebene Vorgehensweise live zu sehen.
{{% /alert %}}

## **PowerPoint zu PDF mit Optionen konvertieren**

Aspose.Slides stellt benutzerdefinierte Optionen – Eigenschaften der Klasse [PdfOptions](https://reference.aspose.com/slides/de/java/com.aspose.slides/pdfoptions/) – zur Verfügung, mit denen Sie das resultierende PDF anpassen, das PDF mit einem Passwort schützen oder festlegen können, wie der Konvertierungsprozess ablaufen soll.

### **PowerPoint zu PDF mit benutzerdefinierten Optionen konvertieren**

Mit benutzerdefinierten Konvertierungsoptionen können Sie die bevorzugte Qualitätseinstellung für Rasterbilder festlegen, bestimmen, wie Metadateien behandelt werden sollen, ein Komprimierungslevel für Text festlegen, DPI für Bilder konfigurieren und mehr.

Das folgende Codebeispiel zeigt, wie Sie eine PowerPoint‑Präsentation mit mehreren benutzerdefinierten Optionen in PDF konvertieren.

```java
import com.aspose.slides.*;

// Instanziieren Sie die PdfOptions-Klasse.
PdfOptions pdfOptions = new PdfOptions();

// Legen Sie die Qualität für JPG-Bilder fest.
pdfOptions.setJpegQuality((byte)90);

// Stellen Sie die DPI für Bilder ein.
pdfOptions.setSufficientResolution(300);

// Legen Sie das Verhalten für Metadateien fest.
pdfOptions.setSaveMetafilesAsPng(true);

// Legen Sie das Textkomprimierungslevel für Textinhalte fest.
pdfOptions.setTextCompression(PdfTextCompression.Flate);

// Definieren Sie den PDF-Compliance-Modus.
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

### **PowerPoint zu PDF mit versteckten Folien konvertieren**

Enthält eine Präsentation versteckte Folien, können Sie die Methode [setShowHiddenSlides](https://reference.aspose.com/slides/de/java/com.aspose.slides/pdfoptions/#setShowHiddenSlides-boolean-) der Klasse [PdfOptions](https://reference.aspose.com/slides/de/java/com.aspose.slides/pdfoptions/) verwenden, um die versteckten Folien als Seiten in das resultierende PDF aufzunehmen.

Dieser Code zeigt, wie Sie eine PowerPoint‑Präsentation mit eingebundenen versteckten Folien in PDF konvertieren:

```java
import com.aspose.slides.*;

// Instanziieren Sie die Presentation-Klasse, die eine PowerPoint- oder OpenDocument-Datei darstellt.
Presentation presentation = new Presentation("PowerPoint.pptx");
try {
    // Instanziieren Sie die PdfOptions-Klasse.
    PdfOptions pdfOptions = new PdfOptions();

    // Versteckte Folien hinzufügen.
    pdfOptions.setShowHiddenSlides(true);

    // Speichern Sie die Präsentation als PDF.
    presentation.save("PowerPoint-to-PDF.pdf", SaveFormat.Pdf, pdfOptions);
} finally {
    presentation.dispose();
}
```

### **PowerPoint zu passwortgeschütztem PDF konvertieren**

Dieser Code demonstriert, wie Sie eine PowerPoint‑Präsentation mit den Schutzparametern der Klasse [PdfOptions](https://reference.aspose.com/slides/de/java/com.aspose.slides/pdfoptions/) in ein passwortgeschütztes PDF konvertieren:

```java
import com.aspose.slides.*;

// Instanziieren Sie die Presentation-Klasse, die eine PowerPoint- oder OpenDocument-Datei darstellt.
Presentation presentation = new Presentation("PowerPoint.pptx");
try {
    // Instanziieren Sie die PdfOptions-Klasse.
    PdfOptions pdfOptions = new PdfOptions();

    // Legen Sie ein PDF-Passwort und Zugriffsberechtigungen fest.
    pdfOptions.setPassword("password");
    pdfOptions.setAccessPermissions(PdfAccessPermissions.PrintDocument | PdfAccessPermissions.HighQualityPrint);

    // Speichern Sie die Präsentation als PDF.
    presentation.save("PPTX-to-PDF.pdf", SaveFormat.Pdf, pdfOptions);
} finally {
    presentation.dispose();
}
```

### **Schriftart‑Ersetzungen erkennen**

Aspose.Slides stellt die Methode [setWarningCallback](https://reference.aspose.com/slides/de/java/com.aspose.slides/saveoptions/#setWarningCallback-com.aspose.slides.IWarningCallback-) unter der Klasse [PdfOptions](https://reference.aspose.com/slides/de/java/com.aspose.slides/pdfoptions/) bereit, mit der Sie Schriftart‑Ersetzungen während des Präsentation‑zu‑PDF‑Konvertierungsprozesses erkennen können.

Dieser Code zeigt, wie Sie Schriftart‑Ersetzungen erkennen:

```java
import com.aspose.slides.*;

public static void main(String[] args) {
    // Instanziieren Sie die Presentation-Klasse, die eine PowerPoint- oder OpenDocument-Datei darstellt.
    Presentation presentation = new Presentation("sample.pptx");

    // Legen Sie den Warn-Callback in den PDF-Optionen fest.
    PdfOptions pdfOptions = new PdfOptions();
    pdfOptions.setWarningCallback(new FontSubstitutionHandler());

    try {
        // Speichern Sie die Präsentation als PDF.
        presentation.save("output.pdf", SaveFormat.Pdf, pdfOptions);
    } finally {
        presentation.dispose();
    }
}

// Implementierung des Warn-Callbacks.
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

{{%  alert color="info"  %}} 
Weitere Informationen zum Empfangen von Rückrufen für Schriftart‑Ersetzungen während des Rendering‑Prozesses finden Sie unter [Getting Warning Callbacks for Fonts Substitution](/slides/de/java/getting-warning-callbacks-for-fonts-substitution-in-aspose-slides/).

Weitere Informationen zu Schriftart‑Ersetzungen finden Sie im Artikel [Font Substitution](/slides/de/java/font-substitution/).
{{% /alert %}} 

## **Ausgewählte Folien in PowerPoint zu PDF konvertieren**

Dieser Code demonstriert, wie Sie nur bestimmte Folien einer PowerPoint‑Präsentation in PDF konvertieren:

```java
import com.aspose.slides.*;

// Instanziieren Sie die Presentation-Klasse, die eine PowerPoint- oder OpenDocument-Datei darstellt.
Presentation presentation = new Presentation("PowerPoint.pptx");
try {
    // Legen Sie ein Array von Foliennummern fest.
    int[] slides = { 1, 3 };

    // Speichern Sie die Präsentation als PDF.
    presentation.save("PPTX-to-PDF.pdf", slides, SaveFormat.Pdf);
} finally {
    presentation.dispose();
}
```

## **PowerPoint zu PDF mit benutzerdefinierter Foliengröße konvertieren**

Dieser Code demonstriert, wie Sie eine PowerPoint‑Präsentation mit einer angegebenen Foliengröße in PDF konvertieren:

```java
import com.aspose.slides.*;

float slideWidth = 612;
float slideHeight = 792;

// Instanziieren Sie die Presentation-Klasse, die eine PowerPoint- oder OpenDocument-Datei darstellt.
Presentation presentation = new Presentation("SelectedSlides.pptx");

// Erstellen Sie eine neue Präsentation mit angepasster Foliengröße.
Presentation resizedPresentation = new Presentation();

try {
    // Legen Sie die benutzerdefinierte Foliengröße fest.
    resizedPresentation.getSlideSize().setSize(slideWidth, slideHeight, SlideSizeScaleType.EnsureFit);
    
    // Klonen Sie die erste Folie aus der ursprünglichen Präsentation.
    ISlide slide = presentation.getSlides().get_Item(0);
    resizedPresentation.getSlides().insertClone(0, slide);

    // Entfernen Sie die leere Folie, mit der die neue Präsentation erstellt wurde.
    resizedPresentation.getSlides().removeAt(1);

    // Speichern Sie die skalierte Präsentation als PDF.
    resizedPresentation.save("PDF_with_custom_slide_size.pdf", SaveFormat.Pdf);
} finally {
    resizedPresentation.dispose();
    presentation.dispose();
}
```

## **PowerPoint zu PDF im Notizen‑Folien‑Modus konvertieren**

Dieser Code demonstriert, wie Sie eine PowerPoint‑Präsentation in ein PDF konvertieren, das Notizen enthält:

```java
import com.aspose.slides.*;

// Instanziieren Sie die Presentation‑Klasse, die eine PowerPoint‑ oder OpenDocument‑Datei darstellt.
Presentation presentation = new Presentation("SelectedSlides.pptx");
try {
    // Konfigurieren Sie die PDF‑Optionen mit Notizen‑Layout.
    NotesCommentsLayoutingOptions notesOptions = new NotesCommentsLayoutingOptions();
    notesOptions.setNotesPosition(NotesPositions.BottomFull);
    PdfOptions pdfOptions = new PdfOptions();
    pdfOptions.setSlidesLayoutOptions(notesOptions);

    // Speichern Sie die Präsentation als PDF mit Notizen.
    presentation.save("PDF_with_notes.pdf", SaveFormat.Pdf, pdfOptions);
} finally {
    presentation.dispose();
}
```

## **Barrierefreiheit und Compliance‑Standards für PDF**

Aspose.Slides ermöglicht Ihnen ein Konvertierungsverfahren, das den [Web Content Accessibility Guidelines (**WCAG**)](https://www.w3.org/TR/WCAG-TECHS/pdf.html) entspricht. Sie können ein PowerPoint‑Dokument in PDF exportieren und dabei einen dieser Compliance‑Standards verwenden: **PDF/A1a**, **PDF/A1b** und **PDF/UA**.

Dieser Code demonstriert einen PowerPoint‑zu‑PDF‑Konvertierungsprozess, der mehrere PDFs basierend auf unterschiedlichen Compliance‑Standards erzeugt:

```java
import com.aspose.slides.*;

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
Aspose.Slides unterstützt PDF‑Konvertierungsvorgänge, sodass Sie PDF‑Dateien in gängige Dateiformate konvertieren können. Sie können Konvertierungen zu [PDF to HTML](https://products.aspose.com/slides/de/java/conversion/pdf-to-html/), [PDF to image](https://products.aspose.com/slides/de/java/conversion/pdf-to-image/), [PDF to JPG](https://products.aspose.com/slides/de/java/conversion/pdf-to-jpg/) und [PDF to PNG](https://products.aspose.com/slides/de/java/conversion/pdf-to-png/) durchführen. Weitere PDF‑Konvertierungen in spezialisierte Formate – [PDF to SVG](https://products.aspose.com/slides/de/java/conversion/pdf-to-svg/), [PDF to TIFF](https://products.aspose.com/slides/de/java/conversion/pdf-to-tiff/) und [PDF to XML](https://products.aspose.com/slides/de/java/conversion/pdf-to-xml/) – werden ebenfalls unterstützt.
{{% /alert %}}

> **Hinweis:** Beim Exportieren nach PDF/UA behandelt Aspose.Slides komplexe Grafiken wie SmartArt, Diagramme und Formeln als eine einzelne Figur. Einzelne Pfadelemente werden nicht als separater Inhalt erhalten und können als Artefakte markiert werden; alternativer Text wird nur für die gesamte Figur bereitgestellt.

## **FAQ**

### Kann ich mehrere PowerPoint‑Dateien gleichzeitig in PDF konvertieren?

Ja, Aspose.Slides unterstützt die Stapelkonvertierung mehrerer PPT‑ oder PPTX‑Dateien in PDF. Sie können Ihre Dateien iterieren und den Konvertierungsprozess programmgesteuert anwenden.

### Ist es möglich, das konvertierte PDF mit einem Passwort zu schützen?

Auf jeden Fall. Verwenden Sie die Klasse [PdfOptions](https://reference.aspose.com/slides/de/java/com.aspose.slides/pdfoptions/), um ein Passwort festzulegen und Zugriffsrechte während des Konvertierungsprozesses zu definieren.

### Wie füge ich versteckte Folien in das PDF ein?

Verwenden Sie die Methode `setShowHiddenSlides` in der Klasse [PdfOptions](https://reference.aspose.com/slides/de/java/com.aspose.slides/pdfoptions/), um versteckte Folien in das resultierende PDF aufzunehmen.

### Kann Aspose.Slides eine hohe Bildqualität im PDF beibehalten?

Ja, Sie können die Bildqualität steuern, indem Sie Methoden wie `setJpegQuality` und `setSufficientResolution` in der Klasse [PdfOptions](https://reference.aspose.com/slides/de/java/com.aspose.slides/pdfoptions/) verwenden, um hochwertige Bilder in Ihrem PDF zu gewährleisten.

### Unterstützt Aspose.Slides PDF/A‑Compliance‑Standards?

Ja, Aspose.Slides ermöglicht den Export von PDFs, die den [verschiedenen Standards](https://reference.aspose.com/slides/de/java/com.aspose.slides/pdfcompliance/) entsprechen, darunter PDF/A1a, PDF/A1b und PDF/UA, sodass Ihre Dokumente die Anforderungen an Barrierefreiheit und Archivierung erfüllen.

## **Zusätzliche Ressourcen**

- [Aspose.Slides für Java Dokumentation](/slides/de/java/)
- [Aspose.Slides für Java API‑Referenz](https://reference.aspose.com/slides/de/java/)
- [Aspose Kostenlose Online‑Konverter](https://products.aspose.app/slides/de/conversion)