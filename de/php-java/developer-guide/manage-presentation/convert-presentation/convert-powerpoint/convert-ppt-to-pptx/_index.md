---
title: PPT nach PPTX in PHP konvertieren
linktitle: PPT zu PPTX
type: docs
weight: 20
url: /de/php-java/convert-ppt-to-pptx/
keywords:
- PowerPoint konvertieren
- Präsentation konvertieren
- Folie konvertieren
- PPT konvertieren
- PPT zu PPTX
- PPT als PPTX speichern
- PPT nach PPTX exportieren
- PowerPoint
- Präsentation
- PHP
- Aspose.Slides
description: "Konvertieren Sie veraltete PPT-Dateien in PPTX in PHP mit Aspose.Slides. Enthält PHP‑Beispiele für Einzeldatei‑ und Batch‑Konvertierung, Fehlerbehandlung und Genauigkeitshinweise."
---
## **Übersicht**

PPT ist das veraltete binäre PowerPoint-Format, während PPTX das neuere Open XML-Format ist. Aspose.Slides für PHP über Java kann eine PPT‑Datei laden und sie als PPTX speichern, ohne Microsoft PowerPoint zu benötigen. Dieser Artikel zeigt, wie man eine Datei oder ein Verzeichnis von Dateien konvertiert und erklärt, was nach der Konvertierung zu überprüfen ist.

## **Eine PPT-Datei in PPTX konvertieren**

Laden Sie die Quelldatei mit der Klasse [Presentation](https://reference.aspose.com/slides/de/php-java/aspose.slides/presentation/) und rufen Sie dann [Presentation::save](https://reference.aspose.com/slides/de/php-java/aspose.slides/presentation/#save) mit [SaveFormat::Pptx](https://reference.aspose.com/slides/de/php-java/aspose.slides/saveformat/#Pptx) auf. Der `finally`-Block gibt die Präsentation frei und gibt deren Ressourcen frei.

```php
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;

// Laden der veralteten PPT-Präsentation.
$presentation = new Presentation("presentation.ppt");
try {
    // Speichern der Präsentation im PPTX-Format.
    $presentation->save("presentation.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

Die Dateierweiterung bestimmt das Ausgabeformat nicht von allein; das Argument [SaveFormat::Pptx](https://reference.aspose.com/slides/de/php-java/aspose.slides/saveformat/#Pptx) tut es. Halten Sie Eingabe- und Ausgabepfade unterschiedlich, wenn Sie die ursprüngliche PPT‑Datei beibehalten müssen.

## **Mehrere PPT-Dateien konvertieren**

Das folgende Beispiel konvertiert jede `.ppt`‑Datei in einem Verzeichnis. Jede Datei wird unabhängig verarbeitet, sodass ein fehlgeschlagener Vorgang den Rest des Stapels nicht stoppt.

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

Für Produktionsszenarien sollten Sie die vollständige Ausnahme protokollieren, entscheiden, ob eine vorhandene Ausgabedatei überschrieben werden darf, und fehlgeschlagene Dateinamen in eine Wiederhol‑ oder Prüfwarteschlange schreiben. Beschädigte Dateien, passwortgeschützte Dateien, die ohne das erforderliche Passwort geöffnet werden, nicht zugängliche Pfade und nicht unterstützte Inhalte können alle eine Konvertierung fehlschlagen lassen. Siehe [Passwortgeschützte Präsentationen](/php-java/password-protected-presentation/) zum Laden verschlüsselter Dateien.

## **Genauigkeit und Legacy‑Funktionen**

Die Konvertierung bewahrt normalerweise Folien, Master, Layouts, Text, Formen, Bilder, Tabellen und Diagramme. Allerdings stellen PPT und PPTX nicht jedes Feature exakt gleich dar. Ein Legacy‑Feature, das kein PPTX‑Äquivalent hat oder von der Bibliothek nicht unterstützt wird, kann normalisiert, weggelassen oder anders dargestellt werden.

Überprüfen Sie die konvertierte Datei, wenn sie Animationen, Übergänge, eingebettete oder verknüpfte OLE‑Objekte, ActiveX‑Steuerelemente, eingebettete Medien, ungewöhnliche Schriften oder VBA‑Makros enthält. Eine reine PPTX‑Datei ist kein makrofähiges Format, daher sollten Sie einen entsprechenden makrofähigen Ablauf verwenden, wenn VBA erhalten bleiben muss. Stellen Sie außerdem sicher, dass erforderliche Schriften und externe Ressourcen in der Umgebung vorhanden sind, in der die konvertierte Präsentation geöffnet oder gerendert wird.

Für wichtige Dokumente öffnen Sie das erzeugte PPTX programmgesteuert erneut, prüfen Sie die wichtigsten Folienzahlen und Inhalte und vergleichen Sie dann Aussehen und Bildlaufverhalten im vorgesehenen Viewer. Betrachten Sie keinen erfolgreichen Aufruf von [Presentation::save](https://reference.aspose.com/slides/de/php-java/aspose.slides/presentation/#save) als Beweis dafür, dass jedes Legacy‑Feature eine exakte PPTX‑Darstellung hat.

## **Wann PPTX verwenden**

Verwenden Sie PPTX, wenn die Präsentation in aktuellen PowerPoint‑Versionen bearbeitet, mit Systemen ausgetauscht wird, die Open‑XML‑Pakete verwenden, oder in einem Format gespeichert werden soll, das leichter zu inspizieren und wiederherzustellen ist als das alte binäre PPT. Bewahren Sie das originale PPT als Archiv‑ oder Rollback‑Kopie auf, bis die konvertierte Präsentation Ihre Genauigkeitsprüfungen bestanden hat.

Wenn Sie stattdessen PDF, HTML, Bilder, XPS oder einen anderen Ausgabetyp benötigen, verwenden Sie die formatbezogene Anleitung in [Präsentationen in mehrere Formate konvertieren](/php-java/convert-presentation/), anstatt anzunehmen, dass alle Zielformate bearbeitbare PowerPoint‑Features erhalten.

## **Online‑Konverter**

Für eine einzelne Datei oder einen schnellen Vergleich können Sie den [Online-PPT‑zu‑PPTX‑Konverter](https://products.aspose.app/slides/de/conversion/ppt-to-pptx) verwenden. Für wiederholbare Konvertierungen, Batch‑Verarbeitung oder Anwendung‑ebenen‑Fehlerbehandlung nutzen Sie die PHP‑API.

## **Verwandte Artikel**

- [PPT vs PPTX](/php-java/ppt-vs-pptx/)
- [Präsentationen in PHP speichern](/php-java/save-presentation/)
- [Unterstützte Dateiformate](/php-java/supported-file-formats/)
- [Präsentationen in PHP öffnen](/php-java/open-presentation/)

## **FAQ**

**Kann ich PPT nach PPTX konvertieren, ohne dass Microsoft PowerPoint installiert ist?**

Ja. Aspose.Slides für PHP über Java lädt und speichert Präsentationsdateien, ohne dass Microsoft PowerPoint erforderlich ist.

**Wird die PPT‑zu‑PPTX‑Konvertierung den gesamten Inhalt exakt erhalten?**

Sie bewahrt den gängigen Präsentationsinhalt, aber eine exakte Treue ist für jedes Legacy‑ oder nicht unterstützte Feature nicht garantiert. Überprüfen Sie die erzeugte Datei, wenn sie Makros, OLE‑ oder ActiveX‑Objekte, Medien, spezialisierte Animationen oder ungewöhnliche Schriften enthält.

**Kann ich eine passwortgeschützte PPT‑Datei konvertieren?**

Ja, sofern Sie beim Laden der Datei das korrekte Passwort angeben. Ein fehlendes oder falsches Passwort führt zum Fehlschlagen des Ladevorgangs.

**Soll ich die PPT‑Datei nach der Konvertierung löschen?**

Bewahren Sie das Original auf, bis Sie das PPTX in den für Sie relevanten Viewern und Workflows verifiziert haben. Das bietet eine Rollback‑Kopie, falls ein Legacy‑Feature anders konvertiert wird.