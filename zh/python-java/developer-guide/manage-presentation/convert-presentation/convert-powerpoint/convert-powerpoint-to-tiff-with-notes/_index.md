---
title: 在 Python 中将 PowerPoint 演示文稿转换为带备注的 TIFF
linktitle: PowerPoint 转 TIFF 带备注
type: docs
weight: 100
url: /zh/python-java/convert-powerpoint-to-tiff-with-notes/
keywords:
- 转换 PowerPoint
- 转换演示文稿
- 转换幻灯片
- 转换 PPT
- 转换 PPTX
- PowerPoint 转 TIFF
- 演示文稿转 TIFF
- 幻灯片转 TIFF
- PPT 转 TIFF
- PPTX 转 TIFF
- 将 PPT 保存为 TIFF
- 将 PPTX 保存为 TIFF
- 导出 PPT 为 TIFF
- 导出 PPTX 为 TIFF
- 带备注的 PowerPoint
- 带备注的演示文稿
- 带备注的幻灯片
- 带备注的 PPT
- 带备注的 PPTX
- 带备注的 TIFF
- Python
- Java
- Aspose.Slides
description: "使用 Aspose.Slides for Python via Java 将 PowerPoint 演示文稿转换为带备注的 TIFF。了解如何高效导出带演讲者备注的幻灯片。"
---
## **简介**

Aspose.Slides for Python via Java 提供了一种简便的方案，可将带有备注的 PowerPoint 和 OpenDocument 演示文稿（PPT、PPTX 和 ODP）转换为 TIFF 格式。该格式被广泛用于高质量图像存储、打印和文档归档。使用 [保存](https://reference.aspose.com/slides/zh/python-java/aspose.slides/presentation/#save) 方法的 [Presentation](https://reference.aspose.com/slides/zh/python-java/aspose.slides/presentation/) 类即可将幻灯片及其讲稿备注导出为单个多页 TIFF 文件。

## **将演示文稿转换为带备注的 TIFF**

使用 Aspose.Slides for Python via Java 将 PowerPoint 或 OpenDocument 演示文稿保存为带备注的 TIFF，需要以下步骤：

1. 实例化 [Presentation](https://reference.aspose.com/slides/zh/python-java/aspose.slides/presentation/) 类：加载 PowerPoint 或 OpenDocument 文件。
2. 配置输出布局选项：使用 [NotesCommentsLayoutingOptions](https://reference.aspose.com/slides/zh/python-java/aspose.slides/notescommentslayoutingoptions/) 类指定备注和评论的显示方式。
3. 将演示文稿保存为 TIFF：将配置好的选项传递给 [保存](https://reference.aspose.com/slides/zh/python-java/aspose.slides/presentation/#save) 方法。

假设我们有一个名为 “speaker_notes.pptx” 的文件，其包含如下幻灯片：

![带有讲稿备注的演示文稿幻灯片](slide_with_notes.png)

下面的代码片段演示如何使用 [setSlidesLayoutOptions](https://reference.aspose.com/slides/zh/python-java/aspose.slides/tiffoptions/#setSlidesLayoutOptions) 方法在备注幻灯片视图下将演示文稿转换为 TIFF 图像。

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import NotesCommentsLayoutingOptions, NotesPositions, Presentation, SaveFormat, TiffOptions

presentation = Presentation("speaker_notes.pptx")
try:
    # 在每张幻灯片下方显示完整的演讲者备注。
    notes_options = NotesCommentsLayoutingOptions()
    notes_options.setNotesPosition(NotesPositions.BottomFull)

    # 配置 TIFF 分辨率和备注布局。
    tiff_options = TiffOptions()
    tiff_options.setDpiX(300)
    tiff_options.setDpiY(300)
    tiff_options.setSlidesLayoutOptions(notes_options)

    # 将演示文稿保存为带有演讲者备注的 TIFF。
    presentation.save("TIFF_with_notes.tiff", SaveFormat.Tiff, tiff_options)
finally:
    presentation.dispose()
```

结果：

![带有讲稿备注的 TIFF 图像](TIFF_with_notes.png)

{{% alert title="Tip" color="success" %}}
查看 Aspose [免费 PowerPoint 转海报转换器](https://products.aspose.app/slides/zh/conversion/convert-ppt-to-poster-online)。
{{% /alert %}}

## **常见问题**

**我可以控制生成的 TIFF 中备注区域的位置吗？**

可以。使用 [setNotesPosition](https://reference.aspose.com/slides/zh/python-java/aspose.slides/notescommentslayoutingoptions/#setNotesPosition) 与 [NotesPositions.BottomTruncated](https://reference.aspose.com/slides/zh/python-java/aspose.slides/notespositions/#BottomTruncated) 将备注放在单页上（可能会被截断），或使用 [NotesPositions.BottomFull](https://reference.aspose.com/slides/zh/python-java/aspose.slides/notespositions/#BottomFull) 在需要时通过额外页面显示全部备注。若要导出不带备注的幻灯片，按如 [将 PowerPoint 转换为 TIFF](/slides/zh/python-java/convert-powerpoint-to-tiff/) 所示省略备注布局配置。

**如何在不损失图像质量的情况下减小带备注的 TIFF 文件大小？**

通过 [setCompressionType](https://reference.aspose.com/slides/zh/python-java/aspose.slides/tiffoptions/#setCompressionType) 使用无损的 [LZW compression](https://reference.aspose.com/slides/zh/python-java/aspose.slides/tiffcompressiontypes/#LZW)。降低分辨率或颜色深度也能进一步减小文件大小，但可能影响图像质量和备注可读性。更多选项请参见 [TIFF 导出设置](/slides/zh/python-java/convert-powerpoint-to-tiff/)。

**如果系统中缺少原始字体，备注中的字体会影响结果吗？**

会。缺失的字体会触发[字体替换](/slides/zh/python-java/font-selection-sequence/)，从而改变文本度量和外观。请[提供所需字体](/slides/zh/python-java/custom-font/)以保持预期的字形。