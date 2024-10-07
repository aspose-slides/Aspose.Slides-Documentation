---
title: خط
type: docs
weight: 50
url: /php-java/Line/
---


{{% alert color="primary" %}} 

Aspose.Slides لـ PHP عبر Java يدعم إضافة أنواع مختلفة من الأشكال إلى الشرائح. في هذا الموضوع، سنبدأ العمل مع الأشكال من خلال إضافة خطوط إلى الشرائح. باستخدام Aspose.Slides لـ PHP عبر Java، يمكن للمطورين ليس فقط إنشاء خطوط بسيطة، ولكن يمكن أيضًا رسم بعض الخطوط المعقدة على الشرائح.

{{% /alert %}} 

## **إنشاء خط بسيط**

لإضافة خط بسيط إلى شريحة مختارة من العرض التقديمي، يرجى اتباع الخطوات التالية:

- إنشاء مثيل من فئة [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/Presentation).
- الحصول على مرجع الشريحة باستخدام الفهرس الخاص بها.
- إضافة AutoShape من نوع الخط باستخدام طريقة [addAutoShape](https://reference.aspose.com/slides/php-java/aspose.slides/IShapeCollection#addAutoShape-int-float-float-float-float-) المعروضة بواسطة كائن [IShapeCollection](https://reference.aspose.com/slides/php-java/aspose.slides/IShapeCollection).
- كتابة العرض التقديمي المعدل كملف PPTX.

في المثال المعطى أدناه، أضفنا خطًا إلى الشريحة الأولى من العرض التقديمي.

```php
  # إنشاء مثيل من فئة PresentationEx التي تمثل ملف PPTX
  $pres = new Presentation();
  try {
    # الحصول على الشريحة الأولى
    $sld = $pres->getSlides()->get_Item(0);
    # إضافة AutoShape من نوع خط
    $sld->getShapes()->addAutoShape(ShapeType::Line, 50, 150, 300, 0);
    # كتابة PPTX إلى القرص
    $pres->save("LineShape.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

## **إنشاء خط على شكل سهم**

Aspose.Slides لـ PHP عبر Java يسمح أيضًا للمطورين بتكوين بعض خصائص الخط لجعله يبدو أكثر جاذبية. دعنا نحاول تكوين بعض خصائص الخط لكي يبدو كسهام. يرجى اتباع الخطوات التالية للقيام بذلك:

- إنشاء مثيل من فئة [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/Presentation).
- الحصول على مرجع الشريحة باستخدام الفهرس الخاص بها.
- إضافة AutoShape من نوع الخط باستخدام طريقة [addAutoShape](https://reference.aspose.com/slides/php-java/aspose.slides/IShapeCollection#addAutoShape-int-float-float-float-float-) المعروضة بواسطة كائن [IShapeCollection](https://reference.aspose.com/slides/php-java/aspose.slides/IShapeCollection).
- تعيين [نمط الخط](https://reference.aspose.com/slides/php-java/aspose.slides/LineStyle) إلى أحد الأنماط المعروضة بواسطة Aspose.Slides لـ PHP عبر Java.
- تعيين عرض الخط.
- تعيين [نمط التقطيع](https://reference.aspose.com/slides/php-java/aspose.slides/LineDashStyle) للخط إلى أحد الأنماط المعروضة بواسطة Aspose.Slides لـ PHP عبر Java.
- تعيين [نمط رأس السهم](https://reference.aspose.com/slides/php-java/aspose.slides/LineArrowheadStyle) و[الطول](https://reference.aspose.com/slides/php-java/aspose.slides/LineArrowheadLength) لنقطة البداية للخط.
- تعيين [نمط رأس السهم](https://reference.aspose.com/slides/php-java/aspose.slides/LineArrowheadStyle) و[الطول](https://reference.aspose.com/slides/php-java/aspose.slides/LineArrowheadLength) لنقطة النهاية للخط.
- كتابة العرض التقديمي المعدل كملف PPTX.

```php
  # إنشاء مثيل من فئة PresentationEx التي تمثل ملف PPTX
  $pres = new Presentation();
  try {
    # الحصول على الشريحة الأولى
    $sld = $pres->getSlides()->get_Item(0);
    # إضافة AutoShape من نوع خط
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
    # كتابة PPTX إلى القرص
    $pres->save("LineShape.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```