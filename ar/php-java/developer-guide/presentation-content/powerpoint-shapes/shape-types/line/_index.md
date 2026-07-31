---
title: إضافة أشكال خطوط إلى العروض التقديمية في PHP
linktitle: خط
type: docs
weight: 50
url: /ar/php-java/line/
keywords:
- خط
- إنشاء خط
- إضافة خط
- خط عادي
- تكوين خط
- تخصيص خط
- نمط المتقطع
- رأس السهم
- PowerPoint
- عرض تقديمي
- PHP
- Aspose.Slides
description: "تعرّف على كيفية تعديل تنسيق الخط في عروض PowerPoint التقديمية باستخدام Aspose.Slides للـ PHP عبر Java. اكتشف الخصائص، والطرق، والأمثلة."
---
## **نظرة عامة**

Aspose.Slides يتيح لك إضافة أشكال خطوط إلى شرائح PowerPoint برمجيًا. توضح هذه المقالة كيفية إنشاء خط بسيط وكيفية تخصيص الخط لجعله يظهر كسهم.

ستتعلم كيفية إضافة شكل خط إلى شريحة، وضبط مظهره البصري، وحفظ العرض المحدث. تركز الأمثلة على إعدادات تنسيق الخط العملية مثل النمط، العرض، نمط الشرط، خيارات رأس السهم، ولون التعبئة.

## **إنشاء خط بسيط**

لإضافة خط بسيط إلى شريحة مختارة من العرض، يرجى اتباع الخطوات التالية:

- إنشاء كائن من الفئة [Presentation](https://reference.aspose.com/slides/ar/php-java/aspose.slides/Presentation) .
- الحصول على مرجع الشريحة باستخدام فهرستها.
- إضافة AutoShape من النوع Line باستخدام طريقة [addAutoShape](https://reference.aspose.com/slides/ar/php-java/aspose.slides/shapecollection/#addAutoShape) المعروضة بواسطة كائن [ShapeCollection](https://reference.aspose.com/slides/ar/php-java/aspose.slides/shapecollection/) .
- كتابة العرض المعدل كملف PPTX.

في المثال المقدم أدناه، أضفنا خطًا إلى الشريحة الأولى من العرض.

```php
  # إنشاء كائن من فئة PresentationEx التي تمثل ملف PPTX
  $pres = new Presentation();
  try {
    # الحصول على الشريحة الأولى
    $sld = $pres->getSlides()->get_Item(0);
    # إضافة AutoShape من النوع line
    $sld->getShapes()->addAutoShape(ShapeType::Line, 50, 150, 300, 0);
    # حفظ PPTX إلى القرص
    $pres->save("LineShape.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

## **إنشاء خط على شكل سهم**

Aspose.Slides for PHP via Java يسمح للمطورين أيضًا بتكوين بعض خصائص الخط لجعله أكثر جاذبية. دعنا نحاول تكوين بعض خصائص الخط لجعله يبدو كسهم. يرجى اتباع الخطوات التالية للقيام بذلك:

- إنشاء كائن من الفئة [Presentation](https://reference.aspose.com/slides/ar/php-java/aspose.slides/Presentation) .
- الحصول على مرجع الشريحة باستخدام فهرستها.
- إضافة AutoShape من النوع Line باستخدام طريقة [addAutoShape](https://reference.aspose.com/slides/ar/php-java/aspose.slides/shapecollection/#addAutoShape) المعروضة بواسطة كائن [ShapeCollection](https://reference.aspose.com/slides/ar/php-java/aspose.slides/shapecollection/) .
- تعيين [Line Style](https://reference.aspose.com/slides/ar/php-java/aspose.slides/LineStyle) إلى أحد الأنماط المتوفرة في Aspose.Slides for PHP via Java.
- تعيين عرض الخط.
- تعيين [Dash Style](https://reference.aspose.com/slides/ar/php-java/aspose.slides/LineDashStyle) للخط إلى أحد الأنماط المتوفرة.
- تعيين [Arrow Head Style](https://reference.aspose.com/slides/ar/php-java/aspose.slides/LineArrowheadStyle) و[Length](https://reference.aspose.com/slides/ar/php-java/aspose.slides/LineArrowheadLength) لنقطة البداية للخط.
- تعيين [Arrow Head Style](https://reference.aspose.com/slides/ar/php-java/aspose.slides/LineArrowheadStyle) و[Length](https://reference.aspose.com/slides/ar/php-java/aspose.slides/LineArrowheadLength) لنقطة النهاية للخط.
- كتابة العرض المعدل كملف PPTX.

```php
  # إنشاء كائن من فئة PresentationEx التي تمثل ملف PPTX
  $pres = new Presentation();
  try {
    # الحصول على الشريحة الأولى
    $sld = $pres->getSlides()->get_Item(0);
    # إضافة AutoShape من النوع line
    $shp = $sld->getShapes()->addAutoShape(ShapeType::Line, 50, 150, 300, 0);
    # تطبيق بعض التنسيقات على الخط
    $shp->getLineFormat()->setStyle(LineStyle->ThickBetweenThin);
    $shp->getLineFormat()->setWidth(10);
    $shp->getLineFormat()->setDashStyle(LineDashStyle->DashDot);
    $shp->getLineFormat()->setBeginArrowheadLength(LineArrowheadLength->Short);
    $shp->getLineFormat()->setBeginArrowheadStyle(LineArrowheadStyle->Oval);
    $shp->getLineFormat()->setEndArrowheadLength(LineArrowheadLength->Long);
    $shp->getLineFormat()->setEndArrowheadStyle(LineArrowheadStyle->Triangle);
    $shp->getLineFormat()->getFillFormat()->setFillType(FillType::Solid);
    $shp->getLineFormat()->getFillFormat()->getSolidFillColor()->setColor(new java("java.awt.Color", PresetColor->Maroon));
    # حفظ PPTX إلى القرص
    $pres->save("LineShape.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

## **FAQ**

**هل يمكنني تحويل خط عادي إلى موصل بحيث "يلتصق" بالأشكال؟**

لا. الخط العادي (AutoShape من النوع Line) لا يتحول تلقائيًا إلى موصل. لجعله يلصق بالأشكال، استخدم النوع المخصص [Connector](https://reference.aspose.com/slides/ar/php-java/aspose.slides/connector/) والواجهات البرمجية المقابلة [/slides/ar/php-java/connector/] للاتصالات.

**ماذا أفعل إذا كان خصائص الخط موروثة من السمة ويصعب تحديد القيم النهائية؟**

[Read the effective properties](/slides/ar/php-java/shape-effective-properties/) عبر `LineFormatEffectiveData`/`LineFillFormatEffectiveData` — هذه القيم تأخذ بالفعل في الاعتبار الوراثة وأنماط السمة.

**هل يمكنني قفل الخط ضد التعديل (التحريك، تغيير الحجم)؟**

نعم. توفر الأشكال [lock objects](https://reference.aspose.com/slides/ar/php-java/aspose.slides/autoshape/getautoshapelock/) التي تسمح بمنع عمليات التعديل.