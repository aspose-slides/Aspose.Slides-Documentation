---
title: إضافة أشكال إهليلجية إلى العروض التقديمية في PHP
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
description: "تعلّم كيفية إنشاء وتنسيق وتحريك أشكال الإهليلج في Aspose.Slides for PHP via Java في عروض PPT و PPTX — تشمل أمثلة على الشيفرة."
---

{{% alert color="primary" %}} 

في هذه المقالة، سنقدم للمطورين طريقة إضافة أشكال بيضاوية إلى شرائحهم باستخدام Aspose.Slides for PHP via Java. Aspose.Slides for PHP عبر Java يوفر مجموعة أسهل من واجهات برمجة التطبيقات لرسم أنواع مختلفة من الأشكال ببضع أسطر من الشيفرة فقط.

{{% /alert %}} 

## **إنشاء إهليلج**
لإضافة إهليلج بسيط إلى شريحة محددة من العرض التقديمي، يرجى اتباع الخطوات أدناه:

- إنشاء مثال من فئة [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/presentation).
- الحصول على مرجع الشريحة باستخدام الفهرس الخاص بها.
- إضافة AutoShape من نوع Ellipse باستخدام الطريقة [addAutoShape](https://reference.aspose.com/slides/php-java/aspose.slides/IShapeCollection#addAutoShape-int-float-float-float-float-) التي يوفرها كائن [IShapeCollection](https://reference.aspose.com/slides/php-java/aspose.slides/IShapeCollection).
- حفظ العرض التقديمي المعدل كملف PPTX.

في المثال أدناه، تم إضافة إهليلج إلى الشريحة الأولى
```php
  # إنشاء فئة Presentation التي تمثل ملف PPTX
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


## **إنشاء إهليلج منسق**
لإضافة إهليلج منسق بشكل أفضل إلى شريحة، يرجى اتباع الخطوات أدناه:

- إنشاء مثال من فئة [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/presentation).
- الحصول على مرجع الشريحة باستخدام الفهرس الخاص بها.
- إضافة AutoShape من نوع Ellipse باستخدام الطريقة [addAutoShape](https://reference.aspose.com/slides/php-java/aspose.slides/IShapeCollection#addAutoShape-int-float-float-float-float-) التي يوفرها كائن [IShapeCollection](https://reference.aspose.com/slides/php-java/aspose.slides/IShapeCollection).
- ضبط نوع التعبئة للإهليلج إلى Solid.
- ضبط لون الإهليلج باستخدام الخاصية SolidFillColor.Color كما يوفرها كائن [FillFormat](https://reference.aspose.com/slides/php-java/aspose.slides/IFillFormat) المرتبط بكائن [IShape](https://reference.aspose.com/slides/php-java/aspose.slides/IShape).
- ضبط لون خطوط الإهليلج.
- ضبط عرض خطوط الإهليلج.
- حفظ العرض التقديمي المعدل كملف PPTX.

في المثال أدناه، تم إضافة إهليلج منسق إلى الشريحة الأولى من العرض التقديمي.
```php
  # إنشاء فئة Presentation التي تمثل ملف PPTX
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


## **الأسئلة المتكررة**

**كيف يمكنني تحديد الموقع والدقة الدقيقة لإهليلج بالنسبة لوحدات الشريحة؟**

عادةً ما يتم تحديد الإحداثيات والأحجام **بنقاط**. للحصول على نتائج متوقعة، احسب بناءً على حجم الشريحة وحول المليمترات أو الإنش المطلوبة إلى نقاط قبل تعيين القيم.

**كيف يمكنني وضع إهليلج فوق أو تحت عناصر أخرى (التحكم في ترتيب الطبقات)؟**

قم بتعديل ترتيب الرسم للكائن عن طريق إحضاره إلى المقدمة أو إرساله إلى الخلف. ذلك يسمح للإهليلج بالتراكب فوق عناصر أخرى أو إظهار ما تحتها.

**كيف يمكنني تحريك ظهور أو إبراز إهليلج؟**

استخدام تأثيرات الدخول أو التأكيد أو الخروج على الشكل عبر [تطبيق](/slides/ar/php-java/shape-animation/)، وضبط المشغلات والوقت لتحديد متى وكيف تُظهر الرسوم المتحركة.