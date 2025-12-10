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
description: "使用 C++ 将演示文稿转换为讲义。设置每页幻灯片数量，保留备注，使用 Aspose.Slides 导出为 PDF 或图像，并附带示例代码。免费试用。"
---

## **讲义模式导出**

Aspose.Slides 提供将演示文稿转换为多种格式的功能，包括在讲义模式下创建供打印的讲义。该模式允许您配置多个幻灯片在单页上的显示方式，非常适用于会议、研讨会和其他活动。您可以通过在 [IPdfOptions](https://reference.aspose.com/slides/cpp/aspose.slides.export/ipdfoptions/)、[IRenderingOptions](https://reference.aspose.com/slides/cpp/aspose.slides.export/irenderingoptions/)、[IHtmlOptions](https://reference.aspose.com/slides/cpp/aspose.slides.export/ihtmloptions/) 和 [ITiffOptions](https://reference.aspose.com/slides/cpp/aspose.slides.export/itiffoptions/) 接口中设置 `set_SlidesLayoutOptions` 方法来启用此模式。

要配置讲义模式，请使用 [HandoutLayoutingOptions](https://reference.aspose.com/slides/cpp/aspose.slides.export/handoutlayoutingoptions/) 对象，它决定在单页上放置多少幻灯片以及其他显示参数。

下面的代码示例展示了如何在讲义模式下将演示文稿转换为 PDF。
```cpp
// 加载演示文稿。
auto presentation = MakeObject<Presentation>(u"sample.pptx");

// 设置导出选项。
auto slidesLayoutOptions = MakeObject<HandoutLayoutingOptions>();
slidesLayoutOptions->set_Handout(HandoutType::Handouts4Horizontal);  // 每页水平放置 4 张幻灯片
slidesLayoutOptions->set_PrintSlideNumbers(true);                    // 打印幻灯片编号
slidesLayoutOptions->set_PrintFrameSlide(true);                      // 在幻灯片周围打印框
slidesLayoutOptions->set_PrintComments(false);                       // 不打印注释

auto pdfOptions = MakeObject<PdfOptions>();
pdfOptions->set_SlidesLayoutOptions(slidesLayoutOptions);

// 使用所选布局将演示文稿导出为 PDF。
presentation->Save(u"output.pdf", SaveFormat::Pdf, pdfOptions);
presentation->Dispose();
```


{{% alert color="warning" %}} 
请注意，`set_SlidesLayoutOptions` 方法仅在某些输出格式中可用，例如 PDF、HTML、TIFF，以及渲染为图像时。
{{% /alert %}} 

## **常见问题**

**在讲义模式下，每页幻灯片缩略图的最大数量是多少？**

Aspose.Slides 支持最多每页 9 张缩略图的[预设](https://reference.aspose.com/slides/cpp/aspose.slides.export/handouttype/)，并可选择横向或纵向排列：1、2、3、4（横向/纵向）、6（横向/纵向）和 9（横向/纵向）。

**我可以定义自定义网格，例如每页 5 或 8 张幻灯片吗？**

不可以。缩略图的数量和顺序严格由[HandoutType](https://reference.aspose.com/slides/cpp/aspose.slides.export/handouttype/)枚举控制；不支持任意布局。

**我可以在讲义输出中包含隐藏的幻灯片吗？**

可以。使用目标格式的导出设置中的 `set_ShowHiddenSlides` 方法，例如 [PdfOptions](https://reference.aspose.com/slides/cpp/aspose.slides.export/pdfoptions/)、[HtmlOptions](https://reference.aspose.com/slides/cpp/aspose.slides.export/htmloptions/) 或 [TiffOptions](https://reference.aspose.com/slides/cpp/aspose.slides.export/tiffoptions/)。