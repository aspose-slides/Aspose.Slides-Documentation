---
title: PHP 中克隆演示文稿幻灯片
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
description: "使用 Aspose.Slides for PHP 快速复制 PowerPoint 幻灯片。遵循我们清晰的代码示例，在秒内自动化 PPT 创建，消除手动操作。"
---

## **克隆演示文稿中的幻灯片**
克隆是创建某物的完全复制或副本的过程。Aspose.Slides for PHP via Java 也可以复制任意幻灯片，然后将该克隆幻灯片插入当前或其他已打开的演示文稿中。幻灯片克隆的过程会生成一个新幻灯片，开发人员可以对其进行修改而不会影响原始幻灯片。克隆幻灯片的方法有多种：

- 在演示文稿的末尾克隆。
- 在演示文稿的其他位置克隆。
- 在另一个演示文稿的末尾克隆。
- 在另一个演示文稿的其他位置克隆。
- 在另一个演示文稿的特定位置克隆。

在 Aspose.Slides for PHP via Java 中，<a href="https://reference.aspose.com/slides/php-java/aspose.slides/Presentation">Presentation</a> 对象公开的（<a href="https://reference.aspose.com/slides/php-java/aspose.slides/Slide">Slide</a>）集合提供了<a href="https://reference.aspose.com/slides/php-java/aspose.slides/SlideCollection/#addClone">addClone</a>和<a href="https://reference.aspose.com/slides/php-java/aspose.slides/SlideCollection/#insertClone">insertClone</a>方法，以实现上述各种幻灯片克隆方式。

## **在演示文稿末尾克隆幻灯片**
如果要克隆幻灯片并在同一演示文稿文件的现有幻灯片末尾使用它，请按照下面列出的步骤使用<a href="https://reference.aspose.com/slides/php-java/aspose.slides/SlideCollection/#addClone">addClone</a>方法：

1. 创建一个<a href="https://reference.aspose.com/slides/php-java/aspose.slides/Presentation">Presentation</a> 类的实例。
2. 通过引用<a href="https://reference.aspose.com/slides/php-java/aspose.slides/Presentation">Presentation</a> 对象公开的幻灯片集合，获取<a href="https://reference.aspose.com/slides/php-java/aspose.slides/Presentation/#getSlides">SlideCollection</a> 对象。
3. 调用<a href="https://reference.aspose.com/slides/php-java/aspose.slides/SlideCollection/#addClone">addClone</a>方法（<a href="https://reference.aspose.com/slides/php-java/aspose.slides/Presentation/#getSlides">SlideCollection</a> 对象公开），并将要克隆的幻灯片作为参数传递给<a href="https://reference.aspose.com/slides/php-java/aspose.slides/SlideCollection/#addClone">addClone</a> 方法。
4. 写入修改后的演示文稿文件。

以下示例中，我们将演示文稿中第一位置（索引为 0）的幻灯片克隆到演示文稿的末尾。
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
如果要克隆幻灯片并在同一演示文稿文件的不同位置使用它，请使用<a href="https://reference.aspose.com/slides/php-java/aspose.slides/SlideCollection/#insertClone">insertClone</a>方法：

1. 创建一个<a href="https://reference.aspose.com/slides/php-java/aspose.slides/Presentation">Presentation</a> 类的实例。
2. 通过引用<a href="https://reference.aspose.com/slides/php-java/aspose.slides/Presentation">Presentation</a> 对象公开的<a href="https://reference.aspose.com/slides/php-java/aspose.slides/Presentation/#getSlides">Slides</a>集合，获取<a href="https://reference.aspose.com/slides/php-java/aspose.slides/SlideCollection">SlideCollection</a> 对象。
3. 调用<a href="https://reference.aspose.com/slides/php-java/aspose.slides/SlideCollection/#insertClone">insertClone</a>方法（<a href="https://reference.aspose.com/slides/php-java/aspose.slides/Presentation/#getSlides">SlideCollection</a> 对象公开），并将要克隆的幻灯片及新位置的索引作为参数传递给<a href="https://reference.aspose.com/slides/php-java/aspose.slides/SlideCollection/#insertClone">insertClone</a> 方法。
4. 将修改后的演示文稿写入为 PPTX 文件。

以下示例中，我们将演示文稿中索引为 0（位置 1）的幻灯片克隆到索引 1（位置 2）。
```php
  # 实例化表示演示文稿文件的 Presentation 类
  $pres = new Presentation("CloneWithInSamePresentation.pptx");
  try {
    # 将所需幻灯片克隆到同一演示文稿中幻灯片集合的末尾
    $slds = $pres->getSlides();
    # 将所需幻灯片克隆到同一演示文稿中指定的索引位置
    $slds->insertClone(2, $pres->getSlides()->get_Item(1));
    # 将修改后的演示文稿写入磁盘
    $pres->save("Aspose_CloneWithInSamePresentation_out.pptx", SaveFormat::Pptx);
  } finally {
    $pres->dispose();
  }
```


## **在另一个演示文稿的末尾克隆幻灯片**
如果需要从一个演示文稿克隆幻灯片并在另一个演示文稿文件的现有幻灯片末尾使用它：

1. 创建一个包含源演示文稿的<a href="https://reference.aspose.com/slides/php-java/aspose.slides/Presentation">Presentation</a> 类实例。
2. 创建一个包含目标演示文稿的<a href="https://reference.aspose.com/slides/php-java/aspose.slides/Presentation">Presentation</a> 类实例。
3. 通过引用目标演示文稿的<a href="https://reference.aspose.com/slides/php-java/aspose.slides/Presentation/#getSlides">Slides</a>集合，获取<a href="https://reference.aspose.com/slides/php-java/aspose.slides/SlideCollection">SlideCollection</a> 对象。
4. 调用<a href="https://reference.aspose.com/slides/php-java/aspose.slides/SlideCollection/#addClone">addClone</a>方法（<a href="https://reference.aspose.com/slides/php-java/aspose.slides/Presentation/#getSlides">SlideCollection</a> 对象公开），并将源演示文稿中的幻灯片作为参数传递给<a href="https://reference.aspose.com/slides/php-java/aspose.slides/SlideCollection/#addClone">addClone</a> 方法。
5. 写入修改后的目标演示文稿文件。

以下示例中，我们将源演示文稿第一索引的幻灯片克隆到目标演示文稿的末尾。
```php
  # 实例化 Presentation 类以加载源演示文稿文件
  $srcPres = new Presentation("CloneAtEndOfAnother.pptx");
  try {
    # 实例化用于目标 PPTX 的 Presentation 类（将克隆幻灯片的目标文件）
    $destPres = new Presentation();
    try {
      # 将所需幻灯片从源演示文稿克隆到目标演示文稿的幻灯片集合末尾
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
如果需要从一个演示文稿克隆幻灯片并在另一个演示文稿文件的特定位置使用它：

1. 创建一个包含源演示文稿的<a href="https://reference.aspose.com/slides/php-java/aspose.slides/Presentation">Presentation</a> 类实例。
2. 创建一个包含目标演示文稿的<a href="https://reference.aspose.com/slides/php-java/aspose.slides/Presentation">Presentation</a> 类实例。
3. 通过引用目标演示文稿的<a href="https://reference.aspose.com/slides/php-java/aspose.slides/Presentation/#getSlides">Slides</a>集合，获取<a href="https://reference.aspose.com/slides/php-java/aspose.slides/SlideCollection/#getSlides">SlideCollection</a> 类。
4. 调用<a href="https://reference.aspose.com/slides/php-java/aspose.slides/SlideCollection/#insertClone">insertClone</a>方法（<a href="https://reference.aspose.com/slides/php-java/aspose.slides/Presentation/#getSlides">SlideCollection</a> 对象公开），并将源演示文稿中的幻灯片以及期望的位置作为参数传递给<a href="https://reference.aspose.com/slides/php-java/aspose.slides/SlideCollection/#insertClone">insertClone</a> 方法。
5. 写入修改后的目标演示文稿文件。

以下示例中，我们将源演示文稿零索引的幻灯片克隆到目标演示文稿索引 1（位置 2）。
```php
  # 实例化 Presentation 类以加载源演示文稿文件
  $srcPres = new Presentation("CloneAtEndOfAnother.pptx");
  try {
    # 实例化用于目标 PPTX 的 Presentation 类（将克隆幻灯片的目标文件）
    $destPres = new Presentation();
    try {
      # 将所需幻灯片从源演示文稿克隆到目标演示文稿的幻灯片集合末尾
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
如果需要从一个演示文稿克隆带母版的幻灯片并在另一个演示文稿中使用，首先必须先将源演示文稿所需的母版克隆到目标演示文稿，然后使用该母版克隆带母版的幻灯片。<a href="https://reference.aspose.com/slides/php-java/aspose.slides/slidecollection/addclone/">addClone(Slide, MasterSlide, boolean)</a> 方法期望传入目标演示文稿中的母版，而不是源演示文稿中的母版。请按照以下步骤克隆带母版的幻灯片：

1. 创建一个包含源演示文稿的<a href="https://reference.aspose.com/slides/php-java/aspose.slides/Presentation">Presentation</a> 类实例。
2. 创建一个包含目标演示文稿的<a href="https://reference.aspose.com/slides/php-java/aspose.slides/Presentation">Presentation</a> 类实例。
3. 访问要克隆的幻灯片及其母版。
4. 通过引用目标演示文稿的<a href="https://reference.aspose.com/slides/php-java/aspose.slides/Presentation">Presentation</a> 对象公开的 Masters 集合，实例化<a href="https://reference.aspose.com/slides/php-java/aspose.slides/MasterSlideCollection">MasterSlideCollection</a> 类。
5. 调用<a href="https://reference.aspose.com/slides/php-java/aspose.slides/SlideCollection/#addClone">addClone</a>方法（<a href="https://reference.aspose.com/slides/php-java/aspose.slides/MasterSlideCollection">MasterSlideCollection</a> 对象公开），并将源 PPTX 中的母版作为参数传递给<a href="https://reference.aspose.com/slides/php-java/aspose.slides/SlideCollection/#addClone">addClone</a> 方法。
6. 通过引用目标演示文稿的<a href="https://reference.aspose.com/slides/php-java/aspose.slides/Presentation">Presentation</a> 对象公开的 Slides 集合，实例化<a href="https://reference.aspose.com/slides/php-java/aspose.slides/Presentation/#getSlides">SlideCollection</a> 类。
7. 调用<a href="https://reference.aspose.com/slides/php-java/aspose.slides/SlideCollection/#addClone">addClone</a>方法（<a href="https://reference.aspose.com/slides/php-java/aspose.slides/Presentation/#getSlides">SlideCollection</a> 对象公开），并将源演示文稿中的幻灯片和目标母版作为参数传递给<a href="https://reference.aspose.com/slides/php-java/aspose.slides/SlideCollection/#addClone">addClone</a> 方法。
8. 写入修改后的目标演示文稿文件。

以下示例中，我们将源演示文稿零索引的带母版幻灯片克隆到目标演示文稿的末尾，使用来自源幻灯片的母版。
```php
  # 实例化 Presentation 类以加载源演示文稿文件
  $srcPres = new Presentation("CloneToAnotherPresentationWithMaster.pptx");
  try {
    # 实例化用于目标演示文稿的 Presentation 类（幻灯片将被克隆的地方）
    $destPres = new Presentation();
    try {
      # 实例化来自源演示文稿幻灯片集合的 ISlide，连同
      # 母版幻灯片
      $SourceSlide = $srcPres->getSlides()->get_Item(0);
      $SourceMaster = $SourceSlide->getLayoutSlide()->getMasterSlide();
      # 将所需的母版幻灯片从源演示文稿克隆到目标演示文稿的母版集合中
      # 目标演示文稿
      $masters = $destPres->getMasters();
      $DestMaster = $SourceSlide->getLayoutSlide()->getMasterSlide();
      # 将所需的母版幻灯片从源演示文稿克隆到目标演示文稿的母版集合中
      # 目标演示文稿
      $iSlide = $masters->addClone($SourceMaster);
      # 将所需幻灯片（使用指定母版）从源演示文稿克隆到目标演示文稿幻灯片集合的末尾
      # 目标演示文稿的幻灯片集合
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
如果要克隆幻灯片并在同一演示文稿文件的不同章节使用它，请使用<a href="https://reference.aspose.com/slides/php-java/aspose.slides/SlideCollection/#addClone">addClone</a>方法（<a href="https://reference.aspose.com/slides/php-java/aspose.slides/SlideCollection">SlideCollection</a> 类公开）。Aspose.Slides for PHP via Java 允许从第一章节克隆幻灯片，然后将该克隆幻灯片插入同一演示文稿的第二章节。

下面的代码片段演示了如何克隆幻灯片并将克隆幻灯片插入指定章节。
```php
  $presentation = new Presentation();
  try {
    $presentation->getSlides()->get_Item(0)->getShapes()->addAutoShape(ShapeType::Rectangle, 200, 50, 300, 100);
    $presentation->getSections()->addSection("Section 1", $presentation->getSlides()->get_Item(0));
    $section2 = $presentation->getSections()->appendEmptySection("Section 2");
    $presentation->getSlides()->addClone($presentation->getSlides()->get_Item(0), $section2);
    # 将目标演示文稿保存到磁盘
    $presentation->save($dataDir . "CloneSlideIntoSpecifiedSection.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($presentation)) {
      $presentation->dispose();
    }
  }
```


## **常见问题**

**演讲者备注和审阅者评论会被克隆吗？**

会。备注页和审阅评论会包含在克隆中。如果不想要它们，请在插入后[删除它们](/slides/zh/php-java/presentation-notes/)。

**图表及其数据源如何处理？**

图表对象、格式以及嵌入的数据都会被复制。如果图表链接到外部源（例如 OLE 嵌入的工作簿），该链接会以 [OLE 对象](/slides/zh/php-java/manage-ole/) 形式保留下来。文件移动后，请验证数据可用性并刷新行为。

**我可以控制克隆的插入位置和章节吗？**

可以。您可以将克隆插入特定的幻灯片索引，并将其放入选定的[章节](/slides/zh/php-java/slide-section/)。如果目标章节不存在，请先创建，然后再将幻灯片移动到该章节。