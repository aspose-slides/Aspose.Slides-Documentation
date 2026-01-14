---
title: 在 PHP 中高效合并演示文稿
linktitle: 合并演示文稿
type: docs
weight: 40
url: /zh/php-java/merge-presentation/
keywords:
- 合并 PowerPoint
- 合并 演示文稿
- 合并 幻灯片
- 合并 PPT
- 合并 PPTX
- 合并 ODP
- 组合 PowerPoint
- 组合 演示文稿
- 组合 幻灯片
- 组合 PPT
- 组合 PPTX
- 组合 ODP
- PHP
- Aspose.Slides
description: "轻松合并 PowerPoint (PPT, PPTX) 和 OpenDocument (ODP) 演示文稿，使用 Aspose.Slides for PHP via Java，简化您的工作流程。"
---

## **演示文稿合并**

当您将一个演示文稿合并到另一个时，实际上是将它们的幻灯片合并到一个演示文稿中，以获得一个文件。 

{{% alert title="Info" color="info" %}}

大多数演示文稿程序（PowerPoint 或 OpenOffice）缺乏允许用户以这种方式合并演示文稿的功能。 

[**Aspose.Slides for PHP via Java**](https://products.aspose.com/slides/php-java/)，但是，它允许您以不同方式合并演示文稿。您可以合并演示文稿的所有形状、样式、文本、格式、批注、动画等，而无需担心质量或数据的损失。

**另请参阅**

[克隆幻灯片](/slides/zh/php-java/clone-slides/).

{{% /alert %}}

### **可以合并的内容**

使用 Aspose.Slides，您可以合并 

* 完整的演示文稿。所有演示文稿中的幻灯片都会合并到一个演示文稿中
* 特定的幻灯片。选定的幻灯片会合并到一个演示文稿中
* 相同格式的演示文稿（如 PPT 转 PPT、PPTX 转 PPTX 等）以及不同格式的演示文稿（如 PPT 转 PPTX、PPTX 转 ODP 等）相互合并。 

{{% alert title="Note" color="warning" %}} 

除了演示文稿，Aspose.Slides 还允许您合并其他文件：

* [图像](https://products.aspose.com/slides/php-java/merger/image-to-image/)，例如 [JPG 到 JPG](https://products.aspose.com/slides/php-java/merger/jpg-to-jpg/) 或 [PNG 到 PNG](https://products.aspose.com/slides/php-java/merger/png-to-png/)
* 文档，例如 [PDF 到 PDF](https://products.aspose.com/slides/php-java/merger/pdf-to-pdf/) 或 [HTML 到 HTML](https://products.aspose.com/slides/php-java/merger/html-to-html/)
* 以及两种不同类型的文件，例如 [图像到 PDF](https://products.aspose.com/slides/php-java/merger/image-to-pdf/) 或 [JPG 到 PDF](https://products.aspose.com/slides/php-java/merger/jpg-to-pdf/) 或 [TIFF 到 PDF](https://products.aspose.com/slides/php-java/merger/tiff-to-pdf/)。

{{% /alert %}}

### **合并选项**

您可以应用选项以确定是否

* 输出演示文稿中的每张幻灯片保留独特的样式
* 为输出演示文稿中的所有幻灯片使用相同的特定样式。 

要合并演示文稿，Aspose.Slides 提供了来自 [SlideCollection](https://reference.aspose.com/slides/php-java/aspose.slides/slidecollection/) 类的 [addClone](https://reference.aspose.com/slides/php-java/aspose.slides/slidecollection/addclone/) 方法。有多种 `addClone` 方法的实现可定义演示文稿合并过程的参数。每个 Presentation 对象都有一个 [slide](https://reference.aspose.com/slides/php-java/aspose.slides/presentation/getslides/) 集合，因此您可以从要合并幻灯片的演示文稿中调用 `addClone` 方法。

`addClone` 方法返回一个 `Slide` 对象，它是源幻灯片的克隆。输出演示文稿中的幻灯片只是源幻灯片的副本。因此，您可以对生成的幻灯片进行更改（例如应用样式、格式选项或布局），而无需担心源演示文稿受到影响。 

## **合并演示文稿** 

Aspose.Slides 提供了 [addClone(Slide)](https://reference.aspose.com/slides/php-java/aspose.slides/slidecollection/addclone/) 方法，允许您在保留幻灯片布局和样式的情况下（默认参数）合并幻灯片。

以下 PHP 代码演示了如何合并演示文稿：
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


## **使用幻灯片母版合并演示文稿** 

Aspose.Slides 提供了 [addClone(Slide, MasterSlide, boolean)](https://reference.aspose.com/slides/php-java/aspose.slides/slidecollection/addclone/) 方法，允许您在应用幻灯片母版模板的情况下合并幻灯片。这样，如果需要，您可以更改输出演示文稿中幻灯片的样式。

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


{{% alert title="Note" color="warning" %}} 

幻灯片母版的布局会自动确定。当无法确定合适的布局时，如果 `addClone` 方法的 `allowCloneMissingLayout` 布尔参数设置为 true，则使用源幻灯片的布局。否则，将抛出 [PptxEditException](https://reference.aspose.com/slides/php-java/aspose.slides/PptxEditException)。 

{{% /alert %}}

如果希望输出演示文稿中的幻灯片使用不同的幻灯片布局，请在合并时改用 [addClone(Slide, LayoutSlide)](https://reference.aspose.com/slides/php-java/aspose.slides/slidecollection/addclone/) 方法。

## **从演示文稿中合并特定幻灯片** 

从多个演示文稿中合并特定幻灯片对于创建自定义幻灯片组非常有用。Aspose.Slides for PHP via Java 允许您仅选择并导入所需的幻灯片。该 API 保留原始幻灯片的格式、布局和设计。

以下 PHP 代码创建一个新演示文稿，添加来自两个其他演示文稿的标题幻灯片，并将结果保存为文件：
```php
function getTitleSlide(Presentation $presentation) {
    for ($i = 0; $i < java_values($presentation->getSlides()->size()); $i++) {
        $slide = $presentation->getSlides()->get_Item($i);
        if (java_values($slide->getLayoutSlide()->getLayoutType()) === SlideLayoutType::Title) {
            return $slide;
        }
    }
    return null;
}
```

```php
$presentation = new Presentation();
$presentation1 = new Presentation($folderPath . "presentation1.pptx");
$presentation2 = new Presentation($folderPath . "presentation2.pptx");
try {
    $presentation->getSlides()->removeAt(0);
    
    $slide1 = getTitleSlide($presentation1);

    if ($slide1 != null)
        $presentation->getSlides()->addClone($slide1);

    $slide2 = getTitleSlide($presentation2);

    if ($slide2 != null)
        $presentation->getSlides()->addClone($slide2);

    $presentation->save($folderPath . "combined.pptx", SaveFormat::Pptx);
} finally {
    $presentation2->dispose();
    $presentation1->dispose();
    $presentation->dispose();
}
```


## **使用幻灯片布局合并演示文稿** 

以下 PHP 代码演示了如何在合并演示文稿时为幻灯片应用首选布局，以获得一个输出演示文稿：
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


## **使用不同幻灯片尺寸合并演示文稿** 

{{% alert title="Note" color="warning" %}} 

无法合并尺寸不同的演示文稿。 

{{% /alert %}}

要合并尺寸不同的两个演示文稿，必须调整其中一个演示文稿的尺寸，使其与另一个演示文稿的尺寸匹配。 

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


## **将幻灯片合并到演示文稿章节** 

以下 PHP 代码演示了如何将特定幻灯片合并到演示文稿的某个章节：
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


该幻灯片会添加在章节的末尾。 

## **另请参阅**


Aspose 提供了一个 [免费在线拼图制作器](https://products.aspose.app/slides/collage)。使用此在线服务，您可以合并 [JPG 到 JPG](https://products.aspose.app/slides/collage/jpg) 或 PNG 到 PNG 图像，创建 [照片网格](https://products.aspose.app/slides/collage/photo-grid)，等等。

查看 [Aspose 免费在线合并器](https://products.aspose.app/slides/merger)。它允许您在相同格式（例如 PPT 到 PPT、PPTX 到 PPTX）或不同格式（例如 PPT 到 PPTX、PPTX 到 ODP）之间合并 PowerPoint 演示文稿。

[![Aspose 免费在线合并器](slides-merger.png)](https://products.aspose.app/slides/merger)

## **常见问题** 

**合并演示文稿时对幻灯片数量有任何限制吗？**

没有严格限制。Aspose.Slides 能处理大型文件，但性能取决于文件大小和系统资源。对于非常大的演示文稿，建议使用 64 位 JVM 并分配足够的堆内存。

**我可以合并包含嵌入视频或音频的演示文稿吗？**

可以，Aspose.Slides 会保留幻灯片中嵌入的多媒体内容，但最终的演示文稿可能会显著增大。

**合并演示文稿时字体会被保留吗？**

会。源演示文稿中使用的字体会在输出文件中保留，前提是这些字体已安装在系统上或已 [嵌入](/slides/zh/php-java/embedded-font/)。