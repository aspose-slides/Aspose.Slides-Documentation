---
title: 默认字体 - PowerPoint C# API
linktitle: 默认字体
type: docs
weight: 30
url: /zh/net/default-font/
keywords:
- 字体
- 默认字体
- 渲染演示文稿
- PowerPoint
- 演示文稿
- C#
- CSharp
- Aspose.Slides for .NET
description: PowerPoint C# API 允许您设置默认字体，以将演示文稿渲染为 PDF、XPS 或缩略图
---

## **在渲染演示文稿时使用默认字体**
Aspose.Slides 允许您为将演示文稿渲染为 PDF、XPS 或缩略图设置默认字体。本文展示了如何定义 DefaultRegular Font 和 DefaultAsian Font 以用作默认字体。请按照以下步骤使用 Aspose.Slides for .NET API 从外部目录加载字体：

1. 创建 LoadOptions 的实例。
1. 将 DefaultRegularFont 设置为您想要的字体。在下面的示例中，我使用了 Wingdings。
1. 将 DefaultAsianFont 设置为您想要的字体。下面的示例中我使用了 Wingdings。
1. 使用 Presentation 加载演示文稿并设置加载选项。
1. 现在，生成幻灯片缩略图、PDF 和 XPS 以验证结果。

上述实现如下所示。
```c#
// 使用加载选项指定默认的常规和亚洲字体
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


## **常见问题**

**DefaultRegularFont 和 DefaultAsianFont 到底影响什么——仅导出，还是包括缩略图、PDF、XPS、HTML 和 SVG？**

它们参与所有受支持输出的渲染管道。这包括幻灯片缩略图、[PDF](/slides/zh/net/convert-powerpoint-to-pdf/)、[XPS](/slides/zh/net/convert-powerpoint-to-xps/)、[光栅图像](/slides/zh/net/convert-powerpoint-to-png/)、[HTML](/slides/zh/net/convert-powerpoint-to-html/)、以及 [SVG](/slides/zh/net/render-a-slide-as-an-svg-image/)，因为 Aspose.Slides 在这些目标上使用相同的布局和字形解析逻辑。

**在仅读取并保存 PPTX 而不进行任何渲染时，默认字体会被应用吗？**

不会。仅在需要对文本进行测量和绘制时，默认字体才会生效。直接打开并保存演示文稿不会更改已存储的字体运行或文件结构。默认字体在渲染或重新排版文本的操作中才会起作用。

**如果我添加了自己的字体文件夹或从内存提供字体，它们会在选择默认字体时被考虑吗？**

会。[自定义字体来源](/slides/zh/net/custom-font/)会扩展引擎可使用的可用字体族和字形目录。默认字体以及任何 [回退规则](/slides/zh/net/fallback-font/) 会首先在这些来源中解析，从而在服务器和容器中提供更可靠的覆盖。

**默认字体会影响文本度量（字距、前进）从而影响换行和折行吗？**

会。更改字体会改变字形度量，从而在渲染过程中影响换行、折行和分页。为了布局稳定性，请 [嵌入原始字体](/slides/zh/net/embedded-font/) 或选择在度量上兼容的默认和回退字体族。

**如果演示文稿中使用的所有字体都已嵌入，设置默认字体还有意义吗？**

通常没有必要，因为 [嵌入的字体](/slides/zh/net/embedded-font/) 已经确保外观一致。默认字体仍可作为安全网，处理嵌入子集未覆盖的字符或文件中混合了嵌入和未嵌入文本的情况。