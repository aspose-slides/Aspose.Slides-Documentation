---
title: 在 .NET 中的低代码演示文稿操作
linktitle: 低代码 API
type: docs
weight: 50
url: /zh/net/low-code-presentation-operations/
keywords:
- 低代码演示文稿 API
- 转换演示文稿
- 合并演示文稿
- 遍历幻灯片
- 遍历形状
- 遍历文本
- 收集形状
- 压缩演示文稿
- 删除未使用的母版幻灯片
- 删除未使用的版式幻灯片
- 压缩嵌入式字体
- PowerPoint
- OpenDocument
- 演示文稿
- .NET
- C#
- Aspose.Slides
description: "在 .NET 中使用 Aspose.Slides 低代码 API 来转换和合并演示文稿、遍历内容、收集形状并减小演示文稿大小。"
---
## **概述**

The [Aspose.Slides.LowCode](https://reference.aspose.com/slides/zh/net/aspose.slides.lowcode/) namespace provides static helper classes for common presentation operations. These helpers wrap frequently used object-model workflows in focused methods, so you can convert or merge files, process presentation elements, collect shapes, and remove unused content with less code.

Low-code helpers are most useful when the operation applies to an entire file or presentation and the default workflow matches your requirements. Use the full [Aspose.Slides object model](https://reference.aspose.com/slides/zh/net/aspose.slides/) when you need fine-grained control over individual slides, masters, layouts, shapes, export settings, or relationships between presentation elements.

The following table summarizes the available helpers:

| 助手 | 适用场景 |
| --- | --- |
| [Convert](https://reference.aspose.com/slides/zh/net/aspose.slides.lowcode/convert/) | 将演示文稿转换为另一种格式，使用直接的文件对文件调用。 |
| [Merger](https://reference.aspose.com/slides/zh/net/aspose.slides.lowcode/merger/) | 合并相同格式的完整演示文稿文件。 |
| [ForEach](https://reference.aspose.com/slides/zh/net/aspose.slides.lowcode/foreach/) | 对每个幻灯片、形状、段落或文本块执行操作。 |
| [Collect](https://reference.aspose.com/slides/zh/net/aspose.slides.lowcode/collect/) | 从整个演示文稿中检索形状，以便重复处理或分析。 |
| [Compress](https://reference.aspose.com/slides/zh/net/aspose.slides.lowcode/compress/) | 删除未使用的母版和版式并压缩嵌入的字体数据。 |

## **转换演示文稿**

Use [Convert.AutoByExtension](https://reference.aspose.com/slides/zh/net/aspose.slides.lowcode/convert/autobyextension/) when the output file extension is sufficient to select the export format. The method opens the source presentation, determines the required format from the output path, and writes the result.

```csharp
using Aspose.Slides.LowCode;

Convert.AutoByExtension("input.pptx", "output.pdf");
```

The [Convert](https://reference.aspose.com/slides/zh/net/aspose.slides.lowcode/convert/) class also provides dedicated methods for PDF, SVG, JPEG, PNG, and TIFF output. Use the full object model when you need to inspect or modify the presentation before export or configure an export option that is not exposed by the selected helper. See [Convert Presentation](/slides/zh/net/convert-presentation/) for format-specific workflows and options.

## **合并演示文稿**

Use [Merger.Process](https://reference.aspose.com/slides/zh/net/aspose.slides.lowcode/merger/process/) to combine complete presentation files with one call. The input presentations must have the same file format.

```csharp
using Aspose.Slides.LowCode;

var inputFiles = new[] { "part-1.pptx", "part-2.pptx" };
Merger.Process(inputFiles, "merged.pptx");
```

The helper is appropriate when all slides should be appended to one result without selecting or remapping them individually. Use the full object model when you need to merge selected slides, apply a destination master or layout, preserve sections explicitly, or reconcile different slide sizes. See [Merge Presentations](/slides/zh/net/merge-presentation/) for those scenarios.

## **遍历演示文稿元素**

The [ForEach](https://reference.aspose.com/slides/zh/net/aspose.slides.lowcode/foreach/) class invokes a callback for each requested type of presentation element. It avoids nested collection loops and is convenient for presentation-wide inspection or formatting changes.

The following example uses [ForEach.Slide](https://reference.aspose.com/slides/zh/net/aspose.slides.lowcode/foreach/slide/), [ForEach.Shape](https://reference.aspose.com/slides/zh/net/aspose.slides.lowcode/foreach/shape/), [ForEach.Paragraph](https://reference.aspose.com/slides/zh/net/aspose.slides.lowcode/foreach/paragraph/), and [ForEach.Portion](https://reference.aspose.com/slides/zh/net/aspose.slides.lowcode/foreach/portion/) to inspect the corresponding elements:

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

## **收集形状**

Use [Collect.Shapes](https://reference.aspose.com/slides/zh/net/aspose.slides.lowcode/collect/shapes/) when you need a collection of all shapes in a presentation rather than a callback for each shape. This is useful when the same set will be filtered, counted, or processed more than once.

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

Use [ForEach.Shape](https://reference.aspose.com/slides/zh/net/aspose.slides.lowcode/foreach/shape/) instead when each shape can be handled immediately and you do not need to retain the collected result.

## **压缩演示文稿内容**

The [Compress](https://reference.aspose.com/slides/zh/net/aspose.slides.lowcode/compress/) class can remove unused structural elements and reduce embedded font data:

- [Compress.RemoveUnusedLayoutSlides](https://reference.aspose.com/slides/zh/net/aspose.slides.lowcode/compress/removeunusedlayoutslides/) removes layout slides that no normal slide references.
- [Compress.RemoveUnusedMasterSlides](https://reference.aspose.com/slides/zh/net/aspose.slides.lowcode/compress/removeunusedmasterslides/) removes master slides that are no longer used.
- [Compress.CompressEmbeddedFonts](https://reference.aspose.com/slides/zh/net/aspose.slides.lowcode/compress/compressembeddedfonts/) removes unused characters from embedded fonts.

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

Remove unused layouts before unused masters so a master that becomes unreferenced after layout cleanup can also be removed. Save the optimized presentation to a new file if you may need the original masters, layouts, or complete embedded font data later. For more detail, see [Slide Master](/slides/zh/net/slide-master/) and [Embedded Font](/slides/zh/net/embedded-font/).

## **常见问题**

**何时应使用 low-code API 而不是完整对象模型？**

Use low-code helpers when a standard operation applies to a complete file or presentation and does not require detailed control over individual elements. Use the full object model when you need to select specific slides, control master and layout relationships, inspect intermediate state, or configure behavior that the helper does not expose.

**Merger 能合并不同文件格式的演示文稿吗？**

No. [Merger.Process](https://reference.aspose.com/slides/zh/net/aspose.slides.lowcode/merger/process/) requires input presentations in the same format. Convert the input files to a common format first, for example with [Convert.AutoByExtension](https://reference.aspose.com/slides/zh/net/aspose.slides.lowcode/convert/autobyextension/), and then merge the converted files.

**ForEach 会处理母版、版式和备注幻灯片吗？**

[ForEach.Slide](https://reference.aspose.com/slides/zh/net/aspose.slides.lowcode/foreach/slide/) iterates through normal presentation slides. Presentation-wide [ForEach.Shape](https://reference.aspose.com/slides/zh/net/aspose.slides.lowcode/foreach/shape/), [ForEach.Paragraph](https://reference.aspose.com/slides/zh/net/aspose.slides.lowcode/foreach/paragraph/), and [ForEach.Portion](https://reference.aspose.com/slides/zh/net/aspose.slides.lowcode/foreach/portion/) operations include normal, master, and layout slides by default. Use their overloads with `includeNotes` set to `true` to include notes slides.

**ForEach.Shape 与 Collect.Shapes 有何区别？**

Use [ForEach.Shape](https://reference.aspose.com/slides/zh/net/aspose.slides.lowcode/foreach/shape/) to process each shape immediately through a callback. Use [Collect.Shapes](https://reference.aspose.com/slides/zh/net/aspose.slides.lowcode/collect/shapes/) when you need an enumerable result that can be retained, filtered, counted, or traversed multiple times.

**Compress 是否总是会使文件变小？**

Not necessarily. The result depends on whether the presentation contains unused layouts, unused masters, or embedded fonts with unused characters. If none of those are present, the corresponding [Compress](https://reference.aspose.com/slides/zh/net/aspose.slides.lowcode/compress/) operations may not reduce the file size.

**ForEach 或 Compress 的更改会自动保存吗？**

No. These helpers operate on the loaded [Presentation](https://reference.aspose.com/slides/zh/net/aspose.slides/presentation/) object in memory. After changing elements in a [ForEach](https://reference.aspose.com/slides/zh/net/aspose.slides.lowcode/foreach/) callback or running [Compress](https://reference.aspose.com/slides/zh/net/aspose.slides.lowcode/compress/), call [Presentation.Save](https://reference.aspose.com/slides/zh/net/aspose.slides/presentation/save/) to write the result.

## **相关文章**

- [转换演示文稿](/slides/zh/net/convert-presentation/)
- [合并演示文稿](/slides/zh/net/merge-presentation/)
- [幻灯片母版](/slides/zh/net/slide-master/)
- [管理文本框](/slides/zh/net/manage-textbox/)
- [嵌入字体](/slides/zh/net/embedded-font/)