---
title: Low-Code-Präsentationsoperationen in .NET
linktitle: Low-Code-API
type: docs
weight: 50
url: /de/net/low-code-presentation-operations/
keywords:
- Low-Code-Präsentations-API
- Präsentation konvertieren
- Präsentationen zusammenführen
- Folien iterieren
- Formen iterieren
- Text iterieren
- Formen sammeln
- Präsentation komprimieren
- Unbenutzte Masterfolien entfernen
- Unbenutzte Layoutfolien entfernen
- Eingebettete Schriften komprimieren
- PowerPoint
- OpenDocument
- Präsentation
- .NET
- C#
- Aspose.Slides
description: "Verwenden Sie die Aspose.Slides Low-Code-API in .NET, um Präsentationen zu konvertieren und zusammenzuführen, Inhalte zu iterieren, Formen zu sammeln und die Präsentationsgröße zu reduzieren."
---
## **Übersicht**

Der [Aspose.Slides.LowCode](https://reference.aspose.com/slides/net/aspose.slides.lowcode/) Namespace bietet statische Hilfsklassen für gängige Präsentationsvorgänge. Diese Hilfsprogramme kapseln häufig verwendete Objektmodell‑Abläufe in fokussierten Methoden, sodass Sie Dateien konvertieren oder zusammenführen, Präsentationselemente verarbeiten, Formen sammeln und ungenutzte Inhalte mit weniger Code entfernen können.

Low‑code‑Hilfsprogramme sind am nützlichsten, wenn der Vorgang auf eine komplette Datei oder Präsentation angewendet wird und der Standard‑Workflow Ihren Anforderungen entspricht. Verwenden Sie das vollständige [Aspose.Slides object model](https://reference.aspose.com/slides/net/aspose.slides/), wenn Sie eine feinkörnige Kontrolle über einzelne Folien, Master, Layouts, Formen, Exporteinstellungen oder Beziehungen zwischen Präsentationselementen benötigen.

Die folgende Tabelle fasst die verfügbaren Hilfsprogramme zusammen:

| Hilfsprogramm | Verwendungszweck |
| --- | --- |
| [Convert](https://reference.aspose.com/slides/net/aspose.slides.lowcode/convert/) | Eine Präsentation in ein anderes Format konvertieren mit einem direkten Datei‑zu‑Datei‑Aufruf. |
| [Merger](https://reference.aspose.com/slides/net/aspose.slides.lowcode/merger/) | Vollständige Präsentationsdateien desselben Formats kombinieren. |
| [ForEach](https://reference.aspose.com/slides/net/aspose.slides.lowcode/foreach/) | Eine Aktion für jede Folie, Form, Absatz oder Textportion ausführen. |
| [Collect](https://reference.aspose.com/slides/net/aspose.slides.lowcode/collect/) | Formen aus der gesamten Präsentation abrufen für wiederholte Verarbeitung oder Analyse. |
| [Compress](https://reference.aspose.com/slides/net/aspose.slides.lowcode/compress/) | Unbenutzte Master/Layouts entfernen, eingebettete Schriftartdaten reduzieren und Bilder komprimieren. |

## **Eine Präsentation konvertieren**

Verwenden Sie [Convert.AutoByExtension](https://reference.aspose.com/slides/net/aspose.slides.lowcode/convert/autobyextension/), wenn die Dateierweiterung des Ausgabedateinamens ausreicht, um das Exportformat auszuwählen. Die Methode öffnet die Quellpräsentation, ermittelt das erforderliche Format aus dem Ausgabepfad und schreibt das Ergebnis.

```csharp
using Aspose.Slides.LowCode;

Convert.AutoByExtension("input.pptx", "output.pdf");
```

Die [Convert](https://reference.aspose.com/slides/net/aspose.slides.lowcode/convert/) Klasse bietet zudem dedizierte Methoden für PDF, SVG, JPEG, PNG und TIFF. Verwenden Sie das vollständige Objektmodell, wenn Sie die Präsentation vor dem Export prüfen oder ändern oder eine Exportoption konfigurieren müssen, die vom ausgewählten Hilfsprogramm nicht bereitgestellt wird. Siehe [Präsentation konvertieren](/slides/de/net/convert-presentation/) für format‑spezifische Workflows und Optionen.

## **Präsentationen zusammenführen**

Verwenden Sie [Merger.Process](https://reference.aspose.com/slides/net/aspose.slides.lowcode/merger/process/), um komplette Präsentationsdateien mit einem Aufruf zu kombinieren. Die Eingabedateien müssen das gleiche Dateiformat haben.

```csharp
using Aspose.Slides.LowCode;

var inputFiles = new[] { "part-1.pptx", "part-2.pptx" };
Merger.Process(inputFiles, "merged.pptx");
```

Das Hilfsprogramm ist geeignet, wenn alle Folien zu einem Ergebnis hinzugefügt werden sollen, ohne sie einzeln auszuwählen oder neu zuzuordnen. Verwenden Sie das vollständige Objektmodell, wenn Sie ausgewählte Folien zusammenführen, einen Ziel‑Master oder ein Ziel‑Layout anwenden, Abschnitte explizit erhalten oder unterschiedliche Foliengrößen vereinheitlichen müssen. Siehe [Präsentationen zusammenführen](/slides/de/net/merge-presentation/) für diese Szenarien.

## **Durch Präsentationselemente iterieren**

Die [ForEach](https://reference.aspose.com/slides/net/aspose.slides.lowcode/foreach/) Klasse ruft für jeden angeforderten Typ von Präsentationselement einen Callback auf. Sie vermeidet verschachtelte Schleifen und ist praktisch für eine komplette Inspektion oder Formatierungsänderungen.

Das folgende Beispiel verwendet [ForEach.Slide](https://reference.aspose.com/slides/net/aspose.slides.lowcode/foreach/slide/), [ForEach.Shape](https://reference.aspose.com/slides/net/aspose.slides.lowcode/foreach/shape/), [ForEach.Paragraph](https://reference.aspose.com/slides/net/aspose.slides.lowcode/foreach/paragraph/) und [ForEach.Portion](https://reference.aspose.com/slides/net/aspose.slides.lowcode/foreach/portion/), um die entsprechenden Elemente zu untersuchen:

```csharp
using System;
using Aspose.Slides;
using Aspose.Slides.LowCode;

using var presentation = new Presentation("input.pptx");

ForEach.Slide(presentation, (slide, index) =>
{
    Console.WriteLine($"Slide {index}: {slide.Shapes.Count} shapes");
});

ForEach.Shape(presentation, (shape, slide, index) =>
{
    Console.WriteLine($"Shape {index} on {slide.GetType().Name}: {shape.Name}");
});

ForEach.Paragraph(presentation, (paragraph, slide, index) =>
{
    Console.WriteLine($"Paragraph {index} on {slide.GetType().Name}: {paragraph.Text}");
});

ForEach.Portion(presentation, (portion, paragraph, slide, index) =>
{
    Console.WriteLine($"Portion {index} on {slide.GetType().Name}: {portion.Text}");
});
```

Standardmäßig umfasst die bild‑ und textweite Durchlauf von Formen und Text normale, Master‑ und Layout‑Folien. Überladungen mit einem `includeNotes`‑Parameter können außerdem Notizfolien verarbeiten. Verwenden Sie direkte Schleifen, wenn die Durchlaufreihenfolge, ein früher Abbruch, Filterung vor dem Callback‑Aufruf oder eine detaillierte Eltern‑Kind‑Steuerung wichtig sind.

## **Formen sammeln**

Verwenden Sie [Collect.Shapes](https://reference.aspose.com/slides/net/aspose.slides.lowcode/collect/shapes/), wenn Sie eine Sammlung aller Formen in einer Präsentation benötigen, anstatt für jede Form einen Callback zu erhalten. Das ist nützlich, wenn derselbe Satz mehrfach gefiltert, gezählt oder verarbeitet werden soll.

```csharp
using System;
using Aspose.Slides;
using Aspose.Slides.LowCode;

using var presentation = new Presentation("input.pptx");
var shapes = Collect.Shapes(presentation);

foreach (var shape in shapes)
{
    Console.WriteLine($"{shape.Name}: {shape.GetType().Name}");
}
```

Verwenden Sie stattdessen [ForEach.Shape](https://reference.aspose.com/slides/net/aspose.slides.lowcode/foreach/shape/), wenn jede Form sofort verarbeitet werden kann und Sie das gesammelte Ergebnis nicht behalten müssen.

## **Präsentationsinhalt komprimieren**

Die [Compress](https://reference.aspose.com/slides/net/aspose.slides.lowcode/compress/) Klasse kann unbenutzte strukturelle Elemente entfernen und eingebettete Schriftartdaten reduzieren:

- [Compress.RemoveUnusedLayoutSlides](https://reference.aspose.com/slides/net/aspose.slides.lowcode/compress/removeunusedlayoutslides/) entfernt Layout‑Folien, auf die keine normale Folie verweist.
- [Compress.RemoveUnusedMasterSlides](https://reference.aspose.com/slides/net/aspose.slides.lowcode/compress/removeunusedmasterslides/) entfernt Master‑Folien, die nicht mehr verwendet werden.
- [Compress.CompressEmbeddedFonts](https://reference.aspose.com/slides/net/aspose.slides.lowcode/compress/compressembeddedfonts/) entfernt ungenutzte Zeichen aus eingebetteten Schriften.

```csharp
using Aspose.Slides;
using Aspose.Slides.Export;
using Aspose.Slides.LowCode;

using var presentation = new Presentation("input.pptx");

Compress.RemoveUnusedLayoutSlides(presentation);
Compress.RemoveUnusedMasterSlides(presentation);
Compress.CompressEmbeddedFonts(presentation);

presentation.Save("compressed.pptx", SaveFormat.Pptx);
```

Entfernen Sie ungenutzte Layouts vor ungenutzten Mastern, damit ein Master, der nach dem Layout‑Aufräumen nicht mehr referenziert wird, ebenfalls entfernt werden kann. Speichern Sie die optimierte Präsentation in einer neuen Datei, falls Sie die ursprünglichen Master, Layouts oder die kompletten eingebetteten Schriftartdaten später benötigen. Weitere Details finden Sie unter [Folienmaster](/slides/de/net/slide-master/) und [Eingebettete Schriftart](/slides/de/net/embedded-font/).

### **Gesamte Präsentation komprimieren**

Aspose.Slides for .NET 26.11 fügt [Compress.CompressPresentation](https://reference.aspose.com/slides/net/aspose.slides.lowcode/compress/compresspresentation/) hinzu. Sie kombiniert das Entfernen ungenutzter Layout‑/Master‑Folien, das Subsetzen eingebetteter Schriften auf verwendete Zeichen und die Bildkompression mit 150 DPI. Verwenden Sie die einzelnen oben beschriebenen Operationen, wenn Sie steuern möchten, welche Änderungen angewendet werden.

Installieren Sie [Aspose.Slides for .NET](/slides/de/net/installation/) 26.11 oder neuer und geben Sie `input.pptx` an. Speichern Sie in einer separaten Datei: Entfernte Layouts, Schriftzeichen und beschnittene Bildpixel können für spätere Bearbeitungen benötigt werden.

```csharp
using Aspose.Slides;
using Aspose.Slides.Export;
using Aspose.Slides.LowCode;

using var presentation = new Presentation("input.pptx");
Compress.CompressPresentation(presentation);
presentation.Save("compressed.pptx", SaveFormat.Pptx);
```

### **Bilder mit gewählter Auflösung komprimieren**

Verwenden Sie [Compress.CompressImages](https://reference.aspose.com/slides/net/aspose.slides.lowcode/compress/compressimages/), um geeignete Bilder zu verarbeiten, ohne gleichzeitig Layouts zu entfernen oder Schriften zu subsetzen. Dieses Beispiel verwendet 96 DPI; wählen Sie einen anderen [PicturesCompression](https://reference.aspose.com/slides/net/aspose.slides.export/picturescompression/)‑Wert für Ihre Ausgabeanforderungen.

```csharp
using Aspose.Slides;
using Aspose.Slides.Export;
using Aspose.Slides.LowCode;

using var presentation = new Presentation("input.pptx");
Compress.CompressImages(presentation, PicturesCompression.Dpi96);
presentation.Save("compressed-images.pptx", SaveFormat.Pptx);
```

Beide Hilfsprogramme nutzen den folgenden Bild‑Verarbeitungs‑Umfang:

| Inhalt | Behandlung |
| --- | --- |
| Rasterbilder und Bildfüllungen von Formen auf normalen, Master‑ und Layout‑Folien, einschließlich gruppierter Formen | Komprimierungsfähig. |
| Bilder, die bereits in der angeforderten oder einer niedrigeren Auflösung vorliegen | Nicht hochskaliert. Beschnittbereiche können weiterhin entfernt werden. |
| Beschnittene Bildbereiche | Versteckte Pixel werden dauerhaft entfernt und Beschnitt‑Offsets zurückgesetzt. |
| Folienhintergründe und Tabellenzellen‑Füllungen | Wird von diesen Hilfsprogrammen nicht verarbeitet. |
| Diagramm‑/SmartArt‑Interna, GIF‑ und Vektorformate wie SVG, EMF und WMF | Außerhalb des dokumentierten Bildkomprimierungs‑Umfangs. |

In 26.11 vermeidet [PicturesCompression.DocumentResolution](https://reference.aspose.com/slides/net/aspose.slides.export/picturescompression/) das auflösungsbasierte Downsampling eines unbeschnittenen Bildes, **preserviert jedoch keine beschnittenen Pixel**. Ein beschnittenes Bild kann weiterhin mit entfernten verborgenen Bereichen neu geschrieben werden. Keines der Hilfsprogramme bietet eine Option zum Erhalt des Beschnitts. Für individuelle Kontrolle siehe das [Beispiel für Bildkompression pro Bild](/slides/de/net/examples/optimization-batch/compression/).

Vergleichen Sie das Aussehen und die Dateigröße der Ausgabe, bevor Sie das Original ersetzen. Einsparungen hängen von den Quellbildern, ihrer Anzeigegröße und ungenutzten Inhalten ab; Kompression garantiert nicht immer eine kleinere Datei. Siehe [Eingebettete Schriften](/slides/de/net/embedded-font/) für die Auswirkungen des Schrift‑Subsettings.

## **FAQ**

**Wann sollte ich die Low‑Code‑API anstelle des vollständigen Objektmodells verwenden?**

Verwenden Sie Low‑Code‑Hilfsprogramme, wenn ein Standardvorgang auf eine komplette Datei oder Präsentation angewendet wird und keine detaillierte Kontrolle über einzelne Elemente erforderlich ist. Verwenden Sie das vollständige Objektmodell, wenn Sie bestimmte Folien auswählen, Master‑ und Layout‑Beziehungen steuern, Zwischenergebnisse prüfen oder ein Verhalten konfigurieren müssen, das das Hilfsprogramm nicht bereitstellt.

**Kann Merger Präsentationen in unterschiedlichen Dateiformaten kombinieren?**

Nein. [Merger.Process](https://reference.aspose.com/slides/net/aspose.slides.lowcode/merger/process/) erfordert Eingabedateien im gleichen Format. Konvertieren Sie die Eingabedateien zunächst in ein gemeinsames Format, zum Beispiel mit [Convert.AutoByExtension](https://reference.aspose.com/slides/net/aspose.slides.lowcode/convert/autobyextension/), und führen Sie anschließend die konvertierten Dateien zusammen.

**Verarbeitet ForEach Master‑, Layout‑ und Notizfolien?**

[ForEach.Slide](https://reference.aspose.com/slides/net/aspose.slides.lowcode/foreach/slide/) iteriert über normale Präsentationsfolien. Präsentationsweite [ForEach.Shape](https://reference.aspose.com/slides/net/aspose.slides.lowcode/foreach/shape/), [ForEach.Paragraph](https://reference.aspose.com/slides/net/aspose.slides.lowcode/foreach/paragraph/) und [ForEach.Portion](https://reference.aspose.com/slides/net/aspose.slides.lowcode/foreach/portion/) schließen standardmäßig normale, Master‑ und Layout‑Folien ein. Verwenden Sie deren Überladungen mit `includeNotes` = `true`, um Notizfolien einzubeziehen.

**Was ist der Unterschied zwischen ForEach.Shape und Collect.Shapes?**

Verwenden Sie [ForEach.Shape](https://reference.aspose.com/slides/net/aspose.slides.lowcode/foreach/shape/), um jede Form sofort über einen Callback zu verarbeiten. Verwenden Sie [Collect.Shapes](https://reference.aspose.com/slides/net/aspose.slides.lowcode/collect/shapes/), wenn Sie ein aufzählbares Ergebnis benötigen, das behalten, gefiltert, gezählt oder mehrmals durchlaufen werden kann.

**Macht Compress die Präsentationsdatei immer kleiner?**

Nicht unbedingt. Einsparungen hängen von ungenutzten Layouts/Mastern, eingebetteten Schriften mit ungenutzten Zeichen und Bildern ab, die von einer Kompression profitieren. Die [Compress](https://reference.aspose.com/slides/net/aspose.slides.lowcode/compress/)‑Hilfsprogramme können die Größe unverändert lassen oder bei manchen Eingaben sogar eine größere Datei erzeugen. Vergleichen Sie sowohl Größe als auch gerenderte Qualität und behalten Sie das Original.

**Werden Änderungen, die von ForEach oder Compress vorgenommen wurden, automatisch gespeichert?**

Nein. Diese Hilfsprogramme arbeiten auf dem geladenen [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation/)‑Objekt im Speicher. Nachdem Sie Elemente in einem [ForEach](https://reference.aspose.com/slides/net/aspose.slides.lowcode/foreach/)‑Callback geändert oder [Compress](https://reference.aspose.com/slides/net/aspose.slides.lowcode/compress/) ausgeführt haben, rufen Sie [Presentation.Save](https://reference.aspose.com/slides/net/aspose.slides/presentation/save/) auf, um das Ergebnis zu schreiben.

## **Verwandte Artikel**

- [Präsentation konvertieren](/slides/de/net/convert-presentation/)
- [Präsentationen zusammenführen](/slides/de/net/merge-presentation/)
- [Folienmaster](/slides/de/net/slide-master/)
- [Textfeld verwalten](/slides/de/net/manage-textbox/)
- [Eingebettete Schriftart](/slides/de/net/embedded-font/)