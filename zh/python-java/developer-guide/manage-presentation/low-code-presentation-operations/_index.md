---
title: 通过 Java 的 Python 低代码演示文稿操作
linktitle: 低代码 API
type: docs
weight: 50
url: /zh/python-java/low-code-presentation-operations/
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
- 删除未使用的布局幻灯片
- 压缩嵌入式字体
- PowerPoint
- OpenDocument
- 演示文稿
- Python
- Java
- Aspose.Slides
description: "在 Python via Java 中使用 Aspose.Slides 低代码 API 来转换和合并演示文稿、遍历内容、收集形状并减小演示文稿大小。"
---
## **概述**

The [Aspose.Slides for Python via Java](https://reference.aspose.com/slides/zh/python-java/aspose.slides/) API provides static helper classes for common presentation operations. These helpers wrap frequently used object-model workflows in focused methods, so you can convert or merge files, process presentation elements, collect shapes, and remove unused content with less code.

Low-code helpers are most useful when the operation applies to an entire file or presentation and the default workflow matches your requirements. Use the full [Aspose.Slides object model](https://reference.aspose.com/slides/zh/python-java/aspose.slides/) when you need fine-grained control over individual slides, masters, layouts, shapes, export settings, or relationships between presentation elements.

The following table summarizes the available helpers:

| 助手 | 适用场景 |
| --- | --- |
| [Convert](https://reference.aspose.com/slides/zh/python-java/aspose.slides/convert/) | 将演示文稿转换为另一种格式，使用直接的文件到文件调用。 |
| [Merger](https://reference.aspose.com/slides/zh/python-java/aspose.slides/merger/) | 合并相同格式的完整演示文稿文件。 |
| [ForEach](https://reference.aspose.com/slides/zh/python-java/aspose.slides/foreach/) | 对每个幻灯片、形状、段落或文本片段运行操作。 |
| [Collect](https://reference.aspose.com/slides/zh/python-java/aspose.slides/collect/) | 从整个演示文稿中检索形状，以便重复处理或分析。 |
| [Compress](https://reference.aspose.com/slides/zh/python-java/aspose.slides/compress/) | 删除未使用的母版和布局并减少嵌入式字体数据。 |

## **转换演示文稿**

Use [Convert.autoByExtension](https://reference.aspose.com/slides/zh/python-java/aspose.slides/convert/#autoByExtension) when the output file extension is sufficient to select the export format. The method opens the source presentation, determines the required format from the output path, and writes the result.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Convert

Convert.autoByExtension("input.pptx", "output.pdf")
```

The [Convert](https://reference.aspose.com/slides/zh/python-java/aspose.slides/convert/) class also provides dedicated methods for PDF, SVG, JPEG, PNG, and TIFF output. Use the full object model when you need to inspect or modify the presentation before export or configure an export option that is not exposed by the selected helper. See [Convert Presentation](/slides/zh/python-java/convert-presentation/) for format-specific workflows and options.

## **合并演示文稿**

Use [Merger.process](https://reference.aspose.com/slides/zh/python-java/aspose.slides/merger/#process) to combine complete presentation files with one call. The input presentations must have the same file format.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Merger

input_files = jpype.JArray(jpype.JString)(["part-1.pptx", "part-2.pptx"])
Merger.process(input_files, "merged.pptx")
```

The helper is appropriate when all slides should be appended to one result without selecting or remapping them individually. Use the full object model when you need to merge selected slides, apply a destination master or layout, preserve sections explicitly, or reconcile different slide sizes. See [Merge Presentations](/slides/zh/python-java/merge-presentation/) for those scenarios.

## **遍历演示文稿元素**

The [ForEach](https://reference.aspose.com/slides/zh/python-java/aspose.slides/foreach/) class invokes a callback for each requested type of presentation element. It avoids nested collection loops and is convenient for presentation-wide inspection or formatting changes.

The following example uses [ForEach.slide](https://reference.aspose.com/slides/zh/python-java/aspose.slides/foreach/#slide), [ForEach.shape](https://reference.aspose.com/slides/zh/python-java/aspose.slides/foreach/#shape), [ForEach.paragraph](https://reference.aspose.com/slides/zh/python-java/aspose.slides/foreach/#paragraph), and [ForEach.portion](https://reference.aspose.com/slides/zh/python-java/aspose.slides/foreach/#portion) to inspect the corresponding elements:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import ForEach, Presentation

def print_slide(slide, index):
    print(f"Slide {index}: {slide.getShapes().size()} shapes")

def print_shape(shape, slide, index):
    print(f"Shape {index} on {slide.getClass().getSimpleName()}: {shape.getName()}")

def print_paragraph(paragraph, slide, index):
    print(f"Paragraph {index} on {slide.getClass().getSimpleName()}: {paragraph.getText()}")

def print_portion(portion, paragraph, slide, index):
    print(f"Portion {index} on {slide.getClass().getSimpleName()}: {portion.getText()}")

presentation = Presentation("input.pptx")
try:
    ForEach.slide(presentation, print_slide)
    ForEach.shape(presentation, print_shape)
    ForEach.paragraph(presentation, print_paragraph)
    ForEach.portion(presentation, print_portion)
finally:
    presentation.dispose()
```

By default, presentation-wide shape and text traversal includes normal, master, and layout slides. Overloads with an `includeNotes` parameter can also process notes slides. Use direct collection loops when traversal order, early exit, filtering before callback invocation, or detailed parent-child control is important.

## **收集形状**

Use [Collect.shapes](https://reference.aspose.com/slides/zh/python-java/aspose.slides/collect/#shapes) when you need a collection of all shapes in a presentation rather than a callback for each shape. This is useful when the same set will be filtered, counted, or processed more than once.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Collect, Presentation

presentation = Presentation("input.pptx")
try:
    shapes = Collect.shapes(presentation)

    for shape in shapes:
        print(f"{shape.getName()}: {shape.getClass().getSimpleName()}")
finally:
    presentation.dispose()
```

Use [ForEach.shape](https://reference.aspose.com/slides/zh/python-java/aspose.slides/foreach/#shape) instead when each shape can be handled immediately and you do not need to retain the collected result.

## **压缩演示文稿内容**

The [Compress](https://reference.aspose.com/slides/zh/python-java/aspose.slides/compress/) class can remove unused structural elements and reduce embedded font data:

- [removeUnusedLayoutSlides](https://reference.aspose.com/slides/zh/python-java/aspose.slides/compress/#removeUnusedLayoutSlides) 删除没有普通幻灯片引用的布局幻灯片。  
- [removeUnusedMasterSlides](https://reference.aspose.com/slides/zh/python-java/aspose.slides/compress/#removeUnusedMasterSlides) 删除不再使用的母版幻灯片。  
- [compressEmbeddedFonts](https://reference.aspose.com/slides/zh/python-java/aspose.slides/compress/#compressEmbeddedFonts) 从嵌入式字体中删除未使用的字符。  

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Compress, Presentation, SaveFormat

presentation = Presentation("input.pptx")
try:
    Compress.removeUnusedLayoutSlides(presentation)
    Compress.removeUnusedMasterSlides(presentation)
    Compress.compressEmbeddedFonts(presentation)

    presentation.save("compressed.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

请先删除未使用的布局，然后再删除未使用的母版，这样在布局清理后变为未引用的母版也可以被移除。如果以后可能需要原始的母版、布局或完整的嵌入式字体数据，请将优化后的演示文稿保存为新文件。更多细节，请参阅 [Slide Master](/slides/zh/python-java/slide-master/) 和 [Embedded Font](/slides/zh/python-java/embedded-font/)。

## **常见问题**

**何时应该使用低代码 API 而不是完整的对象模型？**

当标准操作适用于整个文件或演示文稿且无需对各个元素进行细致控制时，请使用低代码助手。当需要选择特定幻灯片、控制母版和布局关系、检查中间状态或配置助手未公开的行为时，请使用完整的对象模型。

**Merger 能否合并不同文件格式的演示文稿？**

不能。[Merger.process] 需要输入的演示文稿具有相同的格式。请先使用例如 [Convert.autoByExtension] 将输入文件转换为统一格式，然后再合并已转换的文件。

**ForEach 是否处理母版、布局和备注幻灯片？**

[ForEach.slide] 遍历普通演示文稿幻灯片。全演示文稿范围的 [ForEach.shape]、[ForEach.paragraph] 和 [ForEach.portion] 操作默认包括普通、母版和布局幻灯片。使用它们的重载并将 `includeNotes` 设置为 `True` 可包含备注幻灯片。

**ForEach.shape 与 Collect.shapes 有何区别？**

使用 [ForEach.shape] 可以通过回调立即处理每个形状。需要可保留、过滤、计数或多次遍历的可迭代结果时，请使用 [Collect.shapes]。

**Compress 是否总能让演示文稿文件变小？**

不一定。结果取决于演示文稿是否包含未使用的布局、未使用的母版或包含未使用字符的嵌入式字体。如果这些都不存在，相应的 [Compress] 操作可能不会减小文件大小。

**ForEach 或 Compress 所做的更改会自动保存吗？**

不会。这些助手在内存中操作已加载的 [Presentation] 对象。 在 [ForEach] 回调中更改元素或运行 [Compress] 后，需调用 [Presentation.save] 将结果写入文件。

## **Related Articles**

- [转换演示文稿](/slides/zh/python-java/convert-presentation/)
- [合并演示文稿](/slides/zh/python-java/merge-presentation/)
- [幻灯片母版](/slides/zh/python-java/slide-master/)
- [管理文本框](/slides/zh/python-java/manage-textbox/)
- [嵌入式字体](/slides/zh/python-java/embedded-font/)