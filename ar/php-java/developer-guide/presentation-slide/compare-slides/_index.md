---
title: مقارنة الشرائح
type: docs
weight: 50
url: /ar/php-java/compare-slides/
---

## **مقارنة شريحتين**
تمت إضافة طريقة Equals إلى واجهة [IBaseSlide](https://reference.aspose.com/slides/php-java/aspose.slides/IBaseSlide) و فئة [BaseSlide](https://reference.aspose.com/slides/php-java/aspose.slides/BaseSlide). إنها تُرجع true للشرائح/النماذج و الشرائح/الشرائح الرئيسية التي تتطابق من حيث الهيكل والمحتوى الثابت.

تكون شرائختين متساويتين إذا كانت جميع الأشكال، الأنماط، النصوص، الرسوم المتحركة وغيرها من الإعدادات، إلخ، متساوية. لا تأخذ المقارنة في الاعتبار القيم الفريدة للمعرفات، مثل SlideId والمحتوى الديناميكي، مثل قيمة التاريخ الحالي في مكان التاريخ.

```php
  $presentation1 = new Presentation("AccessSlides.pptx");
  try {
    $presentation2 = new Presentation("HelloWorld.pptx");
    try {
      for($i = 0; $i < java_values($presentation1->getMasters()->size()) ; $i++) {
        for($j = 0; $j < java_values($presentation2->getMasters()->size()) ; $j++) {
          if ($presentation1->getMasters()->get_Item($i)->equals($presentation2->getMasters()->get_Item($j))) {
            echo(sprintf("SomePresentation1 MasterSlide#%d متساوي مع SomePresentation2 MasterSlide#%d", $i, $j));
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