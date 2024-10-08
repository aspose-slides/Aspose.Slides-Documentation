---
title: ثيم العرض
type: docs
weight: 10
url: /ar/php-java/presentation-theme/
keywords: "ثيم، ثيم PowerPoint، عرض PowerPoint، Java، Aspose.Slides لـ PHP عبر Java"
description: "ثيم عرض PowerPoint"
---

يحدد ثيم العرض خصائص عناصر التصميم. عند اختيار ثيم عرض، تقوم في الأساس باختيار مجموعة معينة من العناصر المرئية وخصائصها.

في PowerPoint، يتكون الثيم من ألوان، [خطوط](/slides/ar/php-java/powerpoint-fonts/)، [أنماط خلفية](/slides/ar/php-java/presentation-background/)، وتأثيرات.

![مكونات الثيم](theme-constituents.png)

## **تغيير لون الثيم**

يستخدم ثيم PowerPoint مجموعة محددة من الألوان لعناصر مختلفة على الشريحة. إذا لم تعجبك الألوان، يمكنك تغييرها من خلال تطبيق ألوان جديدة للثيم. للسماح لك باختيار لون ثيم جديد، توفر Aspose.Slides قيمًا تحت [SchemeColor](https://reference.aspose.com/slides/php-java/aspose.slides/SchemeColor) التعداد.

يوضح لك كود PHP هذا كيفية تغيير لون التأكيد لثيم:

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
  echo(sprintf("اللون [A=%d، R=%d، G=%d، B=%d]", $effectiveColor->getAlpha(), $effectiveColor->getRed(), $effectiveColor->getGreen(), $effectiveColor->getBlue()));
```

لتوضيح عملية تغيير اللون أكثر، نقوم بإنشاء عنصر آخر ونassign له لون التأكيد (من العملية الأولية). ثم نغير اللون في الثيم:

```php
  $otherShape = $pres->getSlides()->get_Item(0)->getShapes()->addAutoShape(ShapeType::Rectangle, 10, 120, 100, 100);
  $otherShape->getFillFormat()->setFillType(FillType::Solid);
  $otherShape->getFillFormat()->getSolidFillColor()->setSchemeColor(SchemeColor->Accent4);
  $pres->getMasterTheme()->getColorScheme()->getAccent4()->setColor(java("java.awt.Color")->RED);
```

يتم تطبيق اللون الجديد تلقائيًا على كلا العنصرين.

### **تعيين لون الثيم من لوحة إضافية**

عند تطبيق تحولات اللمعان على لون الثيم الرئيسي(1)، تتشكل ألوان من اللوحة الإضافية(2). يمكنك بعد ذلك تعيين تلك الألوان والحصول عليها.

![ألوان اللوحة الإضافية](additional-palette-colors.png)

**1** - ألوان الثيم الرئيسية

**2** - ألوان من اللوحة الإضافية.

يوضح كود PHP هذا عملية حيث يتم الحصول على ألوان اللوحة الإضافية من لون الثيم الرئيسي ثم تستخدم في الأشكال:

```php
  $presentation = new Presentation();
  try {
    $slide = $presentation->getSlides()->get_Item(0);
    # التأكيد 4
    $shape1 = $slide->getShapes()->addAutoShape(ShapeType::Rectangle, 10, 10, 50, 50);
    $shape1->getFillFormat()->setFillType(FillType::Solid);
    $shape1->getFillFormat()->getSolidFillColor()->setSchemeColor(SchemeColor->Accent4);
    # التأكيد 4، أفتح 80%
    $shape2 = $slide->getShapes()->addAutoShape(ShapeType::Rectangle, 10, 70, 50, 50);
    $shape2->getFillFormat()->setFillType(FillType::Solid);
    $shape2->getFillFormat()->getSolidFillColor()->setSchemeColor(SchemeColor->Accent4);
    $shape2->getFillFormat()->getSolidFillColor()->getColorTransform()->add(ColorTransformOperation->MultiplyLuminance, 0.2);
    $shape2->getFillFormat()->getSolidFillColor()->getColorTransform()->add(ColorTransformOperation->AddLuminance, 0.8);
    # التأكيد 4، أفتح 60%
    $shape3 = $slide->getShapes()->addAutoShape(ShapeType::Rectangle, 10, 130, 50, 50);
    $shape3->getFillFormat()->setFillType(FillType::Solid);
    $shape3->getFillFormat()->getSolidFillColor()->setSchemeColor(SchemeColor->Accent4);
    $shape3->getFillFormat()->getSolidFillColor()->getColorTransform()->add(ColorTransformOperation->MultiplyLuminance, 0.4);
    $shape3->getFillFormat()->getSolidFillColor()->getColorTransform()->add(ColorTransformOperation->AddLuminance, 0.6);
    # التأكيد 4، أفتح 40%
    $shape4 = $slide->getShapes()->addAutoShape(ShapeType::Rectangle, 10, 190, 50, 50);
    $shape4->getFillFormat()->setFillType(FillType::Solid);
    $shape4->getFillFormat()->getSolidFillColor()->setSchemeColor(SchemeColor->Accent4);
    $shape4->getFillFormat()->getSolidFillColor()->getColorTransform()->add(ColorTransformOperation->MultiplyLuminance, 0.6);
    $shape4->getFillFormat()->getSolidFillColor()->getColorTransform()->add(ColorTransformOperation->AddLuminance, 0.4);
    # التأكيد 4، أغمق 25%
    $shape5 = $slide->getShapes()->addAutoShape(ShapeType::Rectangle, 10, 250, 50, 50);
    $shape5->getFillFormat()->setFillType(FillType::Solid);
    $shape5->getFillFormat()->getSolidFillColor()->setSchemeColor(SchemeColor->Accent4);
    $shape5->getFillFormat()->getSolidFillColor()->getColorTransform()->add(ColorTransformOperation->MultiplyLuminance, 0.75);
    # التأكيد 4، أغمق 50%
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

## **تغيير خط الثيم**

للسماح لك باختيار الخطوط للثيمات وغيرها من الأغراض، تستخدم Aspose.Slides هذه المعرفات الخاصة (المشابهة لتلك المستخدمة في PowerPoint):

* **+mn-lt** - خط الجسم اللاتيني (خط لاتيني ثانوي)
* **+mj-lt** - خط العنوان اللاتيني (خط لاتيني رئيسي)
* **+mn-ea** - خط الجسم الشرقي الآسيوي (خط شرقي آسيوي ثانوي)
* **+mj-ea** - خط عنوان الشرقي الآسيوي (خط شرقي آسيوي رئيسي)

يوضح كود PHP هذا كيفية تعيين الخط اللاتيني لعنصر ثيم:

```php
  $shape = $pres->getSlides()->get_Item(0)->getShapes()->addAutoShape(ShapeType::Rectangle, 10, 10, 100, 100);
  $paragraph = new Paragraph();
  $portion = new Portion("تنسيق نص الثيم");
  $paragraph->getPortions()->add($portion);
  $shape->getTextFrame()->getParagraphs()->add($paragraph);
  $portion->getPortionFormat()->setLatinFont(new FontData("+mn-lt"));
```

يوضح كود PHP هذا كيف يمكنك تغيير خط ثيم العرض:

```php
  $pres->getMasterTheme()->getFontScheme()->getMinor()->setLatinFont(new FontData("Arial"));
```

سيتم تحديث الخط في جميع مربعات النص.

{{% alert color="primary" title="نصيحة" %}} 

قد ترغب في رؤية [خطوط PowerPoint](/slides/ar/php-java/powerpoint-fonts/).

{{% /alert %}}

## **تغيير نمط خلفية الثيم**

بشكل افتراضي، يوفر تطبيق PowerPoint 12 خلفيات محددة مسبقًا ولكن فقط 3 من تلك الخلفيات الـ 12 يتم حفظها في عرض تقديمي نموذجي.

![todo:image_alt_text](presentation-design_8.png)

على سبيل المثال، بعد حفظ عرض تقديمي في تطبيق PowerPoint، يمكنك تشغيل كود PHP هذا لمعرفة عدد الخلفيات المحددة مسبقًا في العرض التقديمي:

```php
  $pres = new Presentation("pres.pptx");
  try {
    $numberOfBackgroundFills = $pres->getMasterTheme()->getFormatScheme()->getBackgroundFillStyles()->size();
    echo("عدد أنماط التعبئة الخلفية للثيم هو " . $numberOfBackgroundFills);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

{{% alert color="warning" %}} 

باستخدام خاصية [BackgroundFillStyles](https://reference.aspose.com/slides/php-java/aspose.slides/FormatScheme#getBackgroundFillStyles--) من فئة [FormatScheme](https://reference.aspose.com/slides/php-java/aspose.slides/FormatScheme)، يمكنك إضافة أو الوصول إلى نمط الخلفية في ثيم PowerPoint.

{{% /alert %}} 

يوضح كود PHP هذا كيفية تعيين الخلفية لعرض تقديمي:

```php
  $pres->getMasters()->get_Item(0)->getBackground()->setStyleIndex(2);
```

**دليل الفهارس**: 0 يستخدم لعدم التعبئة. تبدأ الفهارس من 1.

{{% alert color="primary" title="نصيحة" %}} 

قد ترغب في رؤية [خلفية PowerPoint](/slides/ar/php-java/presentation-background/).

{{% /alert %}}

## **تغيير تأثير الثيم**

عادة ما يحتوي ثيم PowerPoint على 3 قيم لكل مصفوفة نمط. تلك المصفوفات مدمجة في هذه التأثيرات الثلاثة: خفية، متوسطة، وشديدة. على سبيل المثال، هذه هي النتيجة عند تطبيق التأثيرات على شكل محدد:

![todo:image_alt_text](presentation-design_10.png)

باستخدام 3 خصائص ([FillStyles](https://reference.aspose.com/slides/php-java/aspose.slides/FormatScheme#getFillStyles--)، [LineStyles](https://reference.aspose.com/slides/php-java/aspose.slides/FormatScheme#getLineStyles--)، [EffectStyles](https://reference.aspose.com/slides/php-java/aspose.slides/FormatScheme#getEffectStyles--)) من فئة [FormatScheme](https://reference.aspose.com/slides/php-java/aspose.slides/FormatScheme) يمكنك تغيير العناصر في الثيم (حتى بشكل أكثر مرونة من الخيارات المتاحة في PowerPoint).

يوضح كود PHP هذا كيفية تغيير تأثير الثيم من خلال تعديل أجزاء من العناصر:

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