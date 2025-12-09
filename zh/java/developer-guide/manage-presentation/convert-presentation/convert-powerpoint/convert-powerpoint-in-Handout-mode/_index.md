---
title: 在 Java 中将 PowerPoint 演示文稿转换为讲义模式
linktitle: 讲义模式
type: docs
weight: 150
url: /zh/java/convert-powerpoint-in-Handout-mode/
keywords:
- 转换 PowerPoint
- 转换 演示文稿
- 讲义模式
- 讲义
- PPT
- PPTX
- PowerPoint
- 演示文稿
- Java
- Aspose.Slides
description: "在 Java 中将演示文稿转换为讲义。设置每页幻灯片数量，保留备注，使用 Aspose.Slides 导出为 PDF 或图像，并提供示例 Java 代码。免费试用。"
---

Aspose.Slides 提供将演示文稿转换为多种格式的功能，包括在 Handout 模式下创建用于打印的讲义。此模式允许您配置多个幻灯片在单页上的显示方式，适用于会议、研讨会等活动。您可以通过在 [IPdfOptions](https://reference.aspose.com/slides/java/com.aspose.slides/ipdfoptions/)、[IRenderingOptions](https://reference.aspose.com/slides/java/com.aspose.slides/irenderingoptions/)、[IHtmlOptions](https://reference.aspose.com/slides/java/com.aspose.slides/ihtmloptions/) 和 [ITiffOptions](https://reference.aspose.com/slides/java/com.aspose.slides/itiffoptions/) 接口中设置 `setSlidesLayoutOptions` 方法来启用此模式。

要配置 Handout 模式，请使用 [HandoutLayoutingOptions](https://reference.aspose.com/slides/java/com.aspose.slides/handoutlayoutingoptions/) 对象，该对象决定单页上放置的幻灯片数量以及其他显示参数。

以下示例展示了如何在 Handout 模式下将演示文稿转换为 PDF。
```java
// 加载演示文稿。
Presentation presentation = new Presentation("sample.pptx");
try {
    // 设置导出选项。
    HandoutLayoutingOptions slidesLayoutOptions = new HandoutLayoutingOptions();
    slidesLayoutOptions.setHandout(HandoutType.Handouts4Horizontal);  // 每页水平放置 4 张幻灯片
    slidesLayoutOptions.setPrintSlideNumbers(true);                   // 打印幻灯片编号
    slidesLayoutOptions.setPrintFrameSlide(true);                     // 为幻灯片打印边框
    slidesLayoutOptions.setPrintComments(false);                      // 无注释

    PdfOptions pdfOptions = new PdfOptions();
    pdfOptions.setSlidesLayoutOptions(slidesLayoutOptions);

    // 导出演示文稿为 PDF，使用所选布局。
    presentation.save("output.pdf", SaveFormat.Pdf, pdfOptions);
} finally {
    if (presentation != null) presentation.dispose();    
}
```


{{% alert color="warning" %}} 
请注意，`setSlidesLayoutOptions` 方法仅在某些输出格式（如 PDF、HTML、TIFF）以及以图像形式渲染时可用。 
{{% /alert %}}