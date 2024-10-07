---
title: خلفية العرض
type: docs
weight: 20
url: /php-java/presentation-background/
keywords: "خلفية باوربوينت, تعيين خلفية"
description: "تعيين الخلفية في عرض باوربوينت"
---

تُستخدم الألوان الصلبة، وألوان التدرج، والصور غالبًا كصور خلفية للشرائح. يمكنك تعيين الخلفية إما لشريحة **عادية** (شريحة واحدة) أو **شريحة رئيسية** (عدة شرائح دفعة واحدة).

<img src="powerpoint-background.png" alt="powerpoint-background"  />

## **تعيين لون صلب كخلفية لشريحة عادية**

يسمح لك Aspose.Slides بتعيين لون صلب كخلفية لشريحة معينة في عرض تقديمي (حتى لو كانت هذه العرض تحتوي على شريحة رئيسية). يؤثر تغيير الخلفية فقط على الشريحة المحددة.

1. إنشاء مثيل من فئة [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/Presentation).
2. تعيين الـ [BackgroundType](https://reference.aspose.com/slides/php-java/aspose.slides/backgroundtype/) من الشريحة إلى `OwnBackground`.
3. تعيين الـ [FillType](https://reference.aspose.com/slides/php-java/aspose.slides/filltype/) من خلفية الشريحة إلى `Solid`.
4. استخدم خاصية [SolidFillColor](https://reference.aspose.com/slides/php-java/aspose.slides/fillformat/#getSolidFillColor--) التي تكشف عنها [FillFormat](https://reference.aspose.com/slides/php-java/aspose.slides/fillformat/) لتحديد لون صلب للخلفية.
5. حفظ العرض المعدل.

هذا الرمز PHP يوضح لك كيفية تعيين لون صلب (أزرق) كخلفية لشريحة عادية:

```php
  # Creates an instance of the Presentation class
  $pres = new Presentation("MasterBG.pptx");
  try {
    # Sets the background color for the first ISlide to Blue
    $pres->getSlides()->get_Item(0)->getBackground()->setType(BackgroundType::OwnBackground);
    $pres->getSlides()->get_Item(0)->getBackground()->getFillFormat()->setFillType(FillType::Solid);
    $pres->getSlides()->get_Item(0)->getBackground()->getFillFormat()->getSolidFillColor()->setColor(java("java.awt.Color")->BLUE);
    # Writes the presentation to disk
    $pres->save("ContentBG.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

## **تعيين لون صلب كخلفية لشريحة رئيسية**

يسمح لك Aspose.Slides بتعيين لون صلب كخلفية للشريحة الرئيسية في عرض تقديمي. تعمل الشريحة الرئيسية كنموذج يحتوي على إعدادات التنسيق لجميع الشرائح. لذلك، عند اختيار لون صلب كخلفية للشريحة الرئيسية، سيتم استخدام هذه الخلفية الجديدة لجميع الشرائح.

1. إنشاء مثيل من فئة [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/Presentation).
2. تعيين الـ [BackgroundType](https://reference.aspose.com/slides/php-java/aspose.slides/backgroundtype/) من الشريحة الرئيسية (`Masters`) إلى `OwnBackground`.
3. تعيين الـ [FillType](https://reference.aspose.com/slides/php-java/aspose.slides/filltype/) من خلفية الشريحة الرئيسية إلى `Solid`.
4. استخدم خاصية [SolidFillColor](https://reference.aspose.com/slides/php-java/aspose.slides/fillformat/#getSolidFillColor--) التي تكشف عنها [FillFormat](https://reference.aspose.com/slides/php-java/aspose.slides/fillformat/) لتحديد لون صلب للخلفية.
5. حفظ العرض المعدل.

هذا الرمز PHP يوضح لك كيفية تعيين لون صلب (أخضر غابات) كخلفية لشريحة رئيسية في عرض تقديمي:

```php
  # Creates an instance of the Presentation class
  $pres = new Presentation();
  try {
    # Sets the background color for the Master ISlide to Forest Green
    $pres->getMasters()->get_Item(0)->getBackground()->setType(BackgroundType::OwnBackground);
    $pres->getMasters()->get_Item(0)->getBackground()->getFillFormat()->setFillType(FillType::Solid);
    $pres->getMasters()->get_Item(0)->getBackground()->getFillFormat()->getSolidFillColor()->setColor(java("java.awt.Color")->GREEN);
    # Writes the presentation to disk
    $pres->save("MasterBG.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

## **تعيين لون تدرج كخلفية لشريحة**

التدرج هو تأثير رسومي يعتمد على تغيير تدريجي في اللون. تبدو الألوان المتدرجة، عند استخدامها كخلفيات للشرائح، فنية واحترافية. يسمح لك Aspose.Slides بتعيين لون تدرج كخلفية للشرائح في العروض التقديمية.

1. إنشاء مثيل من فئة [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/Presentation).
2. تعيين الـ [BackgroundType](https://reference.aspose.com/slides/php-java/aspose.slides/backgroundtype/) من الشريحة إلى `OwnBackground`.
3. تعيين الـ [FillType](https://reference.aspose.com/slides/php-java/aspose.slides/filltype/) من خلفية الشريحة الرئيسية إلى `Gradient`.
4. استخدم خاصية [GradientFormat](https://reference.aspose.com/slides/php-java/aspose.slides/fillformat/#getGradientFormat--) التي تكشف عنها [FillFormat](https://reference.aspose.com/slides/php-java/aspose.slides/fillformat/) لتحديد إعدادات التدرج المفضلة لديك.
5. حفظ العرض المعدل.

هذا الرمز PHP يوضح لك كيفية تعيين لون تدرج كخلفية لشريحة:

```php
  # Creates an instance of the Presentation class
  $pres = new Presentation("MasterBG.pptx");
  try {
    # Apply Gradient effect to the Background
    $pres->getSlides()->get_Item(0)->getBackground()->setType(BackgroundType::OwnBackground);
    $pres->getSlides()->get_Item(0)->getBackground()->getFillFormat()->setFillType(FillType::Gradient);
    $pres->getSlides()->get_Item(0)->getBackground()->getFillFormat()->getGradientFormat()->setTileFlip(TileFlip->FlipBoth);
    # Writes the presentation to disk
    $pres->save("ContentBG_Grad.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

## **تعيين صورة كخلفية لشريحة**

بجانب الألوان الصلبة وألوان التدرج، يسمح لك Aspose.Slides أيضًا بتعيين الصور كخلفية للشرائح في العروض التقديمية.

1. إنشاء مثيل من فئة [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/Presentation).
2. تعيين الـ [BackgroundType](https://reference.aspose.com/slides/php-java/aspose.slides/backgroundtype/) من الشريحة إلى `OwnBackground`.
3. تعيين الـ [FillType](https://reference.aspose.com/slides/php-java/aspose.slides/filltype/) من خلفية الشريحة الرئيسية إلى `Picture`.
4. تحميل الصورة التي ترغب في استخدامها كخلفية للشرائح.
5. إضافة الصورة إلى مجموعة الصور في العرض التقديمي.
6. استخدم خاصية [PictureFillFormat](https://reference.aspose.com/slides/php-java/aspose.slides/fillformat/#getPictureFillFormat--) التي تكشف عنها [FillFormat](https://reference.aspose.com/slides/php-java/aspose.slides/fillformat/) لتعيين الصورة كخلفية.
7. حفظ العرض المعدل.

هذا الرمز PHP يوضح لك كيفية تعيين صورة كخلفية لشريحة:

```php
  # Creates an instance of the Presentation class
  $pres = new Presentation();
  try {
    # Sets conditions for background image
    $pres->getSlides()->get_Item(0)->getBackground()->setType(BackgroundType::OwnBackground);
    $pres->getSlides()->get_Item(0)->getBackground()->getFillFormat()->setFillType(FillType::Picture);
    $pres->getSlides()->get_Item(0)->getBackground()->getFillFormat()->getPictureFillFormat()->setPictureFillMode(PictureFillMode->Stretch);
    # Loads the image
    $imgx;
    $image = Images->fromFile("Desert.jpg");
    try {
      $imgx = $pres->getImages()->addImage($image);
    } finally {
      if (!java_is_null($image)) {
        $image->dispose();
      }
    }
    # Adds image to presentation's images collection
    $pres->getSlides()->get_Item(0)->getBackground()->getFillFormat()->getPictureFillFormat()->getPicture()->setImage($imgx);
    # Writes the presentation to disk
    $pres->save("ContentBG_Img.pptx", SaveFormat::Pptx);
  } catch (JavaException $e) {
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

### **تغيير شفافية صورة الخلفية**

قد ترغب في ضبط شفافية صورة خلفية الشريحة لجعل محتويات الشريحة تبرز. يوضح لك هذا الرمز PHP كيفية تغيير الشفافية لصورة خلفية شريحة:

```php
  $transparencyValue = 30;// على سبيل المثال

  # Gets a collection of picture transform operations
  $imageTransform = $slide->getBackground()->getFillFormat()->getPictureFillFormat()->getPicture()->getImageTransform();
  # Finds a transparency effect with fixed percentage.
  $transparencyOperation = null;
  foreach($imageTransform as $operation) {
    if (java_instanceof($operation, new JavaClass("com.aspose.slides.AlphaModulateFixed"))) {
      $transparencyOperation = $operation;
      break;
    }
  }
  # Sets the new transparency value.
  if (java_is_null($transparencyOperation)) {
    $imageTransform->addAlphaModulateFixedEffect(100 - $transparencyValue);
  } else {
    $transparencyOperation->setAmount(100 - $transparencyValue);
  }
```

## **الحصول على قيمة خلفية الشريحة**

يوفر Aspose.Slides واجهة [IBackgroundEffectiveData](https://reference.aspose.com/slides/php-java/aspose.slides/ibackgroundeffectivedata/) للسماح لك بالحصول على القيم الفعالة لخلفيات الشرائح. تحتوي هذه الواجهة على معلومات حول [FillFormat](https://reference.aspose.com/slides/php-java/aspose.slides/ibackgroundeffectivedata/#getFillFormat--) و[EffectFormat](https://reference.aspose.com/slides/php-java/aspose.slides/ibackgroundeffectivedata/#getEffectFormat--).

باستخدام خاصية [Background](https://reference.aspose.com/slides/php-java/aspose.slides/baseslide/#getBackground--) من فئة [BaseSlide](https://reference.aspose.com/slides/php-java/aspose.slides/baseslide/)، يمكنك الحصول على القيمة الفعالة لخلفية الشريحة.

هذا الرمز PHP يوضح لك كيفية الحصول على القيمة الفعالة لخلفية شريحة:

```php
  # Creates an instance of the Presentation class
  $pres = new Presentation("SamplePresentation.pptx");
  try {
    $effBackground = $pres->getSlides()->get_Item(0)->getBackground()->getEffective();
    if ($effBackground->getFillFormat()->getFillType() == FillType::Solid) {
      echo("Fill color: " . $effBackground->getFillFormat()->getSolidFillColor());
    } else {
      echo("Fill type: " . $effBackground->getFillFormat()->getFillType());
    }
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```