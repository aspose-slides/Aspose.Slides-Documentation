---
title: Python 中的低代码演示文稿操作
linktitle: 低代码 API
type: docs
weight: 50
url: /zh/python-net/low-code-presentation-operations/
keywords:
- 低代码演示文稿 API
- 转换演示文稿
- 合并演示文稿
- 收集形状
- 压缩演示文稿
- 删除未使用的母版幻灯片
- 删除未使用的布局幻灯片
- 压缩嵌入式字体
- PowerPoint
- OpenDocument
- 演示文稿
- Python
- Aspose.Slides
description: "在 Python 中使用 Aspose.Slides 低代码 API 来转换和合并演示文稿、收集形状并减小演示文稿大小。"
---
## **概述**

[aspose.slides.lowcode](https://reference.aspose.com/slides/zh/python-net/aspose.slides.lowcode/) 模块提供用于常见演示文稿操作的辅助类。这些辅助类将经常使用的对象模型工作流封装在专注的方法中，使您可以更少的代码完成文件转换或合并、收集形状以及删除未使用的内容。

当操作适用于整个文件或演示文稿且默认工作流满足需求时，低代码辅助类最为实用。需要对单个幻灯片、母版、布局、形状、导出设置或演示文稿元素之间的关系进行精细控制时，请使用完整的 [Aspose.Slides 对象模型](https://reference.aspose.com/slides/zh/python-net/aspose.slides/)。

下表概述了可用的辅助类：

| Helper | 用途 |
| --- | --- |
| [Convert](https://reference.aspose.com/slides/zh/python-net/aspose.slides.lowcode/convert/) | 将演示文稿直接从文件转换为另一种格式。 |
| [Merger](https://reference.aspose.com/slides/zh/python-net/aspose.slides.lowcode/merger/) | 合并相同格式的完整演示文稿文件。 |
| [Collect](https://reference.aspose.com/slides/zh/python-net/aspose.slides.lowcode/collect/) | 从整个演示文稿中检索形状，以便重复处理或分析。 |
| [Compress](https://reference.aspose.com/slides/zh/python-net/aspose.slides.lowcode/compress/) | 删除未使用的母版和布局并压缩嵌入的字体数据。 |

## **转换演示文稿**

当输出文件扩展名足以确定导出格式时，请使用 [Convert.auto_by_extension](https://reference.aspose.com/slides/zh/python-net/aspose.slides.lowcode/convert/auto_by_extension/)。该方法打开源演示文稿，从输出路径确定所需格式并写入结果。

```python
import aspose.slides as slides

slides.lowcode.Convert.auto_by_extension("input.pptx", "output.pdf")
```

[Convert](https://reference.aspose.com/slides/zh/python-net/aspose.slides.lowcode/convert/) 类还提供针对 PDF、SVG、JPEG、PNG 和 TIFF 输出的专用方法。需要在导出前检查或修改演示文稿，或配置选项未被所选辅助类暴露时，请使用完整的对象模型。有关特定格式的工作流和选项，请参阅 [Convert Presentation](/slides/zh/python-net/convert-presentation/)。

## **合并演示文稿**

使用 [Merger.process](https://reference.aspose.com/slides/zh/python-net/aspose.slides.lowcode/merger/process/) 可一次调用合并完整的演示文稿文件。输入的演示文稿必须使用相同的文件格式。

```python
import aspose.slides as slides

input_files = ["part-1.pptx", "part-2.pptx"]
slides.lowcode.Merger.process(input_files, "merged.pptx")
```

当所有幻灯片都应追加到一个结果文件且不需要单独选择或重新映射时，使用此辅助类最为合适。需要合并选定幻灯片、应用目标母版或布局、显式保留章节，或协调不同幻灯片尺寸时，请使用完整的对象模型。相应场景请参阅 [Merge Presentations](/slides/zh/python-net/merge-presentation/)。

## **收集形状**

当需要获取演示文稿中所有形状的集合时，请使用 [Collect.shapes](https://reference.aspose.com/slides/zh/python-net/aspose.slides.lowcode/collect/shapes/)。这在需要对同一组形状进行多次过滤、计数或处理时非常有用。

```python
import aspose.slides as slides

with slides.Presentation("input.pptx") as presentation:
    shapes = slides.lowcode.Collect.shapes(presentation)

    for shape in shapes:
        print(f"{shape.name}: {type(shape).__name__}")
```

如果遍历顺序、提前退出、加工前过滤或对父子关系的细粒度控制很重要，请使用直接的集合循环。

## **压缩演示文稿内容**

[Compress](https://reference.aspose.com/slides/zh/python-net/aspose.slides.lowcode/compress/) 类可删除未使用的结构元素并压缩嵌入的字体数据：

- [Compress.remove_unused_layout_slides](https://reference.aspose.com/slides/zh/python-net/aspose.slides.lowcode/compress/remove_unused_layout_slides/) 删除未被普通幻灯片引用的布局幻灯片。
- [Compress.remove_unused_master_slides](https://reference.aspose.com/slides/zh/python-net/aspose.slides.lowcode/compress/remove_unused_master_slides/) 删除不再使用的母版幻灯片。
- [Compress.compress_embedded_fonts](https://reference.aspose.com/slides/zh/python-net/aspose.slides.lowcode/compress/compress_embedded_fonts/) 删除嵌入字体中未使用的字符。

```python
import aspose.slides as slides

with slides.Presentation("input.pptx") as presentation:
    slides.lowcode.Compress.remove_unused_layout_slides(presentation)
    slides.lowcode.Compress.remove_unused_master_slides(presentation)
    slides.lowcode.Compress.compress_embedded_fonts(presentation)

    presentation.save("compressed.pptx", slides.export.SaveFormat.PPTX)
```

请先删除未使用的布局，再删除未使用的母版，这样在布局清理后变为未引用的母版也能被移除。如果以后可能需要原始的母版、布局或完整的嵌入字体数据，请将优化后的演示文稿保存为新文件。更多细节请参阅 [Slide Master](/slides/zh/python-net/slide-master/) 和 [Embedded Font](/slides/zh/python-net/embedded-font/)。

## **常见问题解答**

**何时应使用低代码 API 而不是完整对象模型？**

当标准操作适用于完整文件或演示文稿且不需要对单个元素进行细致控制时，请使用低代码辅助类。需要选择特定幻灯片、控制母版和布局关系、检查中间状态或配置辅助类未公开的行为时，请使用完整对象模型。

**Merger 能合并不同文件格式的演示文稿吗？**

不能。[Merger.process](https://reference.aspose.com/slides/zh/python-net/aspose.slides.lowcode/merger/process/) 要求输入演示文稿使用相同的格式。请先使用如 [Convert.auto_by_extension](https://reference.aspose.com/slides/zh/python-net/aspose.slides.lowcode/convert/auto_by_extension/) 将输入文件转换为统一格式，然后再进行合并。

**Collect.shapes 包含哪些内容？**

[Collect.shapes](https://reference.aspose.com/slides/zh/python-net/aspose.slides.lowcode/collect/shapes/) 检索演示文稿中的形状，以便它们可以被保留、过滤、计数或多次遍历。当需要对访问的幻灯片类型或嵌套对象进行精确控制时，请使用直接的集合循环。

**Compress 总是能让演示文稿文件变小吗？**

不一定。结果取决于演示文稿是否包含未使用的布局、未使用的母版或包含未使用字符的嵌入字体。如果这些都不存在，相应的 [Compress](https://reference.aspose.com/slides/zh/python-net/aspose.slides.lowcode/compress/) 操作可能不会降低文件大小。

**Compress 所做的更改会自动保存吗？**

不会。这些辅助类在内存中的已加载 [Presentation](https://reference.aspose.com/slides/zh/python-net/aspose.slides/presentation/) 对象上工作。运行 [Compress](https://reference.aspose.com/slides/zh/python-net/aspose.slides.lowcode/compress/) 后，需要调用 [Presentation.save](https://reference.aspose.com/slides/zh/python-net/aspose.slides/presentation/save/) 将结果写入文件。

## **相关文档**

- [Convert Presentation](/slides/zh/python-net/convert-presentation/)
- [Merge Presentations](/slides/zh/python-net/merge-presentation/)
- [Slide Master](/slides/zh/python-net/slide-master/)
- [Manage Text Box](/slides/zh/python-net/manage-textbox/)
- [Embedded Font](/slides/zh/python-net/embedded-font/)