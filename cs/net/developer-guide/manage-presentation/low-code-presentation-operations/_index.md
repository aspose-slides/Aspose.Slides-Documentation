---
title: Operace prezentace s nízkým kódem v .NET
linktitle: API s nízkým kódem
type: docs
weight: 50
url: /cs/net/low-code-presentation-operations/
keywords:
- API pro prezentaci s nízkým kódem
- převod prezentace
- sloučení prezentací
- procházet snímky
- procházet tvary
- procházet text
- sbírat tvary
- komprimovat prezentaci
- odstranit nepoužívané hlavní snímky
- odstranit nepoužívané rozložení snímků
- komprimovat vložená písma
- PowerPoint
- OpenDocument
- prezentace
- .NET
- C#
- Aspose.Slides
description: "Použijte nízkokódové API Aspose.Slides v .NET k převodu a sloučení prezentací, procházení obsahu, sběru tvarů a snížení velikosti prezentace."
---
## **Přehled**

The [Aspose.Slides.LowCode](https://reference.aspose.com/slides/net/aspose.slides.lowcode/) namespace provides static helper classes for common presentation operations. These helpers wrap frequently used object-model workflows in focused methods, so you can convert or merge files, process presentation elements, collect shapes, and remove unused content with less code.

Low-code helpers are most useful when the operation applies to an entire file or presentation and the default workflow matches your requirements. Use the full [Aspose.Slides object model](https://reference.aspose.com/slides/net/aspose.slides/) when you need fine-grained control over individual slides, masters, layouts, shapes, export settings, or relationships between presentation elements.

The following table summarizes the available helpers:

| Pomůcka | Použijte pro |
| --- | --- |
| [Convert](https://reference.aspose.com/slides/net/aspose.slides.lowcode/convert/) | Převod prezentace do jiného formátu pomocí přímého volání soubor-na-soubor. |
| [Merger](https://reference.aspose.com/slides/net/aspose.slides.lowcode/merger/) | Kombinování kompletních souborů prezentací ve stejném formátu. |
| [ForEach](https://reference.aspose.com/slides/net/aspose.slides.lowcode/foreach/) | Spuštění akce pro každý snímek, tvar, odstavec nebo část textu. |
| [Collect](https://reference.aspose.com/slides/net/aspose.slides.lowcode/collect/) | Načtení tvarů z celé prezentace pro opakované zpracování nebo analýzu. |
| [Compress](https://reference.aspose.com/slides/net/aspose.slides.lowcode/compress/) | Odstranění nepoužívaných mistrů/layoutů, zmenšení vložených dat písem a komprese obrázků. |

## **Převést prezentaci**

Use [Convert.AutoByExtension](https://reference.aspose.com/slides/net/aspose.slides.lowcode/convert/autobyextension/) when the output file extension is sufficient to select the export format. The method opens the source presentation, determines the required format from the output path, and writes the result.

```csharp
using Aspose.Slides.LowCode;

Convert.AutoByExtension("input.pptx", "output.pdf");
```

The [Convert](https://reference.aspose.com/slides/net/aspose.slides.lowcode/convert/) class also provides dedicated methods for PDF, SVG, JPEG, PNG, and TIFF output. Use the full object model when you need to inspect or modify the presentation before export or configure an export option that is not exposed by the selected helper. See [Convert Presentation](/slides/cs/net/convert-presentation/) for format-specific workflows and options.

## **Sloučit prezentace**

Use [Merger.Process](https://reference.aspose.com/slides/net/aspose.slides.lowcode/merger/process/) to combine complete presentation files with one call. The input presentations must have the same file format.

```csharp
using Aspose.Slides.LowCode;

var inputFiles = new[] { "part-1.pptx", "part-2.pptx" };
Merger.Process(inputFiles, "merged.pptx");
```

The helper is appropriate when all slides should be appended to one result without selecting or remapping them individually. Use the full object model when you need to merge selected slides, apply a destination master or layout, preserve sections explicitly, or reconcile different slide sizes. See [Merge Presentations](/slides/cs/net/merge-presentation/) for those scenarios.

## **Iterovat přes prvky prezentace**

The [ForEach](https://reference.aspose.com/slides/net/aspose.slides.lowcode/foreach/) class invokes a callback for each requested type of presentation element. It avoids nested collection loops and is convenient for presentation-wide inspection or formatting changes.

The following example uses [ForEach.Slide](https://reference.aspose.com/slides/net/aspose.slides.lowcode/foreach/slide/), [ForEach.Shape](https://reference.aspose.com/slides/net/aspose.slides.lowcode/foreach/shape/), [ForEach.Paragraph](https://reference.aspose.com/slides/net/aspose.slides.lowcode/foreach/paragraph/), and [ForEach.Portion](https://reference.aspose.com/slides/net/aspose.slides.lowcode/foreach/portion/) to inspect the corresponding elements:

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

## **Sbírat tvary**

Use [Collect.Shapes](https://reference.aspose.com/slides/net/aspose.slides.lowcode/collect/shapes/) when you need a collection of all shapes in a presentation rather than a callback for each shape. This is useful when the same set will be filtered, counted, or processed more than once.

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

Use [ForEach.Shape](https://reference.aspose.com/slides/net/aspose.slides.lowcode/foreach/shape/) instead when each shape can be handled immediately and you do not need to retain the collected result.

## **Komprimovat obsah prezentace**

The [Compress](https://reference.aspose.com/slides/net/aspose.slides.lowcode/compress/) class can remove unused structural elements and reduce embedded font data:

- [Compress.RemoveUnusedLayoutSlides](https://reference.aspose.com/slides/net/aspose.slides.lowcode/compress/removeunusedlayoutslides/) removes layout slides that no normal slide references.
- [Compress.RemoveUnusedMasterSlides](https://reference.aspose.com/slides/net/aspose.slides.lowcode/compress/removeunusedmasterslides/) removes master slides that are no longer used.
- [Compress.CompressEmbeddedFonts](https://reference.aspose.com/slides/net/aspose.slides.lowcode/compress/compressembeddedfonts/) removes unused characters from embedded fonts.

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

Remove unused layouts before unused masters so a master that becomes unreferenced after layout cleanup can also be removed. Save the optimized presentation to a new file if you may need the original masters, layouts, or complete embedded font data later. For more detail, see [Slide Master](/slides/cs/net/slide-master/) and [Embedded Font](/slides/cs/net/embedded-font/).

### **Komprimovat celou prezentaci**

Aspose.Slides for .NET 26.11 adds [Compress.CompressPresentation](https://reference.aspose.com/slides/net/aspose.slides.lowcode/compress/compresspresentation/). It combines removal of unused layout/master slides, subsetting of embedded fonts to used characters, and picture compression at 150 DPI. Use the individual operations above when you need to control which changes are applied.

Install [Aspose.Slides for .NET](/slides/cs/net/installation/) 26.11 or later and provide `input.pptx`. Save to a separate file: removed layouts, font characters and cropped picture pixels may be needed for later editing.

```csharp
using Aspose.Slides;
using Aspose.Slides.Export;
using Aspose.Slides.LowCode;

using var presentation = new Presentation("input.pptx");
Compress.CompressPresentation(presentation);
presentation.Save("compressed.pptx", SaveFormat.Pptx);
```

### **Komprimovat obrázky s vybraným rozlišením**

Use [Compress.CompressImages](https://reference.aspose.com/slides/net/aspose.slides.lowcode/compress/compressimages/) to process eligible pictures without also removing layouts or subsetting fonts. This example uses 96 DPI; select another [PicturesCompression](https://reference.aspose.com/slides/net/aspose.slides.export/picturescompression/) value for your output needs.

```csharp
using Aspose.Slides;
using Aspose.Slides.Export;
using Aspose.Slides.LowCode;

using var presentation = new Presentation("input.pptx");
Compress.CompressImages(presentation, PicturesCompression.Dpi96);
presentation.Save("compressed-images.pptx", SaveFormat.Pptx);
```

Both helpers use the following picture-processing scope:

| Obsah | Ošetření |
| --- | --- |
| Raster pictures and shape picture fills on normal, master and layout slides, including grouped shapes | Eligible for compression. |
| Pictures already at or below the requested resolution | Not upscaled. Cropped areas can still be removed. |
| Cropped picture areas | Hidden pixels are permanently removed and crop offsets are reset. |
| Slide backgrounds and table-cell fills | Not processed by these helpers. |
| Chart/SmartArt internals, GIF and vector formats such as SVG, EMF and WMF | Outside the documented image-compression scope. |

In 26.11, [PicturesCompression.DocumentResolution](https://reference.aspose.com/slides/net/aspose.slides.export/picturescompression/) avoids resolution-based downsampling of an uncropped picture, but **does not preserve cropped pixels**. A cropped picture can still be rewritten with its hidden areas removed. Neither helper exposes a preserve-crop option. For individual control, see the [per-picture compression example](/slides/cs/net/examples/optimization-batch/compression/).

Compare the output's appearance and file size before replacing the original. Savings depend on the source pictures, their displayed size and unused content; compression does not guarantee a smaller file. See [Embedded Fonts](/slides/cs/net/embedded-font/) for the implications of font subsetting.

## **Často kladené otázky**

**Kdy bych měl použít low-code API místo plného modelu objektů?**

Use low-code helpers when a standard operation applies to a complete file or presentation and does not require detailed control over individual elements. Use the full object model when you need to select specific slides, control master and layout relationships, inspect intermediate state, or configure behavior that the helper does not expose.

**Může Merger kombinovat prezentace v různých formátech souborů?**

No. [Merger.Process](https://reference.aspose.com/slides/net/aspose.slides.lowcode/merger/process/) requires input presentations in the same format. Convert the input files to a common format first, for example with [Convert.AutoByExtension](https://reference.aspose.com/slides/net/aspose.slides.lowcode/convert/autobyextension/), and then merge the converted files.

**Zpracovává ForEach mistr, layout a poznámkové snímky?**

[ForEach.Slide](https://reference.aspose.com/slides/net/aspose.slides.lowcode/foreach/slide/) iterates through normal presentation slides. Presentation-wide [ForEach.Shape](https://reference.aspose.com/slides/net/aspose.slides.lowcode/foreach/shape/), [ForEach.Paragraph](https://reference.aspose.com/slides/net/aspose.slides.lowcode/foreach/paragraph/), and [ForEach.Portion](https://reference.aspose.com/slides/net/aspose.slides.lowcode/foreach/portion/) operations include normal, master, and layout slides by default. Use their overloads with `includeNotes` set to `true` to include notes slides.

**Jaký je rozdíl mezi ForEach.Shape a Collect.Shapes?**

Use [ForEach.Shape](https://reference.aspose.com/slides/net/aspose.slides.lowcode/foreach/shape/) to process each shape immediately through a callback. Use [Collect.Shapes](https://reference.aspose.com/slides/net/aspose.slides.lowcode/collect/shapes/) when you need an enumerable result that can be retained, filtered, counted, or traversed multiple times.

**Zmenší Compress vždy soubor prezentace?**

Not necessarily. Savings depend on unused layouts/masters, embedded fonts with unused characters, and pictures that benefit from compression. The [Compress](https://reference.aspose.com/slides/net/aspose.slides.lowcode/compress/) helpers may leave the size unchanged or produce a larger file for some inputs. Compare both size and rendered quality, and keep the original.

**Ukládají změny provedené pomocí ForEach nebo Compress automaticky?**

No. These helpers operate on the loaded [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation/) object in memory. After changing elements in a [ForEach](https://reference.aspose.com/slides/net/aspose.slides.lowcode/foreach/) callback or running [Compress](https://reference.aspose.com/slides/net/aspose.slides.lowcode/compress/), call [Presentation.Save](https://reference.aspose.com/slides/net/aspose.slides/presentation/save/) to write the result.

## **Související články**

- [Convert Presentation](/slides/cs/net/convert-presentation/)
- [Merge Presentations](/slides/cs/net/merge-presentation/)
- [Slide Master](/slides/cs/net/slide-master/)
- [Manage Text Box](/slides/cs/net/manage-textbox/)
- [Embedded Font](/slides/cs/net/embedded-font/)