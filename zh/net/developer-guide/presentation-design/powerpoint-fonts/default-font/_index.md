---
title: 在 .NET 中指定默认演示文稿字体
linktitle: 默认字体
type: docs
weight: 30
url: /zh/net/default-font/
keywords:
- 默认字体
- 常规字体
- 普通字体
- 亚洲字体
- PDF 导出
- XPS 导出
- 图像导出
- PowerPoint
- OpenDocument
- 演示文稿
- .NET
- C#
- Aspose.Slides
description: "在 Aspose.Slides for .NET 中设置默认字体，以确保 PowerPoint（PPT、PPTX）和 OpenDocument（ODP）正确转换为 PDF、XPS 和图像。"
---

## **使用默认字体渲染演示文稿**
Aspose.Slides 允许您设置用于将演示文稿渲染为 PDF、XPS 或缩略图的默认字体。本文展示如何定义 DefaultRegularFont 和 DefaultAsianFont 作为默认字体。请按照以下步骤使用 Aspose.Slides for .NET API 从外部目录加载字体：

1. 创建 LoadOptions 的实例。
1. 将 DefaultRegularFont 设置为您想要的字体。在下面的示例中，我使用了 Wingdings。
1. 将 DefaultAsianFont 设置为您想要的字体。在以下示例中，我使用了 Wingdings。
1. 使用 Presentation 加载演示文稿并设置加载选项。
1. 现在，生成幻灯片缩略图、PDF 和 XPS 以验证结果。

以下给出上述实现。
```c#
// 使用加载选项来指定默认的常规字体和亚洲字体
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

**DefaultRegularFont 和 DefaultAsianFont 具体影响什么——仅导出，还是包括缩略图、PDF、XPS、HTML 和 SVG？**

它们参与所有受支持输出的渲染管线。这包括幻灯片缩略图、[PDF](/slides/zh/net/convert-powerpoint-to-pdf/)、[XPS](/slides/zh/net/convert-powerpoint-to-xps/)、[raster images](/slides/zh/net/convert-powerpoint-to-png/)、[HTML](/slides/zh/net/convert-powerpoint-to-html/)、以及[SVG](/slides/zh/net/render-a-slide-as-an-svg-image/)，因为 Aspose.Slides 在这些目标上使用相同的布局和字形解析逻辑。

**在仅读取并保存 PPTX 而不进行任何渲染时，会应用默认字体吗？**

不。只有在需要测量和绘制文本时，默认字体才会发挥作用。直接打开并保存演示文稿不会更改存储的字体运行或文件结构。默认字体会在渲染或重新排版文本的操作中生效。

**如果我添加了自己的字体文件夹或从内存提供字体，它们会在选择默认字体时被考虑吗？**

是的。[Custom font sources](/slides/zh/net/custom-font/) 扩展了可用字体族和字形的目录，供引擎使用。默认字体和任何[fallback rules](/slides/zh/net/fallback-font/)将首先针对这些源进行解析，从而在服务器和容器中实现更可靠的覆盖。

**默认字体会影响文本度量（字距、前进宽度），从而影响换行和自动换行吗？**

会。更改字体会改变字形度量，并可能在渲染期间影响换行、自动换行和分页。为保持布局稳定，建议[embed the original fonts](/slides/zh/net/embedded-font/)或选择在度量上兼容的默认和回退字体族。

**如果演示文稿中使用的所有字体都已嵌入，设置默认字体还有意义吗？**

通常没有必要，因为[embedded fonts](/slides/zh/net/embedded-font/)已经确保外观一致。默认字体仍可作为安全网，针对嵌入子集未覆盖的字符或文件混合了嵌入和未嵌入文本的情况提供保障。