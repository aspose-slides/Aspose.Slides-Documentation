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
description: "PowerPoint PPT/PPTX in hochqualitative, durchsuchbare PDFs in PHP mit Aspose.Slides konvertieren, mit schnellen Code-Beispielen und erweiterten Konvertierungsoptionen."
---
## **Übersicht**

Das Konvertieren von PowerPoint-Präsentationen (PPT, PPTX, ODP usw.) in das PDF-Format in PHP bietet mehrere Vorteile, darunter Kompatibilität über verschiedene Geräte hinweg und das Erhalten des Layouts und der Formatierung Ihrer Präsentation. Diese Anleitung zeigt, wie Präsentationen in PDF-Dokumente konvertiert werden, wie verschiedene Optionen zur Steuerung der Bildqualität verwendet werden, versteckte Folien einbezogen, PDF-Dateien passwortgeschützt werden, Schriftartsubstitutionen erkannt werden, bestimmte Folien für die Konvertierung ausgewählt werden und Compliance-Standards auf Ausgabedokumente angewendet werden.

## **PowerPoint-zu-PDF-Konvertierungen**

Mit Aspose.Slides können Sie Präsentationen in den folgenden Formaten zu PDF konvertieren:

* **PPT**
* **PPTX**
* **ODP**

Um eine Präsentation in PDF zu konvertieren, übergeben Sie den Dateinamen als Argument an die [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/presentation/) Klasse und speichern Sie die Präsentation anschließend als PDF mittels der [save](https://reference.aspose.com/slides/php-java/aspose.slides/presentation/save/) Methode. Die [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/presentation/) Klasse stellt die [save](https://reference.aspose.com/slides/php-java/aspose.slides/presentation/save/) Methode bereit, die typischerweise zum Konvertieren einer Präsentation in PDF verwendet wird.

{{% alert color="info" title="Note" %}}
Aspose.Slides für PHP via Java fügt seine API-Informationen und Versionsnummer in Ausgabedokumente ein. Beispielweise, wenn eine Präsentation in PDF konvertiert wird, füllt Aspose.Slides das Feld Application mit "*Aspose.Slides*" und das Feld PDF Producer mit einem Wert in der Form "*Aspose.Slides v XX.XX*". **Hinweis**, dass Sie Aspose.Slides nicht anweisen können, diese Informationen aus Ausgabedokumenten zu ändern oder zu entfernen.
{{% /alert %}}

Aspose.Slides ermöglicht Ihnen, Folgendes zu konvertieren:

* Gesamte Präsentationen zu PDF
* Bestimmte Folien einer Präsentation zu PDF

Aspose.Slides exportiert Präsentationen zu PDF und stellt sicher, dass die resultierenden PDFs eng an den Originalpräsentationen bleiben. Elemente und Attribute werden bei der Konvertierung genau wiedergegeben, einschließlich:

* Bilder
* Textfelder und Formen
* Textformatierung
* Absatzformatierung
* Hyperlinks
* Kopf- und Fußzeilen
* Aufzählungszeichen
* Tabellen

## **PowerPoint zu PDF konvertieren**

Der standardmäßige PowerPoint-zu-PDF-Konvertierungsprozess verwendet Standardoptionen. In diesem Fall versucht Aspose.Slides, die bereitgestellte Präsentation mit optimalen Einstellungen auf höchstem Qualitätsniveau in PDF zu konvertieren.

Das folgende Beispiel lädt eine Präsentation und speichert alle sichtbaren Folien mit den standardmäßigen Exporteinstellungen als PDF.

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
Aspose bietet einen kostenlosen Online-[**PowerPoint zu PDF-Konverter**](https://products.aspose.app/slides/conversion/ppt-to-pdf) an, der den Präsentation-zu-PDF-Konvertierungsprozess demonstriert. Sie können mit diesem Konverter einen Test durchführen, um die hier beschriebene Vorgehensweise live zu sehen.
{{% /alert %}}

## **PowerPoint zu PDF mit Optionen konvertieren**

Aspose.Slides stellt benutzerdefinierte Optionen – Eigenschaften der Klasse [PdfOptions](https://reference.aspose.com/slides/php-java/aspose.slides/pdfoptions/) – bereit, mit denen Sie das resultierende PDF anpassen, das PDF mit einem Passwort sperren oder festlegen können, wie der Konvertierungsprozess ablaufen soll.

### **PowerPoint zu PDF mit benutzerdefinierten Optionen konvertieren**

Mit benutzerdefinierten Konvertierungsoptionen können Sie Ihre bevorzugte Qualitätsstufe für Rasterbilder festlegen, bestimmen, wie Metadateien behandelt werden, ein Kompressionsniveau für Text setzen, die DPI für Bilder konfigurieren und mehr.

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

### **Eingebettete OLE-Dateien als PDF-Anhänge beibehalten**

Wenn eine Präsentation eine eingebettete Excel-Arbeitsmappe enthält, möchten Sie möglicherweise, dass PDF-Empfänger sowohl auf die Daten der Arbeitsmappe zugreifen als auch die Folien ansehen können. Rufen Sie [setIncludeOleData](https://reference.aspose.com/slides/php-java/aspose.slides/pdfoptions/) mit `true` auf, um eingebettete OLE-Dateien als Anhänge im resultierenden PDF beizubehalten.

Der Standardwert ist `false`: Das Vorschaubild oder Symbol des OLE-Objekts wird auf der PDF-Seite dargestellt, die eingebettete Datei jedoch nicht als Anhang eingefügt. Wird die Option auf `true` gesetzt, wird zusätzlich die Dateidaten eingeschlossen. Die Vorschau bleibt eine visuelle Darstellung; der Anhang ermöglicht es Empfängern, die eingebettete Datei separat zu öffnen oder zu speichern. Das OLE-Objekt wird nicht zu einem interaktiven Excel-Arbeitsblatt auf der PDF-Seite.

Das folgende Beispiel lädt eine Präsentation, die bereits eine eingebettete Excel-Arbeitsmappe enthält, und exportiert sie zu PDF mit der Arbeitsmappe als Anhang.

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
2. Öffnen Sie das **Attachments**-Panel des Viewers und suchen Sie die eingebettete Arbeitsmappe.
3. Speichern Sie den Anhang und öffnen Sie ihn in Excel, um die Daten zu prüfen, oder öffnen Sie ihn direkt, falls der Viewer dies zulässt. Die Vorschau auf der PDF-Seite ist vom Anhang getrennt.

{{% alert color="info" title="Note" %}}
Die PDF/A-Standards legen Beschränkungen für Anhänge fest: PDF/A-1 verbietet eingebettete Dateien, PDF/A-2 erlaubt nur PDF/A-Anhänge, und PDF/A-3 erlaubt andere Dateitypen, einschließlich Excel-Arbeitsmappen. Dies sind Anforderungen der Standards, keine spezifischen Beschränkungen von Aspose.Slides. Dieses Beispiel verwendet die standardmäßige PDF-Compliance-Einstellung und demonstriert keinen PDF/A-Export.
{{% /alert %}}

### **PowerPoint zu PDF mit versteckten Folien konvertieren**

Wenn eine Präsentation versteckte Folien enthält, können Sie die Methode [setShowHiddenSlides](https://reference.aspose.com/slides/php-java/aspose.slides/pdfoptions/setshowhiddenslides/) der Klasse [PdfOptions](https://reference.aspose.com/slides/php-java/aspose.slides/pdfoptions/) verwenden, um die versteckten Folien als Seiten im resultierenden PDF einzubeziehen.

Das folgende Beispiel exportiert eine Präsentation zu PDF und schließt dabei alle versteckten Folien ein.

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

### **PowerPoint zu einem passwortgeschützten PDF konvertieren**

Das folgende Beispiel exportiert eine Präsentation zu einem PDF, das zum Öffnen das Passwort `password` erfordert. Die Zugriffsberechtigungen erlauben das Drucken, einschließlich Druck in hoher Qualität.

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

### **Schriftart‑Substitutionen erkennen**

Aspose.Slides stellt die Methode [setWarningCallback](https://reference.aspose.com/slides/php-java/aspose.slides/saveoptions/) in der Klasse [PdfOptions](https://reference.aspose.com/slides/php-java/aspose.slides/pdfoptions/) bereit, mit der Sie Schriftart‑Substitutionen während des Präsentation‑zu‑PDF‑Konvertierungsprozesses erkennen können.

Das folgende Beispiel exportiert eine Präsentation zu PDF und gibt Schriftart‑Substitutionswarnungen in der Konsole aus. Eine Warnung wird nur ausgegeben, wenn während des Exports eine nicht verfügbare Schriftart substituiert wird.

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
Weitere Informationen zu Schriftart‑Substitutionen finden Sie im Artikel [Font Substitution](/slides/de/php-java/font-substitution/).
{{% /alert %}}

### **Umgang mit Schriftarten ohne eigene fette Variante**

Eine Präsentation kann Fettschrift auf Text anwenden, selbst wenn die Schriftart keine eigene fette Variante besitzt. Der Text kann trotzdem fett erscheinen durch synthetisches Fettdrucken, das die regulären Glyphen künstlich verdickt. Wenn dieser Text zu schwer wirkt oder vom gewünschten Aussehen im PDF abweicht, versuchen Sie, [PdfOptions::setRasterizeUnsupportedFontStyles](https://reference.aspose.com/slides/php-java/aspose.slides/pdfoptions/) mit `true` aufzurufen. Diese Option rendert den betroffenen Text während des PDF-Exports als Bitmap und kann das Erscheinungsbild für bestimmte Schriftarten verbessern. Der Standardwert ist `false`.

Die Beispielpräsentation enthält zwei Textfelder: eines mit normalem Text und eines mit angewandter Fettschrift auf derselben Schriftart, die keine eigene fette Variante besitzt. Das folgende Beispiel lädt die Präsentation, aktiviert die Rasterung nicht unterstützter Schriftstil‑Varianten und exportiert sie zu PDF:

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

Die folgenden Vorschauen zeigen die Ausgabe mit deaktivierter und aktivierter Option. In diesem Beispiel hat der fette Text bei deaktivierter Option stärkere Striche. Bei aktivierter Option sind die Striche leichter; der normale Text bleibt unverändert. Vergleichen Sie die Ergebnisse, bevor Sie die Einstellung für Ihre Präsentation wählen.

| Option deaktiviert (`false`, Standard) | Option aktiviert (`true`) |
|---|---|
| ![PDF with unsupported font style rasterization disabled](unsupported-bold-disabled.png) | ![PDF with unsupported font style rasterization enabled](unsupported-bold-enabled.png) |

In diesem Beispiel wird durch Aktivieren der Option nur der fette Text in eine Bitmap umgewandelt: Er kann nicht ausgewählt, kopiert oder ohne OCR als Text durchsucht werden und seine Kanten erscheinen bei 800 % Zoom weicher. Der normale Text bleibt durchsuchbar. Bei deaktivierter Option bleiben beide Zeichenketten als Text erhalten.

Diese Option rastert Text, der als fett formatiert ist, wenn seine Schriftart keine eigene fette Variante besitzt. [Font substitution](/slides/de/php-java/font-substitution/) wählt stattdessen eine andere Schriftart, wenn die Originalschrift nicht verfügbar ist.

## **Ausgewählte Folien von PowerPoint zu PDF konvertieren**

Das folgende Beispiel exportiert die Folien 1 und 3 einer Präsentation zu PDF. Folienzahlen in diesem Array sind einsbasiert, und die Eingabepäsentation muss mindestens drei Folien enthalten.

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

## **PowerPoint zu PDF mit benutzerdefinierter Foliengröße konvertieren**

Das folgende Beispiel kopiert die erste Folie einer Präsentation in eine neue Präsentation mit einer Foliengröße von 612 × 792 Punkten (8,5 × 11 Zoll). Es skaliert den Folieninhalt, um ihn anzupassen, und exportiert die einzelne Folie zu PDF.

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

    // Entferne die leere Folie, die bei der Erstellung der neuen Präsentation hinzugefügt wurde.
    $resizedPresentation->getSlides()->removeAt(1);

    $resizedPresentation->save("PDF_with_custom_slide_size.pdf", SaveFormat::Pdf);
} finally {
    $resizedPresentation->dispose();
    $presentation->dispose();
}
```

## **PowerPoint zu PDF in Notiz‑Folien‑Ansicht konvertieren**

Das folgende Beispiel exportiert eine Präsentation zu PDF und platziert die Rednernotizen jeder Folie unterhalb der Folie. Verwenden Sie eine Präsentation, die Rednernotizen enthält, um das Ergebnis zu sehen.

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

Aspose.Slides ermöglicht die Verwendung eines Konvertierungsverfahrens, das den [Web Content Accessibility Guidelines (**WCAG**)](https://www.w3.org/TR/WCAG-TECHS/pdf.html) entspricht. Sie können ein PowerPoint‑Dokument zu PDF exportieren unter Verwendung folgender Compliance‑Standards: **PDF/A1a**, **PDF/A1b** und **PDF/UA**.

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
Aspose.Slides unterstützt PDF-Konvertierungsoperationen, mit denen Sie PDF-Dateien in gängige Dateiformate konvertieren können. Sie können folgende Konvertierungen durchführen: [PDF zu HTML](https://products.aspose.com/slides/php-java/conversion/pdf-to-html/), [PDF zu Bild](https://products.aspose.com/slides/php-java/conversion/pdf-to-image/), [PDF zu JPG](https://products.aspose.com/slides/php-java/conversion/pdf-to-jpg/), und [PDF zu PNG](https://products.aspose.com/slides/php-java/conversion/pdf-to-png/). Weitere PDF-Konvertierungsoperationen zu Spezialformaten – [PDF zu SVG](https://products.aspose.com/slides/php-java/conversion/pdf-to-svg/), [PDF zu TIFF](https://products.aspose.com/slides/php-java/conversion/pdf-to-tiff/), und [PDF zu XML](https://products.aspose.com/slides/php-java/conversion/pdf-to-xml/) – werden ebenfalls unterstützt.
{{% /alert %}}

> **Hinweis:** Beim Exportieren zu PDF/UA behandelt Aspose.Slides komplexe Grafiken wie SmartArt, Diagramme und Formeln als einzige Figur. Einzelne Pfadelemente werden nicht als separater Inhalt erhalten und können als Artefakte markiert werden; alternativer Text wird nur für die gesamte Figur bereitgestellt.

## **FAQ**

**Kann ich mehrere PowerPoint-Dateien stapelweise in PDF konvertieren?**

Ja, Aspose.Slides unterstützt die Batch‑Konvertierung mehrerer PPT‑ oder PPTX‑Dateien zu PDF. Sie können Ihre Dateien durchlaufen und den Konvertierungsprozess programmgesteuert anwenden.

**Ist es möglich, das konvertierte PDF passwortgeschützt zu erstellen?**

Ja. Verwenden Sie die Klasse [PdfOptions](https://reference.aspose.com/slides/php-java/aspose.slides/pdfoptions/), um ein Passwort festzulegen und Zugriffsberechtigungen während des Konvertierungsprozesses zu definieren.

**Wie schließe ich versteckte Folien in das PDF ein?**

Rufen Sie [setShowHiddenSlides](https://reference.aspose.com/slides/php-java/aspose.slides/pdfoptions/setshowhiddenslides/) mit `true` in der Klasse [PdfOptions](https://reference.aspose.com/slides/php-java/aspose.slides/pdfoptions/) auf, um versteckte Folien im resultierenden PDF zu integrieren.

**Kann Aspose.Slides eine hohe Bildqualität im PDF beibehalten?**

Ja, Sie können die Bildqualität steuern, indem Sie Methoden wie [setJpegQuality](https://reference.aspose.com/slides/php-java/aspose.slides/pdfoptions/setjpegquality/) und [setSufficientResolution](https://reference.aspose.com/slides/php-java/aspose.slides/pdfoptions/setsufficientresolution/) in der Klasse [PdfOptions](https://reference.aspose.com/slides/php-java/aspose.slides/pdfoptions/) verwenden, um hochwertige Bilder in Ihrem PDF sicherzustellen.

**Unterstützt Aspose.Slides PDF/A‑Compliance‑Standards?**

Ja, Aspose.Slides ermöglicht den Export von PDFs, die den [verschiedenen Standards](https://reference.aspose.com/slides/php-java/aspose.slides/pdfcompliance/) entsprechen, einschließlich PDF/A1a, PDF/A1b und PDF/UA, sodass Ihre Dokumente den Anforderungen an Barrierefreiheit und Archivierung entsprechen.

## **Zusätzliche Ressourcen**

- [Aspose.Slides für PHP via Java Dokumentation](/slides/de/php-java/)
- [Aspose.Slides für PHP via Java API-Referenz](https://reference.aspose.com/slides/php-java/)
- [Aspose kostenlose Online-Konverter](https://products.aspose.app/slides/conversion)