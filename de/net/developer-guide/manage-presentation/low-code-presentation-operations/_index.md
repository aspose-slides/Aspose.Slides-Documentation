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
- Eingebettete Schriftarten komprimieren
- PowerPoint
- OpenDocument
- Präsentation
- .NET
- C#
- Aspose.Slides
description: "Verwenden Sie die Aspose.Slides Low-Code-API in .NET, um Präsentationen zu konvertieren und zusammenzuführen, Inhalte zu iterieren, Formen zu sammeln und die Größe der Präsentation zu reduzieren."
---
## **Übersicht**

Der [Aspose.Slides.LowCode](https://reference.aspose.com/slides/de/net/aspose.slides.lowcode/) Namespace stellt statische Hilfsklassen für gängige Präsentationsvorgänge bereit. Diese Helfer kapseln häufig verwendete Objektmodell‑Workflows in fokussierten Methoden, sodass Sie Dateien konvertieren oder zusammenführen, Präsentationselemente verarbeiten, Formen sammeln und ungenutzte Inhalte mit weniger Code entfernen können.

Low‑Code‑Helfer sind am nützlichsten, wenn der Vorgang auf eine gesamte Datei oder Präsentation angewendet wird und der Standard‑Workflow Ihren Anforderungen entspricht. Verwenden Sie das vollständige [Aspose.Slides‑Objektmodell](https://reference.aspose.com/slides/de/net/aspose.slides/), wenn Sie eine feinkörnige Kontrolle über einzelne Folien, Master, Layouts, Formen, Exporteinstellungen oder Beziehungen zwischen Präsentationselementen benötigen.

Die folgende Tabelle fasst die verfügbaren Helfer zusammen:

| Hilfsklasse | Verwendungszweck |
| --- | --- |
| [Convert](https://reference.aspose.com/slides/de/net/aspose.slides.lowcode/convert/) | Eine Präsentation in ein anderes Format konvertieren – direkter Datei‑zu‑Datei‑Aufruf. |
| [Merger](https://reference.aspose.com/slides/de/net/aspose.slides.lowcode/merger/) | Vollständige Präsentationsdateien desselben Formats kombinieren. |
| [ForEach](https://reference.aspose.com/slides/de/net/aspose.slides.lowcode/foreach/) | Eine Aktion für jede Folie, Form, Absatz oder Textportion ausführen. |
| [Collect](https://reference.aspose.com/slides/de/net/aspose.slides.lowcode/collect/) | Formen aus der gesamten Präsentation abrufen, um sie wiederholt zu verarbeiten oder zu analysieren. |
| [Compress](https://reference.aspose.com/slides/de/net/aspose.slides.lowcode/compress/) | Unbenutzte Master‑ und Layout‑Folien entfernen und eingebettete Schriftartdaten reduzieren. |

## **Eine Präsentation konvertieren**

Verwenden Sie [Convert.AutoByExtension](https://reference.aspose.com/slides/de/net/aspose.slides.lowcode/convert/autobyextension/), wenn die Dateierweiterung des Ausgabedokuments ausreicht, um das Exportformat zu bestimmen. Die Methode öffnet die Quellpräsentation, ermittelt das erforderliche Format aus dem Ausgabepfad und schreibt das Ergebnis.

```csharp
using Aspose.Slides.LowCode;

Convert.AutoByExtension("input.pptx", "output.pdf");
```

Die [Convert](https://reference.aspose.com/slides/de/net/aspose.slides.lowcode/convert/)‑Klasse stellt zudem dedizierte Methoden für die Ausgabe nach PDF, SVG, JPEG, PNG und TIFF bereit. Verwenden Sie das vollständige Objektmodell, wenn Sie die Präsentation vor dem Export inspizieren oder ändern oder eine Exportoption konfigurieren müssen, die vom ausgewählten Helfer nicht bereitgestellt wird. Siehe [Convert Presentation](/net/convert-presentation/) für format‑spezifische Workflows und Optionen.

## **Präsentationen zusammenführen**

Verwenden Sie [Merger.Process](https://reference.aspose.com/slides/de/net/aspose.slides.lowcode/merger/process/), um komplette Präsentationsdateien mit einem Aufruf zu kombinieren. Die Eingabedateien müssen dasselbe Dateiformat besitzen.

```csharp
using Aspose.Slides.LowCode;

var inputFiles = new[] { "part-1.pptx", "part-2.pptx" };
Merger.Process(inputFiles, "merged.pptx");
```

Der Helfer ist geeignet, wenn alle Folien zu einem Ergebnis hinzugefügt werden sollen, ohne sie einzeln auszuwählen oder neu zuzuordnen. Verwenden Sie das vollständige Objektmodell, wenn Sie ausgewählte Folien zusammenführen, einen Ziel‑Master oder -Layout anwenden, Abschnitte explizit erhalten oder unterschiedliche Foliengrößen abgleichen müssen. Siehe [Merge Presentations](/net/merge-presentation/) für diese Szenarien.

## **Durch Präsentationselemente iterieren**

Die [ForEach](https://reference.aspose.com/slides/de/net/aspose.slides.lowcode/foreach/)‑Klasse ruft für jeden angeforderten Typ von Präsentationselement einen Callback auf. Sie vermeidet verschachtelte Sammlungsschleifen und ist praktisch für eine prüfende oder formatierende Durchsicht der gesamten Präsentation.

Das folgende Beispiel verwendet [ForEach.Slide](https://reference.aspose.com/slides/de/net/aspose.slides.lowcode/foreach/slide/), [ForEach.Shape](https://reference.aspose.com/slides/de/net/aspose.slides.lowcode/foreach/shape/), [ForEach.Paragraph](https://reference.aspose.com/slides/de/net/aspose.slides.lowcode/foreach/paragraph/) und [ForEach.Portion](https://reference.aspose.com/slides/de/net/aspose.slides.lowcode/foreach/portion/), um die entsprechenden Elemente zu inspizieren:

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

Standardmäßig beinhaltet die Traversierung von Formen und Text die normalen, Master‑ und Layout‑Folien. Überladungen mit einem `includeNotes`‑Parameter können außerdem Notizfolien verarbeiten. Verwenden Sie direkte Sammlungsschleifen, wenn die Reihenfolge der Traversierung, ein frühzeitiger Abbruch, Filterung vor dem Callback‑Aufruf oder eine detaillierte Eltern‑Kind‑Steuerung wichtig sind.

## **Formen sammeln**

Verwenden Sie [Collect.Shapes](https://reference.aspose.com/slides/de/net/aspose.slides.lowcode/collect/shapes/), wenn Sie eine Sammlung aller Formen einer Präsentation benötigen, anstatt für jede Form einen Callback zu erhalten. Dies ist nützlich, wenn dieselbe Menge mehrfach gefiltert, gezählt oder verarbeitet werden soll.

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

Verwenden Sie stattdessen [ForEach.Shape](https://reference.aspose.com/slides/de/net/aspose.slides.lowcode/foreach/shape/), wenn jede Form sofort bearbeitet werden kann und Sie das gesammelte Ergebnis nicht behalten müssen.

## **Präsentationsinhalt komprimieren**

Die [Compress](https://reference.aspose.com/slides/de/net/aspose.slides.lowcode/compress/)‑Klasse kann unbenutzte Strukturelemente entfernen und eingebettete Schriftartdaten reduzieren:

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

Entfernen Sie ungenutzte Layouts, bevor Sie ungenutzte Master entfernen, damit ein Master, der nach der Layout‑Bereinigung nicht mehr referenziert wird, ebenfalls gelöscht werden kann. Speichern Sie die optimierte Präsentation in einer neuen Datei, falls Sie die ursprünglichen Master, Layouts oder die vollständigen eingebetteten Schriftartdaten später benötigen. Weitere Details finden Sie unter [Slide Master](/net/slide-master/) und [Embedded Font](/net/embedded-font/).

## **FAQ**

**Wann sollte ich die Low‑Code‑API statt des vollständigen Objektmodells verwenden?**

Verwenden Sie Low‑Code‑Helfer, wenn ein Standardvorgang auf eine komplette Datei oder Präsentation angewendet wird und keine detaillierte Kontrolle über einzelne Elemente erforderlich ist. Verwenden Sie das vollständige Objektmodell, wenn Sie bestimmte Folien auswählen, Master‑ und Layout‑Beziehungen steuern, den Zwischenzustand prüfen oder Verhalten konfigurieren müssen, das der Helfer nicht bereitstellt.

**Kann Merger Präsentationen in unterschiedlichen Dateiformaten kombinieren?**

Nein. [Merger.Process](https://reference.aspose.com/slides/de/net/aspose.slides.lowcode/merger/process/) erfordert Eingabedateien im selben Format. Konvertieren Sie die Eingabedateien zuerst in ein gemeinsames Format, z. B. mit [Convert.AutoByExtension](https://reference.aspose.com/slides/de/net/aspose.slides.lowcode/convert/autobyextension/), und führen Sie anschließend die konvertierten Dateien zusammen.

**Verarbeitet ForEach Master‑, Layout‑ und Notizfolien?**

[ForEach.Slide](https://reference.aspose.com/slides/de/net/aspose.slides.lowcode/foreach/slide/) iteriert über normale Präsentationsfolien. Präsentationsweite [ForEach.Shape](https://reference.aspose.com/slides/de/net/aspose.slides.lowcode/foreach/shape/), [ForEach.Paragraph](https://reference.aspose.com/slides/de/net/aspose.slides.lowcode/foreach/paragraph/) und [ForEach.Portion](https://reference.aspose.com/slides/de/net/aspose.slides.lowcode/foreach/portion/) schließen standardmäßig normale, Master‑ und Layout‑Folien ein. Verwenden Sie ihre Überladungen mit `includeNotes` = `true`, um Notizfolien einzubeziehen.

**Was ist der Unterschied zwischen ForEach.Shape und Collect.Shapes?**

Verwenden Sie [ForEach.Shape](https://reference.aspose.com/slides/de/net/aspose.slides.lowcode/foreach/shape/), um jede Form sofort über einen Callback zu verarbeiten. Verwenden Sie [Collect.Shapes](https://reference.aspose.com/slides/de/net/aspose.slides.lowcode/collect/shapes/), wenn Sie ein aufzählbares Ergebnis benötigen, das behalten, gefiltert, gezählt oder mehrfach durchlaufen werden kann.

**Macht Compress immer die Präsentationsdatei kleiner?**

Nicht unbedingt. Das Ergebnis hängt davon ab, ob die Präsentation ungenutzte Layouts, ungenutzte Master oder eingebettete Schriftarten mit ungenutzten Zeichen enthält. Wenn keiner dieser Fälle vorliegt, reduzieren die entsprechenden [Compress](https://reference.aspose.com/slides/de/net/aspose.slides.lowcode/compress/)‑Operationen möglicherweise die Dateigröße nicht.

**Werden Änderungen durch ForEach oder Compress automatisch gespeichert?**

Nein. Diese Helfer arbeiten auf dem geladenen [Presentation](https://reference.aspose.com/slides/de/net/aspose.slides/presentation/)‑Objekt im Speicher. Nachdem Sie Elemente in einem [ForEach](https://reference.aspose.com/slides/de/net/aspose.slides.lowcode/foreach/)‑Callback geändert oder [Compress](https://reference.aspose.com/slides/de/net/aspose.slides.lowcode/compress/) ausgeführt haben, rufen Sie [Presentation.Save](https://reference.aspose.com/slides/de/net/aspose.slides/presentation/save/) auf, um das Ergebnis zu schreiben.

## **Verwandte Artikel**

- [Convert Presentation](/net/convert-presentation/)
- [Merge Presentations](/net/merge-presentation/)
- [Slide Master](/net/slide-master/)
- [Manage Text Box](/net/manage-textbox/)
- [Embedded Font](/net/embedded-font/)