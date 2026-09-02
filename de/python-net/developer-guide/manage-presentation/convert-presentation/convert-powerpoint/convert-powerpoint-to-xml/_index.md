---
title: "PowerPoint-Präsentationen in XML konvertieren mit Python"
linktitle: "PowerPoint zu XML"
type: docs
weight: 145
url: /de/python-net/convert-powerpoint-to-xml/
keywords:
  - "PowerPoint in XML konvertieren"
  - "Präsentation in XML konvertieren"
  - "PPT zu XML"
  - "PPTX zu XML"
  - "ODP zu XML"
  - "PowerPoint XML-Präsentation"
  - "SaveFormat.XML"
  - "Präsentation als XML speichern"
  - "Präsentation nach XML exportieren"
  - "XML-Stream"
  - "Python"
  - "Aspose.Slides"
description: "PowerPoint- und OpenDocument-Präsentationen in PowerPoint-XML-Dateien oder Streams in Python mit Aspose.Slides konvertieren."
---
## **Übersicht**

Aspose.Slides für Python über .NET kann PowerPoint‑Präsentationen in das PowerPoint XML‑Präsentationsformat konvertieren. XML‑Ausgabe ist nützlich, wenn Sie eine textbasierte Darstellung zur Inspektion der Präsentationsstruktur, Fehlersuche in erzeugten Dokumenten, zum Vergleich von Ausgaben in automatisierten Tests oder zur Integration in einen Workflow benötigen, der XML anstelle eines Präsentationspakets verarbeitet.

Verwenden Sie die [Presentation.save](https://reference.aspose.com/slides/de/python-net/aspose.slides/presentation/save/) Methode mit dem Wert `XML` aus der Aufzählung [SaveFormat](https://reference.aspose.com/slides/de/python-net/aspose.slides.export/saveformat/). Sie können das Ergebnis direkt in eine Datei oder in einen Stream schreiben.

{{% alert color="info" title="Hinweis" %}}
`SaveFormat.XML` erstellt eine PowerPoint XML‑Präsentation. Es extrahiert nicht die einzelnen Office Open XML‑Teile, die in einem PPTX‑Paket gespeichert sind. Wenn Sie die genauen PPTX‑Paketteile benötigen, z. B. `ppt/presentation.xml` oder einzelne Folien‑XML‑Dateien, untersuchen Sie das PPTX‑Paket selbst.
{{% /alert %}}

## **Eine Präsentation in eine XML‑Datei konvertieren**

Laden Sie eine Quellpräsentation mit der Klasse [Presentation](https://reference.aspose.com/slides/de/python-net/aspose.slides/presentation/) und übergeben Sie dann den Ausgabepfad und `SaveFormat.XML` an [Presentation.save](https://reference.aspose.com/slides/de/python-net/aspose.slides/presentation/save/). Die Quelle kann jedes für das Laden unterstützte Präsentationsformat sein, z. B. PPT, PPTX oder ODP.

Das folgende Beispiel konvertiert eine PPTX‑Präsentation in eine XML‑Datei:

```py
import aspose.slides as slides

with slides.Presentation("presentation.pptx") as presentation:
    presentation.save("presentation.xml", slides.export.SaveFormat.XML)
```

## **XML‑Ausgabe in einen Stream schreiben**

Verwenden Sie die Stream‑Überladung von [Presentation.save](https://reference.aspose.com/slides/de/python-net/aspose.slides/presentation/save/), wenn die XML‑Ausgabe im Speicher bleiben oder an eine andere Komponente weitergegeben werden muss, z. B. einen Web‑Dienst, Speicheranbieter oder eine XML‑Verarbeitungspipeline. Das folgende Beispiel schreibt das Ergebnis in einen [BytesIO](https://docs.python.org/3/library/io.html#io.BytesIO)‑Stream und spult ihn für nachfolgendes Lesen zurück:

```py
from io import BytesIO

import aspose.slides as slides

with slides.Presentation("presentation.pptx") as presentation:
    xml_stream = BytesIO()
    presentation.save(xml_stream, slides.export.SaveFormat.XML)
    xml_stream.seek(0)

    # Übergibt xml_stream an die nächste Komponente im Workflow.
```

## **XML mit Präsentations‑ und Exportformaten vergleichen**

Wählen Sie das Ausgabeformat abhängig davon, wie das Ergebnis verwendet wird:

| Format | Ausgabe | Typische Verwendung |
| --- | --- | --- |
| PowerPoint XML (`.xml`) | Eine PowerPoint XML‑Präsentation | Inspektion der Struktur, Fehlersuche, Vergleich von erzeugten Ausgaben und XML‑basierte Integration |
| PPT (`.ppt`) | Eine alte binäre Präsentationsdatei | Kompatibilität mit älteren PowerPoint‑Workflows |
| PPTX (`.pptx`) | Ein Office Open XML‑Paket mit mehreren Teilen | Regelmäßige PowerPoint‑Bearbeitung und Präsentationsaustausch |
| PDF oder TIFF | Seiten mit festem Layout oder ein mehrseitiges Bild | Anzeigen, Drucken und Archivieren |
| PNG, JPEG oder SVG | Eine gerenderte Darstellung einer einzelnen Folie | Miniaturansichten, Vorschaubilder und Bild‑Assets |
| HTML oder HTML5 | Web‑orientierte Präsentationsausgabe | Browseransicht und Web‑Veröffentlichung |

Im Gegensatz zu PPT und PPTX ist die XML‑Ausgabe hauptsächlich für Inspektions‑ und datenorientierte Workflows gedacht. Im Gegensatz zu PDF, TIFF, HTML und Folien‑Bildformaten stellt sie Präsentationsdaten dar, anstatt Folien als Seiten oder visuelle Assets zu rendern. In der Tabelle [unterstützte Dateiformate](/slides/de/python-net/supported-file-formats/) wird die PowerPoint XML‑Präsentation als reines Speicherformat aufgeführt, sodass Sie sie nicht verwenden sollten, wenn ein Workflow die exportierte Datei wieder in Aspose.Slides laden muss, um die Bearbeitung fortzusetzen.

## **FAQ**

**Ist `SaveFormat.XML` dasselbe wie das Speichern einer PPTX‑Datei?**

Nein. PPTX ist ein Paket, das mehrere Office Open XML‑Teile enthält, während `SaveFormat.XML` eine PowerPoint XML‑Präsentationsdatei erstellt.

**Kann ich die XML‑Ausgabe speichern, ohne eine Datei auf der Festplatte zu erstellen?**

Ja. Übergeben Sie einen beschreibbaren Stream an [Presentation.save](https://reference.aspose.com/slides/de/python-net/aspose.slides/presentation/save/). Zum Beispiel können Sie einen [BytesIO](https://docs.python.org/3/library/io.html#io.BytesIO)‑Stream für die Verarbeitung im Speicher verwenden.

**Kann Aspose.Slides die exportierte XML‑Datei erneut laden?**

Nein. PowerPoint‑XML‑Präsentation wird derzeit nur zum Speichern unterstützt, nicht zum Laden. Verwenden Sie PPTX oder ein anderes unterstütztes Präsentationsformat, wenn ein Rundreise‑Bearbeitungs‑Workflow erforderlich ist.

**Wandelt die XML‑Konvertierung jede Folie in eine Seite oder ein Bild um?**

Nein. Die XML‑Konvertierung schreibt strukturierte Präsentationsdaten. Verwenden Sie PDF oder TIFF für seitenorientierte Ausgaben oder PNG, JPEG und SVG für einzelne Folien‑Bilder.