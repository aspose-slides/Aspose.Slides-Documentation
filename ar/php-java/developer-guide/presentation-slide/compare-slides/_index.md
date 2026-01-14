---
title: مقارنة شرائح العرض في PHP
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
تمت إضافة طريقة Equals إلى فئة [BaseSlide](https://reference.aspose.com/slides/php-java/aspose.slides/BaseSlide). تُعيد القيمة true للشريحة/التخطيط والشريحة الرئيسة إذا كانت متطابقة من حيث البنية والمحتوى الثابت.  

تكون الشريحتان متساويتين إذا كانت جميع الأشكال والأنماط والنصوص والرسوم المتحركة والإعدادات الأخرى وما إلى ذلك متساوية. لا يأخذ المقارنة في الاعتبار قيم المعرف الفريد، مثل SlideId، ولا المحتوى الديناميكي، مثل قيمة التاريخ الحالية في العنصر النائب للdate.
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


## **الأسئلة المتكررة**

**هل يؤثر كون الشريحة مخفية على مقارنة الشريحتين نفسها؟**

[Hidden status](https://reference.aspose.com/slides/php-java/aspose.slides/slide/gethidden/) هي خاصية على مستوى العرض/التشغيل، ليست محتوى مرئي. يتم تحديد مساواة شريحتين محددتين بناءً على بنيتهما والمحتوى الثابت؛ مجرد كون الشريحة مخفية لا يجعل الشريحتين مختلفتين.

**هل يتم أخذ الروابط الفائقة ومعلماتها في الاعتبار؟**

نعم. الروابط هي جزء من المحتوى الثابت للشريحة. إذا كان عنوان URL أو إجراء الرابط مختلفًا، يُعامل عادة كاختلاف في المحتوى الثابت.

**إذا كانت المخطط يشير إلى ملف Excel خارجي، هل يُؤخذ محتوى ذلك الملف في الاعتبار؟**

لا. يتم إجراء المقارنة بناءً على الشريحتين نفسها. عادةً لا يتم قراءة مصادر البيانات الخارجية وقت المقارنة؛ فقط ما هو موجود في بنية الشريحة وحالتها الثابتة يُؤخذ في الاعتبار.