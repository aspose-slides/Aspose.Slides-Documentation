---
title: 在 PHP 中比较演示文稿幻灯片
linktitle: 比较幻灯片
type: docs
weight: 50
url: /zh/php-java/compare-slides/
keywords:
- 比较幻灯片
- 幻灯片比较
- PowerPoint
- OpenDocument
- 演示文稿
- PHP
- Aspose.Slides
description: "通过 Java 为 PHP 的 Aspose.Slides，以编程方式比较 PowerPoint 和 OpenDocument 演示文稿。快速在代码中识别幻灯片差异。"
---

## **比较两个幻灯片**
已在[BaseSlide](https://reference.aspose.com/slides/php-java/aspose.slides/BaseSlide)类中添加了 Equals 方法。该方法对结构和静态内容相同的幻灯片/布局和母版幻灯片返回 true。

如果所有形状、样式、文本、动画和其他设置等全部相同，则两个幻灯片相等。比较不考虑唯一标识符值，例如 SlideId，以及动态内容，例如日期占位符中的当前日期值。
```php
  $presentation1 = new Presentation("AccessSlides.pptx");
  try {
    $presentation2 = new Presentation("HelloWorld.pptx");
    try {
      for($i = 0; $i < java_values($presentation1->getMasters()->size()) ; $i++) {
        for($j = 0; $j < java_values($presentation2->getMasters()->size()) ; $j++) {
          if ($presentation1->getMasters()->get_Item($i)->equals($presentation2->getMasters()->get_Item($j))) {
            echo(sprintf("SomePresentation1 MasterSlide#%d is equal to SomePresentation2 MasterSlide#%d", $i, $j));
          }
        }
      }
    } finally {
      $presentation2->dispose();
    }
  } finally {
    $presentation1->dispose();
  }
```


## **常见问题**

**幻灯片被隐藏是否会影响对幻灯片本身的比较？**

[Hidden status](https://reference.aspose.com/slides/php-java/aspose.slides/slide/gethidden/) 是演示/播放级别的属性，而非可视内容。两个特定幻灯片的相等性由它们的结构和静态内容决定，仅仅因为幻灯片被隐藏并不会使它们不同。

**超链接及其参数会被考虑吗？**

是的。超链接是幻灯片静态内容的一部分。如果 URL 或超链接操作不同，通常会被视为静态内容的差异。

**如果图表引用了外部 Excel 文件，是否会考虑该文件的内容？**

不会。比较仅基于幻灯片本身进行。外部数据源通常不会在比较时读取；只会考虑幻灯片结构和静态状态中存在的内容。