---
title: Эффект формы
type: docs
weight: 30
url: /ru/php-java/shape-effect
keywords: "Эффект формы, Презентация PowerPoint, Java, Aspose.Slides для PHP через Java"
description: "Примените эффект к форме PowerPoint"
---

Хотя эффекты в PowerPoint могут использоваться для того, чтобы форма выделялась, они отличаются от [заливок](/slides/ru/php-java/shape-formatting/#gradient-fill) или контуров. Используя эффекты PowerPoint, вы можете создать убедительные отражения на форме, распространить свет вокруг формы и т.д.

<img src="shape-effect.png" alt="shape-effect" style="zoom:50%;" />

* PowerPoint предоставляет шесть эффектов, которые можно применить к формам. Вы можете применить один или несколько эффектов к форме.

* Некоторые комбинации эффектов выглядят лучше других. По этой причине PowerPoint предлагает параметры в разделе **Предустановленные**. Параметры предустановленных эффектов представляют собой известные комбинации двух или более эффектов, которые выглядят хорошо. Таким образом, выбрав предустановленный эффект, вам не придется тратить время на тестирование или объединение различных эффектов, чтобы найти красивую комбинацию.

Aspose.Slides предоставляет свойства и методы в классе [EffectFormat](https://reference.aspose.com/slides/php-java/aspose.slides/EffectFormat), которые позволяют применять те же эффекты к формам в презентациях PowerPoint.

## **Применить эффект тени**

Этот PHP-код показывает, как применить эффект внешней тени ([OuterShadowEffect](https://reference.aspose.com/slides/php-java/aspose.slides/EffectFormat#setOuterShadowEffect--)) к прямоугольнику:

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

## **Применить эффект отражения**

Этот PHP-код показывает, как применить эффект отражения к форме:

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

## **Применить эффект свечения**

Этот PHP-код показывает, как применить эффект свечения к форме:

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

## **Применить эффект мягких краев**

Этот PHP-код показывает, как применить эффект мягких краев к форме:

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