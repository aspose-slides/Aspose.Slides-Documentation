---
title: إدارة إعدادات التحجيم التلقائي
type: docs
weight: 30
url: /ar/php-java/manage-autofit-settings/
keywords: "مربع نص، تحجيم تلقائي، عرض باوربوينت، جافا، Aspose.Slides لـ PHP عبر جافا"
description: "قم بإعداد إعدادات التحجيم التلقائي لمربع النص في باوربوينت"
---

بشكل افتراضي، عند إضافة مربع نص، يستخدم Microsoft PowerPoint إعداد **تغيير حجم الشكل ليتناسب مع النص** لمربع النص—ويقوم تلقائيًا بتغيير حجم مربع النص لضمان ملاءمة نصه دائمًا بداخله.

![مربع النص في باوربوينت](textbox-in-powerpoint.png)

* عندما يصبح النص في مربع النص أطول أو أكبر، يقوم باوربوينت تلقائيًا بتكبير مربع النص—زيادة ارتفاعه—لكي يسمح له باستيعاب نص أكبر.
* عندما يصبح النص في مربع النص أقصر أو أصغر، يقوم باوربوينت تلقائيًا بتقليص مربع النص—تقليل ارتفاعه—لإزالة المساحة الزائدة.

في باوربوينت، هذه هي النقاط أو الخيارات الأربعة المهمة التي تتحكم في سلوك التحجيم التلقائي لمربع النص:

* **لا تُحسن التحجيم التلقائي**
* **تقليل النص عند overflow**
* **تغيير حجم الشكل ليتناسب مع النص**
* **لف النص داخل الشكل.**

![خيارات التحجيم التلقائي باوربوينت](autofit-options-powerpoint.png)

توفر Aspose.Slides لـ PHP عبر جافا خيارات مشابهة—بعض الخصائص تحت فئة [TextFrameFormat](https://reference.aspose.com/slides/php-java/aspose.slides/TextFrameFormat)—والتي تسمح لك بالتحكم في سلوك التحجيم التلقائي لمربعات النص في العروض التقديمية.

## **تغيير حجم الشكل ليتناسب مع النص**

إذا كنت تريد أن يتناسب النص في صندوق دائمًا داخل هذا الصندوق بعد إجراء تغييرات على النص، يجب عليك استخدام خيار **تغيير حجم الشكل ليتناسب مع النص**. لتحديد هذا الإعداد، قم بتعيين خاصية [AutofitType](https://reference.aspose.com/slides/php-java/aspose.slides/TextFrameFormat#getAutofitType--) (من فئة [TextFrameFormat](https://reference.aspose.com/slides/php-java/aspose.slides/TextFrameFormat)) إلى `Shape`.

![إعداد دائم التناسب باوربوينت](alwaysfit-setting-powerpoint.png)

يوضح لك هذا الرمز بلغة PHP كيفية تحديد أن النص يجب أن يتناسب دائمًا داخل صندوقه في عرض باوربوينت:

```php
  $pres = new Presentation();
  try {
    $slide = $pres->getSlides()->get_Item(0);
    $autoShape = $slide->getShapes()->addAutoShape(ShapeType::Rectangle, 30, 30, 350, 100);
    $portion = new Portion("lorem ipsum...");
    $portion->getPortionFormat()->getFillFormat()->getSolidFillColor()->setColor(java("java.awt.Color")->BLACK);
    $portion->getPortionFormat()->getFillFormat()->setFillType(FillType::Solid);
    $autoShape->getTextFrame()->getParagraphs()->get_Item(0)->getPortions()->add($portion);
    $textFrameFormat = $autoShape->getTextFrame()->getTextFrameFormat();
    $textFrameFormat::setAutofitType(TextAutofitType::Shape);
    $pres->save("Output-presentation.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

إذا أصبح النص أطول أو أكبر، سيتم تغيير حجم مربع النص تلقائيًا (زيادة في الارتفاع) لضمان ملاءمة كل النص بداخله. إذا أصبح النص أقصر، يحدث العكس.

## **لا تحسن التحجيم التلقائي**

إذا كنت تريد لمربع نص أو شكل أن يحتفظ بأبعاده بغض النظر عن التغييرات التي تطرأ على النص الذي يحتويه، يجب عليك استخدام خيار **لا تحسن التحجيم التلقائي**. لتحديد هذا الإعداد، قم بتعيين خاصية [AutofitType](https://reference.aspose.com/slides/php-java/aspose.slides/TextFrameFormat#getAutofitType--) (من فئة [TextFrameFormat](https://reference.aspose.com/slides/php-java/aspose.slides/TextFrameFormat)) إلى `None`.

![إعداد لا تحسن التحجيم التلقائي باوربوينت](donotautofit-setting-powerpoint.png)

يوضح لك هذا الرمز بلغة PHP كيفية تحديد أنه يجب على مربع النص الاحتفاظ دائمًا بأبعاده في عرض باوربوينت:

```php
  $pres = new Presentation();
  try {
    $slide = $pres->getSlides()->get_Item(0);
    $autoShape = $slide->getShapes()->addAutoShape(ShapeType::Rectangle, 30, 30, 350, 100);
    $portion = new Portion("lorem ipsum...");
    $portion->getPortionFormat()->getFillFormat()->getSolidFillColor()->setColor(java("java.awt.Color")->BLACK);
    $portion->getPortionFormat()->getFillFormat()->setFillType(FillType::Solid);
    $autoShape->getTextFrame()->getParagraphs()->get_Item(0)->getPortions()->add($portion);
    $textFrameFormat = $autoShape->getTextFrame()->getTextFrameFormat();
    $textFrameFormat::setAutofitType(TextAutofitType::None);
    $pres->save("Output-presentation.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

عندما يصبح النص طويلاً جدًا بالنسبة لصندوقه، يتجاوز النص.

## **تقليل النص عند overflow**

إذا أصبح النص طويلًا جدًا بالنسبة لصندوقه، من خلال خيار **تقليل النص عند overflow**، يمكنك تحديد أن حجم النص وتباعده يجب تقليلهما ليتناسبا داخل صندوقه. لتحديد هذا الإعداد، قم بتعيين خاصية [AutofitType](https://reference.aspose.com/slides/php-java/aspose.slides/TextFrameFormat#getAutofitType--) (من فئة [TextFrameFormat](https://reference.aspose.com/slides/php-java/aspose.slides/TextFrameFormat)) إلى `Normal`.

![إعداد تقليل النص عند overflow باوربوينت](shrinktextonoverflow-setting-powerpoint.png)

يوضح لك هذا الرمز بلغة PHP كيفية تحديد أن النص يجب أن يتم تقليله عند overflow في عرض باوربوينت:

```php
  $pres = new Presentation();
  try {
    $slide = $pres->getSlides()->get_Item(0);
    $autoShape = $slide->getShapes()->addAutoShape(ShapeType::Rectangle, 30, 30, 350, 100);
    $portion = new Portion("lorem ipsum...");
    $portion->getPortionFormat()->getFillFormat()->getSolidFillColor()->setColor(java("java.awt.Color")->BLACK);
    $portion->getPortionFormat()->getFillFormat()->setFillType(FillType::Solid);
    $autoShape->getTextFrame()->getParagraphs()->get_Item(0)->getPortions()->add($portion);
    $textFrameFormat = $autoShape->getTextFrame()->getTextFrameFormat();
    $textFrameFormat::setAutofitType(TextAutofitType::Normal);
    $pres->save("Output-presentation.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

{{% alert title="معلومات" color="info" %}}

عندما يتم استخدام خيار **تقليل النص عند overflow**، يتم تطبيق الإعداد فقط عندما يصبح النص طويلًا جدًا بالنسبة لصندوقه.

{{% /alert %}}

## **لف النص**

إذا كنت تريد أن يتم لف النص داخل شكل عند تجاوز النص حدود الشكل ( العرض فقط)، يجب عليك استخدام المعلمة **لف النص داخل الشكل**. لتحديد هذا الإعداد، يجب عليك تعيين خاصية [WrapText](https://reference.aspose.com/slides/php-java/aspose.slides/TextFrameFormat#getWrapText--) (من فئة [TextFrameFormat](https://reference.aspose.com/slides/php-java/aspose.slides/TextFrameFormat)) إلى `true`.

يوضح لك هذا الرمز بلغة PHP كيفية استخدام إعداد لف النص في عرض باوربوينت:

```php
  $pres = new Presentation();
  try {
    $slide = $pres->getSlides()->get_Item(0);
    $autoShape = $slide->getShapes()->addAutoShape(ShapeType::Rectangle, 30, 30, 350, 100);
    $portion = new Portion("lorem ipsum...");
    $portion->getPortionFormat()->getFillFormat()->getSolidFillColor()->setColor(java("java.awt.Color")->BLACK);
    $portion->getPortionFormat()->getFillFormat()->setFillType(FillType::Solid);
    $autoShape->getTextFrame()->getParagraphs()->get_Item(0)->getPortions()->add($portion);
    $textFrameFormat = $autoShape->getTextFrame()->getTextFrameFormat();
    $textFrameFormat::setWrapText(NullableBool::True);
    $pres->save("Output-presentation.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

{{% alert title="ملاحظة" color="warning" %}}

إذا قمت بتعيين خاصية `WrapText` إلى `False` لشكل، عندما يصبح النص داخل الشكل أطول من عرض الشكل، يمتد النص خارج حدود الشكل على خط واحد.

{{% /alert %}}