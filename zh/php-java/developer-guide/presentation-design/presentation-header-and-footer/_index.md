---
title: 演示文稿页眉和页脚
type: docs
weight: 140
url: /zh/php-java/presentation-header-and-footer/
keywords: "PowerPoint 页眉和页脚"
description: "PowerPoint 页眉和页脚"
---

{{% alert color="primary" %}} 

[Aspose.Slides](/slides/zh/php-java/) 提供了对幻灯片页眉和页脚文本的支持，这些文本实际上是在幻灯片母版级别维护的。

{{% /alert %}} 

[Aspose.Slides for PHP via Java](/slides/zh/php-java/) 提供了在演示文稿幻灯片内部管理页眉和页脚的功能。这些实际上是在演示文稿母版级别管理的。

## **在演示文稿中管理页眉和页脚**
某些特定幻灯片的备注可以按如下示例删除：

```php
  # 加载演示文稿
  $pres = new Presentation("headerTest.pptx");
  try {
    # 设置页脚
    $pres->getHeaderFooterManager()->setAllFootersText("我的页脚文本");
    $pres->getHeaderFooterManager()->setAllFootersVisibility(true);
    # 访问并更新页眉
    $masterNotesSlide = $pres->getMasterNotesSlideManager()->getMasterNotesSlide();
    if (null != $masterNotesSlide) {
      updateHeaderFooterText($masterNotesSlide);
    }
    # 保存演示文稿
    $pres->save("HeaderFooterJava.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```
```php

```

## **在讲义和备注幻灯片中管理页眉和页脚**
Aspose.Slides for PHP via Java 支持讲义和备注幻灯片中的页眉和页脚。请按照以下步骤操作：

- 加载包含视频的 [演示文稿](https://reference.aspose.com/slides/php-java/aspose.slides/Presentation)。
- 更改备注母版和所有备注幻灯片的页眉和页脚设置。
- 设置母版备注幻灯片和所有子项页脚占位符可见。
- 设置母版备注幻灯片和所有子项日期和时间占位符可见。
- 仅更改第一个备注幻灯片的页眉和页脚设置。
- 设置备注幻灯片页眉占位符可见。
- 设置备注幻灯片页眉占位符的文本。
- 设置备注幻灯片日期时间占位符的文本。
- 写入修改后的演示文稿文件。

代码片段在以下示例中提供。

```php
  $pres = new Presentation("presentation.pptx");
  try {
    # 更改备注母版和所有备注幻灯片的页眉和页脚设置
    $masterNotesSlide = $pres->getMasterNotesSlideManager()->getMasterNotesSlide();
    if (!java_is_null($masterNotesSlide)) {
      $headerFooterManager = $masterNotesSlide->getHeaderFooterManager();
      $headerFooterManager->setHeaderAndChildHeadersVisibility(true);// 使母版备注幻灯片和所有子项页脚占位符可见

      $headerFooterManager->setFooterAndChildFootersVisibility(true);// 使母版备注幻灯片和所有子项页眉占位符可见

      $headerFooterManager->setSlideNumberAndChildSlideNumbersVisibility(true);// 使母版备注幻灯片和所有子项幻灯片编号占位符可见

      $headerFooterManager->setDateTimeAndChildDateTimesVisibility(true);// 使母版备注幻灯片和所有子项日期和时间占位符可见

      $headerFooterManager->setHeaderAndChildHeadersText("页眉文本");// 设置文本到母版备注幻灯片和所有子项页眉占位符

      $headerFooterManager->setFooterAndChildFootersText("页脚文本");// 设置文本到母版备注幻灯片和所有子项页脚占位符

      $headerFooterManager->setDateTimeAndChildDateTimesText("日期和时间文本");// 设置文本到母版备注幻灯片和所有子项日期和时间占位符

    }
    # 仅更改第一个备注幻灯片的页眉和页脚设置
    $notesSlide = $pres->getSlides()->get_Item(0)->getNotesSlideManager()->getNotesSlide();
    if (!java_is_null($notesSlide)) {
      $headerFooterManager = $notesSlide->getHeaderFooterManager();
      if (!$headerFooterManager->isHeaderVisible()) {
        $headerFooterManager->setHeaderVisibility(true);
      }// 使此备注幻灯片页眉占位符可见

      if (!$headerFooterManager->isFooterVisible()) {
        $headerFooterManager->setFooterVisibility(true);
      }// 使此备注幻灯片页脚占位符可见

      if (!$headerFooterManager->isSlideNumberVisible()) {
        $headerFooterManager->setSlideNumberVisibility(true);
      }// 使此备注幻灯片幻灯片编号占位符可见

      if (!$headerFooterManager->isDateTimeVisible()) {
        $headerFooterManager->setDateTimeVisibility(true);
      }// 使此备注幻灯片日期时间占位符可见

      $headerFooterManager->setHeaderText("新页眉文本");// 设置文本到备注幻灯片页眉占位符

      $headerFooterManager->setFooterText("新页脚文本");// 设置文本到备注幻灯片页脚占位符

      $headerFooterManager->setDateTimeText("新日期和时间文本");// 设置文本到备注幻灯片日期时间占位符

    }
    $pres->save("testresult.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```