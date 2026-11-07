---
title: 低程式碼簡報操作（.NET）
linktitle: 低程式碼 API
type: docs
weight: 50
url: /zh-hant/net/low-code-presentation-operations/
keywords:
- 低程式碼簡報 API
- 轉換簡報
- 合併簡報
- 遍歷投影片
- 遍歷圖形
- 遍歷文字
- 收集圖形
- 壓縮簡報
- 移除未使用的母片投影片
- 移除未使用的版面配置投影片
- 壓縮嵌入式字型
- PowerPoint
- OpenDocument
- 簡報
- .NET
- C#
- Aspose.Slides
description: "在 .NET 中使用 Aspose.Slides 低程式碼 API 來轉換與合併簡報、遍歷內容、收集圖形，並減少簡報大小。"
---
## **概觀**

The [Aspose.Slides.LowCode](https://reference.aspose.com/slides/net/aspose.slides.lowcode/) namespace provides static helper classes for common presentation operations. These helpers wrap frequently used object-model workflows in focused methods, so you can convert or merge files, process presentation elements, collect shapes, and remove unused content with less code.

Low-code helpers are most useful when the operation applies to an entire file or presentation and the default workflow matches your requirements. Use the full [Aspose.Slides object model](https://reference.aspose.com/slides/net/aspose.slides/) when you need fine-grained control over individual slides, masters, layouts, shapes, export settings, or relationships between presentation elements.

The following table summarizes the available helpers:

| Helper | Use it for |
| --- | --- |
| [Convert](https://reference.aspose.com/slides/net/aspose.slides.lowcode/convert/) | 以直接檔案對檔案的方式將簡報轉換為其他格式。 |
| [Merger](https://reference.aspose.com/slides/net/aspose.slides.lowcode/merger/) | 合併相同格式的完整簡報檔案。 |
| [ForEach](https://reference.aspose.com/slides/net/aspose.slides.lowcode/foreach/) | 為每張投影片、圖形、段落或文字區塊執行動作。 |
| [Collect](https://reference.aspose.com/slides/net/aspose.slides.lowcode/collect/) | 從整個簡報中取得圖形以供重複處理或分析。 |
| [Compress](https://reference.aspose.com/slides/net/aspose.slides.lowcode/compress/) | 移除未使用的母片/版面配置、縮減嵌入字型資料並壓縮圖片。 |

## **轉換簡報**

Use [Convert.AutoByExtension](https://reference.aspose.com/slides/net/aspose.slides.lowcode/convert/autobyextension/) when the output file extension is sufficient to select the export format. The method opens the source presentation, determines the required format from the output path, and writes the result.

```csharp
using Aspose.Slides.LowCode;

Convert.AutoByExtension("input.pptx", "output.pdf");
```

The [Convert](https://reference.aspose.com/slides/net/aspose.slides.lowcode/convert/) class also provides dedicated methods for PDF, SVG, JPEG, PNG, and TIFF output. Use the full object model when you need to inspect or modify the presentation before export or configure an export option that is not exposed by the selected helper. See [Convert Presentation](/slides/zh-hant/net/convert-presentation/) for format-specific workflows and options.

## **合併簡報**

Use [Merger.Process](https://reference.aspose.com/slides/net/aspose.slides.lowcode/merger/process/) to combine complete presentation files with one call. The input presentations must have the same file format.

```csharp
using Aspose.Slides.LowCode;

var inputFiles = new[] { "part-1.pptx", "part-2.pptx" };
Merger.Process(inputFiles, "merged.pptx");
```

The helper is appropriate when all slides should be appended to one result without selecting or remapping them individually. Use the full object model when you need to merge selected slides, apply a destination master or layout, preserve sections explicitly, or reconcile different slide sizes. See [Merge Presentations](/slides/zh-hant/net/merge-presentation/) for those scenarios.

## **遍歷簡報元素**

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

## **收集圖形**

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

## **壓縮簡報內容**

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

Remove unused layouts before unused masters so a master that becomes unreferenced after layout cleanup can also be removed. Save the optimized presentation to a new file if you may need the original masters, layouts, or complete embedded font data later. For more detail, see [Slide Master](/slides/zh-hant/net/slide-master/) and [Embedded Font](/slides/zh-hant/net/embedded-font/).

### **壓縮整個簡報**

Aspose.Slides for .NET 26.11 adds [Compress.CompressPresentation](https://reference.aspose.com/slides/net/aspose.slides.lowcode/compress/compresspresentation/). It combines removal of unused layout/master slides, subsetting of embedded fonts to used characters, and picture compression at 150 DPI. Use the individual operations above when you need to control which changes are applied.

Install [Aspose.Slides for .NET](/slides/zh-hant/net/installation/) 26.11 or later and provide `input.pptx`. Save to a separate file: removed layouts, font characters and cropped picture pixels may be needed for later editing.

```csharp
using Aspose.Slides;
using Aspose.Slides.Export;
using Aspose.Slides.LowCode;

using var presentation = new Presentation("input.pptx");
Compress.CompressPresentation(presentation);
presentation.Save("compressed.pptx", SaveFormat.Pptx);
```

### **在選擇的解析度壓縮圖片**

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

| Content | Treatment |
| --- | --- |
| Raster pictures and shape picture fills on normal, master and layout slides, including grouped shapes | Eligible for compression. |
| Pictures already at or below the requested resolution | Not upscaled. Cropped areas can still be removed. |
| Cropped picture areas | Hidden pixels are permanently removed and crop offsets are reset. |
| Slide backgrounds and table-cell fills | Not processed by these helpers. |
| Chart/SmartArt internals, GIF and vector formats such as SVG, EMF and WMF | Outside the documented image-compression scope. |

In 26.11, [PicturesCompression.DocumentResolution](https://reference.aspose.com/slides/net/aspose.slides.export/picturescompression/) avoids resolution-based downsampling of an uncropped picture, but **does not preserve cropped pixels**. A cropped picture can still be rewritten with its hidden areas removed. Neither helper exposes a preserve-crop option. For individual control, see the [每張圖片壓縮範例](/slides/zh-hant/net/examples/optimization-batch/compression/).

Compare the output's appearance and file size before replacing the original. Savings depend on the source pictures, their displayed size and unused content; compression does not guarantee a smaller file. See [Embedded Fonts](/slides/zh-hant/net/embedded-font/) for the implications of font subsetting.

## **常見問題**

**何時應使用低程式碼 API 而非完整物件模型？**

Use low-code helpers when a standard operation applies to a complete file or presentation and does not require detailed control over individual elements. Use the full object model when you need to select specific slides, control master and layout relationships, inspect intermediate state, or configure behavior that the helper does not expose.

**Merger 能否合併不同檔案格式的簡報？**

No. [Merger.Process](https://reference.aspose.com/slides/net/aspose.slides.lowcode/merger/process/) requires input presentations in the same format. Convert the input files to a common format first, for example with [Convert.AutoByExtension](https://reference.aspose.com/slides/net/aspose.slides.lowcode/convert/autobyextension/), and then merge the converted files.

**ForEach 會處理母片、版面配置與備註投影片嗎？**

[ForEach.Slide](https://reference.aspose.com/slides/net/aspose.slides.lowcode/foreach/slide/) iterates through normal presentation slides. Presentation-wide [ForEach.Shape](https://reference.aspose.com/slides/net/aspose.slides.lowcode/foreach/shape/), [ForEach.Paragraph](https://reference.aspose.com/slides/net/aspose.slides.lowcode/foreach/paragraph/), and [ForEach.Portion](https://reference.aspose.com/slides/net/aspose.slides.lowcode/foreach/portion/) operations include normal, master, and layout slides by default. Use their overloads with `includeNotes` set to `true` to include notes slides.

**ForEach.Shape 與 Collect.Shapes 有何不同？**

Use [ForEach.Shape](https://reference.aspose.com/slides/net/aspose.slides.lowcode/foreach/shape/) to process each shape immediately through a callback. Use [Collect.Shapes](https://reference.aspose.com/slides/net/aspose.slides.lowcode/collect/shapes/) when you need an enumerable result that can be retained, filtered, counted, or traversed multiple times.

**Compress 總是會讓簡報檔案變小嗎？**

Not necessarily. Savings depend on unused layouts/masters, embedded fonts with unused characters, and pictures that benefit from compression. The [Compress](https://reference.aspose.com/slides/net/aspose.slides.lowcode/compress/) helpers may leave the size unchanged or produce a larger file for some inputs. Compare both size and rendered quality, and keep the original.

**ForEach 或 Compress 所做的變更會自動儲存嗎？**

No. These helpers operate on the loaded [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation/) object in memory. After changing elements in a [ForEach](https://reference.aspose.com/slides/net/aspose.slides.lowcode/foreach/) callback or running [Compress](https://reference.aspose.com/slides/net/aspose.slides.lowcode/compress/), call [Presentation.Save](https://reference.aspose.com/slides/net/aspose.slides/presentation/save/) to write the result.

## **相關文章**

- [轉換簡報](/slides/zh-hant/net/convert-presentation/)
- [合併簡報](/slides/zh-hant/net/merge-presentation/)
- [投影片母片](/slides/zh-hant/net/slide-master/)
- [管理文字方塊](/slides/zh-hant/net/manage-textbox/)
- [嵌入式字型](/slides/zh-hant/net/embedded-font/)