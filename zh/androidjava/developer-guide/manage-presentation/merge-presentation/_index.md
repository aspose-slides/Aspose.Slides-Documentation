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
description: "使用 Aspose.Slides for Android via Java，轻松合并 PowerPoint（PPT、PPTX）和 OpenDocument（ODP）演示文稿，简化工作流程。"
---

{{% alert  title="Tip" color="primary" %}} 

您可能想查看 **Aspose 免费在线** [Merger app](https://products.aspose.app/slides/merger)。它允许用户在相同格式（PPT 到 PPT，PPTX 到 PPTX，等等）以及不同格式（PPT 到 PPTX，PPTX 到 ODP，等等）之间合并 PowerPoint 演示文稿。

[![todo:image_alt_text](slides-merger.png)](https://products.aspose.app/slides/merger)

{{% /alert %}} 


## **演示文稿合并**

当您将一个演示文稿合并到另一个演示文稿时，实际上是将它们的幻灯片合并到一个演示文稿中，以得到一个文件。 

{{% alert title="Info" color="info" %}}

大多数演示文稿程序（PowerPoint 或 OpenOffice）缺少允许用户以这种方式合并演示文稿的功能。 

但是，[**Aspose.Slides for Android via Java**](https://products.aspose.com/slides/androidjava/)，可以让您以不同方式合并演示文稿。您可以合并包含所有形状、样式、文本、格式、批注、动画等的演示文稿，而无需担心质量或数据的损失。

**另见**
[Clone Slides](https://docs.aspose.com/slides/androidjava/clone-slides/).

{{% /alert %}}

### **可以合并的内容**

使用 Aspose.Slides，您可以合并 

* 整个演示文稿。所有来自这些演示文稿的幻灯片将汇总到一个演示文稿中
* 特定幻灯片。选定的幻灯片将汇总到一个演示文稿中
* 同一格式的演示文稿（PPT 到 PPT，PPTX 到 PPTX，等等）以及不同格式的演示文稿（PPT 到 PPTX，PPTX 到 ODP，等等）相互合并。 

### **合并选项**

您可以应用选项来决定是否

* 输出演示文稿中的每张幻灯片保留唯一的样式
* 为输出演示文稿中的所有幻灯片使用特定样式。 

要合并演示文稿，Aspose.Slides 提供了 [AddClone](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ISlideCollection#addClone-com.aspose.slides.ISlide-) 方法（来自 [ISlideCollection](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ISlideCollection) 接口）。`AddClone` 方法有多种实现形式，用于定义演示文稿合并过程的参数。每个 Presentation 对象都有一个 [Slides](https://reference.aspose.com/slides/androidjava/com.aspose.slides/Presentation#getSlides--) 集合，因此您可以从要合并幻灯片的演示文稿中调用 `AddClone` 方法。

`AddClone` 方法返回一个 `ISlide` 对象，即源幻灯片的克隆。输出演示文稿中的幻灯片仅是源幻灯片的副本。因此，您可以对生成的幻灯片进行更改（例如应用样式、格式选项或布局），而无需担心影响源演示文稿。 

## **合并演示文稿** 

Aspose.Slides 提供了 [**AddClone(ISlide)**](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ISlideCollection#addClone-com.aspose.slides.ISlide-) 方法，允许您在保留幻灯片布局和样式（默认参数）的情况下合并幻灯片。

此 Java 代码展示了如何合并演示文稿：
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

Aspose.Slides 提供了 [**AddClone(ISlide, IMasterSlide, boolean)**](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ISlideCollection#addClone-com.aspose.slides.ISlide-com.aspose.slides.IMasterSlide-boolean-) 方法，允许您在应用幻灯片母版模板的情况下合并幻灯片。这样，必要时您可以更改输出演示文稿中幻灯片的样式。

此 Java 代码演示了上述操作：
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

幻灯片母版的布局会自动确定。如果无法确定合适的布局，并且 `AddClone` 方法的 `allowCloneMissingLayout` 布尔参数设置为 true，则使用源幻灯片的布局。否则，将抛出 [PptxEditException](https://reference.aspose.com/slides/androidjava/com.aspose.slides/PptxEditException)。

{{% /alert %}}

如果希望输出演示文稿中的幻灯片使用不同的布局，请在合并时改用 [AddClone(ISlide, ILayoutSlide)](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ISlideCollection#addClone-com.aspose.slides.ISlide-com.aspose.slides.ILayoutSlide-) 方法。

## **从演示文稿中合并特定幻灯片**

从多个演示文稿中合并特定幻灯片对于创建自定义幻灯片组非常有用。Aspose.Slides for Android via Java 允许您仅选择并导入所需的幻灯片。API 能够保留原始幻灯片的格式、布局和设计。

下面的 Java 代码创建了一个新演示文稿，从两个其他演示文稿中添加标题幻灯片，并将结果保存为文件：
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

此 Java 代码展示了如何在合并演示文稿时为幻灯片应用您偏好的布局，从而获得一个输出演示文稿：
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

您无法合并尺寸不同的演示文稿。 

{{% /alert %}}

要合并 2 个尺寸不同的演示文稿，必须调整其中一个的尺寸，使其与另一个演示文稿的尺寸匹配。 

此示例代码演示了上述操作：
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

此 Java 代码展示了如何将特定幻灯片合并到演示文稿的某个章节：
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


该幻灯片会被添加到章节的末尾。 

{{% alert title="Tip" color="primary" %}}

Aspose 提供了一个 [FREE Collage web app](https://products.aspose.app/slides/collage)。使用此在线服务，您可以合并 [JPG to JPG](https://products.aspose.app/slides/collage/jpg) 或 PNG to PNG 图像，创建 [photo grids](https://products.aspose.app/slides/collage/photo-grid)，等等。 

{{% /alert %}}

## **常见问题**

**合并演示文稿时幻灯片数量是否有限制？**

没有严格的限制。Aspose.Slides 能处理大文件，但性能取决于文件大小和系统资源。对于非常大的演示文稿，建议使用 64 位 JVM 并分配足够的堆内存。

**我可以合并包含嵌入式视频或音频的演示文稿吗？**

可以，Aspose.Slides 会保留幻灯片中嵌入的多媒体内容，但最终的演示文稿文件可能会显著增大。

**合并演示文稿时字体会被保留吗？**

会。只要系统已安装或已 [embedded](/slides/zh/androidjava/embedded-font/) 的源演示文稿使用的字体，将在输出文件中得到保留。