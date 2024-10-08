---
title: 演示文稿备注
type: docs
weight: 110
url: /php-java/presentation-notes/
keywords: "PowerPoint 演讲者备注"
description: "演示文稿备注，演讲者备注"
---


{{% alert color="primary" %}} 

Aspose.Slides 支持从演示文稿中删除备注幻灯片。在本主题中，我们将介绍这个新的功能，移除备注，并从任何演示文稿中添加备注样式幻灯片。

{{% /alert %}} 

Aspose.Slides for PHP via Java 提供了删除任何幻灯片备注的功能，以及为现有备注添加样式。开发人员可以通过以下方式删除备注：

* 删除演示文稿中特定幻灯片的备注。
* 删除演示文稿中所有幻灯片的备注。


## **从幻灯片中删除备注**
可以如下面的示例所示删除特定幻灯片的备注：

```php
  # 实例化表示演示文稿文件的 Presentation 对象
  $pres = new Presentation("presWithNotes.pptx");
  try {
    # 删除第一张幻灯片的备注
    $mgr = $pres->getSlides()->get_Item(0)->getNotesSlideManager();
    $mgr->removeNotesSlide();
    # 将演示文稿保存到磁盘
    $pres->save("test.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

## **从演示文稿中删除备注**
可以如下面的示例所示删除演示文稿中所有幻灯片的备注：

```php
  # 实例化表示演示文稿文件的 Presentation 对象
  $pres = new Presentation("presWithNotes.pptx");
  try {
    # 删除所有幻灯片的备注
    $mgr = null;
    for($i = 0; $i < java_values($pres->getSlides()->size()) ; $i++) {
      $mgr = $pres->getSlides()->get_Item($i)->getNotesSlideManager();
      $mgr->removeNotesSlide();
    }
    # 将演示文稿保存到磁盘
    $pres->save("test.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

## **添加备注样式**
[getNotesStyle](https://reference.aspose.com/slides/php-java/aspose.slides/IMasterNotesSlide#getNotesStyle--) 方法已被添加到 [IMasterNotesSlide](https://reference.aspose.com/slides/php-java/aspose.slides/IMasterNotesSlide) 接口和 [MasterNotesSlide](https://reference.aspose.com/slides/php-java/aspose.slides/MasterNotesSlide) 类中。该属性指定备注文本的样式。实现如下例所示。

```php
  # 实例化表示演示文稿文件的 Presentation 对象
  $pres = new Presentation("demo.pptx");
  try {
    $notesMaster = $pres->getMasterNotesSlideManager()->getMasterNotesSlide();
    if (!java_is_null($notesMaster)) {
      # 获取 MasterNotesSlide 文本样式
      $notesStyle = $notesMaster->getNotesStyle();
      # 为第一层段落设置符号项目符号
      $paragraphFormat = $notesStyle->getLevel(0);
      $paragraphFormat::getBullet()->setType(BulletType::Symbol);
    }
    $pres->save("NotesSlideWithNotesStyle.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```