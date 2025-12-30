---
title: إدارة SmartArt في عروض PowerPoint التقديمية باستخدام PHP
linktitle: إدارة SmartArt
type: docs
weight: 10
url: /ar/php-java/manage-smartart/
keywords:
- SmartArt
- نص SmartArt
- نوع التخطيط
- خاصية مخفية
- مخطط المنظمة
- مخطط تنظيم الصورة
- PowerPoint
- عرض تقديمي
- PHP
- Aspose.Slides
description: "تعلم كيفية إنشاء وتعديل SmartArt في PowerPoint باستخدام Aspose.Slides for PHP عبر Java باستخدام أمثلة شفرة واضحة تُسرّع تصميم الشرائح والأتمتة."
---

## **الحصول على النص من كائن SmartArt**
تم الآن إضافة طريقة TextFrame إلى الواجهة [ISmartArtShape](https://reference.aspose.com/slides/php-java/aspose.slides/ISmartArtShape) وفئة [SmartArtShape](https://reference.aspose.com/slides/php-java/aspose.slides/SmartArtShape) على التوالي. تسمح لك هذه الخاصية بالحصول على كل النص من [SmartArt](https://reference.aspose.com/slides/php-java/aspose.slides/SmartArt) إذا لم يكن يحتوي على نص العقد فقط. سيساعدك الكود النموذجي التالي في الحصول على النص من عقدة SmartArt.
```php
  $pres = new Presentation("Presentation.pptx");
  try {
    $slide = $pres->getSlides()->get_Item(0);
    $smartArt = $slide->getShapes()->get_Item(0);
    $smartArtNodes = $smartArt->getAllNodes();
    foreach($smartArtNodes as $smartArtNode) {
      foreach($smartArtNode->getShapes() as $nodeShape) {
        if (!java_is_null($nodeShape->getTextFrame())) {
          echo($nodeShape->getTextFrame()->getText());
        }
      }
    }
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```


## **تغيير نوع التخطيط لكائن SmartArt**
من أجل تغيير نوع التخطيط لـ [SmartArt](https://reference.aspose.com/slides/php-java/aspose.slides/SmartArt). يرجى اتباع الخطوات التالية:

- إنشاء مثيل من فئة [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/Presentation).
- الحصول على مرجع الشريحة باستخدام فهرسها.
- إضافة [SmartArt](https://reference.aspose.com/slides/php-java/aspose.slides/IShapeCollection#addSmartArt-float-float-float-float-int-) BasicBlockList.
- تغيير [LayoutType](https://reference.aspose.com/slides/php-java/aspose.slides/ISmartArt#setLayout-int-) إلى BasicProcess.
- كتابة العرض التقديمي كملف PPTX.  
في المثال أدناه، قمنا بإضافة موصل بين شكلين.
```php
  $pres = new Presentation();
  try {
    # إضافة SmartArt BasicProcess
    $smart = $pres->getSlides()->get_Item(0)->getShapes()->addSmartArt(10, 10, 400, 300, SmartArtLayoutType::BasicBlockList);
    # تغيير LayoutType إلى BasicProcess
    $smart->setLayout(SmartArtLayoutType::BasicProcess);
    # حفظ العرض التقديمي
    $pres->save("ChangeSmartArtLayout_out.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```


## **التحقق من الخاصية المخفية لكائن SmartArt**
يرجى الملاحظة: الطريقة [ISmartArtNode.isHidden()]((https://reference.aspose.com/slides/php-java/aspose.slides/ISmartArtNode#isHidden--)) تُعيد true إذا كانت هذه العقدة عقدة مخفية في نموذج البيانات. من أجل التحقق من الخاصية المخفية لأي عقدة من [SmartArt](https://reference.aspose.com/slides/php-java/aspose.slides/SmartArt). يرجى اتباع الخطوات التالية:

- إنشاء مثيل من فئة [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/Presentation).
- إضافة [SmartArt](https://reference.aspose.com/slides/php-java/aspose.slides/IShapeCollection#addSmartArt-float-float-float-float-int-) RadialCycle.
- إضافة عقدة على SmartArt.
- التحقق من خاصية [isHidden](https://reference.aspose.com/slides/php-java/aspose.slides/ISmartArtNode#isHidden--) .
- كتابة العرض التقديمي كملف PPTX.

في المثال أدناه، قمنا بإضافة موصل بين شكلين.
```php
  $pres = new Presentation();
  try {
    # إضافة SmartArt BasicProcess
    $smart = $pres->getSlides()->get_Item(0)->getShapes()->addSmartArt(10, 10, 400, 300, SmartArtLayoutType::RadialCycle);
    # إضافة عقدة على SmartArt
    $node = $smart->getAllNodes()->addNode();
    # التحقق من خاصية isHidden
    $hidden = $node->isHidden();// يعيد true

    if ($hidden) {
      # القيام ببعض الإجراءات أو الإشعارات
    }
    # حفظ العرض التقديمي
    $pres->save("CheckSmartArtHiddenProperty_out.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```


## **الحصول على نوع مخطط المنظمة أو تعيينه**
تسمح الطُرُق [ISmartArtNode.getOrganizationChartLayout()](https://reference.aspose.com/slides/php-java/aspose.slides/ISmartArtNode#getOrganizationChartLayout--) و[setOrganizationChartLayout(int)](https://reference.aspose.com/slides/php-java/aspose.slides/ISmartArtNode#setOrganizationChartLayout-int-) بالحصول على أو تعيين نوع مخطط المنظمة المرتبط بالعقدة الحالية. من أجل الحصول على نوع مخطط المنظمة أو تعيينه. يرجى اتباع الخطوات التالية:

- إنشاء مثيل من فئة [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/Presentation).
- إضافة [SmartArt](https://reference.aspose.com/slides/php-java/aspose.slides/IShapeCollection#addSmartArt-float-float-float-float-int-) على الشريحة.
- الحصول على أو [تعيين نوع مخطط المنظمة](https://reference.aspose.com/slides/php-java/aspose.slides/ISmartArtNode#setOrganizationChartLayout-int-).
- كتابة العرض التقديمي كملف PPTX.  
في المثال أدناه، قمنا بإضافة موصل بين شكلين.
```php
  $pres = new Presentation();
  try {
    # إضافة SmartArt BasicProcess
    $smart = $pres->getSlides()->get_Item(0)->getShapes()->addSmartArt(10, 10, 400, 300, SmartArtLayoutType::OrganizationChart);
    # الحصول على أو تعيين نوع مخطط المنظمة
    $smart->getNodes()->get_Item(0)->setOrganizationChartLayout(OrganizationChartLayoutType::LeftHanging);
    # حفظ العرض التقديمي
    $pres->save("OrganizeChartLayoutType_out.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```


## **إنشاء مخطط منظمة صورة**
توفر Aspose.Slides for PHP via Java واجهة برمجة تطبيقات بسيطة لإنشاء مخططات PictureOrganization بسهولة. لإنشاء مخطط على شريحة:

1. إنشاء مثيل من فئة [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/Presentation).
1. الحصول على مرجع الشريحة باستخدام فهرسها.
1. إضافة مخطط ببيانات افتراضية مع النوع المطلوب (ChartType::PictureOrganizationChart).
1. كتابة العرض التقديمي المعدل إلى ملف PPTX.

الكود التالي يُستخدم لإنشاء مخطط.
```php
  $pres = new Presentation("test.pptx");
  try {
    $smartArt = $pres->getSlides()->get_Item(0)->getShapes()->addSmartArt(0, 0, 400, 400, SmartArtLayoutType::PictureOrganizationChart);
    $pres->save("OrganizationChart.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```


## **الحصول على حالة SmartArt أو تعيينها**
من أجل تغيير نوع التخطيط لـ [SmartArt](https://reference.aspose.com/slides/php-java/aspose.slides/SmartArt). يرجى اتباع الخطوات التالية:

1. إنشاء مثيل من فئة [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/Presentation).
1. إضافة [SmartArt](https://reference.aspose.com/slides/php-java/aspose.slides/IShapeCollection#addSmartArt-float-float-float-float-int-) على الشريحة.
1. [الحصول](https://reference.aspose.com/slides/php-java/aspose.slides/ISmartArt#isReversed--) أو [تعيين](https://reference.aspose.com/slides/php-java/aspose.slides/ISmartArt#setReversed-boolean-) حالة مخطط SmartArt.
1. كتابة العرض التقديمي كملف PPTX.

الكود التالي يُستخدم لإنشاء مخطط.
```php
  # إنشاء كائن Presentation الذي يمثل ملف PPTX
  $pres = new Presentation();
  try {
    # إضافة SmartArt BasicProcess
    $smart = $pres->getSlides()->get_Item(0)->getShapes()->addSmartArt(10, 10, 400, 300, SmartArtLayoutType::BasicProcess);
    # الحصول على أو تعيين حالة مخطط SmartArt
    $smart->setReversed(true);
    $flag = $smart->isReversed();
    # حفظ العرض التقديمي
    $pres->save("output.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```


## **FAQ**

**هل يدعم SmartArt العكس/المرايا للغات RTL؟**

نعم. طريقة [setReversed](https://reference.aspose.com/slides/php-java/aspose.slides/smartart/setreversed/) تغير اتجاه المخطط (LTR/RTL) إذا كان نوع SmartArt المحدد يدعم العكس.

**كيف يمكنني نسخ SmartArt إلى نفس الشريحة أو إلى عرض تقديمي آخر مع الحفاظ على التنسيق؟**

يمكنك [استنساخ شكل SmartArt](/slides/ar/php-java/shape-manipulations/) عبر مجموعة الأشكال ([ShapeCollection.addClone](https://reference.aspose.com/slides/php-java/aspose.slides/shapecollection/addclone/)) أو [استنساخ الشريحة بالكامل](/slides/ar/php-java/clone-slides/) التي تحتوي على هذا الشكل. كلا النهجين يحافظان على الحجم والموقع والأنماط.

**كيف أقوم بتصيير SmartArt إلى صورة نقطية للمعاينة أو للتصدير إلى الويب؟**

[تصيير الشريحة](/slides/ar/php-java/convert-powerpoint-to-png/) (أو العرض التقديمي بالكامل) إلى PNG/JPEG عبر API الذي يحوّل الشرائح/العروض إلى صور—سيتم رسم SmartArt كجزء من الشريحة.

**كيف يمكنني برمجياً تحديد SmartArt معين على شريحة إذا كان هناك عدة عناصر؟**

الممارسة الشائعة هي استخدام [النص البديل](https://reference.aspose.com/slides/php-java/aspose.slides/shape/getalternativetext/) (Alt Text) أو [الاسم](https://reference.aspose.com/slides/php-java/aspose.slides/shape/getname/) والبحث عن الشكل عبر تلك السمة داخل [أشكال الشريحة](https://reference.aspose.com/slides/php-java/aspose.slides/baseslide/#getShapes)، ثم فحص النوع للتأكد أنه [SmartArt](https://reference.aspose.com/slides/php-java/aspose.slides/smartart/). توثيق المنتج يوضح التقنيات النموذجية للعثور على الأشكال والعمل معها.