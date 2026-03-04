---
title: إدارة قوالب العروض التقديمية في PHP
linktitle: قالب العرض التقديمي
type: docs
weight: 10
url: /ar/php-java/presentation-theme/
keywords:
- قالب PowerPoint
- قالب العرض
- قالب الشريحة
- تعيين القالب
- تغيير القالب
- إدارة القالب
- لون القالب
- لوحة ألوان إضافية
- خط القالب
- نمط القالب
- تأثير القالب
- PowerPoint
- OpenDocument
- عرض تقديمي
- PHP
- Aspose.Slides
description: "إدارة قوالب العروض التقديمية في Aspose.Slides للـ PHP عبر Java لإنشاء وتخصيص وتحويل ملفات PowerPoint مع الحفاظ على العلامة التجارية المتسقة."
---
يعرف قالب العرض خصائص عناصر التصميم. عندما تختار قالب عرض، فأنت في الأساس تختار مجموعة محددة من العناصر البصرية وخصائصها.

في PowerPoint، يتألف القالب من ألوان، [fonts](/slides/ar/php-java/powerpoint-fonts/)، [background styles](/slides/ar/php-java/presentation-background/)، وتأثيرات.

![theme-constituents](theme-constituents.png)

## **تغيير لون القالب**

يستخدم قالب PowerPoint مجموعة محددة من الألوان لعناصر مختلفة على الشريحة. إذا لم تعجبك الألوان، يمكنك تغييرها بتطبيق ألوان جديدة على القالب. لتتيح لك اختيار لون قالب جديد، توفر Aspose.Slides قيمًا ضمن تعداد [SchemeColor](https://reference.aspose.com/slides/ar/php-java/aspose.slides/SchemeColor).

```php
  $pres = new Presentation();
  try {
    $shape = $pres->getSlides()->get_Item(0)->getShapes()->addAutoShape(ShapeType::Rectangle, 10, 10, 100, 100);
    $shape->getFillFormat()->setFillType(FillType::Solid);
    $shape->getFillFormat()->getSolidFillColor()->setSchemeColor(SchemeColor->Accent4);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

يمكنك تحديد القيمة الفعّالة للون الناتج بهذه الطريقة:

```php
  $fillEffective = $shape->getFillFormat()->getEffective();
  $effectiveColor = $fillEffective->getSolidFillColor();
  echo(sprintf("Color [A=%d, R=%d, G=%d, B=%d]", $effectiveColor->getAlpha(), $effectiveColor->getRed(), $effectiveColor->getGreen(), $effectiveColor->getBlue()));

```

لتوضيح عملية تغيير اللون بشكل أكبر، نقوم بإنشاء عنصر آخر ونعين له لون التمييز (من العملية الأولية). ثم نغيّر اللون في القالب:

```php
  $otherShape = $pres->getSlides()->get_Item(0)->getShapes()->addAutoShape(ShapeType::Rectangle, 10, 120, 100, 100);
  $otherShape->getFillFormat()->setFillType(FillType::Solid);
  $otherShape->getFillFormat()->getSolidFillColor()->setSchemeColor(SchemeColor->Accent4);
  $pres->getMasterTheme()->getColorScheme()->getAccent4()->setColor(java("java.awt.Color")->RED);
```

يتم تطبيق اللون الجديد تلقائيًا على العنصرين.

### **تعيين لون القالب من لوحة ألوان إضافية**

عند تطبيق تحويلات اللمعان على اللون الرئيسي للقالب(1)، تتشكل ألوان من لوحة الألوان الإضافية(2). يمكنك بعد ذلك تعيين تلك الألوان واسترجاعها.

![additional-palette-colors](additional-palette-colors.png)

**1** - ألوان القالب الرئيسية

**2** - ألوان من لوحة الألوان الإضافية.

```php
  $presentation = new Presentation();
  try {
    $slide = $presentation->getSlides()->get_Item(0);
    # Accent 4
    $shape1 = $slide->getShapes()->addAutoShape(ShapeType::Rectangle, 10, 10, 50, 50);
    $shape1->getFillFormat()->setFillType(FillType::Solid);
    $shape1->getFillFormat()->getSolidFillColor()->setSchemeColor(SchemeColor->Accent4);
    # Accent 4, أفتح 80%
    $shape2 = $slide->getShapes()->addAutoShape(ShapeType::Rectangle, 10, 70, 50, 50);
    $shape2->getFillFormat()->setFillType(FillType::Solid);
    $shape2->getFillFormat()->getSolidFillColor()->setSchemeColor(SchemeColor->Accent4);
    $shape2->getFillFormat()->getSolidFillColor()->getColorTransform()->add(ColorTransformOperation->MultiplyLuminance, 0.2);
    $shape2->getFillFormat()->getSolidFillColor()->getColorTransform()->add(ColorTransformOperation->AddLuminance, 0.8);
    # Accent 4, أفتح 60%
    $shape3 = $slide->getShapes()->addAutoShape(ShapeType::Rectangle, 10, 130, 50, 50);
    $shape3->getFillFormat()->setFillType(FillType::Solid);
    $shape3->getFillFormat()->getSolidFillColor()->setSchemeColor(SchemeColor->Accent4);
    $shape3->getFillFormat()->getSolidFillColor()->getColorTransform()->add(ColorTransformOperation->MultiplyLuminance, 0.4);
    $shape3->getFillFormat()->getSolidFillColor()->getColorTransform()->add(ColorTransformOperation->AddLuminance, 0.6);
    # Accent 4, أفتح 40%
    $shape4 = $slide->getShapes()->addAutoShape(ShapeType::Rectangle, 10, 190, 50, 50);
    $shape4->getFillFormat()->setFillType(FillType::Solid);
    $shape4->getFillFormat()->getSolidFillColor()->setSchemeColor(SchemeColor->Accent4);
    $shape4->getFillFormat()->getSolidFillColor()->getColorTransform()->add(ColorTransformOperation->MultiplyLuminance, 0.6);
    $shape4->getFillFormat()->getSolidFillColor()->getColorTransform()->add(ColorTransformOperation->AddLuminance, 0.4);
    # Accent 4, أغمق 25%
    $shape5 = $slide->getShapes()->addAutoShape(ShapeType::Rectangle, 10, 250, 50, 50);
    $shape5->getFillFormat()->setFillType(FillType::Solid);
    $shape5->getFillFormat()->getSolidFillColor()->setSchemeColor(SchemeColor->Accent4);
    $shape5->getFillFormat()->getSolidFillColor()->getColorTransform()->add(ColorTransformOperation->MultiplyLuminance, 0.75);
    # Accent 4, أغمق 50%
    $shape6 = $slide->getShapes()->addAutoShape(ShapeType::Rectangle, 10, 310, 50, 50);
    $shape6->getFillFormat()->setFillType(FillType::Solid);
    $shape6->getFillFormat()->getSolidFillColor()->setSchemeColor(SchemeColor->Accent4);
    $shape6->getFillFormat()->getSolidFillColor()->getColorTransform()->add(ColorTransformOperation->MultiplyLuminance, 0.5);
    $presentation->save($path . "example_accent4.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($presentation)) {
      $presentation->dispose();
    }
  }
```

### **ربط `SchemeColor` بألوان `ColorScheme`**

عند العمل مع [SchemeColor](https://reference.aspose.com/slides/ar/php-java/aspose.slides/schemecolor/)، قد تلاحظ أنه يحتوي على قيم ألوان القالب التالية:

`Background1`, `Background2`, `Text1`, and `Text2`.

مع ذلك، تُرجع `Presentation::getMasterTheme()::getColorScheme()` كائنًا من نوع [ColorScheme](https://reference.aspose.com/slides/ar/php-java/aspose.slides/colorscheme/)، الذي يُظهر الألوان المقابلة كالتالي:

`Dark1`, `Dark2`, `Light1`, and `Light2`.

هذا الاختلاف في التسمية فقط. هذه القيم تشير إلى نفس فتحات ألوان القالب والربط ثابت:

* `Text1` = `Dark1`
* `Background1` = `Light1`
* `Text2` = `Dark2`
* `Background2` = `Light2`

لا يوجد تحويل ديناميكي بين `Text`/`Background` و `Dark`/`Light`. إنها مجرد أسماء بديلة لنفس ألوان القالب.

يأتي هذا الاختلاف في التسمية من مصطلحات Microsoft Office. استخدمت إصدارات Office القديمة `Dark 1` و `Light 1` و `Dark 2` و `Light 2`، بينما تعرض إصدارات الواجهة الحديثة نفس الفتحات كـ `Text 1` و `Background 1` و `Text 2` و `Background 2`.

## **تغيير خط القالب**

لتتيح لك اختيار خطوط للقوالب وأغراض أخرى، تستخدم Aspose.Slides هذه المعرفات الخاصة (مشابهة لتلك المستخدمة في PowerPoint):

* **+mn-lt** - خط النص الأساسي للغة اللاتينية (خط لاتيني فرعي)
* **+mj-lt** - خط عنوان للغة اللاتينية (خط لاتيني رئيسي)
* **+mn-ea** - خط النص الأساسي للغة آسيا الشرقية (خط شرق آسيوي فرعي)
* **+mj-ea** - خط النص الأساسي للغة آسيا الشرقية (خط شرق آسيوي رئيسي)

يعرض لك هذا الشيفرة PHP كيفية تعيين الخط اللاتيني إلى عنصر القالب:

```php
  $shape = $pres->getSlides()->get_Item(0)->getShapes()->addAutoShape(ShapeType::Rectangle, 10, 10, 100, 100);
  $paragraph = new Paragraph();
  $portion = new Portion("Theme text format");
  $paragraph->getPortions()->add($portion);
  $shape->getTextFrame()->getParagraphs()->add($paragraph);
  $portion->getPortionFormat()->setLatinFont(new FontData("+mn-lt"));

```

يعرض لك هذا الشيفرة PHP كيفية تغيير خط قالب العرض:

```php
  $pres->getMasterTheme()->getFontScheme()->getMinor()->setLatinFont(new FontData("Arial"));

```

سيتم تحديث الخط في جميع صناديق النص.

{{% alert color="primary" title="TIP" %}} 
قد ترغب في الاطلاع على [PowerPoint fonts](/slides/ar/php-java/powerpoint-fonts/).
{{% /alert %}}

## **تغيير نمط خلفية القالب**

بشكل افتراضي، يقدم تطبيق PowerPoint 12 خلفية معرفة مسبقًا ولكن يتم حفظ 3 فقط من تلك الخلفيات الـ12 في عرض تقديمي نموذجي.

![todo:image_alt_text](presentation-design_8.png)

على سبيل المثال، بعد حفظ عرض تقديمي في تطبيق PowerPoint، يمكنك تشغيل هذا الشيفرة PHP لمعرفة عدد الخلفيات المعرفة مسبقًا في العرض:

```php
  $pres = new Presentation("pres.pptx");
  try {
    $numberOfBackgroundFills = $pres->getMasterTheme()->getFormatScheme()->getBackgroundFillStyles()->size();
    echo("Number of background fill styles for theme is " . $numberOfBackgroundFills);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

{{% alert color="warning" %}} 
باستخدام الخاصية [BackgroundFillStyles](https://reference.aspose.com/slides/ar/php-java/aspose.slides/FormatScheme#getBackgroundFillStyles--) من الفئة [FormatScheme](https://reference.aspose.com/slides/ar/php-java/aspose.slides/FormatScheme)، يمكنك إضافة أو الوصول إلى نمط الخلفية في قالب PowerPoint.
{{% /alert %}} 

يعرض لك هذا الشيفرة PHP كيفية تعيين الخلفية لعروض تقديمية:

```php
  $pres->getMasters()->get_Item(0)->getBackground()->setStyleIndex(2);
```

**دليل الفهرس**: 0 يُستخدم بدون تعبئة. يبدأ الفهرس من 1.

{{% alert color="primary" title="TIP" %}} 
قد ترغب في الاطلاع على [PowerPoint Background](/slides/ar/php-java/presentation-background/).
{{% /alert %}}

## **تغيير تأثير القالب**

عادةً ما يحتوي قالب PowerPoint على 3 قيم لكل مصفوفة نمط. تُدمج تلك المصفوفات في 3 تأثيرات: خفيف، متوسط، وشديد. على سبيل المثال، هذه هي النتيجة عند تطبيق التأثيرات على شكل معين:

![todo:image_alt_text](presentation-design_10.png)

باستخدام 3 خصائص ([FillStyles](https://reference.aspose.com/slides/ar/php-java/aspose.slides/FormatScheme#getFillStyles--), [LineStyles](https://reference.aspose.com/slides/ar/php-java/aspose.slides/FormatScheme#getLineStyles--), [EffectStyles](https://reference.aspose.com/slides/ar/php-java/aspose.slides/FormatScheme#getEffectStyles--)) من الفئة [FormatScheme](https://reference.aspose.com/slides/ar/php-java/aspose.slides/FormatScheme) يمكنك تغيير العناصر في القالب (بمرونة أكبر من الخيارات في PowerPoint).

```php
  $pres = new Presentation("Subtle_Moderate_Intense.pptx");
  try {
    $pres->getMasterTheme()->getFormatScheme()->getLineStyles()->get_Item(0)->getFillFormat()->getSolidFillColor()->setColor(java("java.awt.Color")->RED);
    $pres->getMasterTheme()->getFormatScheme()->getFillStyles()->get_Item(2)->setFillType(FillType::Solid);
    $pres->getMasterTheme()->getFormatScheme()->getFillStyles()->get_Item(2)->getSolidFillColor()->setColor(java("java.awt.Color")->GREEN);
    $pres->getMasterTheme()->getFormatScheme()->getEffectStyles()->get_Item(2)->getEffectFormat()->getOuterShadowEffect()->setDistance(10.0);
    $pres->save("Design_04_Subtle_Moderate_Intense-out.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

التغييرات الناتجة في لون التعبئة، نوع التعبئة، تأثير الظل، إلخ:

![todo:image_alt_text](presentation-design_11.png)

## **الأسئلة الشائعة**

**هل يمكنني تطبيق قالب على شريحة واحدة دون تغيير القالب الرئيسي؟**

نعم. تدعم Aspose.Slides تجاوزات القالب على مستوى الشريحة، بحيث يمكنك تطبيق قالب محلي على تلك الشريحة فقط مع الحفاظ على قالب الماستر دون تغيير (عن طريق [SlideThemeManager](https://reference.aspose.com/slides/ar/php-java/aspose.slides/slidethememanager/)).

**ما هي الطريقة الأكثر أمانًا لنقل قالب من عرض تقديمي إلى آخر؟**

[Clone slides](/slides/ar/php-java/clone-slides/) مع الماستر الخاص بهم إلى العرض المستهدف. هذا يحافظ على الماستر الأصلي، التخطيطات، والقالب المرتبط بحيث يظل المظهر متسقًا.

**كيف يمكنني رؤية القيم "الفعّالة" بعد جميع الوراثة والتجاوزات؟**

استخدم "العروض الفعّالة" في API عبر ["effective" views](/slides/ar/php-java/shape-effective-properties/) للقالب/اللون/الخط/التأثير. تُعيد هذه القيم الخصائص النهائية بعد تطبيق الماستر وأي تجاوزات محلية.