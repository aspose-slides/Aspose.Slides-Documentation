---
title: PowerPoint-Präsentationen zu XML konvertieren in Python via Java
linktitle: PowerPoint zu XML
type: docs
weight: 145
url: /de/python-java/convert-powerpoint-to-xml/
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
- Python
- Java
- Aspose.Slides
description: "Konvertieren Sie PowerPoint- und OpenDocument-Präsentationen in PowerPoint‑XML‑Dateien oder Streams in Python via Java mit Aspose.Slides für Python via Java."
---
## **Übersicht**

Aspose.Slides für Python via Java kann PowerPoint‑Präsentationen in das PowerPoint XML‑Präsentationsformat konvertieren. XML‑Ausgabe ist nützlich, wenn Sie eine textbasierte Darstellung benötigen, um die Präsentationsstruktur zu inspizieren, generierte Dokumente zu Fehlersuchen, Ausgaben in automatisierten Tests zu vergleichen oder in einen Workflow zu integrieren, der XML anstelle eines Präsentationspakets verwendet.

Verwenden Sie die Methode [Presentation.save](https://reference.aspose.com/slides/de/python-java/aspose.slides/presentation/#save) mit dem Wert [Xml](https://reference.aspose.com/slides/de/python-java/aspose.slides/saveformat/#Xml) aus der Klasse [SaveFormat](https://reference.aspose.com/slides/de/python-java/aspose.slides/saveformat/) . Sie können das Ergebnis direkt in eine Datei oder in einen Stream schreiben.

{{% alert color="info" title="Hinweis" %}}

[SaveFormat.Xml](https://reference.aspose.com/slides/de/python-java/aspose.slides/saveformat/#Xml) erstellt eine PowerPoint XML‑Präsentation. Es extrahiert nicht die einzelnen Office Open XML‑Teile, die in einem PPTX‑Paket gespeichert sind. Wenn Sie die genauen PPTX‑Paketteile benötigen, wie `ppt/presentation.xml` oder einzelne Folien‑XML‑Dateien, untersuchen Sie das PPTX‑Paket selbst.

{{% /alert %}}

## **Konvertieren einer Präsentation in eine XML‑Datei**

Laden Sie eine Quellpräsentation mit der Klasse [Presentation](https://reference.aspose.com/slides/de/python-java/aspose.slides/presentation/) und übergeben Sie dann den Ausgabepfad sowie [SaveFormat.Xml](https://reference.aspose.com/slides/de/python-java/aspose.slides/saveformat/#Xml) an [Presentation.save](https://reference.aspose.com/slides/de/python-java/aspose.slides/presentation/#save). Die Quelle kann jedes für das Laden unterstützte Präsentationsformat sein, z. B. PPT, PPTX oder ODP.

Das folgende Beispiel konvertiert eine PPTX‑Präsentation in eine XML‑Datei:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat

presentation = Presentation("presentation.pptx")
try:
    presentation.save("presentation.xml", SaveFormat.Xml)
finally:
    presentation.dispose()
```

## **Schreiben der XML‑Ausgabe in einen Stream**

Verwenden Sie die Stream‑Überladung von [Presentation.save](https://reference.aspose.com/slides/de/python-java/aspose.slides/presentation/#save), wenn die XML‑Ausgabe im Speicher bleiben oder an eine andere Komponente übergeben werden soll, z. B. einen Webservice, einen Speicheranbieter oder eine XML‑Verarbeitungspipeline. Das folgende Beispiel schreibt das Ergebnis in einen [ByteArrayOutputStream](https://docs.oracle.com/en/java/javase/16/docs/api/java.base/java/io/ByteArrayOutputStream.html) und erhält das resultierende XML als Python‑Bytes‑Objekt:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat

ByteArrayOutputStream = jpype.JClass("java.io.ByteArrayOutputStream")

presentation = Presentation("presentation.pptx")
try:
    xml_stream = ByteArrayOutputStream()
    try:
        presentation.save(xml_stream, SaveFormat.Xml)
        java_bytes = xml_stream.toByteArray()
        xml_data = bytes(java_bytes)

        # Übergeben Sie xml_data an die nächste Komponente im Workflow.
    finally:
        xml_stream.close()
finally:
    presentation.dispose()
```

## **Vergleich von XML mit Präsentations‑ und Exportformaten**

Wählen Sie das Ausgabeformat entsprechend der späteren Verwendung des Ergebnisses:

| Format | Ausgabe | Typische Verwendung |
| --- | --- | --- |
| PowerPoint XML (`.xml`) | Eine PowerPoint XML‑Präsentation | Inspektion der Struktur, Fehlersuche, Vergleich generierter Ausgaben und XML‑basierte Integration |
| PPT (`.ppt`) | Eine alte binäre Präsentationsdatei | Kompatibilität mit älteren PowerPoint‑Workflows |
| PPTX (`.pptx`) | Ein Office Open XML‑Paket mit mehreren Teilen | Reguläre PowerPoint‑Bearbeitung und Präsentationsaustausch |
| PDF oder TIFF | Fest layoutete Seiten oder ein mehrseitiges Bild | Anzeigen, Drucken und Archivieren |
| PNG, JPEG oder SVG | Eine gerenderte Darstellung einer einzelnen Folie | Vorschaubilder, Vorschauen und Bildressourcen |
| HTML oder HTML5 | Web‑orientierte Präsentationsausgabe | Anzeige im Browser und Web‑Veröffentlichung |

Im Gegensatz zu PPT und PPTX ist die XML‑Ausgabe hauptsächlich für Inspektion und datenorientierte Workflows gedacht. Im Gegensatz zu PDF, TIFF, HTML und Folien‑Bildformaten stellt sie Präsentationsdaten dar, anstatt Folien als Seiten oder visuelle Assets zu rendern. Die Tabelle [supported file formats](/slides/de/python-java/supported-file-formats/) listet PowerPoint XML Presentation als reines Speicherformat auf, verwenden Sie sie also nicht, wenn ein Workflow die exportierte Datei wieder in Aspose.Slides laden muss, um weiter zu bearbeiten.

## **FAQ**

**Ist der XML‑Export derselbe wie das Speichern einer PPTX‑Datei?**

Nein. PPTX ist ein Paket, das mehrere Office Open XML‑Teile enthält, während [SaveFormat.Xml](https://reference.aspose.com/slides/de/python-java/aspose.slides/saveformat/#Xml) eine PowerPoint XML‑Präsentationsdatei erstellt.

**Kann ich die XML‑Ausgabe speichern, ohne eine Datei auf der Festplatte zu erstellen?**

Ja. Übergeben Sie einen schreibbaren Java‑Ausgabestream an [Presentation.save](https://reference.aspose.com/slides/de/python-java/aspose.slides/presentation/#save). Verwenden Sie beispielsweise einen [ByteArrayOutputStream](https://docs.oracle.com/en/java/javase/16/docs/api/java.base/java/io/ByteArrayOutputStream.html) für die Verarbeitung im Speicher.

**Kann Aspose.Slides die exportierte XML‑Datei erneut laden?**

Nein. PowerPoint XML Presentation wird derzeit nur zum Speichern unterstützt, nicht zum Laden. Verwenden Sie PPTX oder ein anderes unterstütztes Präsentationsformat, wenn ein Round‑Trip‑Editing erforderlich ist.

**Wandelt die XML‑Konvertierung jede Folie in eine Seite oder ein Bild um?**

Nein. Die XML‑Konvertierung schreibt strukturierte Präsentationsdaten. Verwenden Sie PDF oder TIFF für seitenorientierte Ausgaben oder PNG, JPEG und SVG für einzelne Folienbilder.