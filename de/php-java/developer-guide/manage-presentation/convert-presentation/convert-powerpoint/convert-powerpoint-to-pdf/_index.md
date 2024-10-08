---
title: PowerPoint in PDF umwandeln
linktitle: PowerPoint in PDF umwandeln
type: docs
weight: 40
url: /de/php-java/powerpoint-in-pdf-umwandeln/
keywords: "PowerPoint umwandeln, Präsentation, PowerPoint in PDF, PPT in PDF, PPTX in PDF, PowerPoint als PDF speichern, PDF/A1a, PDF/A1b, PDF/UA, Java"
description: "PowerPoint-Präsentation in PDF umwandeln. Speichern Sie PowerPoint als PDF unter Einhaltung von Standards für Compliance oder Barrierefreiheit."

---
## **Übersicht**

Dieser Artikel erklärt, wie Sie PowerPoint-Dateiformate mit PHP in PDF umwandeln können. Es werden eine Vielzahl von Themen behandelt, z.B.

- PPT in PDF umwandeln
- PPTX in PDF umwandeln
- ODP in PDF umwandeln
- PowerPoint in PDF umwandeln

## **Java PowerPoint in PDF-Konvertierungen**

Mit Aspose.Slides können Sie Präsentationen in diesen Formaten in PDF umwandeln:

* PPT
* PPTX
* ODP

Um eine Präsentation in PDF umzuwandeln, müssen Sie einfach den Dateinamen als Argument in der [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/Presentation) Klasse übergeben und dann die Präsentation als PDF mit der [Save](https://reference.aspose.com/slides/php-java/aspose.slides/Presentation#save-java.lang.String-int-) Methode speichern. Die [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/Presentation) Klasse stellt die [Save](https://reference.aspose.com/slides/php-java/aspose.slides/Presentation#save-java.lang.String-int-) Methode zur Verfügung, die typischerweise verwendet wird, um eine Präsentation in PDF umzuwandeln.

{{%  alert title="HINWEIS"  color="warning"   %}} 

Aspose.Slides für PHP via Java schreibt direkt API-Informationen und Versionsnummern in die Ausgabedokumente. Zum Beispiel, wenn es eine Präsentation in PDF umwandelt, füllt Aspose.Slides für PHP via Java das Anwendungsfeld mit dem Wert '*Aspose.Slides*' und das PDF-Producer-Feld mit einem Wert in der Form '*Aspose.Slides v XX.XX*'. **Hinweis**: Sie können Aspose.Slides für PHP via Java nicht anweisen, diese Informationen aus den Ausgabedokumenten zu ändern oder zu entfernen.

{{% /alert %}}

Aspose.Slides ermöglicht es Ihnen, Folgendes zu konvertieren:

* eine gesamte Präsentation in PDF
* spezifische Folien in einer Präsentation in PDF
* eine Präsentation 

Aspose.Slides exportiert Präsentationen in PDF auf eine Weise, die den Inhalt der resultierenden PDFs sehr ähnlich zu denen in den ursprünglichen Präsentationen macht. Diese bekannten Elemente und Attribute werden oft korrekt bei der Konvertierung von Präsentationen in PDF gerendert:

* Bilder
* Textfelder und andere Formen
* Texte und deren Formatierung
* Absätze und deren Formatierung
* Hyperlinks
* Kopf- und Fußzeilen
* Aufzählungen
* Tabellen

## **PowerPoint in PDF umwandeln**

Die Standardoperation zur PDF-Konvertierung von PowerPoint wird mit den Standardoptionen ausgeführt. In diesem Fall versucht Aspose.Slides, die bereitgestellte Präsentation mit optimalen Einstellungen und maximaler Qualität in PDF umzuwandeln.

Dieser PHP-Code zeigt Ihnen, wie Sie eine PowerPoint in PDF umwandeln:

```php
  # Instanziiert eine Presentation-Klasse, die eine PowerPoint-Datei darstellt
  $pres = new Presentation("PowerPoint.ppt");
  try {
    # Speichert die Präsentation als PDF
    $pres->save("PPT-to-PDF.pdf", SaveFormat::Pdf);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

{{%  alert  color="primary"  %}} 

Aspose bietet einen kostenlosen Online-[**PowerPoint zu PDF Konverter**](https://products.aspose.app/slides/conversion/ppt-to-pdf), der den Prozess der Präsentation in PDF-Konvertierung demonstriert. Für eine Live-Implementierung des hier beschriebenen Verfahrens können Sie einen Test mit dem Konverter durchführen.

{{% /alert %}}

## **PowerPoint in PDF mit Optionen umwandeln**

Aspose.Slides bietet benutzerdefinierte Optionen - Eigenschaften unter der [PdfOptions](https://reference.aspose.com/slides/php-java/aspose.slides/PdfOptions) Klasse - die es Ihnen ermöglichen, die PDF (die aus dem Umwandlungsprozess resultiert) anzupassen, die PDF mit einem Passwort zu schützen oder sogar anzugeben, wie der Umwandlungsprozess verlaufen soll.

### **PowerPoint in PDF mit benutzerdefinierten Optionen umwandeln**

Mit benutzerdefinierten Umwandlungsoptionen können Sie Ihre bevorzugte Qualitätsstufe für JPG-Bilder festlegen, angeben, wie Metadateien behandelt werden sollen, einen Komprimierungsgrad für Texte festlegen usw.

Dieser PHP-Code demonstriert eine Operation, in der eine PowerPoint mit mehreren benutzerdefinierten Optionen in PDF umgewandelt wird:

```php
// Instanziiert eine Presentation-Klasse, die eine PowerPoint-Datei darstellt
  $pres = new Presentation("PowerPoint.pptx");
  try {
    # Instanziiert die PdfOptions-Klasse
    $pdfOptions = new PdfOptions();
    # Setzt die Jpeg-Qualität
    $pdfOptions->setJpegQuality(90);
    # Setzt das Verhalten für Metadateien
    $pdfOptions->setSaveMetafilesAsPng(true);
    # Setzt den Komprimierungsgrad für Texte
    $pdfOptions->setTextCompression(PdfTextCompression::Flate);
    # Definiert den PDF-Standard
    $pdfOptions->setCompliance(PdfCompliance::Pdf15);
    # Speichert die Präsentation als PDF
    $pres->save("PowerPoint-to-PDF.pdf", SaveFormat::Pdf, $pdfOptions);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

### **PowerPoint in PDF mit versteckten Folien umwandeln**

Wenn eine Präsentation versteckte Folien enthält, können Sie eine benutzerdefinierte Option - die [ShowHiddenSlides](https://reference.aspose.com/slides/php-java/aspose.slides/IPdfOptions#getShowHiddenSlides--) Eigenschaft aus der [PdfOptions](https://reference.aspose.com/slides/php-java/aspose.slides/PdfOptions) Klasse - verwenden, um Aspose.Slides anzuweisen, die versteckten Folien als Seiten in die resultierende PDF aufzunehmen.

Dieser PHP-Code zeigt Ihnen, wie Sie eine PowerPoint-Präsentation in PDF umwandeln, wobei versteckte Folien einbezogen werden:

```php
// Instanziiert eine Presentation-Klasse, die eine PowerPoint-Datei darstellt
  $pres = new Presentation("PowerPoint.pptx");
  try {
    # Instanziiert die PdfOptions-Klasse
    $pdfOptions = new PdfOptions();
    # Fügt versteckte Folien hinzu
    $pdfOptions->setShowHiddenSlides(true);
    # Speichert die Präsentation als PDF
    $pres->save("PowerPoint-to-PDF.pdf", SaveFormat::Pdf, $pdfOptions);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

### **PowerPoint in passwortgeschütztes PDF umwandeln**

Dieser PHP-Code zeigt Ihnen, wie Sie eine PowerPoint in ein passwortgeschütztes PDF umwandeln (unter Verwendung von Schutzeinstellungen aus der [PdfOptions](https://reference.aspose.com/slides/php-java/aspose.slides/PdfOptions) Klasse):

```php
// Instanziiert ein Presentation-Objekt, das eine PowerPoint-Datei darstellt
  $pres = new Presentation("PowerPoint.pptx");
  try {
    # / Instanziiert die PdfOptions-Klasse
    $pdfOptions = new PdfOptions();
    # Setzt PDF-Passwort und Zugriffsrechte
    $pdfOptions->setPassword("password");
    $pdfOptions->setAccessPermissions(PdfAccessPermissions::PrintDocument | PdfAccessPermissions::HighQualityPrint);
    # Speichert die Präsentation als PDF
    $pres->save("PPTX-to-PDF.pdf", SaveFormat::Pdf, $pdfOptions);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

### **Schriftartenersetzungen erkennen**

Aspose.Slides bietet die [getWarningCallback](https://reference.aspose.com/slides/php-java/aspose.slides/saveoptions/#getWarningCallback--) Methode unter der [SaveOptions](https://reference.aspose.com/slides/php-java/aspose.slides/saveoptions/) Klasse, um Ihnen zu erlauben, Schriftartenersetzungen im Prozess der Präsentation in PDF-Konvertierung zu erkennen.

Dieser PHP-Code zeigt Ihnen, wie Sie Schriftartenersetzungen erkennen:

```php

class FontSubstSendsWarningCallback {
    function warning($warning)
    {
          if (java_values($warning->getWarningType() == WarningType::CompatibilityIssue)) {
            return ReturnAction::Continue;
          }
          if (java_values($warning->getWarningType() == WarningType::DataLoss && $warning->getDescription()->startsWith("Font will be substituted"))) {
            echo ("Schriftartenersetzungswarnung: " . $warning->getDescription());
          }
          return ReturnAction::Continue;
    }
}

  $loadOptions = new LoadOptions();
  $warningCallback = java_closure(new FontSubstSendsWarningCallback(), null, java("com.aspose.slides.IWarningCallback"));
  $loadOptions->setWarningCallback($warningCallback);
  $pres = new Presentation("pres.pptx", $loadOptions);
  try {
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

{{%  alert color="primary"  %}} 

Für weitere Informationen zum Erhalten von Rückrufen für Schriftartenersetzungen in einem Rendering-Prozess siehe [Erhalten von Warnungen für Schriftartenersetzungen](https://docs.aspose.com/slides/php-java/getting-warning-callbacks-for-fonts-substitution-in-aspose-slides/).

Für weitere Informationen zur Schriftartenersetzung siehe den Artikel [Schriftartenersetzung](https://docs.aspose.com/slides/php-java/font-substitution/).

{{% /alert %}} 

## **Ausgewählte Folien in PowerPoint in PDF umwandeln**

Dieser PHP-Code zeigt Ihnen, wie Sie spezifische Folien in einer PowerPoint-Präsentation in PDF umwandeln:

```php
// Instanziiert ein Presentation-Objekt, das eine PowerPoint-Datei darstellt
  $pres = new Presentation("PowerPoint.pptx");
  try {
    # Setzt ein Array von Folienpositionen
    $slides = array(1, 3 );
    # Speichert die Präsentation als PDF
    $pres->save("PPTX-to-PDF.pdf", $slides, SaveFormat::Pdf);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

## **PowerPoint in PDF mit benutzerdefinierten Foliengrößen umwandeln**

Dieser PHP-Code zeigt Ihnen, wie Sie eine PowerPoint umwandeln, wenn ihre Foliengröße auf ein PDF angegeben ist:

```php
// Instanziiert ein Presentation-Objekt, das eine PowerPoint-Datei darstellt 
  $pres = new Presentation("SelectedSlides.pptx");
  try {
    $outPres = new Presentation();
    try {
      $slide = $pres->getSlides()->get_Item(0);
      $outPres->getSlides()->insertClone(0, $slide);
      # Setzt den Folientyp und die Größe
      $outPres->getSlideSize()->setSize(612.0, 792.0, SlideSizeScaleType::EnsureFit);
      $pdfOptions = new PdfOptions();
      $options = $pdfOptions->getNotesCommentsLayouting();
      $options->setNotesPosition(NotesPositions::BottomFull);
      $outPres->save("PDFnotes_out.pdf", SaveFormat::Pdf, $pdfOptions);
    } finally {
      if (!java_is_null($pres)) {
        $pres->dispose();
      }
    }
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

## **PowerPoint in PDF im Notizfolienansicht umwandeln**

Dieser PHP-Code zeigt Ihnen, wie Sie eine PowerPoint in PDF-Notizen umwandeln:

```php
// Instanziiert eine Presentation-Klasse, die eine PowerPoint-Datei darstellt
  $pres = new Presentation("SelectedSlides.pptx");
  try {
    $pdfOptions = new PdfOptions();
    $options = $pdfOptions->getNotesCommentsLayouting();
    $options->setNotesPosition(NotesPositions::BottomFull);
    $pres->save("Pdf_With_Notes.pdf", SaveFormat::Pdf, $pdfOptions);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

## **Barrierefreiheits- und Compliance-Standards für PDF**

Aspose.Slides ermöglicht es Ihnen, ein Umwandlungsverfahren zu verwenden, das den [Richtlinien für die Barrierefreiheit von Webinhalten (**WCAG**)](https://www.w3.org/TR/WCAG-TECHS/pdf.html) entspricht. Sie können ein PowerPoint-Dokument in PDF unter Verwendung eines dieser Compliance-Standards exportieren: **PDF/A1a**, **PDF/A1b** und **PDF/UA**.

Dieser PHP-Code demonstriert eine PowerPoint in PDF-Konvertierungsoperation, in der mehrere PDFs auf der Grundlage verschiedener Compliance-Standards erstellt werden:

```php
  $pres = new Presentation("pres.pptx");
  try {
    $pdfOptions = new PdfOptions();
    $pdfOptions->setCompliance(PdfCompliance::PdfA1a);
    $pres->save("pres-a1a-compliance.pdf", SaveFormat::Pdf, $pdfOptions);
    $pdfOptions->setCompliance(PdfCompliance::PdfA1b);
    $pres->save("pres-a1b-compliance.pdf", SaveFormat::Pdf, $pdfOptions);
    $pdfOptions->setCompliance(PdfCompliance::PdfUa);
    $pres->save("pres-ua-compliance.pdf", SaveFormat::Pdf, $pdfOptions);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

{{% alert title="Hinweis" color="warning" %}} 

Die Unterstützung von Aspose.Slides für PDF-Konvertierungsoperationen erstreckt sich auch darauf, dass Sie PDF in die gängigsten Dateiformate umwandeln können. Sie können [PDF in HTML](https://products.aspose.com/slides/php-java/conversion/pdf-to-html/), [PDF in Bild](https://products.aspose.com/slides/php-java/conversion/pdf-to-image/), [PDF in JPG](https://products.aspose.com/slides/php-java/conversion/pdf-to-jpg/) und [PDF in PNG](https://products.aspose.com/slides/php-java/conversion/pdf-to-png/) Konvertierungen durchführen. Andere PDF-Konvertierungsoperationen in spezialisierte Formate - [PDF in SVG](https://products.aspose.com/slides/php-java/conversion/pdf-to-svg/), [PDF in TIFF](https://products.aspose.com/slides/php-java/conversion/pdf-to-tiff/) und [PDF in XML](https://products.aspose.com/slides/php-java/conversion/pdf-to-xml/) - werden ebenfalls unterstützt.

{{% /alert %}}