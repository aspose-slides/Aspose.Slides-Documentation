---
title: إهليلج
type: docs
weight: 30
url: /ar/php-java/ellipse/
---


{{% alert color="primary" %}} 

في هذا الموضوع، سنقدم للمطورين كيفية إضافة أشكال إهليلجية إلى الشرائح الخاصة بهم باستخدام Aspose.Slides لـ PHP عبر Java. يوفر Aspose.Slides لـ PHP عبر Java مجموعة أسهل من واجهات برمجة التطبيقات لرسم أنواع مختلفة من الأشكال مع بضع سطور فقط من التعليمات البرمجية.

{{% /alert %}} 

## **إنشاء إهليلجي**
لإضافة إهليلج بسيط إلى شريحة محددة من العرض التقديمي، يرجى اتباع الخطوات أدناه:

- إنشاء مثيل من [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/presentation) class.
- الحصول على مرجع الشريحة باستخدام الفهرس الخاص بها.
- إضافة AutoShape من نوع إهليلجي باستخدام [addAutoShape](https://reference.aspose.com/slides/php-java/aspose.slides/IShapeCollection#addAutoShape-int-float-float-float-float-) method المعروض بواسطة [IShapeCollection](https://reference.aspose.com/slides/php-java/aspose.slides/IShapeCollection) object.
- كتابة العرض التقديمي المعدل كملف PPTX.

في المثال الموضح أدناه، أضفنا إهليلج إلى الشريحة الأولى

```php
  # إنشاء مثيل من Presentation class الذي يمثل PPTX
  $pres = new Presentation();
  try {
    # الحصول على الشريحة الأولى
    $sld = $pres->getSlides()->get_Item(0);
    # إضافة AutoShape من نوع إهليلجي
    $sld->getShapes()->addAutoShape(ShapeType::Ellipse, 50, 150, 150, 50);
    # كتابة ملف PPTX على القرص
    $pres->save("EllipseShp1.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

## **إنشاء إهليلجي منسق**
لإضافة إهليلج منسق بشكل أفضل إلى الشريحة، يرجى اتباع الخطوات أدناه:

- إنشاء مثيل من [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/presentation) class.
- الحصول على مرجع الشريحة باستخدام الفهرس الخاص بها.
- إضافة AutoShape من نوع إهليلجي باستخدام [addAutoShape](https://reference.aspose.com/slides/php-java/aspose.slides/IShapeCollection#addAutoShape-int-float-float-float-float-) method المعروض بواسطة [IShapeCollection](https://reference.aspose.com/slides/php-java/aspose.slides/IShapeCollection) object.
- تعيين نوع التعبئة لإهليلج إلى صلب.
- تعيين لون الإهليلجي باستخدام خاصية SolidFillColor.Color المعروضة بواسطة [FillFormat](https://reference.aspose.com/slides/php-java/aspose.slides/IFillFormat) object المرتبط بـ [IShape](https://reference.aspose.com/slides/php-java/aspose.slides/IShape) object.
- تعيين لون خطوط الإهليلج.
- تعيين عرض خطوط الإهليلج.
- كتابة العرض التقديمي المعدل كملف PPTX.

في المثال الموضح أدناه، أضفنا إهليلجًا منسقًا إلى الشريحة الأولى من العرض التقديمي.

```php
  # إنشاء مثيل من Presentation class الذي يمثل PPTX
  $pres = new Presentation();
  try {
    # الحصول على الشريحة الأولى
    $sld = $pres->getSlides()->get_Item(0);
    # إضافة AutoShape من نوع إهليلجي
    $shp = $sld->getShapes()->addAutoShape(ShapeType::Ellipse, 50, 150, 150, 50);
    # تطبيق بعض التنسيقات على شكل الإهليلج
    $shp->getFillFormat()->setFillType(FillType::Solid);
    $shp->getFillFormat()->getSolidFillColor()->setColor(new java("java.awt.Color", PresetColor->Chocolate));
    # تطبيق بعض التنسيقات على خط الإهليلج
    $shp->getLineFormat()->getFillFormat()->setFillType(FillType::Solid);
    $shp->getLineFormat()->getFillFormat()->getSolidFillColor()->setColor(java("java.awt.Color")->BLACK);
    $shp->getLineFormat()->setWidth(5);
    # كتابة ملف PPTX على القرص
    $pres->save("EllipseShp1.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```