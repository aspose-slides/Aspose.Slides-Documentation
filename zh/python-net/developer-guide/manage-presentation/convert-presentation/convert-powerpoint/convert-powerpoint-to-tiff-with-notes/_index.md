---
title: 将 PowerPoint 转换为带备注的 TIFF
type: docs
weight: 100
url: /python-net/convert-powerpoint-to-tiff-with-notes/
keywords: "将 PowerPoint 转换为带备注的 TIFF"
description: "在 Aspose.Slides 中将 PowerPoint 转换为带备注的 TIFF。"
---

{{% alert title="提示" color="primary" %}}

您可能想查看 Aspose 的 [免费 PowerPoint 转海报转换器](https://products.aspose.app/slides/conversion/convert-ppt-to-poster-online)。

{{% /alert %}}

TIFF 是 Aspose.Slides for Python via .NET 支持将带备注的 PowerPoint PPT 和 PPTX 演示文稿转换为图像的几种广泛使用的图像格式之一。您还可以在备注幻灯片视图中生成幻灯片缩略图。Presentation 类公开的 [Save](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/) 方法可以用于将整个演示文稿在备注幻灯片视图中转换为 TIFF。使用 Aspose.Slides for Python via .NET 将 Microsoft PowerPoint 演示文稿保存为 TIFF 备注的过程只需两行代码。您只需打开演示文稿并将其保存为 TIFF 备注。您还可以为单个幻灯片在备注幻灯片视图中生成幻灯片缩略图。下面的代码片段将示例演示文稿更新为备注幻灯片视图中的 TIFF 图像，如下所示：

```py
import aspose.slides as slides

# 实例化一个 Presentation 对象，表示一个演示文稿文件
presentation = slides.Presentation("pres.pptx")

# 将演示文稿保存为 TIFF 备注
presentation.save("Notes_In_Tiff_out.tiff", slides.export.SaveFormat.TIFF)
```