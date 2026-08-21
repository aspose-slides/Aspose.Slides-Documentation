---
title: Operacje prezentacji Low-Code w .NET
linktitle: API Low-Code
type: docs
weight: 50
url: /pl/net/low-code-presentation-operations/
keywords:
- API prezentacji low-code
- konwersja prezentacji
- łączenie prezentacji
- iteracja slajdów
- iteracja kształtów
- iteracja tekstu
- zbieranie kształtów
- kompresja prezentacji
- usuwanie nieużywanych slajdów master
- usuwanie nieużywanych slajdów układu
- kompresja osadzonych czcionek
- PowerPoint
- OpenDocument
- prezentacja
- .NET
- C#
- Aspose.Slides
description: "Użyj API low-code Aspose.Slides w .NET, aby konwertować i łączyć prezentacje, iterować zawartość, zbierać kształty i zmniejszać rozmiar prezentacji."
---
## **Przegląd**

The [Aspose.Slides.LowCode](https://reference.aspose.com/slides/pl/net/aspose.slides.lowcode/) namespace provides static helper classes for common presentation operations. These helpers wrap frequently used object-model workflows in focused methods, so you can convert or merge files, process presentation elements, collect shapes, and remove unused content with less code.

Low-code helpers are most useful when the operation applies to an entire file or presentation and the default workflow matches your requirements. Use the full [Aspose.Slides object model](https://reference.aspose.com/slides/pl/net/aspose.slides/) when you need fine-grained control over individual slides, masters, layouts, shapes, export settings, or relationships between presentation elements.

The following table summarizes the available helpers:

| Pomocnik | Zastosowanie |
| --- | --- |
| [Convert](https://reference.aspose.com/slides/pl/net/aspose.slides.lowcode/convert/) | Konwertowanie prezentacji na inny format przy użyciu bezpośredniego wywołania plik-do-pliku. |
| [Merger](https://reference.aspose.com/slides/pl/net/aspose.slides.lowcode/merger/) | Łączenie kompletnych plików prezentacji tego samego formatu. |
| [ForEach](https://reference.aspose.com/slides/pl/net/aspose.slides.lowcode/foreach/) | Wykonywanie akcji dla każdego slajdu, kształtu, akapitu lub fragmentu tekstu. |
| [Collect](https://reference.aspose.com/slides/pl/net/aspose.slides.lowcode/collect/) | Pobieranie kształtów z całej prezentacji w celu wielokrotnego przetwarzania lub analizy. |
| [Compress](https://reference.aspose.com/slides/pl/net/aspose.slides.lowcode/compress/) | Usuwanie nieużywanych masterów i układów oraz zmniejszanie danych osadzonych czcionek. |

## **Konwertowanie prezentacji**

Use [Convert.AutoByExtension](https://reference.aspose.com/slides/pl/net/aspose.slides.lowcode/convert/autobyextension/) when the output file extension is sufficient to select the export format. The method opens the source presentation, determines the required format from the output path, and writes the result.

```csharp
using Aspose.Slides.LowCode;

Convert.AutoByExtension("input.pptx", "output.pdf");
```

The [Convert](https://reference.aspose.com/slides/pl/net/aspose.slides.lowcode/convert/) class also provides dedicated methods for PDF, SVG, JPEG, PNG, and TIFF output. Use the full object model when you need to inspect or modify the presentation before export or configure an export option that is not exposed by the selected helper. See [Convert Presentation](/net/convert-presentation/) for format-specific workflows and options.

## **Scalanie prezentacji**

Use [Merger.Process](https://reference.aspose.com/slides/pl/net/aspose.slides.lowcode/merger/process/) to combine complete presentation files with one call. The input presentations must have the same file format.

```csharp
using Aspose.Slides.LowCode;

var inputFiles = new[] { "part-1.pptx", "part-2.pptx" };
Merger.Process(inputFiles, "merged.pptx");
```

The helper is appropriate when all slides should be appended to one result without selecting or remapping them individually. Use the full object model when you need to merge selected slides, apply a destination master or layout, preserve sections explicitly, or reconcile different slide sizes. See [Merge Presentations](/net/merge-presentation/) for those scenarios.

## **Iterowanie po elementach prezentacji**

The [ForEach](https://reference.aspose.com/slides/pl/net/aspose.slides.lowcode/foreach/) class invokes a callback for each requested type of presentation element. It avoids nested collection loops and is convenient for presentation-wide inspection or formatting changes.

The following example uses [ForEach.Slide](https://reference.aspose.com/slides/pl/net/aspose.slides.lowcode/foreach/slide/), [ForEach.Shape](https://reference.aspose.com/slides/pl/net/aspose.slides.lowcode/foreach/shape/), [ForEach.Paragraph](https://reference.aspose.com/slides/pl/net/aspose.slides.lowcode/foreach/paragraph/), and [ForEach.Portion](https://reference.aspose.com/slides/pl/net/aspose.slides.lowcode/foreach/portion/) to inspect the corresponding elements:

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

By default, presentation-wide shape and text traversal includes normal, master, and layout slides. Overloads with an `includeNotes` parameter can also process notes slides. Use direct collection loops when traversal order, early exit, filtering before callback invocation, or detailed parent-child control is important.

## **Zbieranie kształtów**

Use [Collect.Shapes](https://reference.aspose.com/slides/pl/net/aspose.slides.lowcode/collect/shapes/) when you need a collection of all shapes in a presentation rather than a callback for each shape. This is useful when the same set will be filtered, counted, or processed more than once.

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

Use [ForEach.Shape](https://reference.aspose.com/slides/pl/net/aspose.slides.lowcode/foreach/shape/) instead when each shape can be handled immediately and you do not need to retain the collected result.

## **Kompresja zawartości prezentacji**

The [Compress](https://reference.aspose.com/slides/pl/net/aspose.slides.lowcode/compress/) class can remove unused structural elements and reduce embedded font data:

- [Compress.RemoveUnusedLayoutSlides](https://reference.aspose.com/slides/pl/net/aspose.slides.lowcode/compress/removeunusedlayoutslides/) usuwa slajdy układów, które nie są referowane przez żaden normalny slajd.
- [Compress.RemoveUnusedMasterSlides](https://reference.aspose.com/slides/pl/net/aspose.slides.lowcode/compress/removeunusedmasterslides/) usuwa master slajdy, które nie są już używane.
- [Compress.CompressEmbeddedFonts](https://reference.aspose.com/slides/pl/net/aspose.slides.lowcode/compress/compressembeddedfonts/) usuwa nieużywane znaki z osadzonych czcionek.

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

Remove unused layouts before unused masters so a master that becomes unreferenced after layout cleanup can also be removed. Save the optimized presentation to a new file if you may need the original masters, layouts, or complete embedded font data later. For more detail, see [Slide Master](/net/slide-master/) and [Embedded Font](/net/embedded-font/).

## **FAQ**

**Kiedy powinienem używać API low-code zamiast pełnego modelu obiektowego?**

Używaj pomocników low-code, gdy standardowa operacja dotyczy całego pliku lub prezentacji i nie wymaga szczegółowej kontroli nad poszczególnymi elementami. Użyj pełnego modelu obiektowego, gdy potrzebujesz wybrać konkretne slajdy, kontrolować zależności master‑layout, sprawdzić stan pośredni lub skonfigurować zachowanie, które nie jest udostępnione przez pomocnika.

**Czy Merger może łączyć prezentacje w różnych formatach plików?**

Nie. [Merger.Process](https://reference.aspose.com/slides/pl/net/aspose.slides.lowcode/merger/process/) wymaga, aby prezentacje wejściowe były w tym samym formacie. Najpierw skonwertuj pliki wejściowe do wspólnego formatu, na przykład przy użyciu [Convert.AutoByExtension](https://reference.aspose.com/slides/pl/net/aspose.slides.lowcode/convert/autobyextension/), a następnie scal przetworzone pliki.

**Czy ForEach przetwarza slajdy master, layout i notatki?**

[ForEach.Slide](https://reference.aspose.com/slides/pl/net/aspose.slides.lowcode/foreach/slide/) iteruje przez normalne slajdy prezentacji. Operacje [ForEach.Shape](https://reference.aspose.com/slides/pl/net/aspose.slides.lowcode/foreach/shape/), [ForEach.Paragraph](https://reference.aspose.com/slides/pl/net/aspose.slides.lowcode/foreach/paragraph/) i [ForEach.Portion](https://reference.aspose.com/slides/pl/net/aspose.slides.lowcode/foreach/portion/) obejmują domyślnie normalne, master i layout slajdy w całej prezentacji. Użyj ich przeciążeń z parametrem `includeNotes` ustawionym na `true`, aby uwzględnić slajdy notatek.

**Jaka jest różnica między ForEach.Shape a Collect.Shapes?**

Użyj [ForEach.Shape](https://reference.aspose.com/slides/pl/net/aspose.slides.lowcode/foreach/shape/), aby przetworzyć każdy kształt od razu za pomocą callbacku. Użyj [Collect.Shapes](https://reference.aspose.com/slides/pl/net/aspose.slides.lowcode/collect/shapes/), gdy potrzebujesz wyniku enumerable, który może być zachowany, filtrowany, liczony lub przeglądany wielokrotnie.

**Czy Compress zawsze zmniejsza rozmiar pliku prezentacji?**

Nie zawsze. Wynik zależy od tego, czy w prezentacji znajdują się nieużywane układy, nieużywane mastery lub osadzone czcionki z nieużywanymi znakami. Jeśli żadne z tych elementów nie występują, odpowiednie operacje [Compress](https://reference.aspose.com/slides/pl/net/aspose.slides.lowcode/compress/) mogą nie zmniejszyć rozmiaru pliku.

**Czy zmiany wprowadzone przez ForEach lub Compress są zapisywane automatycznie?**

Nie. Te pomocniki działają na wczytanym w pamięci obiekcie [Presentation](https://reference.aspose.com/slides/pl/net/aspose.slides/presentation/), po zmianie elementów w callbacku [ForEach](https://reference.aspose.com/slides/pl/net/aspose.slides.lowcode/foreach/) lub po uruchomieniu [Compress](https://reference.aspose.com/slides/pl/net/aspose.slides.lowcode/compress/), wywołaj [Presentation.Save](https://reference.aspose.com/slides/pl/net/aspose.slides/presentation/save/), aby zapisać wynik.

## **Powiązane artykuły**

- [Convert Presentation](/net/convert-presentation/)
- [Merge Presentations](/net/merge-presentation/)
- [Slide Master](/net/slide-master/)
- [Manage Text Box](/net/manage-textbox/)
- [Embedded Font](/net/embedded-font/)