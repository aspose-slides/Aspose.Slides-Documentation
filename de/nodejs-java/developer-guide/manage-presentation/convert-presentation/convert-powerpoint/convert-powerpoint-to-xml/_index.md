---
title: PowerPoint-Präsentationen nach XML konvertieren in JavaScript
linktitle: PowerPoint zu XML
type: docs
weight: 145
url: /de/nodejs-java/convert-powerpoint-to-xml/
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
- Node.js
- JavaScript
- Aspose.Slides
description: "Konvertieren Sie PowerPoint- und OpenDocument-Präsentationen in PowerPoint‑XML-Dateien oder -Streams in JavaScript mit Aspose.Slides für Node.js über Java."
---
## **Übersicht**

Aspose.Slides für Node.js über Java kann PowerPoint‑Präsentationen in das PowerPoint‑XML‑Präsentationsformat konvertieren. XML‑Ausgabe ist nützlich, wenn Sie eine textbasierte Darstellung benötigen, um die Präsentationsstruktur zu untersuchen, generierte Dokumente zu überprüfen, Ausgaben in automatisierten Tests zu vergleichen oder sie in einen Workflow zu integrieren, der XML anstelle eines Präsentationspakets verarbeitet.

Verwenden Sie die [Presentation.save](https://reference.aspose.com/slides/de/nodejs-java/aspose.slides/presentation/#save)-Methode mit dem `Xml`‑Wert aus der Aufzählung [SaveFormat](https://reference.aspose.com/slides/de/nodejs-java/aspose.slides/saveformat/). Sie können das Ergebnis direkt in eine Datei oder in einen Stream schreiben.

{{% alert color="info" title="Note" %}}
`SaveFormat.Xml` erstellt eine PowerPoint‑XML‑Präsentation. Es extrahiert nicht die einzelnen Office‑Open‑XML‑Teile, die in einem PPTX‑Paket gespeichert sind. Falls Sie die genauen PPTX‑Paketteile benötigen, z. B. `ppt/presentation.xml` oder einzelne Folien‑XML‑Dateien, untersuchen Sie das PPTX‑Paket selbst.
{{% /alert %}}

## **Präsentation in eine XML-Datei konvertieren**

Laden Sie eine Quellpräsentation mit der Klasse [Presentation](https://reference.aspose.com/slides/de/nodejs-java/aspose.slides/presentation/), und übergeben Sie dann den Ausgabepfad sowie `SaveFormat.Xml` an [Presentation.save](https://reference.aspose.com/slides/de/nodejs-java/aspose.slides/presentation/#save). Die Quelle kann jedes für das Laden unterstützte Präsentationsformat sein, z. B. PPT, PPTX oder ODP.

Das folgende Beispiel konvertiert eine PPTX‑Präsentation in eine XML‑Datei:

```javascript
const aspose = { slides: require("aspose.slides.via.java") };

const presentation = new aspose.slides.Presentation("input.pptx");
try {
    presentation.save("presentation.xml", aspose.slides.SaveFormat.Xml);
} finally {
    presentation.dispose();
}
```

## **XML‑Ausgabe in einen Stream schreiben**

Verwenden Sie die Stream‑Überladung von [Presentation.save](https://reference.aspose.com/slides/de/nodejs-java/aspose.slides/presentation/#save), wenn die XML im Speicher bleiben oder an eine andere Komponente weitergegeben werden muss, z. B. an einen Webservice, Speicheranbieter oder eine XML‑Verarbeitungspipeline. Das folgende Beispiel schreibt das Ergebnis in einen Java `ByteArrayOutputStream` und kopiert die erzeugten Daten in einen Node.js `Buffer`:

```javascript
const aspose = { slides: require("aspose.slides.via.java") };
const java = require("java");

const presentation = new aspose.slides.Presentation("input.pptx");
try {
    const xmlStream = java.newInstanceSync("java.io.ByteArrayOutputStream");
    try {
        presentation.save(xmlStream, aspose.slides.SaveFormat.Xml);

        const xmlBuffer = Buffer.from(xmlStream.toByteArray());
        console.log(`XML size: ${xmlBuffer.length} bytes`);

        // Übergibt xmlBuffer an die nächste Komponente im Workflow.
    } finally {
        xmlStream.close();
    }
} finally {
    presentation.dispose();
}
```

## **XML mit Präsentations- und Exportformaten vergleichen**

Wählen Sie das Ausgabeformat je nach Verwendungszweck des Ergebnisses:

| Format | Ausgabe | Typischer Anwendungsfall |
| --- | --- | --- |
| PowerPoint XML (`.xml`) | Eine PowerPoint‑XML‑Präsentation | Untersuchung der Struktur, Fehlersuche, Vergleich der erzeugten Ausgabe und XML‑basierte Integration |
| PPT (`.ppt`) | Eine alte binäre Präsentationsdatei | Kompatibilität mit älteren PowerPoint‑Workflows |
| PPTX (`.pptx`) | Ein Office‑Open‑XML‑Paket mit mehreren Teilen | Regelmäßige PowerPoint‑Bearbeitung und Präsentationsaustausch |
| PDF oder TIFF | Seiten mit festem Layout oder ein mehrseitiges Bild | Anzeigen, Drucken und Archivieren |
| PNG, JPEG oder SVG | Eine gerenderte Darstellung einer einzelnen Folie | Miniaturansichten, Vorschauen und Bildressourcen |
| HTML oder HTML5 | Web‑orientierte Präsentationsausgabe | Anzeige im Browser und Web‑Veröffentlichung |

Im Gegensatz zu PPT und PPTX ist die XML‑Ausgabe hauptsächlich für Inspektion und datenorientierte Workflows gedacht. Im Gegensatz zu PDF, TIFF, HTML und Folien‑Bildformaten stellt sie Präsentationsdaten dar, anstatt Folien als Seiten oder visuelle Assets zu rendern. Die Tabelle [supported file formats](/slides/de/nodejs-java/supported-file-formats/) listet PowerPoint XML Presentation als reines Speicherformat auf; verwenden Sie sie also nicht, wenn ein Workflow die exportierte Datei wieder in Aspose.Slides laden muss, um weiter zu bearbeiten.

## **Häufig gestellte Fragen**

**Ist `SaveFormat.Xml` dasselbe wie das Speichern einer PPTX‑Datei?**

Nein. PPTX ist ein Paket, das mehrere Office‑Open‑XML‑Teile enthält, während `SaveFormat.Xml` eine PowerPoint‑XML‑Präsentationsdatei erstellt.

**Kann ich die XML‑Ausgabe speichern, ohne eine Datei auf dem Datenträger zu erstellen?**

Ja. Übergeben Sie einen beschreibbaren Stream an [Presentation.save](https://reference.aspose.com/slides/de/nodejs-java/aspose.slides/presentation/#save). Zum Beispiel können Sie einen Java `ByteArrayOutputStream` verwenden und dessen Daten in einen Node.js `Buffer` kopieren, um die Verarbeitung im Speicher zu ermöglichen.

**Kann Aspose.Slides die exportierte XML‑Datei erneut laden?**

Nein. PowerPoint XML Presentation wird derzeit nur zum Speichern unterstützt, nicht zum Laden. Verwenden Sie PPTX oder ein anderes unterstütztes Präsentationsformat, wenn ein Round‑Trip‑Bearbeiten erforderlich ist.

**Wandelt die XML‑Konvertierung jede Folie in eine Seite oder ein Bild um?**

Nein. Die XML‑Konvertierung schreibt strukturierte Präsentationsdaten. Verwenden Sie PDF oder TIFF für seitenorientierte Ausgaben oder PNG, JPEG und SVG für einzelne Folienbilder.