---
title: الحصول على الخصائص الفعّالة للشكل من العروض التقديمية في PHP
linktitle: الخصائص الفعّالة
type: docs
weight: 50
url: /ar/php-java/shape-effective-properties/
keywords:
- خصائص الشكل
- خصائص الكاميرا
- تجهيز الإضاءة
- شكل الحافة
- إطار النص
- نمط النص
- ارتفاع الخط
- تنسيق التعبئة
- PowerPoint
- العرض التقديمي
- PHP
- Aspose.Slides
description: "اكتشف كيف تقوم Aspose.Slides للـ PHP عبر Java بحساب وتطبيق الخصائص الفعّالة للشكل لتقديم عرض PowerPoint بدقة."
---

في هذا الموضوع، سنناقش الخصائص **الفعّالة** و**المحلية**. عندما نقوم بتعيين القيم مباشرةً على هذه المستويات

1. في خصائص الجزء على شريحة الجزء؛
1. في نمط نص الشكل النموذجي على شريحة التخطيط أو الشريحة الرئيسية (إذا كان لشكل إطار النص للجزء واحد)؛
1. في إعدادات النص العالمية للعرض التقديمي؛

تُسمى تلك القيم **القيم المحلية**. على أي مستوى، يمكن تعريف أو حذف **القيم المحلية**. ولكن عندما يحتاج التطبيق إلى معرفة كيف يجب أن يبدو الجزء، يستخدم **القيم الفعّالة**. يمكنك الحصول على القيم الفعّالة باستخدام طريقة **getEffective()** من التنسيق المحلي.

هذا المثال البرمجي يوضح لك كيفية الحصول على القيم الفعّالة:
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
تتيح Aspose.Slides for PHP عبر Java للمطورين الحصول على خصائص الكاميرا الفعّالة. لهذا الغرض، تمت إضافة الفئة `ICameraEffectiveData` إلى Aspose.Slides. تمثّل فئة `ICameraEffectiveData` كائنًا غير قابل للتغيير يحتوي على خصائص الكاميرا الفعّالة. تُستخدم نسخة من فئة `ICameraEffectiveData` كجزء من فئة `IThreeDFormatEffectiveData`، والتي تُعد زوجًا من [القيم الفعّالة](https://reference.aspose.com/slides/php-java/aspose.slides/threedformat/geteffective/) لفئة [ThreeDFormat](https://reference.aspose.com/slides/php-java/aspose.slides/threedformat/).

هذا مثال الشيفرة يوضح لك كيفية الحصول على الخصائص الفعّالة للكاميرا:
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


## **الحصول على الخصائص الفعّالة لتجهيز الإضاءة**
تتيح Aspose.Slides for PHP عبر Java للمطورين الحصول على خصائص تجهيز الإضاءة الفعّالة. لهذا الغرض، تمت إضافة الفئة `ILightRigEffectiveData` إلى Aspose.Slides. تمثّل فئة `ILightRigEffectiveData` كائنًا غير قابل للتغيير يحتوي على خصائص تجهيز الإضاءة الفعّالة. تُستخدم نسخة من فئة `ILightRigEffectiveData` كجزء من فئة `IThreeDFormatEffectiveData`، والتي تُعد زوجًا من [القيم الفعّالة](https://reference.aspose.com/slides/php-java/aspose.slides/threedformat/geteffective/) لفئة [ThreeDFormat](https://reference.aspose.com/slides/php-java/aspose.slides/threedformat/).

هذا مثال الشيفرة يوضح لك كيفية الحصول على الخصائص الفعّالة لتجهيز الإضاءة:
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


## **الحصول على الخصائص الفعّالة لشكل الحافة**
تتيح Aspose.Slides for PHP عبر Java للمطورين الحصول على الخصائص الفعّالة لشكل الحافة. لهذا الغرض، تمت إضافة الفئة `IShapeBevelEffectiveData` إلى Aspose.Slides. تمثّل فئة `IShapeBevelEffectiveData` كائنًا غير قابل للتغيير يحتوي على خصائص النقوش الوجهية الفعّالة للشكل. تُستخدم نسخة من فئة `IShapeBevelEffectiveData` كجزء من فئة `IThreeDFormatEffectiveData`، والتي تُعد زوجًا من [القيم الفعّالة](https://reference.aspose.com/slides/php-java/aspose.slides/threedformat/geteffective/) لفئة [ThreeDFormat](https://reference.aspose.com/slides/php-java/aspose.slides/threedformat/).

هذا مثال الشيفرة يوضح لك كيفية الحصول على الخصائص الفعّالة لشكل الحافة:
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
باستخدام Aspose.Slides for PHP عبر Java، يمكنك الحصول على الخصائص الفعّالة لإطار النص. لهذا الغرض، تم إضافة الفئة `ITextFrameFormatEffectiveData` إلى Aspose.Slides. تحتوي على خصائص تنسيق إطار النص الفعّالة.

هذا مثال الشيفرة يوضح لك كيفية الحصول على خصائص تنسيق إطار النص الفعّالة:
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
باستخدام Aspose.Slides for PHP عبر Java، يمكنك الحصول على الخصائص الفعّالة لنمط النص. لهذا الغرض، تمت إضافة الفئة `ITextStyleEffectiveData` إلى Aspose.Slides. تحتوي على خصائص نمط النص الفعّالة.

هذا مثال الشيفرة يوضح لك كيفية الحصول على خصائص نمط النص الفعّالة:
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
باستخدام Aspose.Slides for PHP عبر Java، يمكنك الحصول على الخصائص الفعّالة لارتفاع الخط. هنا نقدم شيفرة توضح تغيير قيمة ارتفاع الخط الفعّالة للجزء بعد تعيين قيم ارتفاع الخط المحلية على مستويات مختلفة من بنية العرض التقديمي:
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


## **الحصول على تنسيق التعبئة الفعّال لجدول**
باستخدام Aspose.Slides for PHP عبر Java، يمكنك الحصول على تنسيق التعبئة الفعّال لأجزاء منطقية مختلفة من الجدول. لهذا الغرض، تمت إضافة الفئة `ICellFormatEffectiveData` إلى Aspose.Slides. تحتوي على خصائص تنسيق التعبئة الفعّالة. يرجى ملاحظة ما يلي: تنسيق الخلية يحصل دائمًا على الأولوية على تنسيق الصف؛ الصف يحصل على الأولوية على العمود؛ والعمود يحصل على الأولوية على كامل الجدول.
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

**كيف يمكنني معرفة أنني حصلت على "لقطة" بدلاً من "كائن مباشر"، ومتى ينبغي أن أقرأ الخصائص الفعّالة مرة أخرى؟**
كائنات EffectiveData هي لقطات غير قابلة للتغيير للقيم المحسوبة في وقت الاستدعاء. إذا قمت بتغيير الإعدادات المحلية أو الموروثة للشكل, استرجع البيانات الفعّالة مرة أخرى للحصول على القيم المحدثة.

**هل يؤثر تغيير شريحة التخطيط/الرئيسية على الخصائص الفعّالة التي تم استرجاعها مسبقًا؟**
نعم، ولكن فقط بعد قراءتها مرة أخرى. الكائن EffectiveData الذي تم الحصول عليه مسبقًا لا يتم تحديثه تلقائيًا—اطلبه مرة أخرى بعد تغيير التخطيط أو الشريحة الرئيسية.

**هل يمكنني تعديل القيم عبر EffectiveData؟**
لا. EffectiveData للقراءة فقط. قم بإجراء التغييرات في كائنات التنسيق المحلية (الشكل/النص/3D، إلخ)، ثم احصل على القيم الفعّالة مرة أخرى.

**ماذا يحدث إذا لم يتم تعيين خاصية على مستوى الشكل، ولا في التخطيط/الرئيسية، ولا في الإعدادات العالمية؟**
تُحدد القيمة الفعّالة بواسطة آلية الافتراضي (القيم الافتراضية لـ PowerPoint/Aspose.Slides). تلك القيمة المُستخرجة تصبح جزءًا من لقطة EffectiveData.

**من قيمة الخط الفعّالة، هل يمكنني تحديد أي مستوى قدم الحجم أو نوع الخط؟**
ليس مباشرة. تُعيد EffectiveData القيمة النهائية. لتحديد المصدر، راجع القيم المحلية في الجزء/الفقرة/إطار النص وأنماط النص في التخطيط/الرئيسية/العرض التقديمي لتحديد المكان الذي ظهر فيه التعريف الصريح أولًا.

**لماذا تبدو قيم EffectiveData أحيانًا متطابقة مع القيم المحلية؟**
لأن القيمة المحلية أصبحت هي النهائية (لم يُحتاج إلى وراثة من مستوى أعلى). في هذه الحالات، تتطابق القيمة الفعّالة مع القيمة المحلية.

**متى يجب عليّ استخدام الخصائص الفعّالة، ومتى يجب أن أعمل فقط بالقيم المحلية؟**
استخدم EffectiveData عندما تحتاج إلى النتيجة "كما تُعرض" بعد تطبيق كل الوراثة (مثل توافق الألوان أو المسافات أو الأحجام). إذا كنت بحاجة لتغيير التنسيق على مستوى محدد، عدّل الخصائص المحلية ثم، إذا لزم الأمر، أعد قراءة EffectiveData للتحقق من النتيجة.