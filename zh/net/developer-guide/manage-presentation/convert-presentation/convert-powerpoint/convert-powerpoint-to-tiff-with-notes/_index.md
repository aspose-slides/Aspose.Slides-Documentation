---
title: 将 PowerPoint 转换为 TIFF，并包含备注
type: docs
weight: 100
url: /net/convert-powerpoint-to-tiff-with-notes/
keywords: "将 PowerPoint 转换为包含备注的 TIFF"
description: "在 Aspose.Slides 中将 PowerPoint 转换为包含备注的 TIFF。"
---

{{% alert title="提示" color="primary" %}}

您可能想查看 Aspose [免费的 PowerPoint 到海报转换器](https://products.aspose.app/slides/conversion/convert-ppt-to-poster-online)。

{{% /alert %}}

TIFF 是 Aspose.Slides for .NET 支持的几种广泛使用的图像格式之一，可以将带有备注的 PowerPoint PPT 和 PPTX 演示文稿转换为图像。您还可以在备注幻灯片视图中生成幻灯片缩略图。Presentation 类公开的 [Save](https://reference.aspose.com/slides/net/aspose.slides/presentation/methods/save/index) 方法可以用于将整份演示文稿以备注幻灯片视图转换为 TIFF。使用 Aspose.Slides for .NET 将 Microsoft PowerPoint 演示文稿保存为 TIFF 备注只需两行代码。您只需打开演示文稿并将其保存为 TIFF 备注。您还可以为单个幻灯片在备注幻灯片视图中生成幻灯片缩略图。以下代码片段更新示例演示文稿为备注幻灯片视图中的 TIFF 图像，如下所示：

```c#
// 实例化一个表示演示文稿文件的 Presentation 对象
using (Presentation presentation = new Presentation("NotesFile.pptx"))
{
    // 将演示文稿保存为 TIFF 备注
    presentation.Save("Notes_In_Tiff_out.tiff", SaveFormat.Tiff);
}
```