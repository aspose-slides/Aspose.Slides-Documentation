---
title: Präsentationen in PHP speichern
linktitle: Präsentation speichern
type: docs
weight: 80
url: /de/php-java/save-presentation/
keywords:
- PowerPoint speichern
- OpenDocument speichern
- Präsentation speichern
- Folie speichern
- PPT speichern
- PPTX speichern
- ODP speichern
- Präsentation in Datei
- Präsentation in Stream
- vordefinierter Ansichtstyp
- Striktes Office Open XML-Format
- Zip64-Modus
- Thumbnail aktualisieren
- Speicherfortschritt
- PHP
- Aspose.Slides
description: "Erfahren Sie, wie Sie Präsentationen mit Aspose.Slides für PHP über Java speichern — Export nach PowerPoint oder OpenDocument bei Beibehaltung von Layouts, Schriftarten und Effekten."
---

## **Übersicht**

[Präsentationen in PHP öffnen](/slides/de/php-java/open-presentation/) beschreibt, wie die [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/presentation/) Klasse verwendet wird, um eine Präsentation zu öffnen. Dieser Artikel erklärt, wie man Präsentationen erstellt und speichert. Die [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/presentation/) Klasse enthält den Inhalt einer Präsentation. Egal, ob Sie eine Präsentation von Grund auf neu erstellen oder eine vorhandene bearbeiten, Sie sollten sie speichern, sobald Sie fertig sind. Mit Aspose.Slides für PHP können Sie in eine **Datei** oder **Stream** speichern. Dieser Artikel erklärt die verschiedenen Möglichkeiten, eine Präsentation zu speichern.

## **Präsentationen in Dateien speichern**

Speichern Sie eine Präsentation in einer Datei, indem Sie die `save`‑Methode der [Presentation]‑Klasse aufrufen. Übergeben Sie den Dateinamen und das Speicherformat an die Methode. Das folgende Beispiel zeigt, wie Sie eine Präsentation mit Aspose.Slides speichern.
```php
// Instanziieren Sie die Presentation-Klasse, die eine Präsentationsdatei darstellt.
$presentation = new Presentation();
try {
    // Führen Sie hier einige Arbeiten aus...
    
    // Speichern Sie die Präsentation in einer Datei.
    $presentation->save("Output.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```


## **Präsentationen in Streams speichern**

Sie können eine Präsentation in einen Stream speichern, indem Sie einen Ausgabestream an die `save`‑Methode der [Presentation]‑Klasse übergeben. Eine Präsentation kann in viele Stream‑Typen geschrieben werden. Im folgenden Beispiel erstellen wir eine neue Präsentation und speichern sie in einen Dateistream.
```php
// Instanziieren Sie die Presentation-Klasse, die eine Präsentationsdatei darstellt.
$presentation = new Presentation();
try {
    $fileStream = new Java("java.io.FileOutputStream", "Output.pptx");
    try {
        // Speichern Sie die Präsentation in den Stream.
        $presentation->save($fileStream, SaveFormat::Pptx);
    } finally {
        $fileStream->close();
    }
} finally {
    $presentation->dispose();
}
```


## **Präsentationen mit vordefiniertem Ansichtstyp speichern**

Aspose.Slides ermöglicht es Ihnen, die anfängliche Ansicht, die PowerPoint verwendet, wenn die erzeugte Präsentation geöffnet wird, über die [ViewProperties]‑Klasse festzulegen. Verwenden Sie die Methode [setLastView] mit einem Wert aus der Aufzählung [ViewType].
```php
$presentation = new Presentation();
try {
    $presentation->getViewProperties()->setLastView(ViewType::SlideMasterView);
    $presentation->save("SlideMasterView.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```


## **Präsentationen im Strikten Office Open XML-Format speichern**

Aspose.Slides ermöglicht das Speichern einer Präsentation im Strikten Office Open XML-Format. Verwenden Sie die [PptxOptions]‑Klasse und setzen Sie beim Speichern deren Conformance‑Eigenschaft. Wenn Sie [Conformance.Iso29500_2008_Strict] setzen, wird die Ausgabedatei im Strikten Office Open XML-Format gespeichert.

Das folgende Beispiel erstellt eine Präsentation und speichert sie im Strikten Office Open XML-Format.
```php
$options = new PptxOptions();
$options->setConformance(Conformance::Iso29500_2008_Strict);

// Instanziieren Sie die Presentation-Klasse, die eine Präsentationsdatei darstellt.
$presentation = new Presentation();
try {
    // Speichern Sie die Präsentation im Strict Office Open XML-Format.
    $presentation->save("StrictOfficeOpenXml.pptx", SaveFormat::Pptx, $options);
} finally {
    $presentation->dispose();
}
```


## **Präsentationen im Office Open XML-Format im Zip64‑Modus speichern**

Eine Office Open XML‑Datei ist ein ZIP‑Archiv, das eine Grenze von 4 GB (2^32 Byte) für die unkomprimierte Größe jeder Datei, die komprimierte Größe jeder Datei und die Gesamtgröße des Archivs festlegt und das Archiv zudem auf 65 535 (2^16‑1) Dateien beschränkt. ZIP64‑Format-Erweiterungen erhöhen diese Grenzen auf 2^64.

Die Methode [PptxOptions.setZip64Mode] ermöglicht es Ihnen, festzulegen, wann ZIP64‑Format-Erweiterungen beim Speichern einer Office Open XML‑Datei verwendet werden sollen.

Diese Methode kann mit den folgenden Modi verwendet werden:

- [IfNecessary] verwendet ZIP64‑Format-Erweiterungen nur, wenn die Präsentation die oben genannten Beschränkungen überschreitet. Dies ist der Standardmodus.
- [Never] verwendet niemals ZIP64‑Format-Erweiterungen.
- [Always] verwendet stets ZIP64‑Format-Erweiterungen.

Der folgende Code zeigt, wie man eine Präsentation als PPTX mit aktivierten ZIP64‑Format-Erweiterungen speichert:
```php
$pptxOptions = new PptxOptions();
$pptxOptions->setZip64Mode(Zip64Mode::Always);

$presentation = new Presentation("Sample.pptx");
try {
    $presentation->save("OutputZip64.pptx", SaveFormat::Pptx, $pptxOptions);
} finally {
    $presentation->dispose();
}
```


{{% alert title="HINWEIS" color="warning" %}}
Wenn Sie mit [Zip64Mode.Never] speichern, wird eine [PptxException] ausgelöst, falls die Präsentation nicht im ZIP32‑Format gespeichert werden kann.
{{% /alert %}}

## **Präsentationen speichern, ohne das Miniaturbild zu aktualisieren**

Die Methode [PptxOptions.setRefreshThumbnail] steuert die Erstellung des Miniaturbildes beim Speichern einer Präsentation im PPTX‑Format:

- Ist sie auf `true` gesetzt, wird das Miniaturbild beim Speichern aktualisiert. Dies ist die Vorgabe.
- Ist sie auf `false` gesetzt, bleibt das aktuelle Miniaturbild erhalten. Hat die Präsentation kein Miniaturbild, wird keines erzeugt.

Im folgenden Code wird die Präsentation in PPTX gespeichert, ohne ihr Miniaturbild zu aktualisieren.
```php
$pptxOptions = new PptxOptions();
$pptxOptions->setRefreshThumbnail(false);

$presentation = new Presentation("Sample.pptx");
try {
    $presentation->save("Output.pptx", SaveFormat::Pptx, $pptxOptions);
}
finally {
    $presentation->dispose();
}
```


{{% alert title="Info" color="info" %}}
Diese Option hilft, die zum Speichern einer Präsentation im PPTX-Format benötigte Zeit zu verkürzen.
{{% /alert %}}

## **Speicherfortschritt in Prozent aktualisieren**

Die Speicherfortschritts-Berichterstattung wird über die Methode [setProgressCallback] auf [SaveOptions] und deren Unterklassen konfiguriert. Geben Sie einen Java‑Proxy an, der das Interface [IProgressCallback] implementiert; während des Exports erhält der Callback periodische Prozent‑Updates.

Die folgenden Code‑Snippets zeigen, wie `IProgressCallback` verwendet wird.
```php
class ExportProgressHandler {
    function reporting($progressValue) {
        // Verwenden Sie hier den Prozentwert des Fortschritts.
        $progress = java("java.lang.Double")->valueOf($progressValue)->intValue();
        echo($progress . "% of the file has been converted.");
    }
}

$progressHandler = java_closure(new ExportProgressHandler(), null, java("com.aspose.slides.IProgressCallback"));

$saveOptions = new PdfOptions();
$saveOptions->setProgressCallback($progressHandler);

$presentation = new Presentation("Sample.pptx");
try {
    $presentation->save("Output.pdf", SaveFormat::Pdf, $saveOptions);
} finally {
    $presentation->dispose();
}
```


{{% alert title="Info" color="info" %}}
Aspose hat eine kostenlose PowerPoint‑Splitter‑App entwickelt, die seine eigene API verwendet. Die App ermöglicht es, eine Präsentation in mehrere Dateien zu splitten, indem ausgewählte Folien als neue PPTX‑ oder PPT‑Dateien gespeichert werden.
{{% /alert %}}

## **FAQ**

**Wird „Fast Save“ (inkrementelles Speichern) unterstützt, sodass nur Änderungen geschrieben werden?**

Nein. Beim Speichern wird jedes Mal die komplette Zieldatei erstellt; inkrementelles „Fast Save“ wird nicht unterstützt.

**Ist das Speichern derselben Presentation‑Instanz aus mehreren Threads threadsicher?**

Nein. Eine [Presentation]‑Instanz ist nicht threadsicher; speichern Sie sie aus einem einzelnen Thread.

**Was passiert mit Hyperlinks und extern verknüpften Dateien beim Speichern?**

[Hyperlinks] werden beibehalten. extern verknüpfte Dateien (z. B. Videos über relative Pfade) werden nicht automatisch kopiert – stellen Sie sicher, dass die referenzierten Pfade weiterhin zugänglich sind.

**Kann ich Dokument‑Metadaten (Autor, Titel, Unternehmen, Datum) festlegen/speichern?**

Ja. Standard‑[Dokumenteigenschaften] werden unterstützt und beim Speichern in die Datei geschrieben.