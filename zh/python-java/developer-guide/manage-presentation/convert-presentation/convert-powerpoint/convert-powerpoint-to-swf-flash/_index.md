---
title: 在 Python via Java 中将 PowerPoint 演示文稿转换为 SWF Flash
linktitle: PowerPoint 转 SWF
type: docs
weight: 80
url: /zh/python-java/convert-powerpoint-to-swf-flash/
keywords:
- 转换 PowerPoint
- 转换 演示文稿
- 转换 幻灯片
- 转换 PPT
- 转换 PPTX
- PowerPoint 转 SWF
- 演示文稿 转 SWF
- 幻灯片 转 SWF
- PPT 转 SWF
- PPTX 转 SWF
- PowerPoint 转 Flash
- 演示文稿 转 Flash
- 幻灯片 转 Flash
- PPT 转 Flash
- PPTX 转 Flash
- 将 PPT 保存为 SWF
- 将 PPTX 保存为 SWF
- 导出 PPT 为 SWF
- 导出 PPTX 为 SWF
- Python
- Java
- Aspose.Slides
description: "在 Python via Java 中使用 Aspose.Slides 将 PowerPoint 演示文稿转换为 SWF Flash。配置查看器、备注、隐藏幻灯片、压缩和字体。"
---
## **概述**

Aspose.Slides for Python via Java 使您能够在没有 Microsoft PowerPoint 的情况下将 PowerPoint 演示文稿转换为 SWF。使用 [Presentation.save](https://reference.aspose.com/slides/zh/python-java/aspose.slides/presentation/#save) 导出演示文稿，使用 [SwfOptions](https://reference.aspose.com/slides/zh/python-java/aspose.slides/swfoptions/) 配置查看器设置、图像质量以及备注或批注的布局。

## **将演示文稿转换为 Flash**

使用 [Presentation](https://reference.aspose.com/slides/zh/python-java/aspose.slides/presentation/) 加载源文件，配置 [SwfOptions](https://reference.aspose.com/slides/zh/python-java/aspose.slides/swfoptions/)，并使用 [SaveFormat.Swf](https://reference.aspose.com/slides/zh/python-java/aspose.slides/saveformat/#Swf) 保存。

以下示例将 `presentation.pptx` 导出为 `presentation.swf`。它通过 [setViewerIncluded](https://reference.aspose.com/slides/zh/python-java/aspose.slides/swfoptions/#setViewerIncluded) 禁用嵌入式查看器，并使用 [NotesCommentsLayoutingOptions](https://reference.aspose.com/slides/zh/python-java/aspose.slides/notescommentslayoutingoptions/) 将演讲者备注放在幻灯片下方。

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import NotesCommentsLayoutingOptions, NotesPositions, Presentation, SaveFormat, SwfOptions

presentation = Presentation("presentation.pptx")
try:
    layout_options = NotesCommentsLayoutingOptions()
    layout_options.setNotesPosition(NotesPositions.BottomFull)

    swf_options = SwfOptions()
    swf_options.setViewerIncluded(False)
    swf_options.setSlidesLayoutOptions(layout_options)

    presentation.save("presentation.swf", SaveFormat.Swf, swf_options)
finally:
    presentation.dispose()
```

在运行示例之前，先[安装 Aspose.Slides for Python via Java](/slides/zh/python-java/installation/)，并将 `presentation.pptx` 放置在工作目录中。JVM 会在每个 Python 进程启动一次。

示例通过 [setNotesPosition](https://reference.aspose.com/slides/zh/python-java/aspose.slides/notescommentslayoutingoptions/#setNotesPosition) 应用 [NotesPositions.BottomFull](https://reference.aspose.com/slides/zh/python-java/aspose.slides/notespositions/#BottomFull)，并将布局传递给 [SwfOptions.setSlidesLayoutOptions](https://reference.aspose.com/slides/zh/python-java/aspose.slides/swfoptions/#setSlidesLayoutOptions)。若要同时包含批注，请在导出前配置 [NotesCommentsLayoutingOptions.setCommentsPosition](https://reference.aspose.com/slides/zh/python-java/aspose.slides/notescommentslayoutingoptions/#setCommentsPosition)。

## **常见问题**

**我可以在 SWF 中包含隐藏幻灯片吗？**

可以。调用 [SwfOptions.setShowHiddenSlides](https://reference.aspose.com/slides/zh/python-java/aspose.slides/swfoptions/#setShowHiddenSlides) 并传入 `True`。默认情况下，隐藏的幻灯片不会被导出。

**我如何控制压缩和最终的 SWF 大小？**

使用 [SwfOptions.setCompressed](https://reference.aspose.com/slides/zh/python-java/aspose.slides/swfoptions/#setCompressed) 启用或禁用压缩，使用 [SwfOptions.setJpegQuality](https://reference.aspose.com/slides/zh/python-java/aspose.slides/swfoptions/#setJpegQuality) 调整 JPEG 图像质量。降低 JPEG 质量可以在牺牲图像保真度的情况下减小文件大小。

**嵌入式查看器的作用是什么，何时应该禁用它？**

[SwfOptions.setViewerIncluded](https://reference.aspose.com/slides/zh/python-java/aspose.slides/swfoptions/#setViewerIncluded) 控制生成的 SWF 是否包含查看器。当您需要导出的幻灯片不带嵌入式查看器时（如上面的示例），传入 `False`。

**如果导出机器上缺少源字体会怎样？**

您可以使用 [setDefaultRegularFont](https://reference.aspose.com/slides/zh/python-java/aspose.slides/saveoptions/#setDefaultRegularFont) 指定默认常规字体，该设置会被 [SwfOptions](https://reference.aspose.com/slides/zh/python-java/aspose.slides/swfoptions/) 继承。请选择导出过程中可用的字体；字体替换可能会改变文本外观和布局。