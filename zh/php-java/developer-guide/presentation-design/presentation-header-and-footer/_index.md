---
title: 在 PHP 中管理演示文稿页眉和页脚
linktitle: 页眉和页脚
type: docs
weight: 140
url: /zh/php-java/presentation-header-and-footer/
keywords:
- 页眉
- 页眉文字
- 页脚
- 页脚文字
- 设置页眉
- 设置页脚
- 讲义
- 备注
- PowerPoint
- OpenDocument
- 演示文稿
- PHP
- Aspose.Slides
description: "使用 Aspose.Slides for PHP via Java 在 PowerPoint 和 OpenDocument 演示文稿中添加和自定义页眉和页脚，以获得专业外观。"
---

{{% alert color="primary" %}} 

[Aspose.Slides](/slides/zh/php-java/) 提供对幻灯片页眉和页脚文本的支持，这些文本实际上在幻灯片母版层面上维护。

{{% /alert %}} 

[Aspose.Slides for PHP via Java](/slides/zh/php-java/) 提供在演示文稿幻灯片内管理页眉和页脚的功能。这些实际上在演示文稿母版层面上进行管理。

## **在演示文稿中管理页眉和页脚**
可以删除某些特定幻灯片的备注，如下例所示：
```php
  # 加载演示文稿
  $pres = new Presentation("headerTest.pptx");
  try {
    # 设置页脚
    $pres->getHeaderFooterManager()->setAllFootersText("My Footer text");
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


## **在讲义和备注幻灯片上管理页眉和页脚**
Aspose.Slides for PHP via Java 支持在讲义和备注幻灯片中使用页眉和页脚。请按照以下步骤操作：

- 加载包含视频的 [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/Presentation)。
- 更改备注母版和所有备注幻灯片的页眉和页脚设置。
- 设置主备注幻灯片以及所有子页脚占位符可见。
- 设置主备注幻灯片以及所有子日期和时间占位符可见。
- 仅更改第一张备注幻灯片的页眉和页脚设置。
- 设置备注幻灯片的页眉占位符可见。
- 为备注幻灯片的页眉占位符设置文本。
- 为备注幻灯片的日期时间占位符设置文本。
- 写入修改后的演示文稿文件。

以下示例提供了代码片段。
```php
  $pres = new Presentation("presentation.pptx");
  try {
    # 更改备注母版和所有备注幻灯片的页眉和页脚设置
    $masterNotesSlide = $pres->getMasterNotesSlideManager()->getMasterNotesSlide();
    if (!java_is_null($masterNotesSlide)) {
      $headerFooterManager = $masterNotesSlide->getHeaderFooterManager();
      $headerFooterManager->setHeaderAndChildHeadersVisibility(true);// 使主备注幻灯片和所有子页脚占位符可见

      $headerFooterManager->setFooterAndChildFootersVisibility(true);// 使主备注幻灯片和所有子页眉占位符可见

      $headerFooterManager->setSlideNumberAndChildSlideNumbersVisibility(true);// 使主备注幻灯片和所有子幻灯片编号占位符可见

      $headerFooterManager->setDateTimeAndChildDateTimesVisibility(true);// 使主备注幻灯片和所有子日期时间占位符可见

      $headerFooterManager->setHeaderAndChildHeadersText("Header text");// 将文本设置到主备注幻灯片和所有子页眉占位符

      $headerFooterManager->setFooterAndChildFootersText("Footer text");// 将文本设置到主备注幻灯片和所有子页脚占位符

      $headerFooterManager->setDateTimeAndChildDateTimesText("Date and time text");// 将文本设置到主备注幻灯片和所有子日期时间占位符

    }
    # 更改仅第一张备注幻灯片的页眉和页脚设置
    $notesSlide = $pres->getSlides()->get_Item(0)->getNotesSlideManager()->getNotesSlide();
    if (!java_is_null($notesSlide)) {
      $headerFooterManager = $notesSlide->getHeaderFooterManager();
      if (!$headerFooterManager->isHeaderVisible()) {
        $headerFooterManager->setHeaderVisibility(true);
      }// 使此备注幻灯片的页眉占位符可见

      if (!$headerFooterManager->isFooterVisible()) {
        $headerFooterManager->setFooterVisibility(true);
      }// 使此备注幻灯片的页脚占位符可见

      if (!$headerFooterManager->isSlideNumberVisible()) {
        $headerFooterManager->setSlideNumberVisibility(true);
      }// 使此备注幻灯片的幻灯片编号占位符可见

      if (!$headerFooterManager->isDateTimeVisible()) {
        $headerFooterManager->setDateTimeVisibility(true);
      }// 使此备注幻灯片的日期时间占位符可见

      $headerFooterManager->setHeaderText("New header text");// 将文本设置到备注幻灯片的页眉占位符

      $headerFooterManager->setFooterText("New footer text");// 将文本设置到备注幻灯片的页脚占位符

      $headerFooterManager->setDateTimeText("New date and time text");// 将文本设置到备注幻灯片的日期时间占位符

    }
    $pres->save("testresult.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```


## **常见问题**

**我可以在普通幻灯片中添加“页眉”吗？**

在 PowerPoint 中，“页眉”仅在备注页和讲义页中存在；在普通幻灯片上，支持的元素是页脚、日期/时间和幻灯片编号。在 Aspose.Slides 中也遵循相同的限制：页眉仅适用于备注/讲义，而在幻灯片上只能使用页脚、日期时间和幻灯片编号。

**如果布局中没有页脚区域，我可以“打开”其可见性吗？**

可以。通过页眉/页脚管理器检查可见性并在需要时启用它。这些 API 标识和方法专为占位符缺失或隐藏的情况设计。

**如何让幻灯片编号从除 1 之外的值开始？**

设置演示文稿的 [first slide number](https://reference.aspose.com/slides/php-java/aspose.slides/presentation/setfirstslidenumber/)；随后所有编号都会重新计算。例如，你可以从 0 或 10 开始，并在标题幻灯片上隐藏编号。

**在导出为 PDF/图像/HTML 时，页眉/页脚会怎样？**

它们会作为演示文稿的普通文本元素进行渲染。也就是说，如果这些元素在幻灯片/备注页上是可见的，它们也会在输出格式中出现，并与其他内容一起显示。