---
title: 用PHP高效合并演示文稿
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
- 合并 PowerPoint
- 合并 演示文稿
- 合并 幻灯片
- 合并 PPT
- 合并 PPTX
- 合并 ODP
- PHP
- Aspose.Slides
description: "使用 Aspose.Slides for PHP via Java，轻松合并 PowerPoint (PPT、PPTX) 和 OpenDocument (ODP) 演示文稿，简化工作流程。"
---

## **演示文稿合并**

当您将一个演示文稿合并到另一个演示文稿时，实际上是将它们的幻灯片组合到一个演示文稿中，以获得一个文件。

{{% alert title="Info" color="info" %}}

大多数演示文稿程序（PowerPoint 或 OpenOffice）缺少允许用户以这种方式合并演示文稿的功能。

[**Aspose.Slides for PHP via Java**](https://products.aspose.com/slides/php-java/)，则允许您以不同方式合并演示文稿。您可以合并演示文稿及其所有形状、样式、文本、格式、批注、动画等，而无需担心质量或数据的丢失。

**另请参见**

[克隆幻灯片](https://docs.aspose.com/slides/php-java/clone-slides/).

{{% /alert %}}

### **可以合并的内容**

使用 Aspose.Slides，您可以合并

* 整个演示文稿。所有演示文稿中的幻灯片最终出现在同一个演示文稿中  
* 指定的幻灯片。选中的幻灯片出现在同一个演示文稿中  
* 相同格式的演示文稿（PPT 转 PPT、PPTX 转 PPTX 等）以及不同格式的演示文稿（PPT 转 PPTX、PPTX 转 ODP 等），相互之间进行合并。

{{% alert title="Note" color="warning" %}} 

除了演示文稿，Aspose.Slides 还允许您合并其他文件：

* [图像](https://products.aspose.com/slides/php-java/merger/image-to-image/)，例如 [JPG 转 JPG](https://products.aspose.com/slides/php-java/merger/jpg-to-jpg/) 或 [PNG 转 PNG](https://products.aspose.com/slides/php-java/merger/png-to-png/)  
* 文档，例如 [PDF 转 PDF](https://products.aspose.com/slides/php-java/merger/pdf-to-pdf/) 或 [HTML 转 HTML](https://products.aspose.com/slides/php-java/merger/html-to-html/)  
* 以及两种不同类型的文件，例如 [图像转 PDF](https://products.aspose.com/slides/php-java/merger/image-to-pdf/)、[JPG 转 PDF](https://products.aspose.com/slides/php-java/merger/jpg-to-pdf/) 或 [TIFF 转 PDF](https://products.aspose.com/slides/php-java/merger/tiff-to-pdf/)。

{{% /alert %}}

### **合并选项**

您可以应用以下选项来决定是否

* 输出演示文稿中的每一张幻灯片保留唯一的样式  
* 所有幻灯片使用统一的样式。

要合并演示文稿，Aspose.Slides 提供了 [AddClone](https://reference.aspose.com/slides/php-java/aspose.slides/ISlideCollection#addClone-com.aspose.slides.ISlide-) 方法（来自 [ISlideCollection](https://reference.aspose.com/slides/php-java/aspose.slides/ISlideCollection) 接口）。`AddClone` 方法有多种实现形式，可定义演示文稿合并过程的参数。每个 Presentation 对象都有一个 [Slides](https://reference.aspose.com/slides/php-java/aspose.slides/Presentation#getSlides--) 集合，您可以从目标演示文稿调用 `AddClone` 方法以合并幻灯片。

`AddClone` 方法返回一个 `ISlide` 对象，该对象是源幻灯片的克隆。输出演示文稿中的幻灯片仅是源幻灯片的复制。因此，您可以对生成的幻灯片进行更改（例如应用样式、格式选项或布局），而无需担心源演示文稿受到影响。

## **合并演示文稿** 

Aspose.Slides 提供了 [**AddClone(ISlide)**](https://reference.aspose.com/slides/php-java/aspose.slides/ISlideCollection#addClone-com.aspose.slides.ISlide-) 方法，允许您在保留原始布局和样式的情况下合并幻灯片（默认参数）。

下面的 PHP 代码演示了如何合并演示文稿：
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

Aspose.Slides 提供了 [**AddClone(ISlide, IMasterSlide, boolean)**](https://reference.aspose.com/slides/php-java/aspose.slides/ISlideCollection#addClone-com.aspose.slides.ISlide-com.aspose.slides.IMasterSlide-boolean-) 方法，允许您在合并幻灯片的同时应用幻灯片母版模板。这样，您可以在需要时更改输出演示文稿中幻灯片的样式。

下面的代码演示了上述操作：
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

幻灯片母版的布局会自动确定。当无法确定合适的布局时，如果将 `AddClone` 方法的 `allowCloneMissingLayout` 布尔参数设为 true，则使用源幻灯片的布局。否则，将抛出 [PptxEditException](https://reference.aspose.com/slides/php-java/aspose.slides/PptxEditException)。

{{% /alert %}}

如果您希望输出演示文稿中的幻灯片采用不同的布局，请在合并时改用 [AddClone(ISlide, ILayoutSlide)](https://reference.aspose.com/slides/php-java/aspose.slides/ISlideCollection#addClone-com.aspose.slides.ISlide-com.aspose.slides.ILayoutSlide-) 方法。

## **合并来自演示文稿的特定幻灯片** 

从多个演示文稿中合并特定幻灯片对于创建自定义幻灯片组非常有用。Aspose.Slides for PHP via Java 允许您选择并导入所需的幻灯片。API 会保留原始幻灯片的格式、布局和设计。

下面的 PHP 代码创建一个新演示文稿，从两个其他演示文稿中添加标题幻灯片，并将结果保存为文件：
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

下面的 PHP 代码演示了如何在合并演示文稿时为幻灯片应用首选布局，以生成一个输出演示文稿：
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


## **合并不同幻灯片尺寸的演示文稿** 

{{% alert title="Note" color="warning" %}} 

无法合并尺寸不同的演示文稿。 

{{% /alert %}}

若要合并尺寸不同的两个演示文稿，必须调整其中一个演示文稿的尺寸，使其与另一个演示文稿的尺寸匹配。

下面的示例代码演示了上述操作：
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

下面的 PHP 代码演示了如何将特定幻灯片合并到演示文稿的某个章节：
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


该幻灯片将添加到章节的末尾。

## **另请参见**


Aspose 提供了一个 [免费在线拼图制作工具](https://products.aspose.app/slides/collage)。使用此在线服务，您可以合并 [JPG 到 JPG](https://products.aspose.app/slides/collage/jpg) 或 PNG 到 PNG 的图像，创建 [照片网格](https://products.aspose.app/slides/collage/photo-grid) 等。

查看 [Aspose 免费在线合并工具](https://products.aspose.app/slides/merger)。它允许您在相同格式（例如 PPT 到 PPT、PPTX 到 PPTX）或不同格式（例如 PPT 到 PPTX、PPTX 到 ODP）之间合并 PowerPoint 演示文稿。

[![Aspose FREE Online Merger](slides-merger.png)](https://products.aspose.app/slides/merger)

## **常见问题** 

**合并演示文稿时对幻灯片数量有任何限制吗？** 

暂无严格限制。Aspose.Slides 能处理大文件，但性能取决于文件大小和系统资源。对于非常大的演示文稿，建议使用 64 位 JVM 并分配足够的堆内存。

**我可以合并包含嵌入视频或音频的演示文稿吗？** 

可以，Aspose.Slides 会保留幻灯片中嵌入的多媒体内容，但最终的演示文稿文件可能会显著增大。

**合并演示文稿时字体会被保留吗？** 

会。源演示文稿中使用的字体会在输出文件中保留，前提是这些字体已在系统上安装或已[嵌入](/slides/zh/php-java/embedded-font/)。