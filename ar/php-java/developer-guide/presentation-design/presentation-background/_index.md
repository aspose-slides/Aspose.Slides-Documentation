---
title: إدارة خلفيات العرض التقديمي في PHP
linktitle: خلفية الشريحة
type: docs
weight: 20
url: /ar/php-java/presentation-background/
keywords:
- خلفية العرض التقديمي
- خلفية الشريحة
- لون صلب
- لون متدرج
- خلفية صورة
- شفافية الخلفية
- خصائص الخلفية
- PowerPoint
- OpenDocument
- عرض تقديمي
- PHP
- Aspose.Slides
description: "تعرّف على كيفية ضبط خلفيات ديناميكية في ملفات PowerPoint و OpenDocument باستخدام Aspose.Slides للـ PHP عبر Java، مع نصائح برمجية لتعزيز عروضك التقديمية."
---

## **نظرة عامة**

تُستخدم الألوان الصلبة، التدرجات، والصور عادةً كخلفيات للشرائح. يمكنك تعيين الخلفية ل**شريحة عادية** (شريحة واحدة) أو ل**شريحة رئيسية** (تنطبق على عدة شرائح في آنٍ واحد).

![PowerPoint background](powerpoint-background.png)

## **تعيين خلفية بلون صلب لشريحة عادية**

يسمح Aspose.Slides لك بتعيين لون صلب كخلفية لشريحة محددة في عرض تقديمي — حتى إذا كان العرض يستخدم شريحة رئيسية. التغيير يطبق فقط على الشريحة المختارة.

1. أنشئ مثيلاً من فئة [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/presentation/).
2. عيّن خاصية الشريحة [BackgroundType](https://reference.aspose.com/slides/php-java/aspose.slides/backgroundtype/) إلى `OwnBackground`.
3. عيّن خلفية الشريحة [FillType](https://reference.aspose.com/slides/php-java/aspose.slides/filltype/) إلى `Solid`.
4. استخدم الطريقة [getSolidFillColor](https://reference.aspose.com/slides/php-java/aspose.slides/fillformat/#getSolidFillColor) على فئة [FillFormat](https://reference.aspose.com/slides/php-java/aspose.slides/fillformat/) لتحديد لون الخلفية الصلب.
5. احفظ العرض التقديمي المعدّل.

يعرض مثال PHP التالي كيفية تعيين لون أزرق صلب كخلفية لشريحة عادية:
```php
// إنشاء مثيل من فئة Presentation.
$presentation = new Presentation();
try {
    $slide = $presentation->getSlides()->get_Item(0);

    // تعيين لون خلفية الشريحة إلى الأزرق.
    $slide->getBackground()->setType(BackgroundType::OwnBackground);
    $slide->getBackground()->getFillFormat()->setFillType(FillType::Solid);
    $slide->getBackground()->getFillFormat()->getSolidFillColor()->setColor(java("java.awt.Color")->BLUE);
    
    // حفظ العرض التقديمي إلى القرص.
    $presentation->save("SolidColorBackground.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```


## **تعيين خلفية بلون صلب لشريحة رئيسية**

يسمح Aspose.Slides لك بتعيين لون صلب كخلفية لشريحة رئيسية في عرض تقديمي. الشريحة الرئيسية تعمل كقالب يتحكم في تنسيق جميع الشرائح، لذا عند اختيار لون صلب لخلفية الشريحة الرئيسية يطبق على كل شريحة.

1. أنشئ مثيلاً من فئة [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/presentation/).
2. عيّن خاصية الشريحة الرئيسية [BackgroundType](https://reference.aspose.com/slides/php-java/aspose.slides/backgroundtype/) (من خلال `getMasters`) إلى `OwnBackground`.
3. عيّن خلفية الشريحة الرئيسية [FillType](https://reference.aspose.com/slides/php-java/aspose.slides/filltype/) إلى `Solid`.
4. استخدم الطريقة [getSolidFillColor](https://reference.aspose.com/slides/php-java/aspose.slides/fillformat/#getSolidFillColor) لتحديد لون الخلفية الصلب.
5. احفظ العرض التقديمي المعدّل.

يعرض مثال PHP التالي كيفية تعيين لون أخضر صلب كخلفية لشريحة رئيسية:
```php
// إنشاء مثيل من فئة Presentation.
$presentation = new Presentation();
try {
    $masterSlide = $presentation->getMasters()->get_Item(0);

    // تعيين لون خلفية الشريحة الرئيسية إلى الأخضر الغابي.
    $masterSlide->getBackground()->setType(BackgroundType::OwnBackground);
    $masterSlide->getBackground()->getFillFormat()->setFillType(FillType::Solid);
    $masterSlide->getBackground()->getFillFormat()->getSolidFillColor()->setColor(java("java.awt.Color")->GREEN);

    // حفظ العرض التقديمي إلى القرص.
    $presentation->save("MasterSlideBackground.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```


## **تعيين خلفية متدرجة لشريحة**

التدرج هو تأثير رسومي يُنشأ بتغير تدريجي في اللون. عند استخدامه كخلفية لشريحة، يمكن أن يجعل العروض التقديمية أكثر إبداعًا واحترافية. يسمح Aspose.Slides لك بتعيين لون متدرج كخلفية للشرائح.

1. أنشئ مثيلاً من فئة [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/presentation/).
2. عيّن خاصية الشريحة [BackgroundType](https://reference.aspose.com/slides/php-java/aspose.slides/backgroundtype/) إلى `OwnBackground`.
3. عيّن خلفية الشريحة [FillType](https://reference.aspose.com/slides/php-java/aspose.slides/filltype/) إلى `Gradient`.
4. استخدم الطريقة [getGradientFormat](https://reference.aspose.com/slides/php-java/aspose.slides/fillformat/#getGradientFormat) على فئة [FillFormat](https://reference.aspose.com/slides/php-java/aspose.slides/fillformat/) لتكوين إعدادات التدرج المفضلة لديك.
5. احفظ العرض التقديمي المعدّل.

يعرض مثال PHP التالي كيفية تعيين لون متدرج كخلفية لشريحة:
```php
// إنشاء مثيل من فئة Presentation.
$presentation = new Presentation();
try {
    $slide = $presentation->getSlides()->get_Item(0);

    // تطبيق تأثير تدرج على الخلفية.
    $slide->getBackground()->setType(BackgroundType::OwnBackground);
    $slide->getBackground()->getFillFormat()->setFillType(FillType::Gradient);
    $slide->getBackground()->getFillFormat()->getGradientFormat()->setTileFlip(TileFlip::FlipBoth);

    // حفظ العرض التقديمي إلى القرص.
    $presentation->save("GradientBackground.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```


## **تعيين صورة كخلفية لشريحة**

بالإضافة إلى التعبئة الصلبة والمتدرجة، يتيح لك Aspose.Slides استخدام الصور كخلفيات للشرائح.

1. أنشئ مثيلاً من فئة [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/presentation/).
2. عيّن خاصية الشريحة [BackgroundType](https://reference.aspose.com/slides/php-java/aspose.slides/backgroundtype/) إلى `OwnBackground`.
3. عيّن خلفية الشريحة [FillType](https://reference.aspose.com/slides/php-java/aspose.slides/filltype/) إلى `Picture`.
4. حمّل الصورة التي تريد استخدامها كخلفية للشريحة.
5. أضف الصورة إلى مجموعة صور العرض التقديمي.
6. استخدم الطريقة [getPictureFillFormat](https://reference.aspose.com/slides/php-java/aspose.slides/fillformat/#getPictureFillFormat) على فئة [FillFormat](https://reference.aspose.com/slides/php-java/aspose.slides/fillformat/) لتعيين الصورة كخلفية.
7. احفظ العرض التقديمي المعدّل.

يعرض مثال PHP التالي كيفية تعيين صورة كخلفية لشريحة:
```php
// إنشاء مثيل من فئة Presentation.
$presentation = new Presentation();
try {
    $slide = $presentation->getSlides()->get_Item(0);

    // تعيين خصائص صورة الخلفية.
    $slide->getBackground()->setType(BackgroundType::OwnBackground);
    $slide->getBackground()->getFillFormat()->setFillType(FillType::Picture);
    $slide->getBackground()->getFillFormat()->getPictureFillFormat()->setPictureFillMode(PictureFillMode::Stretch);

    // تحميل الصورة.
    $image = Images::fromFile("Tulips.jpg");
    // إضافة الصورة إلى مجموعة صور العرض التقديمي.
    $ppImage = $presentation->getImages()->addImage($image);
    $image->dispose();

    $slide->getBackground()->getFillFormat()->getPictureFillFormat()->getPicture()->setImage($ppImage);

    // حفظ العرض التقديمي إلى القرص.
    $presentation->save("ImageAsBackground.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```


يعرض مثال الشيفرة التالي كيفية تعيين نوع تعبئة الخلفية إلى صورة مكررة وتعديل خصائص التكرار:
```php
$presentation = new Presentation();
try {
    $firstSlide = $presentation->getSlides()->get_Item(0);

    $background = $firstSlide->getBackground();

    $background->setType(BackgroundType::OwnBackground);
    $background->getFillFormat()->setFillType(FillType::Picture);

    $newImage = Images::fromFile("image.png");
    $ppImage = $presentation->getImages()->addImage($newImage);
    $newImage->dispose();

    // تعيين الصورة المستخدمة لملء الخلفية.
    $backPictureFillFormat = $background->getFillFormat()->getPictureFillFormat();
    $backPictureFillFormat->getPicture()->setImage($ppImage);

    // تعيين وضع تعبئة الصورة إلى تكرار وضبط خصائص التكرار.
    $backPictureFillFormat->setPictureFillMode(PictureFillMode::Tile);
    $backPictureFillFormat->setTileOffsetX(15);
    $backPictureFillFormat->setTileOffsetY(15);
    $backPictureFillFormat->setTileScaleX(46);
    $backPictureFillFormat->setTileScaleY(87);
    $backPictureFillFormat->setTileAlignment(RectangleAlignment::Center);
    $backPictureFillFormat->setTileFlip(TileFlip::FlipY);

    $presentation->save("TileBackground.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```


{{% alert color="primary" %}}
اقرأ المزيد: [**Tile Picture As Texture**](/slides/ar/php-java/shape-formatting/#tile-picture-as-texture).
{{% /alert %}}

### **تغيير شفافية صورة الخلفية**

قد ترغب في ضبط شفافية صورة خلفية الشريحة لجعل محتويات الشريحة بارزة أكثر. يوضح كود PHP التالي كيفية تغيير شفافية صورة خلفية الشريحة:
```php
$transparencyValue = 30; // على سبيل المثال.

// الحصول على مجموعة عمليات تحويل الصورة.
$imageTransform = $slide->getBackground()->getFillFormat()->getPictureFillFormat()->getPicture()->getImageTransform();

// العثور على تأثير شفافية ثابت بنسبة مئوية.
$transparencyOperation = null;
foreach($imageTransform as $operation) {
    if (java_instanceof($operation, new JavaClass("com.aspose.slides.AlphaModulateFixed"))) {
        $transparencyOperation = $operation;
        break;
    }
}

// تعيين قيمة الشفافية الجديدة.
if (java_is_null($transparencyOperation)) {
    $imageTransform->addAlphaModulateFixedEffect(100 - $transparencyValue);
} else {
    $transparencyOperation->setAmount(100 - $transparencyValue);
}
```


## **الحصول على قيمة خلفية الشريحة**

يوفر Aspose.Slides الفئة `BackgroundEffectiveData` لاسترداد القيم الفعلية لخلفية الشريحة. تُظهر هذه الفئة الـ [FillFormat](https://reference.aspose.com/slides/php-java/aspose.slides/fillformat/) و[EffectFormat](https://reference.aspose.com/slides/php-java/aspose.slides/effectformat/) الفعليين.

باستخدام طريقة `getBackground` من فئة [BaseSlide](https://reference.aspose.com/slides/php-java/aspose.slides/baseslide/)، يمكنك الحصول على الخلفية الفعلية لشريحة.

يعرض مثال PHP التالي كيفية الحصول على قيمة الخلفية الفعلية لشريحة:
```php
// إنشاء مثيل من فئة Presentation.
$presentation = new Presentation("Sample.pptx");
try {
    $slide = $presentation->getSlides()->get_Item(0);

    // استرجاع الخلفية الفعلية مع مراعاة الشريحة الرئيسية والتخطيط والسمة.
    $effBackground = $slide->getBackground()->getEffective();

    if ($effBackground->getFillFormat()->getFillType() == FillType::Solid)
        echo "Fill color: " . $effBackground->getFillFormat()->getSolidFillColor() . "\n";
    else
        echo "Fill type: " . $effBackground->getFillFormat()->getFillType() . "\n";
} finally {
    $presentation->dispose();
}
```


## **الأسئلة المتكررة**

**هل يمكنني إعادة ضبط خلفية مخصصة واستعادة خلفية السمة/التخطيط؟**

نعم. احذف التعبئة المخصصة للشريحة، وستُستعاد الخلفية مرة أخرى من شريحة [layout](/slides/ar/php-java/slide-layout/)/[master](/slides/ar/php-java/slide-master/) المقابلة (أي خلفية [theme](/slides/ar/php-java/presentation-theme/)).

**ماذا يحدث للخلفية إذا غيرت سمة العرض التقديمي لاحقًا؟**

إذا كان للشفرة تعبئة خاصة بها، ستظلunchanged. إذا كانت الخلفية مُستمدة من [layout](/slides/ar/php-java/slide-layout/)/[master](/slides/ar/php-java/slide-master/)، فستُحدَّث لتطابق [السمة الجديدة](/slides/ar/php-java/presentation-theme/).