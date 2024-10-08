---
title: 合并演示文稿
type: docs
weight: 40
url: /php-java/merge-presentation/
keywords: "合并 PowerPoint, PPTX, PPT, 结合 PowerPoint, 合并演示文稿, 结合演示文稿, Java"
description: "合并或结合 PowerPoint 演示文稿"
---

{{% alert  title="提示" color="primary" %}} 

您可能想查看 **Aspose 免费在线** [合并应用](https://products.aspose.app/slides/merger)。它允许用户合并相同格式的 PowerPoint 演示文稿（PPT 转 PPT，PPTX 转 PPTX 等）以及不同格式的演示文稿（PPT 转 PPTX，PPTX 转 ODP 等）。

[![todo:image_alt_text](slides-merger.png)](https://products.aspose.app/slides/merger)

{{% /alert %}} 

## **演示文稿合并**

当您将一个演示文稿合并到另一个演示文稿时，实际上是在单个演示文稿中组合它们的幻灯片，以获得一个文件。 

{{% alert title="信息" color="info" %}}

大多数演示文稿程序（PowerPoint 或 OpenOffice）缺乏允许用户以这种方式结合演示文稿的功能。 

然而，[**Aspose.Slides for PHP via Java**](https://products.aspose.com/slides/php-java/) 允许您以不同的方式合并演示文稿。您可以合并包含所有形状、样式、文本、格式、注释、动画等的演示文稿，而无需担心质量或数据的损失。

**另见**

[克隆幻灯片](https://docs.aspose.com/slides/php-java/clone-slides/)。

{{% /alert %}}

### **可以合并的内容**

使用 Aspose.Slides，您可以合并 

* 整个演示文稿。所有来自演示文稿的幻灯片最终会合并到一个演示文稿中。
* 特定幻灯片。选定的幻灯片最终会合并到一个演示文稿中。
* 同一种格式（PPT 转 PPT，PPTX 转 PPTX 等）和不同格式（PPT 转 PPTX，PPTX 转 ODP 等）。

{{% alert title="注意" color="warning" %}} 

除了演示文稿，Aspose.Slides 还允许您合并其他文件：

* [图像](https://products.aspose.com/slides/php-java/merger/image-to-image/)，如 [JPG 转 JPG](https://products.aspose.com/slides/php-java/merger/jpg-to-jpg/) 或 [PNG 转 PNG](https://products.aspose.com/slides/php-java/merger/png-to-png/)
* 文档，如 [PDF 转 PDF](https://products.aspose.com/slides/php-java/merger/pdf-to-pdf/) 或 [HTML 转 HTML](https://products.aspose.com/slides/php-java/merger/html-to-html/)
* 以及两个不同的文件，如 [图像转 PDF](https://products.aspose.com/slides/php-java/merger/image-to-pdf/) 或 [JPG 转 PDF](https://products.aspose.com/slides/php-java/merger/jpg-to-pdf/) 或 [TIFF 转 PDF](https://products.aspose.com/slides/php-java/merger/tiff-to-pdf/)。

{{% /alert %}}

### **合并选项**

您可以应用选项以决定是否

* 输出演示文稿中的每个幻灯片保留独特的样式。
* 输出演示文稿中的所有幻灯片使用特定样式。

为了合并演示文稿，Aspose.Slides 提供了 [AddClone](https://reference.aspose.com/slides/php-java/aspose.slides/ISlideCollection#addClone-com.aspose.slides.ISlide-) 方法（来自 [ISlideCollection](https://reference.aspose.com/slides/php-java/aspose.slides/ISlideCollection) 接口）。有多种实现的 `AddClone` 方法定义了演示文稿合并过程的参数。每个演示文稿对象都有一个 [Slides](https://reference.aspose.com/slides/php-java/aspose.slides/Presentation#getSlides--) 集合，因此您可以从希望合并幻灯片的演示文稿中调用 `AddClone` 方法。

`AddClone` 方法返回一个 `ISlide` 对象，它是源幻灯片的克隆。输出演示文稿中的幻灯片只是源幻灯片的副本。因此，您可以在不担心源演示文稿受到影响的情况下，对结果幻灯片进行更改（例如，应用样式或格式选项或布局）。 

## **合并演示文稿** 

Aspose.Slides 提供了 [**AddClone(ISlide)**](https://reference.aspose.com/slides/php-java/aspose.slides/ISlideCollection#addClone-com.aspose.slides.ISlide-) 方法，允许您合并幻灯片，同时保持幻灯片的布局和样式（默认参数）。

以下 PHP 代码展示了如何合并演示文稿：

```php
  $pres1 = new Presentation("pres1.pptx");
  try {
    $pres2 = new Presentation("pres2.pptx");
    try {
      foreach($pres2->getSlides() as $slide) {
        $pres1->getSlides()->addClone($slide);
      }
    } finally {
      if (!java_is_null($pres2)) {
        $pres2->dispose();
      }
    }
    $pres1->save("combined.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres1)) {
      $pres1->dispose();
    }
  }
```

## **与幻灯片母版合并演示文稿**

Aspose.Slides 提供了 [**AddClone(ISlide, IMasterSlide, boolean)**](https://reference.aspose.com/slides/php-java/aspose.slides/ISlideCollection#addClone-com.aspose.slides.ISlide-com.aspose.slides.IMasterSlide-boolean-) 方法，允许您合并幻灯片，同时应用幻灯片母版演示文稿模板。如果需要，您可以对输出演示文稿中的幻灯片样式进行更改。

以下代码演示了上述操作：

```php
  $pres1 = new Presentation("pres1.pptx");
  try {
    $pres2 = new Presentation("pres2.pptx");
    try {
      foreach($pres2->getSlides() as $slide) {
        $pres1->getSlides()->addClone($slide, $pres2->getMasters()->get_Item(0), true);
      }
    } finally {
      if (!java_is_null($pres2)) {
        $pres2->dispose();
      }
    }
    $pres1->save("combined.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres1)) {
      $pres1->dispose();
    }
  }
```

{{% alert title="注意" color="warning" %}} 

幻灯片母版的幻灯片布局是自动确定的。当无法确定适当的布局时，如果 `AddClone` 方法的 `allowCloneMissingLayout` 布尔参数设置为 true，则使用来源幻灯片的布局。否则，将抛出 [PptxEditException](https://reference.aspose.com/slides/php-java/aspose.slides/PptxEditException)。

{{% /alert %}}

如果您希望输出演示文稿中的幻灯片具有不同的幻灯片布局，在合并时请使用 [AddClone(ISlide, ILayoutSlide)](https://reference.aspose.com/slides/php-java/aspose.slides/ISlideCollection#addClone-com.aspose.slides.ISlide-com.aspose.slides.ILayoutSlide-) 方法。

## **从演示文稿中合并特定幻灯片**

以下 PHP 代码展示了如何选择和组合来自不同演示文稿的特定幻灯片，以获取一个输出演示文稿：

```php
  $pres1 = new Presentation("pres1.pptx");
  try {
    $pres2 = new Presentation("pres2.pptx");
    try {
      foreach($pres2->getSlides() as $slide) {
        $pres1->getSlides()->addClone($slide, $pres2->getLayoutSlides()->get_Item(0));
      }
    } finally {
      if (!java_is_null($pres2)) {
        $pres2->dispose();
      }
    }
    $pres1->save("combined.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres1)) {
      $pres1->dispose();
    }
  }
```

## **使用幻灯片布局合并演示文稿**

以下 PHP 代码展示了如何合并演示文稿中的幻灯片，同时应用您偏好的幻灯片布局，以获取一个输出演示文稿：

```php
  $pres1 = new Presentation("pres1.pptx");
  try {
    $pres2 = new Presentation("pres2.pptx");
    try {
      foreach($pres2->getSlides() as $slide) {
        $pres1->getSlides()->addClone($slide, $pres2->getLayoutSlides()->get_Item(0));
      }
    } finally {
      if (!java_is_null($pres2)) {
        $pres2->dispose();
      }
    }
    $pres1->save("combined.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres1)) {
      $pres1->dispose();
    }
  }
```

## **合并具有不同幻灯片大小的演示文稿**

{{% alert title="注意" color="warning" %}} 

您无法合并具有不同幻灯片大小的演示文稿。 

{{% /alert %}}

要合并两份具有不同幻灯片大小的演示文稿，您必须调整其中一份演示文稿的大小，以使其与另一份演示文稿的大小匹配。

以下示例代码演示了上述操作：

```php
  $pres1 = new Presentation("pres1.pptx");
  try {
    $pres2 = new Presentation("pres2.pptx");
    try {
      $pres2->getSlideSize()->setSize($pres1->getSlideSize()->getSize()->getWidth(), $pres1->getSlideSize()->getSize()->getHeight(), SlideSizeScaleType::EnsureFit);
      foreach($pres2->getSlides() as $slide) {
        $pres1->getSlides()->addClone($slide);
      }
    } finally {
      if (!java_is_null($pres2)) {
        $pres2->dispose();
      }
    }
    $pres1->save("combined.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres1)) {
      $pres1->dispose();
    }
  }
```

## **将幻灯片合并到演示文稿部分**

以下 PHP 代码展示了如何将特定幻灯片合并到演示文稿中的某一部分：

```php
  $pres1 = new Presentation("pres1.pptx");
  try {
    $pres2 = new Presentation("pres2.pptx");
    try {
      foreach($pres2->getSlides() as $slide) {
        $pres1->getSlides()->addClone($slide, $pres1->getSections()->get_Item(0));
      }
    } finally {
      if (!java_is_null($pres2)) {
        $pres2->dispose();
      }
    }
    $pres1->save("combined.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres1)) {
      $pres1->dispose();
    }
  }
```

幻灯片将被添加到该部分的末尾。 

{{% alert title="提示" color="primary" %}}

Aspose 提供了一个 [免费的拼贴网页应用](https://products.aspose.app/slides/collage)。使用此在线服务，您可以合并 [JPG 转 JPG](https://products.aspose.app/slides/collage/jpg) 或 PNG 转 PNG 图像，创建 [照片网格](https://products.aspose.app/slides/collage/photo-grid) 等。 

{{% /alert %}}