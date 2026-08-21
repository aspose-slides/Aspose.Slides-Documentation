---
title: Python 中的低代码演示操作
linktitle: 低代码 API
type: docs
weight: 50
url: /zh/python-net/low-code-presentation-operations/
keywords:
- 低代码演示 API
- 转换演示文稿
- 合并演示文稿
- 收集形状
- 压缩演示文稿
- 删除未使用的母版幻灯片
- 删除未使用的版面幻灯片
- 压缩嵌入字体
- PowerPoint
- OpenDocument
- 演示文稿
- Python
- Aspose.Slides
description: "在 Python 中使用 Aspose.Slides 低代码 API 来转换和合并演示文稿、收集形状并减小演示文稿大小。"
---
## **概览**

The [aspose.slides.lowcode](https://reference.aspose.com/slides/zh/python-net/aspose.slides.lowcode/) 模块提供用于常见演示操作的辅助类。这些辅助类将常用的对象模型工作流封装为专注的方法，使您能够更少的代码实现转换或合并文件、收集形状以及删除未使用的内容。

Low-code 辅助类在操作适用于整个文件或演示文稿且默认工作流满足需求时最为有用。当需要对单个幻灯片、母版、版面、形状、导出设置或演示元素之间的关系进行细粒度控制时，请使用完整的 [Aspose.Slides object model](https://reference.aspose.com/slides/zh/python-net/aspose.slides/)。

以下表格概述了可用的辅助类：

| 辅助类 | 适用场景 |
| --- | --- |
| [Convert](https://reference.aspose.com/slides/zh/python-net/aspose.slides.lowcode/convert/) | 将演示文稿转换为另一种格式，使用直接的文件到文件调用。 |
| [Merger](https://reference.aspose.com/slides/zh/python-net/aspose.slides.lowcode/merger/) | 合并相同格式的完整演示文稿文件。 |
| [Collect](https://reference.aspose.com/slides/zh/python-net/aspose.slides.lowcode/collect/) | 从整个演示文稿中检索形状，以便重复处理或分析。 |
| [Compress](https://reference.aspose.com/slides/zh/python-net/aspose.slides.lowcode/compress/) | 删除未使用的母版和版面并减少嵌入字体数据。 |

## **转换演示文稿**

当输出文件扩展名足以选择导出格式时，使用 [Convert.auto_by_extension](https://reference.aspose.com/slides/zh/python-net/aspose.slides.lowcode/convert/auto_by_extension/)。该方法打开源演示文稿，从输出路径确定所需格式并写入结果。

```python
import aspose.slides as slides

slides.lowcode.Convert.auto_by_extension("input.pptx", "output.pdf")
```

[Convert](https://reference.aspose.com/slides/zh/python-net/aspose.slides.lowcode/convert/) 类还提供针对 PDF、SVG、JPEG、PNG 和 TIFF 输出的专用方法。当您需要在导出前检查或修改演示文稿，或配置所选辅助类未公开的导出选项时，请使用完整的对象模型。有关特定格式的工作流和选项，请参阅 [转换演示文稿](/python-net/convert-presentation/)。

## **合并演示文稿**

使用 [Merger.process](https://reference.aspose.com/slides/zh/python-net/aspose.slides.lowcode/merger/process/) 可以一次调用合并完整的演示文稿文件。输入的演示文稿必须具有相同的文件格式。

```python
import aspose.slides as slides

input_files = ["part-1.pptx", "part-2.pptx"]
slides.lowcode.Merger.process(input_files, "merged.pptx")
```

当所有幻灯片都应追加到一个结果中且无需单独选择或重新映射时，此辅助类非常合适。当需要合并选定的幻灯片、应用目标母版或版面、显式保留章节，或调和不同的幻灯片尺寸时，请使用完整的对象模型。有关这些场景，请参阅 [合并演示文稿](/python-net/merge-presentation/)。

## **收集形状**

当您需要获取演示文稿中所有形状的集合时，使用 [Collect.shapes](https://reference.aspose.com/slides/zh/python-net/aspose.slides.lowcode/collect/shapes/)。这在需要对同一组形状进行多次过滤、计数或处理时非常有用。

```python
import aspose.slides as slides

with slides.Presentation("input.pptx") as presentation:
    shapes = slides.lowcode.Collect.shapes(presentation)

    for shape in shapes:
        print(f"{shape.name}: {type(shape).__name__}")
```

当遍历顺序、提前退出、在处理前进行过滤或需要细粒度的父子控制重要时，请使用直接的集合循环。

## **压缩演示文稿内容**

[Compress](https://reference.aspose.com/slides/zh/python-net/aspose.slides.lowcode/compress/) 类可以删除未使用的结构元素并减少嵌入字体数据：

- [Compress.remove_unused_layout_slides](https://reference.aspose.com/slides/zh/python-net/aspose.slides.lowcode/compress/remove_unused_layout_slides/) 删除没有普通幻灯片引用的版面幻灯片。  
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

先删除未使用的版面，再删除未使用的母版，这样在版面清理后变为未引用的母版也可以被删除。如果以后可能需要原始的母版、版面或完整的嵌入字体数据，请将优化后的演示文稿保存为新文件。有关更多细节，请参阅 [Slide Master](/python-net/slide-master/) 和 [Embedded Font](/python-net/embedded-font/)。

## **常见问题**

**何时应该使用 low-code API 而不是完整的对象模型？**

当标准操作适用于完整文件或演示文稿且无需对各个元素进行详细控制时，请使用 low-code 辅助类。当需要选择特定幻灯片、控制母版和版面关系、检查中间状态或配置辅助类未公开的行为时，请使用完整的对象模型。

**Merger 能合并不同文件格式的演示文稿吗？**

不能。[Merger.process](https://reference.aspose.com/slides/zh/python-net/aspose.slides.lowcode/merger/process/) 要求输入演示文稿的格式相同。请先使用例如 [Convert.auto_by_extension](https://reference.aspose.com/slides/zh/python-net/aspose.slides.lowcode/convert/auto_by_extension/) 将输入文件转换为统一格式，然后再合并已转换的文件。

**Collect.shapes 包含哪些内容？**

[Collect.shapes](https://reference.aspose.com/slides/zh/python-net/aspose.slides.lowcode/collect/shapes/) 检索演示文稿中的形状，以便它们可以被保留、过滤、计数或多次遍历。当需要对访问的幻灯片类型或嵌套对象进行精确控制时，请使用直接的集合循环。

**Compress 总是会让演示文稿文件更小吗？**

不一定。结果取决于演示文稿是否包含未使用的版面、未使用的母版或带有未使用字符的嵌入字体。如果这些都不存在，相应的 [Compress](https://reference.aspose.com/slides/zh/python-net/aspose.slides.lowcode/compress/) 操作可能不会减小文件大小。

**Compress 所做的更改会自动保存吗？**

不会。这些辅助类在内存中操作已加载的 [Presentation](https://reference.aspose.com/slides/zh/python-net/aspose.slides/presentation/) 对象。运行 [Compress](https://reference.aspose.com/slides/zh/python-net/aspose.slides.lowcode/compress/) 后，需要调用 [Presentation.save](https://reference.aspose.com/slides/zh/python-net/aspose.slides/presentation/save/) 将结果写入文件。

## **相关文档**

- [转换演示文稿](/python-net/convert-presentation/)
- [合并演示文稿](/python-net/merge-presentation/)
- [Slide Master](/python-net/slide-master/)
- [Manage Text Box](/python-net/manage-textbox/)
- [Embedded Font](/python-net/embedded-font/)