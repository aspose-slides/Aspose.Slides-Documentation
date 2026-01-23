---
title: PPT und PPTX in PDF mit PHP konvertieren [Erweiterte Funktionen enthalten]
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
- PHP
- Aspose.Slides
description: "Konvertieren Sie PowerPoint PPT/PPTX in qualitativ hochwertige, durchsuchbare PDFs in PHP mit Aspose.Slides, inklusive schneller Codebeispiele und erweiterter Konvertierungsoptionen."
---

## **Übersicht**

Das Konvertieren von PowerPoint-Präsentationen (PPT, PPTX, ODP usw.) in PDF‑Format mit PHP bietet mehrere Vorteile, darunter Kompatibilität über verschiedene Geräte hinweg und das Bewahren von Layout und Formatierung Ihrer Präsentation. Dieser Leitfaden zeigt, wie man Präsentationen in PDF‑Dokumente umwandelt, verschiedene Optionen zur Steuerung der Bildqualität nutzt, ausgeblendete Folien einbezieht, PDF‑Dateien mit Passwort versieht, Font‑Substitutionen erkennt, bestimmte Folien zur Konvertierung auswählt und Compliance‑Standards auf Ausgabedokumente anwendet.

## **PowerPoint‑zu‑PDF‑Konvertierungen**

Mit Aspose.Slides können Sie Präsentationen in folgenden Formaten in PDF umwandeln:

* **PPT**
* **PPTX**
* **ODP**

Um eine Präsentation in PDF zu konvertieren, übergeben Sie den Dateinamen als Argument an die [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/Presentation)-Klasse und speichern das Ergebnis anschließend mit einer `save`‑Methode als PDF. Die [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/Presentation)-Klasse stellt die `save`‑Methode bereit, die typischerweise zur Konvertierung einer Präsentation in PDF verwendet wird.

{{%  alert title="HINWEIS"  color="warning"   %}} 

Aspose.Slides für PHP via Java fügt API‑Informationen und Versionsnummer in Ausgabedokumente ein. Beim Konvertieren einer Präsentation zu PDF füllt Aspose.Slides das Feld Application mit "*Aspose.Slides*" und das Feld PDF Producer in der Form "*Aspose.Slides v XX.XX*" aus. **Beachte**: Sie können Aspose.Slides nicht anweisen, diese Informationen aus Ausgabedokumenten zu entfernen oder zu ändern.

{{% /alert %}}

Aspose.Slides ermöglicht Ihnen das Konvertieren von:

* Gesamten Präsentationen zu PDF
* Bestimmten Folien einer Präsentation zu PDF

Aspose.Slides exportiert Präsentationen zu PDF und sorgt dafür, dass die resultierenden PDFs den Originalpräsentationen sehr nahe kommen. Elemente und Attribute werden in der Konvertierung exakt wiedergegeben, darunter:

* Bilder
* Textfelder und Formen
* Textformatierung
* Absatzformatierung
* Hyperlinks
* Kopf‑ und Fußzeilen
* Aufzählungszeichen
* Tabellen

## **PowerPoint zu PDF konvertieren**

Der Standard‑PowerPoint‑zu‑PDF‑Konvertierungsprozess verwendet die Vorgabe‑Optionen. In diesem Fall versucht Aspose.Slides, die bereitgestellte Präsentation mit optimalen Einstellungen und höchster Qualität in PDF zu konvertieren.

Der folgende Code zeigt, wie man eine Präsentation (PPT, PPTX, ODP usw.) zu PDF konvertiert:
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

Aspose bietet einen kostenlosen Online-[**PowerPoint‑zu‑PDF‑Konverter**](https://products.aspose.app/slides/conversion/ppt-to-pdf), der den Präsentation‑zu‑PDF‑Konvertierungsprozess demonstriert. Sie können diesen Konverter testen, um die hier beschriebene Vorgehensweise live zu erleben.

{{% /alert %}}

## **PowerPoint zu PDF konvertieren mit Optionen**

Aspose.Slides stellt benutzerdefinierte Optionen – Eigenschaften der [PdfOptions](https://reference.aspose.com/slides/php-java/aspose.slides/PdfOptions)-Klasse – bereit, mit denen Sie das resultierende PDF anpassen, es mit einem Passwort schützen oder das Vorgehen der Konvertierung festlegen können.

### **PowerPoint zu PDF konvertieren mit benutzerdefinierten Optionen**

Mit benutzerdefinierten Konvertierungsoptionen können Sie Ihre bevorzugten Qualitätseinstellungen für Rasterbilder festlegen, das Verhalten von Metadateien bestimmen, ein Komprimierungsniveau für Text angeben, DPI für Bilder konfigurieren und mehr.

Das untenstehende Code‑Beispiel demonstriert, wie man eine PowerPoint‑Präsentation zu PDF mit mehreren benutzerdefinierten Optionen konvertiert.
```php
# Instanziieren Sie die PdfOptions-Klasse.
$pdfOptions = new PdfOptions();

# Legen Sie die Qualität für JPG-Bilder fest.
$pdfOptions->setJpegQuality(90);

# Legen Sie die DPI für Bilder fest.
$pdfOptions->setSufficientResolution(300);

# Legen Sie das Verhalten für Metadateien fest.
$pdfOptions->setSaveMetafilesAsPng(true);

# Legen Sie das Textkomprimierungsniveau für Textinhalte fest.
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


### **PowerPoint zu PDF konvertieren mit ausgeblendeten Folien**

Enthält eine Präsentation ausgeblendete Folien, können Sie die Methode [setShowHiddenSlides](https://reference.aspose.com/slides/php-java/aspose.slides/pdfoptions/#setShowHiddenSlides) der [PdfOptions](https://reference.aspose.com/slides/php-java/aspose.slides/PdfOptions)-Klasse verwenden, um die ausgeblendeten Folien als Seiten in das resultierende PDF aufzunehmen.

Der folgende Code zeigt, wie man eine PowerPoint‑Präsentation zu PDF konvertiert und dabei ausgeblendete Folien einbezieht:
```php
# Instanziieren Sie die Presentation-Klasse, die eine PowerPoint- oder OpenDocument-Datei darstellt.
$presentation = new Presentation("PowerPoint.pptx");
try {
    # Instanziieren Sie die PdfOptions-Klasse.
    $pdfOptions = new PdfOptions();

    # Versteckte Folien hinzufügen.
    $pdfOptions->setShowHiddenSlides(true);

    # Präsentation als PDF speichern.
    $presentation->save("PowerPoint-to-PDF.pdf", SaveFormat::Pdf, $pdfOptions);
} finally {
    $presentation->dispose();
}
```


### **PowerPoint zu passwortgeschütztem PDF konvertieren**

Dieses Beispiel demonstriert, wie man eine PowerPoint‑Präsentation in ein passwortgeschütztes PDF konvertiert, wobei die Schutz‑Parameter der [PdfOptions](https://reference.aspose.com/slides/php-java/aspose.slides/pdfoptions/)-Klasse verwendet werden:
```php
# Instanziieren Sie die Presentation-Klasse, die eine PowerPoint- oder OpenDocument-Datei darstellt.
$presentation = new Presentation("PowerPoint.pptx");
try {
    # Instanziieren Sie die PdfOptions-Klasse.
    $pdfOptions = new PdfOptions();

    # Setzen Sie ein PDF-Passwort und Zugriffsberechtigungen.
    $pdfOptions->setPassword("password");
    $pdfOptions->setAccessPermissions(PdfAccessPermissions::PrintDocument | PdfAccessPermissions::HighQualityPrint);

    # Speichern Sie die Präsentation als PDF.
    $presentation->save("PPTX-to-PDF.pdf", SaveFormat::Pdf, $pdfOptions);
} finally {
    $presentation->dispose();
}
```


### **Font‑Substitutionen erkennen**

Aspose.Slides stellt die Methode [setWarningCallback](https://reference.aspose.com/slides/php-java/aspose.slides/saveoptions/#setWarningCallback) in der [PdfOptions](https://reference.aspose.com/slides/php-java/aspose.slides/pdfoptions/)-Klasse bereit, mit der Sie Font‑Substitutionen während der Präsentation‑zu‑PDF‑Konvertierung erkennen können.

Der folgende Code zeigt, wie Font‑Substitutionen erkannt werden:
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

// Warn-Callback in PDF-Optionen festlegen.
$pdfOptions = new PdfOptions();
$warningCallback = java_closure(new FontSubstitutionHandler(), null, java("com.aspose.slides.IWarningCallback"));
$pdfOptions->setWarningCallback($warningCallback);

// Instanziieren Sie die Presentation-Klasse, die eine PowerPoint- oder OpenDocument-Datei darstellt.
$presentation = new Presentation("sample.pptx");
try {
    // Präsentation als PDF speichern.
    $presentation->save("output.pdf", SaveFormat::Pdf, $pdfOptions);
} finally {
    $presentation->dispose();
}
```


{{%  alert color="primary"  %}} 

Weitere Informationen zu Font‑Substitutionen finden Sie im Artikel [Font Substitution](/slides/de/php-java/font-substitution/).

{{% /alert %}} 

## **Ausgewählte Folien in PowerPoint zu PDF konvertieren**

Dieses Beispiel demonstriert, wie nur bestimmte Folien einer PowerPoint‑Präsentation zu PDF konvertiert werden:
```php
# Instanziieren Sie die Presentation-Klasse, die eine PowerPoint- oder OpenDocument-Datei darstellt.
$presentation = new Presentation("PowerPoint.pptx");
try {
    # Array mit Foliennummern festlegen.
    $slides = array(1, 3);

    # Präsentation als PDF speichern.
    $presentation->save("PPTX-to-PDF.pdf", $slides, SaveFormat::Pdf);
} finally {
    $presentation->dispose();
}
```


## **PowerPoint zu PDF konvertieren mit benutzerdefinierter Foliengröße**

Dieses Beispiel demonstriert, wie man eine PowerPoint‑Präsentation zu PDF mit einer festgelegten Foliengröße konvertiert:
```php
$slideWidth = 612.0;
$slideHeight = 792.0;

# Instanziieren Sie die Presentation-Klasse, die eine PowerPoint- oder OpenDocument-Datei darstellt.
$presentation = new Presentation("SelectedSlides.pptx");

# Erstellen Sie eine neue Präsentation mit angepasster Foliengröße.
$resizedPresentation = new Presentation();

try {
    # Legen Sie die benutzerdefinierte Foliengröße fest.
    $resizedPresentation->getSlideSize()->setSize($slideWidth, $slideHeight, SlideSizeScaleType::EnsureFit);

    # Klonen Sie die erste Folie aus der ursprünglichen Präsentation.
    $slide = $presentation->getSlides()->get_Item(0);
    $resizedPresentation->getSlides()->insertClone(0, $slide);

    # Speichern Sie die verkleinerte Präsentation als PDF mit Notizen.
    $resizedPresentation->save("PDFnotes_out.pdf", SaveFormat::Pdf);
} finally {
    $resizedPresentation->dispose();
    $presentation->dispose();
}
```


## **PowerPoint zu PDF im Notiz‑Folien‑Modus konvertieren**

Dieses Beispiel demonstriert, wie man eine PowerPoint‑Präsentation zu einem PDF konvertiert, das die Notizen enthält:
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


## **Barrierefreiheit und Compliance‑Standards für PDF**

Aspose.Slides ermöglicht Ihnen ein Konvertierungsverfahren, das den [Web Content Accessibility Guidelines (**WCAG**)](https://www.w3.org/TR/WCAG-TECHS/pdf.html) entspricht. Sie können ein PowerPoint‑Dokument zu PDF exportieren und dabei einen der folgenden Compliance‑Standards verwenden: **PDF/A1a**, **PDF/A1b** und **PDF/UA**.

Der folgende Code demonstriert einen PowerPoint‑zu‑PDF‑Konvertierungsprozess, der mehrere PDFs basierend auf unterschiedlichen Compliance‑Standards erzeugt:
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


{{% alert title="Hinweis" color="warning" %}} 

Aspose.Slides unterstützt PDF‑Konvertierungs‑Operationen, mit denen Sie PDF‑Dateien in gängige Formate umwandeln können. Sie können [PDF zu HTML](https://products.aspose.com/slides/php-java/conversion/pdf-to-html/), [PDF zu Bild](https://products.aspose.com/slides/php-java/conversion/pdf-to-image/), [PDF zu JPG](https://products.aspose.com/slides/php-java/conversion/pdf-to-jpg/) und [PDF zu PNG](https://products.aspose.com/slides/php-java/conversion/pdf-to-png/) durchführen. Weitere spezialisierte Formate wie [PDF zu SVG](https://products.aspose.com/slides/php-java/conversion/pdf-to-svg/), [PDF zu TIFF](https://products.aspose.com/slides/php-java/conversion/pdf-to-tiff/) und [PDF zu XML](https://products.aspose.com/slides/php-java/conversion/pdf-to-xml/) werden ebenfalls unterstützt.

{{% /alert %}}

## **FAQ**

**Kann ich mehrere PowerPoint‑Dateien auf einmal zu PDF konvertieren?**

Ja, Aspose.Slides unterstützt die Stapelverarbeitung mehrerer PPT‑ oder PPTX‑Dateien zu PDF. Sie können Ihre Dateien iterativ durchlaufen und den Konvertierungsprozess programmgesteuert anwenden.

**Ist es möglich, das konvertierte PDF mit Passwort zu schützen?**

Absolut. Verwenden Sie die [PdfOptions](https://reference.aspose.com/slides/php-java/aspose.slides/pdfoptions/)-Klasse, um ein Passwort festzulegen und Zugriffsrechte während des Konvertierungsvorgangs zu definieren.

**Wie füge ich ausgeblendete Folien in das PDF ein?**

Nutzen Sie die Methode `setShowHiddenSlides` in der [PdfOptions](https://reference.aspose.com/slides/php-java/aspose.slides/pdfoptions/)-Klasse, um ausgeblendete Folien im resultierenden PDF zu berücksichtigen.

**Kann Aspose.Slides eine hohe Bildqualität im PDF beibehalten?**

Ja, Sie können die Bildqualität steuern, indem Sie Methoden wie `setJpegQuality` und `setSufficientResolution` in der [PdfOptions](https://reference.aspose.com/slides/php-java/aspose.slides/pdfoptions/)-Klasse verwenden, um hochwertige Bilder in Ihrem PDF sicherzustellen.

**Unterstützt Aspose.Slides PDF/A‑Compliance‑Standards?**

Ja, Aspose.Slides ermöglicht den Export von PDFs, die verschiedenen Standards entsprechen, darunter PDF/A1a, PDF/A1b und PDF/UA, sodass Ihre Dokumente sowohl barrierefrei als auch archivierungstauglich sind.

## **Weitere Ressourcen**

- [Aspose.Slides für PHP via Java Dokumentation](/slides/de/php-java/)
- [Aspose.Slides für PHP via Java API‑Referenz](https://reference.aspose.com/slides/php-java/)
- [Aspose Kostenlose Online‑Konverter](https://products.aspose.app/slides/conversion)