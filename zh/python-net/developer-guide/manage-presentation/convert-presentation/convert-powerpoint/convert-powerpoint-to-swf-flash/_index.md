---
title: 将 PowerPoint 转换为 SWF Flash
type: docs
weight: 80
url: /zh/python-net/convert-powerpoint-to-swf-flash/
keywords: "转换 PowerPoint, 演示文稿, PowerPoint 到 SWF, SWF Flash PPT 到 SWF, PPTX 到 SWF, Python"
description: "在 Python 中将 PowerPoint 演示文稿转换为 SWF Flash"
---

由 [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/) 类提供的 [Save](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/) 方法可用于将整个演示文稿转换为 SWF 文档。 您还可以使用 [SWFOptions](https://reference.aspose.com/slides/python-net/aspose.slides.export/swfoptions/) 类和 [INotesCommentsLayoutingOptions](https://reference.aspose.com/slides/python-net/aspose.slides.export/inotescommentslayoutingoptions/) 接口在生成的 SWF 中包含注释。 以下示例展示了如何使用 SWFOptions 类提供的选项将演示文稿转换为 SWF 文档。

```py
import aspose.slides as slides

# 实例化一个表示演示文稿文件的 Presentation 对象
presentation = slides.Presentation("pres.pptx")

swfOptions = slides.export.SwfOptions()
swfOptions.viewer_included = False
swfOptions.notes_comments_layouting.notes_position = slides.export.NotesPositions.BOTTOM_FULL

# 保存演示文稿和笔记页面
presentation.save("SaveAsSwf_out.swf", slides.export.SaveFormat.SWF, swfOptions)
swfOptions.viewer_included = True
presentation.save("SaveNotes_out.swf", slides.export.SaveFormat.SWF, swfOptions)
```