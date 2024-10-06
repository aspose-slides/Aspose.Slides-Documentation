---
title: Effet de forme
type: docs
weight: 30
url: /php-java/shape-effect
keywords: "Effet de forme, présentation PowerPoint, Java, Aspose.Slides pour PHP via Java"
description: "Appliquer un effet à une forme PowerPoint"
---

Bien que les effets dans PowerPoint puissent être utilisés pour faire ressortir une forme, ils diffèrent des [remplissages](/slides/php-java/shape-formatting/#gradient-fill) ou des contours. En utilisant des effets PowerPoint, vous pouvez créer des réflexions convaincantes sur une forme, étendre le halo d'une forme, etc.

<img src="shape-effect.png" alt="effet-de-forme" style="zoom:50%;" />

* PowerPoint propose six effets pouvant être appliqués aux formes. Vous pouvez appliquer un ou plusieurs effets à une forme.

* Certaines combinaisons d'effets sont plus attrayantes que d'autres. Pour cette raison, PowerPoint propose des options sous **Préréglé**. Les options Préréglé sont essentiellement une combinaison connue et esthétique de deux effets ou plus. De cette manière, en sélectionnant un préréglage, vous ne perdrez pas de temps à tester ou à combiner différents effets pour trouver une belle combinaison.

Aspose.Slides fournit des propriétés et des méthodes sous la classe [EffectFormat](https://reference.aspose.com/slides/php-java/aspose.slides/EffectFormat) qui vous permettent d'appliquer les mêmes effets aux formes dans les présentations PowerPoint.

## **Appliquer l'effet d'ombre**

Ce code PHP vous montre comment appliquer l'effet d'ombre extérieure ([OuterShadowEffect](https://reference.aspose.com/slides/php-java/aspose.slides/EffectFormat#setOuterShadowEffect--)) à un rectangle :

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

## **Appliquer l'effet de réflexion**

Ce code PHP vous montre comment appliquer l'effet de réflexion à une forme :

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

## **Appliquer l'effet de lueur**

Ce code PHP vous montre comment appliquer l'effet de lueur à une forme :

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

## **Appliquer l'effet de bords adoucis**

Ce code PHP vous montre comment appliquer les bords adoucis à une forme :

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