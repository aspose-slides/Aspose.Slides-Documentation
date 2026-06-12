---
title: Aplikovat efekty tvarů v prezentacích pomocí PHP
linktitle: Efekt tvaru
type: docs
weight: 30
url: /cs/php-java/shape-effect/
keywords:
- efekt tvaru
- efekt stínu
- efekt odrazu
- efekt záře
- efekt měkkých hran
- formát efektu
- PowerPoint
- prezentace
- PHP
- Aspose.Slides
description: "Přetvořte své soubory PPT a PPTX pomocí pokročilých efektů tvarů s Aspose.Slides pro PHP přes Java — vytvořte během několika sekund nápadité a profesionální snímky."
---
## **Úvod**

Zatímco efekty v PowerPointu lze použít k zvýraznění tvaru, liší se od [vyplnění](/slides/cs/php-java/shape-formatting/#gradient-fill) nebo obrysů. Pomocí efektů v PowerPointu můžete vytvořit přesvědčivé odrazy na tvaru, rozšířit záři tvaru atd.

<img src="shape-effect.png" alt="efekt-tvaru" style="zoom:50%;" />

* PowerPoint poskytuje šest efektů, které lze použít na tvary. Můžete použít jeden nebo více efektů na tvar. 

* Některé kombinace efektů vypadají lépe než jiné. Z tohoto důvodu jsou v PowerPointu možnosti pod **Preset**. Předvolby v podstatě představují osvědčenou dobře vypadající kombinaci dvou nebo více efektů. Tímto způsobem, když vyberete předvolbu, nebudete muset ztrácet čas testováním nebo kombinováním různých efektů, abyste našli vhodnou kombinaci.

Aspose.Slides poskytuje vlastnosti a metody ve třídě [EffectFormat](https://reference.aspose.com/slides/cs/php-java/aspose.slides/EffectFormat), které vám umožní použít stejné efekty na tvary v prezentacích PowerPoint.

## **Použít efekt stínu**

Tento PHP kód vám ukazuje, jak použít efekt vnějšího stínu ([OuterShadowEffect](https://reference.aspose.com/slides/cs/php-java/aspose.slides/EffectFormat#setOuterShadowEffect--)) na obdélník:

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

## **Použít efekt odrazu**

Tento PHP kód vám ukazuje, jak použít efekt odrazu na tvar:

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

## **Použít efekt záře**

Tento PHP kód vám ukazuje, jak použít efekt záře na tvar:

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

## **Použít efekt měkkých hran**

Tento PHP kód vám ukazuje, jak použít měkké hrany na tvar:

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

**Mohu použít více efektů na stejný tvar?**

Ano, můžete kombinovat různé efekty, jako je stín, odraz a záře, na jednom tvaru a vytvořit tak dynamičtější vzhled.

**Na jaké tvary mohu aplikovat efekty?**

Efekty můžete použít na různé tvary, včetně automatických tvarů, grafů, tabulek, obrázků, objektů SmartArt, OLE objektů a dalších.

**Mohu použít efekty na seskupené tvary?**

Ano, můžete použít efekty na seskupené tvary. Efekt bude aplikován na celou skupinu.