---
title: Alakzat-hatások alkalmazása prezentációkban PHP használatával
linktitle: Alakzat-hatás
type: docs
weight: 30
url: /hu/php-java/shape-effect/
keywords:
- alakzat hatás
- árnyék hatás
- tükrözési hatás
- fénylő hatás
- lágy szélek hatás
- hatás formátum
- PowerPoint
- prezentáció
- PHP
- Aspose.Slides
description: "Alakítsa át PPT és PPTX fájljait fejlett alakzat-hatásokkal az Aspose.Slides for PHP via Java segítségével—hozzon létre lenyűgöző, professzionális diákat pillanatok alatt."
---
## **Bevezetés**

Miközben a PowerPoint hatásait arra lehet használni, hogy egy alakzat kitűnjön, különböznek a [kitöltésektől](/slides/hu/php-java/shape-formatting/#gradient-fill) vagy a körvonalaktól. A PowerPoint hatásainak használatával meggyőző tükröződéseket hozhat létre egy alakzaton, elterjesztheti az alakzat fénylő effektjét stb.

![Alakzat hatás](shape-effect.png)

A PowerPoint hat hatást kínál, amelyeket alakzatokra lehet alkalmazni. Egy vagy több hatást is alkalmazhat egy alakzatra.

Néhány hatáskombináció jobban néz ki, mint mások. Emiatt a PowerPoint a **Preset** alatt kínál opciókat. A Preset opciók két vagy több hatás kombinációi, amelyekről ismert, hogy jól mutatnak. Így, ha egy előrebeállítást választ, nem kell időt vesztegetnie a különböző hatások tesztelésével vagy kombinálásával a megfelelő kombináció megtalálásához.

Az Aspose.Slides a [EffectFormat](https://reference.aspose.com/slides/php-java/aspose.slides/effectformat/) osztály alatt biztosít tulajdonságokat és metódusokat, amelyek lehetővé teszik azonos hatások alkalmazását PowerPoint‑prezentációk alakzataira.

## **Árnyékhatás Alkalmazása**

Az Aspose.Slides for PHP via Java támogatja a külső és belső árnyékokat alakzatoknál. Testreszabhatja azok színét, irányát, távolságát és elmosódási sugárát, hogy illeszkedjen a prezentációja designjához.

### **Külső Árnyék Alkalmazása**

Használjon külső árnyékot, hogy egy kártya vagy panel kitűnjön a dia háttérrel szemben. Az árnyék az alakzat szélén túlnyúlik, ezáltal azt a benyomást keltve, hogy az alakzat a dia fölött emelkedik. Állítsa be a színét, irányát, távolságát és elmosódási sugarát, hogy megfeleljen a sablon megvilágításának és stílusának.

Ez a PHP kód bemutatja, hogyan alkalmazhatja a [külső árnyék hatást](https://reference.aspose.com/slides/php-java/aspose.slides/effectformat/#getOuterShadowEffect) egy téglalapra:

```php
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;
use aspose\slides\ShapeType;

$presentation = new Presentation();
try {
    $slide = $presentation->getSlides()->get_Item(0);

    $shape = $slide->getShapes()->addAutoShape(ShapeType::RoundCornerRectangle, 20, 20, 200, 100);
    $shape->getEffectFormat()->enableOuterShadowEffect();
    $shadowColor = new Java("java.awt.Color", 169, 169, 169);
    $shape->getEffectFormat()->getOuterShadowEffect()->getShadowColor()->setColor($shadowColor);
    $shape->getEffectFormat()->getOuterShadowEffect()->setDistance(10);
    $shape->getEffectFormat()->getOuterShadowEffect()->setDirection(45);

    $presentation->save("shadow_effect.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

![Árnyékhatás](shadow_effect.png)

### **Belső Árnyék Alkalmazása**

A sablon vizuális stílusának reprodukálásakor használjon belső árnyékot, hogy egy kártya vagy panel recesszív megjelenést kapjon. A külső árnyék az alakzat külsejére nyúlik és emelkedett hatást kelt, míg a belső árnyék az alakzat széleinek belsejét árnyékolja.

Hívja meg a [enableInnerShadowEffect](https://reference.aspose.com/slides/php-java/aspose.slides/effectformat/#enableInnerShadowEffect) metódust, majd állítsa be a [getInnerShadowEffect](https://reference.aspose.com/slides/php-java/aspose.slides/effectformat/#getInnerShadowEffect) által visszaadott árnyékot. A nagyobb elmosódási sugár értékek lágyabb széleket eredményeznek.

Ez a PHP példa egy világoskék kártyát hoz létre sötétszürke belső árnyékkal, és PPTX fájlként menti. Az árnyék iránya 225 fok, távolsága 7 pont, és elmosódási sugara 6 pont:

```php
use aspose\slides\FillType;
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;
use aspose\slides\ShapeType;

$presentation = new Presentation();
try {
    $slide = $presentation->getSlides()->get_Item(0);

    $shape = $slide->getShapes()->addAutoShape(ShapeType::Rectangle, 20, 20, 200, 100);
    $shape->getFillFormat()->setFillType(FillType::Solid);
    $fillColor = new Java("java.awt.Color", 173, 216, 230);
    $shape->getFillFormat()->getSolidFillColor()->setColor($fillColor);
    $shape->getLineFormat()->getFillFormat()->setFillType(FillType::NoFill);

    $shape->getEffectFormat()->enableInnerShadowEffect();
    $shadow = $shape->getEffectFormat()->getInnerShadowEffect();
    $shadowColor = new Java("java.awt.Color", 105, 105, 105);
    $shadow->getShadowColor()->setColor($shadowColor);
    $shadow->setDirection(225);
    $shadow->setDistance(7);
    $shadow->setBlurRadius(6);

    $presentation->save("inner_shadow_effect.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

![Világoskék téglalap belső árnyékkal](inner_shadow_effect.png)

A belső árnyék eltávolításához hívja meg a [disableInnerShadowEffect](https://reference.aspose.com/slides/php-java/aspose.slides/effectformat/#disableInnerShadowEffect) metódust az alakzat effektusformátumán.

## **Tükrözési Hatás Alkalmazása**

A refléxiós (tükrözési) hatás alkalmazásához az Aspose.Slides for PHP via Java-ban hozzáadhat egy tükörszerű tükröződést alakzatokhoz, beállítva olyan paramétereket, mint a távolság, átlátszóság és méret. Ez a hatás javítja a prezentációk esztétikáját, mivel az alakzatoknak kifinomultabb, csiszoltabb megjelenést kölcsönöz. Egyszerű kóddal könnyen megvalósítható, lehetővé téve a gyors alkalmazást több elemen a konzisztens dizájn érdekében.

Ez a PHP kód bemutatja, hogyan alkalmazhatja a [tükrözési hatást](https://reference.aspose.com/slides/php-java/aspose.slides/effectformat/#getReflectionEffect) egy alakzatra:

```php
use aspose\slides\Presentation;
use aspose\slides\RectangleAlignment;
use aspose\slides\SaveFormat;
use aspose\slides\ShapeType;

$presentation = new Presentation();
try {
    $slide = $presentation->getSlides()->get_Item(0);

    $shape = $slide->getShapes()->addAutoShape(ShapeType::RoundCornerRectangle, 20, 20, 200, 100);
    $shape->getEffectFormat()->enableReflectionEffect();
    $shape->getEffectFormat()->getReflectionEffect()->setRectangleAlign(RectangleAlignment::Bottom);
    $shape->getEffectFormat()->getReflectionEffect()->setDirection(90);
    $shape->getEffectFormat()->getReflectionEffect()->setDistance(40);
    $shape->getEffectFormat()->getReflectionEffect()->setBlurRadius(2);

    $presentation->save("reflection_effect.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

![Tükrözési hatás](reflection_effect.png)

## **Fénylő Hatás Alkalmazása**

Az Aspose.Slides for PHP via Java-ban a fénylő hatás alkalmazásához hozzáadhat egy finom, ragyogó aurát az alakzatok köré, beállítva például a színt és a méretet. Ez a hatás segít kiemelni az alakzatokat, és vonzó, figyelemfelkeltő vizuális elemet ad a prezentációhoz. Minimális kóddal könnyen megvalósítható, javítva a diák általános megjelenését.

Ez a PHP kód bemutatja, hogyan alkalmazhatja a [fénylő hatást](https://reference.aspose.com/slides/php-java/aspose.slides/effectformat/#getGlowEffect) egy alakzatra:

```php
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;
use aspose\slides\ShapeType;

$presentation = new Presentation();
try {
    $slide = $presentation->getSlides()->get_Item(0);

    $shape = $slide->getShapes()->addAutoShape(ShapeType::RoundCornerRectangle, 20, 20, 200, 100);
    $shape->getEffectFormat()->enableGlowEffect();
    $shape->getEffectFormat()->getGlowEffect()->getColor()->setColor(java("java.awt.Color")->MAGENTA);
    $shape->getEffectFormat()->getGlowEffect()->setRadius(15);

    $presentation->save("glow_effect.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

![Fénylő hatás](glow_effect.png)

## **Lágy Szélek Hatás Alkalmazása**

Az Aspose.Slides for PHP via Java-ban a lágy szélek hatás alkalmazásához létrehozhat egy sima, elmosódott átmenetet egy alakzat szélei körül. Ez a hatás finomabb és kifinomultabb megjelenést kölcsönöz, tökéletes olyan tervekhez, amelyeknek gyengédebb, lágyabb kiemelésre van szükségük. Könnyen beállíthatja a paramétereket, például a sugárértéket, hogy a kívánt hatást elérje különböző alakzatoknál a prezentációban.

Ez a PHP kód bemutatja, hogyan alkalmazhatja a [lágy szélek hatást](https://reference.aspose.com/slides/php-java/aspose.slides/effectformat/#getSoftEdgeEffect) egy alakzatra:

```php
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;
use aspose\slides\ShapeType;

$presentation = new Presentation();
try {
    $slide = $presentation->getSlides()->get_Item(0);

    $shape = $slide->getShapes()->addAutoShape(ShapeType::RoundCornerRectangle, 20, 20, 200, 150);
    $shape->getEffectFormat()->enableSoftEdgeEffect();
    $shape->getEffectFormat()->getSoftEdgeEffect()->setRadius(8);

    $presentation->save("soft_edges_effect.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

![Lágy szélek hatás](soft_edges_effect.png)

## **GYIK**

**Alkalmazhatok több effektet ugyanarra az alakzatra?**

Igen, kombinálhat különböző effektusokat, például árnyékot, tükrözést és fénylő hatást egyetlen alakzaton, hogy dinamikusabb megjelenést érjen el.

**Milyen alakzatokra alkalmazhatok effektusokat?**

Különféle alakzatokra alkalmazhat effektusokat, beleértve az autoshape-eket, diagramokat, táblázatokat, képeket, SmartArt objektumokat, OLE objektumokat és egyebeket.

**Alkalmazhatok effektusokat csoportosított alakzatokra?**

Igen, alkalmazhat effektusokat csoportosított alakzatokra. A hatás az egész csoportra vonatkozik.