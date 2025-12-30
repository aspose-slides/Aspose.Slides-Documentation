---
title: مقارنة شرائح العرض التقديمي في PHP
linktitle: مقارنة الشرائح
type: docs
weight: 50
url: /ar/php-java/compare-slides/
keywords:
- مقارنة الشرائح
- مقارنة الشريحة
- PowerPoint
- OpenDocument
- عرض تقديمي
- PHP
- Aspose.Slides
description: "قارن عروض PowerPoint و OpenDocument برمجياً باستخدام Aspose.Slides للـ PHP عبر Java. حدد اختلافات الشرائح في الشيفرة بسرعة."
---

## **قارن شريحتين**
تمت إضافة طريقة Equals إلى واجهة [IBaseSlide](https://reference.aspose.com/slides/php-java/aspose.slides/IBaseSlide) والفئة [BaseSlide](https://reference.aspose.com/slides/php-java/aspose.slides/BaseSlide). تُعيد true للشرائح/التخطيط والشرائح الرئيسية التي تكون متطابقة في بنائها ومحتواها الثابت.

تُعَدّ شريحتان متساويتان إذا كانت جميع الأشكال والأنماط والنصوص والرسوم المتحركة وغيرها من الإعدادات ... متساوية. لا تأخذ المقارنة في الاعتبار قيم المعرفات الفريدة، مثل SlideId، ولا المحتوى الديناميكي، مثل قيمة التاريخ الحالية في عنصر العنصر النائب للتاريخ.
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


## **الأسئلة المتداولة**
**هل يؤثر إخفاء الشريحة على مقارنة الشرائح نفسها؟**
[حالة الإخفاء](https://reference.aspose.com/slides/php-java/aspose.slides/slide/gethidden/) هي خاصية على مستوى العرض/التشغيل، ليست محتوى بصريًا. تُحدد مساواة شريحتين محددتين من خلال بنيتهما ومحتواهما الثابت؛ فمجرد أن تكون شريحة مخفية لا يجعل الشرائح مختلفة.

**هل تُؤخذ الروابط الفائقة ومعلماتها في الاعتبار؟**
نعم. الروابط هي جزء من المحتوى الثابت للشريحة. إذا كان عنوان URL أو إجراء الرابط الفائق مختلفًا، يُعامل عادةً كاختلاف في المحتوى الثابت.

**إذا كان المخطط يشير إلى ملف Excel خارجي، هل يتم أخذ محتويات ذلك الملف في الاعتبار؟**
لا. تُجرى المقارنة بناءً على الشرائح نفسها. عادةً لا تُقرأ مصادر البيانات الخارجية أثناء المقارنة؛ فقط ما هو موجود في بنية الشريحة وحالتها الثابتة يُؤخذ في الاعتبار.