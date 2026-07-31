---
title: 在 C++ 中指定默认演示文稿字体
linktitle: 默认字体
type: docs
weight: 30
url: /zh/cpp/default-font/
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
- C++
- Aspose.Slides
description: "在 Aspose.Slides for C++ 中设置默认字体，以确保 PowerPoint (PPT, PPTX) 和 OpenDocument (ODP) 正确转换为 PDF、XPS 和图像。"
---
## **概述**

Aspose.Slides 允许您指定在呈现演示文稿时使用的默认字体。这在生成幻灯片缩略图或将演示文稿导出为 PDF、XPS 等格式时非常有用。默认字体通过 `LoadOptions` 在加载演示文稿之前进行配置。

`set_DefaultRegularFont` 方法定义常规文本的默认字体，而 `set_DefaultAsianFont` 定义亚洲文本的默认字体。设置这些选项后，演示文稿即可使用指定的字体加载并渲染。

## **使用默认字体渲染演示文稿**
Aspose.Slides 允许您设置用于将演示文稿渲染为 PDF、XPS 或缩略图的默认字体。本文展示如何定义 DefaultRegular Font 和 DefaultAsian Font 作为默认字体。请按照以下步骤使用 Aspose.Slides for C++ API 从外部目录加载字体：

1. 创建一个 LoadOptions 实例。
1. 将 DefaultRegularFont 设置为您想要的字体。在下面的示例中，我使用了 Wingdings。
1. 将 DefaultAsianFont 设置为您想要的字体。在下面的示例中，我使用了 Wingdings。
1. 使用 Presentation 加载演示文稿，并设置加载选项。
1. 现在，生成幻灯片缩略图、PDF 和 XPS 以验证结果。

上述实现如下所示。

```cpp
// 使用加载选项来指定默认的常规字体和亚洲字体
auto loadOptions = MakeObject<LoadOptions>(LoadFormat::Auto);
loadOptions->set_DefaultRegularFont(u"Wingdings");
loadOptions->set_DefaultAsianFont(u"Wingdings");

auto pptx = MakeObject<Presentation>(u"DefaultFonts.pptx", loadOptions);

auto image = pptx->get_Slide(0)->GetImage(1, 1);
image->Save(u"DefaultFonts_out.png", ImageFormat::Png);
image->Dispose();

pptx->Save(u"DefaultFonts_out.pdf", SaveFormat::Pdf);
pptx->Save(u"DefaultFonts_out.xps", SaveFormat::Xps);

pptx->Dispose();
```

## **常见问题**

**DefaultRegularFont 和 DefaultAsianFont 具体影响什么——仅导出，还是也影响缩略图、PDF、XPS、HTML 和 SVG？**

它们参与所有受支持输出的渲染管线。包括幻灯片缩略图、[PDF](/slides/zh/cpp/convert-powerpoint-to-pdf/)、[XPS](/slides/zh/cpp/convert-powerpoint-to-xps/)、[栅格图像](/slides/zh/cpp/convert-powerpoint-to-png/)、[HTML](/slides/zh/cpp/convert-powerpoint-to-html/)以及[SVG](/slides/zh/cpp/render-a-slide-as-an-svg-image/)，因为 Aspose.Slides 在这些目标上使用相同的布局和字形解析逻辑。

**仅读取并保存 PPTX 而不进行任何渲染时，会应用默认字体吗？**

不会。默认字体只有在需要测量和绘制文本时才起作用。直接打开并保存演示文稿不会改变已存储的字体运行或文件结构。默认字体在渲染或重新排版文本的操作中才会生效。

**如果我添加自己的字体文件夹或提供内存中的字体，它们会在选择默认字体时被考虑吗？**

是的。[自定义字体来源](/slides/zh/cpp/custom-font/) 会扩展引擎可用的字体族和字形目录。默认字体以及任何[回退规则](/slides/zh/cpp/fallback-font/) 将首先针对这些来源进行解析，从而在服务器和容器中提供更可靠的覆盖。

**默认字体会影响文本度量（字距、前进宽度），进而影响换行和换行方式吗？**

会。更改字体会改变字形度量，并可能在渲染过程中改变换行、折行和分页。为保持布局稳定，建议[嵌入原始字体](/slides/zh/cpp/embedded-font/)或选择度量兼容的默认和回退字体族。

**如果演示文稿中使用的所有字体都已嵌入，设置默认字体还有意义吗？**

通常没有必要，因为[嵌入字体](/slides/zh/cpp/embedded-font/) 已经确保外观一致。默认字体仍然可以作为安全网，处理嵌入子集未覆盖的字符，或在文件混合了嵌入和未嵌入文本的情况。