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
- خط عادي
- تهيئة خط
- تخصيص خط
- نمط واطئ
- رأس السهم
- PowerPoint
- عرض تقديمي
- PHP
- Aspose.Slides
description: "تعرّف على كيفية معالجة تنسيق الخطوط في عروض PowerPoint التقديمية باستخدام Aspose.Slides لِـ PHP عبر Java. اكتشف الخصائص والطرق والأمثلة."
---

{{% alert color="primary" %}} 

تدعم Aspose.Slides لـ PHP عبر Java إضافة أنواع مختلفة من الأشكال إلى الشرائح. في هذا الموضوع، سنبدأ العمل مع الأشكال بإضافة خطوط إلى الشرائح. باستخدام Aspose.Slides لـ PHP عبر Java، يمكن للمطورين ليس فقط إنشاء خطوط بسيطة، بل يمكن أيضًا رسم خطوط متنوعة على الشرائح.

{{% /alert %}} 

## **إنشاء خط عادي**

لإضافة خط عادي بسيط إلى شريحة مختارة من العرض التقديمي، يرجى اتباع الخطوات أدناه:

- إنشاء مثال من الفئة [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/Presentation) class.
- الحصول على مرجع الشريحة باستخدام فهرسها.
- إضافة AutoShape من نوع Line باستخدام الطريقة [addAutoShape](https://reference.aspose.com/slides/php-java/aspose.slides/shapecollection/#addAutoShape) التي يوفرها كائن [ShapeCollection](https://reference.aspose.com/slides/php-java/aspose.slides/shapecollection/).
- كتابة العرض التقديمي المعدل كملف PPTX.

في المثال المعطى أدناه، قمنا بإضافة خط إلى الشريحة الأولى من العرض التقديمي.
```php
  # إنشاء كائن PresentationEx الذي يمثل ملف PPTX
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

تسمح Aspose.Slides لـ PHP عبر Java أيضًا للمطورين بتكوين بعض خصائص الخط لجعله أكثر جاذبية. دعونا نجرب تكوين بعض خصائص الخط لجعله يبدو كسهم. يرجى اتباع الخطوات أدناه للقيام بذلك:

- إنشاء مثال من الفئة [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/Presentation) class.
- الحصول على مرجع الشريحة باستخدام فهرسها.
- إضافة AutoShape من نوع Line باستخدام الطريقة [addAutoShape](https://reference.aspose.com/slides/php-java/aspose.slides/shapecollection/#addAutoShape) التي يوفرها كائن [ShapeCollection](https://reference.aspose.com/slides/php-java/aspose.slides/shapecollection/).
- تعيين [Line Style](https://reference.aspose.com/slides/php-java/aspose.slides/LineStyle) إلى أحد الأنماط التي تقدمها Aspose.Slides لـ PHP عبر Java.
- تعيين عرض الخط.
- تعيين [Dash Style](https://reference.aspose.com/slides/php-java/aspose.slides/LineDashStyle) للخط إلى أحد الأنماط التي تقدمها Aspose.Slides لـ PHP عبر Java.
- تعيين [Arrow Head Style](https://reference.aspose.com/slides/php-java/aspose.slides/LineArrowheadStyle) و[Length](https://reference.aspose.com/slides/php-java/aspose.slides/LineArrowheadLength) لنقطة بداية الخط.
- تعيين [Arrow Head Style](https://reference.aspose.com/slides/php-java/aspose.slides/LineArrowheadStyle) و[Length](https://reference.aspose.com/slides/php-java/aspose.slides/LineArrowheadLength) لنقطة نهاية الخط.
- كتابة العرض التقديمي المعدل كملف PPTX.
```php
  # إنشاء كائن PresentationEx الذي يمثل ملف PPTX
  $pres = new Presentation();
  try {
    # الحصول على الشريحة الأولى
    $sld = $pres->getSlides()->get_Item(0);
    # إضافة AutoShape من النوع خط
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
    # كتابة ملف PPTX إلى القرص
    $pres->save("LineShape.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```


## **الأسئلة الشائعة**

**هل يمكنني تحويل خط عادي إلى موصل بحيث "يلتقط" الأشكال؟**

لا. الخط العادي (وهو [AutoShape](https://reference.aspose.com/slides/php-java/aspose.slides/autoshape/) من النوع [Line](https://reference.aspose.com/slides/php-java/aspose.slides/shapetype/)) لا يتحول تلقائيًا إلى موصل. لجعله يلتقط الأشكال، استخدم النوع المخصص [Connector](https://reference.aspose.com/slides/php-java/aspose.slides/connector/) والـ [corresponding APIs](/slides/ar/php-java/connector/) للاتصالات.

**ماذا أفعل إذا كانت خصائص الخط موروثة من السمة ومن الصعب تحديد القيم النهائية؟**

[قراءة الخصائص الفعالة](/slides/ar/php-java/shape-effective-properties/) عبر `LineFormatEffectiveData`/`LineFillFormatEffectiveData` — هذه بالفعل تأخذ في الاعتبار الوراثة وأنماط السمة.

**هل يمكنني قفل خط لمنعه من التحرير (النقل، تغيير الحجم)؟**

نعم. توفر الأشكال [lock objects](https://reference.aspose.com/slides/php-java/aspose.slides/autoshape/getautoshapelock/) التي تسمح لك بمنع عمليات التحرير.