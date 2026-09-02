---
title: Präsentationsinformationen in PHP abrufen und aktualisieren
linktitle: Präsentationsinformationen
type: docs
weight: 30
url: /de/php-java/examine-presentation/
keywords:
- Präsentationsformat
- Präsentationseigenschaften
- Dokumenteigenschaften
- Eigenschaften abrufen
- Eigenschaften lesen
- Eigenschaften ändern
- Eigenschaften modifizieren
- Eigenschaften aktualisieren
- PPTX untersuchen
- PPT untersuchen
- ODP untersuchen
- PowerPoint
- OpenDocument
- Präsentation
- PHP
- Aspose.Slides
description: "Untersuchen Sie Folien, Struktur und Metadaten in PowerPoint- und OpenDocument-Präsentationen mit Aspose.Slides für PHP für schnellere Erkenntnisse und intelligentere Inhaltsprüfungen."
---
## **Übersicht**

Aspose.Slides kann das Format einer Präsentation erkennen und die Dokumentmetadaten auslesen, ohne ein vollständiges Präsentationsobjektmodell zu erstellen. Das ist nützlich, wenn Sie Dateien klassifizieren, ein Inventar erstellen oder Eigenschaften prüfen müssen, bevor Sie entscheiden, ob Sie den Präsentationsinhalt laden und verarbeiten.

Dieser Artikel demonstriert die leichte Inspektion über [PresentationFactory](https://reference.aspose.com/slides/de/php-java/aspose.slides/presentationfactory/) und [PresentationInfo](https://reference.aspose.com/slides/de/php-java/aspose.slides/presentationinfo/), sowie gezielte Aktualisierungen über [DocumentProperties](https://reference.aspose.com/slides/de/php-java/aspose.slides/documentproperties/).

## **Prüfen des Präsentationsformats**

Verwenden Sie [PresentationFactory::getPresentationInfo](https://reference.aspose.com/slides/de/php-java/aspose.slides/presentationfactory/), um eine Datei zu inspizieren, ohne eine [Presentation](https://reference.aspose.com/slides/de/php-java/aspose.slides/presentation/)‑Instanz zu erstellen. Die Methode [PresentationInfo::getLoadFormat](https://reference.aspose.com/slides/de/php-java/aspose.slides/presentationinfo/#getLoadFormat) gibt das erkannte Format zurück, z. B. PPTX, PPT oder ODP.

```php
use aspose\slides\LoadFormat;
use aspose\slides\PresentationFactory;

$fileNames = ["pres.pptx", "pres.ppt", "pres.odp"];

foreach ($fileNames as $fileName) {
    $presentationInfo = PresentationFactory::getInstance()->getPresentationInfo($fileName);
    $loadFormat = java_values($presentationInfo->getLoadFormat());
    $formatName = "Other (" . $loadFormat . ")";

    if ($loadFormat === LoadFormat::Pptx) {
        $formatName = "PPTX";
    } elseif ($loadFormat === LoadFormat::Ppt) {
        $formatName = "PPT";
    } elseif ($loadFormat === LoadFormat::Odp) {
        $formatName = "ODP";
    }

    echo $fileName . ": " . $formatName . PHP_EOL;
}
```

## **Erstellen eines leichten Präsentationsinventars**

Wenn Sie viele Präsentationsdateien verarbeiten, benötigen Sie möglicherweise ein kompaktes Inventar zur Validierung, Indexierung oder für ein Dokumenten‑Management‑System. In diesem Szenario verwenden Sie [PresentationFactory::getPresentationInfo](https://reference.aspose.com/slides/de/php-java/aspose.slides/presentationfactory/), um ein [PresentationInfo](https://reference.aspose.com/slides/de/php-java/aspose.slides/presentationinfo/)-Objekt zu erhalten, und rufen dann [PresentationInfo::readDocumentProperties](https://reference.aspose.com/slides/de/php-java/aspose.slides/presentationinfo/#readDocumentProperties) auf, um die Dokumentmetadaten auszulesen. Dieser Ansatz erstellt keine [Presentation](https://reference.aspose.com/slides/de/php-java/aspose.slides/presentation/)-Instanz und erfordert nicht, das gesamte Präsentationsobjektmodell zu durchlaufen.

Die von [DocumentProperties](https://reference.aspose.com/slides/de/php-java/aspose.slides/documentproperties/) bereitgestellten erweiterten Eigenschaften liefern die folgenden Inventarwerte:

| Methode | Inventarwert |
| --- | --- |
| [getSlides](https://reference.aspose.com/slides/de/php-java/aspose.slides/documentproperties/#getSlides) | Gesamtzahl der Folien. |
| [getHiddenSlides](https://reference.aspose.com/slides/de/php-java/aspose.slides/documentproperties/#getHiddenSlides) | Anzahl versteckter Folien. |
| [getNotes](https://reference.aspose.com/slides/de/php-java/aspose.slides/documentproperties/#getNotes) | Anzahl der Folien, die Notizen enthalten. |
| [getParagraphs](https://reference.aspose.com/slides/de/php-java/aspose.slides/documentproperties/#getParagraphs) | Gesamtzahl der Absätze, sofern verfügbar. |
| [getWords](https://reference.aspose.com/slides/de/php-java/aspose.slides/documentproperties/#getWords) | Gesamtzahl der Wörter. |
| [getMultimediaClips](https://reference.aspose.com/slides/de/php-java/aspose.slides/documentproperties/#getMultimediaClips) | Gesamtzahl von Audio‑ und Videoclips. |

Das folgende Beispiel liest diese Werte, ohne ein [Presentation](https://reference.aspose.com/slides/de/php-java/aspose.slides/presentation/)‑Objekt zu erstellen, und gibt ein kompaktes Inventar aus. Es kombiniert außerdem [DocumentProperties::getHeadingPairs](https://reference.aspose.com/slides/de/php-java/aspose.slides/documentproperties/#getHeadingPairs) mit [DocumentProperties::getTitlesOfParts](https://reference.aspose.com/slides/de/php-java/aspose.slides/documentproperties/#getTitlesOfParts), um Inhaltsgruppen wie Schriften, Designs und Folientitel anzuzeigen.

```php
use aspose\slides\LoadFormat;
use aspose\slides\PresentationFactory;

$filePath = "sample.pptx";
$presentationInfo = PresentationFactory::getInstance()->getPresentationInfo($filePath);
$documentProperties = $presentationInfo->readDocumentProperties();

$loadFormat = java_values($presentationInfo->getLoadFormat());
$formatName = "Other (" . $loadFormat . ")";

if ($loadFormat === LoadFormat::Pptx) {
    $formatName = "PPTX";
} elseif ($loadFormat === LoadFormat::Ppt) {
    $formatName = "PPT";
} elseif ($loadFormat === LoadFormat::Odp) {
    $formatName = "ODP";
}

echo "File: " . basename($filePath) . PHP_EOL;
echo "Format: " . $formatName . PHP_EOL;
echo "Title: " . java_values($documentProperties->getTitle()) . PHP_EOL;
echo "Author: " . java_values($documentProperties->getAuthor()) . PHP_EOL;
echo "Statistics:" . PHP_EOL;
echo "  Slides: " . java_values($documentProperties->getSlides()) . PHP_EOL;
echo "  Hidden slides: " . java_values($documentProperties->getHiddenSlides()) . PHP_EOL;
echo "  Slides with notes: " . java_values($documentProperties->getNotes()) . PHP_EOL;
echo "  Paragraphs: " . java_values($documentProperties->getParagraphs()) . PHP_EOL;
echo "  Words: " . java_values($documentProperties->getWords()) . PHP_EOL;
echo "  Multimedia clips: " . java_values($documentProperties->getMultimediaClips()) . PHP_EOL;

$headingPairs = $documentProperties->getHeadingPairs();
$titlesOfParts = $documentProperties->getTitlesOfParts();

if (java_is_null($headingPairs) || java_is_null($titlesOfParts)) {
    echo "Content groups: not available" . PHP_EOL;
} else {
    $headingPairs = java_values($headingPairs);
    $titlesOfParts = java_values($titlesOfParts);
    $partIndex = 0;

    if (count($headingPairs) === 0 || count($titlesOfParts) === 0) {
        echo "Content groups: not available" . PHP_EOL;
    } else {
        echo "Content groups:" . PHP_EOL;

        foreach ($headingPairs as $headingPair) {
            $partCount = java_values($headingPair->getCount());
            echo "  " . java_values($headingPair->getName()) . " (" . $partCount . ")" . PHP_EOL;

            for ($partOffset = 0; $partOffset < $partCount && $partIndex < count($titlesOfParts); $partOffset++) {
                echo "    - " . $titlesOfParts[$partIndex] . PHP_EOL;
                $partIndex++;
            }
        }

        if ($partIndex < count($titlesOfParts)) {
            echo "  Other parts:" . PHP_EOL;

            while ($partIndex < count($titlesOfParts)) {
                echo "    - " . $titlesOfParts[$partIndex] . PHP_EOL;
                $partIndex++;
            }
        }
    }
}
```

Jedes [HeadingPair](https://reference.aspose.com/slides/de/php-java/aspose.slides/headingpair/) liefert einen Gruppennamen und die Anzahl der Elemente in dieser Gruppe. [DocumentProperties::getTitlesOfParts](https://reference.aspose.com/slides/de/php-java/aspose.slides/documentproperties/#getTitlesOfParts) gibt ein flaches, geordnetes Array zurück, sodass die Anzahl aufeinanderfolgender Titel, die durch jedes HeadingPair angegeben wird, konsumiert werden muss.

### **Gespeicherte Metadaten und Formatbeschränkungen**

Die von [PresentationInfo::readDocumentProperties](https://reference.aspose.com/slides/de/php-java/aspose.slides/presentationinfo/#readDocumentProperties) zurückgegebenen Inventareigenschaften spiegeln die im Quell-Dokument verfügbaren Metadaten wider. Aspose.Slides lädt das Präsentationsobjektmodell nicht und durchläuft es nicht, um diese Werte für diesen Aufruf neu zu berechnen. Fehlende Eigenschaften werden durch Standardwerte dargestellt, und gespeicherte Werte können veraltet sein, wenn die Anwendung, die die Datei zuletzt gespeichert hat, ihre Dokumenteigenschaften nicht aktualisiert hat.

- **PPTX:** Das Format stellt erweiterte Dokumenteigenschaften für Folien‑, Notiz‑, versteckte‑Folien‑, Absatz‑, Wort‑ und Multimedia‑Zählungen sowie Heading‑Pairs und Teil‑Titel bereit. Die Verfügbarkeit hängt davon ab, welche Eigenschaften vom Dokumentersteller geschrieben wurden.
- **PPT:** Das Binärformat kann entsprechende Dokument‑Zusammenfassungs‑Eigenschaften speichern. Ist eine Eigenschaft nicht vorhanden oder wurde vom Dokumentersteller nicht aktualisiert, gibt Aspose.Slides ihren gespeicherten oder Standardwert zurück, anstatt ihn aus den Folien zu berechnen.
- **ODP:** OpenDocument‑Metadaten bieten allgemeine Dokumentstatistiken wie Seiten‑, Absatz‑ und Wort‑Zählungen, aber diese Werte lassen sich nicht auf jede PowerPoint‑spezifische erweiterte Eigenschaft abbilden. Metadaten für versteckte Folien, Notiz‑Folien, Multimedia, Heading‑Pairs und Teil‑Titel können fehlen, und die Inventareigenschaften können Standardwerte zurückgeben. Behandeln Sie keinen Nullwert oder ein leeres Array als eindeutigen Nachweis dafür, dass der entsprechende Inhalt fehlt.

Verwenden Sie den leichten Metadaten‑Ansatz für Inventare und Vorprüfungen. Laden Sie die Präsentation und prüfen Sie ihr Live‑Objektmodell, wenn das Ergebnis Änderungen im Arbeitsspeicher widerspiegeln muss oder wenn Sie den tatsächlichen Präsentationsinhalt verifizieren müssen.

## **Aktualisieren von Präsentationseigenschaften**

Die von [PresentationInfo::readDocumentProperties](https://reference.aspose.com/slides/de/php-java/aspose.slides/presentationinfo/#readDocumentProperties) zurückgegebenen Eigenschaften können ebenfalls geändert werden, ohne eine [Presentation](https://reference.aspose.com/slides/de/php-java/aspose.slides/presentation/)‑Instanz zu erstellen. Wenden Sie die Änderungen mit [PresentationInfo::updateDocumentProperties](https://reference.aspose.com/slides/de/php-java/aspose.slides/presentationinfo/#updateDocumentProperties) an und schreiben Sie die gebundene Präsentation mit [PresentationInfo::writeBindedPresentation](https://reference.aspose.com/slides/de/php-java/aspose.slides/presentationinfo/#writeBindedPresentation).

Das folgende Bild zeigt die ursprünglichen Dokumenteigenschaften.

![Original document properties of the PowerPoint presentation](input_properties.png)

Das folgende Beispiel ändert den Titel und die zuletzt gespeicherte Zeit und schreibt das Ergebnis in eine neue Datei:

```php
use aspose\slides\PresentationFactory;

$sourceFile = "sample.pptx";
$outputFile = "sample_with_updated_properties.pptx";
$presentationInfo = PresentationFactory::getInstance()->getPresentationInfo($sourceFile);
$documentProperties = $presentationInfo->readDocumentProperties();

$documentProperties->setTitle("Quarterly sales report");
$documentProperties->setLastSavedTime(new Java("java.util.Date"));

$presentationInfo->updateDocumentProperties($documentProperties);
$outputStream = new Java("java.io.FileOutputStream", $outputFile);
try {
    $presentationInfo->writeBindedPresentation($outputStream);
} finally {
    $outputStream->close();
}
```

Das folgende Bild zeigt die aktualisierten Dokumenteigenschaften.

![Changed document properties of the PowerPoint presentation](output_properties.png)

## **Nützliche Links**

Für verwandte Sicherheitsprüfungen und Schutzeinstellungen siehe die folgenden Artikel:

- [Password-Protect Presentations](/slides/de/php-java/password-protected-presentation/)
- [Write-Protect Presentations](/slides/de/php-java/write-protected-presentation/)

## **FAQ**

**Wie kann ich prüfen, ob Schriften eingebettet sind und welche das sind?**

Laden Sie die Präsentation und verwenden Sie [Presentation::getFontsManager](https://reference.aspose.com/slides/de/php-java/aspose.slides/presentation/#getFontsManager). Rufen Sie [FontsManager::getEmbeddedFonts](https://reference.aspose.com/slides/de/php-java/aspose.slides/fontsmanager/#getEmbeddedFonts) auf, um die eingebetteten Schriften zu erhalten, und [FontsManager::getFonts](https://reference.aspose.com/slides/de/php-java/aspose.slides/fontsmanager/#getFonts), um die von der Präsentation verwendeten Schriften zu erhalten. Vergleichen Sie die beiden Ergebnisse, um Schriften zu finden, die für die Darstellung erforderlich, aber nicht eingebettet sind.

**Wie kann ich schnell erkennen, ob die Datei versteckte Folien enthält und wie viele?**

Wenn die gespeicherten Dokumentmetadaten ausreichen, lesen Sie [DocumentProperties::getHiddenSlides](https://reference.aspose.com/slides/de/php-java/aspose.slides/documentproperties/#getHiddenSlides) über [PresentationFactory::getPresentationInfo](https://reference.aspose.com/slides/de/php-java/aspose.slides/presentationfactory/) und [PresentationInfo::readDocumentProperties](https://reference.aspose.com/slides/de/php-java/aspose.slides/presentationinfo/#readDocumentProperties). Dies eignet sich für ein leichtes Inventar. Wenn die Präsentation im Speicher geändert wurde, können die gespeicherten Metadaten fehlen oder veraltet sein; oder Sie müssen aktuelle Werte prüfen, indem Sie durch [Presentation::getSlides](https://reference.aspose.com/slides/de/php-java/aspose.slides/presentation/#getSlides) iterieren und für jede Folie die Methode [Slide::getHidden](https://reference.aspose.com/slides/de/php-java/aspose.slides/slide/#getHidden) inspizieren.

**Kann ich erkennen, ob eine benutzerdefinierte Foliengröße und -ausrichtung verwendet wird und ob sie von den Vorgaben abweicht?**

Ja. Laden Sie die Präsentation und rufen Sie [Presentation::getSlideSize](https://reference.aspose.com/slides/de/php-java/aspose.slides/presentation/#getSlideSize) auf. Verwenden Sie [SlideSize::getType](https://reference.aspose.com/slides/de/php-java/aspose.slides/slidesize/#getType), [SlideSize::getSize](https://reference.aspose.com/slides/de/php-java/aspose.slides/slidesize/#getSize) und [SlideSize::getOrientation](https://reference.aspose.com/slides/de/php-java/aspose.slides/slidesize/#getOrientation), um die aktuellen Einstellungen mit den erwarteten Vorgaben und Abmessungen zu vergleichen.

**Gibt es eine schnelle Möglichkeit zu sehen, ob Diagramme externe Datenquellen referenzieren?**

Ja. Suchen Sie jede [Chart](https://reference.aspose.com/slides/de/php-java/aspose.slides/chart/) und rufen Sie [ChartData::getDataSourceType](https://reference.aspose.com/slides/de/php-java/aspose.slides/chartdata/#getDataSourceType) auf. Für eine externe Arbeitsmappe rufen Sie [ChartData::getExternalWorkbookPath](https://reference.aspose.com/slides/de/php-java/aspose.slides/chartdata/#getExternalWorkbookPath) auf. Der Datentyp und der Pfad identifizieren eine externe Referenz, aber die Überprüfung, ob das Ziel verfügbar ist, erfordert eine separate Ressourcenprüfung.

**Wie kann ich „schwere“ Folien beurteilen, die das Rendern oder den PDF‑Export verlangsamen könnten?**

Es gibt keine einzelne Komplexitäts‑Eigenschaft. Durchlaufen Sie [Presentation::getSlides](https://reference.aspose.com/slides/de/php-java/aspose.slides/presentation/#getSlides) und die [BaseSlide::getShapes](https://reference.aspose.com/slides/de/php-java/aspose.slides/baseslide/#getShapes)-Sammlung jeder Folie. Nutzen Sie die Anzahl der Formen sowie das Vorhandensein großer Bilder, Effekte, Animationen oder Multimedia als Screening‑Signale und messen Sie ein repräsentatives Rendering oder Export, bevor Sie eine Folie als bestätigten Performance‑Flaschenhals einstufen.