---
title: PowerPoint-Präsentationen in XML konvertieren in .NET
linktitle: PowerPoint zu XML
type: docs
weight: 145
url: /de/net/convert-powerpoint-to-xml/
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
- .NET
- C#
- Aspose.Slides
description: "Konvertieren Sie PowerPoint- und OpenDocument-Präsentationen in PowerPoint-XML-Dateien oder -Streams in C# mit Aspose.Slides für .NET."
---
## **Übersicht**

Aspose.Slides for .NET kann PowerPoint‑Präsentationen in das PowerPoint‑XML‑Presentation‑Format konvertieren. XML‑Ausgabe ist nützlich, wenn Sie eine textbasierte Darstellung benötigen, um die Struktur einer Präsentation zu inspizieren, erzeugte Dokumente zu analysieren, Ausgaben in automatisierten Tests zu vergleichen oder in einen Workflow zu integrieren, der XML statt eines Präsentationspakets verarbeitet.

Verwenden Sie die [Presentation.Save](https://reference.aspose.com/slides/de/net/aspose.slides/presentation/save/)‑Methode mit dem `Xml`‑Wert aus der [SaveFormat](https://reference.aspose.com/slides/de/net/aspose.slides.export/saveformat/)‑Aufzählung. Sie können das Ergebnis direkt in eine Datei oder in einen Stream schreiben.

{{% alert color="info" title="Hinweis" %}}

`SaveFormat.Xml` erstellt eine PowerPoint‑XML‑Präsentation. Es extrahiert nicht die einzelnen Office‑Open‑XML‑Teile, die in einem PPTX‑Paket gespeichert sind. Wenn Sie die genauen PPTX‑Paketteile benötigen, wie `ppt/presentation.xml` oder einzelne Folien‑XML‑Dateien, untersuchen Sie das PPTX‑Paket selbst.

{{% /alert %}}

## **Konvertieren einer Präsentation in eine XML‑Datei**

Laden Sie eine Quellpräsentation mit der [Presentation](https://reference.aspose.com/slides/de/net/aspose.slides/presentation/)‑Klasse und übergeben Sie den Ausgabepfad sowie `SaveFormat.Xml` an [Presentation.Save](https://reference.aspose.com/slides/de/net/aspose.slides/presentation/save/). Die Quelle kann jedes von Aspose.Slides zum Laden unterstützte Format sein, z. B. PPT, PPTX oder ODP.

Das folgende Beispiel konvertiert eine PPTX‑Präsentation in eine XML‑Datei:

```csharp
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation("presentation.pptx");
presentation.Save("presentation.xml", SaveFormat.Xml);
```

## **XML‑Ausgabe in einen Stream schreiben**

Verwenden Sie die Stream‑Überladung von [Presentation.Save](https://reference.aspose.com/slides/de/net/aspose.slides/presentation/save/), wenn die XML‑Ausgabe im Speicher bleiben oder an eine andere Komponente weitergegeben werden soll, z. B. einen Webservice, einen Speicher‑Provider oder eine XML‑Verarbeitungspipeline. Das folgende Beispiel schreibt das Ergebnis in einen [MemoryStream](https://learn.microsoft.com/en-us/dotnet/api/system.io.memorystream?view=net-10.0) und spult ihn zum anschließenden Lesen zurück:

```csharp
using System.IO;
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation("presentation.pptx");
using var xmlStream = new MemoryStream();

presentation.Save(xmlStream, SaveFormat.Xml);
xmlStream.Position = 0;

// xmlStream an die nächste Komponente im Workflow übergeben.
```

## **XML mit Präsentations‑ und Exportformaten vergleichen**

Wählen Sie das Ausgabeformat nach dem Verwendungszweck:

| Format | Ausgabe | Typische Verwendung |
| --- | --- | --- |
| PowerPoint XML (`.xml`) | Eine PowerPoint‑XML‑Präsentation | Struktur untersuchen, Fehler beheben, erzeugte Ausgabe vergleichen und XML‑basierte Integration |
| PPT (`.ppt`) | Eine ältere binäre Präsentationsdatei | Kompatibilität mit älteren PowerPoint‑Workflows |
| PPTX (`.pptx`) | Ein Office Open XML‑Paket mit mehreren Teilen | Regelmäßige PowerPoint‑Bearbeitung und Präsentationsaustausch |
| PDF oder TIFF | Seiten mit festem Layout oder TIFF‑Bilder | Anzeigen, Drucken und Archivieren |
| PNG, JPEG oder SVG | Eine gerenderte Darstellung einer einzelnen Folie | Vorschaubilder, Vorschauen und Bild‑Assets |
| HTML oder HTML5 | Web‑orientierte Präsentationsausgabe | Anzeige im Browser und Web‑Veröffentlichung |

Im Gegensatz zu PPT und PPTX ist die XML‑Ausgabe hauptsächlich für Inspektion und datenorientierte Workflows gedacht. Im Gegensatz zu PDF, TIFF, HTML und Bildformaten für Folien repräsentiert sie Präsentationsdaten, anstatt Folien als Seiten oder visuelle Assets zu rendern. Die [unterstützten Dateiformate](/slides/de/net/supported-file-formats/)‑Tabelle listet jedes Format auf, das Aspose.Slides laden, importieren, speichern oder rendern kann.

## **FAQ**

**Ist `SaveFormat.Xml` dasselbe wie das Speichern einer PPTX‑Datei?**

Nein. PPTX ist ein Paket, das mehrere Office Open XML‑Teile enthält, während `SaveFormat.Xml` eine PowerPoint‑XML‑Präsentationsdatei erzeugt.

**Kann ich die XML‑Ausgabe speichern, ohne eine Datei auf der Festplatte zu erstellen?**

Ja. Übergeben Sie einen beschreibbaren Stream an [Presentation.Save](https://reference.aspose.com/slides/de/net/aspose.slides/presentation/save/). Verwenden Sie beispielsweise einen [MemoryStream](https://learn.microsoft.com/en-us/dotnet/api/system.io.memorystream?view=net-10.0) für die Verarbeitung im Speicher.

**Kann Aspose.Slides die exportierte XML‑Datei erneut laden?**

Ja. Übergeben Sie die XML‑Datei oder einen Stream an den [Presentation](https://reference.aspose.com/slides/de/net/aspose.slides/presentation/presentation/)‑Konstruktor. [Presentation.SourceFormat](https://reference.aspose.com/slides/de/net/aspose.slides/presentation/sourceformat/) liefert dann `SourceFormat.Xml`. [PresentationFactory.GetPresentationInfo](https://reference.aspose.com/slides/de/net/aspose.slides/presentationfactory/getpresentationinfo/) meldet für dieses Format `LoadFormat.Unknown`, daher sollten Sie es nicht zur Entscheidung verwenden, ob eine XML‑Datei geöffnet werden kann.

**Erzeugt die XML‑Konvertierung jede Folie als Seite oder Bild?**

Nein. Die XML‑Konvertierung schreibt strukturierte Präsentationsdaten. Verwenden Sie PDF oder TIFF für seitenorientierte Ausgaben oder PNG, JPEG und SVG für einzelne Folienbilder.