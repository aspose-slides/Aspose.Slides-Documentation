---
title: 默认字体 - PowerPoint C# API
linktitle: 默认字体
type: docs
weight: 30
url: /net/default-font/
keywords: 
- 字体
- 默认字体
- 渲染演示文稿
- PowerPoint
- 演示文稿
- C#
- Csharp
- Aspose.Slides for .NET
description: PowerPoint C# API 允许您设置渲染演示文稿到 PDF、XPS 或缩略图的默认字体
---

## **使用默认字体渲染演示文稿**
Aspose.Slides 允许您设置渲染演示文稿到 PDF、XPS 或缩略图的默认字体。本文展示了如何定义 DefaultRegular Font 和 DefaultAsian Font 作为默认字体。请按照以下步骤使用 Aspose.Slides for .NET API 从外部目录加载字体：

1. 创建 LoadOptions 的实例。
1. 将 DefaultRegularFont 设置为您想要的字体。在以下示例中，我使用了 Wingdings。
1. 将 DefaultAsianFont 设置为您想要的字体。在以下示例中，我也使用了 Wingdings。
1. 使用 Presentation 加载演示文稿并设置加载选项。
1. 现在，生成幻灯片缩略图、PDF 和 XPS 以验证结果。

上述实现如下所示。

```c#
// 使用加载选项指定默认常规和亚洲字体
LoadOptions loadOptions = new LoadOptions(LoadFormat.Auto);
loadOptions.DefaultRegularFont = "Wingdings";
loadOptions.DefaultAsianFont = "Wingdings";

using (Presentation pptx = new Presentation("DefaultFonts.pptx", loadOptions))
{
    using (IImage image = pptx.Slides[0].GetImage(1, 1))
    {
        image.Save("DefaultFonts_out.png", ImageFormat.Png);
    }

    pptx.Save("DefaultFonts_out.pdf", SaveFormat.Pdf);
    pptx.Save("DefaultFonts_out.xps", SaveFormat.Xps);
}
```