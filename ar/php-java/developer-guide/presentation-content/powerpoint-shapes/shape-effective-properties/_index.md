---
title: خصائص الشكل الفعالة
type: docs
weight: 50
url: /php-java/shape-effective-properties/
---

في هذا الموضوع، سنناقش الخصائص **الفعالة** و**المحلية**. عندما نقوم بتعيين القيم مباشرة عند هذه المستويات

1. في خصائص الجزء على شريحة الجزء؛
1. في نمط نص الشكل على الشريحة التخطيطية أو الشريحة الرئيسية (إذا كان شكل إطار نص الجزء يحتوي على واحدة)؛
1. في إعدادات النص العامة للعروض التقديمية؛

تسمى تلك القيم **محلية**. في أي مستوى، يمكن تعريف أو حذف القيم **المحلية**. ولكن عندما يحتاج التطبيق لمعرفة كيف ينبغي أن يبدو الجزء، فإنه يستخدم القيم **الفعالة**. يمكنك الحصول على القيم الفعالة باستخدام طريقة **getEffective()** من التنسيق المحلي.

هذا الكود النموذج يوضح لك كيفية الحصول على القيم الفعالة:

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

## **الحصول على الخصائص الفعالة للكاميرا**
Aspose.Slides لـ PHP عبر Java يسمح للمطورين بالحصول على الخصائص الفعالة للكاميرا. لهذا الغرض، تمت إضافة واجهة [**ICameraEffectiveData**](https://reference.aspose.com/slides/php-java/aspose.slides/ICameraEffectiveData) إلى Aspose.Slides. تمثل واجهة [ICameraEffectiveData](https://reference.aspose.com/slides/php-java/aspose.slides/ICameraEffectiveData) كائنًا غير قابل للتغيير يحتوي على الخصائص الفعالة للكاميرا. تُستخدم نسخة من واجهة [**ICameraEffectiveData**](https://reference.aspose.com/slides/php-java/aspose.slides/ICameraEffectiveData) كجزء من واجهة [**IThreeDFormatEffectiveData**](https://reference.aspose.com/slides/php-java/aspose.slides/IThreeDFormatEffectiveData)، والتي تعد زوجًا من [القيم الفعالة](https://reference.aspose.com/slides/php-java/aspose.slides/ThreeDFormat#getEffective--) لصف class [ThreeDFormat](https://reference.aspose.com/slides/php-java/aspose.slides/ThreeDFormat).

هذا المثال من الكود يوضح لك كيفية الحصول على الخصائص الفعالة للكاميرا:

```php
  $pres = new Presentation("Presentation1.pptx");
  try {
    $threeDEffectiveData = $pres->getSlides()->get_Item(0)->getShapes()->get_Item(0)->getThreeDFormat()->getEffective();
    echo("= الخصائص الفعالة للكاميرا =");
    echo("النوع: " . $threeDEffectiveData->getCamera()->getCameraType());
    echo("مجال الرؤية: " . $threeDEffectiveData->getCamera()->getFieldOfViewAngle());
    echo("التكبير: " . $threeDEffectiveData->getCamera()->getZoom());
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

## **الحصول على الخصائص الفعالة لهيئة الإضاءة**
Aspose.Slides لـ PHP عبر Java يسمح للمطورين بالحصول على الخصائص الفعالة لهيئة الإضاءة. لهذا الغرض، تمت إضافة واجهة [**ILightRigEffectiveData**](https://reference.aspose.com/slides/php-java/aspose.slides/ILightRigEffectiveData) إلى Aspose.Slides. تمثل واجهة [ILightRigEffectiveData](https://reference.aspose.com/slides/php-java/aspose.slides/ILightRigEffectiveData) كائنًا غير قابل للتغيير يحتوي على خصائص هيئة الإضاءة الفعالة. تُستخدم نسخة من واجهة [**ILightRigEffectiveData**](https://reference.aspose.com/slides/php-java/aspose.slides/ILightRigEffectiveData) كجزء من واجهة [**IThreeDFormatEffectiveData**](https://reference.aspose.com/slides/php-java/aspose.slides/IThreeDFormatEffectiveData)، والتي تعد زوجًا من [القيم الفعالة](https://reference.aspose.com/slides/php-java/aspose.slides/ThreeDFormat#getEffective--) لصف class [ThreeDFormat](https://reference.aspose.com/slides/php-java/aspose.slides/ThreeDFormat).

هذا المثال من الكود يوضح لك كيفية الحصول على الخصائص الفعالة لهيئة الإضاءة:

```php
  $pres = new Presentation("Presentation1.pptx");
  try {
    $threeDEffectiveData = $pres->getSlides()->get_Item(0)->getShapes()->get_Item(0)->getThreeDFormat()->getEffective();
    echo("= الخصائص الفعالة لهيئة الإضاءة =");
    echo("النوع: " . $threeDEffectiveData->getLightRig()->getLightType());
    echo("الاتجاه: " . $threeDEffectiveData->getLightRig()->getDirection());
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

## **الحصول على الخصائص الفعالة لشكل التحديد**
Aspose.Slides لـ PHP عبر Java يسمح للمطورين بالحصول على الخصائص الفعالة لشكل التحديد. لهذا الغرض، تمت إضافة واجهة [**IShapeBevelEffectiveData**](https://reference.aspose.com/slides/php-java/aspose.slides/IShapeBevelEffectiveData) إلى Aspose.Slides. تمثل واجهة [IShapeBevelEffectiveData](https://reference.aspose.com/slides/php-java/aspose.slides/IShapeBevelEffectiveData) كائنًا غير قابل للتغيير يحتوي على خصائص تخفيض واجهة الشكل. تُستخدم نسخة من واجهة [**IShapeBevelEffectiveData**](https://reference.aspose.com/slides/php-java/aspose.slides/IShapeBevelEffectiveData) كجزء من واجهة [**IThreeDFormatEffectiveData**](https://reference.aspose.com/slides/php-java/aspose.slides/IThreeDFormatEffectiveData)، والتي تعد زوجًا من [القيم الفعالة](https://reference.aspose.com/slides/php-java/aspose.slides/ThreeDFormat#getEffective--) لصف class [ThreeDFormat](https://reference.aspose.com/slides/php-java/aspose.slides/ThreeDFormat).

هذا المثال من الكود يوضح لك كيفية الحصول على الخصائص الفعالة لشكل التحديد:

```php
  $pres = new Presentation("Presentation1.pptx");
  try {
    $threeDEffectiveData = $pres->getSlides()->get_Item(0)->getShapes()->get_Item(0)->getThreeDFormat()->getEffective();
    echo("= الخصائص الفعالة للسطح العلوي للشكل =");
    echo("النوع: " . $threeDEffectiveData->getBevelTop()->getBevelType());
    echo("العرض: " . $threeDEffectiveData->getBevelTop()->getWidth());
    echo("الارتفاع: " . $threeDEffectiveData->getBevelTop()->getHeight());
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

## **الحصول على الخصائص الفعالة لإطار النص**
باستخدام Aspose.Slides لـ PHP عبر Java، يمكنك الحصول على الخصائص الفعالة لإطار النص. لهذا الغرض، تمت إضافة واجهة [**ITextFrameFormatEffectiveData**](https://reference.aspose.com/slides/php-java/aspose.slides/ITextFrameFormatEffectiveData) إلى Aspose.Slides. تحتوي على خصائص تنسيق إطار النص الفعالة.

هذا المثال من الكود يوضح لك كيفية الحصول على خصائص تنسيق إطار النص الفعالة:

```php
  $pres = new Presentation("Presentation1.pptx");
  try {
    $shape = $pres->getSlides()->get_Item(0)->getShapes()->get_Item(0);
    $effectiveTextFrameFormat = $shape->getTextFrame()->getTextFrameFormat()->getEffective();
    echo("نوع التركيز: " . $effectiveTextFrameFormat::getAnchoringType());
    echo("نوع التلقائي: " . $effectiveTextFrameFormat::getAutofitType());
    echo("نوع النص العمودي: " . $effectiveTextFrameFormat::getTextVerticalType());
    echo("الهوامش");
    echo("   اليسار: " . $effectiveTextFrameFormat::getMarginLeft());
    echo("   الأعلى: " . $effectiveTextFrameFormat::getMarginTop());
    echo("   اليمين: " . $effectiveTextFrameFormat::getMarginRight());
    echo("   الأسفل: " . $effectiveTextFrameFormat::getMarginBottom());
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

## **الحصول على الخصائص الفعالة لنمط النص**
باستخدام Aspose.Slides لـ PHP عبر Java، يمكنك الحصول على الخصائص الفعالة لنمط النص. لهذا الغرض، تمت إضافة واجهة [**ITextStyleEffectiveData**](https://reference.aspose.com/slides/php-java/aspose.slides/ITextStyleEffectiveData) إلى Aspose.Slides. تحتوي على خصائص نمط النص الفعالة.

هذا المثال من الكود يوضح لك كيفية الحصول على خصائص نمط النص الفعالة:

```php
  $pres = new Presentation("Presentation1.pptx");
  try {
    $shape = $pres->getSlides()->get_Item(0)->getShapes()->get_Item(0);
    $effectiveTextStyle = $shape->getTextFrame()->getTextFrameFormat()->getTextStyle()->getEffective();
    for($i = 0; $i <= 8; $i++) {
      $effectiveStyleLevel = $effectiveTextStyle->getLevel($i);
      echo("= التنسيق الفعال للفقرة لمستوى النمط #" . $i . " =");
      echo("العمق: " . $effectiveStyleLevel->getDepth());
      echo("المسافة: " . $effectiveStyleLevel->getIndent());
      echo("المحاذاة: " . $effectiveStyleLevel->getAlignment());
      echo("محاذاة الخط: " . $effectiveStyleLevel->getFontAlignment());
    }
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

## **الحصول على قيمة ارتفاع الخط الفعال**
باستخدام Aspose.Slides لـ PHP عبر Java، يمكنك الحصول على الخصائص الفعالة لارتفاع الخط. هنا، نقدم كودًا يوضح قيمة ارتفاع الخط الفعال للجزء حيث تتغير بعد تعيين قيم ارتفاع الخط المحلية على مستويات مختلفة من بنية العرض التقديمي:

```php
  $pres = new Presentation();
  try {
    $newShape = $pres->getSlides()->get_Item(0)->getShapes()->addAutoShape(ShapeType::Rectangle, 100, 100, 400, 75, false);
    $newShape->addTextFrame("");
    $newShape->getTextFrame()->getParagraphs()->get_Item(0)->getPortions()->clear();
    $portion0 = new Portion("نص عينة مع الجزء الأول");
    $portion1 = new Portion(" و الجزء الثاني.");
    $newShape->getTextFrame()->getParagraphs()->get_Item(0)->getPortions()->add($portion0);
    $newShape->getTextFrame()->getParagraphs()->get_Item(0)->getPortions()->add($portion1);
    echo("ارتفاع الخط الفعال بعد الإنشاء مباشرة:");
    echo("الجزء #0: " . $portion0->getPortionFormat()->getEffective()->getFontHeight());
    echo("الجزء #1: " . $portion1->getPortionFormat()->getEffective()->getFontHeight());
    $pres->getDefaultTextStyle()->getLevel(0)->getDefaultPortionFormat()->setFontHeight(24);
    echo("ارتفاع الخط الفعال بعد تعيين ارتفاع الخط الافتراضي للعروض التقديمية بالكامل:");
    echo("الجزء #0: " . $portion0->getPortionFormat()->getEffective()->getFontHeight());
    echo("الجزء #1: " . $portion1->getPortionFormat()->getEffective()->getFontHeight());
    $newShape->getTextFrame()->getParagraphs()->get_Item(0)->getParagraphFormat()->getDefaultPortionFormat()->setFontHeight(40);
    echo("ارتفاع الخط الفعال بعد تعيين ارتفاع الخط الافتراضي للفقرة:");
    echo("الجزء #0: " . $portion0->getPortionFormat()->getEffective()->getFontHeight());
    echo("الجزء #1: " . $portion1->getPortionFormat()->getEffective()->getFontHeight());
    $newShape->getTextFrame()->getParagraphs()->get_Item(0)->getPortions()->get_Item(0)->getPortionFormat()->setFontHeight(55);
    echo("ارتفاع الخط الفعال بعد تعيين ارتفاع الخط للجزء #0:");
    echo("الجزء #0: " . $portion0->getPortionFormat()->getEffective()->getFontHeight());
    echo("الجزء #1: " . $portion1->getPortionFormat()->getEffective()->getFontHeight());
    $newShape->getTextFrame()->getParagraphs()->get_Item(0)->getPortions()->get_Item(1)->getPortionFormat()->setFontHeight(18);
    echo("ارتفاع الخط الفعال بعد تعيين ارتفاع الخط للجزء #1:");
    echo("الجزء #0: " . $portion0->getPortionFormat()->getEffective()->getFontHeight());
    echo("الجزء #1: " . $portion1->getPortionFormat()->getEffective()->getFontHeight());
    $pres->save("SetLocalFontHeightValues.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

## **الحصول على تنسيق التعبئة الفعالة للجدول**
باستخدام Aspose.Slides لـ PHP عبر Java، يمكنك الحصول على تنسيق التعبئة الفعالة لأجزاء منطقية مختلفة من الجدول. لهذا الغرض، تمت إضافة واجهة [**ICellFormatEffectiveData**](https://reference.aspose.com/slides/php-java/aspose.slides/ICellFormatEffectiveData) في Aspose.Slides. تحتوي على خصائص تنسيق التعبئة الفعالة. يرجى ملاحظة ما يلي: تنسيق الخلايا دائمًا ما يحصل على أولوية على تنسيق الصف؛ الصف يحصل على أولوية على العمود؛ والعمود يحصل على أولوية على الجدول بالكامل.

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