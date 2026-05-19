---
title: PPT und PPTX auf Android in PDF konvertieren [Erweiterte Funktionen enthalten]
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
- Android
- Java
- Aspose.Slides
description: "PowerPoint PPT/PPTX in hochwertige, durchsuchbare PDFs in Java mit Aspose.Slides für Android konvertieren, mit schnellen Codebeispielen und erweiterten Konvertierungsoptionen."
---
## **Übersicht**

Das Konvertieren von PowerPoint‑Präsentationen (PPT, PPTX, ODP usw.) in das PDF‑Format unter Android bietet mehrere Vorteile, darunter Kompatibilität über verschiedene Geräte hinweg und das Bewahren von Layout und Formatierung Ihrer Präsentation. Dieser Leitfaden zeigt, wie Sie Präsentationen in PDF‑Dokumente konvertieren, verschiedene Optionen zur Steuerung der Bildqualität nutzen, versteckte Folien einbeziehen, PDF‑Dateien mit einem Passwort schützen, Font‑Ersetzungen erkennen, bestimmte Folien für die Konvertierung auswählen und Compliance‑Standards auf Ausgabedokumente anwenden.

## **PowerPoint‑zu‑PDF‑Konvertierungen**

Mit Aspose.Slides können Sie Präsentationen in den folgenden Formaten in PDF konvertieren:

* **PPT**
* **PPTX**
* **ODP**

Um eine Präsentation in PDF zu konvertieren, übergeben Sie den Dateinamen als Argument an die [Presentation](https://reference.aspose.com/slides/de/androidjava/com.aspose.slides/presentation/)‑Klasse und speichern Sie die Präsentation anschließend mit einer `save`‑Methode als PDF. Die [Presentation](https://reference.aspose.com/slides/de/androidjava/com.aspose.slides/presentation/)‑Klasse stellt die `save`‑Methode bereit, die typischerweise zur Konvertierung einer Präsentation in PDF verwendet wird.

{{%  alert title="NOTE"  color="warning"   %}} 

Aspose.Slides for Android via Java fügt seine API‑Informationen und Versionsnummer in Ausgabedokumente ein. Beispielsweise wird beim Konvertieren einer Präsentation in PDF das Anwendungsfeld mit "*Aspose.Slides*" und das PDF‑Producer‑Feld mit einem Wert in der Form "*Aspose.Slides v XX.XX*" befüllt. **Hinweis:** Sie können Aspose.Slides nicht anweisen, diese Informationen aus Ausgabedokumenten zu entfernen oder zu ändern.

{{% /alert %}}

Aspose.Slides ermöglicht das Konvertieren von:

* gesamten Präsentationen in PDF
* bestimmten Folien einer Präsentation in PDF

Aspose.Slides exportiert Präsentationen nach PDF und stellt sicher, dass die resultierenden PDFs den Originalpräsentationen sehr nahe kommen. Elemente und Attribute werden in der Konvertierung exakt wiedergegeben, darunter:

* Bilder
* Textfelder und Formen
* Textformatierung
* Absatzformatierung
* Hyperlinks
* Kopf‑ und Fußzeilen
* Aufzählungszeichen
* Tabellen

## **PowerPoint in PDF konvertieren**

Der Standard‑PowerPoint‑zu‑PDF‑Konvertierungsprozess verwendet die Standardeinstellungen. In diesem Fall versucht Aspose.Slides, die bereitgestellte Präsentation mit optimalen Einstellungen und maximaler Qualität in PDF zu konvertieren.

Der folgende Code zeigt, wie Sie eine Präsentation (PPT, PPTX, ODP usw.) in PDF konvertieren:

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

Aspose bietet einen kostenlosen Online‑[**PowerPoint‑zu‑PDF‑Konverter**](https://products.aspose.app/slides/de/conversion/ppt-to-pdf), der den Präsentation‑zu‑PDF‑Konvertierungsprozess demonstriert. Sie können mit diesem Konverter einen Testlauf für die hier beschriebene Vorgehensweise durchführen.

{{% /alert %}}

## **PowerPoint in PDF mit Optionen konvertieren**

Aspose.Slides stellt benutzerdefinierte Optionen – Eigenschaften der [PdfOptions](https://reference.aspose.com/slides/de/androidjava/com.aspose.slides/pdfoptions/)‑Klasse – zur Verfügung, mit denen Sie das resultierende PDF anpassen, mit einem Passwort schützen oder das Vorgehen der Konvertierung festlegen können.

### **PowerPoint in PDF mit benutzerdefinierten Optionen konvertieren**

Mit benutzerdefinierten Konvertierungsoptionen können Sie Ihre bevorzugte Qualitätsstufe für Rasterbilder festlegen, bestimmen, wie Metadateien behandelt werden, ein Komprimierungsniveau für Text setzen, DPI für Bilder konfigurieren und mehr.

Das nachstehende Codebeispiel demonstriert, wie Sie eine PowerPoint‑Präsentation mit mehreren benutzerdefinierten Optionen in PDF konvertieren:

```java
// Instanziieren Sie die PdfOptions-Klasse.
PdfOptions pdfOptions = new PdfOptions();

// Legen Sie die Qualität für JPG-Bilder fest.
pdfOptions.setJpegQuality((byte)90);

// Legen Sie die DPI für Bilder fest.
pdfOptions.setSufficientResolution(300);

/// Legen Sie das Verhalten für Metadateien fest.
pdfOptions.setSaveMetafilesAsPng(true);

// Legen Sie die Textkomprimierungsstufe für Textinhalt fest.
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

### **PowerPoint in PDF mit versteckten Folien konvertieren**

Enthält eine Präsentation versteckte Folien, können Sie die Methode [setShowHiddenSlides](https://reference.aspose.com/slides/de/androidjava/com.aspose.slides/pdfoptions/#setShowHiddenSlides-boolean-) der [PdfOptions](https://reference.aspose.com/slides/de/androidjava/com.aspose.slides/pdfoptions/)‑Klasse verwenden, um die versteckten Folien als Seiten in das resultierende PDF einzubeziehen.

Der folgende Code zeigt, wie Sie eine PowerPoint‑Präsentation mit eingeschlossenen versteckten Folien in PDF konvertieren:

```java
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

### **PowerPoint in passwortgeschütztes PDF konvertieren**

Dieser Code demonstriert, wie Sie eine PowerPoint‑Präsentation mit den Schutzparametern der [PdfOptions](https://reference.aspose.com/slides/de/androidjava/com.aspose.slides/pdfoptions/)‑Klasse in ein passwortgeschütztes PDF konvertieren:

```java
// Instanziieren Sie die Presentation-Klasse, die eine PowerPoint- oder OpenDocument-Datei darstellt.
Presentation presentation = new Presentation("PowerPoint.pptx");
try {
    // Instanziieren Sie die PdfOptions-Klasse.
    PdfOptions pdfOptions = new PdfOptions();

    // Setze ein PDF-Passwort und Zugriffsrechte.
    pdfOptions.setPassword("password");
    pdfOptions.setAccessPermissions(PdfAccessPermissions.PrintDocument | PdfAccessPermissions.HighQualityPrint);

    // Speichern Sie die Präsentation als PDF.
    presentation.save("PPTX-to-PDF.pdf", SaveFormat.Pdf, pdfOptions);
} finally {
    presentation.dispose();
}
```

### **Font‑Ersetzungen erkennen**

Aspose.Slides bietet die Methode [setWarningCallback](https://reference.aspose.com/slides/de/androidjava/com.aspose.slides/saveoptions/#setWarningCallback-com.aspose.slides.IWarningCallback-) unter der [PdfOptions](https://reference.aspose.com/slides/de/androidjava/com.aspose.slides/pdfoptions/)‑Klasse, mit der Sie Font‑Ersetzungen während des Präsentation‑zu‑PDF‑Konvertierungsprozesses erkennen können.

Der folgende Code zeigt, wie Font‑Ersetzungen erkannt werden:

```java
public static void main(String[] args) {
    // Instanziieren Sie die Presentation-Klasse, die eine PowerPoint- oder OpenDocument-Datei darstellt.
    Presentation presentation = new Presentation("sample.pptx");

    // Setzen Sie den Warncallback in den PDF-Optionen.
    PdfOptions pdfOptions = new PdfOptions();
    pdfOptions.setWarningCallback(new FontSubstitutionHandler());

    // Speichern Sie die Präsentation als PDF.
    presentation.save("output.pdf", SaveFormat.Pdf, pdfOptions);
}

// Implementierung des Warncallbacks.
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

Weitere Informationen zu Font‑Ersetzungen finden Sie im Artikel [Font Substitution](/slides/de/androidjava/font-substitution/).

{{% /alert %}} 

## **Ausgewählte Folien einer PowerPoint‑Präsentation in PDF konvertieren**

Dieser Code demonstriert, wie Sie nur bestimmte Folien einer PowerPoint‑Präsentation in PDF konvertieren:

```java
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

## **PowerPoint in PDF mit benutzerdefinierter Foliengröße konvertieren**

Dieser Code demonstriert, wie Sie eine PowerPoint‑Präsentation mit einer angegebenen Foliengröße in PDF konvertieren:

```java
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

    // Speichern Sie die verkleinerte Präsentation als PDF mit Notizen.
    resizedPresentation.save("PDF_with_notes.pdf", SaveFormat.Pdf);
} finally {
    resizedPresentation.dispose();
    presentation.dispose();
}
```

## **PowerPoint in PDF im Notiz‑Folien‑Modus konvertieren**

Dieser Code demonstriert, wie Sie eine PowerPoint‑Präsentation in ein PDF konvertieren, das die Notizen enthält:

```java
// Instanziieren Sie die Presentation-Klasse, die eine PowerPoint- oder OpenDocument-Datei darstellt.
Presentation presentation = new Presentation("SelectedSlides.pptx");
try {
    // Konfigurieren Sie die PDF-Optionen mit Notizenlayout.
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

Aspose.Slides erlaubt ein Konvertierungsverfahren, das den [Web Content Accessibility Guidelines (**WCAG**)](https://www.w3.org/TR/WCAG-TECHS/pdf.html) entspricht. Sie können ein PowerPoint‑Dokument nach PDF exportieren und dabei einen der folgenden Compliance‑Standards verwenden: **PDF/A1a**, **PDF/A1b** und **PDF/UA**.

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

Aspose.Slides unterstützt PDF‑Konvertierungs‑Operationen, mit denen Sie PDF‑Dateien in gängige Formate umwandeln können. Sie können [PDF zu HTML](https://products.aspose.com/slides/de/java/conversion/pdf-to-html/), [PDF zu Bild](https://products.aspose.com/slides/de/java/conversion/pdf-to-image/), [PDF zu JPG](https://products.aspose.com/slides/de/java/conversion/pdf-to-jpg/) und [PDF zu PNG](https://products.aspose.com/slides/de/java/conversion/pdf-to-png/) Konvertierungen durchführen. Weitere PDF‑Konvertierungen in spezialisierte Formate – [PDF zu SVG](https://products.aspose.com/slides/de/java/conversion/pdf-to-svg/), [PDF zu TIFF](https://products.aspose.com/slides/de/java/conversion/pdf-to-tiff/) und [PDF zu XML](https://products.aspose.com/slides/de/java/conversion/pdf-to-xml/) – werden ebenfalls unterstützt.

{{% /alert %}}

> **Hinweis:** Beim Exportieren nach PDF/UA behandelt Aspose.Slides komplexe Grafiken wie SmartArt, Diagramme und Formeln als einzelne Figur. Einzelne Pfadelemente werden nicht als separater Inhalt erhalten und können als Artefakte gekennzeichnet werden; alternativer Text wird nur für die gesamte Figur bereitgestellt.

## **FAQ**

**Kann ich mehrere PowerPoint‑Dateien in einem Durchgang in PDF konvertieren?**

Ja, Aspose.Slides unterstützt die Stapelkonvertierung mehrerer PPT‑ oder PPTX‑Dateien nach PDF. Sie können Ihre Dateien iterativ durchlaufen und den Konvertierungsprozess programmgesteuert anwenden.

**Ist es möglich, das konvertierte PDF mit einem Passwort zu schützen?**

Absolut. Verwenden Sie die [PdfOptions](https://reference.aspose.com/slides/de/androidjava/com.aspose.slides/pdfoptions/)‑Klasse, um während des Konvertierungsvorgangs ein Passwort und Zugriffsrechte festzulegen.

**Wie binde ich versteckte Folien in das PDF ein?**

Verwenden Sie die Methode `setShowHiddenSlides` in der [PdfOptions](https://reference.aspose.com/slides/de/androidjava/com.aspose.slides/pdfoptions/)‑Klasse, um versteckte Folien in das resultierende PDF zu übernehmen.

**Kann Aspose.Slides eine hohe Bildqualität im PDF gewährleisten?**

Ja, Sie können die Bildqualität steuern, indem Sie Methoden wie `setJpegQuality` und `setSufficientResolution` der [PdfOptions](https://reference.aspose.com/slides/de/androidjava/com.aspose.slides/pdfoptions/)‑Klasse verwenden, um hochqualitative Bilder in Ihrem PDF sicherzustellen.

**Unterstützt Aspose.Slides die PDF/A‑Compliance‑Standards?**

Ja, Aspose.Slides ermöglicht den Export von PDFs, die den verschiedenen Standards entsprechen, darunter PDF/A1a, PDF/A1b und PDF/UA, sodass Ihre Dokumente sowohl barrierefrei als auch archivierungstauglich sind.

## **Weitere Ressourcen**

- [Aspose.Slides für Android via Java Dokumentation](/slides/de/androidjava/)
- [Aspose.Slides für Android via Java API‑Referenz](https://reference.aspose.com/slides/de/androidjava/)
- [Aspose Kostenlose Online‑Konverter](https://products.aspose.app/slides/de/conversion)