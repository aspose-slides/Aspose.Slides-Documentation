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
description: "轻松使用 Aspose.Slides for Android via Java 合并 PowerPoint (PPT, PPTX) 和 OpenDocument (ODP) 演示文稿，简化工作流。"
---

{{% alert title="提示" color="primary" %}} 

您可能想查看 **Aspose 免费在线** [Merger app](https://products.aspose.app/slides/merger)。它允许用户在相同格式（PPT 到 PPT、PPTX 到 PPTX 等）合并 PowerPoint 演示文稿，也可以在不同格式（PPT 到 PPTX、PPTX 到 ODP 等）合并演示文稿。

[![todo:image_alt_text](slides-merger.png)](https://products.aspose.app/slides/merger)

{{% /alert %}} 


## **演示文稿合并**

当您将一个演示文稿合并到另一个时，实际上是将它们的幻灯片合并到一个演示文稿中，从而得到一个文件。 

{{% alert title="信息" color="info" %}}

大多数演示文稿程序（PowerPoint 或 OpenOffice）缺少允许用户以这种方式合并演示文稿的功能。 

[**Aspose.Slides for Android via Java**](https://products.aspose.com/slides/androidjava/)，然而，它允许您以不同方式合并演示文稿。您可以合并演示文稿的所有形状、样式、文本、格式、批注、动画等，而无需担忧质量或数据的丢失。

**另请参见**

[克隆幻灯片](https://docs.aspose.com/slides/androidjava/clone-slides/).

{{% /alert %}} 


### **可以合并的内容**

使用 Aspose.Slides，您可以合并 
* 整个演示文稿。所有演示文稿中的幻灯片合并到一个演示文稿中
* 指定幻灯片。选定的幻灯片合并到一个演示文稿中
* 同一格式的演示文稿（如 PPT 到 PPT、PPTX 到 PPTX 等）以及不同格式的演示文稿（如 PPT 到 PPTX、PPTX 到 ODP 等）相互合并。 

{{% alert title="注意" color="warning" %}} 

除了演示文稿，Aspose.Slides 还允许您合并其他文件：

* [图片](https://products.aspose.com/slides/androidjava/merger/image-to-image/)，例如 [JPG 到 JPG](https://products.aspose.com/slides/androidjava/merger/jpg-to-jpg/) 或 [PNG 到 PNG](https://products.aspose.com/slides/androidjava/merger/png-to-png/)
* 文档，例如 [PDF 到 PDF](https://products.aspose.com/slides/androidjava/merger/pdf-to-pdf/) 或 [HTML 到 HTML](https://products.aspose.com/slides/androidjava/merger/html-to-html/)
* 以及两种不同的文件，例如 [图片转 PDF](https://products.aspose.com/slides/androidjava/merger/image-to-pdf/) 或 [JPG 转 PDF](https://products.aspose.com/slides/androidjava/merger/jpg-to-pdf/) 或 [TIFF 转 PDF](https://products.aspose.com/slides/androidjava/merger/tiff-to-pdf/)。

{{% /alert %}}

### **合并选项**

您可以应用以下选项来决定是否
* 输出演示文稿中的每一张幻灯片保留唯一的样式
* 为输出演示文稿中的所有幻灯片使用相同的样式。 

要合并演示文稿，Aspose.Slides 提供了来自 [ISlideCollection](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ISlideCollection) 接口的 [AddClone](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ISlideCollection#addClone-com.aspose.slides.ISlide-) 方法。有几种 `AddClone` 方法的实现，用于定义演示文稿合并过程的参数。每个 Presentation 对象都有一个 [Slides](https://reference.aspose.com/slides/androidjava/com.aspose.slides/Presentation#getSlides--) 集合，因此您可以在要合并幻灯片的演示文稿上调用 `AddClone` 方法。

`AddClone` 方法返回一个 `ISlide` 对象，即源幻灯片的克隆。输出演示文稿中的幻灯片只是源幻灯片的副本。因此，您可以对生成的幻灯片进行更改（例如，应用样式、格式选项或布局），而无需担心源演示文稿受到影响。

## **合并演示文稿** 

Aspose.Slides 提供了 [**AddClone(ISlide)**](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ISlideCollection#addClone-com.aspose.slides.ISlide-) 方法，允许您在保持幻灯片布局和样式（默认参数）的情况下合并幻灯片。

此 Java 代码演示了如何合并演示文稿：
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


## **使用母版幻灯片合并演示文稿**

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


{{% alert title="注意" color="warning" %}} 

幻灯片母版的布局会自动确定。当无法确定合适的布局时，如果 `AddClone` 方法的 `allowCloneMissingLayout` 布尔参数设置为 true，则使用源幻灯片的布局。否则，将抛出 [PptxEditException](https://reference.aspose.com/slides/androidjava/com.aspose.slides/PptxEditException)。

{{% /alert %}}

如果您希望输出演示文稿中的幻灯片使用不同的幻灯片布局，请在合并时改用 [AddClone(ISlide, ILayoutSlide)](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ISlideCollection#addClone-com.aspose.slides.ISlide-com.aspose.slides.ILayoutSlide-) 方法。

## **从演示文稿中合并特定幻灯片**

从多个演示文稿中合并特定幻灯片对于创建自定义幻灯片组非常有用。Aspose.Slides for Android via Java 允许您选择并导入所需的幻灯片。API 能够保留原始幻灯片的格式、布局和设计。

以下 Java 代码创建一个新演示文稿，从另外两个演示文稿中添加标题幻灯片，并将结果保存为文件：
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

此 Java 代码展示了如何在合并演示文稿的幻灯片时应用您首选的幻灯片布局，以获得一个输出演示文稿：
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

{{% alert title="注意" color="warning" %}} 

无法合并具有不同幻灯片尺寸的演示文稿。

{{% /alert %}}

要合并两个尺寸不同的演示文稿，必须调整其中一个演示文稿的尺寸，使其与另一个演示文稿的尺寸匹配。

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

以下 Java 代码展示了如何将特定幻灯片合并到演示文稿的某个章节：
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


该幻灯片会被添加到该章节的末尾。 

{{% alert title="提示" color="primary" %}}

Aspose 提供了一个 [免费拼贴 Web 应用](https://products.aspose.app/slides/collage)。使用此在线服务，您可以合并 [JPG 到 JPG](https://products.aspose.app/slides/collage/jpg) 或 PNG 到 PNG 的图片，创建 [照片网格](https://products.aspose.app/slides/collage/photo-grid) 等。

{{% /alert %}}

## **常见问题**

**合并演示文稿时对幻灯片数量有任何限制吗？**

没有严格的限制。Aspose.Slides 能够处理大型文件，但性能取决于文件大小和系统资源。对于非常大的演示文稿，建议使用 64 位 JVM 并分配足够的堆内存。

**我可以合并包含嵌入式视频或音频的演示文稿吗？**

可以，Aspose.Slides 会保留幻灯片中嵌入的多媒体内容，但最终的演示文稿可能会显著增大。

**合并演示文稿时字体会被保留吗？**

会。只要系统已安装或在源演示文稿中 [已嵌入](/slides/zh/androidjava/embedded-font/)，来源演示文稿使用的字体将在输出文件中得到保留。