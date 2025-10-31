---
title: 在 Python 中将 PowerPoint 演示文稿转换为 SWF Flash
linktitle: PowerPoint 转 SWF Flash
type: docs
weight: 80
url: /zh/python-net/convert-powerpoint-to-swf-flash/
keywords:
- 转换 PowerPoint
- 转换 演示文稿
- 转换 幻灯片
- PowerPoint 转 SWF
- 演示文稿 转 SWF
- 幻灯片 转 SWF
- PPT 转 SWF
- PPTX 转 SWF
- PowerPoint
- 演示文稿
- Python
- Aspose.Slides
description: 使用 Aspose.Slides 在 Python 中将 PowerPoint（PPT/PPTX）转换为 SWF Flash。逐步代码示例，快速高质量输出，无需 PowerPoint 自动化。
---

## **将演示文稿转换为 Flash**

由[Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/)类公开的[Save](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/)方法可用于将整个演示文稿转换为 SWF 文档。您还可以通过使用[SWFOptions](https://reference.aspose.com/slides/python-net/aspose.slides.export/swfoptions/)类和[INotesCommentsLayoutingOptions](https://reference.aspose.com/slides/python-net/aspose.slides.export/inotescommentslayoutingoptions/)接口在生成的 SWF 中包含批注。以下示例展示了如何使用 SWFOptions 类提供的选项将演示文稿转换为 SWF 文档。

```py
import aspose.slides as slides

# 实例化一个表示演示文稿文件的 Presentation 对象
presentation = slides.Presentation("pres.pptx")

swfOptions = slides.export.SwfOptions()
swfOptions.viewer_included = False
swfOptions.notes_comments_layouting.notes_position = slides.export.NotesPositions.BOTTOM_FULL

# 保存演示文稿和批注页
presentation.save("SaveAsSwf_out.swf", slides.export.SaveFormat.SWF, swfOptions)
swfOptions.viewer_included = True
presentation.save("SaveNotes_out.swf", slides.export.SaveFormat.SWF, swfOptions)
```

## **常见问题**

**我可以在 SWF 中包含隐藏的幻灯片吗？**

是的。请在[SwfOptions](https://reference.aspose.com/slides/python-net/aspose.slides.export/swfoptions/)中启用[show_hidden_slides](https://reference.aspose.com/slides/python-net/aspose.slides.export/swfoptions/show_hidden_slides/)选项。默认情况下，隐藏的幻灯片不会导出。

**我如何控制压缩以及最终的 SWF 大小？**

使用[compressed](https://reference.aspose.com/slides/python-net/aspose.slides.export/swfoptions/compressed/)标志（默认启用），并调整[jpeg_quality](https://reference.aspose.com/slides/python-net/aspose.slides.export/swfoptions/jpeg_quality/)以在文件大小和图像质量之间取得平衡。

**'viewer_included' 的作用是什么，何时应禁用它？**

[viewer_included](https://reference.aspose.com/slides/python-net/aspose.slides.export/swfoptions/viewer_included/)会添加嵌入式播放器 UI（导航控件、面板、搜索）。如果您计划使用自己的播放器或需要一个没有 UI 的裸 SWF 框架，请禁用它。

**如果导出机器缺少源字体会发生什么？**

Aspose.Slides 将使用您在[SwfOptions](https://reference.aspose.com/slides/python-net/aspose.slides.export/swfoptions/)中通过[default_regular_font](https://reference.aspose.com/slides/python-net/aspose.slides.export/swfoptions/default_regular_font/)指定的字体进行替换，以避免意外的回退。