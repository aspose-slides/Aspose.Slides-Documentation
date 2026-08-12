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
- Strict Office Open XML-Format
- Zip64-Modus
- Miniaturbild aktualisieren
- Speicherfortschritt
- PHP
- Aspose.Slides
description: "Erfahren Sie, wie Sie Präsentationen mit Aspose.Slides für PHP über Java speichern — exportieren Sie nach PowerPoint oder OpenDocument und behalten dabei Layouts, Schriftarten und Effekte bei."
---
## **Übersicht**

[Open Presentations in PHP](/slides/de/php-java/open-presentation/) beschrieb, wie die [Presentation](https://reference.aspose.com/slides/de/php-java/aspose.slides/presentation/) Klasse zum Öffnen einer Präsentation verwendet wird. Dieser Artikel erklärt, wie man Präsentationen erstellt und speichert. Die [Presentation](https://reference.aspose.com/slides/de/php-java/aspose.slides/presentation/) Klasse enthält den Inhalt einer Präsentation. Egal, ob Sie eine Präsentation von Grund auf neu erstellen oder eine bestehende ändern, Sie möchten sie am Ende speichern. Mit Aspose.Slides für PHP können Sie in eine **Datei** oder **Stream** speichern. Dieser Artikel erklärt die verschiedenen Möglichkeiten, eine Präsentation zu speichern.

## **Präsentationen in Dateien speichern**

Speichern Sie eine Präsentation in einer Datei, indem Sie die `save`‑Methode der [Presentation](https://reference.aspose.com/slides/de/php-java/aspose.slides/presentation/) Klasse aufrufen. Übergeben Sie dem Aufruf den Dateinamen und das Speicherformat. Das folgende Beispiel zeigt, wie man eine Präsentation mit Aspose.Slides speichert.

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

Sie können eine Präsentation in einen Stream speichern, indem Sie einen Ausgabestream an die `save`‑Methode der [Presentation](https://reference.aspose.com/slides/de/php-java/aspose.slides/presentation/) Klasse übergeben. Eine Präsentation kann in viele Stream‑Typen geschrieben werden. Im folgenden Beispiel erstellen wir eine neue Präsentation und speichern sie in einen Dateistream.

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

Aspose.Slides ermöglicht es Ihnen, die anfängliche Ansicht festzulegen, die PowerPoint verwendet, wenn die erzeugte Präsentation geöffnet wird, über die [ViewProperties](https://reference.aspose.com/slides/de/php-java/aspose.slides/viewproperties/) Klasse. Verwenden Sie die [setLastView](https://reference.aspose.com/slides/de/php-java/aspose.slides/viewproperties/#setLastView) Methode mit einem Wert aus der [ViewType](https://reference.aspose.com/slides/de/php-java/aspose.slides/viewtype/) Aufzählung.

```php
$presentation = new Presentation();
try {
    $presentation->getViewProperties()->setLastView(ViewType::SlideMasterView);
    $presentation->save("SlideMasterView.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

## **Präsentationen im Strict Office Open XML-Format speichern**

Aspose.Slides ermöglicht das Speichern einer Präsentation im Strict Office Open XML‑Format. Verwenden Sie die [PptxOptions](https://reference.aspose.com/slides/de/php-java/aspose.slides/pptxoptions/) Klasse und setzen Sie beim Speichern deren Conformance‑Eigenschaft. Wenn Sie [Conformance.Iso29500_2008_Strict](https://reference.aspose.com/slides/de/php-java/aspose.slides/conformance/#Iso29500_2008_Strict) festlegen, wird die Ausgabedatei im Strict Office Open XML‑Format gespeichert.

Das nachstehende Beispiel erstellt eine Präsentation und speichert sie im Strict Office Open XML‑Format.

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

Eine Office Open XML‑Datei ist ein ZIP‑Archiv, das Obergrenzen von 4 GB (2^32 Bytes) für die unkomprimierte Größe einer Datei, die komprimierte Größe einer Datei und die Gesamtgröße des Archivs festlegt und zudem das Archiv auf 65.535 (2^16‑1) Dateien begrenzt. ZIP64‑Formaterweiterungen erhöhen diese Grenzen auf 2^64.

Die [PptxOptions.setZip64Mode](https://reference.aspose.com/slides/de/php-java/aspose.slides/pptxoptions/#setZip64Mode) Methode ermöglicht die Auswahl, wann ZIP64‑Formaterweiterungen beim Speichern einer Office Open XML‑Datei verwendet werden sollen.

Diese Methode kann mit den folgenden Modi verwendet werden:
- [IfNecessary](https://reference.aspose.com/slides/de/php-java/aspose.slides/zip64mode/#IfNecessary) verwendet ZIP64‑Formaterweiterungen nur, wenn die Präsentation die oben genannten Beschränkungen überschreitet. Dies ist der Standardmodus.
- [Never](https://reference.aspose.com/slides/de/php-java/aspose.slides/zip64mode/#Never) verwendet niemals ZIP64‑Formaterweiterungen.
- [Always](https://reference.aspose.com/slides/de/php-java/aspose.slides/zip64mode/#Always) verwendet stets ZIP64‑Formaterweiterungen.

Der folgende Code zeigt, wie man eine Präsentation als PPTX‑Datei mit aktivierten ZIP64‑Formaterweiterungen speichert:

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

{{% alert title="NOTE" color="warning" %}}
Wenn Sie mit [Zip64Mode.Never](https://reference.aspose.com/slides/de/php-java/aspose.slides/zip64mode/#Never) speichern, wird eine [PptxException](https://reference.aspose.com/slides/de/php-java/aspose.slides/pptxexception/) ausgelöst, wenn die Präsentation nicht im ZIP32‑Format gespeichert werden kann.
{{% /alert %}}

## **Präsentationen im Office Open XML-Format mit Komprimierungsstufen speichern**

Bei der Arbeit mit großen Präsentationen können Sie die Komprimierungsstufe anpassen, um Dateigröße und Verarbeitungszeit auszubalancieren. Je nach Ihren Anforderungen bevorzugen Sie möglicherweise schnellere Verarbeitung oder kleinere Ausgabedateien.

Aspose.Slides stellt die [PptxOptions.setCompressionLevel](https://reference.aspose.com/slides/de/php-java/aspose.slides/pptxoptions/#setCompressionLevel) Methode bereit, mit der Sie die beim Speichern einer Präsentation im Office Open XML‑Format zu verwendende Komprimierungsstufe festlegen können.

Die folgenden Komprimierungsstufen stehen zur Verfügung:
- [**None**](https://reference.aspose.com/slides/de/php-java/aspose.slides/compressionlevel/#None): Es wird keine Kompression angewendet. Dateien werden unverändert gespeichert.
- [**Level1**](https://reference.aspose.com/slides/de/php-java/aspose.slides/compressionlevel/#Level1): Die schnellste Kompression mit dem niedrigsten Kompressionsverhältnis.
- [**Level2**](https://reference.aspose.com/slides/de/php-java/aspose.slides/compressionlevel/#Level2): Schnellere Kompression mit einem etwas besseren Kompressionsverhältnis als **Level1**.
- [**Level3**](https://reference.aspose.com/slides/de/php-java/aspose.slides/compressionlevel/#Level3): Bietet bessere Kompression als **Level2** bei moderatem Einfluss auf die Verarbeitungszeit.
- [**Level4**](https://reference.aspose.com/slides/de/php-java/aspose.slides/compressionlevel/#Level4): Bietet bessere Kompression als **Level3**.
- [**Level5**](https://reference.aspose.com/slides/de/php-java/aspose.slides/compressionlevel/#Level5): Bietet verbesserte Kompression gegenüber **Level4** mit zusätzlicher Verarbeitungszeit.
- [**Level6**](https://reference.aspose.com/slides/de/php-java/aspose.slides/compressionlevel/#Level6): Standardkompression, die ein gutes Gleichgewicht zwischen Verarbeitungsgeschwindigkeit und Dateigröße bietet. Dies ist die *Standardkompressionsstufe*.
- [**Level7**](https://reference.aspose.com/slides/de/php-java/aspose.slides/compressionlevel/#Level7): Bietet bessere Kompression als **Level6** bei langsamerer Verarbeitung.
- [**Level8**](https://reference.aspose.com/slides/de/php-java/aspose.slides/compressionlevel/#Level8): Bietet bessere Kompression als **Level7**.
- [**Level9**](https://reference.aspose.com/slides/de/php-java/aspose.slides/compressionlevel/#Level9): Maximale Kompression. Erzeugt die kleinste Dateigröße, jedoch zu Lasten der längsten Verarbeitungszeit.

Das folgende Beispiel demonstriert, wie man eine Präsentation als PPTX‑Datei *ohne Kompression* speichert:

```php
$pptxOptions = new PptxOptions();
$pptxOptions->setCompressionLevel(CompressionLevel::None);

$presentation = new Presentation("Sample.pptx");
try {
    $presentation->save("Sample-out.pptx", SaveFormat::Pptx, $pptxOptions);
} finally {
    $presentation->dispose();
}
```

Dieses Beispiel zeigt, wie man eine Präsentation als PPTX‑Datei mit *maximaler Kompression* speichert:

```php
$pptxOptions = new PptxOptions();
$pptxOptions->setCompressionLevel(CompressionLevel::Level9);

$presentation = new Presentation("Sample.pptx");
try {
    $presentation->save("Sample-level9.pptx", SaveFormat::Pptx, $pptxOptions);
} finally {
    $presentation->dispose();
}
```

## **Präsentationen ohne Aktualisierung des Miniaturbilds speichern**

Die [PptxOptions.setRefreshThumbnail](https://reference.aspose.com/slides/de/php-java/aspose.slides/pptxoptions/#setRefreshThumbnail) Methode steuert die Miniaturbildgenerierung beim Speichern einer Präsentation als PPTX:
- Wenn auf `true` gesetzt, wird das Miniaturbild beim Speichern aktualisiert. Dies ist die Standardeinstellung.
- Wenn auf `false` gesetzt, bleibt das aktuelle Miniaturbild erhalten. Hat die Präsentation kein Miniaturbild, wird keines erzeugt.

Im nachstehenden Code wird die Präsentation als PPTX gespeichert, ohne ihr Miniaturbild zu aktualisieren.

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
Diese Option hilft, die zum Speichern einer Präsentation im PPTX‑Format erforderliche Zeit zu reduzieren.
{{% /alert %}}

## **Speicherfortschrittsaktualisierungen in Prozent speichern**

Die Berichterstattung über den Speicherfortschritt wird über die [setProgressCallback](https://reference.aspose.com/slides/de/php-java/aspose.slides/saveoptions/#setProgressCallback) Methode von [SaveOptions](https://reference.aspose.com/slides/de/php-java/aspose.slides/saveoptions/) und dessen Unterklassen konfiguriert. Stellen Sie einen Java‑Proxy bereit, der das [IProgressCallback](https://reference.aspose.com/slides/de/java/com.aspose.slides/iprogresscallback/) Interface implementiert; während des Exports erhält der Callback periodische Prozent‑Updates.

Die folgenden Code‑Snippets zeigen, wie `IProgressCallback` verwendet wird.

```php
class ExportProgressHandler {
    function reporting($progressValue) {
        // Verwenden Sie hier den Fortschrittsprozentsatz.
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
Aspose hat eine [kostenlose PowerPoint Splitter‑App](https://products.aspose.app/slides/de/splitter) mit seiner eigenen API entwickelt. Die App ermöglicht es, eine Präsentation in mehrere Dateien zu splitten, indem ausgewählte Folien als neue PPTX‑ oder PPT‑Dateien gespeichert werden.
{{% /alert %}}

## **FAQ**

**Wird „schnelles Speichern“ (inkrementelles Speichern) unterstützt, sodass nur Änderungen geschrieben werden?**

Nein. Beim Speichern wird jedes Mal die vollständige Zieldatei erstellt; inkrementelles „schnelles Speichern“ wird nicht unterstützt.

**Ist das gleichzeitige Speichern derselben Presentation‑Instanz aus mehreren Threads thread‑sicher?**

Nein. Eine [Presentation](https://reference.aspose.com/slides/de/php-java/aspose.slides/presentation/) Instanz [ist nicht thread‑sicher](/slides/de/php-java/multithreading/); speichern Sie sie aus einem einzelnen Thread.

**Was passiert mit Hyperlinks und extern verlinkten Dateien beim Speichern?**

[Hyperlinks](/slides/de/php-java/manage-hyperlinks/) bleiben erhalten. Extern verlinkte Dateien (z. B. Videos über relative Pfade) werden nicht automatisch kopiert – stellen Sie sicher, dass die referenzierten Pfade weiterhin zugänglich sind.

**Kann ich Dokument‑Metadaten (Autor, Titel, Firma, Datum) setzen/speichern?**

Ja. Standard‑[Dokumenteneigenschaften](/slides/de/php-java/presentation-properties/) werden unterstützt und beim Speichern in die Datei geschrieben.