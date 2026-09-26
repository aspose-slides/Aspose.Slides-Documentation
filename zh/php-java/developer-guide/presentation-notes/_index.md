---
title: 管理 PHP 中的演示文稿备注
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
- 主备注
- PowerPoint
- OpenDocument
- 演示文稿
- PHP
- Aspose.Slides
description: "使用 Aspose.Slides for PHP via Java 定制演示文稿备注。无缝处理 PowerPoint 和 OpenDocument 备注，提高您的工作效率。"
---
## **概述**

Aspose.Slides 支持从演示文稿中删除备注幻灯片。在本主题中，我们将介绍此功能，包括如何删除备注以及怎样对演示文稿中的备注幻灯片应用样式。Aspose.Slides 允许您删除任意幻灯片的备注，并对已有备注应用样式。开发人员可以通过以下方式删除备注：

- 删除演示文稿中特定幻灯片的备注。
- 删除演示文稿中所有幻灯片的备注。

要读取或更改备注页尺寸、切换方向以及检查导出行为，请参阅[备注页大小](/slides/zh/php-java/notes-size/)。

## **从幻灯片中删除备注**
可以按如下示例删除特定幻灯片的备注：

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

## **从演示文稿中删除备注**
可以按如下示例删除演示文稿中所有幻灯片的备注：

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

## **添加备注样式**
[MasterNotesSlide](https://reference.aspose.com/slides/zh/php-java/aspose.slides/MasterNotesSlide) 类的[getNotesStyle](https://reference.aspose.com/slides/zh/php-java/aspose.slides/MasterNotesSlide#getNotesStyle) 方法提供对备注文本样式的访问。下面的示例演示了具体实现。

```php
  # 实例化一个表示演示文稿文件的 Presentation 对象
  $pres = new Presentation("demo.pptx");
  try {
    $notesMaster = $pres->getMasterNotesSlideManager()->getMasterNotesSlide();
    if (!java_is_null($notesMaster)) {
      # 获取 MasterNotesSlide 文本样式
      $notesStyle = $notesMaster->getNotesStyle();
      # 为第一级段落设置符号项目符号
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

## **常见问题**

**哪个 API 实体提供对特定幻灯片备注的访问？**

备注通过幻灯片的备注管理器访问：该幻灯片拥有一个[NotesSlideManager](https://reference.aspose.com/slides/zh/php-java/aspose.slides/notesslidemanager/)以及一个返回备注对象（若无备注则返回 `null`）的[method](https://reference.aspose.com/slides/zh/php-java/aspose.slides/notesslidemanager/getnotesslide/)。

**库在不同的 PowerPoint 版本中对备注的支持是否存在差异？**

该库面向广泛的 Microsoft PowerPoint 格式（97 及以后版本）以及 ODP；在这些格式中均支持备注，且不依赖于已安装的 PowerPoint 副本。