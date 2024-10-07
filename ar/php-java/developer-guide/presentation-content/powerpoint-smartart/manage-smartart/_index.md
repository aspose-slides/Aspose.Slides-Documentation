---
title: إدارة SmartArt
type: docs
weight: 10
url: /php-java/manage-smartart/
---

## **الحصول على النص من SmartArt**
لقد تم إضافة طريقة TextFrame إلى واجهة [ISmartArtShape](https://reference.aspose.com/slides/php-java/aspose.slides/ISmartArtShape) وفئة [SmartArtShape](https://reference.aspose.com/slides/php-java/aspose.slides/SmartArtShape). تتيح لك هذه الخاصية الحصول على جميع النصوص من [SmartArt](https://reference.aspose.com/slides/php-java/aspose.slides/SmartArt) إذا لم يكن يحتوي فقط على نصوص العقد. سوف تساعدك عينة الكود التالية في الحصول على النص من عقدة SmartArt.

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

## **تغيير نوع تخطيط SmartArt**
لتغيير نوع تخطيط [SmartArt](https://reference.aspose.com/slides/php-java/aspose.slides/SmartArt)، يرجى اتباع الخطوات أدناه:

- إنشاء مثيل من فئة [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/Presentation).
- الحصول على مرجع شريحة باستخدام فهرسها.
- إضافة [SmartArt](https://reference.aspose.com/slides/php-java/aspose.slides/IShapeCollection#addSmartArt-float-float-float-float-int-) BasicBlockList.
- تغيير [LayoutType](https://reference.aspose.com/slides/php-java/aspose.slides/ISmartArt#setLayout-int-) إلى BasicProcess.
- كتابة العرض التقديمي كملف PPTX.
في المثال المعطى أدناه، قمنا بإضافة موصل بين شكلين.

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

## **التحقق من خاصية الخفاء لـ SmartArt**
يرجى ملاحظة: الطريقة [ISmartArtNode.isHidden()](https://reference.aspose.com/slides/php-java/aspose.slides/ISmartArtNode#isHidden--) ترجع true إذا كانت هذه العقدة عقدة مخفية في نموذج البيانات. للتحقق من خاصية الخفاء لأي عقدة من [SmartArt](https://reference.aspose.com/slides/php-java/aspose.slides/SmartArt). يرجى اتباع الخطوات أدناه:

- إنشاء مثيل من فئة [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/Presentation).
- إضافة [SmartArt](https://reference.aspose.com/slides/php-java/aspose.slides/IShapeCollection#addSmartArt-float-float-float-float-int-) RadialCycle.
- إضافة عقدة على SmartArt.
- التحقق من خاصية [isHidden](https://reference.aspose.com/slides/php-java/aspose.slides/ISmartArtNode#isHidden--).
- كتابة العرض التقديمي كملف PPTX.

في المثال المعطى أدناه، قمنا بإضافة موصل بين شكلين.

```php
  $pres = new Presentation();
  try {
    # إضافة SmartArt BasicProcess
    $smart = $pres->getSlides()->get_Item(0)->getShapes()->addSmartArt(10, 10, 400, 300, SmartArtLayoutType::RadialCycle);
    # إضافة عقدة على SmartArt
    $node = $smart->getAllNodes()->addNode();
    # التحقق من خاصية isHidden
    $hidden = $node->isHidden();// ترجع true

    if ($hidden) {
      # تنفيذ بعض الإجراءات أو الإعلامات
    }
    # حفظ العرض التقديمي
    $pres->save("CheckSmartArtHiddenProperty_out.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

## **الحصول أو ضبط نوع مخطط تنظيم**
تسمح الطرق [ISmartArtNode.getOrganizationChartLayout()](https://reference.aspose.com/slides/php-java/aspose.slides/ISmartArtNode#getOrganizationChartLayout--)، [setOrganizationChartLayout(int)](https://reference.aspose.com/slides/php-java/aspose.slides/ISmartArtNode#setOrganizationChartLayout-int-) بالحصول أو ضبط نوع مخطط التنظيم المرتبط بالعقدة الحالية. للحصول على نوع مخطط التنظيم أو ضبطه، يرجى اتباع الخطوات أدناه:

- إنشاء مثيل من فئة [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/Presentation).
- إضافة [SmartArt](https://reference.aspose.com/slides/php-java/aspose.slides/IShapeCollection#addSmartArt-float-float-float-float-int-) على الشريحة.
- الحصول أو [ضبط نوع مخطط التنظيم](https://reference.aspose.com/slides/php-java/aspose.slides/ISmartArtNode#setOrganizationChartLayout-int-).
- كتابة العرض التقديمي كملف PPTX.
في المثال المعطى أدناه، قمنا بإضافة موصل بين شكلين.

```php
  $pres = new Presentation();
  try {
    # إضافة SmartArt BasicProcess
    $smart = $pres->getSlides()->get_Item(0)->getShapes()->addSmartArt(10, 10, 400, 300, SmartArtLayoutType::OrganizationChart);
    # الحصول أو ضبط نوع مخطط التنظيم
    $smart->getNodes()->get_Item(0)->setOrganizationChartLayout(OrganizationChartLayoutType::LeftHanging);
    # حفظ العرض التقديمي
    $pres->save("OrganizeChartLayoutType_out.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

## **إنشاء مخطط تنظيم بصورة**
توفر Aspose.Slides لـ PHP عبر Java واجهة برمجة تطبيقات بسيطة لإنشاء مخططات تنظيم بصورة بسهولة. لإنشاء مخطط على شريحة:

1. إنشاء مثيل من فئة [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/Presentation).
1. الحصول على مرجع الشريحة بواسطة فهرسها.
1. إضافة مخطط ببيانات افتراضية مع النوع المطلوب (ChartType::PictureOrganizationChart).
1. كتابة العرض التقديمي المعدل إلى ملف PPTX.

يستخدم الكود التالي لإنشاء مخطط.

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

## **الحصول أو ضبط حالة SmartArt**
لتغيير نوع تخطيط [SmartArt](https://reference.aspose.com/slides/php-java/aspose.slides/SmartArt). يرجى اتباع الخطوات أدناه:

1. إنشاء مثيل من فئة [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/Presentation).
1. إضافة [SmartArt](https://reference.aspose.com/slides/php-java/aspose.slides/IShapeCollection#addSmartArt-float-float-float-float-int-) على الشريحة.
1. [الحصول](https://reference.aspose.com/slides/php-java/aspose.slides/ISmartArt#isReversed--) أو [ضبط](https://reference.aspose.com/slides/php-java/aspose.slides/ISmartArt#setReversed-boolean-) حالة مخطط SmartArt.
1. كتابة العرض التقديمي كملف PPTX.

يستخدم الكود التالي لإنشاء مخطط.

```php
  # إنشاء مثيل لفئة Presentation التي تمثل ملف PPTX
  $pres = new Presentation();
  try {
    # إضافة SmartArt BasicProcess
    $smart = $pres->getSlides()->get_Item(0)->getShapes()->addSmartArt(10, 10, 400, 300, SmartArtLayoutType::BasicProcess);
    # الحصول أو ضبط حالة مخطط SmartArt
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