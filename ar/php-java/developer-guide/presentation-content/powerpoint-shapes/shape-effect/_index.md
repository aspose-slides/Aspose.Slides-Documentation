---
title: تأثير الشكل
type: docs
weight: 30
url: /php-java/shape-effect
keywords: "تأثير الشكل، عرض PowerPoint، Java، Aspose.Slides لـ PHP عبر Java"
description: "تطبيق تأثير على شكل PowerPoint"
---

بينما يمكن استخدام التأثيرات في PowerPoint لجعل الشكل يبرز، فإنها تختلف عن [التعبئات](/slides/php-java/shape-formatting/#gradient-fill) أو الخطوط. باستخدام تأثيرات PowerPoint، يمكنك إنشاء انعكاسات مقنعة على الشكل، ونشر توهج الشكل، إلخ.

<img src="shape-effect.png" alt="تأثير الشكل" style="zoom:50%;" />

* يوفر PowerPoint ستة تأثيرات يمكن تطبيقها على الأشكال. يمكنك تطبيق تأثير واحد أو أكثر على الشكل.

* بعض تركيبات التأثيرات تبدو أفضل من غيرها. لهذا السبب، خيارات PowerPoint تحت **الإعدادات المسبقة**. خيارات الإعدادات المسبقة هي في الأساس مجموعة معروفة جيدة المظهر من تأثيرين أو أكثر. بهذه الطريقة، من خلال اختيار إعداد مسبق، لن تضطر إلى إضاعة الوقت في اختبار أو دمج تأثيرات مختلفة للعثور على تركيبة لطيفة.

توفر Aspose.Slides خصائص وأساليب تحت فئة [EffectFormat](https://reference.aspose.com/slides/php-java/aspose.slides/EffectFormat) التي تتيح لك تطبيق نفس التأثيرات على الأشكال في عروض PowerPoint.

## **تطبيق تأثير الظل**

يعرض لك هذا الرمز بلغة PHP كيفية تطبيق تأثير الظل الخارجي ([OuterShadowEffect](https://reference.aspose.com/slides/php-java/aspose.slides/EffectFormat#setOuterShadowEffect--)) على مستطيل:

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

## **تطبيق تأثير الانعكاس**

يعرض لك هذا الرمز بلغة PHP كيفية تطبيق تأثير الانعكاس على شكل:

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

## **تطبيق تأثير التوهج**

يعرض لك هذا الرمز بلغة PHP كيفية تطبيق تأثير التوهج على شكل:

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

## **تطبيق تأثير الحواف الناعمة**

يعرض لك هذا الرمز بلغة PHP كيفية تطبيق الحواف الناعمة على شكل:

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