---
title: Konvertieren Sie PPT und PPTX zu PDF auf Android [Erweiterte Funktionen enthalten]
linktitle: PowerPoint zu PDF
type: docs
weight: 40
url: /de/androidjava/convert-powerpoint-to-pdf/
keywords:
- PowerPoint konvertieren
- Präsentation konvertieren
- PowerPoint zu PDF
- Präsentation zu PDF
- PPT zu PDF
- PPT in PDF konvertieren
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
- Android
- Java
- Aspose.Slides
description: "Konvertieren Sie PowerPoint PPT/PPTX in hochwertige, durchsuchbare PDFs in Java mit Aspose.Slides für Android, inklusive schneller Codebeispiele und erweiterten Konvertierungsoptionen."
---
## **Übersicht**

Das Konvertieren von PowerPoint-Präsentationen (PPT, PPTX, ODP usw.) in das PDF-Format unter Android bietet mehrere Vorteile, darunter die Kompatibilität über verschiedene Geräte hinweg und die Bewahrung des Layouts und der Formatierung Ihrer Präsentation. Dieses Handbuch zeigt, wie Sie Präsentationen in PDF-Dokumente konvertieren, verschiedene Optionen zur Steuerung der Bildqualität verwenden, versteckte Folien einbinden, PDF-Dateien mit einem Passwort schützen, Schriftart-Ersetzungen erkennen, bestimmte Folien für die Konvertierung auswählen und Compliance-Standards auf die Ausgabedokumente anwenden.

## **PowerPoint zu PDF-Konvertierungen**

* **PPT**
* **PPTX**
* **ODP**

Um eine Präsentation in PDF zu konvertieren, übergeben Sie den Dateinamen als Argument an die [Presentation](https://reference.aspose.com/slides/de/androidjava/com.aspose.slides/presentation/)‑Klasse und speichern Sie anschließend die Präsentation als PDF mithilfe der `save`‑Methode. Die [Presentation](https://reference.aspose.com/slides/de/androidjava/com.aspose.slides/presentation/)‑Klasse stellt die `save`‑Methode bereit, die typischerweise zum Konvertieren einer Präsentation in PDF verwendet wird.

{{%  alert title="NOTE"  color="warning"   %}} 
Aspose.Slides für Android via Java fügt seine API-Informationen und Versionsnummer in Ausgabedokumente ein. Beispielsweise füllt Aspose.Slides beim Konvertieren einer Präsentation in PDF das Feld Application mit „*Aspose.Slides*“ und das Feld PDF Producer mit einem Wert in der Form „*Aspose.Slides v XX.XX*“. **Hinweis**: Sie können Aspose.Slides nicht anweisen, diese Informationen aus Ausgabedokumenten zu ändern oder zu entfernen.
{{% /alert %}}

Aspose.Slides ermöglicht Ihnen das Konvertieren:

* Gesamte Präsentationen zu PDF
* Bestimmte Folien einer Präsentation zu PDF

Aspose.Slides exportiert Präsentationen nach PDF und stellt sicher, dass die resultierenden PDFs dem Original sehr ähnlich sind. Elemente und Attribute werden in der Konvertierung genau wiedergegeben, einschließlich:

* Bilder
* Textrahmen und Formen
* Textformatierung
* Absatzformatierung
* Hyperlinks
* Kopf- und Fußzeilen
* Aufzählungszeichen
* Tabellen

## **PowerPoint zu PDF konvertieren**

Der Standard-PowerPoint-zu-PDF-Konvertierungsprozess verwendet die Standardoptionen. In diesem Fall versucht Aspose.Slides, die bereitgestellte Präsentation mit optimalen Einstellungen und maximaler Qualität in PDF zu konvertieren.

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
Aspose bietet einen kostenlosen Online-[**PowerPoint-zu-PDF-Konverter**](https://products.aspose.app/slides/de/conversion/ppt-to-pdf) an, der den Präsentation-zu-PDF-Konvertierungsprozess demonstriert. Sie können mit diesem Konverter einen Test durchführen, um die hier beschriebene Vorgehensweise live umzusetzen.
{{% /alert %}}

## **PowerPoint zu PDF mit Optionen konvertieren**

Aspose.Slides stellt benutzerdefinierte Optionen—Eigenschaften der [PdfOptions](https://reference.aspose.com/slides/de/androidjava/com.aspose.slides/pdfoptions/)‑Klasse—zur Verfügung, mit denen Sie das resultierende PDF anpassen, das PDF mit einem Passwort sperren oder festlegen können, wie der Konvertierungsprozess ablaufen soll.

### **PowerPoint zu PDF mit benutzerdefinierten Optionen konvertieren**

Mit benutzerdefinierten Konvertierungsoptionen können Sie Ihre bevorzugte Qualitätseinstellung für Rasterbilder festlegen, bestimmen, wie Metadateien behandelt werden sollen, ein Kompressionsniveau für Text einstellen, die DPI für Bilder konfigurieren und vieles mehr.

```java
import com.aspose.slides.*;

// Instanziieren Sie die PdfOptions-Klasse.
PdfOptions pdfOptions = new PdfOptions();

// Legen Sie die Qualität für JPG-Bilder fest.
pdfOptions.setJpegQuality((byte)90);

// Legen Sie die DPI für Bilder fest.
pdfOptions.setSufficientResolution(300);

/// Legen Sie das Verhalten für Metadateien fest.
pdfOptions.setSaveMetafilesAsPng(true);

// Legen Sie das Komprimierungslevel für Textinhalt fest.
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

Enthält eine Präsentation versteckte Folien, können Sie die Methode [setShowHiddenSlides](https://reference.aspose.com/slides/de/androidjava/com.aspose.slides/pdfoptions/#setShowHiddenSlides-boolean-) der [PdfOptions](https://reference.aspose.com/slides/de/androidjava/com.aspose.slides/pdfoptions/)‑Klasse verwenden, um die versteckten Folien als Seiten in das resultierende PDF einzufügen.

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

Dieser Code zeigt, wie Sie eine PowerPoint-Präsentation mit den Schutzparametern der [PdfOptions](https://reference.aspose.com/slides/de/androidjava/com.aspose.slides/pdfoptions/)‑Klasse in ein passwortgeschütztes PDF konvertieren:

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

### **Schriftarten-Ersetzungen erkennen**

Aspose.Slides stellt die Methode [setWarningCallback](https://reference.aspose.com/slides/de/androidjava/com.aspose.slides/saveoptions/#setWarningCallback-com.aspose.slides.IWarningCallback-) der [PdfOptions](https://reference.aspose.com/slides/de/androidjava/com.aspose.slides/pdfoptions/)‑Klasse bereit, mit der Sie während des Präsentation-zu-PDF-Konvertierungsprozesses Schriftarten-Ersetzungen erkennen können.

Dieser Code zeigt, wie Schriftarten-Ersetzungen erkannt werden:

```java
import com.aspose.slides.*;

public static void main(String[] args) {
    // Instanziieren Sie die Presentation-Klasse, die eine PowerPoint- oder OpenDocument-Datei darstellt.
    Presentation presentation = new Presentation("sample.pptx");

    // Legen Sie den Warnungs-Callback in den PDF-Optionen fest.
    PdfOptions pdfOptions = new PdfOptions();
    pdfOptions.setWarningCallback(new FontSubstitutionHandler());

    // Speichern Sie die Präsentation als PDF.
    presentation.save("output.pdf", SaveFormat.Pdf, pdfOptions);
}

// Implementierung des Warnungs-Callbacks.
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
Weitere Informationen zu Schriftarten-Ersetzungen finden Sie im Artikel [Font Substitution](/slides/de/androidjava/font-substitution/).
{{% /alert %}} 

## **Ausgewählte Folien aus PowerPoint zu PDF konvertieren**

Dieser Code demonstriert, wie Sie nur bestimmte Folien einer PowerPoint-Präsentation in PDF konvertieren:

```java
import com.aspose.slides.*;

// Instanziieren Sie die Presentation-Klasse, die eine PowerPoint- oder OpenDocument-Datei darstellt.
Presentation presentation = new Presentation("PowerPoint.pptx");
try {
    // Array von Foliennummern festlegen.
    int[] slides = { 1, 3 };

    // Speichern Sie die Präsentation als PDF.
    presentation.save("PPTX-to-PDF.pdf", slides, SaveFormat.Pdf);
} finally {
    presentation.dispose();
}
```

## **PowerPoint zu PDF mit benutzerdefinierter Foliengröße konvertieren**

Dieser Code demonstriert, wie Sie eine PowerPoint-Präsentation mit einer angegebenen Foliengröße in PDF konvertieren:

```java
import com.aspose.slides.*;

float slideWidth = 612;
float slideHeight = 792;

// Instanziieren Sie die Presentation-Klasse, die eine PowerPoint- oder OpenDocument-Datei darstellt.
Presentation presentation = new Presentation("SelectedSlides.pptx");

// Create a new presentation with an adjusted slide size.
Presentation resizedPresentation = new Presentation();

try {
    // Benutzerdefinierte Foliengröße festlegen.
    resizedPresentation.getSlideSize().setSize(slideWidth, slideHeight, SlideSizeScaleType.EnsureFit);

    // Klonen Sie die erste Folie aus der Originalpräsentation.
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

## **PowerPoint zu PDF im Notizen-Folien-Ansicht konvertieren**

Dieser Code demonstriert, wie Sie eine PowerPoint-Präsentation in ein PDF konvertieren, das die Notizen enthält:

```java
import com.aspose.slides.*;

// Instanziieren Sie die Presentation-Klasse, die eine PowerPoint- oder OpenDocument-Datei darstellt.
Presentation presentation = new Presentation("SelectedSlides.pptx");
try {
    // PDF-Optionen mit Notizen-Layout konfigurieren.
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

## **Barrierefreiheit und Compliance-Standards für PDF**

Aspose.Slides ermöglicht die Verwendung eines Konvertierungsverfahrens, das den [Web Content Accessibility Guidelines (**WCAG**)](https://www.w3.org/TR/WCAG-TECHS/pdf.html) entspricht. Sie können ein PowerPoint-Dokument in PDF exportieren unter Verwendung eines dieser Compliance-Standards: **PDF/A1a**, **PDF/A1b** und **PDF/UA**.

Dieser Code demonstriert einen PowerPoint-zu-PDF-Konvertierungsprozess, der mehrere PDFs basierend auf verschiedenen Compliance-Standards erzeugt:

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
Aspose.Slides unterstützt PDF-Konvertierungsoperationen, mit denen Sie PDF-Dateien in gängige Dateiformate konvertieren können. Sie können [PDF zu HTML](https://products.aspose.com/slides/de/java/conversion/pdf-to-html/), [PDF zu Bild](https://products.aspose.com/slides/de/java/conversion/pdf-to-image/), [PDF zu JPG](https://products.aspose.com/slides/de/java/conversion/pdf-to-jpg/) und [PDF zu PNG](https://products.aspose.com/slides/de/java/conversion/pdf-to-png/) Konvertierungen durchführen. Weitere PDF-Konvertierungsoperationen zu speziellen Formaten—[PDF zu SVG](https://products.aspose.com/slides/de/java/conversion/pdf-to-svg/), [PDF zu TIFF](https://products.aspose.com/slides/de/java/conversion/pdf-to-tiff/), und [PDF zu XML](https://products.aspose.com/slides/de/java/conversion/pdf-to-xml/)—werden ebenfalls unterstützt.
{{% /alert %}}

> **Hinweis:** Beim Exportieren zu PDF/UA behandelt Aspose.Slides komplexe Grafiken wie SmartArt, Diagramme und Formeln als eine einzelne Figur. Einzelne Pfadelemente werden nicht als separater Inhalt erhalten und können als Artefakte gekennzeichnet werden; alternativer Text wird nur für die gesamte Figur bereitgestellt.

## **FAQ**

### Kann ich mehrere PowerPoint-Dateien stapelweise in PDF konvertieren?

Ja, Aspose.Slides unterstützt die Batch-Konvertierung mehrerer PPT‑ oder PPTX‑Dateien zu PDF. Sie können Ihre Dateien iterativ durchlaufen und den Konvertierungsprozess programmgesteuert anwenden.

### Ist es möglich, das konvertierte PDF mit einem Passwort zu schützen?

Absolut. Verwenden Sie die [PdfOptions](https://reference.aspose.com/slides/de/androidjava/com.aspose.slides/pdfoptions/)‑Klasse, um ein Passwort festzulegen und Zugriffsrechte während des Konvertierungsprozesses zu definieren.

### Wie binde ich versteckte Folien in das PDF ein?

Verwenden Sie die Methode `setShowHiddenSlides` in der [PdfOptions](https://reference.aspose.com/slides/de/androidjava/com.aspose.slides/pdfoptions/)‑Klasse, um versteckte Folien in das resultierende PDF einzufügen.

### Kann Aspose.Slides eine hohe Bildqualität im PDF beibehalten?

Ja, Sie können die Bildqualität steuern, indem Sie Methoden wie `setJpegQuality` und `setSufficientResolution` in der [PdfOptions](https://reference.aspose.com/slides/de/androidjava/com.aspose.slides/pdfoptions/)‑Klasse verwenden, um hochqualitative Bilder in Ihrem PDF sicherzustellen.

### Unterstützt Aspose.Slides die PDF/A‑Compliance‑Standards?

Ja, Aspose.Slides ermöglicht den Export von PDFs, die verschiedenen Standards entsprechen, einschließlich PDF/A1a, PDF/A1b und PDF/UA, sodass Ihre Dokumente den Anforderungen an Barrierefreiheit und Archivierung genügen.

## **Additional Resources**

- [Aspose.Slides for Android via Java Documentation](/slides/de/androidjava/)
- [Aspose.Slides for Android via Java API Reference](https://reference.aspose.com/slides/de/androidjava/)
- [Aspose Free Online Converters](https://products.aspose.app/slides/de/conversion)