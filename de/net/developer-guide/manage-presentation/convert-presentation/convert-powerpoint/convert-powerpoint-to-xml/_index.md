---
title: PowerPoint-Präsentationen nach XML konvertieren in .NET
linktitle: PowerPoint nach XML
type: docs
weight: 145
url: /de/net/convert-powerpoint-to-xml/
keywords:
- PowerPoint nach XML konvertieren
- Präsentation nach XML konvertieren
- PPT nach XML
- PPTX nach XML
- ODP nach XML
- PowerPoint XML-Präsentation
- SaveFormat.Xml
- Präsentation als XML speichern
- Präsentation nach XML exportieren
- XML-Stream
- .NET
- C#
- Aspose.Slides
description: "PowerPoint- und OpenDocument-Präsentationen in PowerPoint-XML-Dateien oder -Streams in C# mit Aspose.Slides für .NET konvertieren."
---
## **Übersicht**

Aspose.Slides für .NET kann PowerPoint‑Präsentationen in das PowerPoint‑XML‑Präsentationsformat konvertieren. XML‑Ausgabe ist nützlich, wenn Sie eine textbasierte Darstellung benötigen, um die Präsentationsstruktur zu untersuchen, erzeugte Dokumente zu troubleshooten, Ausgaben in automatisierten Tests zu vergleichen oder sie in einen Workflow zu integrieren, der XML anstelle eines Präsentationspakets verarbeitet.

Verwenden Sie die Methode [Presentation.Save](https://reference.aspose.com/slides/de/net/aspose.slides/presentation/save/) mit dem `Xml`‑Wert aus der Aufzählung [SaveFormat](https://reference.aspose.com/slides/de/net/aspose.slides.export/saveformat/). Sie können das Ergebnis direkt in eine Datei oder in einen Stream schreiben.

{{% alert color="info" title="Note" %}}
`SaveFormat.Xml` erstellt eine PowerPoint‑XML‑Präsentation. Es extrahiert nicht die einzelnen Office‑Open‑XML‑Teile, die in einem PPTX‑Paket gespeichert sind. Wenn Sie die genauen PPTX‑Paketteile benötigen, wie `ppt/presentation.xml` oder einzelne Folien‑XML‑Dateien, prüfen Sie das PPTX‑Paket selbst.
{{% /alert %}}

## **Eine Präsentation in eine XML‑Datei konvertieren**

Laden Sie eine Quellpräsentation mit der Klasse [Presentation](https://reference.aspose.com/slides/de/net/aspose.slides/presentation/) und übergeben Sie dann den Ausgabepfad sowie `SaveFormat.Xml` an [Presentation.Save](https://reference.aspose.com/slides/de/net/aspose.slides/presentation/save/). Die Quelle kann jedes für das Laden unterstützte Präsentationsformat sein, z. B. PPT, PPTX oder ODP.

Das folgende Beispiel konvertiert eine PPTX‑Präsentation in eine XML‑Datei:

```csharp
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation("presentation.pptx");
presentation.Save("presentation.xml", SaveFormat.Xml);
```

## **XML‑Ausgabe in einen Stream schreiben**

Verwenden Sie die Stream‑Überladung von [Presentation.Save](https://reference.aspose.com/slides/de/net/aspose.slides/presentation/save/), wenn die XML‑Daten im Speicher bleiben oder an eine andere Komponente weitergegeben werden müssen, z. B. einen Web‑Dienst, einen Speicher‑Provider oder eine XML‑Verarbeitungspipeline. Das folgende Beispiel schreibt das Ergebnis in einen [MemoryStream](https://learn.microsoft.com/en-us/dotnet/api/system.io.memorystream) und setzt den Zeiger zurück für nachfolgendes Lesen:

```csharp
using System.IO;
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation("presentation.pptx");
using var xmlStream = new MemoryStream();

presentation.Save(xmlStream, SaveFormat.Xml);
xmlStream.Position = 0;

// Übergeben Sie xmlStream an die nächste Komponente im Workflow.
```

## **XML mit Präsentations‑ und Exportformaten vergleichen**

Wählen Sie das Ausgabeformat entsprechend der geplanten Verwendung des Ergebnisses:

| Format | Ausgabe | Typische Verwendung |
| --- | --- | --- |
| PowerPoint XML (`.xml`) | Eine PowerPoint‑XML‑Präsentation | Untersuchung der Struktur, Fehlersuche, Vergleich von erzeugten Ausgaben und XML‑basierte Integration |
| PPT (`.ppt`) | Eine veraltete binäre Präsentationsdatei | Kompatibilität mit älteren PowerPoint‑Workflows |
| PPTX (`.pptx`) | Ein Office‑Open‑XML‑Paket mit mehreren Teilen | Reguläre PowerPoint‑Bearbeitung und Austausch von Präsentationen |
| PDF oder TIFF | Seiten mit festem Layout oder ein mehrseitiges Bild | Anzeige, Druck und Archivierung |
| PNG, JPEG oder SVG | Eine gerenderte Darstellung einer einzelnen Folie | Vorschaubilder, Vorschauen und Bild‑Assets |
| HTML oder HTML5 | Web‑orientierte Präsentationsausgabe | Anzeige im Browser und Web‑Veröffentlichung |

Im Gegensatz zu PPT und PPTX ist die XML‑Ausgabe vorwiegend für Inspektions‑ und datenorientierte Workflows gedacht. Im Gegensatz zu PDF, TIFF, HTML und Folien‑Bildformaten stellt sie Präsentationsdaten bereit, anstatt Folien als Seiten oder visuelle Assets zu rendern. In der Tabelle [unterstützte Dateiformate](/slides/de/net/supported-file-formats/) wird die PowerPoint‑XML‑Präsentation als reines Speicherformat aufgeführt; verwenden Sie sie also nicht, wenn ein Workflow die exportierte Datei wieder in Aspose.Slides laden muss, um weiter zu bearbeiten.

## **FAQ**

**Ist `SaveFormat.Xml` dasselbe wie das Speichern einer PPTX‑Datei?**  
Nein. PPTX ist ein Paket, das mehrere Office‑Open‑XML‑Teile enthält, während `SaveFormat.Xml` eine PowerPoint‑XML‑Präsentationsdatei erzeugt.

**Kann ich die XML‑Ausgabe speichern, ohne eine Datei auf dem Datenträger zu erzeugen?**  
Ja. Übergeben Sie einen beschreibbaren Stream an [Presentation.Save](https://reference.aspose.com/slides/de/net/aspose.slides/presentation/save/). Verwenden Sie beispielsweise einen [MemoryStream](https://learn.microsoft.com/en-us/dotnet/api/system.io.memorystream), um die Verarbeitung im Speicher durchzuführen.

**Kann Aspose.Slides die exportierte XML‑Datei erneut laden?**  
Nein. PowerPoint‑XML‑Präsentation wird derzeit nur zum Speichern, nicht zum Laden unterstützt. Verwenden Sie PPTX oder ein anderes unterstütztes Präsentationsformat, wenn ein Round‑Trip‑Bearbeiten erforderlich ist.

**Erzeugt die XML‑Konvertierung jede Folie als Seite oder Bild?**  
Nein. Die XML‑Konvertierung schreibt strukturierte Präsentationsdaten. Verwenden Sie PDF oder TIFF für seitenorientierte Ausgaben oder PNG, JPEG und SVG für einzelne Folien‑Bilder.