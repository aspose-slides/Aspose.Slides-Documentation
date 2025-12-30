---
title: Применение эффектов фигур в презентациях с использованием PHP
linktitle: Эффект фигуры
type: docs
weight: 30
url: /ru/php-java/shape-effect/
keywords:
- эффект фигуры
- эффект тени
- эффект отражения
- эффект свечения
- эффект мягких краев
- формат эффекта
- PowerPoint
- презентация
- PHP
- Aspose.Slides
description: "Преобразуйте ваши файлы PPT и PPTX с помощью продвинутых эффектов фигур, используя Aspose.Slides для PHP через Java — создавайте яркие, профессиональные слайды за секунды."
---

В то время как эффекты PowerPoint можно использовать, чтобы выделить форму, они отличаются от [fills](/slides/ru/php-java/shape-formatting/#gradient-fill) или контуров. С помощью эффектов PowerPoint можно создавать убедительные отражения на форме, распространять светящийся ореол формы и т.д.

<img src="shape-effect.png" alt="shape-effect" style="zoom:50%;" />

* PowerPoint предоставляет шесть эффектов, которые можно применять к формам. К форме можно применить один или несколько эффектов.  

* Некоторые комбинации эффектов выглядят лучше, чем другие. По этой причине в PowerPoint есть параметры под **Preset**. Параметры Preset представляют собой известную хорошо выглядящую комбинацию двух и более эффектов. Таким образом, выбрав предустановку, вам не придётся тратить время на тестирование или комбинирование разных эффектов, чтобы найти удачную комбинацию.

Aspose.Slides предоставляет свойства и методы в классе [EffectFormat](https://reference.aspose.com/slides/php-java/aspose.slides/EffectFormat), которые позволяют применять те же эффекты к формам в презентациях PowerPoint.

## **Применение эффекта тени**

Этот PHP‑код показывает, как применить внешний эффект тени ([OuterShadowEffect](https://reference.aspose.com/slides/php-java/aspose.slides/EffectFormat#setOuterShadowEffect--)) к прямоугольнику:
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


## **Применение эффекта отражения**

Этот PHP‑код показывает, как применить эффект отражения к форме:
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


## **Применение эффекта свечения**

Этот PHP‑код показывает, как применить эффект свечения к форме:
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


## **Применение эффекта мягких краёв**

Этот PHP‑код показывает, как применить мягкие края к форме:
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

**Можно ли применить несколько эффектов к одной и той же форме?**

Да, вы можете комбинировать разные эффекты, такие как тень, отражение и свечение, на одной форме, чтобы создать более динамичный вид.

**К каким формам можно применять эффекты?**

Эффекты можно применять к различным формам, включая автозаполняемые фигуры, диаграммы, таблицы, изображения, объекты SmartArt, OLE‑объекты и многое другое.

**Можно ли применять эффекты к сгруппированным формам?**

Да, эффекты можно применять к сгруппированным формам. Эффект будет применён ко всей группе.