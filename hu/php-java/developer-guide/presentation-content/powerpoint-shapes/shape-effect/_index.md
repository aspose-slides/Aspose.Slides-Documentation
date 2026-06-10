---
title: Alakzateffektusok alkalmazása prezentációkban PHP használatával
linktitle: Alakzat effektus
type: docs
weight: 30
url: /hu/php-java/shape-effect/
keywords:
- alakzat effektus
- árnyék effektus
- tükröződés effektus
- ragyogás effektus
- lágy szél effektus
- effektus formátum
- PowerPoint
- prezentáció
- PHP
- Aspose.Slides
description: "Alakítsa át PPT és PPTX fájljait fejlett alakzateffektusokkal az Aspose.Slides for PHP via Java használatával — hozzon létre lenyűgöző, professzionális diákot pillanatok alatt."
---
## **Bevezetés**

Miközben a PowerPoint hatásait arra használhatjuk, hogy egy alakzat kiemelkedjen, eltérnek a [kitöltésektől](/slides/hu/php-java/shape-formatting/#gradient-fill) vagy a körvonalaktól. A PowerPoint hatásainak segítségével meggyőző tükröződéseket hozhatunk létre egy alakzaton, szórhatjuk a ragyogást, stb.

<img src="shape-effect.png" alt="shape-effect" style="zoom:50%;" />

* A PowerPoint hat hatást biztosít, amelyeket alakzatokra lehet alkalmazni. Egy vagy több hatást alkalmazhat egy alakzatra. 

* Néhány hatáskombináció jobban néz ki, mint mások. Emiatt a PowerPoint opciói a **Preset** alatt. Az előre beállított lehetőségek lényegében egy bevált, jól kinéző kombinációt jelentenek két vagy több hatásból. Így egy előre beállított kiválasztásával nem kell időt vesztegetni a különböző hatások tesztelésével vagy kombinálásával, hogy szép kombinációt találjunk.

Az Aspose.Slides a [EffectFormat](https://reference.aspose.com/slides/hu/php-java/aspose.slides/EffectFormat) osztályban olyan tulajdonságokat és metódusokat biztosít, amelyekkel ugyanazokat a hatásokat alkalmazhatja a PowerPoint‑prezentációk alakzataira.

## **Árnyékhatás alkalmazása**

Ez a PHP‑kód mutatja, hogyan kell a külső árnyékhatást ([OuterShadowEffect](https://reference.aspose.com/slides/hu/php-java/aspose.slides/EffectFormat#setOuterShadowEffect--)) egy téglalapra alkalmazni:

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

## **Tükröződés hatás alkalmazása**

Ez a PHP‑kód mutatja, hogyan kell a tükröződés hatást egy alakzatra alkalmazni:

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

## **Ragyogás hatás alkalmazása**

Ez a PHP‑kód mutatja, hogyan kell a ragyogás hatást egy alakzatra alkalmazni:

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

## **Lágy szélek hatás alkalmazása**

Ez a PHP‑kód mutatja, hogyan kell a lágy széleket egy alakzatra alkalmazni:

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

## **GYIK**

**Alkalmazhatok több hatást ugyanarra az alakzatra?**

Igen, különböző hatásokat, például árnyékot, tükröződést és ragyogást kombinálhat egyetlen alakzaton, hogy dinamikusabb megjelenést érjen el.

**Milyen alakzatokra alkalmazhatok hatásokat?**

Különféle alakzatokra, köztük automatikus alakzatokra, diagramokra, táblázatokra, képekre, SmartArt‑elemekre, OLE‑objektumokra és egyebekre alkalmazhat hatásokat.

**Alkalmazhatok hatásokat csoportos alakzatokra?**

Igen, hatásokat csoportos alakzatokra is alkalmazhat. A hatás az egész csoporton érvényesül.