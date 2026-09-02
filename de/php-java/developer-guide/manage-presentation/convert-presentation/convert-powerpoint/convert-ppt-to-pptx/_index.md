---
title: PPT zu PPTX in PHP konvertieren
linktitle: PPT zu PPTX
type: docs
weight: 20
url: /de/php-java/convert-ppt-to-pptx/
keywords:
- PowerPoint konvertieren
- Präsentation konvertieren
- Folien konvertieren
- PPT konvertieren
- PPT zu PPTX
- PPT als PPTX speichern
- PPT nach PPTX exportieren
- PowerPoint
- Präsentation
- PHP
- Aspose.Slides
description: "Konvertieren Sie Legacy-PPT-Dateien zu PPTX in PHP mit Aspose.Slides. Enthält PHP-Beispiele für Einzel- und Batch-Konvertierung, Fehlerbehandlung und Hinweise zur Genauigkeit."
---
## **Übersicht**

PPT ist das veraltete binäre PowerPoint-Format, während PPTX das neuere Open‑XML-Format ist. Aspose.Slides für PHP via Java kann eine PPT‑Datei laden und sie ohne Microsoft PowerPoint als PPTX speichern. Dieser Artikel zeigt, wie man eine Datei oder ein Verzeichnis von Dateien konvertiert und erklärt, was nach der Konvertierung zu überprüfen ist.

## **PPT-Datei in PPTX konvertieren**

Laden Sie die Quelldatei mit der Klasse [Presentation](https://reference.aspose.com/slides/de/php-java/aspose.slides/presentation/) und rufen Sie dann [Presentation::save](https://reference.aspose.com/slides/de/php-java/aspose.slides/presentation/#save) mit [SaveFormat::Pptx](https://reference.aspose.com/slides/de/php-java/aspose.slides/saveformat/#Pptx) auf. Der `finally`‑Block gibt die Präsentation frei und gibt ihre Ressourcen frei.

```php
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;

// Laden Sie die alte PPT-Präsentation.
$presentation = new Presentation("presentation.ppt");
try {
    // Speichern Sie die Präsentation im PPTX-Format.
    $presentation->save("presentation.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

Die Dateierweiterung bestimmt das Ausgabeformat nicht von selbst; das Argument [SaveFormat::Pptx](https://reference.aspose.com/slides/de/php-java/aspose.slides/saveformat/#Pptx) tut es. Halten Sie die Eingabe‑ und Ausgabe‑Pfadnamen unterschiedlich, wenn Sie die ursprüngliche PPT‑Datei behalten müssen.

## **Mehrere PPT-Dateien konvertieren**

Das folgende Beispiel konvertiert jede `.ppt`‑Datei in einem Verzeichnis. Jede Datei wird unabhängig verarbeitet, sodass ein fehlerhafter Konvertierungsvorgang den Rest der Stapelverarbeitung nicht stoppt.

```php
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;

$inputDirectory = "input";
$outputDirectory = "output";
if (!is_dir($outputDirectory) && !mkdir($outputDirectory, 0777, true)) {
    throw new RuntimeException("Cannot create the output directory: " . $outputDirectory);
}

$inputFiles = [];
foreach (new DirectoryIterator($inputDirectory) as $fileInfo) {
    if ($fileInfo->isFile() && strtolower($fileInfo->getExtension()) === "ppt") {
        $inputFiles[] = $fileInfo->getPathname();
    }
}

foreach ($inputFiles as $inputPath) {
    $outputFileName = pathinfo($inputPath, PATHINFO_FILENAME) . ".pptx";
    $outputPath = $outputDirectory . DIRECTORY_SEPARATOR . $outputFileName;
    $presentation = null;

    try {
        $presentation = new Presentation($inputPath);
        $presentation->save($outputPath, SaveFormat::Pptx);
        echo "Converted: " . $inputPath . PHP_EOL;
    } catch (Throwable $exception) {
        fwrite(STDERR, "Failed: " . $inputPath . " (" . $exception->getMessage() . ")" . PHP_EOL);
    } finally {
        if ($presentation !== null) {
            $presentation->dispose();
        }
    }
}
```

Für Produktionsszenarien sollten Sie die vollständige Ausnahme protokollieren, entscheiden, ob eine vorhandene Ausgabedatei überschrieben werden darf, und fehlgeschlagene Dateinamen in eine Wiederholungs‑ oder Prüfungswarteschlange schreiben. Beschädigte Dateien, passwortgeschützte Dateien, die ohne das erforderliche Passwort geöffnet werden, nicht zugängliche Pfade und nicht unterstützte Inhalte können eine Konvertierung zum Fehlschlagen bringen. Siehe [Passwortgeschützte Präsentationen](/slides/de/php-java/password-protected-presentation/) zum Laden verschlüsselter Dateien.

## **Genauigkeit und Legacy‑Funktionen**

Die Konvertierung bewahrt normalerweise Folien, Master, Layouts, Text, Formen, Bilder, Tabellen und Diagramme. Allerdings stellen PPT und PPTX nicht jedes Feature exakt auf die gleiche Weise dar. Ein Legacy‑Feature, für das es kein PPTX‑Äquivalent gibt oder das von der Bibliothek nicht unterstützt wird, kann normalisiert, weggelassen oder anders dargestellt werden.

Überprüfen Sie die konvertierte Datei, wenn sie Animationen, Übergänge, eingebettete oder verknüpfte OLE‑Objekte, ActiveX‑Steuerelemente, eingebettete Medien, ungewöhnliche Schriften oder VBA‑Makros enthält. Eine reine PPTX‑Datei ist kein makrofähiges Format, daher sollten Sie einen geeigneten makrofähigen Workflow verwenden, wenn VBA erhalten bleiben muss. Stellen Sie außerdem sicher, dass erforderliche Schriften und externe Ressourcen in der Umgebung vorhanden sind, in der die konvertierte Präsentation geöffnet oder gerendert wird.

Für wichtige Dokumente öffnen Sie die erzeugte PPTX programmgesteuert erneut und prüfen Sie die wichtigsten Folienzahlen und Inhalte, und vergleichen Sie dann ihr Aussehen sowie das Folien‑Show‑Verhalten im vorgesehenen Viewer. Behandeln Sie einen erfolgreichen Aufruf von [Presentation::save](https://reference.aspose.com/slides/de/php-java/aspose.slides/presentation/#save) nicht als Nachweis, dass jedes Legacy‑Feature eine exakte PPTX‑Darstellung hat.

## **Wann PPTX verwenden**

Verwenden Sie PPTX, wenn die Präsentation in aktuellen PowerPoint‑Versionen bearbeitet, mit Systemen ausgetauscht wird, die Open‑XML‑Pakete verarbeiten, oder in einem Format gespeichert werden soll, das leichter zu inspizieren und wiederherzustellen ist als das alte binäre PPT. Bewahren Sie das ursprüngliche PPT als Archiv‑ oder Rollback‑Kopie auf, bis die konvertierte Präsentation Ihre Genauigkeitsprüfungen bestanden hat.

Falls Sie stattdessen PDF, HTML, Bilder, XPS oder einen anderen Ausgabetyp benötigen, nutzen Sie die formatbezogene Anleitung in [Präsentationen in mehrere Formate konvertieren](/slides/de/php-java/convert-presentation/), anstatt anzunehmen, dass alle Zielformate bearbeitbare PowerPoint‑Features erhalten.

## **Online‑Konverter**

Für eine gelegentliche Datei oder einen schnellen Vergleich können Sie den [online PPT to PPTX converter](https://products.aspose.app/slides/de/conversion/ppt-to-pptx) verwenden. Für wiederholbare Konvertierungen, Stapelverarbeitung oder Anwendungen‑fehlerbehandlung nutzen Sie die PHP‑API.

## **Verwandte Artikel**

- [PPT vs PPTX](/slides/de/php-java/ppt-vs-pptx/)
- [Präsentationen in PHP speichern](/slides/de/php-java/save-presentation/)
- [Unterstützte Dateiformate](/slides/de/php-java/supported-file-formats/)
- [Präsentationen in PHP öffnen](/slides/de/php-java/open-presentation/)

## **FAQ**

**Kann ich PPT in PPTX konvertieren, ohne dass Microsoft PowerPoint installiert ist?**

Ja. Aspose.Slides für PHP via Java lädt und speichert Präsentationsdateien, ohne dass Microsoft PowerPoint erforderlich ist.

**Wird die PPT‑zu‑PPTX‑Konvertierung den gesamten Inhalt exakt erhalten?**

Sie bewahrt den üblichen Präsentationsinhalt, aber eine exakte Treue ist nicht für jedes Legacy‑ oder nicht unterstützte Feature garantiert. Überprüfen Sie die erzeugte Datei, wenn sie Makros, OLE‑ oder ActiveX‑Objekte, Medien, spezialisierte Animationen oder ungewöhnliche Schriften enthält.

**Kann ich eine passwortgeschützte PPT‑Datei konvertieren?**

Ja, sofern Sie beim Laden der Datei das richtige Passwort angeben. Ein fehlendes oder falsches Passwort führt zum Fehlschlag des Ladevorgangs.

**Soll ich die PPT‑Datei nach der Konvertierung löschen?**

Behalten Sie das Original, bis Sie die PPTX in den für Sie relevanten Viewern und Workflows überprüft haben. Dies bietet eine Rollback‑Kopie, falls ein Legacy‑Feature anders konvertiert wird.