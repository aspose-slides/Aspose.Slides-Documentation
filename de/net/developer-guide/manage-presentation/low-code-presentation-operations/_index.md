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
- Shapes iterieren
- Text iterieren
- Shapes sammeln
- Präsentation komprimieren
- Unbenutzte Masterfolien entfernen
- Unbenutzte Layoutfolien entfernen
- Eingebettete Schriftarten komprimieren
- PowerPoint
- OpenDocument
- Präsentation
- .NET
- C#
- Aspose.Slides
description: "Verwenden Sie die Aspose.Slides Low-Code-API in .NET, um Präsentationen zu konvertieren und zusammenzuführen, Inhalte zu iterieren, Shapes zu sammeln und die Präsentationsgröße zu reduzieren."
---
## **Übersicht**

Der Namespace [Aspose.Slides.LowCode](https://reference.aspose.com/slides/de/net/aspose.slides.lowcode/) stellt statische Hilfsklassen für gängige Präsentationsoperationen bereit. Diese Helfer kapseln häufig genutzte Objektmodell‑Arbeitsabläufe in fokussierten Methoden, sodass Sie Dateien konvertieren oder zusammenführen, Präsentationselemente verarbeiten, Shapes sammeln und ungenutzte Inhalte mit weniger Code entfernen können.

Low‑Code‑Hilfsmittel sind am nützlichsten, wenn die Operation auf eine gesamte Datei oder Präsentation angewendet wird und der Standard‑Arbeitsablauf Ihren Anforderungen entspricht. Verwenden Sie das vollständige Aspose.Slides‑Objektmodell, wenn Sie eine feinkörnige Kontrolle über einzelne Folien, Master, Layouts, Shapes, Exporteinstellungen oder Beziehungen zwischen Präsentationselementen benötigen.

Die folgende Tabelle fasst die verfügbaren Hilfsmittel zusammen:

| Hilfsmittel | Verwendung |
| --- | --- |
| [Convert](https://reference.aspose.com/slides/de/net/aspose.slides.lowcode/convert/) | Konvertieren einer Präsentation in ein anderes Format mit einem direkten Datei‑zu‑Datei‑Aufruf. |
| [Merger](https://reference.aspose.com/slides/de/net/aspose.slides.lowcode/merger/) | Kombinieren vollständiger Präsentationsdateien desselben Formats. |
| [ForEach](https://reference.aspose.com/slides/de/net/aspose.slides.lowcode/foreach/) | Ausführen einer Aktion für jede Folie, jedes Shape, jeden Absatz oder Textabschnitt. |
| [Collect](https://reference.aspose.com/slides/de/net/aspose.slides.lowcode/collect/) | Abrufen von Shapes aus der gesamten Präsentation für wiederholte Verarbeitung oder Analyse. |
| [Compress](https://reference.aspose.com/slides/de/net/aspose.slides.lowcode/compress/) | Entfernen ungenutzter Master und Layouts sowie Reduzieren eingebetteter Schriftartdaten. |

## **Eine Präsentation konvertieren**

Verwenden Sie [Convert.AutoByExtension](https://reference.aspose.com/slides/de/net/aspose.slides.lowcode/convert/autobyextension/), wenn die Dateierweiterung der Ausgabedatei ausreicht, um das Exportformat zu bestimmen. Die Methode öffnet die Quellpräsentation, ermittelt das erforderliche Format aus dem Ausgabepfad und schreibt das Ergebnis.

```csharp
using Aspose.Slides.LowCode;

Convert.AutoByExtension("input.pptx", "output.pdf");
```

Die [Convert](https://reference.aspose.com/slides/de/net/aspose.slides.lowcode/convert/)‑Klasse stellt zudem spezielle Methoden für die Ausgabe als PDF, SVG, JPEG, PNG und TIFF bereit. Verwenden Sie das vollständige Objektmodell, wenn Sie die Präsentation vor dem Export prüfen oder ändern müssen oder eine Exportoption konfigurieren wollen, die vom gewählten Hilfsmittel nicht bereitgestellt wird. Siehe [Convert Presentation](/slides/de/net/convert-presentation/) für formatbezogene Arbeitsabläufe und Optionen.

## **Präsentationen zusammenführen**

Verwenden Sie [Merger.Process](https://reference.aspose.com/slides/de/net/aspose.slides.lowcode/merger/process/), um vollständige Präsentationsdateien mit einem Aufruf zu kombinieren. Die Eingabedateien müssen dasselbe Dateiformat besitzen.

```csharp
using Aspose.Slides.LowCode;

var inputFiles = new[] { "part-1.pptx", "part-2.pptx" };
Merger.Process(inputFiles, "merged.pptx");
```

Das Hilfsmittel ist geeignet, wenn alle Folien zu einem Ergebnis hinzugefügt werden sollen, ohne sie einzeln auszuwählen oder neu zuzuordnen. Verwenden Sie das vollständige Objektmodell, wenn Sie ausgewählte Folien zusammenführen, einen Ziel‑Master oder -Layout anwenden, Abschnitte explizit erhalten oder unterschiedliche Foliengrößen angleichen müssen. Siehe [Merge Presentations](/slides/de/net/merge-presentation/) für diese Szenarien.

## **Durch Präsentationselemente iterieren**

Die [ForEach](https://reference.aspose.com/slides/de/net/aspose.slides.lowcode/foreach/)‑Klasse ruft für jeden gewünschten Typ von Präsentationselement einen Callback auf. Sie vermeidet verschachtelte Sammlungsschleifen und ist praktisch für eine präsentationsweite Inspektion oder Formatierungsänderungen.

Das folgende Beispiel verwendet [ForEach.Slide](https://reference.aspose.com/slides/de/net/aspose.slides.lowcode/foreach/slide/), [ForEach.Shape](https://reference.aspose.com/slides/de/net/aspose.slides.lowcode/foreach/shape/), [ForEach.Paragraph](https://reference.aspose.com/slides/de/net/aspose.slides.lowcode/foreach/paragraph/), und [ForEach.Portion](https://reference.aspose.com/slides/de/net/aspose.slides.lowcode/foreach/portion/) , um die entsprechenden Elemente zu inspizieren:

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

Standardmäßig umfasst die präsentationsweite Shape‑ und Text‑Durchquerung normale Folien sowie Master‑ und Layout‑Folien. Überladungen mit einem `includeNotes`‑Parameter können auch Notizfolien verarbeiten. Verwenden Sie direkte Sammlungsschleifen, wenn die Durchlaufreihenfolge, ein vorzeitiger Abbruch, Filtern vor dem Callback‑Aufruf oder eine detaillierte Eltern‑Kind‑Steuerung wichtig sind.

## **Shapes sammeln**

Verwenden Sie [Collect.Shapes](https://reference.aspose.com/slides/de/net/aspose.slides.lowcode/collect/shapes/), wenn Sie eine Sammlung aller Shapes in einer Präsentation benötigen, anstatt für jedes Shape einen Callback zu erhalten. Dies ist nützlich, wenn derselbe Satz mehrfach gefiltert, gezählt oder verarbeitet werden soll.

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

Verwenden Sie stattdessen [ForEach.Shape](https://reference.aspose.com/slides/de/net/aspose.slides.lowcode/foreach/shape/), wenn jedes Shape sofort verarbeitet werden kann und Sie das gesammelte Ergebnis nicht behalten müssen.

## **Präsentationsinhalt komprimieren**

Die [Compress](https://reference.aspose.com/slides/de/net/aspose.slides.lowcode/compress/)‑Klasse kann ungenutzte Strukturelemente entfernen und eingebettete Schriftartdaten reduzieren:

- [Compress.RemoveUnusedLayoutSlides](https://reference.aspose.com/slides/de/net/aspose.slides.lowcode/compress/removeunusedlayoutslides/) entfernt Layout‑Folien, auf die keine normale Folie verweist.
- [Compress.RemoveUnusedMasterSlides](https://reference.aspose.com/slides/de/net/aspose.slides.lowcode/compress/removeunusedmasterslides/) entfernt Master‑Folien, die nicht mehr verwendet werden.
- [Compress.CompressEmbeddedFonts](https://reference.aspose.com/slides/de/net/aspose.slides.lowcode/compress/compressembeddedfonts/) entfernt ungenutzte Zeichen aus eingebetteten Schriftarten.

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

Entfernen Sie ungenutzte Layouts vor ungenutzten Mastern, damit ein Master, der nach der Layout‑Bereinigung nicht mehr referenziert wird, ebenfalls entfernt werden kann. Speichern Sie die optimierte Präsentation in einer neuen Datei, falls Sie später die ursprünglichen Master, Layouts oder die vollständigen eingebetteten Schriftartdaten benötigen. Weitere Details finden Sie unter [Slide Master](/slides/de/net/slide-master/) und [Embedded Font](/slides/de/net/embedded-font/).

## **FAQ**

**Wann sollte ich die Low‑Code‑API anstelle des vollständigen Objektmodells verwenden?**

Verwenden Sie Low‑Code‑Hilfsmittel, wenn eine Standardoperation auf eine komplette Datei oder Präsentation angewendet wird und keine detaillierte Kontrolle über einzelne Elemente erfordert. Verwenden Sie das vollständige Objektmodell, wenn Sie bestimmte Folien auswählen, Beziehungen zwischen Master und Layout steuern, Zwischenzustände prüfen oder ein Verhalten konfigurieren müssen, das das Hilfsmittel nicht bereitstellt.

**Kann Merger Präsentationen in verschiedenen Dateiformaten kombinieren?**

Nein. Merger.Process erfordert, dass die Eingabedateien dasselbe Format besitzen. Konvertieren Sie die Eingabedateien zunächst in ein gemeinsames Format, zum Beispiel mit [Convert.AutoByExtension](https://reference.aspose.com/slides/de/net/aspose.slides.lowcode/convert/autobyextension/), und führen Sie anschließend die konvertierten Dateien zusammen.

**Verarbeitet ForEach Master‑, Layout‑ und Notizfolien?**

[ForEach.Slide](https://reference.aspose.com/slides/de/net/aspose.slides.lowcode/foreach/slide/) iteriert über die normalen Präsentationsfolien. Präsentationsweite [ForEach.Shape](https://reference.aspose.com/slides/de/net/aspose.slides.lowcode/foreach/shape/), [ForEach.Paragraph](https://reference.aspose.com/slides/de/net/aspose.slides.lowcode/foreach/paragraph/), und [ForEach.Portion](https://reference.aspose.com/slides/de/net/aspose.slides.lowcode/foreach/portion/) schließen standardmäßig normale, Master‑ und Layout‑Folien ein. Verwenden Sie deren Überladungen mit `includeNotes` auf `true`, um Notizfolien mit einzubeziehen.

**Was ist der Unterschied zwischen ForEach.Shape und Collect.Shapes?**

Verwenden Sie [ForEach.Shape](https://reference.aspose.com/slides/de/net/aspose.slides.lowcode/foreach/shape/), um jedes Shape sofort über einen Callback zu verarbeiten. Verwenden Sie [Collect.Shapes](https://reference.aspose.com/slides/de/net/aspose.slides.lowcode/collect/shapes/), wenn Sie ein aufzählbares Ergebnis benötigen, das behalten, gefiltert, gezählt oder mehrfach durchlaufen werden kann.

**Macht Compress immer die Präsentationsdatei kleiner?**

Nicht unbedingt. Das Ergebnis hängt davon ab, ob die Präsentation ungenutzte Layouts, ungenutzte Master oder eingebettete Schriftarten mit ungenutzten Zeichen enthält. Wenn keiner dieser Fälle vorliegt, reduzieren die entsprechenden Compress‑Operationen die Dateigröße möglicherweise nicht.

**Werden Änderungen durch ForEach oder Compress automatisch gespeichert?**

Nein. Diese Hilfsmittel arbeiten auf dem geladenen [Presentation](https://reference.aspose.com/slides/de/net/aspose.slides/presentation/)‑Objekt im Speicher. Nach Änderungen an Elementen in einem [ForEach](https://reference.aspose.com/slides/de/net/aspose.slides.lowcode/foreach/)‑Callback oder nach dem Ausführen von [Compress](https://reference.aspose.com/slides/de/net/aspose.slides.lowcode/compress/), rufen Sie [Presentation.Save](https://reference.aspose.com/slides/de/net/aspose.slides/presentation/save/) auf, um das Ergebnis zu schreiben.

## **Verwandte Artikel**

- [Convert Presentation](/slides/de/net/convert-presentation/)
- [Merge Presentations](/slides/de/net/merge-presentation/)
- [Slide Master](/slides/de/net/slide-master/)
- [Manage Text Box](/slides/de/net/manage-textbox/)
- [Embedded Font](/slides/de/net/embedded-font/)