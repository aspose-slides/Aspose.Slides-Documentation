---
title: PPT und PPTX in PDF in PHP konvertieren [Erweiterte Funktionen enthalten]
linktitle: PowerPoint zu PDF
type: docs
weight: 40
url: /de/php-java/convert-powerpoint-to-pdf/
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
- PHP
- Aspose.Slides
description: "PowerPoint PPT/PPTX in PHP mit Aspose.Slides in hochwertige, durchsuchbare PDFs konvertieren, inkl. schneller Codebeispiele und erweiterten Konvertierungsoptionen."
---

## **Übersicht**

Das Konvertieren von PowerPoint-Präsentationen (PPT, PPTX, ODP usw.) in das PDF-Format mit PHP bietet mehrere Vorteile, darunter die Kompatibilität über verschiedene Geräte hinweg und die Erhaltung des Layouts und der Formatierung Ihrer Präsentation. Dieser Leitfaden zeigt, wie man Präsentationen in PDF-Dokumente umwandelt, verschiedene Optionen zur Steuerung der Bildqualität nutzt, ausgeblendete Folien einschließt, PDF-Dateien mit einem Passwort schützt, Schriftartersetzungen erkennt, bestimmte Folien für die Konvertierung auswählt und Compliance-Standards auf Ausgabedokumente anwendet.

## **PowerPoint-zu-PDF-Konvertierungen**

Um Präsentationen in die folgenden Formate in PDF zu konvertieren, können Sie Aspose.Slides verwenden:

* **PPT**
* **PPTX**
* **ODP**

Um eine Präsentation in PDF zu konvertieren, übergeben Sie den Dateinamen als Argument an die [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/Presentation)-Klasse und speichern Sie die Präsentation anschließend mit einer `save`‑Methode als PDF. Die [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/Presentation)-Klasse stellt die `save`‑Methode bereit, die typischerweise zum Konvertieren einer Präsentation in PDF verwendet wird.

{{%  alert title="NOTE"  color="warning"   %}} 

Aspose.Slides für PHP via Java fügt seine API-Informationen und Versionsnummer in Ausgabedokumente ein. Beispielsweise füllt Aspose.Slides beim Konvertieren einer Präsentation in PDF das Feld Application mit "*Aspose.Slides*" und das Feld PDF Producer mit einem Wert im Format "*Aspose.Slides v XX.XX*". **Hinweis**: Sie können Aspose.Slides nicht anweisen, diese Informationen aus den Ausgabedokumenten zu ändern oder zu entfernen.

{{% /alert %}}

Aspose.Slides ermöglicht:

* Gesamte Präsentationen in PDF
* Bestimmte Folien einer Präsentation in PDF

Aspose.Slides exportiert Präsentationen nach PDF und sorgt dafür, dass die resultierenden PDFs den Originalpräsentationen eng entsprechen. Elemente und Attribute werden bei der Konvertierung genau wiedergegeben, einschließlich:

* Bilder
* Textfelder und Formen
* Textformatierung
* Absatzformatierung
* Hyperlinks
* Kopf- und Fußzeilen
* Aufzählungszeichen
* Tabellen

## **PowerPoint in PDF konvertieren**

Der standardmäßige PowerPoint-zu-PDF-Konvertierungsprozess verwendet Standardoptionen. In diesem Fall versucht Aspose.Slides, die bereitgestellte Präsentation mit optimalen Einstellungen und maximaler Qualität in PDF zu konvertieren.

```php
# Instanziieren Sie die Presentation-Klasse, die eine PowerPoint- oder OpenDocument-Datei darstellt.
$presentation = new Presentation("PowerPoint.pptx");
try {
    # Speichern Sie die Präsentation als PDF.
    $presentation->save("PPT-to-PDF.pdf", SaveFormat::Pdf);
} finally {
    $presentation->dispose();
}
```


{{%  alert  color="primary"  %}} 

Aspose bietet einen kostenlosen Online-**PowerPoint-zu-PDF-Konverter**(https://products.aspose.app/slides/conversion/ppt-to-pdf), der den Präsentation-zu-PDF-Konvertierungsprozess demonstriert. Sie können mit diesem Konverter einen Test durchführen, um die hier beschriebene Vorgehensweise live zu sehen.

{{% /alert %}}

## **PowerPoint in PDF mit Optionen konvertieren**

Aspose.Slides bietet benutzerdefinierte Optionen – Eigenschaften der Klasse [PdfOptions](https://reference.aspose.com/slides/php-java/aspose.slides/PdfOptions) – die es Ihnen ermöglichen, das resultierende PDF anzupassen, das PDF mit einem Passwort zu schützen oder festzulegen, wie der Konvertierungsprozess ablaufen soll.

### **PowerPoint in PDF mit benutzerdefinierten Optionen konvertieren**

Mit benutzerdefinierten Konvertierungsoptionen können Sie Ihre bevorzugte Qualitätseinstellung für Rasterbilder festlegen, bestimmen, wie Metadateien behandelt werden, ein Komprimierungsniveau für Text festlegen, DPI für Bilder konfigurieren und mehr.

```php
# Instanziieren Sie die PdfOptions-Klasse.
$pdfOptions = new PdfOptions();

# Setzen Sie die Qualität für JPG-Bilder.
$pdfOptions->setJpegQuality(90);

# Setzen Sie die DPI für Bilder.
$pdfOptions->setSufficientResolution(300);

# Setzen Sie das Verhalten für Metadateien.
$pdfOptions->setSaveMetafilesAsPng(true);

# Setzen Sie den Textkomprimierungsgrad für Textinhalte.
$pdfOptions->setTextCompression(PdfTextCompression::Flate);

# Definieren Sie den PDF-Konformitätsmodus.
$pdfOptions->setCompliance(PdfCompliance::Pdf15);

# Instanziieren Sie die Presentation-Klasse, die eine PowerPoint- oder OpenDocument-Datei darstellt.
$presentation = new Presentation("PowerPoint.pptx");
try {
    # Speichern Sie die Präsentation als PDF-Dokument.
    $presentation->save("PowerPoint-to-PDF.pdf", SaveFormat::Pdf, $pdfOptions);
} finally {
    $presentation->dispose();
}
```


### **PowerPoint in PDF mit ausgeblendeten Folien konvertieren**

Enthält eine Präsentation ausgeblendete Folien, können Sie die Methode [setShowHiddenSlides](https://reference.aspose.com/slides/php-java/aspose.slides/pdfoptions/#setShowHiddenSlides) aus der Klasse [PdfOptions](https://reference.aspose.com/slides/php-java/aspose.slides/PdfOptions) verwenden, um die ausgeblendeten Folien als Seiten in das resultierende PDF einzufügen.

```php
# Instanziieren Sie die Presentation-Klasse, die eine PowerPoint- oder OpenDocument-Datei darstellt.
$presentation = new Presentation("PowerPoint.pptx");
try {
    # Instanziieren Sie die PdfOptions-Klasse.
    $pdfOptions = new PdfOptions();

    # Versteckte Folien hinzufügen.
    $pdfOptions->setShowHiddenSlides(true);

    # Speichern Sie die Präsentation als PDF.
    $presentation->save("PowerPoint-to-PDF.pdf", SaveFormat::Pdf, $pdfOptions);
} finally {
    $presentation->dispose();
}
```


### **PowerPoint in passwortgeschütztes PDF konvertieren**

Dieser Code zeigt, wie man eine PowerPoint-Präsentation mit den Schutzparametern der Klasse [PdfOptions](https://reference.aspose.com/slides/php-java/aspose.slides/pdfoptions/) in ein passwortgeschütztes PDF konvertiert:

```php
# Instanziieren Sie die Presentation‑Klasse, die eine PowerPoint‑ oder OpenDocument‑Datei darstellt.
$presentation = new Presentation("PowerPoint.pptx");
try {
    # Instanziieren Sie die PdfOptions‑Klasse.
    $pdfOptions = new PdfOptions();

    # Setzen Sie ein PDF‑Passwort und Zugriffsberechtigungen.
    $pdfOptions->setPassword("password");
    $pdfOptions->setAccessPermissions(PdfAccessPermissions::PrintDocument | PdfAccessPermissions::HighQualityPrint);

    # Speichern Sie die Präsentation als PDF.
    $presentation->save("PPTX-to-PDF.pdf", SaveFormat::Pdf, $pdfOptions);
} finally {
    $presentation->dispose();
}
```


### **Schriftartersetzungen erkennen**

Aspose.Slides stellt die Methode [setWarningCallback](https://reference.aspose.com/slides/php-java/aspose.slides/saveoptions/#setWarningCallback) in der Klasse [PdfOptions](https://reference.aspose.com/slides/php-java/aspose.slides/pdfoptions/) bereit, die es Ihnen ermöglicht, während des Präsentation-zu-PDF-Konvertierungsprozesses Schriftartersetzungen zu erkennen.

Dieser Code zeigt, wie Schriftartersetzungen erkannt werden:

```php
class FontSubstitutionHandler {
    function warning($warning)
    {
        if (java_values($warning->getWarningType()) == WarningType::DataLoss &&
        $warning->getDescription()->startsWith("Font will be substituted")) {
            echo("Font substitution warning: " . $warning->getDescription());
        }

        return ReturnAction::Continue;
    }
}

// Festlegen des Warnungs-Callbacks in den PDF-Optionen.
$pdfOptions = new PdfOptions();
$warningCallback = java_closure(new FontSubstitutionHandler(), null, java("com.aspose.slides.IWarningCallback"));
$pdfOptions->setWarningCallback($warningCallback);

// Instanziieren Sie die Presentation-Klasse, die eine PowerPoint- oder OpenDocument-Datei darstellt.
$presentation = new Presentation("sample.pptx");
try {
    // Speichern Sie die Präsentation als PDF.
    $presentation->save("output.pdf", SaveFormat::Pdf, $pdfOptions);
} finally {
    $presentation->dispose();
}
```


{{%  alert color="primary"  %}} 

Weitere Informationen zum Empfangen von Callbacks für Schriftartersetzungen während des Renderings finden Sie unter [Getting Warning Callbacks for Fonts Substitution](/slides/de/php-java/getting-warning-callbacks-for-fonts-substitution-in-aspose-slides/).

Weitere Informationen zur Schriftartersetzung finden Sie im Artikel [Font Substitution](/slides/de/php-java/font-substitution/).

{{% /alert %}} 

## **Ausgewählte Folien in PowerPoint in PDF konvertieren**

Dieser Code zeigt, wie nur bestimmte Folien einer PowerPoint-Präsentation in PDF konvertiert werden:

```php
# Instanziieren Sie die Presentation-Klasse, die eine PowerPoint- oder OpenDocument-Datei darstellt.
$presentation = new Presentation("PowerPoint.pptx");
try {
    # Array von Foliennummern festlegen.
    $slides = array(1, 3);

    # Präsentation als PDF speichern.
    $presentation->save("PPTX-to-PDF.pdf", $slides, SaveFormat::Pdf);
} finally {
    $presentation->dispose();
}
```


## **PowerPoint in PDF mit benutzerdefinierter Foliengröße konvertieren**

Dieser Code zeigt, wie eine PowerPoint-Präsentation mit einer angegebenen Foliengröße in PDF konvertiert wird:

```php
$slideWidth = 612.0;
$slideHeight = 792.0;

# Instanziieren Sie die Presentation-Klasse, die eine PowerPoint- oder OpenDocument-Datei darstellt.
$presentation = new Presentation("SelectedSlides.pptx");

# Erstellen Sie eine neue Präsentation mit angepasster Foliengröße.
$resizedPresentation = new Presentation();

try {
    # Setzen Sie die benutzerdefinierte Foliengröße.
    $resizedPresentation->getSlideSize()->setSize($slideWidth, $slideHeight, SlideSizeScaleType::EnsureFit);

    # Klonen Sie die erste Folie der Originalpräsentation.
    $slide = $presentation->getSlides()->get_Item(0);
    $resizedPresentation->getSlides()->insertClone(0, $slide);

    # Speichern Sie die skalierte Präsentation als PDF mit Notizen.
    $resizedPresentation->save("PDFnotes_out.pdf", SaveFormat::Pdf);
} finally {
    $resizedPresentation->dispose();
    $presentation->dispose();
}
```


## **PowerPoint in PDF im Foliennotizen‑Modus konvertieren**

Dieser Code zeigt, wie eine PowerPoint-Präsentation in ein PDF konvertiert wird, das die Notizen enthält:

```php
# Instanziieren Sie die Presentation-Klasse, die eine PowerPoint- oder OpenDocument-Datei darstellt.
$presentation = new Presentation("SelectedSlides.pptx");
try {
    # Konfigurieren Sie die PDF-Optionen mit Notizen-Layout.
    $notesOptions = new NotesCommentsLayoutingOptions();
    $notesOptions->setNotesPosition(NotesPositions::BottomFull);
    $pdfOptions = new PdfOptions();
    $pdfOptions->setSlidesLayoutOptions($notesOptions);

    # Speichern Sie die Präsentation als PDF mit Notizen.
    $presentation->save("PDF_with_notes.pdf", SaveFormat::Pdf, $pdfOptions);
} finally {
    $presentation->dispose();
}
```


## **Barrierefreiheit und Compliance-Standards für PDF**

Aspose.Slides ermöglicht die Verwendung eines Konvertierungsverfahrens, das den [Web Content Accessibility Guidelines (**WCAG**)](https://www.w3.org/TR/WCAG-TECHS/pdf.html) entspricht. Sie können ein PowerPoint-Dokument mit einem dieser Compliance-Standards in PDF exportieren: **PDF/A1a**, **PDF/A1b** und **PDF/UA**.

Dieser Code demonstriert einen PowerPoint-zu-PDF-Konvertierungsprozess, der mehrere PDFs basierend auf unterschiedlichen Compliance-Standards erzeugt:

```php
$presentation = new Presentation("pres.pptx");
try {
    $pdfOptions = new PdfOptions();

    $pdfOptions->setCompliance(PdfCompliance::PdfA1a);
    $presentation->save("pres-a1a-compliance.pdf", SaveFormat::Pdf, $pdfOptions);

    $pdfOptions->setCompliance(PdfCompliance::PdfA1b);
    $presentation->save("pres-a1b-compliance.pdf", SaveFormat::Pdf, $pdfOptions);

    $pdfOptions->setCompliance(PdfCompliance::PdfUa);
    $presentation->save("pres-ua-compliance.pdf", SaveFormat::Pdf, $pdfOptions);
} finally {
    $presentation->dispose();
}
```


{{% alert title="Note" color="warning" %}} 

Aspose.Slides unterstützt PDF-Konvertierungsoperationen, mit denen Sie PDF-Dateien in gängige Dateiformate konvertieren können. Sie können [PDF zu HTML](https://products.aspose.com/slides/php-java/conversion/pdf-to-html/), [PDF zu Bild](https://products.aspose.com/slides/php-java/conversion/pdf-to-image/), [PDF zu JPG](https://products.aspose.com/slides/php-java/conversion/pdf-to-jpg/), und [PDF zu PNG](https://products.aspose.com/slides/php-java/conversion/pdf-to-png/) Konvertierungen durchführen. Weitere PDF-Konvertierungsoperationen zu speziellen Formaten – [PDF zu SVG](https://products.aspose.com/slides/php-java/conversion/pdf-to-svg/), [PDF zu TIFF](https://products.aspose.com/slides/php-java/conversion/pdf-to-tiff/), und [PDF zu XML](https://products.aspose.com/slides/php-java/conversion/pdf-to-xml/) – werden ebenfalls unterstützt.

{{% /alert %}}

## **FAQ**

**Kann ich mehrere PowerPoint-Dateien stapelweise in PDF konvertieren?**

Ja, Aspose.Slides unterstützt die Batch-Konvertierung mehrerer PPT- oder PPTX-Dateien in PDF. Sie können Ihre Dateien iterativ durchlaufen und den Konvertierungsprozess programmgesteuert anwenden.

**Ist es möglich, das konvertierte PDF passwortgeschützt zu machen?**

Absolut. Verwenden Sie die Klasse [PdfOptions](https://reference.aspose.com/slides/php-java/aspose.slides/pdfoptions/), um ein Passwort festzulegen und Zugriffsrechte während des Konvertierungsprozesses zu definieren.

**Wie kann ich ausgeblendete Folien in das PDF einbeziehen?**

Verwenden Sie die Methode `setShowHiddenSlides` in der Klasse [PdfOptions](https://reference.aspose.com/slides/php-java/aspose.slides/pdfoptions/), um ausgeblendete Folien in das resultierende PDF aufzunehmen.

**Kann Aspose.Slides hohe Bildqualität im PDF gewährleisten?**

Ja, Sie können die Bildqualität steuern, indem Sie Methoden wie `setJpegQuality` und `setSufficientResolution` in der Klasse [PdfOptions](https://reference.aspose.com/slides/php-java/aspose.slides/pdfoptions/) verwenden, um hochwertige Bilder in Ihrem PDF sicherzustellen.

**Unterstützt Aspose.Slides die PDF/A-Compliance-Standards?**

Ja, Aspose.Slides ermöglicht den Export von PDFs, die verschiedenen Standards entsprechen, einschließlich PDF/A1a, PDF/A1b und PDF/UA, und stellt somit sicher, dass Ihre Dokumente den Anforderungen an Barrierefreiheit und Archivierung genügen.

## **Weitere Ressourcen**

- [Aspose.Slides für PHP via Java Dokumentation](/slides/de/php-java/)
- [Aspose.Slides für PHP via Java API-Referenz](https://reference.aspose.com/slides/php-java/)
- [Aspose kostenlose Online-Konverter](https://products.aspose.app/slides/conversion)