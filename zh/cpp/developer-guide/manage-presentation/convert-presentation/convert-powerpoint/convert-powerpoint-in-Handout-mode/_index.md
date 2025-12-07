---
title: 使用 C++ 将 PowerPoint 演示文稿转换为讲义模式
linktitle: 讲义模式
type: docs
weight: 150
url: /zh/cpp/convert-powerpoint-in-Handout-mode/
keywords:
- 转换 PowerPoint
- 转换 演示文稿
- 讲义模式
- 讲义
- PPT
- PPTX
- PowerPoint
- 演示文稿
- C++
- Aspose.Slides
description: "使用 C++ 将演示文稿转换为讲义。设置每页幻灯片数，保留备注，使用 Aspose.Slides 导出为 PDF 或图像，并附有示例代码。免费试用。"
---

## **讲义模式导出**

Aspose.Slides 提供将演示文稿转换为多种格式的功能，包括在讲义模式下创建用于打印的讲义。此模式可让您配置多张幻灯片在单页上的显示方式，适用于会议、研讨会等场合。您可以通过在 [IPdfOptions]({{link}}) 、[IRenderingOptions]({{link}}) 、[IHtmlOptions]({{link}}) 和 [ITiffOptions]({{link}}) 接口中设置 `set_SlidesLayoutOptions` 方法来启用此模式。

要配置讲义模式，请使用 [HandoutLayoutingOptions]({{link}}) 对象，它决定单页上放置的幻灯片数量及其他显示参数。

下面的代码示例展示了如何在讲义模式下将演示文稿转换为 PDF。
```cpp
// 加载演示文稿.
auto presentation = MakeObject<Presentation>(u"sample.pptx");

// Set the export options.
auto slidesLayoutOptions = MakeObject<HandoutLayoutingOptions>();
slidesLayoutOptions->set_Handout(HandoutType::Handouts4Horizontal);  // 每页水平排列 4 张幻灯片
slidesLayoutOptions->set_PrintSlideNumbers(true);                    // 打印幻灯片编号
slidesLayoutOptions->set_PrintFrameSlide(true);                      // 在幻灯片周围打印框线
slidesLayoutOptions->set_PrintComments(false);                       // 无注释

auto pdfOptions = MakeObject<PdfOptions>();
pdfOptions->set_SlidesLayoutOptions(slidesLayoutOptions);

// Export the presentation to PDF with the chosen layout.
presentation->Save(u"output.pdf", SaveFormat::Pdf, pdfOptions);
presentation->Dispose();
```


{{% alert color="warning" %}} 

请注意，`set_SlidesLayoutOptions` 方法仅在某些输出格式（如 PDF、HTML、TIFF）以及以图像方式渲染时可用。

{{% /alert %}} 

## **常见问题**

**在讲义模式下，每页最大可以显示多少个幻灯片缩略图？**

Aspose.Slides 支持的 [presets]({{link}}) 最多每页 9 个缩略图，支持水平或垂直排列：1、2、3、4（水平/垂直）、6（水平/垂直）和 9（水平/垂直）。

**我可以自定义网格，例如每页 5 张或 8 张幻灯片吗？**

不可以。缩略图的数量和排列方式严格受 [HandoutType]({{link}}) 枚举控制，不支持任意布局。

**我可以在讲义输出中包含隐藏的幻灯片吗？**

可以。请在目标格式的导出设置中使用 `set_ShowHiddenSlides` 方法，例如在 [PdfOptions]({{link}})、[HtmlOptions]({{link}}) 或 [TiffOptions]({{link}}) 中。