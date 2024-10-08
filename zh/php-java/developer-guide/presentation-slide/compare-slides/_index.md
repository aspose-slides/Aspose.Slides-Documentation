---
title: 比较幻灯片
type: docs
weight: 50
url: /zh/php-java/compare-slides/
---

## **比较两个幻灯片**
Equals 方法已添加到 [IBaseSlide](https://reference.aspose.com/slides/php-java/aspose.slides/IBaseSlide) 接口和 [BaseSlide](https://reference.aspose.com/slides/php-java/aspose.slides/BaseSlide) 类。它对于在结构和静态内容上相同的幻灯片/布局和幻灯片/母版幻灯片返回 true。

如果所有形状、样式、文本、动画和其他设置等都是相同的，则两个幻灯片是相等的。比较不考虑唯一标识符值，例如 SlideId 和动态内容，例如日期占位符中的当前日期值。

```php
  $presentation1 = new Presentation("AccessSlides.pptx");
  try {
    $presentation2 = new Presentation("HelloWorld.pptx");
    try {
      for($i = 0; $i < java_values($presentation1->getMasters()->size()) ; $i++) {
        for($j = 0; $j < java_values($presentation2->getMasters()->size()) ; $j++) {
          if ($presentation1->getMasters()->get_Item($i)->equals($presentation2->getMasters()->get_Item($j))) {
            echo(sprintf("SomePresentation1 主幻灯片#%d 等于 SomePresentation2 主幻灯片#%d", $i, $j));
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