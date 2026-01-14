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
- مخطط تنظيم
- مخطط تنظيم صورة
- PowerPoint
- عرض تقديمي
- PHP
- Aspose.Slides
description: "تعلم بناء وتحرير SmartArt في PowerPoint باستخدام Aspose.Slides for PHP عبر Java باستخدام أمثلة شفرة واضحة تسرّع تصميم الشرائح والأتمتة."
---

## **الحصول على النص من كائن SmartArt**
تم الآن إضافة طريقة TextFrame إلى فئة [SmartArtShape](https://reference.aspose.com/slides/php-java/aspose.slides/SmartArtShape) على التوالي. تسمح لك هذه الخاصية بالحصول على كل النص من [SmartArt](https://reference.aspose.com/slides/php-java/aspose.slides/SmartArt) إذا لم يكن يحتوي فقط على نص العقد. سيساعدك الكود النموذجي التالي في الحصول على النص من عقدة SmartArt.
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

- إنشاء مثيل من فئة [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/Presentation) .
- الحصول على مرجع الشريحة باستخدام فهرسها.
- إضافة [SmartArt](https://reference.aspose.com/slides/php-java/aspose.slides/shapecollection/addsmartart/) BasicBlockList.
- تغيير [LayoutType](https://reference.aspose.com/slides/php-java/aspose.slides/smartart/setlayout/) إلى BasicProcess.
- حفظ العرض التقديمي كملف PPTX.
في المثال الموضح أدناه، قمنا بإضافة موصل بين شكلين.
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
يرجى الملاحظة: طريقة [SmartArtNode::isHidden()](https://reference.aspose.com/slides/php-java/aspose.slides/smartartnode/ishidden/) تُعيد `true` إذا كانت هذه العقدة عقدة مخفية في نموذج البيانات. من أجل التحقق من الخاصية المخفية لأي عقدة من [SmartArt](https://reference.aspose.com/slides/php-java/aspose.slides/SmartArt)، يرجى اتباع الخطوات التالية:

- إنشاء مثيل من فئة [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/Presentation) .
- إضافة [SmartArt](https://reference.aspose.com/slides/php-java/aspose.slides/shapecollection/addsmartart/) RadialCycle.
- إضافة عقدة إلى SmartArt.
- التحقق من خاصية [visibility](https://reference.aspose.com/slides/php-java/aspose.slides/smartartnode/ishidden/).
- حفظ العرض التقديمي كملف PPTX.
في المثال الموضح أدناه، قمنا بإضافة موصل بين شكلين.
```php
  $pres = new Presentation();
  try {
    # إضافة SmartArt BasicProcess
    $smart = $pres->getSlides()->get_Item(0)->getShapes()->addSmartArt(10, 10, 400, 300, SmartArtLayoutType::RadialCycle);
    # إضافة عقدة على SmartArt
    $node = $smart->getAllNodes()->addNode();
    # التحقق من الخاصية isHidden
    $hidden = $node->isHidden();// يعيد true

    if ($hidden) {
      # تنفيذ بعض الإجراءات أو الإشعارات
    }
    # حفظ العرض التقديمي
    $pres->save("CheckSmartArtHiddenProperty_out.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```


## **الحصول أو تعيين نوع مخطط التنظيم**
تسمح الطريقتان [SmartArtNode::getOrganizationChartLayout()](https://reference.aspose.com/slides/php-java/aspose.slides/smartartnode/getorganizationchartlayout/) و [SmartArtNode::setOrganizationChartLayout(int)](https://reference.aspose.com/slides/php-java/aspose.slides/smartartnode/setorganizationchartlayout/) بالحصول أو تعيين نوع مخطط التنظيم المرتبط بالعقدة الحالية. من أجل الحصول أو تعيين نوع مخطط التنظيم، يرجى اتباع الخطوات التالية:

- إنشاء مثيل من فئة [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/Presentation) .
- إضافة [SmartArt](https://reference.aspose.com/slides/php-java/aspose.slides/shapecollection/addsmartart/) إلى الشريحة.
- الحصول أو [تعيين نوع مخطط التنظيم](https://reference.aspose.com/slides/php-java/aspose.slides/smartartnode/setorganizationchartlayout/).
- حفظ العرض التقديمي كملف PPTX.
في المثال الموضح أدناه، قمنا بإضافة موصل بين شكلين.
```php
  $pres = new Presentation();
  try {
    # إضافة SmartArt BasicProcess
    $smart = $pres->getSlides()->get_Item(0)->getShapes()->addSmartArt(10, 10, 400, 300, SmartArtLayoutType::OrganizationChart);
    # الحصول أو تعيين نوع مخطط التنظيم
    $smart->getNodes()->get_Item(0)->setOrganizationChartLayout(OrganizationChartLayoutType::LeftHanging);
    # حفظ العرض التقديمي
    $pres->save("OrganizeChartLayoutType_out.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```


## **إنشاء مخطط تنظيم صورة**
توفر Aspose.Slides for PHP عبر Java واجهة برمجة تطبيقات بسيطة لإنشاء مخططات PictureOrganization بسهولة. لإنشاء مخطط على شريحة:

1. إنشاء مثيل من فئة [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/Presentation) .
1. الحصول على مرجع الشريحة بواسطة فهرستها.
1. إضافة مخطط ببيانات افتراضية مع النوع المطلوب (ChartType::PictureOrganizationChart).
1. حفظ العرض التقديمي المعدل كملف PPTX
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


## **الحصول أو تعيين حالة SmartArt**
من أجل تغيير نوع التخطيط لـ [SmartArt](https://reference.aspose.com/slides/php-java/aspose.slides/SmartArt). يرجى اتباع الخطوات التالية:

1. إنشاء مثيل من فئة [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/Presentation) .
1. إضافة [SmartArt](https://reference.aspose.com/slides/php-java/aspose.slides/shapecollection/addsmartart/) إلى الشريحة.
1. [Get](https://reference.aspose.com/slides/php-java/aspose.slides/smartart/isreversed/) أو [Set](https://reference.aspose.com/slides/php-java/aspose.slides/smartart/setreversed/) حالة مخطط SmartArt.
1. حفظ العرض التقديمي كملف PPTX.
الكود التالي يُستخدم لإنشاء مخطط.
```php
  # إنشاء كائن من الفئة Presentation التي تمثل ملف PPTX
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


## **الأسئلة الشائعة**

**هل يدعم SmartArt العكس/الانعكاس للغات من اليمين إلى اليسار؟**

نعم. طريقة [setReversed](https://reference.aspose.com/slides/php-java/aspose.slides/smartart/setreversed/) تقوم بتبديل اتجاه المخطط (LTR/RTL) إذا كان نوع SmartArt المحدد يدعم العكس.

**كيف يمكنني نسخ SmartArt إلى نفس الشريحة أو إلى عرض تقديمي آخر مع الحفاظ على التنسيق؟**

يمكنك [استنساخ شكل SmartArt](/slides/ar/php-java/shape-manipulations/) عبر مجموعة الأشكال ([ShapeCollection::addClone](https://reference.aspose.com/slides/php-java/aspose.slides/shapecollection/addclone/)) أو [استنساخ الشريحة بالكامل](/slides/ar/php-java/clone-slides/) التي تحتوي على هذا الشكل. كلا الطريقتين تحتفظ بالحجم والموقع والتنسيق.

**كيف أقوم بتحويل SmartArt إلى صورة نقطية للمعاينة أو التصدير إلى الويب؟**

يمكنك [تحويل الشريحة](/slides/ar/php-java/convert-powerpoint-to-png/) (أو العرض التقديمي بأكمله) إلى PNG/JPEG عبر API يحول الشرائح/العروض إلى صور — سيُرسم SmartArt كجزء من الشريحة.

**كيف يمكنني برمجياً اختيار SmartArt معين على شريحة إذا كان هناك عدة عناصر؟**

ممارسة شائعة هي استخدام [النص البديل](https://reference.aspose.com/slides/php-java/aspose.slides/shape/getalternativetext/) (Alt Text) أو [الاسم](https://reference.aspose.com/slides/php-java/aspose.slides/shape/getname/) والبحث عن الشكل باستخدام تلك السمة ضمن [أشكال الشريحة](https://reference.aspose.com/slides/php-java/aspose.slides/baseslide/#getShapes)، ثم التحقق من النوع للتأكد من أنه [SmartArt](https://reference.aspose.com/slides/php-java/aspose.slides/smartart/). يصف التوثيق تقنيات شائعة للعثور على الأشكال والعمل معها.