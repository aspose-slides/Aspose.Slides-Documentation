---
title: إضافة إهليلجات إلى العروض التقديمية في PHP
linktitle: إهليلج
type: docs
weight: 30
url: /ar/php-java/ellipse/
keywords:
- إهليلج
- شكل
- إضافة إهليلج
- إنشاء إهليلج
- رسم إهليلج
- إهليلج منسق
- PowerPoint
- عرض تقديمي
- PHP
- Aspose.Slides
description: "تعرف على كيفية إنشاء وتنسيق ومعالجة أشكال الإهليلج في Aspose.Slides لـ PHP عبر Java عبر عروض PPT و PPTX — تشمل الأمثلة البرمجية."
---

{{% alert color="primary" %}} 

في هذا الموضوع، سنقدم للمطورين طريقة إضافة أشكال إهليلجية إلى الشرائح باستخدام Aspose.Slides for PHP via Java. يوفر Aspose.Slides for PHP via Java مجموعة أسهل من واجهات برمجة التطبيقات لرسم أنواع مختلفة من الأشكال ببضع أسطر من الشيفرة فقط.

{{% /alert %}} 

## **إنشاء إهليلج**
لإضافة إهليلج بسيط إلى شريحة مختارة من العرض التقديمي، يرجى اتباع الخطوات التالية:

- إنشاء نسخة من الفئة [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/presentation).
- الحصول على مرجع الشريحة باستخدام الفهرس الخاص بها.
- إضافة AutoShape من نوع Ellipse باستخدام الطريقة [addAutoShape](https://reference.aspose.com/slides/php-java/aspose.slides/shapecollection/#addAutoShape) التي توفرها كائن [ShapeCollection](https://reference.aspose.com/slides/php-java/aspose.slides/shapecollection/).
- حفظ العرض المعدل كملف PPTX.

في المثال المعطى أدناه، قمنا بإضافة إهليلج إلى الشريحة الأولى
```php
  # إنشاء كائن من الفئة Presentation التي تمثل ملف PPTX
  $pres = new Presentation();
  try {
    # الحصول على الشريحة الأولى
    $sld = $pres->getSlides()->get_Item(0);
    # إضافة AutoShape من نوع إهليلج
    $sld->getShapes()->addAutoShape(ShapeType::Ellipse, 50, 150, 150, 50);
    # كتابة ملف PPTX إلى القرص
    $pres->save("EllipseShp1.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```


## **إنشاء إهليلج مُنسق**
لإضافة إهليلج منسق بشكل أفضل إلى شريحة، يرجى اتباع الخطوات التالية:

- إنشاء نسخة من الفئة [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/presentation).
- الحصول على مرجع الشريحة باستخدام الفهرس الخاص بها.
- إضافة AutoShape من نوع Ellipse باستخدام الطريقة [addAutoShape](https://reference.aspose.com/slides/php-java/aspose.slides/shapecollection/#addAutoShape) التي توفرها كائن [ShapeCollection](https://reference.aspose.com/slides/php-java/aspose.slides/shapecollection/).
- تحديد نوع التعبئة للـ إهليلج إلى Solid.
- تحديد لون الإهليلج باستخدام الطريقة `SolidFillColor::setColor` التي توفرها كائن [FillFormat](https://reference.aspose.com/slides/php-java/aspose.slides/fillformat/) المرتبط بكائن [Shape](https://reference.aspose.com/slides/php-java/aspose.slides/shape/).
- تحديد لون خطوط الإهليلج.
- تحديد عرض خطوط الإهليلج.
- حفظ العرض المعدل كملف PPTX.

في المثال المعطى أدناه، قمنا بإضافة إهليلج منسق إلى الشريحة الأولى من العرض التقديمي.
```php
  # إنشاء كائن من الفئة Presentation التي تمثل ملف PPTX
  $pres = new Presentation();
  try {
    # الحصول على الشريحة الأولى
    $sld = $pres->getSlides()->get_Item(0);
    # إضافة AutoShape من نوع إهليلج
    $shp = $sld->getShapes()->addAutoShape(ShapeType::Ellipse, 50, 150, 150, 50);
    # تطبيق بعض التنسيقات على شكل الإهليلج
    $shp->getFillFormat()->setFillType(FillType::Solid);
    $shp->getFillFormat()->getSolidFillColor()->setColor(new java("java.awt.Color", PresetColor->Chocolate));
    # تطبيق بعض التنسيقات على خط الإهليلج
    $shp->getLineFormat()->getFillFormat()->setFillType(FillType::Solid);
    $shp->getLineFormat()->getFillFormat()->getSolidFillColor()->setColor(java("java.awt.Color")->BLACK);
    $shp->getLineFormat()->setWidth(5);
    # كتابة ملف PPTX إلى القرص
    $pres->save("EllipseShp1.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```


## **الأسئلة الشائعة**

**كيف يمكنني تحديد الموضع الدقيق وحجم الإهليلج بالنسبة لوحدات الشريحة؟**

عادةً ما يتم تحديد الإحداثيات والأحجام **بالنقاط**. للحصول على نتائج متوقعة، احسب على أساس حجم الشريحة وحول المليمترات أو الإنش المطلوبة إلى نقاط قبل تعيين القيم.

**كيف يمكنني وضع إهليلج فوق أو تحت كائنات أخرى (التحكم في ترتيب الطبقات)؟**

قم بتعديل ترتيب رسم الكائن عن طريق إحضاره إلى المقدمة أو إرساله إلى الخلف. هذا يسمح للإهليلج بتغطية الكائنات الأخرى أو إظهار ما تحتها.

**كيف يمكنني تحريك ظهور أو إبراز إهليلج؟**

[Apply](/slides/ar/php-java/shape-animation/) تأثيرات الدخول أو التأكيد أو الخروج على الشكل، وقم بتكوين المشغلات والوقت لتحديد متى وكيف يتم تشغيل الرسوم المتحركة.