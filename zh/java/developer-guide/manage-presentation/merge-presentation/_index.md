---
title: 合并演示文稿
type: docs
weight: 40
url: /zh/java/merge-presentation/
keywords: "合并 PowerPoint, PPTX, PPT, 合并 PowerPoint, 合并演示文稿, Java"
description: "在 Java 中合并或组合 PowerPoint 演示文稿"
---


{{% alert  title="提示" color="primary" %}} 

您可以查看 **Aspose 免费在线** [合并应用程序](https://products.aspose.app/slides/merger)。它允许用户以相同格式合并 PowerPoint 演示文稿（PPT 到 PPT，PPTX 到 PPTX 等）并合并不同格式的演示文稿（PPT 到 PPTX，PPTX 到 ODP 等）。

[![todo:image_alt_text](slides-merger.png)](https://products.aspose.app/slides/merger)

{{% /alert %}} 


## **演示文稿合并**

当您将一个演示文稿合并到另一个演示文稿时，实际上是在单一演示文稿中组合它们的幻灯片以获取一个文件。 

{{% alert title="信息" color="info" %}}

大多数演示程序（PowerPoint 或 OpenOffice）缺乏使用户能够以这种方式组合演示文稿的功能。 

然而，[**Aspose.Slides for Java**](https://products.aspose.com/slides/java/) 允许您以多种方式合并演示文稿。您可以合并演示文稿及其所有形状、样式、文本、格式、评论、动画等，而无需担心质量或数据的损失。 

**另请查看**

[克隆幻灯片](https://docs.aspose.com/slides/java/clone-slides/)。 

{{% /alert %}}

### **可以合并的内容**

使用 Aspose.Slides，您可以合并 

* 整个演示文稿。所有来源演示文稿的幻灯片最终合并为一个演示文稿
* 特定幻灯片。所选幻灯片最终合并为一个演示文稿
* 以相同格式（PPT 到 PPT，PPTX 到 PPTX 等）和不同格式（PPT 到 PPTX，PPTX 到 ODP 等）的演示文稿相互合并。 

{{% alert title="注意" color="warning" %}} 

除了演示文稿，Aspose.Slides 还允许您合并其他文件：

* [图像](https://products.aspose.com/slides/java/merger/image-to-image/)，例如 [JPG 到 JPG](https://products.aspose.com/slides/java/merger/jpg-to-jpg/) 或 [PNG 到 PNG](https://products.aspose.com/slides/java/merger/png-to-png/)
* 文档，例如 [PDF 到 PDF](https://products.aspose.com/slides/java/merger/pdf-to-pdf/) 或 [HTML 到 HTML](https://products.aspose.com/slides/java/merger/html-to-html/)
* 以及两种不同文件，如 [图像到 PDF](https://products.aspose.com/slides/java/merger/image-to-pdf/) 或 [JPG 到 PDF](https://products.aspose.com/slides/java/merger/jpg-to-pdf/) 或 [TIFF 到 PDF](https://products.aspose.com/slides/java/merger/tiff-to-pdf/)。

{{% /alert %}}

### **合并选项**

您可以应用选项以确定是否

* 输出演示文稿中的每个幻灯片保留独特样式
* 输出演示文稿中的所有幻灯片使用特定样式。 

要合并演示文稿，Aspose.Slides 提供了 [AddClone](https://reference.aspose.com/slides/java/com.aspose.slides/ISlideCollection#addClone-com.aspose.slides.ISlide-) 方法（来自 [ISlideCollection](https://reference.aspose.com/slides/java/com.aspose.slides/ISlideCollection) 接口）。有多个实现的 `AddClone` 方法定义了演示文稿合并过程的参数。每个演示文稿对象都有一个 [Slides](https://reference.aspose.com/slides/java/com.aspose.slides/Presentation#getSlides--) 集合，因此您可以从希望合并幻灯片的演示文稿中调用 `AddClone` 方法。 

`AddClone` 方法返回一个 `ISlide` 对象，这是来源幻灯片的克隆。输出演示文稿中的幻灯片只是来自源的幻灯片的副本。因此，您可以对结果幻灯片进行更改（例如，应用样式或格式选项或布局），而不必担心源演示文稿受到影响。 

## **合并演示文稿** 

Aspose.Slides 提供了 [**AddClone(ISlide)**](https://reference.aspose.com/slides/java/com.aspose.slides/ISlideCollection#addClone-com.aspose.slides.ISlide-) 方法，它允许您合并幻灯片，同时幻灯片保留其布局和样式（默认参数）。 

以下 Java 代码展示了如何合并演示文稿：

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

Aspose.Slides 提供了 [**AddClone(ISlide, IMasterSlide, boolean)**](https://reference.aspose.com/slides/java/com.aspose.slides/ISlideCollection#addClone-com.aspose.slides.ISlide-com.aspose.slides.IMasterSlide-boolean-) 方法，它允许您合并幻灯片，同时应用幻灯片母版演示文稿模板。这样，如果必要，您可以更改输出演示文稿中幻灯片的样式。 

以下 Java 代码演示了所述操作：

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

幻灯片母版的幻灯片布局会自动确定。当无法确定合适的布局时，如果 `AddClone` 方法的 `allowCloneMissingLayout` 布尔参数设为 true，则使用源幻灯片的布局。否则，将抛出 [PptxEditException](https://reference.aspose.com/slides/java/com.aspose.slides/PptxEditException) 。 

{{% /alert %}}

如果您希望输出演示文稿中的幻灯片具有不同的幻灯片布局，请在合并时使用 [AddClone(ISlide, ILayoutSlide)](https://reference.aspose.com/slides/java/com.aspose.slides/ISlideCollection#addClone-com.aspose.slides.ISlide-com.aspose.slides.ILayoutSlide-) 方法。 

## **从演示文稿中合并特定幻灯片**

以下 Java 代码展示了如何选择并组合来自不同演示文稿的特定幻灯片以获取一个输出演示文稿：

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

## **使用幻灯片布局合并演示文稿**

以下 Java 代码展示了如何在合并演示文稿的同时应用您喜欢的幻灯片布局，以获取一个输出演示文稿：

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

## **合并具有不同幻灯片大小的演示文稿**

{{% alert title="注意" color="warning" %}} 

您无法合并具有不同幻灯片大小的演示文稿。 

{{% /alert %}}

要合并两个具有不同幻灯片大小的演示文稿，您必须调整其中一个演示文稿的大小，以使其与另一个演示文稿的大小匹配。 

以下示例代码演示了所述操作：

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

## **将幻灯片合并到演示文稿部分**

以下 Java 代码展示了如何将特定幻灯片合并到演示文稿的某个部分：

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

幻灯片会添加到该部分的末尾。 

{{% alert title="提示" color="primary" %}}

Aspose 提供了一个 [免费的拼贴网页应用](https://products.aspose.app/slides/collage)。使用此在线服务，您可以合并 [JPG 到 JPG](https://products.aspose.app/slides/collage/jpg) 或 PNG 到 PNG 图像，创建 [照片网格](https://products.aspose.app/slides/collage/photo-grid) 等等。 

{{% /alert %}}