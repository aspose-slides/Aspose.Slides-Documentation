---
title: 在 Android 上高效合并演示文稿
linktitle: 合并演示文稿
type: docs
weight: 40
url: /zh/androidjava/merge-presentation/
keywords:
- 合并 PowerPoint
- 合并演示文稿
- 合并幻灯片
- 合并 PPT
- 合并 PPTX
- 合并 ODP
- 组合 PowerPoint
- 组合演示文稿
- 组合幻灯片
- 组合 PPT
- 组合 PPTX
- 组合 ODP
- Android
- Java
- Aspose.Slides
description: "轻松合并 PowerPoint（PPT、PPTX）和 OpenDocument（ODP）演示文稿，使用适用于 Android 的 Aspose.Slides for Java，简化您的工作流程。"
---

{{% alert  title="Tip" color="primary" %}} 

您可能想了解 **Aspose 免费在线** [Merger 应用](https://products.aspose.app/slides/merger)。它允许用户在相同格式（PPT 到 PPT，PPTX 到 PPTX 等）合并 PowerPoint 演示文稿，也可以在不同格式（PPT 到 PPTX，PPTX 到 ODP 等）合并演示文稿。

[![todo:image_alt_text](slides-merger.png)](https://products.aspose.app/slides/merger)

{{% /alert %}} 


## **演示文稿合并**

当您将一个演示文稿合并到另一个演示文稿时，实际上是将它们的幻灯片组合成一个单一的演示文稿，以获得一个文件。 

{{% alert title="Info" color="info" %}}

大多数演示文稿程序（PowerPoint 或 OpenOffice）缺乏允许用户以此方式合并演示文稿的功能。 

[**Aspose.Slides for Android via Java**](https://products.aspose.com/slides/androidjava/)，然而，允许您以不同方式合并演示文稿。您可以合并演示文稿的所有形状、样式、文本、格式、批注、动画等，而无需担心质量或数据的丢失。

**另请参阅**

[克隆幻灯片](https://docs.aspose.com/slides/androidjava/clone-slides/).

{{% /alert %}}

### **可以合并的内容**

使用 Aspose.Slides，您可以合并 

* 整个演示文稿。所有演示文稿中的幻灯片都会汇集到一个演示文稿中
* 特定幻灯片。选定的幻灯片会汇集到一个演示文稿中
* 相同格式的演示文稿（如 PPT 到 PPT，PPTX 到 PPTX 等）以及不同格式的演示文稿（如 PPT 到 PPTX，PPTX 到 ODP 等）相互合并。 

{{% alert title="Note" color="warning" %}} 

除了演示文稿，Aspose.Slides 还允许您合并其他文件：

* [图像](https://products.aspose.com/slides/androidjava/merger/image-to-image/)，例如 [JPG 到 JPG](https://products.aspose.com/slides/androidjava/merger/jpg-to-jpg/) 或 [PNG 到 PNG](https://products.aspose.com/slides/androidjava/merger/png-to-png/)
* 文档，例如 [PDF 到 PDF](https://products.aspose.com/slides/androidjava/merger/pdf-to-pdf/) 或 [HTML 到 HTML](https://products.aspose.com/slides/androidjava/merger/html-to-html/)
* 以及不同类型的文件，例如 [图像到 PDF](https://products.aspose.com/slides/androidjava/merger/image-to-pdf/) 或 [JPG 到 PDF](https://products.aspose.com/slides/androidjava/merger/jpg-to-pdf/) 或 [TIFF 到 PDF](https://products.aspose.com/slides/androidjava/merger/tiff-to-pdf/).

{{% /alert %}}

### **合并选项**

您可以应用选项来决定是否

* 输出演示文稿中的每张幻灯片保留独特的样式
* 为输出演示文稿中的所有幻灯片使用统一的特定样式。 

要合并演示文稿，Aspose.Slides 提供了来自 [ISlideCollection](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ISlideCollection) 接口的 [AddClone](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ISlideCollection#addClone-com.aspose.slides.ISlide-) 方法。有多种 `AddClone` 方法的实现，用于定义演示文稿合并过程的参数。每个 Presentation 对象都有一个 [Slides](https://reference.aspose.com/slides/androidjava/com.aspose.slides/Presentation#getSlides--) 集合，因此您可以从希望合并幻灯片的演示文稿中调用 `AddClone` 方法。

`AddClone` 方法返回一个 `ISlide` 对象，它是源幻灯片的克隆。输出演示文稿中的幻灯片只是源幻灯片的副本。因此，您可以对生成的幻灯片进行更改（例如，应用样式、格式选项或布局），而无需担心影响源演示文稿。

## **合并演示文稿** 

Aspose.Slides 提供了 [**AddClone(ISlide)**](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ISlideCollection#addClone-com.aspose.slides.ISlide-) 方法，允许您在保持幻灯片布局和样式的情况下合并幻灯片（默认参数）。

以下 Java 代码演示了如何合并演示文稿：
```java
Presentation pres1 = new Presentation("pres1.pptx");
try {
    Presentation pres2 = new Presentation("pres2.pptx");
    try {
        for(ISlide slide : pres2.getSlides())
        {
            pres1.getSlides().addClone(slide);
        }
    } finally {
        if (pres2 != null) pres2.dispose();
    }
    pres1.save("combined.pptx", SaveFormat.Pptx);
} finally {
    if (pres1 != null) pres1.dispose();
}
```


## **使用幻灯片母版合并演示文稿**

Aspose.Slides 提供了 [**AddClone(ISlide, IMasterSlide, boolean)**](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ISlideCollection#addClone-com.aspose.slides.ISlide-com.aspose.slides.IMasterSlide-boolean-) 方法，允许您在应用幻灯片母版模板的同时合并幻灯片。这样，如果需要，您可以更改输出演示文稿中幻灯片的样式。

以下 Java 代码演示了上述操作：
```java
Presentation pres1 = new Presentation("pres1.pptx");
try {
    Presentation pres2 = new Presentation("pres2.pptx");
    try {
        for(ISlide slide : pres2.getSlides())
        {
            pres1.getSlides().addClone(slide, pres2.getMasters().get_Item(0), true);
        }
    } finally {
        if (pres2 != null) pres2.dispose();
    }
    pres1.save("combined.pptx", SaveFormat.Pptx);
} finally {
    if (pres1 != null) pres1.dispose();
}
```


{{% alert title="Note" color="warning" %}} 

幻灯片母版的布局会自动确定。当无法确定合适的布局时，如果 `AddClone` 方法的 `allowCloneMissingLayout` 布尔参数设为 true，则使用源幻灯片的布局。否则，将抛出 [PptxEditException](https://reference.aspose.com/slides/androidjava/com.aspose.slides/PptxEditException)。

{{% /alert %}}

如果您希望输出演示文稿中的幻灯片使用不同的幻灯片布局，请在合并时改用 [AddClone(ISlide, ILayoutSlide)](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ISlideCollection#addClone-com.aspose.slides.ISlide-com.aspose.slides.ILayoutSlide-) 方法。

## **合并演示文稿中的特定幻灯片**

从多个演示文稿中合并特定幻灯片对于创建自定义幻灯片组非常有用。Aspose.Slides for Android via Java 允许您仅选择并导入所需的幻灯片。该 API 保留原始幻灯片的格式、布局和设计。

以下 Java 代码创建一个新演示文稿，添加来自两个其他演示文稿的标题幻灯片，并将结果保存到文件中：
```java
Presentation presentation = new Presentation();
Presentation presentation1 = new Presentation("presentation1.pptx");
Presentation presentation2 = new Presentation("presentation2.pptx");
try {
    presentation.getSlides().removeAt(0);
    
    ISlide slide1 = getTitleSlide(presentation1);

    if (slide1 != null)
        presentation.getSlides().addClone(slide1);

    ISlide slide2 = getTitleSlide(presentation2);

    if (slide2 != null)
        presentation.getSlides().addClone(slide2);

    presentation.save("combined.pptx", SaveFormat.Pptx);
} finally {
    presentation2.dispose();
    presentation1.dispose();
    presentation.dispose();
}
```

```java
static ISlide getTitleSlide(IPresentation presentation) {
    for (ISlide slide : presentation.getSlides()) {
        if (slide.getLayoutSlide().getLayoutType() == SlideLayoutType.Title) {
            return slide;
        }
    }
    return null;
}
```


## **使用幻灯片布局合并演示文稿**

以下 Java 代码演示了如何在合并演示文稿的幻灯片时应用您首选的幻灯片布局，以获得一个输出演示文稿：
```java
Presentation pres1 = new Presentation("pres1.pptx");
try {
    Presentation pres2 = new Presentation("pres2.pptx");
    try {
        for(ISlide slide : pres2.getSlides())
        {
            pres1.getSlides().addClone(slide, pres2.getLayoutSlides().get_Item(0));
        }
    } finally {
        if (pres2 != null) pres2.dispose();
    }
    pres1.save("combined.pptx", SaveFormat.Pptx);
} finally {
    if (pres1 != null) pres1.dispose();
}
```


## **使用不同幻灯片尺寸合并演示文稿**

{{% alert title="Note" color="warning" %}} 

无法合并具有不同幻灯片尺寸的演示文稿。 

{{% /alert %}}

要合并尺寸不同的两个演示文稿，必须调整其中一个演示文稿的大小，使其尺寸与另一个演示文稿匹配。

以下示例代码演示了上述操作：
```java
Presentation pres1 = new Presentation("pres1.pptx");
try {
    Presentation pres2 = new Presentation("pres2.pptx");
    try {
        pres2.getSlideSize().setSize((float)pres1.getSlideSize().getSize().getWidth(), (float)pres1.getSlideSize().getSize().getHeight(), SlideSizeScaleType.EnsureFit);

        for(ISlide slide : pres2.getSlides())
        {
            pres1.getSlides().addClone(slide);
        }
    } finally {
        if (pres2 != null) pres2.dispose();
    }
    pres1.save("combined.pptx", SaveFormat.Pptx);
} finally {
    if (pres1 != null) pres1.dispose();
}
```


## **将幻灯片合并到演示文稿章节**

以下 Java 代码演示了如何将特定幻灯片合并到演示文稿的某个章节：
```java
Presentation pres1 = new Presentation("pres1.pptx");
try {
    Presentation pres2 = new Presentation("pres2.pptx");
    try {
        for(ISlide slide : pres2.getSlides())
        {
            pres1.getSlides().addClone(slide, pres1.getSections().get_Item(0));
        }
    } finally {
        if (pres2 != null) pres2.dispose();
    }
    pres1.save("combined.pptx", SaveFormat.Pptx);
} finally {
    if (pres1 != null) pres1.dispose();
}
```


该幻灯片将被添加到该章节的末尾。 

{{% alert title="Tip" color="primary" %}}

Aspose 提供了一个 [免费拼贴 Web 应用](https://products.aspose.app/slides/collage)。使用此在线服务，您可以合并 [JPG 到 JPG](https://products.aspose.app/slides/collage/jpg) 或 PNG 到 PNG 图像，创建 [照片网格](https://products.aspose.app/slides/collage/photo-grid) 等。

{{% /alert %}}

## **常见问题**

**合并演示文稿时对幻灯片数量有任何限制吗？**

没有严格的限制。Aspose.Slides 能处理大型文件，但性能取决于文件大小和系统资源。对于非常大的演示文稿，建议使用 64 位 JVM 并分配足够的堆内存。

**我可以合并包含嵌入式视频或音频的演示文稿吗？**

可以，Aspose.Slides 会保留幻灯片中嵌入的多媒体内容，但最终的演示文稿可能会显著增大。

**合并演示文稿时字体会被保留吗？**

是的。只要系统已安装或在源演示文稿中[嵌入](/slides/zh/androidjava/embedded-font/)了相应字体，输出文件中会保留这些字体。