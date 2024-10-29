---
title: 默认字体 - PowerPoint Java API
linktitle: 默认字体
type: docs
weight: 30
url: /zh/java/default-font/
description: PowerPoint Java API 允许您设置将演示文稿渲染为 PDF、XPS 或缩略图的默认字体。本文展示了如何定义 DefaultRegular Font 和 DefaultAsian Font 作为默认字体。
---


## **使用默认字体渲染演示文稿**
Aspose.Slides 允许您设置默认字体用于将演示文稿渲染为 PDF、XPS 或缩略图。本文展示了如何定义 DefaultRegular Font 和 DefaultAsian Font 作为默认字体。请按照以下步骤使用 Aspose.Slides for Java API 从外部目录加载字体：

1. 创建一个 [LoadOptions](https://reference.aspose.com/slides/java/com.aspose.slides/LoadOptions) 的实例。
1. [设置 DefaultRegularFont](https://reference.aspose.com/slides/java/com.aspose.slides/LoadOptions#setDefaultRegularFont-java.lang.String-) 为您所需的字体。在以下示例中，我使用了 Wingdings。
1. [设置 DefaultAsianFont](https://reference.aspose.com/slides/java/com.aspose.slides/LoadOptions#setDefaultAsianFont-java.lang.String-) 为您所需的字体。在下面的示例中，我也使用了 Wingdings。
1. 使用 Presentation 加载演示文稿并设置加载选项。
1. 现在，生成幻灯片缩略图、PDF 和 XPS 以验证结果。

上述实现如下所示。

```java
// 使用加载选项定义默认的常规和亚洲字体
LoadOptions loadOptions = new LoadOptions(LoadFormat.Auto);
loadOptions.setDefaultRegularFont("Wingdings");
loadOptions.setDefaultAsianFont("Wingdings");

// 加载演示文稿
Presentation pres = new Presentation("DefaultFonts.pptx", loadOptions);
try {
    // 生成幻灯片缩略图
    IImage slideImage = pres.getSlides().get_Item(0).getImage(1, 1);
    try {
         // 将图片保存到磁盘。
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