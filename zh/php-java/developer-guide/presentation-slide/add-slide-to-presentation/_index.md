---
title: 添加幻灯片到演示文稿
type: docs
weight: 10
url: /zh/php-java/add-slide-to-presentation/
---

## **添加幻灯片到演示文稿**
{{% alert color="primary" %}} 

在谈论如何将幻灯片添加到演示文稿文件之前，我们先讨论一些关于幻灯片的事实。每个 PowerPoint 演示文稿文件包含 **母版 / 布局** 幻灯片和其他 **普通** 幻灯片。这意味着一个演示文稿文件至少包含一张或多张幻灯片。需要知道的是，没有幻灯片的演示文稿文件不受 Aspose.Slides for PHP via Java 的支持。每张幻灯片都有一个唯一的 Id，所有普通幻灯片按照零基索引指定的顺序排列。

{{% /alert %}} 

Aspose.Slides for PHP via Java 允许开发者向其演示文稿添加空幻灯片。要在演示文稿中添加空幻灯片，请按照以下步骤操作：

- 创建一个 [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/presentation) 类的实例。
- 通过设置对 [Slides](https://reference.aspose.com/slides/php-java/aspose.slides/Presentation#getSlides--)（内容幻灯片对象集合）属性的引用，实例化 [ISlideCollection](https://reference.aspose.com/slides/php-java/aspose.slides/ISlideCollection) 类，该属性由 [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/presentation) 对象暴露。
- 通过调用 [ISlideCollection](https://reference.aspose.com/slides/php-java/aspose.slides/ISlideCollection) 对象暴露的 [**addEmptySlide**](https://reference.aspose.com/slides/php-java/aspose.slides/ISlideCollection#addEmptySlide-com.aspose.slides.ILayoutSlide-) 方法，将空幻灯片添加到内容幻灯片集合的末尾。
- 对新增加的空幻灯片进行一些操作。
- 最后，使用 [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/presentation) 对象写入演示文稿文件。

```php
  # 实例化表示演示文稿文件的 Presentation 类
  $pres = new Presentation();
  try {
    # 实例化 SlideCollection 类
    $slds = $pres->getSlides();
    for($i = 0; $i < java_values($pres->getLayoutSlides()->size()) ; $i++) {
      # 将空幻灯片添加到 Slides 集合中
      $slds->addEmptySlide($pres->getLayoutSlides()->get_Item($i));
    }
    # 对新增加的幻灯片进行一些操作
    # 将 PPTX 文件保存到磁盘
    $pres->save("EmptySlide.pptx", SaveFormat::Pptx);
  } finally {
    $pres->dispose();
  }
```