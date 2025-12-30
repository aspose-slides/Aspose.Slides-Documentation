---
title: تطبيق تأثيرات الشكل في العروض التقديمية باستخدام PHP
linktitle: تأثير الشكل
type: docs
weight: 30
url: /ar/php-java/shape-effect/
keywords:
- تأثير الشكل
- تأثير الظل
- تأثير الانعكاس
- تأثير التوهج
- تأثير الحواف الناعمة
- تنسيق التأثير
- PowerPoint
- العرض التقديمي
- PHP
- Aspose.Slides
description: "حوّل ملفات PPT و PPTX الخاصة بك باستخدام تأثيرات الشكل المتقدمة عبر Aspose.Slides للـ PHP عبر Java — أنشئ شرائح جذابة ومهنية في ثوانٍ."
---

بينما يمكن استخدام التأثيرات في PowerPoint لجعل الشكل يبرز، فهي تختلف عن [fills](/slides/ar/php-java/shape-formatting/#gradient-fill) أو الحدود. باستخدام تأثيرات PowerPoint، يمكنك إنشاء انعكاسات مقنعة على الشكل، أو نشر توهج الشكل، إلخ.

<img src="shape-effect.png" alt="shape-effect" style="zoom:50%;" />

* يوفر PowerPoint ستة تأثيرات يمكن تطبيقها على الأشكال. يمكنك تطبيق تأثير واحد أو أكثر على شكل. 
* بعض تركيبات التأثيرات تبدو أفضل من غيرها. لهذا السبب، توجد خيارات PowerPoint تحت **Preset**. تُعد خيارات Preset مزيجًا معروفًا جيد المظهر من تأثيرين أو أكثر. بهذه الطريقة، باختيار إعداد مسبق، لن تضطر إلى إضاعة الوقت في اختبار أو دمج تأثيرات مختلفة للعثور على تركيبة لطيفة.

توفر Aspose.Slides خصائص وأساليب ضمن فئة [EffectFormat](https://reference.aspose.com/slides/php-java/aspose.slides/EffectFormat) التي تسمح لك بتطبيق نفس التأثيرات على الأشكال في عروض PowerPoint.

## **Apply a Shadow Effect**

هذا الكود PHP يوضح لك كيفية تطبيق تأثير الظل الخارجي ([OuterShadowEffect](https://reference.aspose.com/slides/php-java/aspose.slides/EffectFormat#setOuterShadowEffect--)) على مستطيل:
```php
  $pres = new Presentation();
  try {
    $shape = $pres->getSlides()->get_Item(0)->getShapes()->addAutoShape(ShapeType::RoundCornerRectangle, 20, 20, 200, 150);
    $shape->getEffectFormat()->enableOuterShadowEffect();
    $shape->getEffectFormat()->getOuterShadowEffect()->getShadowColor()->setColor(java("java.awt.Color")->DARK_GRAY);
    $shape->getEffectFormat()->getOuterShadowEffect()->setDistance(10);
    $shape->getEffectFormat()->getOuterShadowEffect()->setDirection(45);
    $pres->save("output.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```


## **Apply a Reflection Effect**

هذا الكود PHP يوضح لك كيفية تطبيق تأثير الانعكاس على شكل:
```php
  $pres = new Presentation();
  try {
    $shape = $pres->getSlides()->get_Item(0)->getShapes()->addAutoShape(ShapeType::RoundCornerRectangle, 20, 20, 200, 150);
    $shape->getEffectFormat()->enableReflectionEffect();
    $shape->getEffectFormat()->getReflectionEffect()->setRectangleAlign(RectangleAlignment->Bottom);
    $shape->getEffectFormat()->getReflectionEffect()->setDirection(90);
    $shape->getEffectFormat()->getReflectionEffect()->setDistance(55);
    $shape->getEffectFormat()->getReflectionEffect()->setBlurRadius(4);
    $pres->save("reflection.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```


## **Apply a Glow Effect**

هذا الكود PHP يوضح لك كيفية تطبيق تأثير التوهج على شكل:
```php
  $pres = new Presentation();
  try {
    $shape = $pres->getSlides()->get_Item(0)->getShapes()->addAutoShape(ShapeType::RoundCornerRectangle, 20, 20, 200, 150);
    $shape->getEffectFormat()->enableGlowEffect();
    $shape->getEffectFormat()->getGlowEffect()->getColor()->setColor(java("java.awt.Color")->MAGENTA);
    $shape->getEffectFormat()->getGlowEffect()->setRadius(15);
    $pres->save("glow.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```


## **Apply a Soft Edges Effect**

هذا الكود PHP يوضح لك كيفية تطبيق الحواف الناعمة على شكل:
```php
  $pres = new Presentation();
  try {
    $shape = $pres->getSlides()->get_Item(0)->getShapes()->addAutoShape(ShapeType::RoundCornerRectangle, 20, 20, 200, 150);
    $shape->getEffectFormat()->enableSoftEdgeEffect();
    $shape->getEffectFormat()->getSoftEdgeEffect()->setRadius(15);
    $pres->save("softEdges.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```


## **FAQ**

**Can I apply multiple effects to the same shape?**

نعم، يمكنك دمج تأثيرات مختلفة، مثل الظل، الانعكاس، والتوهج، على شكل واحد لإنشاء مظهر أكثر ديناميكية.

**What shapes can I apply effects to?**

يمكنك تطبيق التأثيرات على أشكال مختلفة، بما في ذلك الأشكال التلقائية، المخططات، الجداول، الصور، كائنات SmartArt، كائنات OLE، وأكثر.

**Can I apply effects to grouped shapes?**

نعم، يمكنك تطبيق التأثيرات على الأشكال المجمعة. سيُطبق التأثير على المجموعة بأكملها.