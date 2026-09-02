---
title: PowerPoint-Präsentationen in XML in PHP konvertieren
linktitle: PowerPoint zu XML
type: docs
weight: 145
url: /de/php-java/convert-powerpoint-to-xml/
keywords:
- PowerPoint zu XML konvertieren
- Präsentation zu XML konvertieren
- PPT zu XML
- PPTX zu XML
- ODP zu XML
- PowerPoint XML-Präsentation
- SaveFormat.Xml
- Präsentation als XML speichern
- Präsentation nach XML exportieren
- XML-Stream
- PHP
- Aspose.Slides
description: "PowerPoint- und OpenDocument-Präsentationen in PowerPoint-XML-Dateien oder -Streams in PHP mit Aspose.Slides für PHP via Java konvertieren."
---
## **Übersicht**

Aspose.Slides für PHP via Java kann PowerPoint‑Präsentationen in das PowerPoint‑XML‑Presentation‑Format konvertieren. XML‑Ausgabe ist nützlich, wenn Sie eine textbasierte Darstellung benötigen, um die Präsentationsstruktur zu untersuchen, erzeugte Dokumente zu trouble­shooten, Ausgaben in automatisierten Tests zu vergleichen oder sie in einen Workflow zu integrieren, der XML anstelle eines Präsentationspakets verarbeitet.

Verwenden Sie die [Presentation::save](https://reference.aspose.com/slides/de/php-java/aspose.slides/presentation/)‑Methode mit dem `Xml`‑Wert aus der Aufzählung [SaveFormat](https://reference.aspose.com/slides/de/php-java/aspose.slides/saveformat/). Sie können das Ergebnis direkt in eine Datei oder in einen Stream schreiben.

{{% alert color="info" title="Hinweis" %}}
`SaveFormat::Xml` erstellt eine PowerPoint‑XML‑Presentation. Es extrahiert nicht die einzelnen Office‑Open‑XML‑Teile, die in einem PPTX‑Paket gespeichert sind. Wenn Sie die genauen PPTX‑Paket‑Teile benötigen, z. B. `ppt/presentation.xml` oder einzelne Folien‑XML‑Dateien, prüfen Sie das PPTX‑Paket selbst.
{{% /alert %}}

## **Eine Präsentation in eine XML‑Datei konvertieren**

Laden Sie eine Quellpräsentation mit der Klasse [Presentation](https://reference.aspose.com/slides/de/php-java/aspose.slides/presentation/) und übergeben Sie dann den Ausgabepfad sowie `SaveFormat::Xml` an [Presentation::save](https://reference.aspose.com/slides/de/php-java/aspose.slides/presentation/). Die Quelle kann jedes für das Laden unterstützte Präsentationsformat sein, z. B. PPT, PPTX oder ODP.

Das folgende Beispiel konvertiert eine PPTX‑Präsentation in eine XML‑Datei:

```php
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;

$inputPath = __DIR__ . DIRECTORY_SEPARATOR . "presentation.pptx";
$outputPath = __DIR__ . DIRECTORY_SEPARATOR . "presentation.xml";
$presentation = new Presentation($inputPath);
try {
    $presentation->save($outputPath, SaveFormat::Xml);
} finally {
    $presentation->dispose();
}
```

## **XML‑Ausgabe in einen Stream schreiben**

Verwenden Sie die Stream‑Überladung von [Presentation::save](https://reference.aspose.com/slides/de/php-java/aspose.slides/presentation/), wenn die XML‑Daten im Speicher bleiben oder an eine andere Komponente weitergegeben werden müssen, z. B. einen Webservice, einen Speicheranbieter oder eine XML‑Verarbeitungspipeline. Das folgende Beispiel schreibt das Ergebnis in einen [ByteArrayOutputStream](https://docs.oracle.com/javase/8/docs/api/java/io/ByteArrayOutputStream.html) und erhält das erzeugte XML als Byte‑Array:

```php
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;

$inputPath = __DIR__ . DIRECTORY_SEPARATOR . "presentation.pptx";
$presentation = new Presentation($inputPath);
try {
    $xmlStream = new Java("java.io.ByteArrayOutputStream");
    try {
        $presentation->save($xmlStream, SaveFormat::Xml);
        $xmlBytes = $xmlStream->toByteArray();

        // Geben Sie $xmlBytes an die nächste Komponente im Workflow weiter.
    } finally {
        $xmlStream->close();
    }
} finally {
    $presentation->dispose();
}
```

Ein `ByteArrayOutputStream` speichert alle erzeugten Daten im Speicher, sodass vor dem Aufruf von `toByteArray` kein Positions‑Reset erforderlich ist.

## **XML mit Präsentations‑ und Exportformaten vergleichen**

Wählen Sie das Ausgabeformat je nach Verwendungszweck des Ergebnisses:

| Format | Ausgabe | Typische Verwendung |
| --- | --- | --- |
| PowerPoint XML (`.xml`) | Eine PowerPoint‑XML‑Presentation | Untersuchung der Struktur, Fehlersuche, Vergleich von erzeugten Ausgaben und XML‑basierte Integration |
| PPT (`.ppt`) | Eine alte binäre Präsentationsdatei | Kompatibilität mit älteren PowerPoint‑Workflows |
| PPTX (`.pptx`) | Ein Office‑Open‑XML‑Paket mit mehreren Teilen | Normale PowerPoint‑Bearbeitung und Austausch von Präsentationen |
| PDF oder TIFF | Seiten mit festem Layout oder ein mehrseitiges Bild | Anzeige, Druck und Archivierung |
| PNG, JPEG oder SVG | Eine gerenderte Darstellung einer einzelnen Folie | Miniaturen, Vorschauen und Bild‑Assets |
| HTML oder HTML5 | Weborientierte Präsentationsausgabe | Anzeige im Browser und Web‑Veröffentlichung |

Im Gegensatz zu PPT und PPTX ist die XML‑Ausgabe hauptsächlich für Inspektion und datenorientierte Workflows gedacht. Im Gegensatz zu PDF, TIFF, HTML und Folien‑Bildformaten stellt sie Präsentationsdaten bereit, anstatt Folien als Seiten oder visuelle Assets zu rendern. Die Tabelle der [unterstützten Dateiformate](/slides/de/php-java/supported-file-formats/) listet PowerPoint XML Presentation als reines Speicherformat auf, verwenden Sie sie also nicht, wenn ein Workflow die exportierte Datei wieder in Aspose.Slides laden muss, um weiter zu bearbeiten.

## **FAQ**

**Ist `SaveFormat::Xml` dasselbe wie das Speichern einer PPTX‑Datei?**

Nein. PPTX ist ein Paket, das mehrere Office‑Open‑XML‑Teile enthält, während `SaveFormat::Xml` eine PowerPoint‑XML‑Presentation‑Datei erstellt.

**Kann ich die XML‑Ausgabe speichern, ohne eine Datei auf der Festplatte zu erstellen?**

Ja. übergeben Sie einen beschreibbaren Stream an [Presentation::save](https://reference.aspose.com/slides/de/php-java/aspose.slides/presentation/). Verwenden Sie zum Beispiel einen [ByteArrayOutputStream](https://docs.oracle.com/javase/8/docs/api/java/io/ByteArrayOutputStream.html) für die In‑Memory‑Verarbeitung.

**Kann Aspose.Slides die exportierte XML‑Datei erneut laden?**

Nein. PowerPoint XML Presentation wird derzeit nur zum Speichern unterstützt, nicht zum Laden. Verwenden Sie PPTX oder ein anderes unterstütztes Präsentationsformat, wenn ein Round‑Trip‑Editieren erforderlich ist.

**Wandelt die XML‑Konvertierung jede Folie in eine Seite oder ein Bild um?**

Nein. Die XML‑Konvertierung schreibt strukturierte Präsentationsdaten. Verwenden Sie PDF oder TIFF für seitenorientierte Ausgaben oder PNG, JPEG und SVG für einzelne Folienbilder.