---
title: 在 Java 中指定默认演示文稿字体
linktitle: 默认字体
type: docs
weight: 30
url: /zh/java/default-font/
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
- Java
- Aspose.Slides
description: "在 Aspose.Slides for Java 中设置默认字体，以确保 PowerPoint（PPT、PPTX）和 OpenDocument（ODP）正确转换为 PDF、XPS 和图像。"
---

## **使用默认字体渲染演示文稿**
Aspose.Slides 允许您设置在将演示文稿渲染为 PDF、XPS 或缩略图时使用的默认字体。本文展示如何定义 DefaultRegularFont 和 DefaultAsianFont 作为默认字体。请按以下步骤使用 Aspose.Slides for Java API 从外部目录加载字体：

1. 创建一个 [LoadOptions](https://reference.aspose.com/slides/java/com.aspose.slides/LoadOptions) 实例。
2. [Set the DefaultRegularFont](https://reference.aspose.com/slides/java/com.aspose.slides/LoadOptions#setDefaultRegularFont-java.lang.String-) 设置为您想要的字体。在下面的示例中，我使用了 Wingdings。
3. [Set the DefaultAsianFont](https://reference.aspose.com/slides/java/com.aspose.slides/LoadOptions#setDefaultAsianFont-java.lang.String-) 设置为您想要的字体。我在下面的示例中使用了 Wingdings。
4. 使用 Presentation 加载演示文稿并设置加载选项。
5. 现在，生成幻灯片缩略图、PDF 和 XPS 以验证结果。

上述实现如下所示。
```java
// 使用加载选项定义默认的常规字体和亚洲字体
LoadOptions loadOptions = new LoadOptions(LoadFormat.Auto);
loadOptions.setDefaultRegularFont("Wingdings");
loadOptions.setDefaultAsianFont("Wingdings");

// 加载演示文稿
Presentation pres = new Presentation("DefaultFonts.pptx", loadOptions);
try {
    // 生成幻灯片缩略图
    IImage slideImage = pres.getSlides().get_Item(0).getImage(1, 1);
    try {
         // 将图像保存到磁盘上。
          slideImage.save("output.png", ImageFormat.Png);
    } finally {
         if (slideImage != null) slideImage.dispose();
    }

    // 生成 PDF
    pres.save("output_out.pdf", SaveFormat.Pdf);

    // 生成 XPS
    pres.save("output_out.xps", SaveFormat.Xps);
} catch (IOException e) {
} finally {
    if (pres != null) pres.dispose();
}
```


## **常见问题**

**DefaultRegularFont 和 DefaultAsianFont 究竟影响哪些方面——仅导出，还是包括缩略图、PDF、XPS、HTML 和 SVG？**

它们参与所有受支持输出的渲染管线。这包括幻灯片缩略图、[PDF](/slides/zh/java/convert-powerpoint-to-pdf/)、[XPS](/slides/zh/java/convert-powerpoint-to-xps/)、[栅格图像](/slides/zh/java/convert-powerpoint-to-png/)、[HTML](/slides/zh/java/convert-powerpoint-to-html/)、以及 [SVG](/slides/zh/java/render-a-slide-as-an-svg-image/)，因为 Aspose.Slides 在这些目标上使用相同的布局和字形解析逻辑。

**仅读取并保存 PPTX 而不进行任何渲染时，是否会应用默认字体？**

否。只有在需要测量和绘制文本时，默认字体才会起作用。直接打开并保存演示文稿不会更改已存储的字体运行或文件结构。默认字体在渲染或重新排版文本的操作中才会生效。

**如果我添加自己的字体文件夹或从内存提供字体，它们会在选择默认字体时被考虑吗？**

是的。[自定义字体源](/slides/zh/java/custom-font/) 会扩展引擎可用的字体家族和字形目录。默认字体和任何 [回退规则](/slides/zh/java/fallback-font/) 将首先在这些来源中解析，从而在服务器和容器中提供更可靠的覆盖。

**默认字体会影响文本度量（字距、前进宽度），从而影响换行和换行方式吗？**

是的。更改字体会改变字形度量，并可能在渲染过程中改变换行、自动换行和分页。为确保布局稳定，建议 [嵌入原始字体](/slides/zh/java/embedded-font/) 或选择度量兼容的默认和回退字体家族。

**如果演示文稿中使用的所有字体都已嵌入，设置默认字体还有意义吗？**

通常没有必要，因为 [嵌入字体](/slides/zh/java/embedded-font/) 已经确保外观一致。默认字体仍可作为安全网，处理未被嵌入子集覆盖的字符，或在文件同时包含嵌入和未嵌入文本的情况。