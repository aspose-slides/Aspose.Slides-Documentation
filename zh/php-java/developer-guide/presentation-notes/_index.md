---
title: 在 PHP 中管理演示文稿备注
linktitle: 演示文稿备注
type: docs
weight: 110
url: /zh/php-java/presentation-notes/
keywords:
- 备注
- 备注幻灯片
- 添加备注
- 删除备注
- 备注样式
- 母版备注
- PowerPoint
- OpenDocument
- 演示文稿
- PHP
- Aspose.Slides
description: "使用 Aspose.Slides for PHP via Java 自定义演示文稿备注。无缝处理 PowerPoint 和 OpenDocument 备注，提高工作效率。"
---

{{% alert color="primary" %}} 

Aspose.Slides 支持从演示文稿中删除备注幻灯片。在本主题中，我们将介绍此新功能，即删除备注以及向任何演示文稿添加备注样式幻灯片。 

{{% /alert %}} 

Aspose.Slides for PHP via Java 提供了删除任意幻灯片备注以及为现有备注添加样式的功能。开发人员可以通过以下方式删除备注：

* 删除演示文稿中特定幻灯片的备注。
* 删除演示文稿中所有幻灯片的备注


## **Remove Notes from a Slide**
如下面的示例所示，可删除某个特定幻灯片的备注：
```php
  # 实例化一个表示演示文稿文件的 Presentation 对象
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


## **Remove Notes from a Presentation**
如下面的示例所示，可删除演示文稿中所有幻灯片的备注：
```php
  # 实例化一个表示演示文稿文件的 Presentation 对象
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


## **Add a Notes Style**
[getNotesStyle](https://reference.aspose.com/slides/php-java/aspose.slides/IMasterNotesSlide#getNotesStyle--) 方法已添加到 [IMasterNotesSlide](https://reference.aspose.com/slides/php-java/aspose.slides/IMasterNotesSlide) 接口和 [MasterNotesSlide](https://reference.aspose.com/slides/php-java/aspose.slides/MasterNotesSlide) 类中。此属性指定备注文本的样式。下面的示例演示了其实现。
```php
  # 实例化一个表示演示文稿文件的 Presentation 对象
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


## **FAQ**

**Which API entity provides access to the notes of a specific slide?**

备注通过幻灯片的备注管理器访问：幻灯片拥有一个 [NotesSlideManager](https://reference.aspose.com/slides/php-java/aspose.slides/notesslidemanager/) 和一个返回备注对象的 [method](https://reference.aspose.com/slides/php-java/aspose.slides/notesslidemanager/getnotesslide/)，如果没有备注则返回 `null`。

**Are there differences in notes support across the PowerPoint versions the library works with?**

该库面向广泛的 Microsoft PowerPoint 格式（97 及以后版本）以及 ODP；在这些格式中均支持备注，不依赖于已安装的 PowerPoint 副本。