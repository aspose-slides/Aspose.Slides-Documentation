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
- Vorschaubild aktualisieren
- Speicherfortschritt
- PHP
- Aspose.Slides
description: "PowerPoint- und OpenDocument-Präsentationen in PHP mit Aspose.Slides in Dateien oder Streams speichern und die PPTX-Ausgabe sowie Fortschrittsberichte konfigurieren."
---
## **Übersicht**

Nachdem Sie eine Präsentation erstellt oder [eine vorhandene geöffnet](/slides/de/php-java/open-presentation/), verwenden Sie die [Presentation::save](https://reference.aspose.com/slides/de/php-java/aspose.slides/presentation/#save) Methode, um das Ergebnis zu schreiben. Aspose.Slides für PHP über Java kann eine Präsentation in einer Datei oder einem Stream in PowerPoint-, OpenDocument-, PDF- und anderen Formaten speichern. Die folgenden Abschnitte behandeln die Standard‑Speichervorgänge und die für die PPTX‑Ausgabe verfügbaren Optionen.

## **Präsentationen in Dateien speichern**

Um eine Präsentation in einer Datei zu speichern, übergeben Sie dem Aufruf der Methode [Presentation::save](https://reference.aspose.com/slides/de/php-java/aspose.slides/presentation/#save) den Ausgabepfad und einen [SaveFormat](https://reference.aspose.com/slides/de/php-java/aspose.slides/saveformat/)‑Wert. Der Formatwert bestimmt den Dateityp, den Aspose.Slides erstellt.

Das folgende Beispiel erstellt eine Präsentation und speichert sie als PPTX‑Datei:

```php
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;

$presentation = new Presentation();
try {
    // Inhalt der Präsentation hinzufügen oder ändern.
    $presentation->save("Output.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

## **Präsentationen im Originalformat speichern**

Für Beispiele zur Erkennung von Dateien und Streams, das Verhalten neu erstellter Präsentationen und die Unterscheidung zwischen Quell‑ und Ausgabeformaten siehe [Ermitteln des ursprünglichen Präsentationsformats](/slides/de/php-java/detect-presentation-source-format/).

In einer Batch‑Verarbeitungsanwendung ist das Eingabeformat möglicherweise nicht im Voraus bekannt. Nach dem Laden einer Datei lesen Sie das Originalformat über die Methode [Presentation::getSourceFormat](https://reference.aspose.com/slides/de/php-java/aspose.slides/presentation/#getSourceFormat). Übergeben Sie den resultierenden [SourceFormat](https://reference.aspose.com/slides/de/php-java/aspose.slides/sourceformat/)‑Wert an [SlideUtil::toSaveFormat](https://reference.aspose.com/slides/de/php-java/aspose.slides/slideutil/#toSaveFormat), um den entsprechenden [SaveFormat](https://reference.aspose.com/slides/de/php-java/aspose.slides/saveformat/)‑Wert zu erhalten, und verwenden Sie dann [Presentation::save](https://reference.aspose.com/slides/de/php-java/aspose.slides/presentation/#save), um die geänderte Präsentation zu schreiben.

Das folgende vollständige Beispiel verarbeitet jede Datei in einem Eingabeverzeichnis, aktualisiert ihren Titel und speichert sie in ein Ausgabeverzeichnis im Format, aus dem sie geladen wurde:

```php
use aspose\slides\Presentation;
use aspose\slides\SlideUtil;

$inputDirectory = __DIR__ . DIRECTORY_SEPARATOR . "Input";
$outputDirectory = __DIR__ . DIRECTORY_SEPARATOR . "Output";

if (!is_dir($outputDirectory) && !mkdir($outputDirectory, 0777, true)) {
    echo("Cannot create the output directory." . PHP_EOL);
}

$inputFiles = is_dir($inputDirectory) ? scandir($inputDirectory) : false;
if ($inputFiles !== false && is_dir($outputDirectory)) {
    foreach ($inputFiles as $fileName) {
        $inputPath = $inputDirectory . DIRECTORY_SEPARATOR . $fileName;
        if (!is_file($inputPath)) {
            continue;
        }

        $presentation = null;
        $presentationLoaded = false;
        try {
            $presentation = new Presentation($inputPath);
            $presentationLoaded = true;
            $saveFormat = SlideUtil::toSaveFormat($presentation->getSourceFormat());
            $presentation->getDocumentProperties()->setTitle("Processed by the batch application");

            $outputPath = $outputDirectory . DIRECTORY_SEPARATOR . $fileName;
            $presentation->save($outputPath, $saveFormat);
        } catch (\Throwable $exception) {
            echo("Cannot process '" . $inputPath . "': " . $exception->getMessage() . PHP_EOL);
        } finally {
            if ($presentationLoaded) {
                $presentation->dispose();
            }
        }
    }
}
```

[SlideUtil::toSaveFormat](https://reference.aspose.com/slides/de/php-java/aspose.slides/slideutil/#toSaveFormat) mappt PPT, PPTX, ODP, PPTM, PPSX, PPSM, POTX, POTM, PPS, POT, OTP, FODP und PowerPoint‑XML zu den entsprechenden Präsentations‑Speicherformaten. Es mappt nur Präsentations‑Quellformate; es ist nicht dazu gedacht, Exportformate wie PDF, HTML, TIFF oder Bilder auszuwählen. Die Übergabe eines nicht unterstützten oder ungültigen [SourceFormat](https://reference.aspose.com/slides/de/php-java/aspose.slides/sourceformat/)‑Wertes führt zu einer [IllegalArgumentException](https://docs.oracle.com/en/java/javase/16/docs/api/java.base/java/lang/IllegalArgumentException.html).

Legacy‑PPT-, PPS‑ und POT‑Dateien verwenden denselben Binärcontainer. Wenn eine solche Präsentation aus einem Stream ohne Dateierweiterung geladen wird, kann eine PPS‑ oder POT‑Datei daher als PPT identifiziert werden. Wenn das Beibehalten dieser Legacy‑Untertypen erforderlich ist, bewahren Sie den ursprünglichen Dateinamen oder die Format‑Metadaten separat auf und verwenden Sie diese bei der Auswahl des Ausgabedateinamens und -formats.

## **Präsentationen in Streams speichern**

Um eine Präsentation zu schreiben, ohne einen endgültigen Dateipfad zu benötigen, übergeben Sie einen beschreibbaren Stream und einen [SaveFormat](https://reference.aspose.com/slides/de/php-java/aspose.slides/saveformat/)‑Wert an die Methode [Presentation::save](https://reference.aspose.com/slides/de/php-java/aspose.slides/presentation/#save). Dieser Ansatz ist nützlich, wenn die Ausgabe von einem Webservice zurückgegeben, in einer Datenbank gespeichert oder im Speicher verarbeitet werden muss.

Das folgende Beispiel speichert eine neue Präsentation in einen Dateistream:

```php
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;

$presentation = new Presentation();
try {
    $outputStream = new Java("java.io.FileOutputStream", "Output.pptx");
    try {
        $presentation->save($outputStream, SaveFormat::Pptx);
    } finally {
        $outputStream->close();
    }
} finally {
    $presentation->dispose();
}
```

## **Präsentationen mit vordefiniertem Ansichtstyp speichern**

Sie können die Ansicht festlegen, in der PowerPoint eine gespeicherte Präsentation zunächst öffnet. Verwenden Sie vor dem Speichern die Methode [ViewProperties::setLastView](https://reference.aspose.com/slides/de/php-java/aspose.slides/viewproperties/#setLastView) mit einem [ViewType](https://reference.aspose.com/slides/de/php-java/aspose.slides/viewtype/)‑Wert.

Das folgende Beispiel konfiguriert die Folienmaster‑Ansicht als Anfangsansicht:

```php
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;
use aspose\slides\ViewType;

$presentation = new Presentation();
try {
    $presentation->getViewProperties()->setLastView(ViewType::SlideMasterView);
    $presentation->save("SlideMasterView.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

## **Präsentationen im strikten Office Open XML‑Format speichern**

Um eine PPTX‑Datei zu erstellen, die dem Strict‑Profil von Office Open XML entspricht, erzeugen Sie eine Instanz von [PptxOptions](https://reference.aspose.com/slides/de/php-java/aspose.slides/pptxoptions/) und verwenden deren Methode [PptxOptions::setConformance](https://reference.aspose.com/slides/de/php-java/aspose.slides/pptxoptions/#setConformance), wobei Sie [Conformance::Iso29500_2008_Strict](https://reference.aspose.com/slides/de/php-java/aspose.slides/conformance/#Iso29500-2008-Strict) übergeben. Anschließend übergeben Sie die Optionen an die Methode [Presentation::save](https://reference.aspose.com/slides/de/php-java/aspose.slides/presentation/#save).

```php
use aspose\slides\Conformance;
use aspose\slides\PptxOptions;
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;

$options = new PptxOptions();
$options->setConformance(Conformance::Iso29500_2008_Strict);

$presentation = new Presentation();
try {
    $presentation->save("StrictOfficeOpenXml.pptx", SaveFormat::Pptx, $options);
} finally {
    $presentation->dispose();
}
```

## **Präsentationen im Office Open XML‑Format im Zip64‑Modus speichern**

Ein Standard‑ZIP‑Archiv begrenzt die komprimierte und unkomprimierte Größe jedes Eintrags, die Gesamtagröße des Archivs und die Anzahl der Einträge. Da eine PPTX‑Datei ein ZIP‑Archiv ist, kann eine sehr große Präsentation diese Grenzen überschreiten. ZIP64‑Erweiterungen erhöhen die entsprechenden Größen‑ und Eintragsanzahl‑Grenzen.

Verwenden Sie die Methode [PptxOptions::setZip64Mode](https://reference.aspose.com/slides/de/php-java/aspose.slides/pptxoptions/#setZip64Mode), um zu steuern, ob Aspose.Slides ZIP64‑Erweiterungen schreibt:

- [IfNecessary](https://reference.aspose.com/slides/de/php-java/aspose.slides/zip64mode/#IfNecessary) verwendet ZIP64 nur, wenn die Präsentation die Standard‑ZIP‑Grenzen überschreitet. Dies ist der Standardmodus.
- [Never](https://reference.aspose.com/slides/de/php-java/aspose.slides/zip64mode/#Never) deaktiviert ZIP64‑Erweiterungen.
- [Always](https://reference.aspose.com/slides/de/php-java/aspose.slides/zip64mode/#Always) schreibt immer ZIP64‑Erweiterungen.

Das folgende Beispiel aktiviert ZIP64‑Erweiterungen für die Ausgabepäsentation immer:

```php
use aspose\slides\PptxOptions;
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;
use aspose\slides\Zip64Mode;

$presentation = new Presentation("Sample.pptx");
try {
    $options = new PptxOptions();
    $options->setZip64Mode(Zip64Mode::Always);

    $presentation->save("OutputZip64.pptx", SaveFormat::Pptx, $options);
} finally {
    $presentation->dispose();
}
```

{{% alert color="warning" title="Warning" %}}
Wenn [Zip64Mode::Never](https://reference.aspose.com/slides/de/php-java/aspose.slides/zip64mode/#Never) verwendet wird und die Präsentation nicht in die Standard‑ZIP‑Grenzen passt, löst der Speicher‑Vorgang eine [PptxException](https://reference.aspose.com/slides/de/php-java/aspose.slides/pptxexception/) aus.
{{% /alert %}}

## **Präsentationen im Office Open XML‑Format mit Komprimierungsstufen speichern**

Für PPTX‑Ausgaben können Sie die Speicher­geschwindigkeit gegen die Dateigröße abwägen, indem Sie die Methode [PptxOptions::setCompressionLevel](https://reference.aspose.com/slides/de/php-java/aspose.slides/pptxoptions/#setCompressionLevel) verwenden. Die Klasse [CompressionLevel](https://reference.aspose.com/slides/de/php-java/aspose.slides/compressionlevel/) bietet folgende Werte:

- [None](https://reference.aspose.com/slides/de/php-java/aspose.slides/compressionlevel/#None) speichert Daten ohne Kompression.
- [Level1](https://reference.aspose.com/slides/de/php-java/aspose.slides/compressionlevel/#Level1) bietet die schnellste Kompression und die größte komprimierte Ausgabe.
- [Level2](https://reference.aspose.com/slides/de/php-java/aspose.slides/compressionlevel/#Level2) bis [Level5](https://reference.aspose.com/slides/de/php-java/aspose.slides/compressionlevel/#Level5) bevorzugen zunehmend kleinere Ausgaben gegenüber der Speicher­geschwindigkeit.
- [Level6](https://reference.aspose.com/slides/de/php-java/aspose.slides/compressionlevel/#Level6) balanciert Speicher­geschwindigkeit und Dateigröße. Dies ist die Standardstufe.
- [Level7](https://reference.aspose.com/slides/de/php-java/aspose.slides/compressionlevel/#Level7) und [Level8](https://reference.aspose.com/slides/de/php-java/aspose.slides/compressionlevel/#Level8) bevorzugen weiter kleinere Ausgaben gegenüber der Speicher­geschwindigkeit.
- [Level9](https://reference.aspose.com/slides/de/php-java/aspose.slides/compressionlevel/#Level9) bietet die stärkste Kompression und erfordert die meiste Verarbeitungszeit.

Das folgende Beispiel speichert eine Präsentation ohne Kompression:

```php
use aspose\slides\CompressionLevel;
use aspose\slides\PptxOptions;
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;

$presentation = new Presentation("Sample.pptx");
try {
    $options = new PptxOptions();
    $options->setCompressionLevel(CompressionLevel::None);

    $presentation->save("OutputNoCompression.pptx", SaveFormat::Pptx, $options);
} finally {
    $presentation->dispose();
}
```

Das folgende Beispiel verwendet die maximale Komprimierungsstufe:

```php
use aspose\slides\CompressionLevel;
use aspose\slides\PptxOptions;
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;

$presentation = new Presentation("Sample.pptx");
try {
    $options = new PptxOptions();
    $options->setCompressionLevel(CompressionLevel::Level9);

    $presentation->save("OutputMaximumCompression.pptx", SaveFormat::Pptx, $options);
} finally {
    $presentation->dispose();
}
```

## **Präsentationen ohne Aktualisieren des Vorschaubildes speichern**

Wenn eine Präsentation als PPTX gespeichert wird, steuert die Methode [PptxOptions::setRefreshThumbnail](https://reference.aspose.com/slides/de/php-java/aspose.slides/pptxoptions/#setRefreshThumbnail) ihr Dokument‑Vorschaubild:

- `true` regeneriert das Vorschaubild während des Speicher‑Vorgangs. Dies ist der Standardwert.
- `false` bewahrt das vorhandene Vorschaubild. Hat die Präsentation kein Vorschaubild, erzeugt Aspose.Slides keines.

Das folgende Beispiel speichert eine Präsentation, ohne ihr Vorschaubild zu aktualisieren:

```php
use aspose\slides\PptxOptions;
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;

$presentation = new Presentation("Sample.pptx");
try {
    $options = new PptxOptions();
    $options->setRefreshThumbnail(false);

    $presentation->save("Output.pptx", SaveFormat::Pptx, $options);
} finally {
    $presentation->dispose();
}
```

{{% alert color="info" title="Note" %}}
Das Deaktivieren der Vorschaubild‑Aktualisierung kann die zum Speichern einer PPTX‑Datei erforderliche Zeit verkürzen.
{{% /alert %}}

## **Speicherfortschritt in Prozent aktualisieren**

Um einen Speicher‑Vorgang zu überwachen, stellen Sie einen Java‑Proxy bereit, der das [IProgressCallback](https://reference.aspose.com/slides/de/java/com.aspose.slides/iprogresscallback/)‑Interface implementiert, und übergeben Sie den Proxy an die Methode [SaveOptions::setProgressCallback](https://reference.aspose.com/slides/de/php-java/aspose.slides/saveoptions/#setProgressCallback). Aspose.Slides ruft dann die Methode [IProgressCallback::reporting](https://reference.aspose.com/slides/de/java/com.aspose.slides/iprogresscallback/#reporting-double-) mit Fortschrittswerten während des Exports auf.

Das folgende Beispiel meldet den Fortschritt eines PDF‑Exports in der Konsole:

```php
use aspose\slides\PdfOptions;
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;

class ExportProgressHandler {
    function reporting($progressValue) {
        $progress = java("java.lang.Double")->valueOf($progressValue)->intValue();
        echo($progress . "% of the file has been converted." . PHP_EOL);
    }
}

$progressHandler = java_closure(new ExportProgressHandler(), null, java("com.aspose.slides.IProgressCallback"));

$options = new PdfOptions();
$options->setProgressCallback($progressHandler);

$presentation = new Presentation("Sample.pptx");
try {
    $presentation->save("Output.pdf", SaveFormat::Pdf, $options);
} finally {
    $presentation->dispose();
}
```

{{% alert color="info" title="Note" %}}
Aspose stellt einen kostenlosen [PowerPoint Splitter](https://products.aspose.app/slides/de/splitter) bereit, der mit der Aspose.Slides‑API erstellt wurde. Er speichert ausgewählte Folien einer Präsentation als separate PPT‑ oder PPTX‑Dateien.
{{% /alert %}}

## **FAQ**

**Unterstützt Aspose.Slides inkrementelles oder „Fast‑Save“?**

Nein. Jeder Speicher‑Vorgang schreibt eine vollständige Ausgabedatei, anstatt nur die geänderten Teile zu aktualisieren.

**Können mehrere Threads dieselbe Presentation‑Instanz speichern?**

Nein. Eine [Presentation](https://reference.aspose.com/slides/de/php-java/aspose.slides/presentation/)‑Instanz [ist nicht thread‑sicher](/slides/de/php-java/multithreading/). Greifen Sie jeweils nur von einem Thread aus auf eine Instanz zu und speichern Sie sie.

**Was geschieht mit Hyperlinks und extern verknüpften Dateien, wenn ich eine Präsentation speichere?**

[Hyperlinks](/slides/de/php-java/manage-hyperlinks/) bleiben in der Präsentation erhalten. Aspose.Slides kopiert nicht extern verknüpfte Dateien, daher muss die gespeicherte Präsentation weiterhin Zugriff auf deren Speicherorte haben.

**Kann ich Dokumentmetadaten wie Autor, Titel, Firma und Erstellungsdatum speichern?**

Ja. Setzen Sie vor dem Speichern die entsprechenden [Dokumenteneigenschaften](/slides/de/php-java/presentation-properties/), und Aspose.Slides schreibt sie in die Ausgabedatei.