---
title: إدارة قوالب العروض التقديمية في PHP
linktitle: قالب العرض التقديمي
type: docs
weight: 10
url: /ar/php-java/presentation-theme/
keywords:
- قالب PowerPoint
- قالب العرض التقديمي
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

قالب العرض يحدد خصائص عناصر التصميم. عندما تختار قالب عرض، فأنت في الأساس تختار مجموعة محددة من العناصر البصرية وخصائصها.

في PowerPoint، يتكون القالب من ألوان، [الخطوط](/slides/ar/php-java/powerpoint-fonts/)، [أنماط الخلفية](/slides/ar/php-java/presentation-background/)، وتأثيرات.

![theme-constituents](theme-constituents.png)

## **تغيير لون القالب**

يستخدم قالب PowerPoint مجموعة محددة من الألوان لعناصر مختلفة في الشريحة. إذا لم تعجبك الألوان، يمكنك تغييرها بتطبيق ألوان جديدة على القالب. للسماح لك باختيار لون قالب جديد، توفر Aspose.Slides قيمًا ضمن تعداد [SchemeColor](https://reference.aspose.com/slides/php-java/aspose.slides/SchemeColor).

يعرض لك هذا الشيفرة PHP كيفية تغيير اللون المميز للقالب:
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


يمكنك تحديد القيمة الفعلية للون الناتج بهذه الطريقة:
```php
  $fillEffective = $shape->getFillFormat()->getEffective();
  $effectiveColor = $fillEffective->getSolidFillColor();
  echo(sprintf("Color [A=%d, R=%d, G=%d, B=%d]", $effectiveColor->getAlpha(), $effectiveColor->getRed(), $effectiveColor->getGreen(), $effectiveColor->getBlue()));

```


لتوضيح عملية تغيير اللون أكثر، نقوم بإنشاء عنصر آخر ونعيّن له اللون المميز (من العملية الأولية). ثم نغير اللون في القالب:
```php
  $otherShape = $pres->getSlides()->get_Item(0)->getShapes()->addAutoShape(ShapeType::Rectangle, 10, 120, 100, 100);
  $otherShape->getFillFormat()->setFillType(FillType::Solid);
  $otherShape->getFillFormat()->getSolidFillColor()->setSchemeColor(SchemeColor->Accent4);
  $pres->getMasterTheme()->getColorScheme()->getAccent4()->setColor(java("java.awt.Color")->RED);
```


يتم تطبيق اللون الجديد تلقائيًا على كلا العنصرين.

### **تعيين لون القالب من لوحة ألوان إضافية**

عند تطبيق تحويلات الإضاءة على اللون الرئيسي للقالب(1)، تتشكل ألوان من لوحة الألوان الإضافية(2). يمكنك بعد ذلك تعيين تلك الألوان القالبية والحصول عليها.

![additional-palette-colors](additional-palette-colors.png)

**1** - الألوان الرئيسية للقالب  
**2** - ألوان من لوحة الألوان الإضافية.

يعرض لك هذا الشيفرة PHP عملية يتم فيها الحصول على ألوان لوحة الألوان الإضافية من اللون الرئيسي للقالب ثم استخدامها في الأشكال:
```php
  $presentation = new Presentation();
  try {
    $slide = $presentation->getSlides()->get_Item(0);
    # التمييز 4
    $shape1 = $slide->getShapes()->addAutoShape(ShapeType::Rectangle, 10, 10, 50, 50);
    $shape1->getFillFormat()->setFillType(FillType::Solid);
    $shape1->getFillFormat()->getSolidFillColor()->setSchemeColor(SchemeColor->Accent4);
    # التمييز 4، أفتح بنسبة 80%
    $shape2 = $slide->getShapes()->addAutoShape(ShapeType::Rectangle, 10, 70, 50, 50);
    $shape2->getFillFormat()->setFillType(FillType::Solid);
    $shape2->getFillFormat()->getSolidFillColor()->setSchemeColor(SchemeColor->Accent4);
    $shape2->getFillFormat()->getSolidFillColor()->getColorTransform()->add(ColorTransformOperation->MultiplyLuminance, 0.2);
    $shape2->getFillFormat()->getSolidFillColor()->getColorTransform()->add(ColorTransformOperation->AddLuminance, 0.8);
    # التمييز 4، أفتح بنسبة 60%
    $shape3 = $slide->getShapes()->addAutoShape(ShapeType::Rectangle, 10, 130, 50, 50);
    $shape3->getFillFormat()->setFillType(FillType::Solid);
    $shape3->getFillFormat()->getSolidFillColor()->setSchemeColor(SchemeColor->Accent4);
    $shape3->getFillFormat()->getSolidFillColor()->getColorTransform()->add(ColorTransformOperation->MultiplyLuminance, 0.4);
    $shape3->getFillFormat()->getSolidFillColor()->getColorTransform()->add(ColorTransformOperation->AddLuminance, 0.6);
    # التمييز 4، أفتح بنسبة 40%
    $shape4 = $slide->getShapes()->addAutoShape(ShapeType::Rectangle, 10, 190, 50, 50);
    $shape4->getFillFormat()->setFillType(FillType::Solid);
    $shape4->getFillFormat()->getSolidFillColor()->setSchemeColor(SchemeColor->Accent4);
    $shape4->getFillFormat()->getSolidFillColor()->getColorTransform()->add(ColorTransformOperation->MultiplyLuminance, 0.6);
    $shape4->getFillFormat()->getSolidFillColor()->getColorTransform()->add(ColorTransformOperation->AddLuminance, 0.4);
    # التمييز 4، أغمق بنسبة 25%
    $shape5 = $slide->getShapes()->addAutoShape(ShapeType::Rectangle, 10, 250, 50, 50);
    $shape5->getFillFormat()->setFillType(FillType::Solid);
    $shape5->getFillFormat()->getSolidFillColor()->setSchemeColor(SchemeColor->Accent4);
    $shape5->getFillFormat()->getSolidFillColor()->getColorTransform()->add(ColorTransformOperation->MultiplyLuminance, 0.75);
    # التمييز 4، أغمق بنسبة 50%
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


## **تغيير خط القالب**

للسماح لك باختيار الخطوط للقوالب وأغراض أخرى، تستخدم Aspose.Slides هذه المعرفات الخاصة (مشابهة لتلك المستخدمة في PowerPoint):

* **+mn-lt** - الخط الأساسي للغة اللاتينية (خط لاتيني صغير)
* **+mj-lt** - خط العنوان للغة اللاتينية (خط لاتيني كبير)
* **+mn-ea** - الخط الأساسي للغات شرق آسيا (خط شرق آسيوي صغير)
* **+mj-ea** - الخط الأساسي للغات شرق آسيا (خط شرق آسيوي كبير)

يعرض لك هذا الشيفرة PHP كيفية تعيين الخط اللاتيني لعنصر القالب:
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


سيتم تحديث الخط في جميع مربعات النص.

{{% alert color="primary" title="TIP" %}} 
قد ترغب في الاطلاع على [خطوط PowerPoint](/slides/ar/php-java/powerpoint-fonts/).
{{% /alert %}}

## **تغيير نمط خلفية القالب**

بشكل افتراضي، يوفر تطبيق PowerPoint 12 خلفية مُعرّفة مسبقًا لكن فقط 3 من تلك الخلفيات تُحفظ في عرض تقديمي نموذجي.

![todo:image_alt_text](presentation-design_8.png)

على سبيل المثال، بعد حفظ عرض تقديمي في تطبيق PowerPoint، يمكنك تشغيل هذا الشيفرة PHP لمعرفة عدد الخلفيات المُعرّفة مسبقًا في العرض:
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
باستخدام خاصية [BackgroundFillStyles](https://reference.aspose.com/slides/php-java/aspose.slides/FormatScheme#getBackgroundFillStyles--) من فئة [FormatScheme](https://reference.aspose.com/slides/php-java/aspose.slides/FormatScheme)، يمكنك إضافة أو الوصول إلى نمط الخلفية في قالب PowerPoint.
{{% /alert %}} 

يعرض لك هذا الشيفرة PHP كيفية تعيين الخلفية لعرض تقديمي:
```php
  $pres->getMasters()->get_Item(0)->getBackground()->setStyleIndex(2);
```


**دليل الفهرس**: يُستخدم 0 لعدم التعبئة. يبدأ الفهرس من 1.

{{% alert color="primary" title="TIP" %}} 
قد ترغب في الاطلاع على [خلفية PowerPoint](/slides/ar/php-java/presentation-background/).
{{% /alert %}}

## **تغيير تأثير القالب**

عادةً ما يحتوي قالب PowerPoint على 3 قيم لكل مصفوفة نمط. تُدمج تلك المصفوفات لتشكل هذه التأثيرات الثلاثة: خفيف، متوسط، وشديد. على سبيل المثال، هذه هي النتيجة عند تطبيق التأثيرات على شكل معين:

![todo:image_alt_text](presentation-design_10.png)

باستخدام 3 خصائص ([FillStyles](https://reference.aspose.com/slides/php-java/aspose.slides/FormatScheme#getFillStyles--), [LineStyles](https://reference.aspose.com/slides/php-java/aspose.slides/FormatScheme#getLineStyles--), [EffectStyles](https://reference.aspose.com/slides/php-java/aspose.slides/FormatScheme#getEffectStyles--)) من فئة [FormatScheme](https://reference.aspose.com/slides/php-java/aspose.slides/FormatScheme) يمكنك تعديل العناصر في القالب (بمرونة أكبر من الخيارات المتوفرة في PowerPoint).

يعرض لك هذا الشيفرة PHPكيفية تغيير تأثير القالب عن طريق تعديل أجزاء من العناصر:
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

**هل يمكنني تطبيق قالب على شريحة واحدة دون تغيير الرئيسي؟**  
نعم. تدعم Aspose.Slides تجاوزات القالب على مستوى الشريحة، بحيث يمكنك تطبيق قالب محلي على تلك الشريحة فقط مع الحفاظ على قالب الرئيس الأصلي (من خلال [SlideThemeManager](https://reference.aspose.com/slides/php-java/aspose.slides/slidethememanager/)).

**ما هي الطريقة الأكثر أمانًا لنقل قالب من عرض تقديمي إلى آخر؟**  
[نسخ الشرائح](/slides/ar/php-java/clone-slides/) مع رئيسها إلى العرض الهدف. هذا يحافظ على الرئيس الأصلي، التخطيطات، والقالب المرتبط بحيث يبقى المظهر متسقًا.

**كيف يمكنني رؤية القيم "الفعّالة" بعد جميع الوراثة والتجاوزات؟**  
استخدم "العروض الفعّالة" في الـ API [/slides/php-java/shape-effective-properties/] للموضوع/اللون/الخط/التأثير. تُعيد هذه القيم الخصائص المُحَلة النهائية بعد تطبيق الرئيس وأي تجاوزات محلية.