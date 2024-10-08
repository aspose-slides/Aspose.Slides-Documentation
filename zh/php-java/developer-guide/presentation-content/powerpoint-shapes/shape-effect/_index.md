---
title: 形状效果
type: docs
weight: 30
url: /zh/php-java/shape-effect
keywords: "形状效果, PowerPoint 演示文稿, Java, Aspose.Slides for PHP via Java"
description: "对 PowerPoint 形状应用效果"
---

虽然 PowerPoint 中的效果可以用来使形状突出，但它们与[填充](/slides/zh/php-java/shape-formatting/#gradient-fill)或轮廓不同。使用 PowerPoint 效果，您可以在形状上创建令人信服的反射，扩展形状的光晕等。

<img src="shape-effect.png" alt="形状效果" style="zoom:50%;" />

* PowerPoint 提供六种效果，可以应用于形状。您可以对一个形状应用一个或多个效果。

* 一些效果组合看起来比其他组合更好。因此，PowerPoint 在 **预设** 下提供了选项。预设选项本质上是一种已知的好看的两个或更多效果的组合。这样，通过选择预设，您就不必浪费时间测试或组合不同的效果来找到一个好的组合。

Aspose.Slides 提供了在[EffectFormat](https://reference.aspose.com/slides/php-java/aspose.slides/EffectFormat)类下的属性和方法，允许您在 PowerPoint 演示文稿中对形状应用相同的效果。

## **应用阴影效果**

以下 PHP 代码演示如何对一个矩形应用外阴影效果 ([OuterShadowEffect](https://reference.aspose.com/slides/php-java/aspose.slides/EffectFormat#setOuterShadowEffect--))：

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

## **应用反射效果**

以下 PHP 代码演示如何对一个形状应用反射效果：

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

## **应用光晕效果**

以下 PHP 代码演示如何对一个形状应用光晕效果：

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

## **应用柔和边缘效果**

以下 PHP 代码演示如何对一个形状应用柔和边缘效果：

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