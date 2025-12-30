---
title: 在 PHP 中向演示文稿添加幻灯片
linktitle: 添加幻灯片
type: docs
weight: 10
url: /zh/php-java/add-slide-to-presentation/
keywords:
- 添加幻灯片
- 创建幻灯片
- 空幻灯片
- PowerPoint
- OpenDocument
- 演示文稿
- PHP
- Aspose.Slides
description: "使用 Aspose.Slides for PHP via Java，轻松向 PowerPoint 和 OpenDocument 演示文稿添加幻灯片——秒级实现流畅高效的幻灯片插入。"
---

## **向演示文稿添加幻灯片**
{{% alert color="primary" %}} 

在讨论向演示文稿文件添加幻灯片之前，让我们先了解一些关于幻灯片的事实。每个 PowerPoint 演示文稿文件包含 **Master / Layout** 幻灯片和其他 **Normal** 幻灯片。这意味着一个演示文稿文件至少包含一张或多张幻灯片。需要注意的是，Aspose.Slides for PHP via Java 不支持没有幻灯片的演示文稿文件。每张幻灯片都有唯一的 Id，所有 Normal 幻灯片按照基于零的索引顺序排列。

{{% /alert %}} 

Aspose.Slides for PHP via Java 允许开发者向其演示文稿添加空幻灯片。要在演示文稿中添加空幻灯片，请按以下步骤操作：

- 创建一个 [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/presentation) 类的实例。
- 实例化 [ISlideCollection](https://reference.aspose.com/slides/php-java/aspose.slides/ISlideCollection) 类，通过设置对 [Slides](https://reference.aspose.com/slides/php-java/aspose.slides/Presentation#getSlides--)（内容 Slide 对象集合）属性的引用，该属性由 [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/presentation) 对象公开。
- 通过调用由 [ISlideCollection](https://reference.aspose.com/slides/php-java/aspose.slides/ISlideCollection) 对象公开的 [**addEmptySlide**](https://reference.aspose.com/slides/php-java/aspose.slides/ISlideCollection#addEmptySlide-com.aspose.slides.ILayoutSlide-) 方法，在内容幻灯片集合的末尾向演示文稿添加一个空幻灯片。
- 对新添加的空幻灯片进行一些操作。
- 最后，使用 [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/presentation) 对象写入演示文稿文件。
```php
  # 实例化表示演示文件的 Presentation 类
  $pres = new Presentation();
  try {
    # 实例化 SlideCollection 类
    $slds = $pres->getSlides();
    for($i = 0; $i < java_values($pres->getLayoutSlides()->size()) ; $i++) {
      # 向 Slides 集合中添加空幻灯片
      $slds->addEmptySlide($pres->getLayoutSlides()->get_Item($i));
    }
    # 对新添加的幻灯片进行一些操作
    # 将 PPTX 文件保存到磁盘
    $pres->save("EmptySlide.pptx", SaveFormat::Pptx);
  } finally {
    $pres->dispose();
  }
```


## **常见问题**

**我可以在特定位置插入新幻灯片，而不仅仅是末尾吗？**

是的。库支持幻灯片集合以及 [insert](https://reference.aspose.com/slides/php-java/aspose.slides/slidecollection/insertemptyslide/)/[clone](https://reference.aspose.com/slides/php-java/aspose.slides/slidecollection/insertclone/) 操作，因此您可以在所需的索引位置添加幻灯片，而不仅仅是末尾。

**基于布局添加幻灯片时，主题/样式会被保留吗？**

是的。布局继承其母版的格式，新幻灯片则继承所选布局及其关联的母版。

**在添加幻灯片之前，新“空”演示文稿中包含哪个幻灯片？**

新创建的演示文稿已经包含一个索引为零的空白幻灯片。在计算插入索引时需要考虑这一点。

**如果母版有很多选项，如何为新幻灯片选择“正确”的布局？**

通常选择符合所需结构的 [LayoutSlide](https://reference.aspose.com/slides/php-java/aspose.slides/layoutslide/)（例如 [Title and Content, Two Content, etc.](https://reference.aspose.com/slides/php-java/aspose.slides/slidelayouttype/)）。如果缺少此类布局，您可以将其 [add it to the master](/slides/zh/php-java/slide-layout/) 添加到母版，然后使用它。