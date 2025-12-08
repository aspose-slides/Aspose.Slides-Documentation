---
title: 在 Python 中将 PPTX 转换为 PPT
linktitle: PPTX 转 PPT
type: docs
weight: 21
url: /zh/python-net/convert-pptx-to-ppt/
keywords:
- PPTX 转 PPT
- 将 PPTX 转换为 PPT
- 转换 PowerPoint
- 转换演示文稿
- Python
- Aspose.Slides
description: "使用 Aspose.Slides for Python via .NET轻松将 PPTX 转换为 PPT——确保与 PowerPoint 格式的无缝兼容，同时保留演示文稿的布局和质量。"
---

## **概述**

Aspose.Slides for Python 让您可以在代码中将现代 PPTX 演示文稿转换为传统 PPT 格式。打开 PPTX 并将其导出为 PPT，同时保持演示文稿的内容和布局，使结果兼容旧版 PowerPoint。相同的工作流还可以生成其他输出——如 PDF、XPS、ODP、HTML 或图像——因此能够平滑地集成到脚本、CI 管道和批处理任务中。

## **将 PPTX 转换为 PPT**

要将 PPTX 转换为 PPT，只需将文件名和保存格式传递给 [save](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/save/) 方法的 [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/) 类。下面的 Python 示例使用默认选项将演示文稿从 PPTX 转换为 PPT。
```py
import aspose.slides as slides

# 实例化表示 PPTX 文件的 Presentation 类。
presentation = slides.Presentation("presentation.pptx")

# 将演示文稿保存为 PPT 文件。
presentation.save("presentation.ppt", slides.export.SaveFormat.PPT)
```


## **常见问题**

**将 PPTX 保存为传统 PPT（97–2003）格式时，所有效果和功能都会保留吗？**

并非总是。PPT 格式缺少某些新功能（例如特定的效果、对象和行为），因此在转换过程中可能会对功能进行简化或光栅化。

**我可以只将选定的幻灯片转换为 PPT，而不是整个演示文稿吗？**

直接保存会针对整个演示文稿。若要转换特定幻灯片，请创建仅包含这些幻灯片的新演示文稿并将其保存为 PPT；或者使用支持按幻灯片转换参数的服务/API。

**是否支持受密码保护的演示文稿？**

支持。您可以检测文件是否受保护，使用密码打开，并且还能为保存的 PPT [configure protection/encryption settings](/slides/zh/python-net/password-protected-presentation/)。

**另请参阅:**
- [将 PPT & PPTX 转换为 PDF（Python）| 高级选项](/slides/zh/python-net/convert-powerpoint-to-pdf/)
- [将 PowerPoint 演示文稿转换为 XPS（Python）](/slides/zh/python-net/convert-powerpoint-to-xps/)
- [将 PowerPoint 演示文稿转换为 HTML（Python）](/slides/zh/python-net/convert-powerpoint-to-html/)
- [将 PowerPoint 幻灯片转换为 PNG（Python）](/slides/zh/python-net/convert-powerpoint-to-png/)