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
description: "PowerPoint PPT/PPTX in hochwertige, durchsuchbare PDFs in Java mit Aspose.Slides konvertieren, mit schnellen Codebeispielen und erweiterten Konvertierungsoptionen."
---

## **Übersicht**

Das Konvertieren von PowerPoint‑Präsentationen (PPT, PPTX, ODP usw.) in das PDF‑Format in Java bietet mehrere Vorteile, darunter Kompatibilität auf verschiedenen Geräten und die Erhaltung des Layouts und der Formatierung Ihrer Präsentation. Dieses Handbuch zeigt, wie Präsentationen in PDF‑Dokumente konvertiert werden, wie verschiedene Optionen zur Steuerung der Bildqualität verwendet werden, versteckte Folien einbezogen werden, PDF‑Dateien mit Passwort geschützt werden, Schriftart‑Ersetzungen erkannt werden, bestimmte Folien für die Konvertierung ausgewählt werden und Konformitätsstandards auf Ausgabedokumente angewendet werden.

## **PowerPoint‑zu‑PDF‑Konvertierungen**

Mit Aspose.Slides können Sie Präsentationen in den folgenden Formaten in PDF konvertieren:

* **PPT**
* **PPTX**
* **ODP**

Um eine Präsentation in PDF zu konvertieren, übergeben Sie den Dateinamen als Argument an die Klasse [Presentation](https://reference.aspose.com/slides/java/com.aspose.slides/presentation/) und speichern Sie die Präsentation anschließend als PDF mit einer `save`‑Methode. Die Klasse [Presentation](https://reference.aspose.com/slides/java/com.aspose.slides/presentation/) stellt die `save`‑Methode bereit, die typischerweise zum Konvertieren einer Präsentation in PDF verwendet wird.

{{%  alert title="HINWEIS"  color="warning"   %}} 

Aspose.Slides for Java fügt seinen API‑Informationen und die Versionsnummer in Ausgabedokumente ein. Beispielsweise füllt Aspose.Slides beim Konvertieren einer Präsentation in PDF das Anwendungsfeld mit "*Aspose.Slides*" und das PDF‑Producer‑Feld mit einem Wert in der Form "*Aspose.Slides v XX.XX*". **Hinweis**, dass Sie Aspose.Slides nicht anweisen können, diese Informationen aus Ausgabedokumenten zu ändern oder zu entfernen.

{{% /alert %}}

Aspose.Slides ermöglicht Ihnen die Konvertierung von:

* Gesamte Präsentationen zu PDF
* Bestimmte Folien einer Präsentation zu PDF

Aspose.Slides exportiert Präsentationen zu PDF und sorgt dafür, dass die resultierenden PDFs dem Original sehr nahekommen. Elemente und Attribute werden bei der Konvertierung genau wiedergegeben, einschließlich:

* Bilder
* Textfelder und Formen
* Textformatierung
* Absatzformatierung
* Hyperlinks
* Kopf‑ und Fußzeilen
* Aufzählungszeichen
* Tabellen

## **PowerPoint zu PDF konvertieren**

Der Standard‑PowerPoint‑zu‑PDF‑Konvertierungsprozess verwendet Standardoptionen. In diesem Fall versucht Aspose.Slides, die bereitgestellte Präsentation mit optimalen Einstellungen bei maximaler Qualität in PDF zu konvertieren.

Dieses Beispiel zeigt, wie eine Präsentation (PPT, PPTX, ODP usw.) in PDF konvertiert wird:
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

Aspose bietet einen kostenlosen Online‑**PowerPoint to PDF converter**(https://products.aspose.app/slides/conversion/ppt-to-pdf), der den Präsentation‑zu‑PDF‑Konvertierungsprozess demonstriert. Sie können mit diesem Konverter einen Test durchführen, um die hier beschriebene Vorgehensweise live zu sehen.

{{% /alert %}}

## **PowerPoint zu PDF mit Optionen konvertieren**

Aspose.Slides stellt benutzerdefinierte Optionen – Eigenschaften der Klasse [PdfOptions](https://reference.aspose.com/slides/java/com.aspose.slides/pdfoptions/) – bereit, mit denen Sie das resultierende PDF anpassen, mit einem Passwort schützen oder das Vorgehen des Konvertierungsprozesses festlegen können.

### **PowerPoint zu PDF mit benutzerdefinierten Optionen konvertieren**

Mit benutzerdefinierten Konvertierungsoptionen können Sie Ihre bevorzugte Qualitätseinstellung für Rasterbilder festlegen, bestimmen, wie Metadateien behandelt werden, eine Komprimierungsstufe für Text setzen, die DPI für Bilder konfigurieren und vieles mehr.

```java
// Instanziieren Sie die PdfOptions-Klasse.
PdfOptions pdfOptions = new PdfOptions();

// Legen Sie die Qualität für JPG-Bilder fest.
pdfOptions.setJpegQuality((byte)90);

// DPI für Bilder festlegen.
pdfOptions.setSufficientResolution(300);

// Verhalten für Metafiles festlegen.
pdfOptions.setSaveMetafilesAsPng(true);

// Textkomprimierungsgrad für Textinhalte festlegen.
pdfOptions.setTextCompression(PdfTextCompression.Flate);

// PDF-Konformitätsmodus definieren.
pdfOptions.setCompliance(PdfCompliance.Pdf15);

// Instanziieren Sie die Presentation-Klasse, die eine PowerPoint- oder OpenDocument-Datei darstellt.
Presentation presentation = new Presentation("PowerPoint.pptx");

try {
    // Präsentation als PDF-Dokument speichern.
    presentation.save("PowerPoint-to-PDF.pdf", SaveFormat.Pdf, pdfOptions);
} finally {
    presentation.dispose();
}
```


### **PowerPoint zu PDF mit versteckten Folien konvertieren**

Enthält eine Präsentation versteckte Folien, können Sie die Methode [setShowHiddenSlides](https://reference.aspose.com/slides/java/com.aspose.slides/pdfoptions/#setShowHiddenSlides-boolean-) der Klasse [PdfOptions](https://reference.aspose.com/slides/java/com.aspose.slides/pdfoptions/) verwenden, um die versteckten Folien als Seiten in das resultierende PDF aufzunehmen.

```java
// Instanziieren Sie die Presentation-Klasse, die eine PowerPoint- oder OpenDocument-Datei darstellt.
Presentation presentation = new Presentation("PowerPoint.pptx");
try {
    // Instanziieren Sie die PdfOptions-Klasse.
    PdfOptions pdfOptions = new PdfOptions();

    // Versteckte Folien hinzufügen.
    pdfOptions.setShowHiddenSlides(true);

    // Präsentation als PDF speichern.
    presentation.save("PowerPoint-to-PDF.pdf", SaveFormat.Pdf, pdfOptions);
} finally {
    presentation.dispose();
}
```


### **PowerPoint zu passwortgeschütztem PDF konvertieren**

Dieses Beispiel zeigt, wie eine PowerPoint‑Präsentation mit Hilfe der Schutzparameter der Klasse [PdfOptions](https://reference.aspose.com/slides/java/com.aspose.slides/pdfoptions/) in ein passwortgeschütztes PDF konvertiert wird:
```java
// Instanziieren Sie die Presentation-Klasse, die eine PowerPoint- oder OpenDocument-Datei darstellt.
Presentation presentation = new Presentation("PowerPoint.pptx");
try {
    // Instanziieren Sie die PdfOptions-Klasse.
    PdfOptions pdfOptions = new PdfOptions();

    // Legen Sie ein PDF-Passwort und Zugriffsberechtigungen fest.
    pdfOptions.setPassword("password");
    pdfOptions.setAccessPermissions(PdfAccessPermissions.PrintDocument | PdfAccessPermissions.HighQualityPrint);

    // Präsentation als PDF speichern.
    presentation.save("PPTX-to-PDF.pdf", SaveFormat.Pdf, pdfOptions);
} finally {
    presentation.dispose();
}
```


### **Schriftart‑Ersetzungen erkennen**

Aspose.Slides stellt die Methode [setWarningCallback](https://reference.aspose.com/slides/java/com.aspose.slides/saveoptions/#setWarningCallback-com.aspose.slides.IWarningCallback-) unter der Klasse [PdfOptions](https://reference.aspose.com/slides/java/com.aspose.slides/pdfoptions/) bereit, mit der Sie während des Präsentation‑zu‑PDF‑Konvertierungsprozesses Schriftart‑Ersetzungen erkennen können.

```java
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


{{%  alert color="primary"  %}} 

Weitere Informationen zum Empfangen von Rückrufen für Schriftart‑Ersetzungen während des Rendering‑Vorgangs finden Sie unter [Getting Warning Callbacks for Fonts Substitution](/slides/de/java/getting-warning-callbacks-for-fonts-substitution-in-aspose-slides/).

Weitere Informationen zu Schriftart‑Ersetzungen finden Sie im Artikel [Font Substitution](/slides/de/java/font-substitution/).

{{% /alert %}} 

## **Ausgewählte Folien in PowerPoint zu PDF konvertieren**

Dieses Beispiel zeigt, wie nur bestimmte Folien einer PowerPoint‑Präsentation zu PDF konvertiert werden:
```java
// Instanziieren Sie die Presentation-Klasse, die eine PowerPoint- oder OpenDocument-Datei darstellt.
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


## **PowerPoint zu PDF mit benutzerdefinierter Foliengröße konvertieren**

Dieses Beispiel zeigt, wie eine PowerPoint‑Präsentation zu PDF mit einer angegebenen Foliengröße konvertiert wird:
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

    // Speichern Sie die skalierte Präsentation als PDF mit Notizen.
    resizedPresentation.save("PDF_with_notes.pdf", SaveFormat.Pdf);
} finally {
    resizedPresentation.dispose();
    presentation.dispose();
}
```


## **PowerPoint zu PDF im Notizen‑Folien‑Modus konvertieren**

Dieses Beispiel zeigt, wie eine PowerPoint‑Präsentation zu einem PDF konvertiert wird, das Notizen enthält:
```java
// Instanziieren Sie die Presentation-Klasse, die eine PowerPoint- oder OpenDocument-Datei darstellt.
Presentation presentation = new Presentation("SelectedSlides.pptx");
try {
    // PDF-Optionen mit Notizenlayout konfigurieren.
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


## **Barrierefreiheit‑ und Konformitätsstandards für PDF**

Aspose.Slides ermöglicht ein Konvertierungsverfahren, das den [Web Content Accessibility Guidelines (**WCAG**)](https://www.w3.org/TR/WCAG-TECHS/pdf.html) entspricht. Sie können ein PowerPoint‑Dokument zu PDF exportieren, das einen der folgenden Konformitätsstandards erfüllt: **PDF/A1a**, **PDF/A1b** und **PDF/UA**.

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


{{% alert title="Hinweis" color="warning" %}} 

Aspose.Slides unterstützt PDF‑Konvertierungsoperationen, mit denen Sie PDF‑Dateien in gängige Formate konvertieren können. Sie können [PDF to HTML](https://products.aspose.com/slides/java/conversion/pdf-to-html/), [PDF to image](https://products.aspose.com/slides/java/conversion/pdf-to-image/), [PDF to JPG](https://products.aspose.com/slides/java/conversion/pdf-to-jpg/) und [PDF to PNG](https://products.aspose.com/slides/java/conversion/pdf-to-png/) Konvertierungen durchführen. Weitere PDF‑Konvertierungen in spezialisierte Formate – [PDF to SVG](https://products.aspose.com/slides/java/conversion/pdf-to-svg/), [PDF to TIFF](https://products.aspose.com/slides/java/conversion/pdf-to-tiff/) und [PDF to XML](https://products.aspose.com/slides/java/conversion/pdf-to-xml/) – werden ebenfalls unterstützt.

{{% /alert %}}

## **Häufig gestellte Fragen**

1. **Kann ich mehrere PowerPoint‑Dateien gleichzeitig in PDF konvertieren?**  
   Ja, Aspose.Slides unterstützt die Batch‑Konvertierung mehrerer PPT‑ oder PPTX‑Dateien zu PDF. Sie können Ihre Dateien iterativ durchgehen und den Konvertierungsprozess programmgesteuert anwenden.

2. **Ist es möglich, das konvertierte PDF mit einem Passwort zu schützen?**  
   Absolut. Verwenden Sie die Klasse [PdfOptions](https://reference.aspose.com/slides/java/com.aspose.slides/pdfoptions/), um ein Passwort festzulegen und Zugriffsrechte während des Konvertierungsprozesses zu definieren.

3. **Wie kann ich versteckte Folien in das PDF einbeziehen?**  
   Nutzen Sie die Methode `setShowHiddenSlides` der Klasse [PdfOptions](https://reference.aspose.com/slides/java/com.aspose.slides/pdfoptions/), um versteckte Folien in das resultierende PDF aufzunehmen.

4. **Kann Aspose.Slides eine hohe Bildqualität im PDF beibehalten?**  
   Ja, Sie können die Bildqualität mit Methoden wie `setJpegQuality` und `setSufficientResolution` der Klasse [PdfOptions](https://reference.aspose.com/slides/java/com.aspose.slides/pdfoptions/) steuern, um hochwertige Bilder im PDF sicherzustellen.

5. **Unterstützt Aspose.Slides die PDF/A‑Konformitätsstandards?**  
   Ja, Aspose.Slides erlaubt den Export von PDFs, die verschiedenen Standards entsprechen, einschließlich PDF/A1a, PDF/A1b und PDF/UA, sodass Ihre Dokumente den Anforderungen an Barrierefreiheit und Archivierung genügen.

## **Zusätzliche Ressourcen**

- [Aspose.Slides für Java Dokumentation](/slides/de/java/)
- [Aspose.Slides für Java API-Referenz](https://reference.aspose.com/slides/java/)
- [Aspose kostenlose Online‑Konverter](https://products.aspose.app/slides/conversion)