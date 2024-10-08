---
title: 默认字体
type: docs
weight: 30
url: /zh/cpp/default-font/
keywords: 
- 字体
- 默认字体
- 渲染演示文稿
- PowerPoint
- 演示文稿
- C++
- Aspose.Slides for C++
description: PowerPoint C++ API 允许您设置渲染演示文稿为 PDF、XPS 或缩略图时使用的默认字体
---

## **设置默认字体**
使用 Aspose.Slides for C++，您可以在 PowerPoint 演示文稿中设置默认字体。一个新方法 [set_DefaultRegularFont()](https://reference.aspose.com/slides/cpp/class/aspose.slides.export.i_save_options/#a9df129ea6e65c8196e08173799a10492) 已被添加到 [**SaveOptions**](https://reference.aspose.com/slides/cpp/class/aspose.slides.export.save_options/) 类中。它允许在将演示文稿保存为不同格式时使用缺失的所有字体的默认字体，而无需重新加载演示文稿。

下面的代码片段演示了使用不同的默认常规字体将演示文稿保存为 [HTML](https://docs.fileformat.com/web/html/) 和 [PDF](https://docs.fileformat.com/pdf/)。

{{< gist "aspose-com-gists" "81aeb05e6d3a070aa76fdea22ed53bc7" "Examples-SlidesCPP-SetDefaultFont-SetDefaultFont.cpp" >}}


## **使用默认字体渲染演示文稿**
Aspose.Slides 允许您设置用于将演示文稿渲染为 PDF、XPS 或缩略图的默认字体。本文展示了如何定义 DefaultRegular Font 和 DefaultAsian Font 作为默认字体。请按照以下步骤通过使用 Aspose.Slides for C++ API 从外部目录加载字体：

1. 创建一个 LoadOptions 的实例。
2. 将 DefaultRegularFont 设置为您想要的字体。在以下示例中，我使用了 Wingdings。
3. 将 DefaultAsianFont 设置为您想要的字体。在以下示例中我使用了 Wingdings。
4. 使用 Presentation 加载演示文稿并设置加载选项。
5. 现在，生成幻灯片缩略图、PDF 和 XPS 以验证结果。

上述实现如下所示。

```cpp
// 使用加载选项指定默认常规和亚洲字体
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