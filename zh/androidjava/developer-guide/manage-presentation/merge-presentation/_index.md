---
title: 合并演示文稿
type: docs
weight: 40
url: /androidjava/merge-presentation/
keywords: "合并PowerPoint, PPTX, PPT, 组合PowerPoint, 合并演示, 组合演示, Java"
description: "在Java中合并或组合PowerPoint演示文稿"
---


{{% alert  title="提示" color="primary" %}} 

您可能想查看 **Aspose免费在线** [合并应用](https://products.aspose.app/slides/merger)。它允许人们以相同格式合并PowerPoint演示文稿（PPT到PPT，PPTX到PPTX等），并以不同格式合并演示文稿（PPT到PPTX，PPTX到ODP等）。

[![todo:image_alt_text](slides-merger.png)](https://products.aspose.app/slides/merger)

{{% /alert %}} 


## **演示文稿合并**

当您将一个演示文稿合并到另一个演示文稿时，实际上是将它们的幻灯片合并到一个演示文稿中，从而获得一个文件。 

{{% alert title="信息" color="info" %}}

大多数演示程序（PowerPoint或OpenOffice）没有允许用户以这种方式组合演示文稿的功能。 

然而，[**Aspose.Slides for Android via Java**](https://products.aspose.com/slides/androidjava/)允许您以不同的方式合并演示文稿。您可以合并包含所有形状、样式、文本、格式、评论、动画等的演示文稿，而不必担心质量或数据的损失。

**另请参见**

[克隆幻灯片](https://docs.aspose.com/slides/androidjava/clone-slides/)。

{{% /alert %}}

### **可以合并的内容**

使用Aspose.Slides，您可以合并 

* 整个演示文稿。所有幻灯片将来自演示文稿合并到一个演示文稿中
* 特定幻灯片。选定的幻灯片将合并到一个演示文稿中
* 以一种格式（PPT到PPT，PPTX到PPTX等）和以不同格式（PPT到PPTX，PPTX到ODP等）合并演示文稿。 

{{% alert title="注意" color="warning" %}} 

除了演示文稿，Aspose.Slides还允许您合并其他文件：

* [图像](https://products.aspose.com/slides/androidjava/merger/image-to-image/)，如 [JPG到JPG](https://products.aspose.com/slides/androidjava/merger/jpg-to-jpg/) 或 [PNG到PNG](https://products.aspose.com/slides/androidjava/merger/png-to-png/)
* 文档，如 [PDF到PDF](https://products.aspose.com/slides/androidjava/merger/pdf-to-pdf/) 或 [HTML到HTML](https://products.aspose.com/slides/androidjava/merger/html-to-html/)
* 以及两个不同的文件，如 [图像到PDF](https://products.aspose.com/slides/androidjava/merger/image-to-pdf/) 或 [JPG到PDF](https://products.aspose.com/slides/androidjava/merger/jpg-to-pdf/) 或 [TIFF到PDF](https://products.aspose.com/slides/androidjava/merger/tiff-to-pdf/)。

{{% /alert %}}

### **合并选项**

您可以应用选项，以确定

* 输出演示文稿中的每个幻灯片是否保留独特的样式
* 是否对输出演示文稿中的所有幻灯片使用特定样式。 

要合并演示文稿，Aspose.Slides提供 [AddClone](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ISlideCollection#addClone-com.aspose.slides.ISlide-) 方法（来自 [ISlideCollection](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ISlideCollection) 接口）。`AddClone`方法有几种实现，定义了演示文稿合并过程的参数。每个Presentation对象都有一个 [Slides](https://reference.aspose.com/slides/androidjava/com.aspose.slides/Presentation#getSlides--) 集合，因此您可以从要合并幻灯片的演示文稿中调用`AddClone`方法。

`AddClone`方法返回一个`ISlide`对象，它是源幻灯片的克隆。输出演示文稿中的幻灯片只是源幻灯片的副本。因此，您可以对结果幻灯片进行更改（例如，应用样式或格式选项或布局），而不必担心源演示文稿受到影响。 

## **合并演示文稿** 

Aspose.Slides提供 [**AddClone(ISlide)**](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ISlideCollection#addClone-com.aspose.slides.ISlide-) 方法，允许您合并幻灯片，同时幻灯片保留其布局和样式（默认参数）。

以下Java代码演示了如何合并演示文稿：

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

## **带幻灯片母版的合并演示文稿**

Aspose.Slides提供 [**AddClone(ISlide, IMasterSlide, boolean)**](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ISlideCollection#addClone-com.aspose.slides.ISlide-com.aspose.slides.IMasterSlide-boolean-) 方法，允许您合并幻灯片，同时应用幻灯片母版演示文稿模板。这样，如果需要，您可以更改输出演示文稿中幻灯片的样式。

以下Java代码演示了上述操作：

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

幻灯片母版的幻灯片布局是自动确定的。当无法确定合适的布局时，如果`AddClone`方法的`allowCloneMissingLayout`布尔参数设置为true，则使用源幻灯片的布局。否则，将抛出[PptxEditException](https://reference.aspose.com/slides/androidjava/com.aspose.slides/PptxEditException)。

{{% /alert %}}

如果您希望输出演示文稿中的幻灯片具有不同的幻灯片布局，请在合并时使用 [AddClone(ISlide, ILayoutSlide)](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ISlideCollection#addClone-com.aspose.slides.ISlide-com.aspose.slides.ILayoutSlide-) 方法。

## **从演示文稿合并特定幻灯片**

以下Java代码演示了如何选择和合并来自不同演示文稿的特定幻灯片，以获得一个输出演示文稿：

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

## **带幻灯片布局合并演示文稿**

以下Java代码演示了如何合并来自演示文稿的幻灯片，同时将您首选的幻灯片布局应用于它们，以获得一个输出演示文稿：

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

## **合并不同幻灯片尺寸的演示文稿**

{{% alert title="注意" color="warning" %}} 

您不能合并不同幻灯片尺寸的演示文稿。 

{{% /alert %}}

要合并两份不同幻灯片尺寸的演示文稿，您必须调整其中一份演示文稿的尺寸，以匹配另一份演示文稿的尺寸。 

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

## **将幻灯片合并到演示文稿部分**

以下Java代码演示了如何将特定幻灯片合并到演示文稿中的某个部分：

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

幻灯片被添加到该部分的末尾。 

{{% alert title="提示" color="primary" %}}

Aspose提供了一个 [免费的拼贴网页应用](https://products.aspose.app/slides/collage)。使用此在线服务，您可以合并 [JPG到JPG](https://products.aspose.app/slides/collage/jpg) 或 PNG到PNG图像，创建 [照片网格](https://products.aspose.app/slides/collage/photo-grid) 等等。 

{{% /alert %}}