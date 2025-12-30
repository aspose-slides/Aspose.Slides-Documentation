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
description: "使用 Aspose.Slides for PHP 快速复制 PowerPoint 幻灯片。遵循我们清晰的代码示例，在几秒钟内实现 PPT 自动创建，消除手动工作。"
---

## **在演示文稿中克隆幻灯片**
克隆是创建某物精确副本或复制品的过程。Aspose.Slides for PHP via Java 也可以对任何幻灯片进行复制或克隆，然后将该克隆幻灯片插入当前或其他已打开的演示文稿中。幻灯片克隆的过程会生成一个新幻灯片，开发人员可以对其进行修改，而不会更改原始幻灯片。克隆幻灯片有多种方式：

- 在演示文稿末尾克隆。
- 在演示文稿的其他位置克隆。
- 在另一个演示文稿末尾克隆。
- 在另一个演示文稿的其他位置克隆。
- 在另一个演示文稿的特定位置克隆。

在 Aspose.Slides for PHP via Java 中，(由 [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/Presentation) 对象公开的 [ISlide](https://reference.aspose.com/slides/php-java/aspose.slides/ISlide) 对象集合) 提供了 [addClone](https://reference.aspose.com/slides/php-java/aspose.slides/ISlideCollection#addClone-com.aspose.slides.ISlide-) 和 [insertClone](https://reference.aspose.com/slides/php-java/aspose.slides/ISlideCollection#insertClone-int-com.aspose.slides.ISlide-) 方法，以执行上述各种幻灯片克隆方式。

## **在演示文稿末尾克隆幻灯片**
如果想要克隆幻灯片并将其放在同一演示文稿文件的现有幻灯片末尾，请按照以下步骤使用 [addClone](https://reference.aspose.com/slides/php-java/aspose.slides/ISlideCollection#addClone-com.aspose.slides.ISlide-) 方法：

1. 创建 [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/Presentation) 类的实例。  
1. 通过引用由 [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/Presentation) 对象公开的 Slides 集合，实例化 [ISlideCollection](https://reference.aspose.com/slides/php-java/aspose.slides/Presentation#getSlides--) 类。  
1. 调用由 [ISlideCollection](https://reference.aspose.com/slides/php-java/aspose.slides/Presentation#getSlides--) 对象公开的 [addClone](https://reference.aspose.com/slides/php-java/aspose.slides/ISlideCollection#addClone-com.aspose.slides.ISlide-) 方法，并将要克隆的幻灯片作为参数传递给该方法。  
1. 写入修改后的演示文稿文件。

在下面的示例中，我们将演示文稿中位于首位（零索引）的幻灯片克隆到演示文稿的末尾。
```php
  # 实例化表示演示文稿文件的 Presentation 类
  $pres = new Presentation("CloneWithinSamePresentationToEnd.pptx");
  try {
    # 将所需幻灯片克隆到同一演示文稿的幻灯片集合末尾
    $slds = $pres->getSlides();
    $slds->addClone($pres->getSlides()->get_Item(0));
    # 将修改后的演示文稿写入磁盘
    $pres->save("Aspose_CloneWithinSamePresentationToEnd_out.pptx", SaveFormat::Pptx);
  } finally {
    $pres->dispose();
  }
```


## **在演示文稿的其他位置克隆幻灯片**
如果想要克隆幻灯片并将其放在同一演示文稿文件的其他位置，请使用 [insertClone](https://reference.aspose.com/slides/php-java/aspose.slides/ISlideCollection#insertClone-int-com.aspose.slides.ISlide-) 方法：

1. 创建 [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/Presentation) 类的实例。  
1. 通过引用由 [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/Presentation) 对象公开的 **Slides** 集合实例化相应的类。  
1. 调用由 [ISlideCollection](https://reference.aspose.com/slides/php-java/aspose.slides/Presentation#getSlides--) 对象公开的 [insertClone](https://reference.aspose.com/slides/php-java/aspose.slides/ISlideCollection#insertClone-int-com.aspose.slides.ISlide-) 方法，并将要克隆的幻灯片以及新位置的索引作为参数传递给该方法。  
1. 将修改后的演示文稿写入为 PPTX 文件。

在下面的示例中，我们将演示文稿中位于零索引（位置 1）的幻灯片克隆到索引 1（位置 2）。
```php
  # 实例化表示演示文稿文件的 Presentation 类
  $pres = new Presentation("CloneWithInSamePresentation.pptx");
  try {
    # 将所需幻灯片克隆到同一演示文稿的幻灯片集合末尾
    $slds = $pres->getSlides();
    # 将所需幻灯片克隆到同一演示文稿的指定索引位置
    $slds->insertClone(2, $pres->getSlides()->get_Item(1));
    # 将修改后的演示文稿写入磁盘
    $pres->save("Aspose_CloneWithInSamePresentation_out.pptx", SaveFormat::Pptx);
  } finally {
    $pres->dispose();
  }
```


## **在另一个演示文稿末尾克隆幻灯片**
如果需要将一份演示文稿中的幻灯片克隆到另一份演示文稿的末尾：

1. 创建包含要克隆来源幻灯片的 [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/Presentation) 实例。  
1. 创建包含目标演示文稿的 [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/Presentation) 实例。  
1. 通过引用目标演示文稿的 **Slides** 集合，实例化 [ISlideCollection](https://reference.aspose.com/slides/php-java/aspose.slides/ISlideCollection) 类。  
1. 调用由 [ISlideCollection](https://reference.aspose.com/slides/php-java/aspose.slides/Presentation#getSlides--) 对象公开的 [addClone](https://reference.aspose.com/slides/php-java/aspose.slides/ISlideCollection#addClone-com.aspose.slides.ISlide-) 方法，并将来源演示文稿中的幻灯片作为参数传递给该方法。  
1. 写入修改后的目标演示文稿文件。

在下面的示例中，我们将来源演示文稿首位的幻灯片克隆到目标演示文稿的末尾。
```php
  # 实例化 Presentation 类以加载源演示文稿文件
  $srcPres = new Presentation("CloneAtEndOfAnother.pptx");
  try {
    # 实例化目标 PPTX 的 Presentation 类（将在此克隆幻灯片）
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
如果需要将一份演示文稿中的幻灯片克隆到另一份演示文稿的特定位置：

1. 创建包含来源演示文稿的 [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/Presentation) 实例。  
1. 创建包含目标演示文稿的 [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/Presentation) 实例。  
1. 通过引用目标演示文稿的 Slides 集合，实例化 [ISlideCollection](https://reference.aspose.com/slides/php-java/aspose.slides/Presentation#getSlides--) 类。  
1. 调用由 [ISlideCollection](https://reference.aspose.com/slides/php-java/aspose.slides/Presentation#getSlides--) 对象公开的 [insertClone](https://reference.aspose.com/slides/php-java/aspose.slides/ISlideCollection#insertClone-int-com.aspose.slides.ISlide-) 方法，并将来源演示文稿中的幻灯片以及所需位置作为参数传递给该方法。  
1. 写入修改后的目标演示文稿文件。

在下面的示例中，我们将来源演示文稿零索引的幻灯片克隆到目标演示文稿的索引 1（位置 2）。
```php
  # 实例化 Presentation 类以加载源演示文稿文件
  $srcPres = new Presentation("CloneAtEndOfAnother.pptx");
  try {
    # 实例化目标 PPTX 的 Presentation 类（将在此克隆幻灯片）
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
如果需要将带有母版幻灯片的幻灯片从一个演示文稿克隆到另一个演示文稿，首先必须先将源演示文稿中的所需母版克隆到目标演示文稿。随后使用该母版克隆带母版的幻灯片。[addClone(ISlide, IMasterSlide, boolean)](https://reference.aspose.com/slides/php-java/aspose.slides/ISlideCollection#addClone-com.aspose.slides.ISlide-com.aspose.slides.IMasterSlide-boolean-) 方法要求提供目标演示文稿中的母版，而不是来源演示文稿的母版。请按以下步骤克隆带母版的幻灯片：

1. 创建包含来源演示文稿的 [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/Presentation) 实例。  
1. 创建包含目标演示文稿的 [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/Presentation) 实例。  
1. 访问要克隆的幻灯片及其母版。  
1. 通过引用目标演示文稿的 Masters 集合，实例化 [IMasterSlideCollection](https://reference.aspose.com/slides/php-java/aspose.slides/IMasterSlideCollection) 类。  
1. 调用由 [IMasterSlideCollection](https://reference.aspose.com/slides/php-java/aspose.slides/IMasterSlideCollection) 对象公开的 [addClone](https://reference.aspose.com/slides/php-java/aspose.slides/ISlideCollection#addClone-com.aspose.slides.ISlide-) 方法，并将来源 PPTX 中的母版作为参数传递给该方法。  
1. 通过引用目标演示文稿的 Slides 集合，实例化 [ISlideCollection](https://reference.aspose.com/slides/php-java/aspose.slides/Presentation#getSlides--) 类。  
1. 调用由 [ISlideCollection](https://reference.aspose.com/slides/php-java/aspose.slides/Presentation#getSlides--) 对象公开的 [addClone](https://reference.aspose.com/slides/php-java/aspose.slides/ISlideCollection#addClone-com.aspose.slides.ISlide-) 方法，并将来源演示文稿的幻灯片及克隆后的母版作为参数传递给该方法。  
1. 写入修改后的目标演示文稿文件。

在下面的示例中，我们将来源演示文稿零索引处的带母版幻灯片克隆到目标演示文稿的末尾，并使用来源幻灯片的母版。
```php
  # 实例化 Presentation 类以加载源演示文稿文件
  $srcPres = new Presentation("CloneToAnotherPresentationWithMaster.pptx");
  try {
    # 实例化用于目标演示文稿的 Presentation 类（将在此克隆幻灯片）
    $destPres = new Presentation();
    try {
      # 从源演示文稿的幻灯片集合中实例化 ISlide，并且
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
      # 将所需幻灯片从源演示文稿（使用所需母版）克隆到目标演示文稿的幻灯片集合末尾
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
如果想要克隆幻灯片并将其放在同一演示文稿的不同章节，请使用由 [**ISlideCollection**](https://reference.aspose.com/slides/php-java/aspose.slides/ISlideCollection) 接口公开的 [**addClone**](https://reference.aspose.com/slides/php-java/aspose.slides/ISlideCollection#addClone-com.aspose.slides.ISlide-com.aspose.slides.ISection-) 方法。Aspose.Slides for PHP via Java 使得可以从第一章节克隆幻灯片，并将克隆的幻灯片插入同一演示文稿的第二章节。

下面的代码片段演示了如何克隆幻灯片并将克隆的幻灯片插入指定章节。
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

会。备注页和审阅评论都会包含在克隆中。如果不需要它们，请在插入后 [删除它们](/slides/zh/php-java/presentation-notes/)。

**图表及其数据源如何处理？**

图表对象、格式以及嵌入的数据都会被复制。如果图表链接到了外部源（例如 OLE 嵌入的工作簿），该链接会保留为 [OLE 对象](/slides/zh/php-java/manage-ole/)。在文件之间移动后，请验证数据可用性并刷新行为。

**我可以控制克隆的插入位置和章节吗？**

可以。您可以在特定幻灯片索引处插入克隆，并将其放入选定的 [章节](/slides/zh/php-java/slide-section/)。如果目标章节不存在，请先创建该章节，然后将幻灯片移动进去。