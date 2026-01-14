---
title: 在 Python 中将 PowerPoint 演示文稿转换为 SWF Flash
linktitle: PowerPoint 转换为 SWF Flash
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
description: "在 Python 中使用 Aspose.Slides 将 PowerPoint (PPT/PPTX) 转换为 SWF Flash。一步一步的代码示例，快速高质量输出，无需 PowerPoint 自动化。"
---

## **将演示文稿转换为 Flash**

[save](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/save/) 方法由[Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/)类公开，可用于将整个演示文稿转换为 SWF 文档。您还可以使用[SWFOptions](https://reference.aspose.com/slides/python-net/aspose.slides.export/swfoptions/)类和[NotesCommentsLayoutingOptions](https://reference.aspose.com/slides/python-net/aspose.slides.export/notescommentslayoutingoptions/)类在生成的 SWF 中包含批注。以下示例演示如何使用 SWFOptions 类提供的选项将演示文稿转换为 SWF 文档。
```py
import aspose.slides as slides

# 实例化一个表示演示文件的 Presentation 对象
presentation = slides.Presentation("pres.pptx")

swfOptions = slides.export.SwfOptions()
swfOptions.viewer_included = False
swfOptions.notes_comments_layouting.notes_position = slides.export.NotesPositions.BOTTOM_FULL

# 保存演示文稿和备注页面
presentation.save("SaveAsSwf_out.swf", slides.export.SaveFormat.SWF, swfOptions)
swfOptions.viewer_included = True
presentation.save("SaveNotes_out.swf", slides.export.SaveFormat.SWF, swfOptions)
```


## **常见问题**

**我可以在 SWF 中包含隐藏的幻灯片吗？**

可以。 在[SwfOptions](https://reference.aspose.com/slides/python-net/aspose.slides.export/swfoptions/)中启用[show_hidden_slides](https://reference.aspose.com/slides/python-net/aspose.slides.export/swfoptions/show_hidden_slides/)选项。默认情况下，隐藏的幻灯片不会导出。

**我该如何控制压缩和最终的 SWF 大小？**

使用[compressed](https://reference.aspose.com/slides/python-net/aspose.slides.export/swfoptions/compressed/)标志（默认已启用），并调整[jpeg_quality](https://reference.aspose.com/slides/python-net/aspose.slides.export/swfoptions/jpeg_quality/)以在文件大小和图像保真度之间取得平衡。

**'viewer_included' 是什么作用，何时应该禁用它？**

[viewer_included](https://reference.aspose.com/slides/python-net/aspose.slides.export/swfoptions/viewer_included/)会添加嵌入式播放器 UI（导航控件、面板、搜索）。如果您计划使用自己的播放器或需要没有 UI 的纯 SWF 框架，请禁用它。

**如果导出机器上缺少源字体会怎样？**

Aspose.Slides 将使用您通过[default_regular_font](https://reference.aspose.com/slides/python-net/aspose.slides.export/swfoptions/default_regular_font/)在[SwfOptions](https://reference.aspose.com/slides/python-net/aspose.slides.export/swfoptions/)中指定的字体进行替换，以避免意外的回退。