---
title: 在 PHP 中克隆演示文稿幻灯片
linktitle: 克隆幻灯片
type: docs
weight: 35
url: /zh/php-java/clone-slides/
keywords:
- 克隆幻灯片
- 复制幻灯片
- 保存幻灯片
- PowerPoint
- OpenDocument
- 演示文稿
- PHP
- Aspose.Slides
description: "使用 Aspose.Slides for PHP 快速复制 PowerPoint 幻灯片。遵循我们的清晰代码示例，在几秒钟内实现 PPT 自动创建，消除手工操作。"
---
## **介绍**

克隆是制作某物精确副本或复制品的过程。Aspose.Slides for PHP via Java 也能够对任意幻灯片进行复制或克隆，然后将该克隆幻灯片插入当前或任何其他已打开的演示文稿。幻灯片克隆过程会创建一个新幻灯片，开发人员可以对其进行修改而不影响原始幻灯片。克隆幻灯片有多种可能方式：

- 在演示文稿内部的末尾克隆。
- 在演示文稿内部的其他位置克隆。
- 在另一个演示文稿的末尾克隆。
- 在另一个演示文稿的其他位置克隆。
- 在另一个演示文稿的特定位置克隆。

在 Aspose.Slides for PHP via Java 中，由 [Presentation](https://reference.aspose.com/slides/zh/php-java/aspose.slides/Presentation) 对象公开的 (一个包含 [Slide](https://reference.aspose.com/slides/zh/php-java/aspose.slides/Slide) 对象的集合) 提供了 [addClone](https://reference.aspose.com/slides/zh/php-java/aspose.slides/SlideCollection/#addClone) 和 [insertClone](https://reference.aspose.com/slides/zh/php-java/aspose.slides/SlideCollection/#insertClone) 方法，以执行上述幻灯片克隆类型

## **在演示文稿末尾克隆幻灯片**
If you want to clone a slide and then use it within the same presentation file at the end of the existing slides, use the [addClone](https://reference.aspose.com/slides/zh/php-java/aspose.slides/SlideCollection/#addClone) method according to the steps listed below:

1. 创建一个 [Presentation](https://reference.aspose.com/slides/zh/php-java/aspose.slides/Presentation) 类的实例。
1. 通过引用由 [Presentation](https://reference.aspose.com/slides/zh/php-java/aspose.slides/Presentation) 对象公开的幻灯片集合，获取 [SlideCollection](https://reference.aspose.com/slides/zh/php-java/aspose.slides/Presentation/#getSlides) 对象。
1. 调用由 [SlideCollection](https://reference.aspose.com/slides/zh/php-java/aspose.slides/Presentation/#getSlides) 对象公开的 [addClone](https://reference.aspose.com/slides/zh/php-java/aspose.slides/SlideCollection/#addClone) 方法，并将要克隆的幻灯片作为参数传递给该方法。
1. 写入修改后的演示文稿文件。

在下面的示例中，我们已将位于演示文稿第一位置（零索引）的幻灯片克隆到演示文稿的末尾。

```php
  # 实例化表示演示文稿文件的 Presentation 类
  $pres = new Presentation("CloneWithinSamePresentationToEnd.pptx");
  try {
    # 将所需幻灯片克隆到同一演示文稿中幻灯片集合的末尾
    $slds = $pres->getSlides();
    $slds->addClone($pres->getSlides()->get_Item(0));
    # 将修改后的演示文稿写入磁盘
    $pres->save("Aspose_CloneWithinSamePresentationToEnd_out.pptx", SaveFormat::Pptx);
  } finally {
    $pres->dispose();
  }
```

## **在演示文稿内部的其他位置克隆幻灯片**
If you want to clone a slide and then use it within the same presentation file but at a different position, use the [insertClone](https://reference.aspose.com/slides/zh/php-java/aspose.slides/SlideCollection/#insertClone) method:

1. 创建一个 [Presentation](https://reference.aspose.com/slides/zh/php-java/aspose.slides/Presentation) 类的实例。
1. 通过引用由 [Presentation](https://reference.aspose.com/slides/zh/php-java/aspose.slides/Presentation) 对象公开的 **Slides** 集合，获取 [SlideCollection](https://reference.aspose.com/slides/zh/php-java/aspose.slides/SlideCollection) 对象。
1. 调用由 [SlideCollection](https://reference.aspose.com/slides/zh/php-java/aspose.slides/Presentation/#getSlides) 对象公开的 [insertClone](https://reference.aspose.com/slides/zh/php-java/aspose.slides/SlideCollection/#insertClone) 方法，并将要克隆的幻灯片以及新位置的索引作为参数传递给该方法。
1. 将修改后的演示文稿写入为 PPTX 文件。

在下面的示例中，我们已将位于零索引（位置 1）的幻灯片克隆到索引 1（位置 2）。

```php
  # 实例化表示演示文稿文件的 Presentation 类
  $pres = new Presentation("CloneWithInSamePresentation.pptx");
  try {
    # 将所需幻灯片克隆到同一演示文稿中幻灯片集合的末尾
    $slds = $pres->getSlides();
    # 将所需幻灯片克隆到同一演示文稿中的指定索引
    $slds->insertClone(2, $pres->getSlides()->get_Item(1));
    # 将修改后的演示文稿写入磁盘
    $pres->save("Aspose_CloneWithInSamePresentation_out.pptx", SaveFormat::Pptx);
  } finally {
    $pres->dispose();
  }
```

## **在另一个演示文稿的末尾克隆幻灯片**
If you need to clone a slide from one presentation and use it in another presentation file, at the end of the existing slides:

1. 创建一个包含要克隆幻灯片来源的演示文稿的 [Presentation](https://reference.aspose.com/slides/zh/php-java/aspose.slides/Presentation) 类实例。
1. 创建一个包含目标演示文稿的 [Presentation](https://reference.aspose.com/slides/zh/php-java/aspose.slides/Presentation) 类实例。
1. 通过引用目标演示文稿的 **Slides** 集合，获取 [SlideCollection](https://reference.aspose.com/slides/zh/php-java/aspose.slides/SlideCollection) 对象。
1. 调用由 [SlideCollection](https://reference.aspose.com/slides/zh/php-java/aspose.slides/Presentation/#getSlides) 对象公开的 [addClone](https://reference.aspose.com/slides/zh/php-java/aspose.slides/SlideCollection/#addClone) 方法，并将来源演示文稿中的幻灯片作为参数传递给该方法。
1. 写入修改后的目标演示文稿文件。

在下面的示例中，我们已将来源演示文稿第一索引的幻灯片克隆到目标演示文稿的末尾。

```php
  # 实例化 Presentation 类以加载源演示文稿文件
  $srcPres = new Presentation("CloneAtEndOfAnother.pptx");
  try {
    # 实例化目标 PPTX 的 Presentation 类（幻灯片将被克隆到此处）
    $destPres = new Presentation();
    try {
      # 将所需幻灯片从源演示文稿克隆到目标演示文稿中幻灯片集合的末尾
      $slds = $destPres->getSlides();
      $slds->addClone($srcPres->getSlides()->get_Item(0));
      # 将目标演示文稿写入磁盘
      $destPres->save("Aspose2_out.pptx", SaveFormat::Pptx);
    } finally {
      $destPres->dispose();
    }
  } finally {
    $srcPres->dispose();
  }
```

## **在另一个演示文稿的其他位置克隆幻灯片**
If you need to clone a slide from one presentation and use it in another presentation file, at a specific position:

1. 创建一个包含来源演示文稿的 [Presentation](https://reference.aspose.com/slides/zh/php-java/aspose.slides/Presentation) 类实例。
1. 创建一个包含目标演示文稿的 [Presentation](https://reference.aspose.com/slides/zh/php-java/aspose.slides/Presentation) 类实例。
1. 通过引用目标演示文稿的 Slides 集合，获取 [SlideCollection](https://reference.aspose.com/slides/zh/php-java/aspose.slides/Presentation/#getSlides) 类。
1. 调用由 [SlideCollection](https://reference.aspose.com/slides/zh/php-java/aspose.slides/Presentation/#getSlides) 对象公开的 [insertClone](https://reference.aspose.com/slides/zh/php-java/aspose.slides/SlideCollection/#insertClone) 方法，并将来源演示文稿中的幻灯片以及期望的位置作为参数传递给该方法。
1. 写入修改后的目标演示文稿文件。

在下面的示例中，我们已将来源演示文稿零索引的幻灯片克隆到目标演示文稿的索引 1（位置 2）。

```php
  # 实例化 Presentation 类以加载源演示文稿文件
  $srcPres = new Presentation("CloneAtEndOfAnother.pptx");
  try {
    # 实例化目标 PPTX 的 Presentation 类（幻灯片将被克隆到此处）
    $destPres = new Presentation();
    try {
      # 将所需幻灯片从源演示文稿克隆到目标演示文稿中幻灯片集合的末尾
      $slds = $destPres->getSlides();
      $slds->insertClone(2, $srcPres->getSlides()->get_Item(0));
      # 将目标演示文稿写入磁盘
      $destPres->save("Aspose2_out.pptx", SaveFormat::Pptx);
    } finally {
      $destPres->dispose();
    }
  } finally {
    $srcPres->dispose();
  }
```

## **在另一个演示文稿的特定位置克隆带母版的幻灯片**
If you need to clone a slide with a master slide from one presentation from and use it in another presentation, you need to clone the desired master slide from source presentation to destination presentation first. Then you need to use that master slide for cloning slide with master slide. The [**addClone(Slide, MasterSlide, boolean)**](https://reference.aspose.com/slides/zh/php-java/aspose.slides/slidecollection/addclone/) expects a master slide from destination presentation rather than from source presentation. In order to clone the slide with a master, please follow the steps below:

1. 创建一个包含来源演示文稿的 [Presentation](https://reference.aspose.com/slides/zh/php-java/aspose.slides/Presentation) 类实例。
1. 创建一个包含目标演示文稿的 [Presentation](https://reference.aspose.com/slides/zh/php-java/aspose.slides/Presentation) 类实例。
1. 访问要克隆的幻灯片及其母版。
1. 通过引用目标演示文稿的 Masters 集合，实例化 [MasterSlideCollection](https://reference.aspose.com/slides/zh/php-java/aspose.slides/MasterSlideCollection) 类。
1. 调用由 [MasterSlideCollection](https://reference.aspose.com/slides/zh/php-java/aspose.slides/MasterSlideCollection) 对象公开的 [addClone](https://reference.aspose.com/slides/zh/php-java/aspose.slides/SlideCollection/#addClone) 方法，并将来源 PPTX 中的母版作为参数传递给该方法。
1. 通过引用目标演示文稿的 Slides 集合，实例化 [SlideCollection](https://reference.aspose.com/slides/zh/php-java/aspose.slides/Presentation/#getSlides) 类。
1. 调用由 [SlideCollection](https://reference.aspose.com/slides/zh/php-java/aspose.slides/Presentation/#getSlides) 对象公开的 [addClone](https://reference.aspose.com/slides/zh/php-java/aspose.slides/SlideCollection/#addClone) 方法，并将来源演示文稿中的幻灯片以及母版作为参数传递给该方法。
1. 写入修改后的目标演示文稿文件。

在下面的示例中，我们已将来源演示文稿零索引的带母版的幻灯片克隆到目标演示文稿的末尾，使用来源幻灯片的母版。

```php
  # 实例化 Presentation 类以加载源演示文稿文件
  $srcPres = new Presentation("CloneToAnotherPresentationWithMaster.pptx");
  try {
    # 实例化目标演示文稿的 Presentation 类（幻灯片将在此被克隆）
    $destPres = new Presentation();
    try {
      # 从源演示文稿的幻灯片集合中实例化 ISlide，并附带
      # 母版幻灯片
      $SourceSlide = $srcPres->getSlides()->get_Item(0);
      $SourceMaster = $SourceSlide->getLayoutSlide()->getMasterSlide();
      # 将所需母版幻灯片从源演示文稿克隆到目标演示文稿的母版集合中
      # 目标演示文稿
      $masters = $destPres->getMasters();
      $DestMaster = $SourceSlide->getLayoutSlide()->getMasterSlide();
      # 将所需母版幻灯片从源演示文稿克隆到目标演示文稿的母版集合中
      # 目标演示文稿
      $iSlide = $masters->addClone($SourceMaster);
      # 将所需幻灯片从源演示文稿使用所需母版克隆到目标演示文稿中幻灯片集合的末尾
      # 
      $slds = $destPres->getSlides();
      $slds->addClone($SourceSlide, $iSlide, true);
      # 将目标演示文稿保存到磁盘
      $destPres->save("CloneToAnotherPresentationWithMaster_out.pptx", SaveFormat::Pptx);
    } finally {
      $destPres->dispose();
    }
  } finally {
    $srcPres->dispose();
  }
```

## **在指定章节的末尾克隆幻灯片**
If you want to clone a slide and then use it within the same presentation file but at a different section, then use the [addClone](https://reference.aspose.com/slides/zh/php-java/aspose.slides/SlideCollection/#addClone) method exposed by the [SlideCollection](https://reference.aspose.com/slides/zh/php-java/aspose.slides/SlideCollection) class. Aspose.Slides for PHP via Java makes it possible to clone a slide from the first section and then insert that cloned slide to the second section of the same presentation.

The following code snippet shows you how to clone a slide and insert the cloned slide into a specified section.

```php
  $presentation = new Presentation();
  try {
    $presentation->getSlides()->get_Item(0)->getShapes()->addAutoShape(ShapeType::Rectangle, 200, 50, 300, 100);
    $presentation->getSections()->addSection("Section 1", $presentation->getSlides()->get_Item(0));
    $section2 = $presentation->getSections()->appendEmptySection("Section 2");
    $presentation->getSlides()->addClone($presentation->getSlides()->get_Item(0), $section2);
    # 将目标演示文稿保存到磁盘
    $presentation->save("CloneSlideIntoSpecifiedSection.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($presentation)) {
      $presentation->dispose();
    }
  }
```

## **确保幻灯片尺寸匹配**

When cloning slides into another presentation, make sure the destination presentation has the same slide size as the source. If the slide sizes differ, Aspose.Slides does not automatically rescale the cloned shapes—their original coordinates and dimensions are preserved, which may cause the content to appear misaligned or extend beyond the slide boundaries.

You can set the destination presentation's slide size to match the source before cloning the master and slide:

```php
$sourceSize = $sourcePresentation->getSlideSize()->getSize();

$targetPresentation->getSlideSize()->setSize(
    $sourceSize->getWidth(), $sourceSize->getHeight(), SlideSizeScaleType::DoNotScale);
```

Do this before cloning the master and the slide.

## **FAQ**

**Do speaker notes and reviewer comments get cloned?**

Yes. The notes page and review comments are included in the clone. If you don’t want them, [remove them](/slides/zh/php-java/presentation-notes/) after insertion.

**How are charts and their data sources handled?**

The chart object, formatting, and embedded data are copied. If the chart was linked to an external source (e.g., an OLE-embedded workbook), that linkage is preserved as an [OLE object](/slides/zh/php-java/manage-ole/). After moving between files, verify data availability and refresh behavior.

**Can I control the insertion position and sections for the clone?**

Yes. You can insert the clone at a specific slide index and place it into a chosen [section](/slides/zh/php-java/slide-section/). If the target section doesn’t exist, create it first and then move the slide into it.