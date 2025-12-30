---
title: إضافة أشكال الخط إلى العروض التقديمية في PHP
linktitle: خط
type: docs
weight: 50
url: /ar/php-java/Line/
keywords:
- خط
- إنشاء خط
- إضافة خط
- خط بسيط
- تكوين الخط
- تخصيص الخط
- نمط الشرط
- رأس السهم
- PowerPoint
- عرض تقديمي
- PHP
- Aspose.Slides
description: "تعلم كيفية تعديل تنسيق الخط في عروض PowerPoint التقديمية باستخدام Aspose.Slides for PHP عبر Java. اكتشف الخصائص والطرق والأمثلة."
---

{{% alert color="primary" %}} 

يدعم Aspose.Slides for PHP عبر Java إضافة أنواع مختلفة من الأشكال إلى الشرائح. في هذا الموضوع، سنبدأ العمل مع الأشكال عن طريق إضافة خطوط إلى الشرائح. باستخدام Aspose.Slides for PHP عبر Java، يمكن للمطورين ليس فقط إنشاء خطوط بسيطة، بل يمكن أيضًا رسم خطوط مزخرفة على الشرائح.

{{% /alert %}} 

## **إنشاء خط بسيط**

- إنشاء مثيل من الفئة [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/Presentation) .
- الحصول على مرجع شريحة باستخدام الفهرس الخاص بها.
- إضافة AutoShape من نوع خط باستخدام الطريقة [addAutoShape](https://reference.aspose.com/slides/php-java/aspose.slides/IShapeCollection#addAutoShape-int-float-float-float-float-) التي يوفرها كائن [IShapeCollection](https://reference.aspose.com/slides/php-java/aspose.slides/IShapeCollection) .
- حفظ العرض المُعدَّل كملف PPTX.

في المثال الموضح أدناه، أضفنا خطًا إلى الشريحة الأولى من العرض.
```php
  # إنشاء كائن من الفئة PresentationEx التي تمثل ملف PPTX
  $pres = new Presentation();
  try {
    # الحصول على الشريحة الأولى
    $sld = $pres->getSlides()->get_Item(0);
    # إضافة AutoShape من النوع خط
    $sld->getShapes()->addAutoShape(ShapeType::Line, 50, 150, 300, 0);
    # كتابة ملف PPTX إلى القرص
    $pres->save("LineShape.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```


## **إنشاء خط على شكل سهم**

- إنشاء مثيل من الفئة [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/Presentation) .
- الحصول على مرجع شريحة باستخدام الفهرس الخاص بها.
- إضافة AutoShape من نوع خط باستخدام الطريقة [addAutoShape](https://reference.aspose.com/slides/php-java/aspose.slides/IShapeCollection#addAutoShape-int-float-float-float-float-) التي يوفرها كائن [IShapeCollection](https://reference.aspose.com/slides/php-java/aspose.slides/IShapeCollection) .
- تحديد [Line Style](https://reference.aspose.com/slides/php-java/aspose.slides/LineStyle) إلى أحد الأنماط المتاحة في Aspose.Slides for PHP عبر Java.
- تحديد عرض الخط.
- تحديد [Dash Style](https://reference.aspose.com/slides/php-java/aspose.slides/LineDashStyle) للخط إلى أحد الأنماط المتاحة في Aspose.Slides for PHP عبر Java.
- تحديد [Arrow Head Style](https://reference.aspose.com/slides/php-java/aspose.slides/LineArrowheadStyle) و[Length](https://reference.aspose.com/slides/php-java/aspose.slides/LineArrowheadLength) لنقطة البداية للخط.
- تحديد [Arrow Head Style](https://reference.aspose.com/slides/php-java/aspose.slides/LineArrowheadStyle) و[Length](https://reference.aspose.com/slides/php-java/aspose.slides/LineArrowheadLength) لنقطة النهاية للخط.
- حفظ العرض المُعدَّل كملف PPTX.
```php
  # إنشاء كائن من الفئة PresentationEx التي تمثل ملف PPTX
  $pres = new Presentation();
  try {
    # الحصول على الشريحة الأولى
    $sld = $pres->getSlides()->get_Item(0);
    # إضافة AutoShape من النوع خط
    $shp = $sld->getShapes()->addAutoShape(ShapeType::Line, 50, 150, 300, 0);
    # تطبيق بعض التنسيق على الخط
    $shp->getLineFormat()->setStyle(LineStyle->ThickBetweenThin);
    $shp->getLineFormat()->setWidth(10);
    $shp->getLineFormat()->setDashStyle(LineDashStyle->DashDot);
    $shp->getLineFormat()->setBeginArrowheadLength(LineArrowheadLength->Short);
    $shp->getLineFormat()->setBeginArrowheadStyle(LineArrowheadStyle->Oval);
    $shp->getLineFormat()->setEndArrowheadLength(LineArrowheadLength->Long);
    $shp->getLineFormat()->setEndArrowheadStyle(LineArrowheadStyle->Triangle);
    $shp->getLineFormat()->getFillFormat()->setFillType(FillType::Solid);
    $shp->getLineFormat()->getFillFormat()->getSolidFillColor()->setColor(new java("java.awt.Color", PresetColor->Maroon));
    # كتابة ملف PPTX إلى القرص
    $pres->save("LineShape.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```


## **الأسئلة المتكررة**

**هل يمكنني تحويل خط عادي إلى موصل بحيث "ينطبق" على الأشكال؟**

لا. الخط العادي (‏[AutoShape](https://reference.aspose.com/slides/php-java/aspose.slides/autoshape/) من النوع [Line](https://reference.aspose.com/slides/php-java/aspose.slides/shapetype/)) لا يتحول تلقائيًا إلى موصل. لجعله يلتصق بالأشكال، استخدم النوع المخصص [Connector](https://reference.aspose.com/slides/php-java/aspose.slides/connector/) و[APIs المقابلة](/slides/ar/php-java/connector/) للاتصالات.

**ماذا أفعل إذا كانت خصائص الخط موروثة من السمة ومن الصعب تحديد القيم النهائية؟**

[اقرأ الخصائص الفعالة](/slides/ar/php-java/shape-effective-properties/) عبر `LineFormatEffectiveData`/`LineFillFormatEffectiveData` — هذه الخصائص تأخذ بالفعل في الاعتبار الوراثة وأنماط السمة.

**هل يمكنني قفل خط لمنع التعديل (النقل، تغيير الحجم)؟**

نعم. تقدم الأشكال [كائنات القفل](https://reference.aspose.com/slides/php-java/aspose.slides/autoshape/getautoshapelock/) التي تتيح لك [منع عمليات التعديل](/slides/ar/php-java/applying-protection-to-presentation/).