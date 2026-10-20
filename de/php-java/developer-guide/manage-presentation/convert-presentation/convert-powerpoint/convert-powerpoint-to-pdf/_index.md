---
title: PPT und PPTX in PDF konvertieren in PHP [Erweiterte Funktionen enthalten]
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
- Anhang
- PDF/A1a
- PDF/A1b
- PDF/UA
- PHP
- Aspose.Slides
description: "PowerPoint PPT/PPTX in hochwertige, durchsuchbare PDFs in PHP mit Aspose.Slides konvertieren, mit schnellen Codebeispielen und erweiterten Konvertierungsoptionen."
---
## **Übersicht**

Das Konvertieren von PowerPoint‑Präsentationen (PPT, PPTX, ODP usw.) in das PDF‑Format in PHP bietet mehrere Vorteile, darunter die Kompatibilität über verschiedene Geräte hinweg und das Bewahren des Layouts und der Formatierung Ihrer Präsentation. Dieser Leitfaden zeigt, wie Präsentationen in PDF‑Dokumente konvertiert werden, verschiedene Optionen zur Steuerung der Bildqualität verwendet, versteckte Folien einbezogen, PDF‑Dateien mit Passwort geschützt, Schriften‑Ersetzungen erkannt, bestimmte Folien für die Konvertierung ausgewählt und Konformitätsstandards auf Ausgabedokumente angewendet werden.

## **PowerPoint‑zu‑PDF‑Konvertierungen**

* **PPT**
* **PPTX**
* **ODP**

Um eine Präsentation in PDF zu konvertieren, übergeben Sie den Dateinamen als Argument an die [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/presentation/)‑Klasse und speichern Sie die Präsentation anschließend als PDF mithilfe einer [save](https://reference.aspose.com/slides/php-java/aspose.slides/presentation/save/)‑Methode. Die [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/presentation/)‑Klasse stellt die [save](https://reference.aspose.com/slides/php-java/aspose.slides/presentation/save/)‑Methode bereit, die typischerweise zum Konvertieren einer Präsentation in PDF verwendet wird.

{{% alert color="info" title="Note" %}}
Aspose.Slides for PHP via Java fügt seine API‑Informationen und Versionsnummer in Ausgabedokumente ein. Zum Beispiel füllt Aspose.Slides beim Konvertieren einer Präsentation in PDF das Feld Application mit „*Aspose.Slides*“ und das Feld PDF Producer mit einem Wert in der Form „*Aspose.Slides v XX.XX*“. **Hinweis**: Sie können Aspose.Slides nicht anweisen, diese Informationen aus Ausgabedokumenten zu ändern oder zu entfernen.
{{% /alert %}}

Aspose.Slides ermöglicht die Konvertierung von:

* Ganze Präsentationen in PDF
* Bestimmte Folien einer Präsentation in PDF

Aspose.Slides exportiert Präsentationen nach PDF und stellt sicher, dass die resultierenden PDFs den Originalpräsentationen sehr ähnlich sind. Elemente und Attribute werden bei der Konvertierung exakt wiedergegeben, einschließlich:

* Bilder
* Textfelder und Formen
* Textformatierung
* Absatzformatierung
* Hyperlinks
* Kopf‑ und Fußzeilen
* Aufzählungszeichen
* Tabellen

## **PowerPoint‑zu‑PDF konvertieren**

Der standardmäßige PowerPoint‑zu‑PDF‑Konvertierungsprozess verwendet Standardoptionen. In diesem Fall versucht Aspose.Slides, die bereitgestellte Präsentation mit optimalen Einstellungen auf höchstem Qualitätsniveau in PDF zu konvertieren.

Das folgende Beispiel lädt eine Präsentation und speichert alle sichtbaren Folien mithilfe der Standard‑Exporteinstellungen als PDF.

```php
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;

$presentation = new Presentation("PowerPoint.pptx");
try {
    $presentation->save("PPT-to-PDF.pdf", SaveFormat::Pdf);
} finally {
    $presentation->dispose();
}
```

{{% alert color="info" title="Note" %}}
Aspose bietet einen kostenlosen Online‑[**PowerPoint‑zu‑PDF‑Konverter**](https://products.aspose.app/slides/conversion/ppt-to-pdf), der den Präsentation‑zu‑PDF‑Konvertierungsprozess demonstriert. Sie können mit diesem Konverter einen Test durchführen, um die hier beschriebene Vorgehensweise live umzusetzen.
{{% /alert %}}

## **PowerPoint‑zu‑PDF‑Konvertierung mit Optionen**

Aspose.Slides stellt benutzerdefinierte Optionen – Eigenschaften der Klasse [PdfOptions](https://reference.aspose.com/slides/php-java/aspose.slides/pdfoptions/) – bereit, mit denen Sie das resultierende PDF anpassen, mit einem Passwort schützen oder das Vorgehen des Konvertierungsprozesses festlegen können.

### **PowerPoint‑zu‑PDF‑Konvertierung mit benutzerdefinierten Optionen**

Mit benutzerdefinierten Konvertierungsoptionen können Sie die gewünschte Qualitätsstufe für Rasterbilder festlegen, festlegen, wie Metadateien behandelt werden sollen, einen Komprimierungsgrad für Text einstellen, die DPI für Bilder konfigurieren und vieles mehr.

```php
use aspose\slides\PdfCompliance;
use aspose\slides\PdfOptions;
use aspose\slides\PdfTextCompression;
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;

$pdfOptions = new PdfOptions();
$pdfOptions->setJpegQuality(90);
$pdfOptions->setSufficientResolution(300);
$pdfOptions->setSaveMetafilesAsPng(true);
$pdfOptions->setTextCompression(PdfTextCompression::Flate);
$pdfOptions->setCompliance(PdfCompliance::Pdf15);

$presentation = new Presentation("PowerPoint.pptx");
try {
    $presentation->save("PowerPoint-to-PDF.pdf", SaveFormat::Pdf, $pdfOptions);
} finally {
    $presentation->dispose();
}
```

### **Automatische Bildkomprimierung auswählen**

Enthält eine Präsentation viele Fotos oder Screenshots, kann die Reduzierung der Größe des exportierten PDFs das Versenden per E‑Mail oder Herunterladen erleichtern. Rufen Sie [PdfOptions::setBestImagesCompressionRatio](https://reference.aspose.com/slides/php-java/aspose.slides/pdfoptions/setbestimagescompressionratio/) mit `true` auf, um während des PDF‑Exports automatisch den am besten geeigneten Komprimierungsalgorithmus für jedes Bild auszuwählen.

Das folgende Beispiel lädt eine vorhandene Präsentation, aktiviert die automatische Auswahl der Bildkomprimierung und speichert sie als PDF‑Dokument. Alle anderen PDF‑Exporteinstellungen behalten ihre Standardwerte bei.

```php
use aspose\slides\PdfOptions;
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;

$pdfOptions = new PdfOptions();
$pdfOptions->setBestImagesCompressionRatio(true);

$presentation = new Presentation("image-heavy.pptx");
try {
    $presentation->save("image-heavy.pdf", SaveFormat::Pdf, $pdfOptions);
} finally {
    $presentation->dispose();
}
```

Diese Option wählt für jedes Bild einen Komprimierungsalgorithmus aus. Das Verringern des an [setJpegQuality](https://reference.aspose.com/slides/php-java/aspose.slides/pdfoptions/setjpegquality/) übergebenen Wertes reduziert hingegen die JPEG‑Bildqualität, während das Verringern des an [setSufficientResolution](https://reference.aspose.com/slides/php-java/aspose.slides/pdfoptions/setsufficientresolution/) übergebenen Wertes ermöglicht, dass Bilder auf eine niedrigere Auflösung herunterskaliert werden, was Details reduzieren kann. Das Aktivieren der automatischen Komprimierungsauswahl senkt diese Einstellungen selbst nicht.

Die Auswahl von Bildkomprimierungsalgorithmen erfordert zusätzlichen Verarbeitungszeit und Speicher. Die Größenreduktion hängt von den Bildern und den Exporteinstellungen der Präsentation ab; eine feste Reduktion ist nicht für jede Präsentation garantiert.

### **Eingebettete OLE‑Dateien als PDF‑Anhänge erhalten**

Enthält eine Präsentation eine eingebettete Excel‑Arbeitsmappe, möchten Sie möglicherweise, dass PDF‑Empfänger sowohl die Daten der Arbeitsmappe als auch die Folien einsehen können. Rufen Sie [setIncludeOleData](https://reference.aspose.com/slides/php-java/aspose.slides/pdfoptions/) mit `true` auf, um eingebettete OLE‑Dateien als Anhänge im resultierenden PDF zu erhalten.

Der Standardwert ist `false`: Das Vorschaubild oder Symbol des OLE‑Objekts wird auf der PDF‑Seite dargestellt, jedoch wird die eingebettete Datei nicht als Anhang hinzugefügt. Durch Setzen der Option auf `true` wird die Dateidaten zusätzlich eingebunden. Die Vorschau bleibt eine visuelle Darstellung; der Anhang ermöglicht es Empfängern, die eingebettete Datei separat zu öffnen oder zu speichern. Das OLE‑Objekt wird nicht zu einem interaktiven Excel‑Arbeitsblatt auf der PDF‑Seite.

Das folgende Beispiel lädt eine Präsentation, die bereits eine eingebettete Excel‑Arbeitsmappe enthält, und exportiert sie nach PDF mit der angehängten Arbeitsmappe.

```php
use aspose\slides\PdfOptions;
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;

$pdfOptions = new PdfOptions();
$pdfOptions->setIncludeOleData(true);

$presentation = new Presentation("presentation.pptx");
try {
    $presentation->save("presentation.pdf", SaveFormat::Pdf, $pdfOptions);
} finally {
    $presentation->dispose();
}
```

Um das Ergebnis zu prüfen:

1. Öffnen Sie das exportierte PDF in einem Viewer, der Dateianhänge unterstützt, z. B. Adobe Acrobat Reader.
2. Öffnen Sie das **Attachments**‑Panel des Viewers und suchen Sie die eingebettete Arbeitsmappe.
3. Speichern Sie den Anhang und öffnen Sie ihn in Excel, um die Daten zu prüfen, oder öffnen Sie ihn direkt, falls der Viewer dies zulässt. Die Vorschau auf der PDF‑Seite ist vom Anhang getrennt.

{{% alert color="info" title="Note" %}}
Die PDF/A‑Standards legen Beschränkungen für Anhänge fest: PDF/A‑1 verbietet eingebettete Dateien, PDF/A‑2 erlaubt nur PDF/A‑Anhänge, und PDF/A‑3 erlaubt weitere Dateitypen, einschließlich Excel‑Arbeitsmappen. Dies sind Vorgaben der Standards, nicht spezifische Einschränkungen von Aspose.Slides. Dieses Beispiel verwendet die Standard‑PDF‑Compliance‑Einstellung und demonstriert keinen PDF/A‑Export.
{{% /alert %}}

### **PowerPoint‑zu‑PDF‑Konvertierung mit versteckten Folien**

Enthält eine Präsentation versteckte Folien, können Sie die Methode [setShowHiddenSlides](https://reference.aspose.com/slides/php-java/aspose.slides/pdfoptions/setshowhiddenslides/) der Klasse [PdfOptions](https://reference.aspose.com/slides/php-java/aspose.slides/pdfoptions/) verwenden, um die versteckten Folien als Seiten in das resultierende PDF aufzunehmen.

```php
use aspose\slides\PdfOptions;
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;

$pdfOptions = new PdfOptions();
$pdfOptions->setShowHiddenSlides(true);

$presentation = new Presentation("PowerPoint.pptx");
try {
    $presentation->save("PowerPoint-to-PDF.pdf", SaveFormat::Pdf, $pdfOptions);
} finally {
    $presentation->dispose();
}
```

### **PowerPoint‑zu‑PDF mit Passwortschutz konvertieren**

Das folgende Beispiel exportiert eine Präsentation in ein PDF, das zum Öffnen das Passwort `password` erfordert. Die Zugriffsrechte erlauben das Drucken, einschließlich Hoch‑Qualitäts‑Druck.

```php
use aspose\slides\PdfAccessPermissions;
use aspose\slides\PdfOptions;
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;

$pdfOptions = new PdfOptions();
$pdfOptions->setPassword("password");
$pdfOptions->setAccessPermissions(PdfAccessPermissions::PrintDocument | PdfAccessPermissions::HighQualityPrint);

$presentation = new Presentation("PowerPoint.pptx");
try {
    $presentation->save("PPTX-to-PDF.pdf", SaveFormat::Pdf, $pdfOptions);
} finally {
    $presentation->dispose();
}
```

### **Schriftarten‑Ersetzungen erkennen**

Aspose.Slides bietet die Methode [setWarningCallback](https://reference.aspose.com/slides/php-java/aspose.slides/saveoptions/) in der Klasse [PdfOptions](https://reference.aspose.com/slides/php-java/aspose.slides/pdfoptions/) an, mit der Sie Schriftarten‑Ersetzungen während des Präsentation‑zu‑PDF‑Konvertierungsprozesses erkennen können.

Das folgende Beispiel exportiert eine Präsentation nach PDF und gibt Schriftarten‑Ersetzungswarnungen in der Konsole aus. Eine Warnung wird nur ausgegeben, wenn während des Exports eine nicht verfügbare Schriftart ersetzt wird.

```php
use aspose\slides\PdfOptions;
use aspose\slides\Presentation;
use aspose\slides\ReturnAction;
use aspose\slides\SaveFormat;
use aspose\slides\WarningType;

class FontSubstitutionHandler {
    function warning($warning)
    {
        if (java_values($warning->getWarningType()) == WarningType::DataLoss && $warning->getDescription()->startsWith("Font will be substituted")) {
            echo("Font substitution warning: " . $warning->getDescription());
        }

        return ReturnAction::Continue;
    }
}

$warningCallback = java_closure(new FontSubstitutionHandler(), null, java("com.aspose.slides.IWarningCallback"));

$pdfOptions = new PdfOptions();
$pdfOptions->setWarningCallback($warningCallback);

$presentation = new Presentation("sample.pptx");
try {
    $presentation->save("output.pdf", SaveFormat::Pdf, $pdfOptions);
} finally {
    $presentation->dispose();
}
```

{{% alert color="info" title="Note" %}}
Weitere Informationen zu Schriftarten‑Ersetzungen finden Sie im Artikel [Schriftarten‑Ersetzung](/slides/de/php-java/font-substitution/).
{{% /alert %}}

### **Umgang mit Schriften ohne dedizierten Fettdruck‑Schriftschnitt**

Eine Präsentation kann für Text fett formatieren, selbst wenn die Schrift keinen dedizierten Fettdruck‑Schriftschnitt besitzt. Der Text kann dennoch durch synthetisches Fettdrucken fett erscheinen, wodurch die regulären Glyphen künstlich verdickt werden. Wenn dieser Text im PDF zu schwer wirkt oder von der gewünschten Darstellung abweicht, versuchen Sie, [PdfOptions::setRasterizeUnsupportedFontStyles](https://reference.aspose.com/slides/php-java/aspose.slides/pdfoptions/) mit `true` aufzurufen. Diese Option rendert den betroffenen Text während des PDF‑Exports als Bitmap und kann das Aussehen für bestimmte Schriften verbessern. Der Standardwert ist `false`.

Die Beispielpräsentation enthält zwei Textfelder: eines mit normalem Text und eines mit auf die gleiche Schrift angewandter Fettdruck‑Formatierung, wobei kein dedizierter Fettdruck‑Schriftschnitt vorhanden ist. Das folgende Beispiel lädt die Präsentation, aktiviert die Rasterisierung nicht unterstützter Schriftschnitt‑Stile und exportiert sie nach PDF:

```php
use aspose\slides\PdfOptions;
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;

$pdfOptions = new PdfOptions();
$pdfOptions->setRasterizeUnsupportedFontStyles(true);

$presentation = new Presentation("unsupported-bold.pptx");
try {
    $presentation->save("rasterized.pdf", SaveFormat::Pdf, $pdfOptions);
} finally {
    $presentation->dispose();
}
```

Die folgenden Vorschaubilder zeigen die Ausgabe mit deaktivierter und aktivierter Option. In diesem Beispiel hat der fette Text bei deaktivierter Option schwerere Striche. Bei aktivierter Option sind die Striche leichter; der normale Text bleibt unverändert. Vergleichen Sie die Ergebnisse, bevor Sie die Einstellung für Ihre Präsentation wählen.

| Option deaktiviert (`false`, Standard) | Option aktiviert (`true`) |
|---|---|
| ![PDF mit deaktivierter Rasterisierung nicht unterstützter Schriftschnitt‑Stile](unsupported-bold-disabled.png) | ![PDF mit aktivierter Rasterisierung nicht unterstützter Schriftschnitt‑Stile](unsupported-bold-enabled.png) |

In diesem Beispiel rasterisiert diese Option Text, der als fett formatiert ist, wenn seine Schrift keinen dedizierten Fettdruck‑Schriftschnitt hat. Stattdessen wählt [Schriftarten‑Ersetzung](/slides/de/php-java/font-substitution/) eine andere Schrift, wenn die Originalschrift nicht verfügbar ist.

## **Ausgewählte Folien aus PowerPoint in PDF konvertieren**

Das folgende Beispiel exportiert die Folien 1 und 3 einer Präsentation nach PDF. Die Foliennummern in diesem Array beginnen bei 1, und die Eingabepäsentation muss mindestens drei Folien enthalten.

```php
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;

$presentation = new Presentation("PowerPoint.pptx");
try {
    $slides = array(1, 3);
    $presentation->save("PPTX-to-PDF.pdf", $slides, SaveFormat::Pdf);
} finally {
    $presentation->dispose();
}
```

## **PowerPoint‑zu‑PDF‑Konvertierung mit benutzerdefinierter Foliengröße**

Das folgende Beispiel kopiert die erste Folie einer Präsentation in eine neue Präsentation mit einer Foliengröße von 612 × 792 Punkten (8,5 × 11 Zoll). Es skaliert den Folieninhalt, sodass er passt, und exportiert die einzelne Folie nach PDF.

```php
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;
use aspose\slides\SlideSizeScaleType;

$slideWidth = 612.0;
$slideHeight = 792.0;

$presentation = new Presentation("SelectedSlides.pptx");
$resizedPresentation = new Presentation();

try {
    $resizedPresentation->getSlideSize()->setSize($slideWidth, $slideHeight, SlideSizeScaleType::EnsureFit);
    $slide = $presentation->getSlides()->get_Item(0);
    $resizedPresentation->getSlides()->insertClone(0, $slide);

    // Entferne die leere Folie, mit der die neue Präsentation erstellt wurde.
    $resizedPresentation->getSlides()->removeAt(1);

    $resizedPresentation->save("PDF_with_custom_slide_size.pdf", SaveFormat::Pdf);
} finally {
    $resizedPresentation->dispose();
    $presentation->dispose();
}
```

## **PowerPoint‑zu‑PDF‑Konvertierung in Notiz‑Folien‑Ansicht**

Das folgende Beispiel exportiert eine Präsentation nach PDF und platziert die Rednernotizen jeder Folie unterhalb der Folie. Verwenden Sie eine Präsentation mit Rednernotizen, um das Ergebnis zu sehen.

```php
use aspose\slides\NotesCommentsLayoutingOptions;
use aspose\slides\NotesPositions;
use aspose\slides\PdfOptions;
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;

$notesOptions = new NotesCommentsLayoutingOptions();
$notesOptions->setNotesPosition(NotesPositions::BottomFull);

$pdfOptions = new PdfOptions();
$pdfOptions->setSlidesLayoutOptions($notesOptions);

$presentation = new Presentation("SelectedSlides.pptx");
try {
    $presentation->save("PDF_with_notes.pdf", SaveFormat::Pdf, $pdfOptions);
} finally {
    $presentation->dispose();
}
```

## **Barrierefreiheit und Compliance‑Standards für PDF**

Aspose.Slides ermöglicht Ihnen die Verwendung eines Konvertierungsverfahrens, das den [Web Content Accessibility Guidelines (**WCAG**)](https://www.w3.org/TR/WCAG-TECHS/pdf.html) entspricht. Sie können ein PowerPoint‑Dokument nach PDF exportieren und dabei einen der folgenden Compliance‑Standards verwenden: **PDF/A1a**, **PDF/A1b** und **PDF/UA**.

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

{{% alert color="info" title="Note" %}}
Aspose.Slides unterstützt PDF‑Konvertierungsoperationen und ermöglicht das Konvertieren von PDF‑Dateien in gängige Dateiformate. Sie können [PDF zu HTML](https://products.aspose.com/slides/php-java/conversion/pdf-to-html/), [PDF zu Bild](https://products.aspose.com/slides/php-java/conversion/pdf-to-image/), [PDF zu JPG](https://products.aspose.com/slides/php-java/conversion/pdf-to-jpg/), und [PDF zu PNG](https://products.aspose.com/slides/php-java/conversion/pdf-to-png/) Konvertierungen durchführen. Weitere PDF‑Konvertierungsoperationen zu spezialisierten Formaten – [PDF zu SVG](https://products.aspose.com/slides/php-java/conversion/pdf-to-svg/), [PDF zu TIFF](https://products.aspose.com/slides/php-java/conversion/pdf-to-tiff/), und [PDF zu XML](https://products.aspose.com/slides/php-java/conversion/pdf-to-xml/) – werden ebenfalls unterstützt.
{{% /alert %}}

> **Hinweis:** Beim Exportieren nach PDF/UA behandelt Aspose.Slides komplexe Grafiken wie SmartArt, Diagramme und Formeln als eine einzelne Figur. Einzelne Pfadelemente werden nicht als getrennte Inhalte erhalten und können als Artefakte markiert werden; Alternativtext wird nur für die gesamte Figur bereitgestellt.

## **FAQ**

**Kann ich mehrere PowerPoint‑Dateien stapelweise in PDF konvertieren?**  
Ja, Aspose.Slides unterstützt die Stapelkonvertierung mehrerer PPT‑ oder PPTX‑Dateien in PDF. Sie können Ihre Dateien iterativ durchlaufen und den Konvertierungsprozess programmgesteuert anwenden.

**Ist es möglich, das konvertierte PDF mit einem Passwort zu schützen?**  
Ja. Verwenden Sie die Klasse [PdfOptions](https://reference.aspose.com/slides/php-java/aspose.slides/pdfoptions/), um ein Passwort festzulegen und Zugriffsrechte während des Konvertierungsprozesses zu definieren.

**Wie kann ich versteckte Folien in das PDF einbinden?**  
Rufen Sie [setShowHiddenSlides](https://reference.aspose.com/slides/php-java/aspose.slides/pdfoptions/setshowhiddenslides/) mit `true` in der Klasse [PdfOptions](https://reference.aspose.com/slides/php-java/aspose.slides/pdfoptions/) auf, um versteckte Folien in das resultierende PDF aufzunehmen.

**Kann Aspose.Slides eine hohe Bildqualität im PDF beibehalten?**  
Ja, Sie können die Bildqualität steuern, indem Sie Methoden wie [setJpegQuality](https://reference.aspose.com/slides/php-java/aspose.slides/pdfoptions/setjpegquality/) und [setSufficientResolution](https://reference.aspose.com/slides/php-java/aspose.slides/pdfoptions/setsufficientresolution/) in der Klasse [PdfOptions](https://reference.aspose.com/slides/php-java/aspose.slides/pdfoptions/) verwenden, um hochwertige Bilder in Ihrem PDF sicherzustellen.

**Unterstützt Aspose.Slides PDF/A‑Compliance‑Standards?**  
Ja, Aspose.Slides ermöglicht den Export von PDFs, die den [verschiedenen Standards](https://reference.aspose.com/slides/php-java/aspose.slides/pdfcompliance/) entsprechen, darunter PDF/A1a, PDF/A1b und PDF/UA, sodass Ihre Dokumente die Anforderungen an Barrierefreiheit und Archivierung erfüllen.

## **Zusätzliche Ressourcen**

- [Aspose.Slides für PHP via Java Dokumentation](/slides/de/php-java/)
- [Aspose.Slides für PHP via Java API‑Referenz](https://reference.aspose.com/slides/php-java/)
- [Aspose kostenlose Online‑Konverter](https://products.aspose.app/slides/conversion)