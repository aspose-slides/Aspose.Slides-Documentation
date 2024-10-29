---
title: إنشاء عرض باور بوينت باستخدام PHP
linktitle: إنشاء عرض تقديمي
type: docs
weight: 10
url: /ar/php-java/create-presentation/
keywords: إنشاء ppt جافا، إنشاء عرض تقديمي ppt، إنشاء pptx جافا
description: تعلم كيفية إنشاء عروض باور بوينت مثل PPT و PPTX باستخدام PHP من الصفر.
---

## **إنشاء عرض باور بوينت**
لإضافة خط بسيط إلى شريحة محددة من العرض، يرجى اتباع الخطوات أدناه:

1. أنشئ مثيلاً لفئة Presentation.
1. احصل على مرجع لشريحة باستخدام فهرسها.
1. أضف AutoShape من نوع خط باستخدام طريقة addAutoShape المعروضة بواسطة كائن Shapes.
1. اكتب العرض المعدل كملف PPTX.

في المثال المقدم أدناه، أضفنا خطًا إلى الشريحة الأولى من العرض.

```php
  # إنشاء كائن Presentation يمثل ملف عرض
  $pres = new Presentation();
  try {
    # احصل على الشريحة الأولى
    $slide = $pres->getSlides()->get_Item(0);
    # أضف شكلاً تلقائيًا من نوع خط
    $slide->getShapes()->addAutoShape(ShapeType::Line, 50, 150, 300, 0);
    $pres->save("NewPresentation_out.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```