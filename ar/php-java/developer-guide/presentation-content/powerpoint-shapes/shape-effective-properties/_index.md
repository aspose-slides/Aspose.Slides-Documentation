---
title: الحصول على الخصائص الفعّالة للأشكال من العروض التقديمية في PHP
linktitle: الخصائص الفعّالة
type: docs
weight: 50
url: /ar/php-java/shape-effective-properties/
keywords:
- خصائص الشكل
- خصائص الكاميرا
- نظام الإضاءة
- شكل مقوَّس
- إطار النص
- نمط النص
- ارتفاع الخط
- تنسيق التعبئة
- PowerPoint
- عرض تقديمي
- PHP
- Aspose.Slides
description: "اكتشف كيف يقوم Aspose.Slides for PHP عبر Java بحساب وتطبيق الخصائص الفعّالة للأشكال لضمان عرض PowerPoint بدقة."
---

في هذا الموضوع، سنناقش الخصائص **الفعّالة** و **المحلية**. عندما نقوم بتعيين القيم مباشرةً عند هذه المستويات

1. في خصائص الجزء على شريحة الجزء؛
1. في نمط النص للشكل النموذجي على الشريحة القالب أو الشريحة الرئيسة (إذا كان لدى شكل إطار النص للجزء واحد)؛
1. في إعدادات النص العامة للعرض التقديمي؛

تُسمى تلك القيم **القيم المحلية**. عند أي مستوى، يمكن تعريف القيم **المحلية** أو حذفها. لكن عندما يحتاج التطبيق إلى معرفة شكل الجزء، فإنه يستخدم القيم **الفعّالة**. يمكنك الحصول على القيم الفعّالة باستخدام طريقة **getEffective()** من التنسيق المحلي.

يعرض لك هذا المثال البرمجي كيفية الحصول على القيم الفعّالة:
```php
  $pres = new Presentation("Presentation1.pptx");
  try {
    $shape = $pres->getSlides()->get_Item(0)->getShapes()->get_Item(0);
    $localTextFrameFormat = $shape->getTextFrame()->getTextFrameFormat();
    $effectiveTextFrameFormat = $localTextFrameFormat::getEffective();
    $localPortionFormat = $shape->getTextFrame()->getParagraphs()->get_Item(0)->getPortions()->get_Item(0)->getPortionFormat();
    $effectivePortionFormat = $localPortionFormat::getEffective();
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```


## **الحصول على الخصائص الفعّالة للكاميرا**
يتيح Aspose.Slides for PHP عبر Java للمطورين الحصول على الخصائص الفعّالة للكاميرا. من أجل ذلك، تمت إضافة الواجهة [**ICameraEffectiveData**](https://reference.aspose.com/slides/php-java/aspose.slides/ICameraEffectiveData) إلى Aspose.Slides. تمثل واجهة [ICameraEffectiveData](https://reference.aspose.com/slides/php-java/aspose.slides/ICameraEffectiveData) كائنًا غير قابل للتغيير يحتوي على خصائص الكاميرا الفعّالة. يتم استخدام نسخة من واجهة [**ICameraEffectiveData**](https://reference.aspose.com/slides/php-java/aspose.slides/ICameraEffectiveData) كجزء من واجهة [**IThreeDFormatEffectiveData**](https://reference.aspose.com/slides/php-java/aspose.slides/IThreeDFormatEffectiveData)، وهي زوج [القيم الفعّالة](https://reference.aspose.com/slides/php-java/aspose.slides/ThreeDFormat#getEffective--) لـ class [ThreeDFormat](https://reference.aspose.com/slides/php-java/aspose.slides/ThreeDFormat).

يعرض لك هذا المثال البرمجي كيفية الحصول على الخصائص الفعّالة للكاميرا:
```php
  $pres = new Presentation("Presentation1.pptx");
  try {
    $threeDEffectiveData = $pres->getSlides()->get_Item(0)->getShapes()->get_Item(0)->getThreeDFormat()->getEffective();
    echo("= Effective camera properties =");
    echo("Type: " . $threeDEffectiveData->getCamera()->getCameraType());
    echo("Field of view: " . $threeDEffectiveData->getCamera()->getFieldOfViewAngle());
    echo("Zoom: " . $threeDEffectiveData->getCamera()->getZoom());
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```


## **الحصول على الخصائص الفعّالة لجهاز الإضاءة**
يتيح Aspose.Slides for PHP عبر Java للمطورين الحصول على الخصائص الفعّالة لجهاز الإضاءة. من أجل ذلك، تمت إضافة الواجهة [**ILightRigEffectiveData**](https://reference.aspose.com/slides/php-java/aspose.slides/ILightRigEffectiveData) إلى Aspose.Slides. تمثل واجهة [ILightRigEffectiveData](https://reference.aspose.com/slides/php-java/aspose.slides/ILightRigEffectiveData) كائنًا غير قابل للتغيير يحتوي على خصائص جهاز الإضاءة الفعّالة. يتم استخدام نسخة من واجهة [**ILightRigEffectiveData**](https://reference.aspose.com/slides/php-java/aspose.slides/ILightRigEffectiveData) كجزء من واجهة [**IThreeDFormatEffectiveData**](https://reference.aspose.com/slides/php-java/aspose.slides/IThreeDFormatEffectiveData)، وهي زوج [القيم الفعّالة](https://reference.aspose.com/slides/php-java/aspose.slides/ThreeDFormat#getEffective--) لـ class [ThreeDFormat](https://reference.aspose.com/slides/php-java/aspose.slides/ThreeDFormat).

يعرض لك هذا المثال البرمجي كيفية الحصول على الخصائص الفعّالة لجهاز الإضاءة:
```php
  $pres = new Presentation("Presentation1.pptx");
  try {
    $threeDEffectiveData = $pres->getSlides()->get_Item(0)->getShapes()->get_Item(0)->getThreeDFormat()->getEffective();
    echo("= Effective light rig properties =");
    echo("Type: " . $threeDEffectiveData->getLightRig()->getLightType());
    echo("Direction: " . $threeDEffectiveData->getLightRig()->getDirection());
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```


## **الحصول على الخصائص الفعّالة للشكل المائل**
يتيح Aspose.Slides for PHP عبر Java للمطورين الحصول على الخصائص الفعّالة للشكل المائل. من أجل ذلك، تمت إضافة الواجهة [**IShapeBevelEffectiveData**](https://reference.aspose.com/slides/php-java/aspose.slides/IShapeBevelEffectiveData) إلى Aspose.Slides. تمثل واجهة [IShapeBevelEffectiveData](https://reference.aspose.com/slides/php-java/aspose.slides/IShapeBevelEffectiveData) كائنًا غير قابل للتغيير يحتوي على خصائص ارتقاع الوجه للشكل الفعّالة. يتم استخدام نسخة من واجهة [**IShapeBevelEffectiveData**](https://reference.aspose.com/slides/php-java/aspose.slides/IShapeBevelEffectiveData) كجزء من واجهة [**IThreeDFormatEffectiveData**]([**IShapeBevelEffectiveData**](https://reference.aspose.com/slides/php-java/aspose.slides/IShapeBevelEffectiveData))، وهي زوج [القيم الفعّالة](https://reference.aspose.com/slides/php-java/aspose.slides/ThreeDFormat#getEffective--) لـ class [ThreeDFormat](https://reference.aspose.com/slides/php-java/aspose.slides/ThreeDFormat).

يعرض لك هذا المثال البرمجي كيفية الحصول على الخصائص الفعّالة للشكل المائل:
```php
  $pres = new Presentation("Presentation1.pptx");
  try {
    $threeDEffectiveData = $pres->getSlides()->get_Item(0)->getShapes()->get_Item(0)->getThreeDFormat()->getEffective();
    echo("= Effective shape's top face relief properties =");
    echo("Type: " . $threeDEffectiveData->getBevelTop()->getBevelType());
    echo("Width: " . $threeDEffectiveData->getBevelTop()->getWidth());
    echo("Height: " . $threeDEffectiveData->getBevelTop()->getHeight());
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```


## **الحصول على الخصائص الفعّالة لإطار النص**
باستخدام Aspose.Slides for PHP عبر Java، يمكنك الحصول على الخصائص الفعّالة لإطار النص. من أجل ذلك، تمت إضافة الواجهة [**ITextFrameFormatEffectiveData**](https://reference.aspose.com/slides/php-java/aspose.slides/ITextFrameFormatEffectiveData) إلى Aspose.Slides. يحتوي على خصائص تنسيق إطارات النص الفعّالة.

يعرض لك هذا المثال البرمجي كيفية الحصول على خصائص تنسيق إطار النص الفعّالة:
```php
  $pres = new Presentation("Presentation1.pptx");
  try {
    $shape = $pres->getSlides()->get_Item(0)->getShapes()->get_Item(0);
    $effectiveTextFrameFormat = $shape->getTextFrame()->getTextFrameFormat()->getEffective();
    echo("Anchoring type: " . $effectiveTextFrameFormat::getAnchoringType());
    echo("Autofit type: " . $effectiveTextFrameFormat::getAutofitType());
    echo("Text vertical type: " . $effectiveTextFrameFormat::getTextVerticalType());
    echo("Margins");
    echo("   Left: " . $effectiveTextFrameFormat::getMarginLeft());
    echo("   Top: " . $effectiveTextFrameFormat::getMarginTop());
    echo("   Right: " . $effectiveTextFrameFormat::getMarginRight());
    echo("   Bottom: " . $effectiveTextFrameFormat::getMarginBottom());
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```


## **الحصول على الخصائص الفعّالة لنمط النص**
باستخدام Aspose.Slides for PHP عبر Java، يمكنك الحصول على الخصائص الفعّالة لنمط النص. من أجل ذلك، تمت إضافة الواجهة [**ITextStyleEffectiveData**](https://reference.aspose.com/slides/php-java/aspose.slides/ITextStyleEffectiveData) إلى Aspose.Slides. يحتوي على خصائص نمط النص الفعّالة.

يعرض لك هذا المثال البرمجي كيفية الحصول على خصائص نمط النص الفعّالة:
```php
  $pres = new Presentation("Presentation1.pptx");
  try {
    $shape = $pres->getSlides()->get_Item(0)->getShapes()->get_Item(0);
    $effectiveTextStyle = $shape->getTextFrame()->getTextFrameFormat()->getTextStyle()->getEffective();
    for($i = 0; $i <= 8; $i++) {
      $effectiveStyleLevel = $effectiveTextStyle->getLevel($i);
      echo("= Effective paragraph formatting for style level #" . $i . " =");
      echo("Depth: " . $effectiveStyleLevel->getDepth());
      echo("Indent: " . $effectiveStyleLevel->getIndent());
      echo("Alignment: " . $effectiveStyleLevel->getAlignment());
      echo("Font alignment: " . $effectiveStyleLevel->getFontAlignment());
    }
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```


## **الحصول على قيمة ارتفاع الخط الفعّالة**
باستخدام Aspose.Slides for PHP عبر Java، يمكنك الحصول على الخصائص الفعّالة لارتفاع الخط. هنا نقدم كودًا يوضح تغير قيمة ارتفاع الخط الفعّالة للجزء بعد ضبط قيم ارتفاع الخط المحلية على مستويات مختلفة من بنية العرض التقديمي:
```php
  $pres = new Presentation();
  try {
    $newShape = $pres->getSlides()->get_Item(0)->getShapes()->addAutoShape(ShapeType::Rectangle, 100, 100, 400, 75, false);
    $newShape->addTextFrame("");
    $newShape->getTextFrame()->getParagraphs()->get_Item(0)->getPortions()->clear();
    $portion0 = new Portion("Sample text with first portion");
    $portion1 = new Portion(" and second portion.");
    $newShape->getTextFrame()->getParagraphs()->get_Item(0)->getPortions()->add($portion0);
    $newShape->getTextFrame()->getParagraphs()->get_Item(0)->getPortions()->add($portion1);
    echo("Effective font height just after creation:");
    echo("Portion #0: " . $portion0->getPortionFormat()->getEffective()->getFontHeight());
    echo("Portion #1: " . $portion1->getPortionFormat()->getEffective()->getFontHeight());
    $pres->getDefaultTextStyle()->getLevel(0)->getDefaultPortionFormat()->setFontHeight(24);
    echo("Effective font height after setting entire presentation default font height:");
    echo("Portion #0: " . $portion0->getPortionFormat()->getEffective()->getFontHeight());
    echo("Portion #1: " . $portion1->getPortionFormat()->getEffective()->getFontHeight());
    $newShape->getTextFrame()->getParagraphs()->get_Item(0)->getParagraphFormat()->getDefaultPortionFormat()->setFontHeight(40);
    echo("Effective font height after setting paragraph default font height:");
    echo("Portion #0: " . $portion0->getPortionFormat()->getEffective()->getFontHeight());
    echo("Portion #1: " . $portion1->getPortionFormat()->getEffective()->getFontHeight());
    $newShape->getTextFrame()->getParagraphs()->get_Item(0)->getPortions()->get_Item(0)->getPortionFormat()->setFontHeight(55);
    echo("Effective font height after setting portion #0 font height:");
    echo("Portion #0: " . $portion0->getPortionFormat()->getEffective()->getFontHeight());
    echo("Portion #1: " . $portion1->getPortionFormat()->getEffective()->getFontHeight());
    $newShape->getTextFrame()->getParagraphs()->get_Item(0)->getPortions()->get_Item(1)->getPortionFormat()->setFontHeight(18);
    echo("Effective font height after setting portion #1 font height:");
    echo("Portion #0: " . $portion0->getPortionFormat()->getEffective()->getFontHeight());
    echo("Portion #1: " . $portion1->getPortionFormat()->getEffective()->getFontHeight());
    $pres->save("SetLocalFontHeightValues.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```


## **الحصول على تنسيق الملء الفعّال لجدول**
باستخدام Aspose.Slides for PHP عبر Java، يمكنك الحصول على تنسيق الملء الفعّال لأجزاء منطقية مختلفة في الجدول. لهذا الغرض، تمت إضافة الواجهة [**ICellFormatEffectiveData**](https://reference.aspose.com/slides/php-java/aspose.slides/ICellFormatEffectiveData) إلى Aspose.Slides. تحتوي على خصائص تنسيق ملء فعّالة. يرجى ملاحظة ما يلي: يتم إعطاء تنسيق الخلية أولوية دائمًا على تنسيق الصف؛ ويفضل الصف على العمود؛ ويفضل العمود على الجدول بأكمله.
```php
  $pres = new Presentation("Presentation1.pptx");
  try {
    $tbl = $pres->getSlides()->get_Item(0)->getShapes()->get_Item(0);
    $tableFormatEffective = $tbl->getTableFormat()->getEffective();
    $rowFormatEffective = $tbl->getRows()->get_Item(0)->getRowFormat()->getEffective();
    $columnFormatEffective = $tbl->getColumns()->get_Item(0)->getColumnFormat()->getEffective();
    $cellFormatEffective = $tbl->get_Item(0, 0)->getCellFormat()->getEffective();
    $tableFillFormatEffective = $tableFormatEffective->getFillFormat();
    $rowFillFormatEffective = $rowFormatEffective->getFillFormat();
    $columnFillFormatEffective = $columnFormatEffective->getFillFormat();
    $cellFillFormatEffective = $cellFormatEffective->getFillFormat();
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```


## **الأسئلة الشائعة**

**كيف يمكنني معرفة أنني حصلت على "لقطة" بدلاً من "كائن حي"، ومتى يجب علي قراءة الخصائص الفعّالة مرة أخرى؟**  
كائنات EffectiveData هي لقطات غير قابلة للتغيير للقيم المحسوبة في وقت الاستدعاء. إذا قمت بتغيير الإعدادات المحلية أو الموروثة للشكل، استرجع البيانات الفعّالية مرة أخرى للحصول على القيم المحدّثة.

**هل يؤثر تغيير شريحة القالب/الرئيسية على الخصائص الفعّالة التي تم استرجاعها بالفعل؟**  
نعم، ولكن فقط بعد قراءة القيم مرة أخرى. كائن EffectiveData الذي تم الحصول عليه مسبقًا لا يحدث نفسه—اطلبه مرة أخرى بعد تعديل القالب أو الشريحة الرئيسية.

**هل يمكنني تعديل القيم عبر EffectiveData؟**  
لا. EffectiveData للقراءة فقط. قم بإجراء التغييرات في كائنات التنسيق المحلي (الشكل/النص/3D، إلخ)، ثم احصل على القيم الفعّالة مرة أخرى.

**ماذا يحدث إذا لم يتم تعيين خاصية على مستوى الشكل، ولا في القالب/الرئيسية، ولا في الإعدادات العامة؟**  
يتم تحديد القيمة الفعّالة عبر آلية الافتراضية (الافتراضات الخاصة بـ PowerPoint/Aspose.Slides). تصبح تلك القيمة المحلولة جزءًا من لقطة EffectiveData.

**من قيمة الخط الفعّالة، هل يمكنني معرفة أي مستوى قدم الحجم أو نوع الخط؟**  
ليس بشكل مباشر. تُعيد EffectiveData القيمة النهائية. لتحديد المصدر، افحص القيم المحلية في الجزء/الفقرة/إطار النص وأنماط النص في القالب/الرئيسية/العرض لمعرفة أين ظهرت التعريف الأول الصريح.

**لماذا تبدو قيم EffectiveData أحيانًا مطابقة للقيم المحلية؟**  
لأن القيمة المحلية أصبحت النهائية (لم يكن هناك حاجة إلى وراثة من مستوى أعلى). في هذه الحالات، تتطابق القيمة الفعّالة مع القيمة المحلية.

**متى يجب استخدام الخصائص الفعّالة، ومتى يجب العمل فقط بالقيم المحلية؟**  
استخدم EffectiveData عندما تحتاج إلى النتيجة "كما تم عرضها" بعد تطبيق جميع الوراثات (مثل مطابقة الألوان أو الهوامش أو الأحجام). إذا كنت بحاجة إلى تغيير التنسيق على مستوى معين، عدّل الخصائص المحلية ثم، إذا لزم الأمر, أعد قراءة EffectiveData للتحقق من النتيجة.