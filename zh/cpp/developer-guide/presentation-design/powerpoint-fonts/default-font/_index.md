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
description: "在 Aspose.Slides for C++ 中设置默认字体，以确保 PowerPoint（PPT、PPTX）和 OpenDocument（ODP）正确转换为 PDF、XPS 和图像。"
---

## **设置默认字体**
使用 Aspose.Slides for C++，您可以在 PowerPoint 演示文稿中设置默认字体。已在 [**SaveOptions**](https://reference.aspose.com/slides/cpp/class/aspose.slides.export.save_options/) 类中添加了新方法 [set_DefaultRegularFont()](https://reference.aspose.com/slides/cpp/class/aspose.slides.export.i_save_options/#a9df129ea6e65c8196e08173799a10492)。该方法允许在保存演示文稿为不同格式时，使用默认字体替代所有缺失的字体，而无需重新加载演示文稿。

下面的代码片段演示了将演示文稿保存为 [HTML](https://docs.fileformat.com/web/html/) 和 [PDF](https://docs.fileformat.com/pdf/) 并使用不同的默认常规字体。

{{< gist "aspose-com-gists" "81aeb05e6d3a070aa76fdea22ed53bc7" "Examples-SlidesCPP-SetDefaultFont-SetDefaultFont.cpp" >}}


## **在渲染演示文稿时使用默认字体**
Aspose.Slides 允许您为将演示文稿渲染为 PDF、XPS 或缩略图时设置默认字体。本文展示了如何定义 DefaultRegularFont 和 DefaultAsianFont 作为默认字体。请按照以下步骤使用 Aspose.Slides for C++ API 从外部目录加载字体：

1. 创建 LoadOptions 实例。  
1. 将 DefaultRegularFont 设置为您想要的字体。在下面的示例中，我使用了 Wingdings。  
1. 将 DefaultAsianFont 设置为您想要的字体。示例中同样使用了 Wingdings。  
1. 使用 Presentation 加载演示文稿并设置加载选项。  
1. 现在，生成幻灯片缩略图、PDF 和 XPS 以验证结果。

以下给出了上述实现代码。
```cpp
// 使用加载选项指定默认常规字体和亚洲字体
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

**DefaultRegularFont 和 DefaultAsianFont 到底影响什么——仅导出，还是包括缩略图、PDF、XPS、HTML 和 SVG？**

它们参与所有受支持输出的渲染管线。这包括幻灯片缩略图、[PDF](/slides/zh/cpp/convert-powerpoint-to-pdf/)、[XPS](/slides/zh/cpp/convert-powerpoint-to-xps/)、[光栅图像](/slides/zh/cpp/convert-powerpoint-to-png/)、[HTML](/slides/zh/cpp/convert-powerpoint-to-html/) 和 [SVG](/slides/zh/cpp/render-a-slide-as-an-svg-image/)，因为 Aspose.Slides 在这些目标之间使用相同的布局和字形解析逻辑。

**在仅读取并保存 PPTX 而不进行任何渲染时，默认字体会被应用吗？**

不会。默认字体仅在必须对文本进行测量和绘制时才起作用。直接打开并保存演示文稿不会更改存储的字体运行或文件结构。默认字体只在渲染或重新排版文本的操作中发挥作用。

**如果我添加自己的字体文件夹或从内存提供字体，它们会在选择默认字体时被考虑吗？**

会。[自定义字体源](/slides/zh/cpp/custom-font/) 会扩展引擎可用的字体族和字形目录。默认字体以及任何 [回退规则](/slides/zh/cpp/fallback-font/) 都会首先在这些来源中查找，从而在服务器或容器中提供更可靠的覆盖。

**默认字体会影响文本度量（字距、前进宽度），从而影响换行和自动换行吗？**

会。更换字体会改变字形度量，可能在渲染期间导致换行、自动换行和分页的变化。为保持布局稳定，建议 [嵌入原始字体](/slides/zh/cpp/embedded-font/) 或选择度量兼容的默认和回退字体族。

**如果演示文稿中使用的所有字体都已嵌入，设置默认字体还有意义吗？**

通常没有必要，因为 [嵌入字体](/slides/zh/cpp/embedded-font/) 已经确保外观一致。默认字体仍然可以作为安全网，处理嵌入子集未覆盖的字符或文件中混合了嵌入和未嵌入文本的情况。